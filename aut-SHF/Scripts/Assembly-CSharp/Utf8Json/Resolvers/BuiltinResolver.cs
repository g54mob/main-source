using System;
using System.Collections.Generic;

namespace Utf8Json.Resolvers
{
	public sealed class BuiltinResolver : IJsonFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IJsonFormatter<T> formatter;

			static FormatterCache()
			{
			}
		}

		internal static class BuiltinResolverGetFormatterHelper
		{
			private static readonly Dictionary<Type, object> formatterMap;

			internal static object GetFormatter(Type t)
			{
				return null;
			}
		}

		public static readonly IJsonFormatterResolver Instance;

		private BuiltinResolver()
		{
		}

		public IJsonFormatter<T> GetFormatter<T>()
		{
			return null;
		}
	}
}
