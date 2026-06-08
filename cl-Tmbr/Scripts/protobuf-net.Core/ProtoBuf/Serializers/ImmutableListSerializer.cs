using System;
using System.Collections.Immutable;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableListSerializer<T> : RepeatedSerializer<ImmutableList<T>, T>
	{
		protected override ImmutableList<T> Initialize(ImmutableList<T> values, ISerializationContext context)
		{
			return values ?? ImmutableList<T>.Empty;
		}

		protected override ImmutableList<T> AddRange(ImmutableList<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count != 1)
			{
				return values.AddRange(newValues);
			}
			return values.Add(RepeatedSerializer.Singleton(ref newValues));
		}

		protected override ImmutableList<T> Clear(ImmutableList<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(ImmutableList<T> values)
		{
			return values?.Count ?? 0;
		}

		internal override long Measure(ImmutableList<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			ImmutableList<T>.Enumerator values2 = values.GetEnumerator();
			return RepeatedSerializer<ImmutableList<T>, T>.Measure(ref values2, serializer, context, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, ImmutableList<T> values, ISerializer<T> serializer, SerializerFeatures features)
		{
			ImmutableList<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<ImmutableList<T>, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
		}

		internal override void WritePacked(ref ProtoWriter.State state, ImmutableList<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			ImmutableList<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<ImmutableList<T>, T>.WritePacked(ref state, ref values2, serializer, wireType);
		}
	}
}
