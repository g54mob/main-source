using System.Collections.Generic;
using UnityEngine;

public class Inventory : IInventory
{
	private int _scrap;

	private int guiInventoryCount;

	private int guiMaxInventorySpace;

	private int guiScrapValue = -1;

	private string _guiStatus = string.Empty;

	private string _guiScrap = string.Empty;

	private List<IInventoryItem> Items;

	private string groupKey = string.Empty;

	private bool _refreshed;

	public int InventoryCount
	{
		get
		{
			return Items.Count;
		}
	}

	public int Scrap
	{
		get
		{
			return _scrap;
		}
		set
		{
			_scrap = value;
			if (isDataGalaxyLevel)
			{
				GalaxySaveFile.Save(groupKey, "SCRAP", _scrap);
				return;
			}
			UniverseSaveFile.Save(groupKey, "SCRAP", _scrap);
			if (SystemOverlayUI.Instance != null)
			{
				SystemOverlayUI.Instance.SetScrap(_scrap);
			}
		}
	}

	public int TotalPropulsionFuel
	{
		get
		{
			return PropulsionFuelCharge + PropulsionFuelReserve;
		}
	}

	public int PropulsionFuelCharge
	{
		get
		{
			if (isDataGalaxyLevel)
			{
				return GalaxySaveFile.Get(groupKey, "F_PROP_C", 6);
			}
			return UniverseSaveFile.Get(groupKey, "F_PROP_C", 6);
		}
		private set
		{
			if (isDataGalaxyLevel)
			{
				GalaxySaveFile.Save(groupKey, "F_PROP_C", value);
				return;
			}
			UniverseSaveFile.Save(groupKey, "F_PROP_C", value);
			if (SystemOverlayUI.Instance != null)
			{
				SystemOverlayUI.Instance.SetFuelPropulsion(PropulsionFuelCharge, PropulsionFuelReserve);
			}
		}
	}

	public int PropulsionFuelReserve
	{
		get
		{
			if (isDataGalaxyLevel)
			{
				return GalaxySaveFile.Get(groupKey, "F_PROP_R", 0);
			}
			return UniverseSaveFile.Get(groupKey, "F_PROP_R", 0);
		}
		set
		{
			if (isDataGalaxyLevel)
			{
				GalaxySaveFile.Save(groupKey, "F_PROP_R", value);
				return;
			}
			UniverseSaveFile.Save(groupKey, "F_PROP_R", value);
			if (SystemOverlayUI.Instance != null)
			{
				SystemOverlayUI.Instance.SetFuelPropulsion(PropulsionFuelCharge, PropulsionFuelReserve);
			}
		}
	}

	public int JumpFuel
	{
		get
		{
			if (isDataGalaxyLevel)
			{
				return GalaxySaveFile.Get(groupKey, "F_JUMP", -1);
			}
			return UniverseSaveFile.Get(groupKey, "F_JUMP", -1);
		}
		set
		{
			if (isDataGalaxyLevel)
			{
				GalaxySaveFile.Save(groupKey, "F_JUMP", value);
				return;
			}
			UniverseSaveFile.Save(groupKey, "F_JUMP", value);
			if (SystemOverlayUI.Instance != null)
			{
				SystemOverlayUI.Instance.SetFuelJump(value);
			}
		}
	}

	public bool CanHaveScrap { get; set; }

	public int MaxInventorySpace { get; private set; }

	public string guiStatus
	{
		get
		{
			if (guiInventoryCount != InventoryCount || guiMaxInventorySpace != MaxInventorySpace)
			{
				_guiStatus = string.Format("{0} / {1}", InventoryCount, MaxInventorySpace);
				guiInventoryCount = InventoryCount;
				guiMaxInventorySpace = MaxInventorySpace;
			}
			return _guiStatus;
		}
	}

	public string guiScrap
	{
		get
		{
			if (guiScrapValue != Scrap)
			{
				_guiScrap = "Scrap: " + Scrap;
				guiScrapValue = Scrap;
			}
			return _guiScrap;
		}
	}

	public List<IInventoryItem> ItemsCopy { get; private set; }

	public bool isDataGalaxyLevel { get; private set; }

	public Inventory(int maxInventoryCount, string saveGroupKey, bool isDataGalaxyLevel)
	{
		MaxInventorySpace = maxInventoryCount;
		Items = new List<IInventoryItem>();
		CanHaveScrap = true;
		groupKey = saveGroupKey;
		this.isDataGalaxyLevel = isDataGalaxyLevel;
		ItemsCopy = new List<IInventoryItem>();
		_scrap = ((!isDataGalaxyLevel) ? UniverseSaveFile.Get(groupKey, "SCRAP", _scrap) : GalaxySaveFile.Get(groupKey, "SCRAP", _scrap));
	}

	public void AgeInventoryItems(int additionalDays)
	{
		AgeInventoryItems(additionalDays, false);
	}

	public void AgeInventoryItems(int additionalDays, bool force)
	{
		string empty = string.Empty;
		empty = ((!(GalaxyMapManager.Instance != null) || GalaxyMapManager.Instance.SelectedStarSystem == null) ? GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey : GalaxyMapManager.Instance.SelectedStarSystem.GroupKey);
		if (!force && GalaxySaveFile.Get(empty, "VIEWED", false))
		{
			return;
		}
		int count = Items.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)Items[num];
			if (baseShipUpgrade is BaseShipUpgrade)
			{
				BaseShipUpgrade baseShipUpgrade2 = baseShipUpgrade;
				if (baseShipUpgrade2 is LongRangeScannerUpgrade)
				{
					baseShipUpgrade2.NumMissions++;
					bool flag = false;
					if (baseShipUpgrade2.BreakProbability > 15f)
					{
						Debug.Log(string.Format("Ship Upgrade used, and has a high enough probability of breaking ({0}%) testing to see if broke: {1}", baseShipUpgrade2.BreakProbability, baseShipUpgrade.Name));
						if (Random.Range(0f, 100f) < baseShipUpgrade2.BreakProbability)
						{
							baseShipUpgrade2.Break();
							flag = true;
						}
					}
					else
					{
						Debug.Log(string.Format("Ship Upgrade used but has a low probability of breaking ({0}%) so NOT testing to see if broke: {1}", baseShipUpgrade2.BreakProbability, baseShipUpgrade.Name));
					}
					if (!flag)
					{
						float breakProbability = baseShipUpgrade2.BreakProbability;
						float num2 = Random.Range(3f, 6f);
						float num3 = baseShipUpgrade2.UpgradeBreakFactor * num2;
						if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery)
						{
							num3 = (GameSaveFile.Get("NC", false) ? (num3 * 0.75f) : (num3 * 0.5f));
						}
						switch (GameSaveFile.Get("DIFF_UPG", 0))
						{
						case 1:
							num3 *= 0.5f;
							break;
						case 2:
							num3 *= 1.5f;
							break;
						}
						baseShipUpgrade2.BreakProbability += num3;
						if (breakProbability < 15f && baseShipUpgrade2.BreakProbability >= 15f)
						{
							DialogUI.Instance.ShowDialog("Upgrade Damaged:", "Long Range Scanner is deteriorating.");
						}
						else if (breakProbability < 25f && baseShipUpgrade2.BreakProbability >= 25f)
						{
							DialogUI.Instance.ShowDialog("Upgrade Damaged:", "Long Range Scanner is deteriorating.");
						}
						Debug.Log(string.Format("Ship Upgrade's break probability has been increased to: {0}% - {1}", baseShipUpgrade2.BreakProbability, baseShipUpgrade.Name));
					}
					if (GlobalSettings.GameState.ThePlayer.MyShip != null && GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory != null && baseShipUpgrade2 != null)
					{
						int slotIndex = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.GetSlotIndex(baseShipUpgrade);
						baseShipUpgrade2.SaveData("SHIP", slotIndex);
						baseShipUpgrade2.UsedThisMission = false;
						if (flag)
						{
							Mothership.Instance.ExternalUninstallScanner();
							SlotInfo slotByUpgrade = GlobalSettings.GameState.ThePlayer.MyShip.GetSlotByUpgrade(baseShipUpgrade);
							if (slotByUpgrade != null)
							{
								slotByUpgrade.UnInstallUpgrade();
								UniverseSaveFile.ClearGroup(baseShipUpgrade.GroupKey);
							}
							else
							{
								GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.RemoveInventoryItem(baseShipUpgrade);
							}
							GlobalSettings.GameState.ThePlayer.AddToInventory(baseShipUpgrade);
							slotIndex = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.GetSlotIndex(baseShipUpgrade);
							baseShipUpgrade2.SaveData("PLAYER", slotIndex);
							baseShipUpgrade2.UsedThisMission = false;
							DialogUI.Instance.ShowDialog("Upgrade nonfunctional:", "Long Range Scanner has ceased to function.");
						}
					}
				}
			}
		}
	}

	public void AddInventoryItem(IInventoryItem item)
	{
		AddInventoryItem(item, null);
	}

	public void AddInventoryItem(IInventoryItem item, SlotInfo slot)
	{
		if (item is ExpandedInventoryItem)
		{
			item = (item as ExpandedInventoryItem).RealItem;
		}
		if (item == null)
		{
			return;
		}
		Items.Add(item);
		switch (item.InventoryType)
		{
		case InventoryTypeEnum.DroneUpgrade:
		{
			BaseDroneUpgrade baseDroneUpgrade = (BaseDroneUpgrade)item;
			UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "TYPE", baseDroneUpgrade.Definition.Type);
			if (slot == null)
			{
				UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "SLOT", Items.Count - 1);
			}
			else
			{
				UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "SLOT", slot.SlotNumber);
			}
			UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "INV_MISSIONS", baseDroneUpgrade.NumMissions);
			UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "INV_ERROR_MISSIONS", baseDroneUpgrade.ErrorMissions);
			UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "INV_BREAK_TIME", baseDroneUpgrade.BreakTime);
			UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "INV_ERROR_TIME", baseDroneUpgrade.ErrorTime);
			UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "INV_TIME_POST_ERROR_MISSION", baseDroneUpgrade.TimeInMissionPostErrorMision);
			UniverseSaveFile.Save(baseDroneUpgrade.GroupKey, groupKey, "INV_BREAK_PROB", baseDroneUpgrade.BreakProbability);
			break;
		}
		case InventoryTypeEnum.ShipUpgrade:
		{
			BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)item;
			if (!isDataGalaxyLevel)
			{
				UniverseSaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "TYPE", baseShipUpgrade.UpgradeType);
				if (slot == null)
				{
					UniverseSaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "SLOT", Items.Count - 1);
				}
				else
				{
					UniverseSaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "SLOT", slot.SlotNumber);
				}
				UniverseSaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "INV_MISSIONS", baseShipUpgrade.NumMissions);
				UniverseSaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "INV_BREAK_PROB", baseShipUpgrade.BreakProbability);
				if (baseShipUpgrade is IBreakable)
				{
					UniverseSaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "STATE", ((IBreakable)baseShipUpgrade).BrokenState);
				}
			}
			else
			{
				GalaxySaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "TYPE", baseShipUpgrade.UpgradeType);
				if (slot == null)
				{
					GalaxySaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "SLOT", Items.Count - 1);
				}
				else
				{
					GalaxySaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "SLOT", slot.SlotNumber);
				}
				GalaxySaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "INV_MISSIONS", baseShipUpgrade.NumMissions);
				GalaxySaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "INV_BREAK_PROB", baseShipUpgrade.BreakProbability);
				if (baseShipUpgrade is IBreakable)
				{
					GalaxySaveFile.Save(baseShipUpgrade.GroupKey, groupKey, "STATE", ((IBreakable)baseShipUpgrade).BrokenState);
				}
			}
			break;
		}
		default:
			Debug.LogWarning(string.Format("Inventory.AddInventoryItem doesn't support the '{0}' InventoryType in the persistant data.", item.InventoryType));
			break;
		}
		UpdateItemCopy();
	}

	public void AddUniqueInventoryItem(IInventoryItem item)
	{
		if (!Items.Contains(item))
		{
			AddInventoryItem(item);
		}
	}

	public void InsertItem(IInventoryItem item, int idx)
	{
		if (item is ExpandedInventoryItem)
		{
			item = (item as ExpandedInventoryItem).RealItem;
		}
		Items.Insert(idx, item);
		switch (item.InventoryType)
		{
		case InventoryTypeEnum.DroneUpgrade:
		{
			BaseDroneUpgrade baseDroneUpgrade = (BaseDroneUpgrade)item;
			baseDroneUpgrade.SaveData(groupKey, Items.Count - 1);
			break;
		}
		case InventoryTypeEnum.ShipUpgrade:
		{
			BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)item;
			baseShipUpgrade.SaveData(groupKey, Items.Count - 1);
			break;
		}
		default:
			Debug.LogWarning(string.Format("Inventory.InsertItem doesn't support the '{0}' InventoryType in the persistant data.", item.InventoryType));
			break;
		}
		UpdateItemCopy();
	}

	public void RemoveInventoryItem(IInventoryItem item)
	{
		if (item is ExpandedInventoryItem)
		{
			Debug.LogWarning("Trying to remove an 'expanded' inventory item?" + item.Name);
		}
		else
		{
			if (!Items.Contains(item))
			{
				return;
			}
			Items.Remove(item);
			switch (item.InventoryType)
			{
			case InventoryTypeEnum.DroneUpgrade:
			{
				BaseDroneUpgrade baseDroneUpgrade = (BaseDroneUpgrade)item;
				if (isDataGalaxyLevel)
				{
					GalaxySaveFile.ClearGroup(baseDroneUpgrade.GroupKey, groupKey);
				}
				else
				{
					UniverseSaveFile.ClearGroup(baseDroneUpgrade.GroupKey, groupKey);
				}
				break;
			}
			case InventoryTypeEnum.ShipUpgrade:
			{
				BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)item;
				if (isDataGalaxyLevel)
				{
					GalaxySaveFile.ClearGroup(baseShipUpgrade.GroupKey, groupKey);
				}
				else if (!baseShipUpgrade.IsPermanentUpgrade)
				{
					UniverseSaveFile.ClearGroup(baseShipUpgrade.GroupKey, groupKey);
				}
				else
				{
					UniverseSaveFile.ClearGroup(baseShipUpgrade.GroupKey, "SHIP");
				}
				break;
			}
			default:
				Debug.LogWarning(string.Format("Inventory.RemoveInventoryItem doesn't support the '{0}' InventoryType in the persistant data.", item.InventoryType));
				break;
			}
			UpdateItemCopy();
			if (Items.Count <= 0)
			{
				return;
			}
			UniverseSaveFile.BeginBatch();
			int count = Items.Count;
			for (int i = 0; i < count; i++)
			{
				IInventoryItem inventoryItem = Items[i];
				switch (inventoryItem.InventoryType)
				{
				case InventoryTypeEnum.DroneUpgrade:
				{
					BaseDroneUpgrade baseDroneUpgrade2 = (BaseDroneUpgrade)inventoryItem;
					baseDroneUpgrade2.SaveData(groupKey, i);
					break;
				}
				case InventoryTypeEnum.ShipUpgrade:
				{
					BaseShipUpgrade baseShipUpgrade2 = (BaseShipUpgrade)inventoryItem;
					if (!baseShipUpgrade2.IsPermanentUpgrade)
					{
						baseShipUpgrade2.SaveData(groupKey, i);
					}
					else
					{
						baseShipUpgrade2.SaveData("SHIP", i);
					}
					break;
				}
				}
			}
			UniverseSaveFile.EndBatch();
		}
	}

	public bool SwapInventoryItem(IInventoryItem otherItem, IInventoryItem thisItem, Inventory otherInventory)
	{
		if (otherItem.SellValue >= thisItem.SellValue)
		{
			int num = 0;
			foreach (IInventoryItem item in otherInventory.Items)
			{
				if (item == otherItem)
				{
					break;
				}
				num++;
			}
			int num2 = 0;
			foreach (IInventoryItem item2 in Items)
			{
				if (item2 == thisItem)
				{
					break;
				}
				num2++;
			}
			InsertItem(otherItem, num2);
			otherInventory.InsertItem(thisItem, num);
			RemoveInventoryItem(thisItem);
			otherInventory.RemoveInventoryItem(otherItem);
			UpdateItemCopy();
			return true;
		}
		return false;
	}

	public void RechargePropulsionFuel()
	{
		PropulsionFuelCharge = GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax;
	}

	public void DrainPropulsionFuel(int units)
	{
		int num = units;
		int num2 = 0;
		if (PropulsionFuelCharge < num)
		{
			num2 = num - PropulsionFuelCharge;
			num = PropulsionFuelCharge;
		}
		PropulsionFuelCharge -= num;
		PropulsionFuelReserve -= num2;
	}

	public void AddSpecificPropulsionChargeFuel(int units)
	{
		PropulsionFuelCharge = units;
	}

	public void AddSpecificPropulsionReserveFuel(int units)
	{
		PropulsionFuelReserve = units;
	}

	public void ClearAndAddPropulsionFuel(int units)
	{
		PropulsionFuelCharge = 0;
		PropulsionFuelReserve = 0;
		int num = units;
		int propulsionFuelReserve = 0;
		if (num > 6)
		{
			propulsionFuelReserve = num - 6;
			num = 6;
		}
		PropulsionFuelReserve = propulsionFuelReserve;
		PropulsionFuelCharge = num;
	}

	public void AddReservePropulsionFuel(int units)
	{
		PropulsionFuelReserve += units;
	}

	public void SubtractReservePropulsionFuel(int units)
	{
		PropulsionFuelReserve -= units;
		if (PropulsionFuelReserve < 0)
		{
			PropulsionFuelReserve = 0;
		}
	}

	private void UpdateItemCopy()
	{
		if (ItemsCopy == null)
		{
			ItemsCopy = new List<IInventoryItem>();
		}
		else
		{
			ItemsCopy.Clear();
		}
		if (Items.Count > 0)
		{
			IInventoryItem[] array = new IInventoryItem[Items.Count];
			Items.CopyTo(array);
			ItemsCopy.AddRange(array);
		}
		EventManager.Instance.Publish(GeneralEventType.InventoryChange);
	}

	public void InitialRefresh()
	{
		if (!_refreshed)
		{
			UpdateItemCopy();
			_refreshed = true;
		}
	}

	public int GetSlotIndex(IInventoryItem item)
	{
		int count = Items.Count;
		for (int i = 0; i < count; i++)
		{
			if (Items[i] == item)
			{
				return i;
			}
		}
		return -1;
	}
}
