using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class ImmutableIDictionarySerializer<TKey, TValue> : MapSerializer<IImmutableDictionary<TKey, TValue>, TKey, TValue>
	{
		protected override IImmutableDictionary<TKey, TValue> Clear(IImmutableDictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values.Clear();
		}

		protected override IImmutableDictionary<TKey, TValue> Initialize(IImmutableDictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values ?? ImmutableDictionary<TKey, TValue>.Empty;
		}

		protected override IImmutableDictionary<TKey, TValue> AddRange(IImmutableDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				KeyValuePair<TKey, TValue> keyValuePair = RepeatedSerializer.Singleton(ref newValues);
				return values.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return values.AddRange(newValues);
		}

		protected override IImmutableDictionary<TKey, TValue> SetValues(IImmutableDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (newValues.Count == 1)
			{
				KeyValuePair<TKey, TValue> keyValuePair = RepeatedSerializer.Singleton(ref newValues);
				return values.SetItem(keyValuePair.Key, keyValuePair.Value);
			}
			return values.SetItems(newValues);
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, WireType wireType, IImmutableDictionary<TKey, TValue> values, in KeyValuePairSerializer<TKey, TValue> pairSerializer)
		{
			IEnumerator<KeyValuePair<TKey, TValue>> enumerator = values.GetEnumerator();
			try
			{
				MapSerializer<IImmutableDictionary<TKey, TValue>, TKey, TValue>.Write(ref state, fieldNumber, wireType, ref enumerator, in pairSerializer);
			}
			finally
			{
				enumerator?.Dispose();
			}
		}
	}
}
