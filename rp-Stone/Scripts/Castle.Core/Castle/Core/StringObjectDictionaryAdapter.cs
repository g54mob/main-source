using System;
using System.Collections;
using System.Collections.Generic;

namespace Castle.Core
{
	public sealed class StringObjectDictionaryAdapter : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
		internal class EnumeratorAdapter : IEnumerator<KeyValuePair<string, object>>, IDisposable, IEnumerator
		{
			private readonly StringObjectDictionaryAdapter adapter;

			private IEnumerator<string> keyEnumerator;

			private string currentKey;

			private object currentValue;

			public object Current => new KeyValuePair<string, object>(currentKey, currentValue);

			KeyValuePair<string, object> IEnumerator<KeyValuePair<string, object>>.Current => new KeyValuePair<string, object>(currentKey, currentValue);

			public EnumeratorAdapter(StringObjectDictionaryAdapter adapter)
			{
				this.adapter = adapter;
				keyEnumerator = ((IDictionary<string, object>)adapter).Keys.GetEnumerator();
			}

			public bool MoveNext()
			{
				if (keyEnumerator.MoveNext())
				{
					currentKey = keyEnumerator.Current;
					currentValue = adapter[currentKey];
					return true;
				}
				return false;
			}

			public void Reset()
			{
				keyEnumerator.Reset();
			}

			public void Dispose()
			{
				GC.SuppressFinalize(this);
			}
		}

		private readonly IDictionary dictionary;

		object IDictionary<string, object>.this[string key]
		{
			get
			{
				return dictionary[key];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		ICollection<string> IDictionary<string, object>.Keys
		{
			get
			{
				string[] array = new string[Count];
				dictionary.Keys.CopyTo(array, 0);
				return array;
			}
		}

		ICollection<object> IDictionary<string, object>.Values
		{
			get
			{
				object[] array = new object[Count];
				dictionary.Values.CopyTo(array, 0);
				return array;
			}
		}

		public object this[object key]
		{
			get
			{
				return dictionary[key];
			}
			set
			{
				dictionary[key] = value;
			}
		}

		public ICollection Keys => dictionary.Keys;

		public ICollection Values => dictionary.Values;

		public bool IsReadOnly => dictionary.IsReadOnly;

		public bool IsFixedSize => dictionary.IsFixedSize;

		public int Count => dictionary.Count;

		public object SyncRoot => dictionary.SyncRoot;

		public bool IsSynchronized => dictionary.IsSynchronized;

		public StringObjectDictionaryAdapter(IDictionary dictionary)
		{
			this.dictionary = dictionary;
		}

		bool IDictionary<string, object>.ContainsKey(string key)
		{
			return dictionary.Contains(key);
		}

		void IDictionary<string, object>.Add(string key, object value)
		{
			throw new NotImplementedException();
		}

		bool IDictionary<string, object>.Remove(string key)
		{
			throw new NotImplementedException();
		}

		bool IDictionary<string, object>.TryGetValue(string key, out object value)
		{
			value = null;
			if (dictionary.Contains(key))
			{
				value = dictionary[key];
				return true;
			}
			return false;
		}

		void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
		{
			throw new NotImplementedException();
		}

		bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
		{
			throw new NotImplementedException();
		}

		void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
		{
			throw new NotImplementedException();
		}

		IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
		{
			return new EnumeratorAdapter(this);
		}

		public bool Contains(object key)
		{
			return dictionary.Contains(key);
		}

		public void Add(object key, object value)
		{
			dictionary.Add(key, value);
		}

		public void Clear()
		{
			dictionary.Clear();
		}

		public void Remove(object key)
		{
			dictionary.Remove(key);
		}

		public void CopyTo(Array array, int index)
		{
			dictionary.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable)dictionary).GetEnumerator();
		}
	}
}
