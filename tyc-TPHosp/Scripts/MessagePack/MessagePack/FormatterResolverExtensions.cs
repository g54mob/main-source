using System;
using System.Reflection;
using MessagePack.Formatters;

namespace MessagePack
{
	public static class FormatterResolverExtensions
	{
		public static IMessagePackFormatter<T> GetFormatterWithVerify<T>(this IFormatterResolver resolver)
		{
			IMessagePackFormatter<T> formatter;
			try
			{
				formatter = resolver.GetFormatter<T>();
			}
			catch (TypeInitializationException innerException)
			{
				while (innerException.InnerException != null)
				{
					innerException = (TypeInitializationException)innerException.InnerException;
				}
				throw innerException;
			}
			if (formatter == null)
			{
				throw new FormatterNotRegisteredException(typeof(T).FullName + " is not registered in this resolver. resolver:" + resolver.GetType().Name);
			}
			return formatter;
		}

		public static object GetFormatterDynamic(this IFormatterResolver resolver, Type type)
		{
			return typeof(IFormatterResolver).GetRuntimeMethod("GetFormatter", Type.EmptyTypes).MakeGenericMethod(type).Invoke(resolver, null);
		}
	}
}
