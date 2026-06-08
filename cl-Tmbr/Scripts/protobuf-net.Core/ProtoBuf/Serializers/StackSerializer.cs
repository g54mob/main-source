using System;
using System.Collections.Generic;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal sealed class StackSerializer<TCollection, T> : RepeatedSerializer<TCollection, T> where TCollection : Stack<T>
	{
		protected override TCollection Initialize(TCollection values, ISerializationContext context)
		{
			return values ?? TypeModel.ActivatorCreate<TCollection>();
		}

		protected override TCollection Clear(TCollection values, ISerializationContext context)
		{
			values.Clear();
			return values;
		}

		protected override int TryGetCount(TCollection values)
		{
			return values?.Count ?? 0;
		}

		protected override TCollection AddRange(TCollection values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			RepeatedSerializer.ReverseInPlace(ref newValues);
			Span<T> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				T item = span[i];
				values.Push(item);
			}
			return values;
		}

		internal override long Measure(TCollection values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			Stack<T>.Enumerator values2 = values.GetEnumerator();
			return RepeatedSerializer<TCollection, T>.Measure(ref values2, serializer, context, wireType);
		}

		internal override void WritePacked(ref ProtoWriter.State state, TCollection values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			Stack<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<TCollection, T>.WritePacked(ref state, ref values2, serializer, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, TCollection values, ISerializer<T> serializer, SerializerFeatures features)
		{
			Stack<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<TCollection, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
		}
	}
}
