using MessagePack;
using MessagePack.Formatters;

namespace Networking.Resolver
{
	public class CustomResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> Formatter;

			static FormatterCache()
			{
				Formatter = (IMessagePackFormatter<T>)SampleCustomResolverGetFormatterHelper.GetFormatter(typeof(T));
			}
		}

		public static readonly IFormatterResolver Instance = new CustomResolver();

		private CustomResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.Formatter;
		}
	}
}
