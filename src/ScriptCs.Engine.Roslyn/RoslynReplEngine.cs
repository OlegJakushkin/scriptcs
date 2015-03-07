﻿using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Microsoft.CodeAnalysis.Scripting;
using ScriptCs.Contracts;

namespace ScriptCs.Engine.Roslyn
{
    public class RoslynReplEngine : RoslynScriptEngine, IReplEngine
    {
        public RoslynReplEngine(IScriptHostFactory scriptHostFactory, ILog logger)
            : base(scriptHostFactory, logger)
        {
        }

        public ICollection<string> GetLocalVariables(ScriptPackSession scriptPackSession)
        {
            if (scriptPackSession != null && scriptPackSession.State.ContainsKey(SessionKey))
            {
                var sessionState = (SessionState<ScriptState>) scriptPackSession.State[SessionKey];
                return sessionState.Session.Variables.Select(x => string.Format("{0} {1}", x.Type, x.Name)).ToArray();
            }

            return new string[0];
        }

        protected override ScriptResult Execute(string code, object globals, SessionState<ScriptState> sessionState)
        {
            return string.IsNullOrWhiteSpace(FileName) && !IsCompleteSubmission(code)
                ? ScriptResult.Incomplete
                : base.Execute(code, globals, sessionState);
        }
    }
}