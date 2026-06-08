using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableIListSerializer<T> : RepeatedSerializer<IImmutableList<T>, T>
	{
		protected override IImmutableList<T> Initialize(IImmutableList<T> values, ISerializationContext context)
		{
			return values ?? ImmutableList<T>.Empty;
		}

		protected override IImmutableList<T> AddRange(IImmutableList<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count != 1)
			{
				return values.AddRange(newValues);
			}
			return values.Add(RepeatedSerializer.Singleton(ref newValues));
		}

		protected override IImmutableList<T> Clear(IImmutableList<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(IImmutableList<T> values)
		{
			return TryGetCountDefault(values);
		}

		internal override long Measure(IImmutableList<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
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

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, IImmutableList<T> values, ISerializer<T> serializer)
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

		internal override void WritePacked(ref ProtoWriter.State state, IImmutableList<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
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
