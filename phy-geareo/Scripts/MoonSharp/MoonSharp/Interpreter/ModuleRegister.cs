using System;
using System.Reflection;

namespace MoonSharp.Interpreter
{
	public static class ModuleRegister
	{
		public static Table RegisterCoreModules(this Table table, CoreModules modules)
		{
			return null;
		}

		public static Table RegisterConstants(this Table table)
		{
			return null;
		}

		public static Table RegisterModuleType(this Table gtable, Type t)
		{
			return null;
		}

		private static void RegisterScriptFieldAsConst(FieldInfo fi, object o, Table table, Type t, string name)
		{
		}

		private static void RegisterScriptField(FieldInfo fi, object o, Table table, Type t, string name)
		{
		}

		private static Table CreateModuleNamespace(Table gtable, Type t)
		{
			return null;
		}

		public static Table RegisterModuleType<T>(this Table table)
		{
			return null;
		}
	}
}
