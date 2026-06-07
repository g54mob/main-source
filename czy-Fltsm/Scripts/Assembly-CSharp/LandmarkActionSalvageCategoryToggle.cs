using UnityEngine;

public class LandmarkActionSalvageCategoryToggle : LandmarkActionToggle
{
	[Header("Category Toggle")]
	[SerializeField]
	private SalvagePanel _salvagePanel;

	private LandmarkActionSalvage _action;

	private LandmarkActionSalvage.Category _category;

	protected override void OnDisable()
	{
		base.OnDisable();
		_action?.CompositionUpdated.RemoveListener(OnCompositionUpdated);
	}

	public void Initialize(LandmarkActionSalvage action, LandmarkActionSalvage.Category category)
	{
		Initialize(category);
		_action = action;
		_action.CompositionUpdated.AddListener(OnCompositionUpdated);
		_category = category;
		base.isOn = category.CanBeSalvaged && category.IsToggled;
		OnCompositionUpdated();
	}

	protected override void OnValueChanged(bool value)
	{
		base.OnValueChanged(value);
		_action?.UpdateState();
	}

	private void OnCompositionUpdated()
	{
		UpdateSalvagePanel();
		if (_category.ReturnIsCompleted())
		{
			SetCompleted();
		}
	}

	private void UpdateSalvagePanel()
	{
		_salvagePanel.gameObject.SetActive(value: true);
		_salvagePanel.Enable(_action.Project);
		foreach (InventoryAuditor.CountedItem item in _category.ReturnCountedItems())
		{
			if (item.WasCounted)
			{
				int itemCount = item.ReturnCount(InventoryAuditor.CountType.All);
				_salvagePanel.AddItemSlot(item.ItemProperties, itemCount, _category.IsItemFilterToggled(item.ItemProperties), hideToggle: true);
			}
		}
	}
}
