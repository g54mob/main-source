namespace Utf8Json.Resolvers
{
	public sealed class AttributeFormatterResolver : IJsonFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IJsonFormatter<T> formatter;

			static FormatterCache()
			{
			}
		}

		public static IJsonFormatterResolver Instance;

		private AttributeFormatterResolver()
		{
		}

		public IJsonFormatter<T> GetFormatter<T>()
		{
			return null;
		}
	}
}
