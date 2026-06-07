using System;
using System.Collections.Generic;

namespace UI.Xml
{
	[Serializable]
	public class AttributeDictionary : SerializableDictionary<string, string>
	{
		public AttributeDictionary(IDictionary<string, string> attributes = null)
		{
			_Comparer = StringComparer.OrdinalIgnoreCase;
			if (attributes == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> attribute in attributes)
			{
				Add(attribute.Key, attribute.Value);
			}
		}

		public AttributeDictionary Clone()
		{
			return new AttributeDictionary(this);
		}

		public virtual AttributeDictionary AsReadOnly()
		{
			return new ReadOnlyAttributeDictionary(this);
		}

		public virtual string GetValue(string key)
		{
			if (ContainsKey(key))
			{
				return this[key];
			}
			return null;
		}

		public virtual T GetValue<T>(string key)
		{
			return GetValue(key).ChangeToType<T>();
		}

		public override string ToString()
		{
			string text = "AttributeDictionary Values:\n";
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				text += $"[{current.Key}] => '{current.Value}'\n";
			}
			return text;
		}

		public void Merge(AttributeDictionary other)
		{
			if (other.Count == 0)
			{
				return;
			}
			foreach (KeyValuePair<string, string> item in other)
			{
				this.SetValue(item.Key, item.Value);
			}
		}
	}
}
