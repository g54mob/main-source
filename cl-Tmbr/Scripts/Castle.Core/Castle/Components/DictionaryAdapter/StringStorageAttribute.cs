using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = false)]
	public class StringStorageAttribute : DictionaryBehaviorAttribute, IDictionaryPropertySetter, IDictionaryBehavior
	{
		public bool SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor property)
		{
			value = ((value != null) ? value.ToString() : null);
			return true;
		}
	}
}
