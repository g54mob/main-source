namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryPropertySetter : IDictionaryBehavior
	{
		bool SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor property);
	}
}
