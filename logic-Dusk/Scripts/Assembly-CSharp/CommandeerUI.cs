using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandeerUI : MonoBehaviour
{
	public static CommandeerUI Instance;

	public Text warningLabel;

	public UIShipPanel yourShipPanel;

	public UIShipPanel newShipPanel;

	public Color changePositiveColor = Color.green;

	public Color changeNeutralColor = Color.gray;

	public Color changeNegativeColor = Color.red;

	public Color focusedButtonColor = Color.blue;

	public Color focusedTextColor = Color.white;

	public Color notFocusedButtonColor = Color.white;

	public Color notFocusedTextColor = Color.blue;

	private bool firstUpdate = true;

	private void Awake()
	{
		Instance = this;
		if (warningLabel != null)
		{
			warningLabel.enabled = false;
		}
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (firstUpdate)
		{
			firstUpdate = false;
		}
		else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			CommandeerButtonPressed();
		}
	}

	public void Show()
	{
		base.gameObject.SetActive(true);
		yourShipPanel.Initialze();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		BaseShipUpgrade baseShipUpgrade = null;
		List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
		foreach (IInventoryItem item in itemsCopy)
		{
			if (item == null)
			{
				continue;
			}
			if (item is BaseShipUpgrade)
			{
				BaseShipUpgrade baseShipUpgrade2 = (BaseShipUpgrade)item;
				if (baseShipUpgrade2 != null && baseShipUpgrade2.IsPermanentUpgrade)
				{
					baseShipUpgrade = baseShipUpgrade2;
					num3++;
				}
				else
				{
					yourShipPanel.slotList.AddSlot(baseShipUpgrade2, false);
					num2++;
				}
			}
			else
			{
				num++;
			}
		}
		if (num2 < GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots - num3)
		{
			for (int i = num2; i < GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots - num3; i++)
			{
				yourShipPanel.slotList.AddSlot(null, false);
			}
		}
		if (GlobalSettings.GameState.ThePlayer.MyShip.slotList != null)
		{
			int count = GlobalSettings.GameState.ThePlayer.MyShip.slotList.Count;
			for (int j = 0; j < count; j++)
			{
				yourShipPanel.slotList.UpdateSlotStatus(GlobalSettings.GameState.ThePlayer.MyShip.slotList[j]);
			}
		}
		if (baseShipUpgrade != null)
		{
			yourShipPanel.slotList.AddSlot(baseShipUpgrade, true);
		}
		yourShipPanel.shipNameLabel.text = GlobalSettings.GameState.ThePlayer.MyShip.Name;
		int num4 = 0;
		int num5 = 0;
		foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
		{
			if (drone != null)
			{
				if (drone.DroneNumber <= 4)
				{
					num4++;
				}
				else
				{
					num5++;
				}
			}
		}
		yourShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.FleetDrone, 4, num4, -1);
		yourShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.ReserveDrone, 3, num5, -1);
		yourShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.DroneUpgrades, 21, num, -1);
		yourShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.ShipUpgrades, GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots, num2, -1);
		yourShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.Scrap, GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax, GlobalSettings.GameState.ThePlayer.Inventory.Scrap, -1);
		yourShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.PFuelReserve, GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax, GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge, -1);
		string empty = string.Empty;
		empty = ((GlobalSettings.GameState.ThePlayer.MyShip.Definition.Value == null) ? GlobalSettings.GameState.ThePlayer.MyShip.Definition.Key.imageFileName : GlobalSettings.GameState.ThePlayer.MyShip.Definition.Value.imageFileName);
		if (!string.IsNullOrEmpty(empty))
		{
			Texture2D texture2D = ResourceManager.LoadAsset<Texture2D>("UI/shipProfiles/" + empty);
			if (texture2D != null)
			{
				yourShipPanel.shipImage.texture = texture2D;
			}
		}
		BaseShipUpgrade baseShipUpgrade3 = null;
		newShipPanel.Initialze();
		List<ShipUpgradeSubsystemObject> list = new List<ShipUpgradeSubsystemObject>();
		for (int k = 0; k <= 1; k++)
		{
			foreach (ShipUpgradeSubsystemObject upgradeSubSystem in DungeonManager.Instance.UpgradeSubSystems)
			{
				if (!(upgradeSubSystem != null) || list.Contains(upgradeSubSystem))
				{
					continue;
				}
				if (k == 0 && upgradeSubSystem.InstalledShipObject != null && upgradeSubSystem.InstalledShipObject.ThisUpgrade != null)
				{
					if (upgradeSubSystem.InstalledShipObject.ThisUpgrade.IsPermanentUpgrade)
					{
						baseShipUpgrade3 = upgradeSubSystem.InstalledShipObject.ThisUpgrade;
						continue;
					}
					newShipPanel.slotList.AddSlot(upgradeSubSystem.InstalledShipObject.ThisUpgrade, false);
					list.Add(upgradeSubSystem);
				}
				else if (k == 1 && (upgradeSubSystem.InstalledShipObject == null || upgradeSubSystem.InstalledShipObject.ThisUpgrade == null))
				{
					newShipPanel.slotList.AddSlot(null, false);
					list.Add(upgradeSubSystem);
				}
			}
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.slotList != null)
		{
			int count2 = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.slotList.Count;
			for (int l = 0; l < count2; l++)
			{
				newShipPanel.slotList.UpdateSlotStatus(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.slotList[l]);
			}
		}
		if (baseShipUpgrade3 != null)
		{
			newShipPanel.slotList.AddSlot(baseShipUpgrade3, true);
		}
		newShipPanel.shipNameLabel.text = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Name;
		newShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.FleetDrone, 4, -1, 4);
		newShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.ReserveDrone, 3, -1, 3);
		newShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.DroneUpgrades, 21, -1, 21);
		newShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.ShipUpgrades, newShipPanel.slotList.Count, -1, GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots);
		newShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.Scrap, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ScrapMax, -1, GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax);
		newShipPanel.shipHold.SetValue(UIShipHold.ShipPropertyEnum.PFuelReserve, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.PFuelMax, -1, GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax);
		empty = string.Empty;
		empty = ((GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value == null) ? GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.imageFileName : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value.imageFileName);
		if (!string.IsNullOrEmpty(empty))
		{
			Texture2D texture2D2 = ResourceManager.LoadAsset<Texture2D>("UI/shipProfiles/" + empty);
			if (texture2D2 != null)
			{
				newShipPanel.shipImage.texture = texture2D2;
			}
		}
		string text = string.Empty;
		if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap > GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ScrapMax)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text += ", ";
			}
			text += "scrap";
		}
		if (GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge > GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.PFuelMax)
		{
			if (!string.IsNullOrEmpty(text))
			{
				text += ", ";
			}
			text += "charge propulsion";
		}
		if (!string.IsNullOrEmpty(text))
		{
			warningLabel.text = string.Format("Warning: You have more <color={0}>{2}</color> than <color={1}>{3}</color> supports.\r\nSome will need to be scrapped / jettisoned to comandeer.", "#FFF000", "#8ed0ff", text, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Name);
			warningLabel.enabled = true;
		}
		else
		{
			warningLabel.enabled = false;
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(false);
	}

	private void CancelButtonPressed()
	{
		GameplayManager.Instance.WindowState = GameWindowStates.None;
		DungeonManager.Instance.DisableAllInputForAMoment();
		ConsoleWindow3.SendConsoleResponse("Commandeering canceled", ConsoleMessageType.Info);
		Hide();
	}

	private void CommandeerButtonPressed()
	{
		GameplayManager.Instance.WindowState = GameWindowStates.None;
		DungeonManager.Instance.CommandeerCurrentDerelict();
		DungeonManager.Instance.DisableAllInputForAMoment();
		ConsoleWindow3.SendConsoleResponse("Commandeering...", ConsoleMessageType.Info);
		Hide();
	}
}
