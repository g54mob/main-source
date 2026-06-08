using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableIQueueSerializer<T> : RepeatedSerializer<IImmutableQueue<T>, T>
	{
		protected override IImmutableQueue<T> Initialize(IImmutableQueue<T> values, ISerializationContext context)
		{
			return values ?? ImmutableQueue<T>.Empty;
		}

		protected override IImmutableQueue<T> AddRange(IImmutableQueue<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				return values.Enqueue(RepeatedSerializer.Singleton(ref newValues));
			}
			Span<T> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				T value = span[i];
				values = values.Enqueue(value);
			}
			return values;
		}

		protected override IImmutableQueue<T> Clear(IImmutableQueue<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(IImmutableQueue<T> values)
		{
			try
			{
				return (values != null && !values.IsEmpty) ? (-1) : 0;
			}
			catch
			{
				return -1;
			}
		}

		internal override long Measure(IImmutableQueue<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				return RepeatedSerializer<IImmutableQueue<T>, T>.Measure(ref values2, serializer, context, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, IImmutableQueue<T> values, ISerializer<T> serializer, SerializerFeatures features)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				RepeatedSerializer<IImmutableQueue<T>, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void WritePacked(ref ProtoWriter.State state, IImmutableQueue<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				RepeatedSerializer<IImmutableQueue<T>, T>.WritePacked(ref state, ref values2, serializer, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}
	}
}
