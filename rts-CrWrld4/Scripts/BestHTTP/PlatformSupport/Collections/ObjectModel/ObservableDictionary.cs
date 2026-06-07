using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PlatformSupport.Collections.Specialized;

namespace PlatformSupport.Collections.ObjectModel
{
	public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
	{
		private const string CountString = "Count";

		private const string IndexerName = "Item[]";

		private const string KeysName = "Keys";

		private const string ValuesName = "Values";

		private IDictionary<TKey, TValue> _Dictionary;

		protected IDictionary<TKey, TValue> Dictionary => null;

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		public TValue Item
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

		public bool IsReadOnly => false;

		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public ObservableDictionary()
		{
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
		{
		}

		public ObservableDictionary(IEqualityComparer<TKey> comparer)
		{
		}

		public ObservableDictionary(int capacity)
		{
		}

		public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
		{
		}

		public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
		{
		}

		public void Add(TKey key, TValue value)
		{
		}

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void AddRange(IDictionary<TKey, TValue> items)
		{
		}

		private void Insert(TKey key, TValue value, bool add)
		{
		}

		private void OnPropertyChanged()
		{
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
		}

		private void OnCollectionChanged()
		{
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
		{
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
		{
		}

		private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
		{
		}
	}
}
