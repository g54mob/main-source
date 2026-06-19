using System.Collections.Generic;
using Unity.Entities;

public class UpgradeForgeButton : ButtonUIElement
{
	private ContainedObjectsBuffer _item;

	public void UpdateSlotItem(ContainedObjectsBuffer item)
	{
		_item = item;
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		canBeClicked = ShouldBeActive();
	}

	public override List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		PlayerController player = Manager.main.player;
		ContainedObjectsBuffer item = _item;
		if (item.objectID == ObjectID.None)
		{
			return null;
		}
		CraftingHandler craftingHandler = ((!(player != null)) ? null : ((player.activeCraftingHandler != null) ? player.activeCraftingHandler : player.playerCraftingHandler));
		if (craftingHandler != null && item.objectID != ObjectID.None && PugDatabase.HasComponent<LevelCD>(item.objectData))
		{
			int num = ((item.variation > 0) ? item.variation : PugDatabase.GetComponent<LevelCD>(item.objectData).level);
			if (num >= LevelScaling.GetMaxLevel())
			{
				return null;
			}
			List<Entity> nearbyChests = craftingHandler.GetNearbyChests();
			return craftingHandler.GetCraftingMaterialInfosForUpgrade(num + 1, nearbyChests);
		}
		return null;
	}

	public bool ShouldBeActive()
	{
		if (Manager.ui.craftingMaterialsAreNotRequired)
		{
			return true;
		}
		PlayerController player = Manager.main.player;
		ContainedObjectsBuffer item = _item;
		if (item.objectID == ObjectID.None)
		{
			return false;
		}
		CraftingHandler craftingHandler = ((!(player != null)) ? null : ((player.activeCraftingHandler != null) ? player.activeCraftingHandler : player.playerCraftingHandler));
		if (craftingHandler != null && item.objectID != ObjectID.None && PugDatabase.HasComponent<LevelCD>(item.objectData))
		{
			int num = ((item.variation > 0) ? item.variation : PugDatabase.GetComponent<LevelCD>(item.objectData).level);
			if (num >= LevelScaling.GetMaxLevel())
			{
				return false;
			}
			List<Entity> nearbyChests = craftingHandler.GetNearbyChests();
			return craftingHandler.HasMaterialsToBeUpgraded(num + 1, nearbyChests);
		}
		return false;
	}

	public override TextAndFormatFields GetHoverTitle()
	{
		if (GetRequiredMaterials(isRepairing: false, isReinforcing: false) == null)
		{
			return null;
		}
		return base.GetHoverTitle();
	}
}
