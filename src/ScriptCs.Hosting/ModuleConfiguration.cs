﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScriptCs.Contracts;

namespace ScriptCs.Hosting
{
    public class ModuleConfiguration : ServiceOverrides<IModuleConfiguration>, IModuleConfiguration
    {
        public ModuleConfiguration(bool debug, string scriptName, bool repl, LogLevel logLevel, IDictionary<Type,Object> overrides)
            :base(overrides)
        {
            this.InMemory = debug;
            ScriptName = scriptName;
            Repl = repl;
            LogLevel = logLevel;
        }

        public bool InMemory { get; private set; }
        public string ScriptName { get; private set; }
        public bool Repl { get; private set; }
        public LogLevel LogLevel { get; private set; }
    }
}
