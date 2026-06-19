using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
	public class TH20Resolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				object obj = TH20ResolverGetFormatterHelper.GetFormatter(typeof(T));
				if (obj != null)
				{
					formatter = (IMessagePackFormatter<T>)obj;
				}
			}
		}

		public static readonly IFormatterResolver Instance = new TH20Resolver();

		private TH20Resolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
