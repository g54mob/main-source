public interface IInventorySpaceLimiter
{
	bool FitsItem(Item item);

	bool FitsItem(ItemProperties itemProperties);

	int GetCapacity(ItemProperties itemProperties);
}
