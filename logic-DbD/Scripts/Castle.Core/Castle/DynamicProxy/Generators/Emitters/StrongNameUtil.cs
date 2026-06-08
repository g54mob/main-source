using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal static class StrongNameUtil
	{
		private static readonly IDictionary<Assembly, bool> signedAssemblyCache = new Dictionary<Assembly, bool>();

		private static readonly object lockObject = new object();

		public static bool IsAssemblySigned(this Assembly assembly)
		{
			lock (lockObject)
			{
				if (!signedAssemblyCache.TryGetValue(assembly, out var value))
				{
					value = assembly.ContainsPublicKey();
					signedAssemblyCache.Add(assembly, value);
				}
				return value;
			}
		}

		private static bool ContainsPublicKey(this Assembly assembly)
		{
			if (assembly.FullName != null)
			{
				return !assembly.FullName.Contains("PublicKeyToken=null");
			}
			return false;
		}

		public static bool IsAnyTypeFromUnsignedAssembly(IEnumerable<Type> types)
		{
			return types.Any((Type t) => !t.Assembly.IsAssemblySigned());
		}

		public static bool IsAnyTypeFromUnsignedAssembly(Type baseType, IEnumerable<Type> interfaces)
		{
			if (baseType != null && !baseType.Assembly.IsAssemblySigned())
			{
				return true;
			}
			return IsAnyTypeFromUnsignedAssembly(interfaces);
		}
	}
}
