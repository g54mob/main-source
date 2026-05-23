using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NJsonSchema.Infrastructure
{
	internal sealed class DictionaryProxy<TKey, TInterface, TImplementation> : IDictionary<TKey, TInterface>, ICollection<KeyValuePair<TKey, TInterface>>, IEnumerable<KeyValuePair<TKey, TInterface>>, IEnumerable where TImplementation : TInterface
	{
		private readonly IDictionary<TKey, TImplementation> _dictionary;

		public int Count => _dictionary.Count;

		public bool IsReadOnly => _dictionary.IsReadOnly;

		public TInterface this[TKey key]
		{
			get
			{
				return (TInterface)(object)_dictionary[key];
			}
			set
			{
				_dictionary[key] = (TImplementation)(object)value;
			}
		}

		public ICollection<TKey> Keys => _dictionary.Keys;

		public ICollection<TInterface> Values => _dictionary.Values.OfType<TInterface>().ToList();

		public DictionaryProxy(IDictionary<TKey, TImplementation> dictionary)
		{
			_dictionary = dictionary;
		}

		public IEnumerator<KeyValuePair<TKey, TInterface>> GetEnumerator()
		{
			return _dictionary.Select((KeyValuePair<TKey, TImplementation> t) => new KeyValuePair<TKey, TInterface>(t.Key, (TInterface)(object)t.Value)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(KeyValuePair<TKey, TInterface> item)
		{
			_dictionary.Add(item.Key, (TImplementation)(object)item.Value);
		}

		public void Clear()
		{
			_dictionary.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TInterface> item)
		{
			return _dictionary.Contains(new KeyValuePair<TKey, TImplementation>(item.Key, (TImplementation)(object)item.Value));
		}

		public void CopyTo(KeyValuePair<TKey, TInterface>[] array, int arrayIndex)
		{
			_dictionary.CopyTo(array.Select((KeyValuePair<TKey, TInterface> t) => new KeyValuePair<TKey, TImplementation>(t.Key, (TImplementation)(object)t.Value)).ToArray(), arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TInterface> item)
		{
			return _dictionary.Remove(new KeyValuePair<TKey, TImplementation>(item.Key, (TImplementation)(object)item.Value));
		}

		public void Add(TKey key, TInterface value)
		{
			_dictionary.Add(key, (TImplementation)(object)value);
		}

		public bool ContainsKey(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			return _dictionary.Remove(key);
		}

		public bool TryGetValue(TKey key, out TInterface value)
		{
			if (_dictionary.TryGetValue(key, out var value2))
			{
				value = (TInterface)(object)value2;
				return true;
			}
			value = default(TInterface);
			return false;
		}
	}
}
