using System;
using System.Collections.Generic;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	internal sealed class DictionaryOfIReadOnlyDictionarySerializer<TKey, TValue> : MapSerializer<IReadOnlyDictionary<TKey, TValue>, TKey, TValue>
	{
		protected override IReadOnlyDictionary<TKey, TValue> Initialize(IReadOnlyDictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values ?? new Dictionary<TKey, TValue>();
		}

		protected override IReadOnlyDictionary<TKey, TValue> Clear(IReadOnlyDictionary<TKey, TValue> values, ISerializationContext context)
		{
			if (values is IDictionary<TKey, TValue> { IsReadOnly: false } dictionary)
			{
				dictionary.Clear();
				return values;
			}
			return new Dictionary<TKey, TValue>();
		}

		protected override IReadOnlyDictionary<TKey, TValue> AddRange(IReadOnlyDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (values is IDictionary<TKey, TValue> { IsReadOnly: false } dictionary)
			{
				Span<KeyValuePair<TKey, TValue>> span = newValues.AsSpan();
				for (int i = 0; i < span.Length; i++)
				{
					KeyValuePair<TKey, TValue> keyValuePair = span[i];
					dictionary.Add(keyValuePair.Key, keyValuePair.Value);
				}
				return values;
			}
			Dictionary<TKey, TValue> dictionary2 = new Dictionary<TKey, TValue>(values.Count + newValues.Count);
			foreach (KeyValuePair<TKey, TValue> value in values)
			{
				dictionary2.Add(value.Key, value.Value);
			}
			Span<KeyValuePair<TKey, TValue>> span2 = newValues.AsSpan();
			for (int j = 0; j < span2.Length; j++)
			{
				KeyValuePair<TKey, TValue> keyValuePair2 = span2[j];
				dictionary2.Add(keyValuePair2.Key, keyValuePair2.Value);
			}
			return dictionary2;
		}

		protected override IReadOnlyDictionary<TKey, TValue> SetValues(IReadOnlyDictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			if (values is IDictionary<TKey, TValue> { IsReadOnly: false } dictionary)
			{
				Span<KeyValuePair<TKey, TValue>> span = newValues.AsSpan();
				for (int i = 0; i < span.Length; i++)
				{
					KeyValuePair<TKey, TValue> keyValuePair = span[i];
					dictionary[keyValuePair.Key] = keyValuePair.Value;
				}
				return values;
			}
			Dictionary<TKey, TValue> dictionary2 = new Dictionary<TKey, TValue>(values.Count);
			foreach (KeyValuePair<TKey, TValue> value in values)
			{
				dictionary2.Add(value.Key, value.Value);
			}
			Span<KeyValuePair<TKey, TValue>> span2 = newValues.AsSpan();
			for (int j = 0; j < span2.Length; j++)
			{
				KeyValuePair<TKey, TValue> keyValuePair2 = span2[j];
				dictionary2[keyValuePair2.Key] = keyValuePair2.Value;
			}
			return values;
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, WireType wireType, IReadOnlyDictionary<TKey, TValue> values, in KeyValuePairSerializer<TKey, TValue> pairSerializer)
		{
			IEnumerator<KeyValuePair<TKey, TValue>> enumerator = values.GetEnumerator();
			MapSerializer<IReadOnlyDictionary<TKey, TValue>, TKey, TValue>.Write(ref state, fieldNumber, wireType, ref enumerator, in pairSerializer);
		}
	}
}
