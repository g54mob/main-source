namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryKeyBuilder : IDictionaryBehavior
	{
		string GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property);
	}
}
