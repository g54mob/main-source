using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
	public class TypeKeyPrefixAttribute : DictionaryBehaviorAttribute, IDictionaryKeyBuilder, IDictionaryBehavior
	{
		string IDictionaryKeyBuilder.GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property)
		{
			return $"{property.Property.DeclaringType.FullName}#{key}";
		}
	}
}
