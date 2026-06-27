using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FluentAssertions.Common
{
	internal static class TypeReflector
	{
		public static IEnumerable<Type> GetAllTypesFromAppDomain(Func<Assembly, bool> predicate)
		{
			return (from a in AppDomain.CurrentDomain.GetAssemblies()
				where !IsDynamic(a) && IsRelevant(a) && predicate(a)
				select a).SelectMany(GetExportedTypes).ToArray();
		}

		private static bool IsRelevant(Assembly ass)
		{
			string name = ass.GetName().Name;
			if (name != null && !name.StartsWith("microsoft.", StringComparison.OrdinalIgnoreCase) && !name.StartsWith("xunit", StringComparison.OrdinalIgnoreCase) && !name.StartsWith("jetbrains.", StringComparison.OrdinalIgnoreCase) && !name.StartsWith("system", StringComparison.OrdinalIgnoreCase) && !name.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase))
			{
				return !name.StartsWith("newtonsoft", StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		private static bool IsDynamic(Assembly assembly)
		{
			string fullName = assembly.GetType().FullName;
			if (fullName == "System.Reflection.Emit.AssemblyBuilder" || fullName == "System.Reflection.Emit.InternalAssemblyBuilder")
			{
				return true;
			}
			return false;
		}

		private static IEnumerable<Type> GetExportedTypes(Assembly assembly)
		{
			try
			{
				return assembly.GetExportedTypes();
			}
			catch (ReflectionTypeLoadException ex)
			{
				return ex.Types;
			}
			catch (FileLoadException)
			{
				return Array.Empty<Type>();
			}
			catch (Exception)
			{
				return Array.Empty<Type>();
			}
		}
	}
}
