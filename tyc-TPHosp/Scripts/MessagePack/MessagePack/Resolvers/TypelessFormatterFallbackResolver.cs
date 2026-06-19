using MessagePack.Formatters;
using MessagePack.Internal;

namespace MessagePack.Resolvers
{
	internal sealed class TypelessFormatterFallbackResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				if (typeof(T) == typeof(object))
				{
					formatter = (IMessagePackFormatter<T>)fallbackFormatter;
				}
			}
		}

		public static IFormatterResolver Instance = new TypelessFormatterFallbackResolver();

		private static IMessagePackFormatter<object> fallbackFormatter = new DynamicObjectTypeFallbackFormatter(ForceSizePrimitiveObjectResolver.Instance, ContractlessStandardResolverCore.Instance);

		private TypelessFormatterFallbackResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
