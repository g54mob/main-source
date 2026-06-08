using System;
using System.Collections.Generic;
using Stonescript.Compiler;

namespace Stonescript.Runtime
{
	public class Executable
	{
		public Script script;

		public DateTime buildTimestamp;

		public Machine machine;

		public Scope Target { get; set; }

		public Action Action => delegate
		{
			Execute();
		};

		public object Execute(ExecutionContext execCtx = null)
		{
			return machine.Execute(this, execCtx);
		}

		public object Execute(string funcName, IEnumerable<object> parameters = null, ExecutionContext execCtx = null, bool gracefulFail = false)
		{
			IFunction function = null;
			try
			{
				function = Target.GetFunction(funcName);
			}
			catch (Exception)
			{
				if (gracefulFail)
				{
					return null;
				}
				throw;
			}
			return machine.Execute(this, function, parameters, execCtx);
		}

		public object Execute(IFunction function, List<object> parameters = null, ExecutionContext execCtx = null)
		{
			return machine.Execute(this, function, parameters, execCtx);
		}

		public object Execute(NativeFunction.Callback funcCallback, List<object> parameters = null, ExecutionContext execCtx = null)
		{
			NativeFunction function = new NativeFunction(Target, funcCallback);
			return machine.Execute(this, function, parameters, execCtx);
		}

		public object Evaluate(string expression, ExecutionContext execCtx = null)
		{
			ExecutionContext executionContext = null;
			if (execCtx == null)
			{
				execCtx = machine.CreateExecutionContext();
				executionContext = execCtx;
			}
			execCtx.Push(this);
			execCtx.Push(new Scope(Target));
			object result = machine.EvaluateExpression(expression, execCtx);
			execCtx.Pop();
			execCtx.PopExecutable();
			if (executionContext != null)
			{
				machine.execCtxPool.Return(executionContext);
			}
			return result;
		}

		public void Recompile()
		{
			machine.Recompile(this);
		}
	}
}
