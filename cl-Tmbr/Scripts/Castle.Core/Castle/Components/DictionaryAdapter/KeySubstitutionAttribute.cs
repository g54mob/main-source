using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
	public class KeySubstitutionAttribute : DictionaryBehaviorAttribute, IDictionaryKeyBuilder, IDictionaryBehavior
	{
		private readonly string oldValue;

		private readonly string newValue;

		public KeySubstitutionAttribute(string oldValue, string newValue)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
		}

		string IDictionaryKeyBuilder.GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property)
		{
			return key.Replace(oldValue, newValue);
		}
	}
}
