public interface IStorageUpgrade
{
	int Capacity { get; }

	int Quantity { get; }

	void AddItem(int count);

	void OverrideQuantity(int qty);
}
