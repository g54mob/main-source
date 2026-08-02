public interface IItem
{
	void Take();

	void Drop();

	void AutoDestroy(float time);

	void DestroyItem();

	void Collect(PlayerInventory player);
}
