using System;
using System.Collections.Generic;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal sealed class SetSerializer<TCollection, T> : RepeatedSerializer<TCollection, T> where TCollection : ISet<T>
	{
		protected override TCollection Initialize(TCollection values, ISerializationContext context)
		{
			if (values == null)
			{
				if (!typeof(TCollection).IsInterface)
				{
					return TypeModel.ActivatorCreate<TCollection>();
				}
				return (TCollection)(object)new HashSet<T>();
			}
			return values;
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
			values.UnionWith(newValues);
			return values;
		}

		internal override long Measure(TCollection values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			return RepeatedSerializer<TCollection, T>.Measure(ref values2, serializer, context, wireType);
		}

		internal override void WritePacked(ref ProtoWriter.State state, TCollection values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			RepeatedSerializer<TCollection, T>.WritePacked(ref state, ref values2, serializer, wireType);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, TCollection values, ISerializer<T> serializer, SerializerFeatures features)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			RepeatedSerializer<TCollection, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
		}
	}
}
