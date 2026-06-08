using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableSortedDictionarySerializer<TKey, TValue> : MapSerializer<ImmutableSortedDictionary<TKey, TValue>, TKey, TValue>
	{
		protected override ImmutableSortedDictionary<TKey, TValue> Clear(ImmutableSortedDictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override ImmutableSortedDictionary<TKey, TValue> Initialize(ImmutableSortedDictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values ?? ImmutableSortedDictionary<TKey, TValue>.Empty;
		}

		protected override ImmutableSortedDictionary<TKey, TValue> AddRange(ImmutableSortedDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				KeyValuePair<TKey, TValue> keyValuePair = RepeatedSerializer.Singleton(ref newValues);
				return values.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return values.AddRange(newValues);
		}

		protected override ImmutableSortedDictionary<TKey, TValue> SetValues(ImmutableSortedDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				KeyValuePair<TKey, TValue> keyValuePair = RepeatedSerializer.Singleton(ref newValues);
				return values.SetItem(keyValuePair.Key, keyValuePair.Value);
			}
			return values.SetItems(newValues);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, WireType wireType, ImmutableSortedDictionary<TKey, TValue> values, in KeyValuePairSerializer<TKey, TValue> pairSerializer)
		{
			ImmutableSortedDictionary<TKey, TValue>.Enumerator enumerator = values.GetEnumerator();
			Write(ref state, fieldNumber, wireType, ref enumerator, in pairSerializer);
		}
	}
}
