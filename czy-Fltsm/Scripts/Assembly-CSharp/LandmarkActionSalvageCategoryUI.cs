using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkActionSalvageCategoryUI : LandmarkActionSalvageCategoryUIBase
{
	[SerializeField]
	private TextMeshProUGUI _descriptionText;

	[SerializeField]
	private GameObject _moraleEffect;

	[SerializeField]
	private SalvagePanel _salvagePanel;

	[SerializeField]
	private GameObject _overlay;

	[SerializeField]
	private Button _unlockButton;

	[SerializeField]
	private TextMeshProUGUI _unlockButtonText;

	[SerializeField]
	private Image _completedIcon;

	private LandmarkActionSalvage _action;

	private LandmarkActionSalvage.Category _category;

	public ItemProperties.Event ItemSlotToggleEvent => _salvagePanel.ItemSlotToggleEvent;

	private void OnEnable()
	{
		OnCompositionUpdated();
	}

	private void OnDisable()
	{
		_action.CompositionUpdated.RemoveListener(OnCompositionUpdated);
		if ((bool)_salvagePanel && _salvagePanel.gameObject.activeSelf)
		{
			_salvagePanel.ItemSlotToggleEvent.RemoveListener(OnItemSlotToggle);
		}
	}

	public override void Initialize(LandmarkActionSalvage action, LandmarkActionSalvage.Category category)
	{
		_action = action;
		_action.CompositionUpdated.AddListener(OnCompositionUpdated);
		_category = category;
		if (_category.CategoryAsset == null)
		{
			_descriptionText.text = "No Category assigned!";
			_unlockButton.gameObject.SetActive(value: false);
		}
		else
		{
			_descriptionText.text = _category.CategoryAsset.Description;
			if (_category.TryReturnRequiredItemCost(out var cost))
			{
				_unlockButtonText.text = cost.ToString();
				_unlockButton.gameObject.SetActive(value: true);
			}
			else
			{
				_unlockButton.gameObject.SetActive(value: false);
			}
		}
		OnCompositionUpdated();
		_moraleEffect.SetActive(value: false);
		base.gameObject.SetActive(value: true);
	}

	private void OnCompositionUpdated()
	{
		bool isCompleted = _category.ReturnIsCompleted();
		UpdateSalvagePanel(isCompleted);
		UpdateState(isCompleted);
	}

	private void UpdateSalvagePanel(bool isCompleted)
	{
		if (isCompleted)
		{
			_salvagePanel.gameObject.SetActive(value: false);
			return;
		}
		_salvagePanel.gameObject.SetActive(value: true);
		_salvagePanel.Enable(_action.Project);
		_salvagePanel.ItemSlotToggleEvent.AddListener(OnItemSlotToggle);
		foreach (InventoryAuditor.CountedItem item in _category.ReturnCountedItems())
		{
			int num = item.ReturnCount(InventoryAuditor.CountType.All);
			if (num != 0)
			{
				_salvagePanel.AddItemSlot(item.ItemProperties, num, _category.IsItemFilterToggled(item.ItemProperties));
			}
		}
	}

	private void OnItemSlotToggle(ItemProperties itemProperties)
	{
		_category.ToggleItemFilter(itemProperties);
	}

	private void UpdateState(bool isCompleted)
	{
		_unlockButton.onClick.RemoveAllListeners();
		if (_category.Unlocked)
		{
			_overlay.SetActive(value: false);
			_unlockButton.gameObject.SetActive(value: false);
		}
		else
		{
			_overlay.SetActive(value: true);
			_unlockButton.gameObject.SetActive(value: true);
			_unlockButton.onClick.AddListener(OnSalvageButtonClick);
		}
		_completedIcon.gameObject.SetActive(isCompleted);
	}

	private void OnSalvageButtonClick()
	{
		if (!_category.TryReturnRequiredItemCost(out var cost) || !Community.PlayerCommunity.Inventory.TryReserveItems(_category.CategoryAsset.RequiredItem.ItemProperties, cost, out var reservedItems))
		{
			return;
		}
		foreach (Item item in reservedItems)
		{
			item.TakeFromInventory();
		}
		_category.Unlocked = true;
		UpdateState(_category.ReturnIsCompleted());
	}
}
