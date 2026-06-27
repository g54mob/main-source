namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryMetaInitializer : IDictionaryBehavior
	{
		void Initialize(IDictionaryAdapterFactory factory, DictionaryAdapterMeta dictionaryMeta);

		bool ShouldHaveBehavior(object behavior);
	}
}
