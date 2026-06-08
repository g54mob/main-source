using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal class ProducerConsumerSerializer<TCollection, T> : RepeatedSerializer<TCollection, T> where TCollection : class, IProducerConsumerCollection<T>
	{
		protected override TCollection Clear(TCollection values, ISerializationContext context)
		{
			if (values.Count != 0)
			{
				if (values is ICollection<T> collection)
				{
					collection.Clear();
				}
				else
				{
					ThrowHelper.ThrowInvalidOperationException("Unable to clear the collection: " + values.GetType().NormalizeName());
				}
			}
			return values;
		}

		protected override TCollection AddRange(TCollection values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			Span<T> span = MemoryExtensions.AsSpan(newValues);
			for (int i = 0; i < span.Length; i++)
			{
				T item = span[i];
				if (!values.TryAdd(item))
				{
					ThrowHelper.ThrowInvalidOperationException("Unable to add to the collection: " + values.GetType().NormalizeName());
				}
			}
			return values;
		}

		protected override TCollection Initialize(TCollection values, ISerializationContext context)
		{
			return values ?? TypeModel.ActivatorCreate<TCollection>();
		}

		protected override int TryGetCount(TCollection values)
		{
			return TryGetCountDefault(values);
		}

		internal override long Measure(TCollection values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				return Measure(ref values2, serializer, context, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, TCollection values, ISerializer<T> serializer)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				Write(ref state, fieldNumber, category, wireType, ref values2, serializer);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void WritePacked(ref ProtoWriter.State state, TCollection values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				WritePacked(ref state, ref values2, serializer, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}
	}
}
