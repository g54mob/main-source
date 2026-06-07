using System;
using System.Collections.Generic;

namespace UI.Xml
{
	[Serializable]
	public class ReadOnlyAttributeDictionary : AttributeDictionary
	{
		private AttributeDictionary dictionary;

		public override bool IsReadOnly => true;

		public override string this[string key, string defaultValue] => dictionary[key, defaultValue];

		public override string this[string key]
		{
			get
			{
				return dictionary[key];
			}
			set
			{
				throw new NotSupportedException("This attribute collection is read-only!");
			}
		}

		public ReadOnlyAttributeDictionary(AttributeDictionary dictionary)
		{
			this.dictionary = dictionary;
		}

		public override void Clear()
		{
			throw new NotSupportedException("This attribute collection is read-only!");
		}

		public override void Add(KeyValuePair<string, string> item)
		{
			throw new NotSupportedException("This attribute collection is read-only!");
		}

		public override bool Remove(KeyValuePair<string, string> item)
		{
			throw new NotSupportedException("This attribute collection is read-only!");
		}

		public override bool Remove(string key)
		{
			throw new NotSupportedException("This attribute collection is read-only!");
		}

		public override void Add(string key, string value)
		{
			throw new NotSupportedException("This attribute collection is read-only!");
		}

		public override string GetValue(string key)
		{
			return dictionary.GetValue(key);
		}

		public override T GetValue<T>(string key)
		{
			return dictionary.GetValue<T>(key);
		}

		public override string ToString()
		{
			return dictionary.ToString();
		}

		public override bool ContainsValue(string value)
		{
			return dictionary.ContainsValue(value);
		}

		public override bool ContainsKey(string key)
		{
			return dictionary.ContainsKey(key);
		}

		public override AttributeDictionary AsReadOnly()
		{
			return this;
		}
	}
}
