using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = false)]
	public class NewGuidAttribute : DictionaryBehaviorAttribute, IDictionaryPropertyGetter, IDictionaryBehavior
	{
		private static readonly Guid UnassignedGuid;

		public object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
		{
			if (storedValue == null || storedValue.Equals(UnassignedGuid))
			{
				storedValue = Guid.NewGuid();
				property.SetPropertyValue(dictionaryAdapter, key, ref storedValue, dictionaryAdapter.This.Descriptor);
			}
			return storedValue;
		}
	}
}
