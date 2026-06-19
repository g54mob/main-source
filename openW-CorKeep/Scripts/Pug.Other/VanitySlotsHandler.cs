using Unity.Entities;

public class VanitySlotsHandler
{
	public readonly InventoryHandler helmVanitySlotInventoryHandler;

	public readonly InventoryHandler breastVanitySlotInventoryHandler;

	public readonly InventoryHandler pantsVanitySlotInventoryHandler;

	private EntityMonoBehaviour entityMonoBehaviour;

	private Entity ownerEntity => entityMonoBehaviour.entity;

	private World world => entityMonoBehaviour.world;

	public VanitySlotsHandler(EntityMonoBehaviour entityMonoBehaviour, World world)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		VanitySlotsCD componentData = EntityUtility.GetComponentData<VanitySlotsCD>(ownerEntity, world);
		helmVanitySlotInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, componentData.helmVanitySlotIndex, 1, 1);
		breastVanitySlotInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, componentData.breastVanitySlotIndex, 1, 1);
		pantsVanitySlotInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, componentData.pantsVanitySlotIndex, 1, 1);
	}
}
