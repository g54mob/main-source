using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class FiltersUI : ItemSlotsUIContainer
{
	private EntityMonoBehaviour filteringBuilding;

	public override int MAX_ROWS { get; } = 1;

	public override int MAX_COLUMNS { get; } = 1;

	public virtual bool centerLayout => false;

	public override void ShowContainerUI()
	{
		categoryWindowStartSlotIndex = Manager.ui.GetCategoryWindowInfoStartIndex();
		base.ShowContainerUI();
		filteringBuilding = Manager.main.player.GetActiveFilteringBuilding() as EntityMonoBehaviour;
		ObjectFilteringCD value = default(ObjectFilteringCD);
		if (filteringBuilding != null)
		{
			EntityUtility.TryGetComponentData<ObjectFilteringCD>(filteringBuilding.entity, filteringBuilding.world, out value);
		}
		int num = 1;
		base.visibleColumns = Mathf.Min(num, MAX_COLUMNS);
		base.visibleRows = Mathf.CeilToInt((float)num / (float)base.visibleColumns);
		float sideStartPosition = GetSideStartPosition(centerLayout ? base.visibleColumns : MAX_COLUMNS);
		float num2 = 0.5625f + (0f - GetSideStartPosition(centerLayout ? base.visibleRows : MAX_ROWS));
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < MAX_ROWS; i++)
		{
			for (int j = 0; j < MAX_COLUMNS; j++)
			{
				if (num3 >= itemSlots.Count)
				{
					break;
				}
				if (i < base.visibleRows && j < base.visibleColumns && num4 < num)
				{
					itemSlots[num3].visibleSlotIndex = num4;
					if (autoPositionSlots)
					{
						itemSlots[num3].transform.localPosition = new Vector3(sideStartPosition + (float)j * spread, num2 - (float)i * spread, 0f);
					}
					itemSlots[num3].gameObject.SetActive(value: true);
					itemSlots[num3].UpdateSlot();
					num4++;
				}
				else
				{
					itemSlots[num3].gameObject.SetActive(value: false);
				}
				num3++;
			}
		}
	}

	private float GetSideStartPosition(int size)
	{
		return (0f - (float)(size - 1) / 2f) * spread;
	}

	public void ToggleFilterPicking()
	{
		Manager.ui.mouse.ToggleFilterPickingMouseMode();
	}

	public void ClearFilter()
	{
		EntityMonoBehaviour entityMonoBehaviour = Manager.main.player?.GetActiveFilteringBuilding() as EntityMonoBehaviour;
		if (entityMonoBehaviour != null)
		{
			Manager.main.player.QueueInputAction(new UIInputActionData
			{
				action = UIInputAction.InventoryChange,
				inventoryChangeData = Create.AddFilter(entityMonoBehaviour.entity, ObjectID.None, 0)
			});
			AudioManager.SfxUI(SfxID.ui_clear_filter_1_01, 1f, reuse: true, 0.14f, 0.02f, playOnGamepad: false, gamepadSpeakerOutputTypeIsSpeaker: true, 0.04f);
		}
	}

	public override UIelement GetClosestUIElement(Vector3 worldPosition)
	{
		List<UIelement> list = new List<UIelement>(base.totalVisibleSlots + 1);
		for (int i = 0; i < base.totalVisibleSlots; i++)
		{
			int index = VisibleSlotIndexToInternalSlotIndex(i);
			if (itemSlots[index].isShowing && itemSlots[index].isVisibleOnScreen)
			{
				list.Add(itemSlots[index]);
			}
		}
		UIelement result = null;
		float num = 2.1474836E+09f;
		foreach (UIelement item in list)
		{
			float sqrMagnitude = (worldPosition - item.transform.position).sqrMagnitude;
			if (sqrMagnitude < num)
			{
				num = sqrMagnitude;
				result = item;
			}
		}
		return result;
	}
}
