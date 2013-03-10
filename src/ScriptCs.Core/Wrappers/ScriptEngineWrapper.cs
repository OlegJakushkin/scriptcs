﻿using System.ComponentModel.Composition;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;

namespace ScriptCs.Wrappers
{
    internal class ScriptEngineWrapper : IScriptEngine
    {
        private CommonScriptEngine scriptEngine;

        [ImportingConstructor]
        public ScriptEngineWrapper()
        {
            this.scriptEngine = new ScriptEngine();
        }

        public ScriptEngineWrapper(CommonScriptEngine engine)
        {
            this.scriptEngine = engine;
        }

        public string BaseDirectory
        {
            get
            {
                return this.scriptEngine.BaseDirectory;
            }

            set
            {
                this.scriptEngine.BaseDirectory = value;
            }
        }

        public void AddReference(string assemblyDisplayNameOrPath)
        {
            this.scriptEngine.AddReference(assemblyDisplayNameOrPath);
        }

        public ISession CreateSession()
        {
            return new SessionWrapper(this.scriptEngine.CreateSession());
        }

        public ISession CreateSession<THostObject>(THostObject hostObject) where THostObject : class
        {
            return new SessionWrapper(this.scriptEngine.CreateSession(hostObject));
        }

        public ISession CreateSession(object hostObject, System.Type hostObjectType = null)
        {
            return new SessionWrapper(this.scriptEngine.CreateSession(hostObject, hostObjectType));
        }
    }
}