using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPEffects.ObjectChanged;

namespace TMPEffects.SerializedCollections
{
	[Serializable]
	public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INotifyObjectChanged, IDisposable where TValue : INotifyObjectChanged
	{
		protected bool mayRaise;

		private Dictionary<TKey, TValue> _dictionary;

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

		public ICollection<TKey> Keys => null;

		public ICollection<TValue> Values => null;

		public int Count => 0;

		public bool IsReadOnly => false;

		public event ObjectChangedEventHandler ObjectChanged
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

		public void Add(TKey key, TValue value)
		{
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

		public bool ContainsKey(TKey key)
		{
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return null;
		}

		public bool Remove(TKey key)
		{
			return false;
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			value = default(TValue);
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public void Dispose()
		{
		}

		protected void RaisePropertyChanged()
		{
		}

		protected void RaisePropertyChanged(object sender)
		{
		}
	}
}
