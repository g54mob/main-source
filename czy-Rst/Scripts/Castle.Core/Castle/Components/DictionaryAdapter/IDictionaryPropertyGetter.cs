namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryPropertyGetter : IDictionaryBehavior
	{
		object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists);
	}
}
