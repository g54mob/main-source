using System;
using System.Collections.Immutable;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableHashSetSerializer<T> : RepeatedSerializer<ImmutableHashSet<T>, T>
	{
		protected override ImmutableHashSet<T> Initialize(ImmutableHashSet<T> values, ISerializationContext context)
		{
			return values ?? ImmutableHashSet<T>.Empty;
		}

		protected override ImmutableHashSet<T> AddRange(ImmutableHashSet<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count != 1)
			{
				return values.Union(newValues);
			}
			return values.Add(RepeatedSerializer.Singleton(ref newValues));
		}

		protected override ImmutableHashSet<T> Clear(ImmutableHashSet<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(ImmutableHashSet<T> values)
		{
			return values?.Count ?? 0;
		}

		internal override long Measure(ImmutableHashSet<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			ImmutableHashSet<T>.Enumerator values2 = values.GetEnumerator();
			return Measure(ref values2, serializer, context, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, ImmutableHashSet<T> values, ISerializer<T> serializer)
		{
			ImmutableHashSet<T>.Enumerator values2 = values.GetEnumerator();
			Write(ref state, fieldNumber, category, wireType, ref values2, serializer);
		}

		internal override void WritePacked(ref ProtoWriter.State state, ImmutableHashSet<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			ImmutableHashSet<T>.Enumerator values2 = values.GetEnumerator();
			WritePacked(ref state, ref values2, serializer, wireType);
		}
	}
}
