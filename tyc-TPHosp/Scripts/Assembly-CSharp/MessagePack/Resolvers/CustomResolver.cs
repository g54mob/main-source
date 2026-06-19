using MessagePack.Formatters;
using TH20;

namespace MessagePack.Resolvers
{
	public sealed class CustomResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				if (typeof(T) == typeof(OnlineChallengeEvent))
				{
					formatter = (IMessagePackFormatter<T>)(object)new OnlineChallengeEventFormatter();
					return;
				}
				IFormatterResolver[] resolvers = CustomResolver.resolvers;
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

		public static readonly IFormatterResolver Instance = new CustomResolver();

		private static readonly IFormatterResolver[] resolvers = new IFormatterResolver[4]
		{
			TH20Resolver.Instance,
			BuiltinResolver.Instance,
			AttributeFormatterResolver.Instance,
			PrimitiveObjectResolver.Instance
		};

		private CustomResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
