using System;
using System.Collections.Concurrent;

namespace ProtoBuf.Serializers
{
	internal sealed class ConcurrentQueueSerializer<TCollection, T> : ProducerConsumerSerializer<TCollection, T> where TCollection : ConcurrentQueue<T>
	{
		protected override TCollection AddRange(TCollection values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			Span<T> span = MemoryExtensions.AsSpan(newValues);
			for (int i = 0; i < span.Length; i++)
			{
				T item = span[i];
				values.Enqueue(item);
			}
			return values;
		}
	}
}
