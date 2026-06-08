namespace KitchenData
{
	public interface IListLookup<TKey, TValue>
	{
		TKey Key { get; }

		TValue Value { get; }
	}
}
