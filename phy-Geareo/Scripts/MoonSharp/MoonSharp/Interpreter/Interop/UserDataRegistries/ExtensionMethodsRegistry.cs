using System;
using System.Collections.Generic;
using System.Reflection;
using MoonSharp.Interpreter.DataStructs;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter.Interop.UserDataRegistries
{
	internal class ExtensionMethodsRegistry
	{
		private class UnresolvedGenericMethod
		{
			public readonly MethodInfo Method;

			public readonly InteropAccessMode AccessMode;

			public readonly HashSet<Type> AlreadyAddedTypes;

			public UnresolvedGenericMethod(MethodInfo mi, InteropAccessMode mode)
			{
			}
		}

		private static object s_Lock;

		private static MultiDictionary<string, IOverloadableMemberDescriptor> s_Registry;

		private static MultiDictionary<string, UnresolvedGenericMethod> s_UnresolvedGenericsRegistry;

		private static int s_ExtensionMethodChangeVersion;

		public static void RegisterExtensionType(Type type, InteropAccessMode mode = InteropAccessMode.Default)
		{
		}

		private static object FrameworkGetMethods()
		{
			return null;
		}

		public static IEnumerable<IOverloadableMemberDescriptor> GetExtensionMethodsByName(string name)
		{
			return null;
		}

		public static int GetExtensionMethodsChangeVersion()
		{
			return 0;
		}

		public static List<IOverloadableMemberDescriptor> GetExtensionMethodsByNameAndType(string name, Type extendedType)
		{
			return null;
		}

		private static MethodInfo InstantiateMethodInfo(MethodInfo mi, Type extensionType, Type genericType, Type extendedType)
		{
			return null;
		}

		private static Type GetGenericMatch(Type extensionType, Type extendedType)
		{
			return null;
		}
	}
}
