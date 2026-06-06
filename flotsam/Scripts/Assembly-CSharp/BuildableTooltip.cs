using TMPro;
using UnityEngine;

public class BuildableTooltip : MonoBehaviour
{
	[Tooltip("Vertical offset for the tooltip to display it above the buttons, instead of on it.")]
	public float VerticalOffset = 30f;

	[Space]
	[SerializeField]
	[Tooltip("Prefab for the item slot.")]
	private ChildBehaviourCache<BuildableTooltipItemSlot> _itemSlotPrefab;

	[SerializeField]
	[Tooltip("Prefab for the mooring point slot.")]
	private BuildableTooltipMooringPointSlot _mooringPointSlot;

	[Space(15f)]
	[SerializeField]
	[Tooltip("Text component for the construction name.")]
	private TextMeshProUGUI _nameText;

	[SerializeField]
	[Tooltip("Text component for the construction description.")]
	private TextMeshProUGUI _descriptionText;

	[SerializeField]
	private TextField _footprint;

	[SerializeField]
	private IntField _beauty;

	[SerializeField]
	private IntField _energyRequirement;

	[SerializeField]
	private TextField _weight;

	[SerializeField]
	private GameObject _buildableInfoContainer;

	[SerializeField]
	private GameObject _constructionCostsContainer;

	private bool _tooltipActive;

	private IPlaceable _placeable;

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.UIStateChanged, OnUIStateChanged);
	}

	private void OnDisable()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateSlots);
		Community.PlayerCommunity.MooringPointsUpdatedEvent -= UpdateSlots;
		GameEventDispatcher.RemoveListener(GameEventType.UIStateChanged, OnUIStateChanged);
	}

	public void DisplayTooltip(IPlaceable placeable, bool upgradeResources = false)
	{
		_placeable = placeable;
		IPlaceable placeable2;
		if (!upgradeResources)
		{
			placeable2 = placeable;
		}
		else
		{
			IPlaceable upgrade = ((BuildableProperties)placeable).Upgrade;
			placeable2 = upgrade;
		}
		IPlaceable placeable3 = placeable2;
		if (placeable3.RequiresMooringPoint)
		{
			Community.PlayerCommunity.MooringPointsUpdatedEvent += UpdateSlots;
		}
		_nameText.text = placeable3.Name;
		_descriptionText.text = placeable3.GetDescription();
		if (placeable3 is PlaceableProperties placeableProperties)
		{
			_buildableInfoContainer.gameObject.SetActive(value: true);
			_footprint.SetText($"{placeableProperties.Width}x{placeableProperties.Depth}");
			_beauty.SetInt(placeableProperties.ReturnBuildableTooltipBeautyScore());
			if (placeableProperties.TryGetEnergyCost(out var energyCost))
			{
				_energyRequirement.SetFloat(energyCost);
			}
			else
			{
				_energyRequirement.gameObject.SetActive(value: false);
			}
			_weight.SetText($"{placeableProperties.GetWeightModeWeight()}/{Engine.TownAvailableTugCapacity}", Engine.CanTug(placeableProperties) ? TextField.States.Positive : TextField.States.Negative);
		}
		else
		{
			_buildableInfoContainer.gameObject.SetActive(value: false);
		}
		DisplayTooltip(upgradeResources);
	}

	private void DisplayTooltip(bool upgradeResources = false)
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(UpdateSlots);
		_tooltipActive = true;
		CreateSlots(_placeable as PlaceableProperties, upgradeResources);
	}

	public void HideTooltip()
	{
		_tooltipActive = false;
		GameManager.HighlightManager.ClearHighlights();
		base.gameObject.SetActive(value: false);
	}

	private void CreateSlots(PlaceableProperties placeableProperties, bool upgradeResources = false)
	{
		if (placeableProperties == null)
		{
			_constructionCostsContainer.SetActive(value: false);
			return;
		}
		_constructionCostsContainer.SetActive(value: true);
		_mooringPointSlot.gameObject.SetActive(placeableProperties.RequiresMooringPoint);
		_itemSlotPrefab.Reset();
		CountedItemProperty[] array = placeableProperties.ReturnTooltipRequiredResources(upgradeResources);
		foreach (CountedItemProperty slotItem in array)
		{
			_itemSlotPrefab.Get(active: true).Initialize(slotItem);
		}
		_itemSlotPrefab.Trim();
	}

	private void UpdateSlots()
	{
		if (_tooltipActive && _constructionCostsContainer.activeInHierarchy)
		{
			for (int i = 0; i < _itemSlotPrefab.Count; i++)
			{
				_itemSlotPrefab[i].UpdateSlot();
			}
		}
	}

	private void OnUIStateChanged(GameEvent gameEvent)
	{
		if (UIManager.State != UIState.Normal)
		{
			HideTooltip();
		}
	}
}
