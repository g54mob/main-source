using System;
using System.Collections.Generic;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal class EnumerableSerializer<TCollection, TCreate, T> : RepeatedSerializer<TCollection, T> where TCollection : class, IEnumerable<T> where TCreate : TCollection
	{
		protected override TCollection Initialize(TCollection values, ISerializationContext context)
		{
			object obj = values;
			if (obj == null)
			{
				if (!typeof(TCreate).IsInterface)
				{
					return (TCollection)(object)TypeModel.ActivatorCreate<TCreate>();
				}
				obj = (TCollection)(object)new List<T>();
			}
			return (TCollection)obj;
		}

		protected override int TryGetCount(TCollection values)
		{
			return TryGetCountDefault(values);
		}

		internal override long Measure(TCollection values, IMeasuringSerializer<T> serializer, ISerializationContext context, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				return RepeatedSerializer<TCollection, T>.Measure(ref values2, serializer, context, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void WritePacked(ref ProtoWriter.State state, TCollection values, IMeasuringSerializer<T> serializer, WireType wireType)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				RepeatedSerializer<TCollection, T>.WritePacked(ref state, ref values2, serializer, wireType);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, SerializerFeatures category, WireType wireType, TCollection values, ISerializer<T> serializer, SerializerFeatures features)
		{
			IEnumerator<T> values2 = values.GetEnumerator();
			try
			{
				RepeatedSerializer<TCollection, T>.Write(ref state, fieldNumber, category, wireType, ref values2, serializer, features);
			}
			finally
			{
				values2?.Dispose();
			}
		}

		private static void ThrowInvalidCollectionType(object collection)
		{
			ThrowHelper.ThrowInvalidOperationException("For repeated data declared as " + typeof(TCollection).NormalizeName() + ", the *underlying* collection (" + collection?.GetType().NormalizeName() + ") must implement ICollection<T> and must not declare itself read-only; alternative (more exotic) collections can be used, but must be declared using their well-known form (for example, a member could be declared as ImmutableHashSet<T>)");
		}

		protected override TCollection Clear(TCollection values, ISerializationContext context)
		{
			if (values is ICollection<T> { IsReadOnly: false } collection)
			{
				collection.Clear();
			}
			else if (typeof(TCollection) == typeof(IEnumerable<T>))
			{
				values = Initialize(null, context);
			}
			else
			{
				ThrowInvalidCollectionType(values);
			}
			return values;
		}

		protected override TCollection AddRange(TCollection values, ref ArraySegment<T> newValues, ISerializationContext context)
		{
			if (!(values is List<T> list))
			{
				if (values is ICollection<T> { IsReadOnly: false } collection)
				{
					Span<T> span = newValues.AsSpan();
					for (int i = 0; i < span.Length; i++)
					{
						T item = span[i];
						collection.Add(item);
					}
				}
				else
				{
					ThrowInvalidCollectionType(values);
				}
			}
			else
			{
				list.AddRange(newValues);
			}
			return values;
		}
	}
}
