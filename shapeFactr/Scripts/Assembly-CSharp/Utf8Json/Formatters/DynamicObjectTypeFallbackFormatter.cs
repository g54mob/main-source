using System.Collections.Generic;
using Utf8Json.Internal;

namespace Utf8Json.Formatters
{
	public sealed class DynamicObjectTypeFallbackFormatter : IJsonFormatter<object>, IJsonFormatter
	{
		private delegate void SerializeMethod(object dynamicFormatter, ref JsonWriter writer, object value, IJsonFormatterResolver formatterResolver);

		private readonly ThreadsafeTypeKeyHashTable<KeyValuePair<object, SerializeMethod>> serializers;

		private readonly IJsonFormatterResolver[] innerResolvers;

		public DynamicObjectTypeFallbackFormatter(params IJsonFormatterResolver[] innerResolvers)
		{
		}

		public void Serialize(ref JsonWriter writer, object value, IJsonFormatterResolver formatterResolver)
		{
		}

		public object Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
