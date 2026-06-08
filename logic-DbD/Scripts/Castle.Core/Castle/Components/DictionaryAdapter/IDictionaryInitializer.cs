namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryInitializer : IDictionaryBehavior
	{
		void Initialize(IDictionaryAdapter dictionaryAdapter, object[] behaviors);
	}
}
