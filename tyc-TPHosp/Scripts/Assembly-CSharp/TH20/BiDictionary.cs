using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace TH20
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(DictionaryDebugView<, >))]
	public class BiDictionary<TFirst, TSecond> : IDictionary<TFirst, TSecond>, ICollection<KeyValuePair<TFirst, TSecond>>, IEnumerable<KeyValuePair<TFirst, TSecond>>, IEnumerable, IDictionary, ICollection
	{
		private class ReverseDictionary : IDictionary<TSecond, TFirst>, ICollection<KeyValuePair<TSecond, TFirst>>, IEnumerable<KeyValuePair<TSecond, TFirst>>, IEnumerable, IDictionary, ICollection
		{
			private readonly BiDictionary<TFirst, TSecond> _owner;

			public int Count => _owner._secondToFirst.Count;

			object ICollection.SyncRoot => ((ICollection)_owner._secondToFirst).SyncRoot;

			bool ICollection.IsSynchronized => ((ICollection)_owner._secondToFirst).IsSynchronized;

			bool IDictionary.IsFixedSize => ((IDictionary)_owner._secondToFirst).IsFixedSize;

			public bool IsReadOnly
			{
				get
				{
					if (!((IDictionary)_owner._secondToFirst).IsReadOnly)
					{
						return ((IDictionary)_owner._firstToSecond).IsReadOnly;
					}
					return true;
				}
			}

			public TFirst this[TSecond key]
			{
				get
				{
					return _owner._secondToFirst[key];
				}
				set
				{
					_owner._secondToFirst[key] = value;
					_owner._firstToSecond[value] = key;
				}
			}

			object IDictionary.this[object key]
			{
				get
				{
					return ((IDictionary)_owner._secondToFirst)[key];
				}
				set
				{
					((IDictionary)_owner._secondToFirst)[key] = value;
					((IDictionary)_owner._firstToSecond)[value] = key;
				}
			}

			public ICollection<TSecond> Keys => _owner._secondToFirst.Keys;

			ICollection IDictionary.Keys => ((IDictionary)_owner._secondToFirst).Keys;

			public ICollection<TFirst> Values => _owner._secondToFirst.Values;

			ICollection IDictionary.Values => ((IDictionary)_owner._secondToFirst).Values;

			public ReverseDictionary(BiDictionary<TFirst, TSecond> owner)
			{
				_owner = owner;
			}

			public IEnumerator<KeyValuePair<TSecond, TFirst>> GetEnumerator()
			{
				return _owner._secondToFirst.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			IDictionaryEnumerator IDictionary.GetEnumerator()
			{
				return ((IDictionary)_owner._secondToFirst).GetEnumerator();
			}

			public void Add(TSecond key, TFirst value)
			{
				_owner._secondToFirst.Add(key, value);
				_owner._firstToSecond.Add(value, key);
			}

			void IDictionary.Add(object key, object value)
			{
				((IDictionary)_owner._secondToFirst).Add(key, value);
				((IDictionary)_owner._firstToSecond).Add(value, key);
			}

			public void Add(KeyValuePair<TSecond, TFirst> item)
			{
				((ICollection<KeyValuePair<TSecond, TFirst>>)_owner._secondToFirst).Add(item);
				((ICollection<KeyValuePair<TFirst, TSecond>>)_owner._firstToSecond).Add(item.Reverse());
			}

			public bool ContainsKey(TSecond key)
			{
				return _owner._secondToFirst.ContainsKey(key);
			}

			public bool Contains(KeyValuePair<TSecond, TFirst> item)
			{
				return ((ICollection<KeyValuePair<TSecond, TFirst>>)_owner._secondToFirst).Contains(item);
			}

			public bool TryGetValue(TSecond key, out TFirst value)
			{
				return _owner._secondToFirst.TryGetValue(key, out value);
			}

			public bool Remove(TSecond key)
			{
				if (_owner._secondToFirst.TryGetValue(key, out var value))
				{
					_owner._secondToFirst.Remove(key);
					_owner._firstToSecond.Remove(value);
					return true;
				}
				return false;
			}

			void IDictionary.Remove(object key)
			{
				IDictionary secondToFirst = _owner._secondToFirst;
				if (secondToFirst.Contains(key))
				{
					object key2 = secondToFirst[key];
					secondToFirst.Remove(key);
					((IDictionary)_owner._firstToSecond).Remove(key2);
				}
			}

			public bool Remove(KeyValuePair<TSecond, TFirst> item)
			{
				return ((ICollection<KeyValuePair<TSecond, TFirst>>)_owner._secondToFirst).Remove(item);
			}

			public bool Contains(object key)
			{
				return ((IDictionary)_owner._secondToFirst).Contains(key);
			}

			public void Clear()
			{
				_owner._secondToFirst.Clear();
				_owner._firstToSecond.Clear();
			}

			public void CopyTo(KeyValuePair<TSecond, TFirst>[] array, int arrayIndex)
			{
				((ICollection<KeyValuePair<TSecond, TFirst>>)_owner._secondToFirst).CopyTo(array, arrayIndex);
			}

			void ICollection.CopyTo(Array array, int index)
			{
				((ICollection)_owner._secondToFirst).CopyTo(array, index);
			}
		}

		private readonly Dictionary<TFirst, TSecond> _firstToSecond = new Dictionary<TFirst, TSecond>();

		[NonSerialized]
		private readonly Dictionary<TSecond, TFirst> _secondToFirst = new Dictionary<TSecond, TFirst>();

		[NonSerialized]
		private readonly ReverseDictionary _reverseDictionary;

		public Dictionary<TFirst, TSecond> FirstToSecond => _firstToSecond;

		public Dictionary<TSecond, TFirst> SecondToFirst => _secondToFirst;

		public IDictionary<TSecond, TFirst> Reverse => _reverseDictionary;

		public int Count => _firstToSecond.Count;

		object ICollection.SyncRoot => ((ICollection)_firstToSecond).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)_firstToSecond).IsSynchronized;

		bool IDictionary.IsFixedSize => ((IDictionary)_firstToSecond).IsFixedSize;

		public bool IsReadOnly
		{
			get
			{
				if (!((IDictionary)_firstToSecond).IsReadOnly)
				{
					return ((IDictionary)_secondToFirst).IsReadOnly;
				}
				return true;
			}
		}

		public TSecond this[TFirst key]
		{
			get
			{
				return _firstToSecond[key];
			}
			set
			{
				_firstToSecond[key] = value;
				_secondToFirst[value] = key;
			}
		}

		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary)_firstToSecond)[key];
			}
			set
			{
				((IDictionary)_firstToSecond)[key] = value;
				((IDictionary)_secondToFirst)[value] = key;
			}
		}

		public ICollection<TFirst> Keys => _firstToSecond.Keys;

		ICollection IDictionary.Keys => ((IDictionary)_firstToSecond).Keys;

		public ICollection<TSecond> Values => _firstToSecond.Values;

		ICollection IDictionary.Values => ((IDictionary)_firstToSecond).Values;

		public BiDictionary()
		{
			_reverseDictionary = new ReverseDictionary(this);
		}

		public IEnumerator<KeyValuePair<TFirst, TSecond>> GetEnumerator()
		{
			return _firstToSecond.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)_firstToSecond).GetEnumerator();
		}

		public void Add(TFirst key, TSecond value)
		{
			_firstToSecond.Add(key, value);
			_secondToFirst.Add(value, key);
		}

		void IDictionary.Add(object key, object value)
		{
			((IDictionary)_firstToSecond).Add(key, value);
			((IDictionary)_secondToFirst).Add(value, key);
		}

		public void Add(KeyValuePair<TFirst, TSecond> item)
		{
			_firstToSecond.Add(item.Key, item.Value);
			_secondToFirst.Add(item.Value, item.Key);
		}

		public bool ContainsKey(TFirst key)
		{
			return _firstToSecond.ContainsKey(key);
		}

		public bool ContainsValue(TSecond value)
		{
			return _secondToFirst.ContainsKey(value);
		}

		public bool Contains(KeyValuePair<TFirst, TSecond> item)
		{
			return ((IDictionary)_firstToSecond).Contains((object)item);
		}

		public bool TryGetValue(TFirst key, out TSecond value)
		{
			return _firstToSecond.TryGetValue(key, out value);
		}

		public bool Remove(TFirst key)
		{
			if (_firstToSecond.TryGetValue(key, out var value))
			{
				_firstToSecond.Remove(key);
				_secondToFirst.Remove(value);
				return true;
			}
			return false;
		}

		void IDictionary.Remove(object key)
		{
			IDictionary firstToSecond = _firstToSecond;
			if (firstToSecond.Contains(key))
			{
				object key2 = firstToSecond[key];
				firstToSecond.Remove(key);
				((IDictionary)_secondToFirst).Remove(key2);
			}
		}

		public bool Remove(KeyValuePair<TFirst, TSecond> item)
		{
			return ((ICollection<KeyValuePair<TFirst, TSecond>>)_firstToSecond).Remove(item);
		}

		public bool Contains(object key)
		{
			return ((IDictionary)_firstToSecond).Contains(key);
		}

		public void Clear()
		{
			_firstToSecond.Clear();
			_secondToFirst.Clear();
		}

		public void CopyTo(KeyValuePair<TFirst, TSecond>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<TFirst, TSecond>>)_firstToSecond).CopyTo(array, arrayIndex);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection)_firstToSecond).CopyTo(array, index);
		}

		[OnDeserialized]
		internal void OnDeserialized(StreamingContext context)
		{
			_secondToFirst.Clear();
			foreach (KeyValuePair<TFirst, TSecond> item in _firstToSecond)
			{
				_secondToFirst.Add(item.Value, item.Key);
			}
		}
	}
}
