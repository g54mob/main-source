using System;
using System.Collections.Concurrent;

namespace ProtoBuf.Serializers
{
	internal sealed class ConcurrentStackSerializer<TCollection, T> : ProducerConsumerSerializer<TCollection, T> where TCollection : ConcurrentStack<T>
	{
		protected override TCollection Clear(TCollection values, ISerializationContext context)
		{
			values.Clear();
			return values;
		}

		protected override TCollection AddRange(TCollection values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			RepeatedSerializer.ReverseInPlace(ref newValues);
			values.PushRange(newValues.Array, newValues.Offset, newValues.Count);
			return values;
		}
	}
}
