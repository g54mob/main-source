namespace Utility
{
	public interface IItemPool<T> where T : PoolableItem<T>
	{
		void ReturnItem(T item);

		void ReturnItemDelayed(T item);

		void ReturnDelayedItems();

		void RetireAll();
	}
}
