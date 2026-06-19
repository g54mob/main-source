using Unity.Entities;

public class UpgradeSlotHandler
{
	public readonly InventoryHandler inventoryHandler;

	private EntityMonoBehaviour entityMonoBehaviour;

	private Entity ownerEntity => entityMonoBehaviour.entity;

	private World world => entityMonoBehaviour.world;

	public UpgradeSlotHandler(EntityMonoBehaviour entityMonoBehaviour, World world)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		inventoryHandler = new InventoryHandler(entityMonoBehaviour, world, EntityUtility.GetComponentData<UpgradeSlotCD>(ownerEntity, world).slotIndex, 1, 1);
	}
}
