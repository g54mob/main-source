using System.Linq;
using MessagePack.Formatters;
using MessagePack.Resolvers;

namespace MessagePack.Internal
{
	internal sealed class ContractlessStandardResolverAllowPrivateCore : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				IFormatterResolver[] resolvers = ContractlessStandardResolverAllowPrivateCore.resolvers;
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

		public static readonly IFormatterResolver Instance = new ContractlessStandardResolverAllowPrivateCore();

		private static readonly IFormatterResolver[] resolvers = StandardResolverHelper.DefaultResolvers.Concat(new IFormatterResolver[2]
		{
			DynamicObjectResolverAllowPrivate.Instance,
			DynamicContractlessObjectResolverAllowPrivate.Instance
		}).ToArray();

		private ContractlessStandardResolverAllowPrivateCore()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
