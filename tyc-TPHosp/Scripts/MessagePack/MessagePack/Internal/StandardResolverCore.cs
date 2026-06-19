using System.Linq;
using MessagePack.Formatters;
using MessagePack.Resolvers;

namespace MessagePack.Internal
{
	internal sealed class StandardResolverCore : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				IFormatterResolver[] resolvers = StandardResolverCore.resolvers;
				for (int i = 0; i < resolvers.Length; i++)
				{
					IMessagePackFormatter<T> messagePackFormatter = resolvers[i].GetFormatter<T>();
					if (messagePackFormatter != null)
					{
						formatter = messagePackFormatter;
						break;
					}
				}
			}
		}

		public static readonly IFormatterResolver Instance = new StandardResolverCore();

		private static readonly IFormatterResolver[] resolvers = StandardResolverHelper.DefaultResolvers.Concat(new IFormatterResolver[1] { DynamicObjectResolver.Instance }).ToArray();

		private StandardResolverCore()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
