using UnityEngine;

public class DrifterOverviewDiet : AgentReferenceUIElement
{
	[SerializeField]
	private VitalType _vital;

	[SerializeField]
	private ChildBehaviourCache<InventoryPanelItemSlot> _itemSlotPrefab;

	[SerializeField]
	[Tooltip("The base size used for the slots other than the slot for the current day.\r\n NOTE: Previous Day Slot Size and Previous Day Slot Size Decrease are applied to all slots other than the first slot, which is the slot for the current day.")]
	private float _previousDaySlotSize = 42f;

	[SerializeField]
	[Tooltip("The amount by which the slots other than the slot for the current day are decreased.\r\n NOTE: Previous Day Slot Size and Previous Day Slot Size Decrease are applied to all slots other than the first slot, which is the slot for the current day.")]
	private float _previousDaySlotSizeDecrease = 2f;

	private Diet _diet;

	protected override void Subscribe(Agent agent)
	{
		if (agent.Vitals.TryReturnDiet(VitalType.Hunger, out _diet))
		{
			UpdateItemSlots();
		}
	}

	protected override void Unsubscribe(Agent agent)
	{
	}

	private void UpdateItemSlots()
	{
		_itemSlotPrefab.Reset();
		if (0 < _diet.ConsumedItems.Count)
		{
			_itemSlotPrefab.Get(active: true).Initialize(_diet.ReturnItemConsumedToday());
			for (int i = 1; i < _diet.ConsumedItems.Count; i++)
			{
				InventoryPanelItemSlot inventoryPanelItemSlot = _itemSlotPrefab.Get(active: true);
				inventoryPanelItemSlot.Initialize(_diet.ConsumedItems[i]);
				inventoryPanelItemSlot.SetSize(i, _previousDaySlotSize, _previousDaySlotSizeDecrease);
			}
		}
		_itemSlotPrefab.Trim();
	}
}
