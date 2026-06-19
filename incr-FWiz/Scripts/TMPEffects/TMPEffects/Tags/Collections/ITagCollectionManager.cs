namespace TMPEffects.Tags.Collections
{
	internal interface ITagCollectionManager<TKey>
	{
		ITagCollection this[TKey key] { get; }

		ITagCollection AddKey(TKey key);

		bool RemoveKey(TKey key);
	}
}
