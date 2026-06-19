using System;
using System.Collections;
using System.Collections.Generic;
using TMPEffects.ObjectChanged;

namespace TMPEffects.SerializedCollections
{
	[Serializable]
	public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, INotifyObjectChanged, IDisposable where TValue : INotifyObjectChanged
	{
		protected bool mayRaise = true;

		private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

		public TValue this[TKey key]
		{
			get
			{
				return _dictionary[key];
			}
			set
			{
				_dictionary[key] = value;
				RaisePropertyChanged();
			}
		}

		public ICollection<TKey> Keys => _dictionary.Keys;

		public ICollection<TValue> Values => _dictionary.Values;

		public int Count => ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Count;

		public bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).IsReadOnly;

		public event ObjectChangedEventHandler ObjectChanged;

		public void Add(TKey key, TValue value)
		{
			_dictionary.Add(key, value);
			RaisePropertyChanged();
			if (value != null)
			{
				value.ObjectChanged += RaisePropertyChanged;
			}
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Add(item);
			RaisePropertyChanged();
			if (item.Value != null)
			{
				TValue value = item.Value;
				value.ObjectChanged += RaisePropertyChanged;
			}
		}

		public void Clear()
		{
			foreach (KeyValuePair<TKey, TValue> item in _dictionary)
			{
				if (item.Value != null)
				{
					TValue value = item.Value;
					value.ObjectChanged -= RaisePropertyChanged;
				}
			}
			_dictionary.Clear();
			RaisePropertyChanged();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Contains(item);
		}

		public bool ContainsKey(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).CopyTo(array, arrayIndex);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<TKey, TValue>>)_dictionary).GetEnumerator();
		}

		public bool Remove(TKey key)
		{
			if (_dictionary.ContainsKey(key))
			{
				TValue val = _dictionary[key];
				val.ObjectChanged -= RaisePropertyChanged;
				if (!_dictionary.Remove(key))
				{
					throw new InvalidOperationException("Failed to remove key despite it being present?");
				}
				RaisePropertyChanged();
				return true;
			}
			return false;
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			if (((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Contains(item))
			{
				TValue val = _dictionary[item.Key];
				val.ObjectChanged -= RaisePropertyChanged;
				if (!_dictionary.Remove(item.Key))
				{
					throw new InvalidOperationException("Failed to remove key despite it being present?");
				}
				RaisePropertyChanged();
				return true;
			}
			return false;
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return _dictionary.TryGetValue(key, out value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_dictionary).GetEnumerator();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		protected void RaisePropertyChanged()
		{
			if (mayRaise)
			{
				this.ObjectChanged?.Invoke(this);
			}
		}

		protected void RaisePropertyChanged(object sender)
		{
			if (mayRaise)
			{
				this.ObjectChanged?.Invoke(this);
			}
		}
	}
}
