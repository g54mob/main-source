using System;

namespace MoonSharp.Interpreter.Interop.StandardDescriptors
{
	internal class EventFacade : IUserDataType
	{
		private Func<object, ScriptExecutionContext, CallbackArguments, DynValue> m_AddCallback;

		private Func<object, ScriptExecutionContext, CallbackArguments, DynValue> m_RemoveCallback;

		private object m_Object;

		public EventFacade(EventMemberDescriptor parent, object obj)
		{
		}

		public EventFacade(Func<object, ScriptExecutionContext, CallbackArguments, DynValue> addCallback, Func<object, ScriptExecutionContext, CallbackArguments, DynValue> removeCallback, object obj)
		{
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
