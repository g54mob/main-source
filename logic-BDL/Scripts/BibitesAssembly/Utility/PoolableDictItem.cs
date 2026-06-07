namespace Utility
{
	public abstract class PoolableDictItem<TKey, T> : PoolableItem<T> where T : PoolableDictItem<TKey, T>
	{
		public virtual void AssignKey(TKey key)
		{
		}
	}
}
