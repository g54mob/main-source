using System;
using System.Collections.Generic;
using Stonescript.Compiler;

namespace Stonescript.Runtime
{
	public class ExecutionContext
	{
		public Machine machine;

		public Processor processor;

		public StonescriptParser.StmtContext CurrentStatement;

		public bool returned;

		public object returnValue;

		public bool breaked;

		public bool continued;

		public List<InvocationContext> callStack = new List<InvocationContext>();

		private List<Executable> executableStack = new List<Executable>();

		public long startTime;

		private HashSet<Scope> managedScopes = new HashSet<Scope>();

		public string ScriptName => CurrentExecutable.script.name;

		public int LineNumber => CurrentStatement.Start.Line;

		public InvocationContext CurrentInvocationContext
		{
			get
			{
				if (callStack.Count <= 0)
				{
					return null;
				}
				return callStack[callStack.Count - 1];
			}
		}

		public Scope CurrentTarget
		{
			get
			{
				if (callStack.Count <= 0)
				{
					return null;
				}
				return callStack[callStack.Count - 1].scope;
			}
		}

		public Executable CurrentExecutable
		{
			get
			{
				if (executableStack.Count <= 0)
				{
					return null;
				}
				return executableStack[executableStack.Count - 1];
			}
		}

		public string StackTrace
		{
			get
			{
				string text = "";
				for (int num = callStack.Count - 1; num >= 0; num--)
				{
					InvocationContext invocationContext = callStack[num];
					if (invocationContext.function != null)
					{
						if (invocationContext.function is ScriptFunction)
						{
							ScriptFunction scriptFunction = invocationContext.function as ScriptFunction;
							text += $"{scriptFunction.executable.script.name}.{scriptFunction.Name} line {invocationContext.LineNumber}\n";
						}
						else
						{
							text = text + "Stonescript.Engine." + invocationContext.function.Name + "\n";
						}
					}
					else
					{
						text += $"{invocationContext.ScriptName} line {invocationContext.LineNumber}\n";
					}
				}
				return text;
			}
		}

		public void Reset()
		{
			foreach (Scope managedScope in managedScopes)
			{
				machine.scopePool.Return(managedScope);
			}
			managedScopes.Clear();
			machine = null;
			processor = null;
			CurrentStatement = null;
			returned = false;
			returnValue = null;
			breaked = false;
			continued = false;
			startTime = 0L;
			callStack.Clear();
			executableStack.Clear();
		}

		public InvocationContext Push(StonescriptObject target, IFunction function, List<object> parameters)
		{
			Scope scope = machine.scopePool.Get().Init(target);
			managedScopes.Add(scope);
			InvocationContext invocationContext = machine.invCtxPool.Get().Init(this, target, function, parameters, scope);
			invocationContext.parent = CurrentInvocationContext;
			invocationContext.node = CurrentStatement;
			invocationContext.executable = CurrentExecutable;
			callStack.Add(invocationContext);
			if (callStack.Count > machine.MAX_CALL_DEPTH)
			{
				throw new StackOverflowException();
			}
			return invocationContext;
		}

		public InvocationContext Push(Scope scope, StonescriptObject owner = null)
		{
			InvocationContext invocationContext = machine.invCtxPool.Get().Init(this, owner, null, null, scope);
			invocationContext.parent = CurrentInvocationContext;
			invocationContext.node = CurrentStatement;
			invocationContext.executable = CurrentExecutable;
			callStack.Add(invocationContext);
			if (callStack.Count > machine.MAX_CALL_DEPTH)
			{
				throw new StackOverflowException();
			}
			return invocationContext;
		}

		public void Pop()
		{
			InvocationContext invocationContext = callStack[callStack.Count - 1];
			callStack.RemoveAt(callStack.Count - 1);
			if (managedScopes.Contains(invocationContext.scope))
			{
				managedScopes.Remove(invocationContext.scope);
				machine.scopePool.Return(invocationContext.scope);
			}
			machine.invCtxPool.Return(invocationContext);
		}

		public InvocationContext Push(Executable executable)
		{
			executableStack.Add(executable);
			return Push(executable.Target, executable.Target);
		}

		public InvocationContext Push(Executable executable, IFunction function, List<object> parameters)
		{
			executableStack.Add(executable);
			return Push(executable.Target, function, parameters);
		}

		public Executable PopExecutable()
		{
			Executable result = executableStack[executableStack.Count - 1];
			executableStack.RemoveAt(executableStack.Count - 1);
			Pop();
			return result;
		}
	}
}
