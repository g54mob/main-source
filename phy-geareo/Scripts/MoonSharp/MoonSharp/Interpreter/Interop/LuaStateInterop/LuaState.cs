using System.Collections.Generic;

namespace MoonSharp.Interpreter.Interop.LuaStateInterop
{
	public class LuaState
	{
		private List<DynValue> m_Stack;

		public ScriptExecutionContext ExecutionContext { get; private set; }

		public string FunctionName { get; private set; }

		public int Count => 0;

		internal LuaState(ScriptExecutionContext executionContext, CallbackArguments args, string functionName)
		{
		}

		public DynValue Top(int pos = 0)
		{
			return null;
		}

		public DynValue At(int pos)
		{
			return null;
		}

		public void Push(DynValue v)
		{
		}

		public DynValue Pop()
		{
			return null;
		}

		public DynValue[] GetTopArray(int num)
		{
			return null;
		}

		public DynValue GetReturnValue(int retvals)
		{
			return null;
		}

		public void Discard(int nargs)
		{
		}
	}
}
