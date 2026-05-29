using System;

namespace Utf8Json.Resolvers.Internal
{
	internal sealed class DynamicObjectResolverAllowPrivateTrueExcludeNullFalseNameMutateOriginal : IJsonFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IJsonFormatter<T> formatter;

			static FormatterCache()
			{
			}
		}

		public static readonly IJsonFormatterResolver Instance;

		private static readonly Func<string, string> nameMutator;

		private static readonly bool excludeNull;

		public IJsonFormatter<T> GetFormatter<T>()
		{
			return null;
		}
	}
}
