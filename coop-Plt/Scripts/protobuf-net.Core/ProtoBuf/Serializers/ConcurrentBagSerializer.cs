using System;
using System.Collections.Concurrent;

namespace ProtoBuf.Serializers
{
	internal sealed class ConcurrentBagSerializer<TCollection, T> : ProducerConsumerSerializer<TCollection, T> where TCollection : ConcurrentBag<T>
	{
		protected override TCollection AddRange(TCollection values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			Span<T> span = MemoryExtensions.AsSpan(newValues);
			for (int i = 0; i < span.Length; i++)
			{
				T item = span[i];
				values.Add(item);
			}
			return values;
		}
	}
}
