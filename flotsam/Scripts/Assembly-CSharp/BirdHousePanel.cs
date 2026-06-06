using UnityEngine;
using UnityEngine.UI;

public class BirdHousePanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private SelectableGroup _selectableGroup;

	[Header("Salvaging")]
	[SerializeField]
	private Toggle _itemExportToggle;

	[SerializeField]
	private ChildBehaviourCache<BirdHousePanelSalvageToggle> _salvageSlotPrefab;

	[Header("Food")]
	[SerializeField]
	private Toggle _foodRefillToggle;

	[SerializeField]
	private ChildBehaviourCache<RationedFoodSlot> _rationPrefab;

	[Header("Inhabitants")]
	[SerializeField]
	[Tooltip("Parent to attach bird entries to.")]
	private ChildBehaviourCache<BirdEntry> _birdEntryPrefab;

	private BirdHouse _birdHouse;

	public BuildablePanelElementId Id => BuildablePanelElementId.Birdhouse;

	private void OnEnable()
	{
		_itemExportToggle.onValueChanged.AddListener(ToggleItemExport);
		_foodRefillToggle.onValueChanged.AddListener(ToggleFoodRefill);
	}

	private void Update()
	{
		UpdatePanel();
	}

	private void OnDisable()
	{
		_itemExportToggle.onValueChanged.RemoveListener(ToggleItemExport);
		_foodRefillToggle.onValueChanged.RemoveListener(ToggleFoodRefill);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (buildable.TryReturnBuildableExtendable<BirdHouse>(out _birdHouse))
		{
			base.gameObject.SetActive(value: true);
			_rationPrefab.Reset();
			for (int i = 0; i < _birdHouse.BirdCapacity; i++)
			{
				_rationPrefab.Get(active: true).Initialize(_birdHouse.FoodSource);
			}
			_rationPrefab.Trim();
			UpdatePanel();
			_salvageSlotPrefab.Reset();
			ItemPropertiesGroup[] itemGroups = _birdHouse.ItemGroups;
			foreach (ItemPropertiesGroup itemPropertiesGroup in itemGroups)
			{
				_salvageSlotPrefab.Get(active: true).Initialize(itemPropertiesGroup);
			}
			_salvageSlotPrefab.Trim();
			_foodRefillToggle.SetIsOnWithoutNotify(_birdHouse.RefillFood);
			_itemExportToggle.SetIsOnWithoutNotify(_birdHouse.ExportItems);
			_selectableGroup.Initialize();
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}

	private void UpdatePanel()
	{
		for (int i = 0; i < _birdHouse.FoodRations.Length && i < _rationPrefab.Count; i++)
		{
			_rationPrefab[i].UpdatePortion(_birdHouse.FoodRations[i].Count);
		}
		_birdEntryPrefab.Reset();
		for (int j = 0; j < _birdHouse.BirdCapacity; j++)
		{
			_birdEntryPrefab.Get(active: true).Initialize((j < _birdHouse.Birds.Count) ? _birdHouse.Birds[j] : null);
		}
		_birdEntryPrefab.Trim();
	}

	private void ToggleFoodRefill(bool value)
	{
		if ((bool)_birdHouse)
		{
			_birdHouse.ToggleFoodRefilling(value);
		}
	}

	private void ToggleItemExport(bool value)
	{
		if ((bool)_birdHouse)
		{
			_birdHouse.EnableItemExport(value);
		}
	}
}
