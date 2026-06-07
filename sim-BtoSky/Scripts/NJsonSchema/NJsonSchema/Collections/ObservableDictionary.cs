using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace NJsonSchema.Collections
{
	internal sealed class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		private Dictionary<TKey, TValue> _dictionary;

		public ICollection<TKey> Keys => _dictionary.Keys;

		ICollection IDictionary.Values => ((IDictionary)_dictionary).Values;

		ICollection IDictionary.Keys => ((IDictionary)_dictionary).Keys;

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

		public ICollection<TValue> Values => _dictionary.Values;

		public TValue this[TKey key]
		{
			get
			{
				return _dictionary[key];
			}
			set
			{
				Insert(key, value, add: false);
			}
		}

		public bool IsFixedSize => false;

		public int Count => _dictionary.Count;

		public bool IsSynchronized { get; private set; }

		public object SyncRoot { get; private set; }

		public bool IsReadOnly => ((IDictionary)_dictionary).IsReadOnly;

		object IDictionary.this[object key]
		{
			get
			{
				return this[(TKey)key];
			}
			set
			{
				this[(TKey)key] = (TValue)value;
			}
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableDictionary()
		{
			_dictionary = new Dictionary<TKey, TValue>();
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
		{
			_dictionary = new Dictionary<TKey, TValue>(dictionary);
		}

		public ObservableDictionary(IEqualityComparer<TKey> comparer)
		{
			_dictionary = new Dictionary<TKey, TValue>(comparer);
		}

		public ObservableDictionary(int capacity)
		{
			_dictionary = new Dictionary<TKey, TValue>(capacity);
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
			_dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
		}

		public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
			_dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
		}

		public void AddRange(IDictionary<TKey, TValue> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException("items");
			}
			if (items.Count <= 0)
			{
				return;
			}
			if (_dictionary.Count > 0)
			{
				if (items.Keys.Any((TKey k) => _dictionary.ContainsKey(k)))
				{
					throw new ArgumentException("An item with the same key has already been added.");
				}
				foreach (KeyValuePair<TKey, TValue> item in items)
				{
					_dictionary.Add(item.Key, item.Value);
				}
			}
			else
			{
				_dictionary = new Dictionary<TKey, TValue>(items);
			}
			OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray());
		}

		private void Insert(TKey key, TValue value, bool add)
		{
			if (_dictionary.TryGetValue(key, out var value2))
			{
				if (add)
				{
					throw new ArgumentException("An item with the same key has already been added.");
				}
				if (!object.Equals(value2, value))
				{
					_dictionary[key] = value;
					OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, value2));
				}
			}
			else
			{
				_dictionary[key] = value;
				OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void OnCollectionChanged()
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem, 0));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem, 0));
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
		{
			OnPropertyChanged();
			this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItems, 0));
		}

		private void OnPropertyChanged()
		{
			OnPropertyChanged("Count");
			OnPropertyChanged("Item[]");
			OnPropertyChanged("Keys");
			OnPropertyChanged("Values");
		}

		public void Add(TKey key, TValue value)
		{
			Insert(key, value, add: true);
		}

		public bool ContainsKey(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			_dictionary.TryGetValue(key, out var _);
			bool flag = _dictionary.Remove(key);
			if (flag)
			{
				OnCollectionChanged();
			}
			return flag;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return _dictionary.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Insert(item.Key, item.Value, add: true);
		}

		void IDictionary.Add(object key, object value)
		{
			Insert((TKey)key, (TValue)value, add: true);
		}

		public void Clear()
		{
			if (_dictionary.Count > 0)
			{
				_dictionary.Clear();
				OnCollectionChanged();
			}
		}

		public void Initialize(IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
		{
			List<KeyValuePair<TKey, TValue>> pairs = keyValuePairs.ToList();
			foreach (KeyValuePair<TKey, TValue> item in pairs)
			{
				_dictionary[item.Key] = item.Value;
			}
			TKey[] array = _dictionary.Keys.Where((TKey k) => !pairs.Any((KeyValuePair<TKey, TValue> p) => object.Equals(p.Key, k))).ToArray();
			foreach (TKey key in array)
			{
				_dictionary.Remove(key);
			}
			OnCollectionChanged();
		}

		public void Initialize(IEnumerable keyValuePairs)
		{
			Initialize(keyValuePairs.Cast<KeyValuePair<TKey, TValue>>());
		}

		public bool Contains(object key)
		{
			return ContainsKey((TKey)key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)_dictionary).GetEnumerator();
		}

		public void Remove(object key)
		{
			Remove((TKey)key);
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return _dictionary.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection)_dictionary).CopyTo((Array)array, arrayIndex);
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)_dictionary).CopyTo(array, index);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Remove(item.Key);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
		{
			return _dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_dictionary).GetEnumerator();
		}
	}
}
