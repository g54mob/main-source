using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public abstract class DictionaryFormatterBase<TKey, TValue, TIntermediate, TEnumerator, TDictionary> : IJsonFormatter<TDictionary>, IJsonFormatter where TEnumerator : IEnumerator<KeyValuePair<TKey, TValue>> where TDictionary : class, IEnumerable<KeyValuePair<TKey, TValue>>
	{
		public void Serialize(ref JsonWriter writer, TDictionary value, IJsonFormatterResolver formatterResolver)
		{
		}

		public TDictionary Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}

		protected abstract TEnumerator GetSourceEnumerator(TDictionary source);

		protected abstract TIntermediate Create();

		protected abstract void Add(ref TIntermediate collection, int index, TKey key, TValue value);

		protected abstract TDictionary Complete(ref TIntermediate intermediateCollection);
	}
	public abstract class DictionaryFormatterBase<TKey, TValue, TIntermediate, TDictionary> : DictionaryFormatterBase<TKey, TValue, TIntermediate, IEnumerator<KeyValuePair<TKey, TValue>>, TDictionary> where TDictionary : class, IEnumerable<KeyValuePair<TKey, TValue>>
	{
		protected override IEnumerator<KeyValuePair<TKey, TValue>> GetSourceEnumerator(TDictionary source)
		{
			return null;
		}
	}
	public abstract class DictionaryFormatterBase<TKey, TValue, TDictionary> : DictionaryFormatterBase<TKey, TValue, TDictionary, TDictionary> where TDictionary : class, IDictionary<TKey, TValue>
	{
		protected override TDictionary Complete(ref TDictionary intermediateCollection)
		{
			return null;
		}
	}
}
