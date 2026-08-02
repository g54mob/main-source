using System.Collections.Generic;
using MoonSharp.Interpreter.Execution;

namespace MoonSharp.Interpreter
{
	public class Closure : RefIdObject, IScriptPrivateResource
	{
		public enum UpvaluesType
		{
			None = 0,
			Environment = 1,
			Closure = 2
		}

		private static ClosureContext emptyClosure;

		public int EntryPointByteCodeLocation { get; private set; }

		public Script OwnerScript { get; private set; }

		internal ClosureContext ClosureContext { get; private set; }

		internal Closure(Script script, int idx, SymbolRef[] symbols, IEnumerable<DynValue> resolvedLocals)
		{
		}

		public DynValue Call()
		{
			return null;
		}

		public DynValue Call(params object[] args)
		{
			return null;
		}

		public DynValue Call(params DynValue[] args)
		{
			return null;
		}

		public ScriptFunctionDelegate GetDelegate()
		{
			return null;
		}

		public ScriptFunctionDelegate<T> GetDelegate<T>()
		{
			return null;
		}

		public int GetUpvaluesCount()
		{
			return 0;
		}

		public string GetUpvalueName(int idx)
		{
			return null;
		}

		public DynValue GetUpvalue(int idx)
		{
			return null;
		}

		public UpvaluesType GetUpvaluesType()
		{
			return default(UpvaluesType);
		}
	}
}
