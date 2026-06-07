using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BrewGame.SaveSystem.Serialization
{
	[Serializable]
	public class SerializableDictionary<TKey, TValue>
	{
		[JsonProperty]
		private Dictionary<TKey, TValue> _dictionary;

		[JsonIgnore]
		public Dictionary<TKey, TValue> Dictionary => null;

		public TValue this[TKey key]
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public int Count => 0;

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		public SerializableDictionary()
		{
		}

		public SerializableDictionary(Dictionary<TKey, TValue> source)
		{
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public void Add(TKey key, TValue value)
		{
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public void Clear()
		{
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}
	}
}
