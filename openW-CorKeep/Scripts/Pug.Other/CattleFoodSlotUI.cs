public class CattleFoodSlotUI : SlotUIBase
{
	public override void UpdateSlot()
	{
		PlayerController player = Manager.main.player;
		if (!(player == null))
		{
			ContainedObjectsBuffer food = player.activeCattle.GetFood(visibleSlotIndex);
			if (food.objectID == ObjectID.None)
			{
				SetEmptyIcon();
				return;
			}
			if (!PugDatabase.TryGetObjectInfo(food.objectID, out var objectInfo) || objectInfo.icon == null)
			{
				SetMissingIcon();
				return;
			}
			icon.sprite = objectInfo.icon;
			icon.transform.localPosition = objectInfo.iconOffset;
		}
	}

	public override void OnSelected()
	{
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}
}
