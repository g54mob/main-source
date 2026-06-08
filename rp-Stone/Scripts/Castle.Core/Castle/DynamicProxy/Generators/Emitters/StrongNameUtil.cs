using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public static class StrongNameUtil
	{
		private static readonly IDictionary<Assembly, bool> signedAssemblyCache;

		private static readonly object lockObject;

		public static bool CanStrongNameAssembly { get; set; }

		[SecuritySafeCritical]
		static StrongNameUtil()
		{
			signedAssemblyCache = new Dictionary<Assembly, bool>();
			lockObject = new object();
			try
			{
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
				CanStrongNameAssembly = true;
			}
			catch (SecurityException)
			{
				CanStrongNameAssembly = false;
			}
		}

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
			return types.Any((Type t) => !t.GetTypeInfo().Assembly.IsAssemblySigned());
		}

		public static bool IsAnyTypeFromUnsignedAssembly(Type baseType, IEnumerable<Type> interfaces)
		{
			if (baseType != null && !baseType.GetTypeInfo().Assembly.IsAssemblySigned())
			{
				return true;
			}
			return IsAnyTypeFromUnsignedAssembly(interfaces);
		}
	}
}
