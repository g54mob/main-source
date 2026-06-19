using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
	public sealed class TypelessObjectResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				formatter = ((typeof(T) == typeof(object)) ? ((IMessagePackFormatter<T>)TypelessFormatter.Instance) : null);
			}
		}

		public static IFormatterResolver Instance = new TypelessObjectResolver();

		private TypelessObjectResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
