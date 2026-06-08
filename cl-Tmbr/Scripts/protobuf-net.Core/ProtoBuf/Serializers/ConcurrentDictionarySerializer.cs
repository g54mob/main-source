using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal sealed class ConcurrentDictionarySerializer<TCollection, TKey, TValue> : MapSerializer<TCollection, TKey, TValue> where TCollection : ConcurrentDictionary<TKey, TValue>
	{
		protected override TCollection Clear(TCollection values, ISerializationContext context)
		{
			values.Clear();
			return values;
		}

		protected override TCollection Initialize(TCollection values, ISerializationContext context)
		{
			return values ?? TypeModel.ActivatorCreate<TCollection>();
		}

		protected override TCollection AddRange(TCollection values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			Span<KeyValuePair<TKey, TValue>> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				KeyValuePair<TKey, TValue> keyValuePair = span[i];
				if (!values.TryAdd(keyValuePair.Key, keyValuePair.Value))
				{
					ThrowHelper.ThrowArgumentException("duplicate key");
				}
			}
			return values;
		}

		protected override TCollection SetValues(TCollection values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			Span<KeyValuePair<TKey, TValue>> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				KeyValuePair<TKey, TValue> keyValuePair = span[i];
				values[keyValuePair.Key] = keyValuePair.Value;
			}
			return values;
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, WireType wireType, TCollection values, in KeyValuePairSerializer<TKey, TValue> pairSerializer)
		{
			IEnumerator<KeyValuePair<TKey, TValue>> enumerator = values.GetEnumerator();
			try
			{
				MapSerializer<TCollection, TKey, TValue>.Write(ref state, fieldNumber, wireType, ref enumerator, in pairSerializer);
			}
			finally
			{
				enumerator?.Dispose();
			}
		}
	}
}
