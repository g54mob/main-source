using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
	public sealed class PrimitiveObjectResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				formatter = ((typeof(T) == typeof(object)) ? ((IMessagePackFormatter<T>)PrimitiveObjectFormatter.Instance) : null);
			}
		}

		public static IFormatterResolver Instance = new PrimitiveObjectResolver();

		private PrimitiveObjectResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
