using MessagePack.Formatters;
using MessagePack.Internal;

namespace MessagePack.Resolvers
{
	public sealed class ContractlessStandardResolverAllowPrivate : IFormatterResolver
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
					formatter = ContractlessStandardResolverAllowPrivateCore.Instance.GetFormatter<T>();
				}
			}
		}

		public static readonly IFormatterResolver Instance = new ContractlessStandardResolverAllowPrivate();

		private ContractlessStandardResolverAllowPrivate()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
