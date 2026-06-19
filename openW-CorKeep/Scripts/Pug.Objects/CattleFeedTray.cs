using System.Collections.Generic;
using UnityEngine;

public class CattleFeedTray : Table
{
	public List<Animator> itemAnimatorsHorizontal;

	private List<ObjectDataCD> _containedItems = new List<ObjectDataCD>();

	public override void OnOccupied()
	{
		base.OnOccupied();
		_containedItems = new List<ObjectDataCD>();
		for (int i = 0; i < 3; i++)
		{
			_containedItems.Add(default(ObjectDataCD));
		}
		UpdateContainedItemsAnimations(onlyUpdateData: true);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateContainedItemsAnimations(onlyUpdateData: false);
	}

	private void UpdateContainedItemsAnimations(bool onlyUpdateData)
	{
		for (int i = 0; i < base.inventoryHandler.size; i++)
		{
			ObjectDataCD objectDataCD = base.inventoryHandler.GetObjectData(i);
			if (!onlyUpdateData && (_containedItems[i].objectID != objectDataCD.objectID || _containedItems[i].amount != objectDataCD.amount))
			{
				itemAnimatorsHorizontal[i].SetTrigger(-1838420484);
			}
			_containedItems[i] = base.inventoryHandler.GetObjectData(i);
		}
	}
}
