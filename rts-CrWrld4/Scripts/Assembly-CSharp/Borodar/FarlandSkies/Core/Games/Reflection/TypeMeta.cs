using System;
using System.Collections.Generic;
using System.Reflection;

namespace Borodar.FarlandSkies.Core.Games.Reflection
{
	public static class TypeMeta
	{
		private static Dictionary<Type, Type[]> s_DiscoveredTypeCache;

		public static Type[] DiscoverImplementations<T>()
		{
			return null;
		}

		public static Type[] DiscoverImplementations(Type type)
		{
			return null;
		}

		private static IEnumerable<Type> DiscoverImplementationsInternal(Type type, Assembly assembly)
		{
			return null;
		}

		public static IEnumerable<Type> GetAnnotatedDependencies(Type type)
		{
			return null;
		}

		public static string NicifyName(string typeName, string unwantedSuffix = null)
		{
			return null;
		}

		public static string NicifyCompoundName(string typeName, char sourceSeparator = '_', string targetSeparator = " - ", string unwantedSuffix = null)
		{
			return null;
		}

		public static string NicifyNamespaceQualifiedName(string namespaceName, string name)
		{
			return null;
		}

		public static string RemoveUnwantedSuffix(string typeName, string unwantedSuffix)
		{
			return null;
		}
	}
}
