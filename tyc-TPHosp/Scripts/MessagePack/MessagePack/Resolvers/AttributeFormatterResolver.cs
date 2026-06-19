using System;
using System.Reflection;
using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
	public sealed class AttributeFormatterResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				MessagePackFormatterAttribute customAttribute = typeof(T).GetTypeInfo().GetCustomAttribute<MessagePackFormatterAttribute>();
				if (customAttribute != null)
				{
					if (customAttribute.Arguments == null)
					{
						formatter = (IMessagePackFormatter<T>)Activator.CreateInstance(customAttribute.FormatterType);
					}
					else
					{
						formatter = (IMessagePackFormatter<T>)Activator.CreateInstance(customAttribute.FormatterType, customAttribute.Arguments);
					}
				}
			}
		}

		public static IFormatterResolver Instance = new AttributeFormatterResolver();

		private AttributeFormatterResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
