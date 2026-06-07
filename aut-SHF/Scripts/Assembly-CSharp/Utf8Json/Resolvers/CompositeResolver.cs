namespace Utf8Json.Resolvers
{
	public sealed class CompositeResolver : IJsonFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IJsonFormatter<T> formatter;

			static FormatterCache()
			{
			}
		}

		public static readonly CompositeResolver Instance;

		private static bool isFreezed;

		private static IJsonFormatter[] formatters;

		private static IJsonFormatterResolver[] resolvers;

		private CompositeResolver()
		{
		}

		public static void Register(params IJsonFormatterResolver[] resolvers)
		{
		}

		public static void Register(params IJsonFormatter[] formatters)
		{
		}

		public static void Register(IJsonFormatter[] formatters, IJsonFormatterResolver[] resolvers)
		{
		}

		public static void RegisterAndSetAsDefault(params IJsonFormatterResolver[] resolvers)
		{
		}

		public static void RegisterAndSetAsDefault(params IJsonFormatter[] formatters)
		{
		}

		public static void RegisterAndSetAsDefault(IJsonFormatter[] formatters, IJsonFormatterResolver[] resolvers)
		{
		}

		public static IJsonFormatterResolver Create(params IJsonFormatter[] formatters)
		{
			return null;
		}

		public static IJsonFormatterResolver Create(params IJsonFormatterResolver[] resolvers)
		{
			return null;
		}

		public static IJsonFormatterResolver Create(IJsonFormatter[] formatters, IJsonFormatterResolver[] resolvers)
		{
			return null;
		}

		public IJsonFormatter<T> GetFormatter<T>()
		{
			return null;
		}
	}
}
