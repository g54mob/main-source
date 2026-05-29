using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Utf8Json.Internal.Emit
{
	internal class DynamicAssembly
	{
		private readonly AssemblyBuilder assemblyBuilder;

		private readonly ModuleBuilder moduleBuilder;

		private readonly object gate;

		public TypeBuilder DefineType(string name, TypeAttributes attr)
		{
			return null;
		}

		public TypeBuilder DefineType(string name, TypeAttributes attr, Type parent)
		{
			return null;
		}

		public TypeBuilder DefineType(string name, TypeAttributes attr, Type parent, Type[] interfaces)
		{
			return null;
		}

		public DynamicAssembly(string moduleName)
		{
		}
	}
}
