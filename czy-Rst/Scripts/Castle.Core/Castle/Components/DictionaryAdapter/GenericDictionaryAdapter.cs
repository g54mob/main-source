using System;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter
{
	public class GenericDictionaryAdapter<TValue> : AbstractDictionaryAdapter
	{
		private readonly IDictionary<string, TValue> dictionary;

		public override bool IsReadOnly => dictionary.IsReadOnly;

		public override object this[object key]
		{
			get
			{
				TValue value;
				return dictionary.TryGetValue(GetKey(key), out value) ? value : default(TValue);
			}
			set
			{
				dictionary[GetKey(key)] = (TValue)value;
			}
		}

		public GenericDictionaryAdapter(IDictionary<string, TValue> dictionary)
		{
			this.dictionary = dictionary;
		}

		public override bool Contains(object key)
		{
			return dictionary.Keys.Contains(GetKey(key));
		}

		private static string GetKey(object key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return key.ToString();
		}
	}
	public static class GenericDictionaryAdapter
	{
		public static GenericDictionaryAdapter<TValue> ForDictionaryAdapter<TValue>(this IDictionary<string, TValue> dictionary)
		{
			return new GenericDictionaryAdapter<TValue>(dictionary);
		}
	}
}
