using Unity.Entities;
using UnityEngine;

public class SellSlotsHandler
{
	public readonly InventoryHandler sellSlotsInventoryHandler;

	private EntityMonoBehaviour entityMonoBehaviour;

	private Entity ownerEntity => entityMonoBehaviour.entity;

	private World world => entityMonoBehaviour.world;

	public SellSlotsHandler(EntityMonoBehaviour entityMonoBehaviour, World world)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		SellSlotsCD componentData = EntityUtility.GetComponentData<SellSlotsCD>(ownerEntity, world);
		sellSlotsInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, componentData.startIndex, componentData.sizeX, componentData.sizeX * componentData.sizeY);
		EntityUtility.SetComponentData(ownerEntity, world, componentData);
	}

	public void MoveAllSlotsToPlayerInventoryOrDrop(Vector3 renderPosition)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < sellSlotsInventoryHandler.size; i++)
		{
			if (sellSlotsInventoryHandler.GetObjectData(i).objectID != ObjectID.None)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			sellSlotsInventoryHandler.MoveOrDropItems(player, Manager.main.player.playerInventoryHandler, renderPosition);
		}
	}
}
