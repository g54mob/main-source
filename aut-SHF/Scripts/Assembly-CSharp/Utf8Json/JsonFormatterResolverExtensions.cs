using System;

namespace Utf8Json
{
	public static class JsonFormatterResolverExtensions
	{
		public static IJsonFormatter<T> GetFormatterWithVerify<T>(this IJsonFormatterResolver resolver)
		{
			return null;
		}

		public static object GetFormatterDynamic(this IJsonFormatterResolver resolver, Type type)
		{
			return null;
		}

		public static void DeserializeToWithFallbackReplace<T>(this IJsonFormatterResolver formatterResolver, ref T value, ref JsonReader reader)
		{
		}
	}
}
