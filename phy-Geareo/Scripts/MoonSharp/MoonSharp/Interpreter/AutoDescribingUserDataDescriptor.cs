using System;
using MoonSharp.Interpreter.Interop;

namespace MoonSharp.Interpreter
{
	internal class AutoDescribingUserDataDescriptor : IUserDataDescriptor
	{
		private string m_FriendlyName;

		private Type m_Type;

		public string Name => null;

		public Type Type => null;

		public AutoDescribingUserDataDescriptor(Type type, string friendlyName)
		{
		}

		public DynValue Index(Script script, object obj, DynValue index, bool isDirectIndexing)
		{
			return null;
		}

		public bool SetIndex(Script script, object obj, DynValue index, DynValue value, bool isDirectIndexing)
		{
			return false;
		}

		public string AsString(object obj)
		{
			return null;
		}

		public DynValue MetaIndex(Script script, object obj, string metaname)
		{
			return null;
		}

		public bool IsTypeCompatible(Type type, object obj)
		{
			return false;
		}
	}
}
