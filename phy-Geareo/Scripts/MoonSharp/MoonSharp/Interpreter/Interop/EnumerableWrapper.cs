using System.Collections;

namespace MoonSharp.Interpreter.Interop
{
	internal class EnumerableWrapper : IUserDataType
	{
		private IEnumerator m_Enumerator;

		private Script m_Script;

		private DynValue m_Prev;

		private bool m_HasTurnOnce;

		private EnumerableWrapper(Script script, IEnumerator enumerator)
		{
		}

		public void Reset()
		{
		}

		private DynValue GetNext(DynValue prev)
		{
			return null;
		}

		private DynValue LuaIteratorCallback(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		internal static DynValue ConvertIterator(Script script, IEnumerator enumerator)
		{
			return null;
		}

		internal static DynValue ConvertTable(Table table)
		{
			return null;
		}

		public DynValue Index(Script script, DynValue index, bool isDirectIndexing)
		{
			return null;
		}

		public bool SetIndex(Script script, DynValue index, DynValue value, bool isDirectIndexing)
		{
			return false;
		}

		public DynValue MetaIndex(Script script, string metaname)
		{
			return null;
		}
	}
}
