namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryReferenceManager
	{
		bool IsReferenceProperty(IDictionaryAdapter dictionaryAdapter, string propertyName);

		bool TryGetReference(object keyObject, out object inGraphObject);

		void AddReference(object keyObject, object relatedObject, bool isInGraph);
	}
}
