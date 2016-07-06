﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using WebJobs.Script.ConsoleHost.Common;

namespace WebJobs.Script.ConsoleHost.Commands
{
    [CommandNames("gs", "get-settings")]
    public class GetSettingsCommand : FunctionAppBaseCommand
    {
        public override Task Run()
        {
            throw new Exception();
        }
    }
}
