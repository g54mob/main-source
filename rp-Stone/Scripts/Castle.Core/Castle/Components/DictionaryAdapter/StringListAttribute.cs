using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class StringListAttribute : DictionaryBehaviorAttribute, IDictionaryPropertyGetter, IDictionaryBehavior, IDictionaryPropertySetter
	{
		private class StringListWrapper<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private readonly string key;

			private readonly char separator;

			private readonly IDictionary dictionary;

			private readonly List<T> inner;

			public T this[int index]
			{
				get
				{
					return inner[index];
				}
				set
				{
					inner[index] = value;
					SynchronizeDictionary();
				}
			}

			public int Count => inner.Count;

			public bool IsReadOnly => false;

			public StringListWrapper(string key, string list, char separator, IDictionary dictionary)
			{
				this.key = key;
				this.separator = separator;
				this.dictionary = dictionary;
				inner = new List<T>();
				ParseList(list);
			}

			public int IndexOf(T item)
			{
				return inner.IndexOf(item);
			}

			public void Insert(int index, T item)
			{
				inner.Insert(index, item);
				SynchronizeDictionary();
			}

			public void RemoveAt(int index)
			{
				inner.RemoveAt(index);
				SynchronizeDictionary();
			}

			public void Add(T item)
			{
				inner.Add(item);
				SynchronizeDictionary();
			}

			public void Clear()
			{
				inner.Clear();
				SynchronizeDictionary();
			}

			public bool Contains(T item)
			{
				return inner.Contains(item);
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
				inner.CopyTo(array, arrayIndex);
			}

			public bool Remove(T item)
			{
				if (inner.Remove(item))
				{
					SynchronizeDictionary();
					return true;
				}
				return false;
			}

			public IEnumerator<T> GetEnumerator()
			{
				return inner.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return inner.GetEnumerator();
			}

			private void ParseList(string list)
			{
				if (list != null)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
					string[] array = list.Split(new char[1] { separator });
					foreach (string value in array)
					{
						inner.Add((T)converter.ConvertFrom(value));
					}
				}
			}

			private void SynchronizeDictionary()
			{
				dictionary[key] = BuildString(inner, separator);
			}
		}

		public char Separator { get; set; }

		public StringListAttribute()
		{
			Separator = ',';
		}

		object IDictionaryPropertyGetter.GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
		{
			Type propertyType = property.PropertyType;
			if ((storedValue == null || !storedValue.GetType().IsInstanceOfType(propertyType)) && propertyType.GetTypeInfo().IsGenericType)
			{
				Type genericTypeDefinition = propertyType.GetGenericTypeDefinition();
				if (genericTypeDefinition == typeof(IList<>) || genericTypeDefinition == typeof(ICollection<>) || genericTypeDefinition == typeof(List<>) || genericTypeDefinition == typeof(IEnumerable<>))
				{
					Type type = propertyType.GetGenericArguments()[0];
					TypeConverter converter = TypeDescriptor.GetConverter(type);
					if (converter != null && converter.CanConvertFrom(typeof(string)))
					{
						return Activator.CreateInstance(typeof(StringListWrapper<>).MakeGenericType(type), key, storedValue, Separator, dictionaryAdapter.This.Dictionary);
					}
				}
			}
			return storedValue;
		}

		bool IDictionaryPropertySetter.SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor property)
		{
			if (value is IEnumerable enumerable)
			{
				value = BuildString(enumerable, Separator);
			}
			return true;
		}

		internal static string BuildString(IEnumerable enumerable, char separator)
		{
			bool flag = true;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object item in enumerable)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					stringBuilder.Append(separator);
				}
				stringBuilder.Append(item.ToString());
			}
			return stringBuilder.ToString();
		}
	}
}
