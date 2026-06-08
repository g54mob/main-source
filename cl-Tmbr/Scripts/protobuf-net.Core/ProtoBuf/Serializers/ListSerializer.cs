using System;
using System.Collections.Generic;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal sealed class ListSerializer<T> : ListSerializer<List<T>, T>
	{
		protected override List<T> Initialize(List<T> values, ISerializationContext context)
		{
			return values ?? new List<T>();
		}
	}
	internal class ListSerializer<TList, T> : RepeatedSerializer<TList, T> where TList : List<T>
	{
		protected override TList Initialize(TList values, ISerializationContext context)
		{
			return values ?? TypeModel.ActivatorCreate<TList>();
		}

		protected override TList Clear(TList values, ISerializationContext context)
		{
			values.Clear();
			return values;
		}

		protected override TList AddRange(TList values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			values.AddRange(newValues);
			return values;
		}

		protected override int TryGetCount(TList values)
		{
			return values?.Count ?? 0;
		}

		internal override long Measure(TList values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			List<T>.Enumerator values2 = values.GetEnumerator();
			return RepeatedSerializer<TList, T>.Measure(ref values2, serializer, context, wireType);
		}

		internal override void WritePacked(ref ProtoWriter.State state, TList values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			List<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<TList, T>.WritePacked(ref state, ref values2, serializer, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, TList values, ISerializer<T> serializer, SerializerFeatures features)
		{
			List<T>.Enumerator values2 = values.GetEnumerator();
			RepeatedSerializer<TList, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
		}
	}
}
