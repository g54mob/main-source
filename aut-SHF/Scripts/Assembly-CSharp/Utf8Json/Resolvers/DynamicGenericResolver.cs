namespace Utf8Json.Resolvers
{
	public sealed class DynamicGenericResolver : IJsonFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IJsonFormatter<T> formatter;

			static FormatterCache()
			{
			}
		}

		public static readonly IJsonFormatterResolver Instance;

		private DynamicGenericResolver()
		{
		}

		public IJsonFormatter<T> GetFormatter<T>()
		{
			return null;
		}
	}
}
