using UnityEngine;
using UnityEngine.UI;

public class UIModContainer : MonoBehaviour
{
	public UIDroneItem droneHeadingItem;

	public UIUpgradeItem shipUpgradeHeadingItem;

	public UIUpgradeItem upgradeHeadingItem;

	public UIUpgradeItem craftHeadingItem;

	public UIModListSimple modList;

	private Image backgroundImage;

	private UIMultiObjectStateToggle multiObjectStateToggle;

	public IUIItem CurrentItem { get; private set; }

	private void Awake()
	{
		if (droneHeadingItem != null)
		{
			droneHeadingItem.gameObject.SetActive(false);
		}
		if (shipUpgradeHeadingItem != null)
		{
			shipUpgradeHeadingItem.gameObject.SetActive(false);
		}
		if (upgradeHeadingItem != null)
		{
			upgradeHeadingItem.gameObject.SetActive(false);
		}
		modList.gameObject.SetActive(false);
		backgroundImage = base.gameObject.GetComponent<Image>();
		multiObjectStateToggle = base.gameObject.GetComponent<UIMultiObjectStateToggle>();
	}

	private void Start()
	{
		if (droneHeadingItem != null)
		{
			droneHeadingItem.SetInactive();
		}
		multiObjectStateToggle.SetInactive();
		SetInactive();
	}

	private void OnDestroy()
	{
		backgroundImage = null;
		multiObjectStateToggle = null;
	}

	public void Show()
	{
		modList.Clear(false);
		modList.gameObject.SetActive(true);
		HideHeader();
	}

	public void Hide()
	{
		SetInactive();
		if (droneHeadingItem != null)
		{
			droneHeadingItem.gameObject.SetActive(false);
		}
		if (shipUpgradeHeadingItem != null)
		{
			shipUpgradeHeadingItem.gameObject.SetActive(false);
		}
		if (upgradeHeadingItem != null)
		{
			upgradeHeadingItem.gameObject.SetActive(false);
		}
		if (craftHeadingItem != null)
		{
			craftHeadingItem.gameObject.SetActive(false);
		}
		modList.gameObject.SetActive(false);
		droneHeadingItem.MarkEmpty(0);
	}

	public void SetActive()
	{
		if (droneHeadingItem != null)
		{
			droneHeadingItem.SetActive();
		}
		backgroundImage.color = ModificationUI.Instance.selectedBorderColor;
		multiObjectStateToggle.SetActive();
	}

	public void SetInactive()
	{
		backgroundImage.color = ModificationUI.Instance.deSelectedBorderColor;
		multiObjectStateToggle.SetInactive();
	}

	public void HideHeader()
	{
		if (droneHeadingItem != null)
		{
			droneHeadingItem.gameObject.SetActive(false);
		}
		if (shipUpgradeHeadingItem != null)
		{
			shipUpgradeHeadingItem.gameObject.SetActive(false);
		}
		if (upgradeHeadingItem != null)
		{
			upgradeHeadingItem.gameObject.SetActive(false);
		}
		if (craftHeadingItem != null)
		{
			craftHeadingItem.gameObject.SetActive(false);
		}
	}

	public void SetItem(IUIItem item, bool clearHighlight)
	{
		CurrentItem = item;
		if (item == null)
		{
			return;
		}
		if (item is UIDroneItem)
		{
			UIDroneItem uIDroneItem = (UIDroneItem)item;
			if (uIDroneItem.Drone != null)
			{
				if (droneHeadingItem != null && droneHeadingItem.gameObject != null)
				{
					droneHeadingItem.gameObject.SetActive(true);
				}
				droneHeadingItem.FillSlot(uIDroneItem.Drone);
				modList.AddCategory(modList.gameObject, "drone", "Drone");
				modList.TargetObject = uIDroneItem.Drone;
				foreach (IModification modification in ((IUIModItem)item).ModificationList)
				{
					modification.SetTarget(uIDroneItem.Drone);
					modList.AddBackendItem("drone", modification, false, item);
				}
				modList.AddCategory(modList.gameObject, "scrap", "Scrap");
				modList.AddBackendItem("scrap", new ScrapMod(ModificationsHelper.CalculateScrapValue((IInventoryItem)uIDroneItem.Drone)), true, item);
			}
			else if (droneHeadingItem != null && droneHeadingItem.gameObject != null)
			{
				droneHeadingItem.gameObject.SetActive(false);
			}
			return;
		}
		if (((IUIModItem)item).ModificationList != null)
		{
			string empty = string.Empty;
			bool flag = false;
			bool flag2 = false;
			IDrone drone = null;
			if (item.ParentItem is IDrone)
			{
				flag = true;
				flag2 = true;
				drone = (IDrone)item.ParentItem;
			}
			else if (item is UIModItem && ((UIModItem)item).OriginalUIItem is UIDroneItem)
			{
				flag = true;
				drone = ((UIDroneItem)((UIModItem)item).OriginalUIItem).Drone;
			}
			if (flag)
			{
				if (upgradeHeadingItem != null && upgradeHeadingItem.gameObject != null)
				{
					upgradeHeadingItem.gameObject.SetActive(true);
					upgradeHeadingItem.label.text = "Drone Upgrade: " + item.InventoryItem.Name;
					if (item.ParentItem != null)
					{
						upgradeHeadingItem.iconImage.enabled = true;
					}
					else
					{
						upgradeHeadingItem.iconImage.enabled = false;
					}
				}
				if (upgradeHeadingItem != null && upgradeHeadingItem is UIBreakableUpgradeHeaderItem)
				{
					UIBreakableUpgradeHeaderItem uIBreakableUpgradeHeaderItem = (UIBreakableUpgradeHeaderItem)upgradeHeadingItem;
					Color upgradeStatus = DroneManager.GetUpgradeStatus((BaseDroneUpgrade)item.InventoryItem, false);
					uIBreakableUpgradeHeaderItem.breakStats.MissionCountLabel.text = ((BaseDroneUpgrade)item.InventoryItem).NumMissions.ToString();
					uIBreakableUpgradeHeaderItem.breakStats.BreakProbabilityLabel.text = ((BaseDroneUpgrade)item.InventoryItem).BreakProbability.ToString("0.00") + "%";
					uIBreakableUpgradeHeaderItem.breakStats.DescriptionLabel.color = upgradeStatus;
					uIBreakableUpgradeHeaderItem.breakStats.MissionCountLabel.color = upgradeStatus;
					uIBreakableUpgradeHeaderItem.breakStats.BreakProbabilityLabel.color = upgradeStatus;
				}
				empty = string.Format("drone_{0}", drone.DroneNumber);
				string empty2 = string.Empty;
				if (flag2)
				{
					empty += item.InventoryItem.GroupKey;
					empty2 = string.Format("Drone {0} {1} Modifications", drone.DroneNumber, item.InventoryItem.Name);
				}
				else
				{
					empty2 = string.Format("Drone {0} Modifications", drone.DroneNumber);
				}
				modList.AddCategory(modList.gameObject, empty, empty2);
			}
			else
			{
				empty = ((item.InventoryItem == null) ? string.Format("upgrade") : string.Format("upgrade_{0}", item.InventoryItem.GroupKey));
				if (item.InventoryItem is BaseShipUpgrade)
				{
					modList.AddCategory(modList.gameObject, empty, string.Format("Ship Upgrade: {0}", item.InventoryItem.Name));
					if (shipUpgradeHeadingItem != null && shipUpgradeHeadingItem.gameObject != null)
					{
						shipUpgradeHeadingItem.gameObject.SetActive(true);
						shipUpgradeHeadingItem.label.text = item.InventoryItem.Name;
					}
					if (shipUpgradeHeadingItem != null && shipUpgradeHeadingItem is UIBreakableUpgradeHeaderItem)
					{
						UIBreakableUpgradeHeaderItem uIBreakableUpgradeHeaderItem2 = (UIBreakableUpgradeHeaderItem)shipUpgradeHeadingItem;
						if (!((BaseShipUpgrade)item.InventoryItem).IsPermanentUpgrade)
						{
							uIBreakableUpgradeHeaderItem2.breakStats.gameObject.SetActive(true);
							Color upgradeStatus2 = DroneManager.GetUpgradeStatus((BaseShipUpgrade)item.InventoryItem, false);
							uIBreakableUpgradeHeaderItem2.breakStats.MissionCountLabel.text = ((BaseShipUpgrade)item.InventoryItem).NumMissions.ToString();
							uIBreakableUpgradeHeaderItem2.breakStats.BreakProbabilityLabel.text = ((BaseShipUpgrade)item.InventoryItem).BreakProbability.ToString("0.00") + "%";
							uIBreakableUpgradeHeaderItem2.breakStats.DescriptionLabel.color = upgradeStatus2;
							uIBreakableUpgradeHeaderItem2.breakStats.MissionCountLabel.color = upgradeStatus2;
							uIBreakableUpgradeHeaderItem2.breakStats.BreakProbabilityLabel.color = upgradeStatus2;
						}
						else
						{
							uIBreakableUpgradeHeaderItem2.breakStats.gameObject.SetActive(false);
						}
					}
				}
				else if (item.InventoryItem != null)
				{
					modList.AddCategory(modList.gameObject, empty, string.Format("Drone Upgrade: {0}", item.InventoryItem.Name));
					if (upgradeHeadingItem != null && upgradeHeadingItem.gameObject != null)
					{
						upgradeHeadingItem.gameObject.SetActive(true);
						upgradeHeadingItem.label.text = "Upgrade: " + item.InventoryItem.Name;
						if (item.ParentItem != null)
						{
							upgradeHeadingItem.iconImage.enabled = true;
						}
						else
						{
							upgradeHeadingItem.iconImage.enabled = false;
						}
					}
					if (upgradeHeadingItem != null && upgradeHeadingItem is UIBreakableUpgradeHeaderItem)
					{
						UIBreakableUpgradeHeaderItem uIBreakableUpgradeHeaderItem3 = (UIBreakableUpgradeHeaderItem)upgradeHeadingItem;
						Color upgradeStatus3 = DroneManager.GetUpgradeStatus((BaseDroneUpgrade)item.InventoryItem, false);
						uIBreakableUpgradeHeaderItem3.breakStats.MissionCountLabel.text = ((BaseDroneUpgrade)item.InventoryItem).NumMissions.ToString();
						uIBreakableUpgradeHeaderItem3.breakStats.BreakProbabilityLabel.text = ((BaseDroneUpgrade)item.InventoryItem).BreakProbability.ToString("0.00") + "%";
						uIBreakableUpgradeHeaderItem3.breakStats.DescriptionLabel.color = upgradeStatus3;
						uIBreakableUpgradeHeaderItem3.breakStats.MissionCountLabel.color = upgradeStatus3;
						uIBreakableUpgradeHeaderItem3.breakStats.BreakProbabilityLabel.color = upgradeStatus3;
					}
				}
				else if (((IUIModItem)item).ModificationList[0] is CraftGathererMod || ((IUIModItem)item).ModificationList[0] is CraftGeneratorMod || ((IUIModItem)item).ModificationList[0] is CraftTowMod)
				{
					modList.AddCategory(modList.gameObject, empty, string.Format("Assemble"));
					if (craftHeadingItem != null && craftHeadingItem.gameObject != null)
					{
						craftHeadingItem.gameObject.SetActive(true);
						if (((IUIModItem)item).ModificationList[0] is CraftGathererMod)
						{
							craftHeadingItem.label.text = "Assemble: Gather";
						}
						else if (((IUIModItem)item).ModificationList[0] is CraftGeneratorMod)
						{
							craftHeadingItem.label.text = "Assemble: Generator";
						}
						else if (((IUIModItem)item).ModificationList[0] is CraftTowMod)
						{
							craftHeadingItem.label.text = "Assemble: Tow";
						}
					}
				}
			}
			if (!flag || flag2)
			{
				modList.TargetObject = item.InventoryItem;
			}
			foreach (IModification modification2 in ((IUIModItem)item).ModificationList)
			{
				if (!flag || flag2)
				{
					modification2.SetTarget(item.InventoryItem);
				}
				if (modification2 is ScrapMod)
				{
					if (ModificationUI.Instance.selectedInventoryItem != null)
					{
						ModificationUI.Instance.selectedInventoryItem.Dim();
						((ScrapMod)modification2).AffectedItem = ModificationUI.Instance.selectedInventoryItem;
					}
					modList.AddBackendItem(empty, modification2, true, item);
				}
				else
				{
					modList.AddBackendItem(empty, modification2, false, item);
				}
			}
			if (item is UIUpgradeItem && ((UIUpgradeItem)item).InventoryItem != null)
			{
				bool flag3 = true;
				if (item.InventoryItem is BaseShipUpgrade && ((BaseShipUpgrade)item.InventoryItem).IsPermanentUpgrade)
				{
					flag3 = false;
				}
				if (flag3)
				{
					modList.AddCategory(modList.gameObject, "scrap", "Scrap");
					modList.AddBackendItem("scrap", new ScrapMod(ModificationsHelper.CalculateScrapValue(item.InventoryItem)), true, item);
				}
			}
			return;
		}
		if (item.InventoryItem is BaseShipUpgrade)
		{
			if (shipUpgradeHeadingItem != null && shipUpgradeHeadingItem.gameObject != null)
			{
				shipUpgradeHeadingItem.gameObject.SetActive(true);
				shipUpgradeHeadingItem.label.text = item.InventoryItem.Name;
			}
			if (shipUpgradeHeadingItem != null && shipUpgradeHeadingItem is UIBreakableUpgradeHeaderItem)
			{
				UIBreakableUpgradeHeaderItem uIBreakableUpgradeHeaderItem4 = (UIBreakableUpgradeHeaderItem)shipUpgradeHeadingItem;
				if (!((BaseShipUpgrade)item.InventoryItem).IsPermanentUpgrade)
				{
					uIBreakableUpgradeHeaderItem4.breakStats.gameObject.SetActive(true);
					Color upgradeStatus4 = DroneManager.GetUpgradeStatus((BaseShipUpgrade)item.InventoryItem, false);
					uIBreakableUpgradeHeaderItem4.breakStats.MissionCountLabel.text = ((BaseShipUpgrade)item.InventoryItem).NumMissions.ToString();
					uIBreakableUpgradeHeaderItem4.breakStats.BreakProbabilityLabel.text = ((BaseShipUpgrade)item.InventoryItem).BreakProbability.ToString("0.00") + "%";
					uIBreakableUpgradeHeaderItem4.breakStats.DescriptionLabel.color = upgradeStatus4;
					uIBreakableUpgradeHeaderItem4.breakStats.MissionCountLabel.color = upgradeStatus4;
					uIBreakableUpgradeHeaderItem4.breakStats.BreakProbabilityLabel.color = upgradeStatus4;
				}
				else
				{
					uIBreakableUpgradeHeaderItem4.breakStats.gameObject.SetActive(false);
				}
			}
		}
		bool flag4 = true;
		if (item.InventoryItem is BaseShipUpgrade && ((BaseShipUpgrade)item.InventoryItem).IsPermanentUpgrade)
		{
			flag4 = false;
		}
		if (flag4)
		{
			modList.AddCategory(modList.gameObject, string.Format("scrap {0}", item.InventoryItem.GroupKey), "Scrap");
			modList.AddBackendItem(string.Format("scrap {0}", item.InventoryItem.GroupKey), new ScrapMod(ModificationsHelper.CalculateScrapValue(item.InventoryItem)), true, item);
		}
	}
}
