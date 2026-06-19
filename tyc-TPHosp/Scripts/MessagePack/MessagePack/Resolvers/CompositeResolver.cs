using System;
using System.Reflection;
using MessagePack.Formatters;

namespace MessagePack.Resolvers
{
	public sealed class CompositeResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			public static readonly IMessagePackFormatter<T> formatter;

			static FormatterCache()
			{
				isFreezed = true;
				IMessagePackFormatter[] formatters = CompositeResolver.formatters;
				foreach (IMessagePackFormatter messagePackFormatter in formatters)
				{
					foreach (Type implementedInterface in messagePackFormatter.GetType().GetTypeInfo().ImplementedInterfaces)
					{
						TypeInfo typeInfo = implementedInterface.GetTypeInfo();
						if (typeInfo.IsGenericType && typeInfo.GenericTypeArguments[0] == typeof(T))
						{
							formatter = (IMessagePackFormatter<T>)messagePackFormatter;
							return;
						}
					}
				}
				IFormatterResolver[] resolvers = CompositeResolver.resolvers;
				for (int i = 0; i < resolvers.Length; i++)
				{
					IMessagePackFormatter<T> messagePackFormatter2 = resolvers[i].GetFormatter<T>();
					if (messagePackFormatter2 != null)
					{
						formatter = messagePackFormatter2;
						break;
					}
				}
			}
		}

		public static readonly CompositeResolver Instance = new CompositeResolver();

		private static bool isFreezed = false;

		private static IMessagePackFormatter[] formatters = new IMessagePackFormatter[0];

		private static IFormatterResolver[] resolvers = new IFormatterResolver[0];

		private CompositeResolver()
		{
		}

		public static void Register(params IFormatterResolver[] resolvers)
		{
			if (isFreezed)
			{
				throw new InvalidOperationException("Register must call on startup(before use GetFormatter<T>).");
			}
			CompositeResolver.resolvers = resolvers;
		}

		public static void Register(params IMessagePackFormatter[] formatters)
		{
			if (isFreezed)
			{
				throw new InvalidOperationException("Register must call on startup(before use GetFormatter<T>).");
			}
			CompositeResolver.formatters = formatters;
		}

		public static void Register(IMessagePackFormatter[] formatters, IFormatterResolver[] resolvers)
		{
			if (isFreezed)
			{
				throw new InvalidOperationException("Register must call on startup(before use GetFormatter<T>).");
			}
			CompositeResolver.resolvers = resolvers;
			CompositeResolver.formatters = formatters;
		}

		public static void RegisterAndSetAsDefault(params IFormatterResolver[] resolvers)
		{
			Register(resolvers);
			MessagePackSerializer.SetDefaultResolver(Instance);
		}

		public static void RegisterAndSetAsDefault(params IMessagePackFormatter[] formatters)
		{
			Register(formatters);
			MessagePackSerializer.SetDefaultResolver(Instance);
		}

		public static void RegisterAndSetAsDefault(IMessagePackFormatter[] formatters, IFormatterResolver[] resolvers)
		{
			Register(formatters);
			Register(resolvers);
			MessagePackSerializer.SetDefaultResolver(Instance);
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.formatter;
		}
	}
}
