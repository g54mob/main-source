using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Castle.Core
{
	public sealed class ReflectionBasedDictionaryAdapter : IDictionary, ICollection, IEnumerable
	{
		private class DictionaryEntryEnumeratorAdapter : IDictionaryEnumerator, IEnumerator
		{
			private readonly IDictionaryEnumerator enumerator;

			private KeyValuePair<string, object> current;

			public DictionaryEntry Entry => new DictionaryEntry(Key, Value);

			public object Key => current.Key;

			public object Value => current.Value;

			public object Current => new DictionaryEntry(Key, Value);

			public DictionaryEntryEnumeratorAdapter(IDictionaryEnumerator enumerator)
			{
				this.enumerator = enumerator;
			}

			public bool MoveNext()
			{
				bool num = enumerator.MoveNext();
				if (num)
				{
					current = (KeyValuePair<string, object>)enumerator.Current;
				}
				return num;
			}

			public void Reset()
			{
				enumerator.Reset();
			}
		}

		private readonly Dictionary<string, object> properties = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

		public int Count => properties.Count;

		public bool IsSynchronized => false;

		public object SyncRoot => properties;

		public bool IsReadOnly => true;

		public object this[object key]
		{
			get
			{
				properties.TryGetValue(key.ToString(), out var value);
				return value;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public ICollection Keys => properties.Keys;

		public ICollection Values => properties.Values;

		bool IDictionary.IsFixedSize
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ReflectionBasedDictionaryAdapter(object target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			Read(properties, target);
		}

		public void Add(object key, object value)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(object key)
		{
			return properties.ContainsKey(key.ToString());
		}

		public void Remove(object key)
		{
		}

		public IEnumerator GetEnumerator()
		{
			return new DictionaryEntryEnumeratorAdapter(properties.GetEnumerator());
		}

		void ICollection.CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new DictionaryEntryEnumeratorAdapter(properties.GetEnumerator());
		}

		public static void Read(IDictionary targetDictionary, object valuesAsAnonymousObject)
		{
			foreach (PropertyInfo readableProperty in GetReadableProperties(valuesAsAnonymousObject.GetType()))
			{
				object propertyValue = GetPropertyValue(valuesAsAnonymousObject, readableProperty);
				targetDictionary[readableProperty.Name] = propertyValue;
			}
		}

		private static object GetPropertyValue(object target, PropertyInfo property)
		{
			return property.GetValue(target, null);
		}

		private static IEnumerable<PropertyInfo> GetReadableProperties(Type targetType)
		{
			return targetType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(IsReadable);
		}

		private static bool IsReadable(PropertyInfo property)
		{
			if (property.CanRead)
			{
				return property.GetIndexParameters().Length == 0;
			}
			return false;
		}
	}
}
