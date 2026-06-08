using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableDictionarySerializer<TKey, TValue> : MapSerializer<ImmutableDictionary<TKey, TValue>, TKey, TValue>
	{
		protected override ImmutableDictionary<TKey, TValue> Clear(ImmutableDictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override ImmutableDictionary<TKey, TValue> Initialize(ImmutableDictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values ?? ImmutableDictionary<TKey, TValue>.Empty;
		}

		protected override ImmutableDictionary<TKey, TValue> AddRange(ImmutableDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				KeyValuePair<TKey, TValue> keyValuePair = RepeatedSerializer.Singleton(ref newValues);
				return values.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return values.AddRange(newValues);
		}

		protected override ImmutableDictionary<TKey, TValue> SetValues(ImmutableDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				KeyValuePair<TKey, TValue> keyValuePair = RepeatedSerializer.Singleton(ref newValues);
				return values.SetItem(keyValuePair.Key, keyValuePair.Value);
			}
			return values.SetItems(newValues);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, WireType wireType, ImmutableDictionary<TKey, TValue> values, in KeyValuePairSerializer<TKey, TValue> pairSerializer)
		{
			ImmutableDictionary<TKey, TValue>.Enumerator enumerator = values.GetEnumerator();
			MapSerializer<ImmutableDictionary<TKey, TValue>, TKey, TValue>.Write(ref state, fieldNumber, wireType, ref enumerator, in pairSerializer);
		}
	}
}
