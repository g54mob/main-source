namespace Restory.StorageSystem
{
	public interface IStorageItemStackable : IStorageItem
	{
		int MaxStackCount { get; }

		bool CanStackWith(IStorageItemStackable item);
	}
}
