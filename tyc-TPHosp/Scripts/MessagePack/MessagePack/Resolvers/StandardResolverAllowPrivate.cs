using MessagePack.Formatters;
using MessagePack.Internal;

namespace MessagePack.Resolvers
{
	public sealed class StandardResolverAllowPrivate : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				if (typeof(T) == typeof(object))
				{
					formatter = PrimitiveObjectResolver.Instance.GetFormatter<T>();
				}
				else
				{
					formatter = StandardResolverAllowPrivateCore.Instance.GetFormatter<T>();
				}
			}
		}

		public static readonly IFormatterResolver Instance = new StandardResolverAllowPrivate();

		private StandardResolverAllowPrivate()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
