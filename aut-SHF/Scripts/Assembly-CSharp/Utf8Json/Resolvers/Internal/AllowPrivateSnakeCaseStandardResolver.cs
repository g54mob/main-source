namespace Utf8Json.Resolvers.Internal
{
	internal sealed class AllowPrivateSnakeCaseStandardResolver : IJsonFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IJsonFormatter<T> formatter;

			static FormatterCache()
			{
			}
		}

		private sealed class InnerResolver : IJsonFormatterResolver
		{
			private static class FormatterCache<T>
			{
				public static readonly IJsonFormatter<T> formatter;

				static FormatterCache()
				{
				}
			}

			public static readonly IJsonFormatterResolver Instance;

			private static readonly IJsonFormatterResolver[] resolvers;

			private InnerResolver()
			{
			}

			public IJsonFormatter<T> GetFormatter<T>()
			{
				return null;
			}
		}

		public static readonly IJsonFormatterResolver Instance;

		private static readonly IJsonFormatter<object> fallbackFormatter;

		private AllowPrivateSnakeCaseStandardResolver()
		{
		}

		public IJsonFormatter<T> GetFormatter<T>()
		{
			return null;
		}
	}
}
