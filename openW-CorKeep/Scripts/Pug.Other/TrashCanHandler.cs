using Unity.Entities;

public class TrashCanHandler
{
	public readonly InventoryHandler inventoryHandler;

	private EntityMonoBehaviour entityMonoBehaviour;

	private Entity ownerEntity => entityMonoBehaviour.entity;

	private World world => entityMonoBehaviour.world;

	public TrashCanHandler(EntityMonoBehaviour entityMonoBehaviour, World world)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		inventoryHandler = new InventoryHandler(entityMonoBehaviour, world, EntityUtility.GetComponentData<TrashCanCD>(ownerEntity, world).slotIndex, 1, 1);
	}
}
