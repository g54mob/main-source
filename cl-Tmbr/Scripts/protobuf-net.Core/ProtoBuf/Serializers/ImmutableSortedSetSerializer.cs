using System;
using System.Collections.Immutable;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableSortedSetSerializer<T> : RepeatedSerializer<ImmutableSortedSet<T>, T>
	{
		protected override ImmutableSortedSet<T> Initialize(ImmutableSortedSet<T> values, ISerializationContext context)
		{
			return values ?? ImmutableSortedSet<T>.Empty;
		}

		protected override ImmutableSortedSet<T> AddRange(ImmutableSortedSet<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count != 1)
			{
				return values.Union(newValues);
			}
			return values.Add(RepeatedSerializer.Singleton(ref newValues));
		}

		protected override ImmutableSortedSet<T> Clear(ImmutableSortedSet<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(ImmutableSortedSet<T> values)
		{
			return values?.Count ?? 0;
		}

		internal override long Measure(ImmutableSortedSet<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			ImmutableSortedSet<T>.Enumerator values2 = values.GetEnumerator();
			return RepeatedSerializer<ImmutableSortedSet<T>, T>.Measure(ref values2, serializer, context, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, ImmutableSortedSet<T> values, ISerializer<T> serializer, SerializerFeatures features)
		{
			ImmutableSortedSet<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<ImmutableSortedSet<T>, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
		}

		internal override void WritePacked(ref ProtoWriter.State state, ImmutableSortedSet<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			ImmutableSortedSet<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<ImmutableSortedSet<T>, T>.WritePacked(ref state, ref values2, serializer, wireType);
		}
	}
}
