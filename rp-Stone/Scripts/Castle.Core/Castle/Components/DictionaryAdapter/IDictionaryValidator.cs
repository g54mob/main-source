namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryValidator
	{
		bool IsValid(IDictionaryAdapter dictionaryAdapter);

		string Validate(IDictionaryAdapter dictionaryAdapter);

		string Validate(IDictionaryAdapter dictionaryAdapter, PropertyDescriptor property);

		void Invalidate(IDictionaryAdapter dictionaryAdapter);
	}
}
