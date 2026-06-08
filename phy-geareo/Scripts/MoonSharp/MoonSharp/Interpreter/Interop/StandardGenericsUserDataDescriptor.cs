using System;

namespace MoonSharp.Interpreter.Interop
{
	public class StandardGenericsUserDataDescriptor : IUserDataDescriptor, IGeneratorUserDataDescriptor
	{
		public InteropAccessMode AccessMode { get; private set; }

		public string Name { get; private set; }

		public Type Type { get; private set; }

		public StandardGenericsUserDataDescriptor(Type type, InteropAccessMode accessMode)
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

		public IUserDataDescriptor Generate(Type type)
		{
			return null;
		}
	}
}
