public abstract class InventoryCapacityBar : SceneBehaviour
{
	protected ICommunalInventory _inventory;

	public void Initialize(ICommunalInventory inventory)
	{
		if (_inventory != null)
		{
			_inventory.InventoryUpdatedEvent.RemoveListener(UpdateCapacity);
		}
		_inventory = inventory;
		_inventory.InventoryUpdatedEvent.AddListener(UpdateCapacity);
		UpdateCapacity();
	}

	public abstract void UpdateCapacity();
}
