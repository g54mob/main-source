using System.Collections.Generic;

namespace MoonSharp.Interpreter
{
	public class CallbackArguments
	{
		private IList<DynValue> m_Args;

		private int m_Count;

		private bool m_LastIsTuple;

		public int Count => 0;

		public bool IsMethodCall { get; private set; }

		public DynValue this[int index] => null;

		public CallbackArguments(IList<DynValue> args, bool isMethodCall)
		{
		}

		public DynValue RawGet(int index, bool translateVoids)
		{
			return null;
		}

		public DynValue[] GetArray(int skip = 0)
		{
			return null;
		}

		public DynValue AsType(int argNum, string funcName, DataType type, bool allowNil = false)
		{
			return null;
		}

		public T AsUserData<T>(int argNum, string funcName, bool allowNil = false)
		{
			return default(T);
		}

		public int AsInt(int argNum, string funcName)
		{
			return 0;
		}

		public long AsLong(int argNum, string funcName)
		{
			return 0L;
		}

		public string AsStringUsingMeta(ScriptExecutionContext executionContext, int argNum, string funcName)
		{
			return null;
		}

		public CallbackArguments SkipMethodCall()
		{
			return null;
		}
	}
}
