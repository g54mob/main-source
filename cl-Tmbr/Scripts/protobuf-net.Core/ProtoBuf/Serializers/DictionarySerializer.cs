using System;
using System.Collections.Generic;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	internal sealed class DictionarySerializer<TKey, TValue> : MapSerializer<Dictionary<TKey, TValue>, TKey, TValue>
	{
		protected override Dictionary<TKey, TValue> Initialize(Dictionary<TKey, TValue> values, ISerializationContext context)
		{
			return values ?? new Dictionary<TKey, TValue>();
		}

		protected override Dictionary<TKey, TValue> Clear(Dictionary<TKey, TValue> values, ISerializationContext context)
		{
			values.Clear();
			return values;
		}

		protected override Dictionary<TKey, TValue> AddRange(Dictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			Span<KeyValuePair<TKey, TValue>> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				KeyValuePair<TKey, TValue> keyValuePair = span[i];
				values.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return values;
		}

		protected override Dictionary<TKey, TValue> SetValues(Dictionary<TKey, TValue> values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			Span<KeyValuePair<TKey, TValue>> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				KeyValuePair<TKey, TValue> keyValuePair = span[i];
				values[keyValuePair.Key] = keyValuePair.Value;
			}
			return values;
		}

		internal override void Write(ref ProtoWriter.State state, int fieldNumber, WireType wireType, Dictionary<TKey, TValue> values, in KeyValuePairSerializer<TKey, TValue> pairSerializer)
		{
			Dictionary<TKey, TValue>.Enumerator enumerator = values.GetEnumerator();
			MapSerializer<Dictionary<TKey, TValue>, TKey, TValue>.Write(ref state, fieldNumber, wireType, ref enumerator, in pairSerializer);
		}
	}
	internal class DictionarySerializer<TCollection, TKey, TValue> : MapSerializer<TCollection, TKey, TValue> where TCollection : IDictionary<TKey, TValue>
	{
		protected override TCollection Initialize(TCollection values, ISerializationContext context)
		{
			if (values == null)
			{
				if (!typeof(TCollection).IsInterface)
				{
					return TypeModel.ActivatorCreate<TCollection>();
				}
				return (TCollection)(object)new Dictionary<TKey, TValue>();
			}
			return values;
		}

		protected override TCollection Clear(TCollection values, ISerializationContext context)
		{
			values.Clear();
			return values;
		}

		protected override TCollection AddRange(TCollection values, ref ArraySegment<KeyValuePair<TKey, TValue>> newValues, ISerializationContext context)
		{
			Span<KeyValuePair<TKey, TValue>> span = newValues.AsSpan();
			for (int i = 0; i < span.Length; i++)
			{
				KeyValuePair<TKey, TValue> keyValuePair = span[i];
				values.Add(keyValuePair.Key, keyValuePair.Value);
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
