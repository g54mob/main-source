using System;
using System.Collections.Generic;

namespace Utf8Json.Resolvers.Internal
{
	internal static class DynamicGenericResolverGetFormatterHelper
	{
		private static readonly Dictionary<Type, Type> formatterMap;

		internal static object GetFormatter(Type t)
		{
			return null;
		}

		private static object CreateInstance(Type genericType, Type[] genericTypeArguments, params object[] arguments)
		{
			return null;
		}
	}
}
