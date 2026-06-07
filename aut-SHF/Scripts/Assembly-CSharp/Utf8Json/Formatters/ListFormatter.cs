using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public class ListFormatter<T> : IJsonFormatter<List<T>>, IJsonFormatter, IOverwriteJsonFormatter<List<T>>
	{
		private readonly CollectionDeserializeToBehaviour deserializeToBehaviour;

		public ListFormatter()
		{
		}

		public ListFormatter(CollectionDeserializeToBehaviour deserializeToBehaviour)
		{
		}

		public void Serialize(ref JsonWriter writer, List<T> value, IJsonFormatterResolver formatterResolver)
		{
		}

		public List<T> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void DeserializeTo(ref List<T> value, ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
		}
	}
}
