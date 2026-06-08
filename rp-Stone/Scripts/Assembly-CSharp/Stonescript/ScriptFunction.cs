using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Stonescript.Runtime;

namespace Stonescript
{
	public class ScriptFunction : IFunction
	{
		private string name;

		private List<string> parameterNames;

		public Executable executable;

		public ParserRuleContext declarationContext;

		public string Name => name;

		public List<string> ParameterNames
		{
			get
			{
				return parameterNames;
			}
			set
			{
				parameterNames = value;
			}
		}

		public ScriptFunction(string name, List<string> parameterNames, ParserRuleContext declarationContext, Executable executable)
		{
			this.name = name;
			this.parameterNames = parameterNames;
			this.declarationContext = declarationContext;
			this.executable = executable;
		}

		public object Invoke(List<object> parameters, InvocationContext invCtx)
		{
			InvocationContext invocationContext = null;
			ExecutionContext executionContext = null;
			if (invCtx == null)
			{
				if (executable.machine.Processor.ExecutionContext == null)
				{
					executionContext = executable.machine.execCtxPool.Get();
					executionContext.machine = executable.machine;
					executionContext.processor = executable.machine.Processor;
					executable.machine.Processor.ExecutionContext = executionContext;
					executionContext.startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
				}
				invocationContext = executable.machine.Processor.ExecutionContext.Push(executable, this, parameters);
				invCtx = invocationContext;
			}
			object result = executable.machine.Processor.Invoke(this, declarationContext, parameters, invCtx);
			if (invocationContext != null)
			{
				executable.machine.Processor.ExecutionContext.PopExecutable();
				if (executionContext != null)
				{
					executable.machine.Processor.ExecutionContext = null;
					executable.machine.execCtxPool.Return(executionContext);
				}
			}
			return result;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
