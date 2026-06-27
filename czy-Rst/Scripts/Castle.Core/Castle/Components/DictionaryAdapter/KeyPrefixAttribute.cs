using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public class KeyPrefixAttribute : DictionaryBehaviorAttribute, IDictionaryKeyBuilder, IDictionaryBehavior
	{
		public string KeyPrefix { get; set; }

		public KeyPrefixAttribute()
		{
		}

		public KeyPrefixAttribute(string keyPrefix)
		{
			KeyPrefix = keyPrefix;
		}

		string IDictionaryKeyBuilder.GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property)
		{
			return KeyPrefix + key;
		}
	}
}
