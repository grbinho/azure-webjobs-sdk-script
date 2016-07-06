﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.Azure.WebJobs.Host;
using WebJobs.Script.ConsoleHost.Common;

namespace WebJobs.Script.ConsoleHost.Commands
{
    public abstract class Command
    {
        private string _logFile;

        [Option("logFile", DefaultValue = "", HelpText = "")]
        public string LogFile
        {
            get { return _logFile; }
            set
            {
                _logFile = value;
                EnsureTracer();
            }
        }

        [Option('q', "quiet", DefaultValue = false, HelpText = "")]
        public bool Quiet { get; set; }

        public string OriginalCommand { get; set; }

        private void EnsureTracer()
        {
            if (Tracer == null)
            {
                if (string.IsNullOrEmpty(LogFile))
                {
                    Tracer = new ConsoleTracer(TraceLevel.Info);
                }
                else
                {
                    Tracer = new FileTracer(TraceLevel.Info, LogFile);
                }
            }
        }

        public TraceWriter Tracer { get; private set; }

        public void TraceInfo(string message)
        {
            EnsureTracer();
            if (!Quiet)
            {
                message = message?.TrimEnd(new[] { '\n', '\r' });
                if (!string.IsNullOrEmpty(message))
                {
                    Tracer.Info(message, Constants.CliTracingSource);
                }
            }
        }

        public abstract Task Run();
    }
}