using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigInventorySlot : UIUpgradeSlot
{
	public Image selectedBorder;

	public Image cursorBorder;

	private IInventoryItem _inventoryItem;

	private bool _initialized;

	private Color itemShipUpgradeBroken = new Color(1f, 0.5f, 0.5f);

	public bool IsSelected
	{
		get
		{
			return selectedBorder.gameObject.activeInHierarchy;
		}
	}

	public bool IsCursorHere
	{
		get
		{
			return cursorBorder.gameObject.activeInHierarchy;
		}
	}

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			base.gameObject.SetActive(value);
		}
	}

	public IInventoryItem InventoryItem
	{
		get
		{
			return _inventoryItem;
		}
	}

	protected override void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	protected override void OnDestroy()
	{
		selectedBorder = null;
		cursorBorder = null;
		base.OnDestroy();
	}

	private void Initialize()
	{
		if (selectedBorder == null || cursorBorder == null || address == null)
		{
			Debug.LogError("BoardingConfigInventorySlot did not resolve all fields properly");
		}
		else
		{
			label.text = string.Empty;
		}
		_initialized = true;
	}

	public void SetInventoryItem(IInventoryItem inventoryItem)
	{
		if (inventoryItem == null)
		{
			_inventoryItem = null;
			label.text = "------";
			label.color = Color.blue;
			address.color = label.color;
			return;
		}
		_inventoryItem = inventoryItem;
		if (inventoryItem.GetType().BaseType == typeof(BaseDroneUpgrade))
		{
			label.text = DroneManager.GetDroneUpgradeText((BaseDroneUpgrade)inventoryItem);
			label.color = DroneManager.GetUpgradeStatus((BaseDroneUpgrade)inventoryItem, !IsCursorHere);
		}
		else
		{
			label.text = DroneManager.GetShipUpgradeText((BaseShipUpgrade)inventoryItem);
			label.color = DroneManager.GetUpgradeStatus((BaseShipUpgrade)_inventoryItem, !IsCursorHere);
		}
		address.color = label.color;
		IsVisible = true;
	}

	public void SetIsSelected(bool isSelected)
	{
		if (!_initialized)
		{
			Initialize();
		}
		selectedBorder.gameObject.SetActive(isSelected);
	}

	public void SetCursorHere(bool cursorIsHere)
	{
		if (!_initialized)
		{
			Initialize();
		}
		cursorBorder.gameObject.SetActive(cursorIsHere);
		Color color = Color.white;
		if (_inventoryItem != null)
		{
			color = ((!(_inventoryItem is BaseDroneUpgrade)) ? DroneManager.GetUpgradeStatus((BaseShipUpgrade)_inventoryItem, !cursorIsHere) : DroneManager.GetUpgradeStatus((BaseDroneUpgrade)_inventoryItem, !IsCursorHere));
		}
		if (cursorIsHere)
		{
			if (_inventoryItem != null)
			{
				string empty = string.Empty;
				if (_inventoryItem is BaseDroneUpgrade)
				{
					empty = BoardingConfigUi.Instance.helper.FindHelpText(((BaseDroneUpgrade)_inventoryItem).CommandValue);
					if (empty != string.Empty)
					{
						BoardingConfigUi.Instance.SetHintText(empty);
					}
				}
				else if (_inventoryItem is BaseShipUpgrade)
				{
					string text = BoardingConfigUi.Instance.helper.FindHelpText(((BaseShipUpgrade)_inventoryItem).CommandValue);
					if (text == string.Empty)
					{
						text = _inventoryItem.Description;
					}
					BoardingConfigShipUpgradeUi.Instance.tooltips.label.text = text;
				}
			}
			else
			{
				BoardingConfigUi.Instance.SetHintText(string.Empty);
				BoardingConfigShipUpgradeUi.Instance.tooltips.label.text = string.Empty;
			}
			label.color = color;
			address.color = color;
			RefreshBreakStats();
		}
		else
		{
			label.color = color;
			address.color = color;
		}
	}

	private void RefreshBreakStats()
	{
		if (_inventoryItem is BaseDroneUpgrade)
		{
			BaseDroneUpgrade baseDroneUpgrade = (BaseDroneUpgrade)_inventoryItem;
			BoardingConfigUi.Instance.breakStats.gameObject.SetActive(true);
			BoardingConfigUi.Instance.breakStats.MissionCountLabel.text = baseDroneUpgrade.NumMissions.ToString();
			BoardingConfigUi.Instance.breakStats.BreakProbabilityLabel.text = baseDroneUpgrade.BreakProbability.ToString("0.00") + "%";
			Color upgradeStatus = DroneManager.GetUpgradeStatus(baseDroneUpgrade, !IsCursorHere);
			BoardingConfigUi.Instance.breakStats.Border.color = upgradeStatus;
			BoardingConfigUi.Instance.breakStats.DescriptionLabel.color = upgradeStatus;
			BoardingConfigUi.Instance.breakStats.MissionCountLabel.color = upgradeStatus;
			BoardingConfigUi.Instance.breakStats.BreakProbabilityLabel.color = upgradeStatus;
		}
		else if (_inventoryItem is BaseShipUpgrade)
		{
			BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)_inventoryItem;
			if (!baseShipUpgrade.IsPermanentUpgrade)
			{
				BoardingConfigShipUpgradeUi.Instance.breakStats.gameObject.SetActive(true);
				BoardingConfigShipUpgradeUi.Instance.breakStats.MissionCountLabel.text = baseShipUpgrade.NumMissions.ToString();
				BoardingConfigShipUpgradeUi.Instance.breakStats.BreakProbabilityLabel.text = baseShipUpgrade.BreakProbability.ToString("0.00") + "%";
				Color upgradeStatus2 = DroneManager.GetUpgradeStatus(baseShipUpgrade, !IsCursorHere);
				BoardingConfigShipUpgradeUi.Instance.breakStats.Border.color = upgradeStatus2;
				BoardingConfigShipUpgradeUi.Instance.breakStats.DescriptionLabel.color = upgradeStatus2;
				BoardingConfigShipUpgradeUi.Instance.breakStats.MissionCountLabel.color = upgradeStatus2;
				BoardingConfigShipUpgradeUi.Instance.breakStats.BreakProbabilityLabel.color = upgradeStatus2;
			}
			else
			{
				BoardingConfigShipUpgradeUi.Instance.breakStats.gameObject.SetActive(false);
			}
		}
		else
		{
			BoardingConfigUi.Instance.breakStats.gameObject.SetActive(false);
			BoardingConfigShipUpgradeUi.Instance.breakStats.gameObject.SetActive(false);
		}
	}
}
