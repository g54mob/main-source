using System;
using Utf8Json.Internal;

namespace Utf8Json.Formatters
{
	public class ArraySegmentFormatter<T> : IJsonFormatter<ArraySegment<T>>, IJsonFormatter
	{
		private static readonly ArrayPool<T> arrayPool;

		public void Serialize(ref JsonWriter writer, ArraySegment<T> value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ArraySegment<T> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(ArraySegment<T>);
		}
	}
}
