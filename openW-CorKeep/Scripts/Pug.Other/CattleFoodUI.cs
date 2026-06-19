using System.Collections.Generic;
using UnityEngine;

public class CattleFoodUI : ItemSlotsUIContainer
{
	public override int MAX_ROWS => 1;

	public override int MAX_COLUMNS => 3;

	public override void ShowContainerUI()
	{
		base.ShowContainerUI();
		PlayerController playerController = Manager.main.player;
		if (playerController == null)
		{
			return;
		}
		List<ContainedObjectsBuffer> eatsFoods = playerController.activeCattle.eatsFoods;
		int count = eatsFoods.Count;
		base.visibleColumns = Mathf.Min(count, MAX_COLUMNS);
		base.visibleRows = Mathf.CeilToInt((float)count / (float)base.visibleColumns);
		float sideStartPosition = GetSideStartPosition(base.visibleColumns);
		float num = 0f - GetSideStartPosition(base.visibleRows);
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < MAX_ROWS; i++)
		{
			for (int j = 0; j < MAX_COLUMNS; j++)
			{
				ContainedObjectsBuffer containedObjectsBuffer = eatsFoods[num2];
				if (i < base.visibleRows && j < base.visibleColumns && num3 < count)
				{
					if (containedObjectsBuffer.objectID != ObjectID.None)
					{
						itemSlots[num2].visibleSlotIndex = num3;
						if (autoPositionSlots)
						{
							itemSlots[num2].transform.localPosition = new Vector3(sideStartPosition + (float)j * spread, num - (float)i * spread, 0f);
						}
						itemSlots[num2].gameObject.SetActive(value: true);
						itemSlots[num2].UpdateSlot();
					}
					else
					{
						itemSlots[num2].gameObject.SetActive(value: false);
					}
					num3++;
				}
				else
				{
					itemSlots[num2].gameObject.SetActive(value: false);
				}
				num2++;
			}
		}
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}
}
