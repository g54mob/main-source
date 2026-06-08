using System;
using System.Collections.Generic;

namespace MoonSharp.Interpreter.Interop
{
	public class CompositeUserDataDescriptor : IUserDataDescriptor
	{
		private List<IUserDataDescriptor> m_Descriptors;

		private Type m_Type;

		public IList<IUserDataDescriptor> Descriptors => null;

		public string Name => null;

		public Type Type => null;

		public CompositeUserDataDescriptor(List<IUserDataDescriptor> descriptors, Type type)
		{
		}

		public DynValue Index(Script script, object obj, DynValue index, bool isNameIndex)
		{
			return null;
		}

		public bool SetIndex(Script script, object obj, DynValue index, DynValue value, bool isNameIndex)
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
