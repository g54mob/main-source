using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class KeyAttribute : DictionaryBehaviorAttribute, IDictionaryKeyBuilder, IDictionaryBehavior
	{
		public string Key { get; private set; }

		public KeyAttribute(string key)
		{
			Key = key;
		}

		public KeyAttribute(string[] keys)
		{
			Key = string.Join(",", keys);
		}

		string IDictionaryKeyBuilder.GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property)
		{
			return Key;
		}
	}
}
