using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableISetSerializer<T> : RepeatedSerializer<IImmutableSet<T>, T>
	{
		protected override IImmutableSet<T> Initialize(IImmutableSet<T> values, ISerializationContext context)
		{
			return values ?? ImmutableHashSet<T>.Empty;
		}

		protected override IImmutableSet<T> AddRange(IImmutableSet<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count != 1)
			{
				return values.Union(newValues);
			}
			return values.Add(RepeatedSerializer.Singleton(ref newValues));
		}

		protected override IImmutableSet<T> Clear(IImmutableSet<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(IImmutableSet<T> values)
		{
			return TryGetCountDefault(values);
		}

		internal override long Measure(IImmutableSet<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
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

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, IImmutableSet<T> values, ISerializer<T> serializer)
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

		internal override void WritePacked(ref ProtoWriter.State state, IImmutableSet<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
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
