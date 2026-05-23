using Utf8Json.Internal;

namespace Utf8Json.Formatters
{
	public class ArrayFormatter<T> : IJsonFormatter<T[]>, IJsonFormatter, IOverwriteJsonFormatter<T[]>
	{
		private static readonly ArrayPool<T> arrayPool;

		private readonly CollectionDeserializeToBehaviour deserializeToBehaviour;

		public ArrayFormatter()
		{
		}

		public ArrayFormatter(CollectionDeserializeToBehaviour deserializeToBehaviour)
		{
		}

		public void Serialize(ref JsonWriter writer, T[] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T[] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		public void DeserializeTo(ref T[] value, ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
		}
	}
}
