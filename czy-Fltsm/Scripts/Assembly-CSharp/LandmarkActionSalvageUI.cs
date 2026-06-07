using UnityEngine;

[RequireComponent(typeof(SalvagePanel))]
public class LandmarkActionSalvageUI : LandmarkActionUI
{
	private SalvagePanel _salvagePanel;

	private LandmarkActionSalvage _action;

	public void Initialize(LandmarkActionSalvage action)
	{
		base.Initialize(action);
		_action = action;
		_action.CompositionUpdated.AddListener(UpdateSalvagePanel);
		UpdateSalvagePanel();
	}

	private void UpdateSalvagePanel()
	{
		if (_salvagePanel == null)
		{
			_salvagePanel = GetComponent<SalvagePanel>();
		}
		_salvagePanel.Enable(_action.Project);
		_salvagePanel.ItemSlotToggleEvent.AddListener(OnItemSlotToggle);
		foreach (InventoryAuditor.CountedItem item in _action.ReturnCountedSalvageableItems())
		{
			_salvagePanel.AddItemSlot(item.ItemProperties, item.ReturnCount(InventoryAuditor.CountType.All), _action.ReturnIsItemFilterToggled(item.ItemProperties));
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		_action.CompositionUpdated.RemoveListener(UpdateSalvagePanel);
		_salvagePanel.ItemSlotToggleEvent.RemoveListener(OnItemSlotToggle);
	}

	private void OnItemSlotToggle(ItemProperties itemProperties)
	{
		_action.ToggleItemFilter(itemProperties);
	}

	public override bool IsLandmarkActionUI(LandmarkAction landmarkAction)
	{
		return landmarkAction is LandmarkActionSalvage;
	}
}
