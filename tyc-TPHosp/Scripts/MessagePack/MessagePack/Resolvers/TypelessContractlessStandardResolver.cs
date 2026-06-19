using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
	public sealed class TypelessContractlessStandardResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				IFormatterResolver[] resolvers = TypelessContractlessStandardResolver.resolvers;
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

		public static readonly IFormatterResolver Instance = new TypelessContractlessStandardResolver();

		private static readonly IFormatterResolver[] resolvers = new IFormatterResolver[9]
		{
			NativeDateTimeResolver.Instance,
			BuiltinResolver.Instance,
			AttributeFormatterResolver.Instance,
			DynamicEnumResolver.Instance,
			DynamicGenericResolver.Instance,
			DynamicUnionResolver.Instance,
			DynamicObjectResolver.Instance,
			DynamicContractlessObjectResolver.Instance,
			TypelessObjectResolver.Instance
		};

		private TypelessContractlessStandardResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
