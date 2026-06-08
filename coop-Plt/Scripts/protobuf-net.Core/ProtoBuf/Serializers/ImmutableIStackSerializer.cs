using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableIStackSerializer<T> : RepeatedSerializer<IImmutableStack<T>, T>
	{
		protected override IImmutableStack<T> Initialize(IImmutableStack<T> values, ISerializationContext context)
		{
			return values ?? ImmutableStack<T>.Empty;
		}

		protected override IImmutableStack<T> AddRange(IImmutableStack<T> values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				return values.Push(RepeatedSerializer.Singleton(ref newValues));
			}
			RepeatedSerializer.ReverseInPlace(ref newValues);
			Span<T> span = MemoryExtensions.AsSpan(newValues);
			for (int i = 0; i < span.Length; i++)
			{
				T value = span[i];
				values = values.Push(value);
			}
			return values;
		}

		protected override IImmutableStack<T> Clear(IImmutableStack<T> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override int TryGetCount(IImmutableStack<T> values)
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

		internal override long Measure(IImmutableStack<T> values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
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

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, IImmutableStack<T> values, ISerializer<T> serializer)
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

		internal override void WritePacked(ref ProtoWriter.State state, IImmutableStack<T> values, IMeasuringSerializer<T> serializer, WireType wireType)
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
