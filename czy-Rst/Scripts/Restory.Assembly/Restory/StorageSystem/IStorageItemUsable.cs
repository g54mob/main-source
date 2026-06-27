namespace Restory.StorageSystem
{
	public interface IStorageItemUsable : IStorageItem
	{
		float Progress { get; set; }

		float MaxProgress { get; }
	}
}
