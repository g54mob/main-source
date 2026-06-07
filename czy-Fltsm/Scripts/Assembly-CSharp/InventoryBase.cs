public abstract class InventoryBase : SceneBehaviour
{
	public abstract InventoryType Type { get; }

	public abstract Target Target { get; }

	public abstract int AnimationCycles { get; }

	public abstract Activity PickupActivity { get; }

	public abstract Activity DropoffActivity { get; }

	public abstract Item TakeItem(Item item);

	public bool TryTakeItem(Item item, out Item takenItem)
	{
		takenItem = TakeItem(item);
		return takenItem != null;
	}

	public abstract bool AddItem(Item item, SubInventoryType subInventory);
}
