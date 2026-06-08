using System;
using System.Collections.Generic;
using System.Linq;

public class LocalPlayer
{
	private int _daysAlive;

	public Inventory Inventory { get; set; }

	public DungeonInfo MyShip { get; set; }

	public StarSystemInfo CurrentStarSystem { get; set; }

	public DungeonInfo CurrentDockedDungeon { get; set; }

	public DungeonConfigurationManager.DungeonHelper.DungeonProperty CurrentDungeonProperty { get; set; }

	public int RationsNeededForClosestUnvisitedDungeon { get; set; }

	public List<IDrone> Drones { get; set; }

	public List<IDrone> DronesLeftBehind { get; set; }

	public List<BaseShipUpgrade> UnreportedBrokenUpgrades { get; private set; }

	public int DaysAlive
	{
		get
		{
			return _daysAlive;
		}
		private set
		{
			_daysAlive = value;
			UniverseSaveFile.Save("PLAYER", "DAYS", _daysAlive);
		}
	}

	public LocalPlayer(int daysAlive, bool isReal)
	{
		Inventory = new Inventory(25, "PLAYER", false);
		Drones = new List<IDrone>();
		DronesLeftBehind = new List<IDrone>();
		DaysAlive = daysAlive;
		UnreportedBrokenUpgrades = new List<BaseShipUpgrade>();
		string text = UniverseSaveFile.Get("PLAYER", "SHIP_ID", string.Empty);
		int num = 0;
		int result = -1;
		if (string.IsNullOrEmpty(text))
		{
			num = UniverseSaveFile.Get("LAST_SHIP_ID", -1);
			num++;
			UniverseSaveFile.Save("LAST_SHIP_ID", num);
		}
		else
		{
			num = UniverseSaveFile.Get(text, 0);
			string[] array = text.Split('_');
			if (array.Length == 2)
			{
				int.TryParse(array[1], out result);
			}
		}
		MyShip = new DungeonInfo(null, num, result);
		MyShip.InstalledInventory = new Inventory(10, "PLAYER", false);
		int num2 = 0;
		List<string> allGroups = UniverseSaveFile.GetAllGroups("INVITMS", "P", "SHIP");
		if (allGroups != null)
		{
			int count = allGroups.Count;
			for (int i = 0; i < count; i++)
			{
				string groupKey = allGroups[i];
				if (UniverseSaveFile.Get(groupKey, "TYPE", "Undefined").StartsWith("Perm"))
				{
					num2++;
				}
			}
		}
		MyShip.LoadSlotsFromData(num2);
		UniverseSaveFile.Save(MyShip.GroupKey, "P", "PLAYER");
		UniverseSaveFile.Save("PLAYER", "SHIP_ID", MyShip.GroupKey);
		MyShip.Definition = new KeyValuePair<DungeonConfigurationManager.DungeonHelper.DungeonDefinition, DungeonConfigurationManager.DungeonHelper.DungeonClassDefinition>(new DungeonConfigurationManager.DungeonHelper.DungeonDefinition("Exploration", DungeonTypeEnum.Derelict), null);
		MyShip.HaveVisited = true;
		MyShip.DungeonType = DungeonTypeEnum.Derelict;
		UniverseSaveFile.Save(MyShip.GroupKey, "VISITED", true);
		MyShip.WasPlayerOwned = true;
		if (GlobalSettings.IsTutorial)
		{
			return;
		}
		List<string> allGroups2 = UniverseSaveFile.GetAllGroups("INVITMD", "P", "PLAYER");
		List<string> allGroups3 = UniverseSaveFile.GetAllGroups("INVITMS", "P", "PLAYER");
		int num3 = 0;
		SortedList<int, IInventoryItem> sortedList = new SortedList<int, IInventoryItem>();
		foreach (string item in allGroups2)
		{
			string[] array2 = item.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
			int result2 = -1;
			int.TryParse(array2[1], out result2);
			string value = UniverseSaveFile.Get(item, "TYPE", "Undefined");
			DroneUpgradeType type = (DroneUpgradeType)(int)Enum.Parse(typeof(DroneUpgradeType), value, true);
			BaseDroneUpgrade baseDroneUpgrade = DroneUpgradeFactory.CreateUpgradeInstance(type, result2);
			if (baseDroneUpgrade == null)
			{
				continue;
			}
			int key = UniverseSaveFile.Get(item, "SLOT", -1);
			if (baseDroneUpgrade is IBreakable)
			{
				string value2 = UniverseSaveFile.Get(item, "STATE", "None");
				BrokenStateEnum brokenStateEnum = (BrokenStateEnum)(int)Enum.Parse(typeof(BrokenStateEnum), value2, true);
				if (brokenStateEnum != BrokenStateEnum.None)
				{
					((IBreakable)baseDroneUpgrade).OverrideBrokenState(brokenStateEnum);
				}
			}
			if (baseDroneUpgrade is IStorageUpgrade)
			{
				int qty = UniverseSaveFile.Get(item, "QTY", 0);
				((IStorageUpgrade)baseDroneUpgrade).OverrideQuantity(qty);
			}
			if (baseDroneUpgrade is IPoweredObject)
			{
				float power = UniverseSaveFile.Get(item, "QTY", ((IPoweredObject)baseDroneUpgrade).TotalPower);
				((IPoweredObject)baseDroneUpgrade).OverridePower(power);
			}
			if (baseDroneUpgrade is IDamagableObject && baseDroneUpgrade is IOverrideHitpoints)
			{
				float hitpoints = UniverseSaveFile.Get(item, "INV_HP", ((IDamagableObject)baseDroneUpgrade).CurrentHitPoints);
				((IOverrideHitpoints)baseDroneUpgrade).OverrideCurrentHitpoints(hitpoints);
				float hitpoints2 = UniverseSaveFile.Get(item, "INV_HP_TOTAL", ((IDamagableObject)baseDroneUpgrade).TotalHitpoints);
				((IOverrideHitpoints)baseDroneUpgrade).OverrideTotalHitpoints(hitpoints2);
			}
			baseDroneUpgrade.AppliedModifications = (ModificationStorageIdEnum)UniverseSaveFile.Get(item, "INV_MODS", 0);
			baseDroneUpgrade.NumMissions = UniverseSaveFile.Get(item, "INV_MISSIONS", 0);
			baseDroneUpgrade.ErrorMissions = UniverseSaveFile.Get(item, "INV_ERROR_MISSIONS", 0);
			baseDroneUpgrade.BreakTime = UniverseSaveFile.Get(item, "INV_BREAK_TIME", 120f);
			baseDroneUpgrade.ErrorTime = UniverseSaveFile.Get(item, "INV_ERROR_TIME", 0f);
			baseDroneUpgrade.BreakProbability = UniverseSaveFile.Get(item, "INV_BREAK_PROB", 0f);
			baseDroneUpgrade.TimeInMissionPostErrorMision = UniverseSaveFile.Get(item, "INV_TIME_POST_ERROR_MISSION", 0f);
			if (sortedList.ContainsKey(key))
			{
				key = sortedList.Last().Key + 1;
			}
			sortedList.Add(key, baseDroneUpgrade);
		}
		foreach (string item2 in allGroups3)
		{
			string[] array3 = item2.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
			int result3 = -1;
			int.TryParse(array3[1], out result3);
			string value3 = UniverseSaveFile.Get(item2, "TYPE", "Undefined");
			ShipUpgradeType upgradeType = (ShipUpgradeType)(int)Enum.Parse(typeof(ShipUpgradeType), value3, true);
			BaseShipUpgrade baseShipUpgrade = ShipUpgradeFactory.CreateUpgrade(upgradeType, result3);
			if (baseShipUpgrade == null)
			{
				continue;
			}
			int key2 = UniverseSaveFile.Get(item2, "SLOT", -1);
			if (baseShipUpgrade is IBreakable)
			{
				string value4 = UniverseSaveFile.Get(item2, "STATE", "None");
				BrokenStateEnum brokenStateEnum2 = (BrokenStateEnum)(int)Enum.Parse(typeof(BrokenStateEnum), value4, true);
				if (brokenStateEnum2 != BrokenStateEnum.None)
				{
					((IBreakable)baseShipUpgrade).OverrideBrokenState(brokenStateEnum2);
				}
			}
			if (sortedList.ContainsKey(key2))
			{
				key2 = sortedList.Last().Key + 1;
			}
			sortedList.Add(key2, baseShipUpgrade);
			baseShipUpgrade.AppliedModifications = (ModificationStorageIdEnum)UniverseSaveFile.Get(baseShipUpgrade.GroupKey, "INV_MODS", 0);
			baseShipUpgrade.NumMissions = UniverseSaveFile.Get(item2, "INV_MISSIONS", 0);
			baseShipUpgrade.BreakProbability = UniverseSaveFile.Get(item2, "INV_BREAK_PROB", 0f);
		}
		IEnumerator<KeyValuePair<int, IInventoryItem>> enumerator3 = sortedList.GetEnumerator();
		if (isReal)
		{
			while (enumerator3.MoveNext())
			{
				Inventory.AddInventoryItem(enumerator3.Current.Value);
			}
		}
		sortedList.Clear();
		List<string> allGroups4 = UniverseSaveFile.GetAllGroups("INVITMS", "P", "SHIP");
		foreach (string item3 in allGroups4)
		{
			string[] array4 = item3.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
			int result4 = -1;
			int.TryParse(array4[1], out result4);
			string value5 = UniverseSaveFile.Get(item3, "TYPE", "Undefined");
			ShipUpgradeType upgradeType2 = (ShipUpgradeType)(int)Enum.Parse(typeof(ShipUpgradeType), value5, true);
			BaseShipUpgrade baseShipUpgrade2 = ShipUpgradeFactory.CreateUpgrade(upgradeType2, result4);
			if (baseShipUpgrade2 == null)
			{
				continue;
			}
			int key3 = UniverseSaveFile.Get(item3, "SLOT", -1);
			if (baseShipUpgrade2 is IBreakable)
			{
				string value6 = UniverseSaveFile.Get(item3, "STATE", "None");
				BrokenStateEnum brokenStateEnum3 = (BrokenStateEnum)(int)Enum.Parse(typeof(BrokenStateEnum), value6, true);
				if (brokenStateEnum3 != BrokenStateEnum.None)
				{
					((IBreakable)baseShipUpgrade2).OverrideBrokenState(brokenStateEnum3);
				}
			}
			if (sortedList.ContainsKey(key3))
			{
				key3 = sortedList.Last().Key + 1;
			}
			sortedList.Add(key3, baseShipUpgrade2);
			baseShipUpgrade2.AppliedModifications = (ModificationStorageIdEnum)UniverseSaveFile.Get(baseShipUpgrade2.GroupKey, "INV_MODS", 0);
			baseShipUpgrade2.NumMissions = UniverseSaveFile.Get(item3, "INV_MISSIONS", 0);
			baseShipUpgrade2.BreakProbability = UniverseSaveFile.Get(item3, "INV_BREAK_PROB", 0f);
		}
		if (isReal)
		{
			enumerator3 = sortedList.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				InstallShipUpgrade((BaseShipUpgrade)enumerator3.Current.Value);
			}
		}
	}

	public void AddDaysTraveled(int additionalDays)
	{
		DaysAlive += additionalDays;
		int num = GameSaveFile.Get("ST_CUR_DAYS", 0) + additionalDays;
		GameSaveFile.Save("ST_CUR_DAYS", num);
		GameSaveFile.Save("ST_TTL_DAYS", GameSaveFile.Get("ST_TTL_DAYS", 0) + additionalDays);
		if (num > GameSaveFile.Get("ST_BST_DAYS", 0))
		{
			GameSaveFile.Save("ST_BST_DAYS", num);
		}
		GlobalSettings.UniverseDaysSurvived += additionalDays;
		UniverseSaveFile.Save("GSTATE", "UNIVERSE_DAYS", GlobalSettings.UniverseDaysSurvived);
		MyShip.InstalledInventory.AgeInventoryItems(additionalDays);
	}

	public bool AddToInventory(IInventoryItem item)
	{
		int num = 0;
		num = ((!(item is BaseDroneUpgrade)) ? Inventory.ItemsCopy.Count((IInventoryItem x) => x != null && x is BaseShipUpgrade) : Inventory.ItemsCopy.Count((IInventoryItem x) => x != null && x is BaseDroneUpgrade));
		if (num < Inventory.MaxInventorySpace)
		{
			Inventory.AddUniqueInventoryItem(item);
			return true;
		}
		return false;
	}

	public void RemoveFromInventory(IInventoryItem item)
	{
		Inventory.RemoveInventoryItem(item);
	}

	public bool InstallShipUpgrade(BaseShipUpgrade upgrade)
	{
		return InstallShipUpgrade(upgrade, true);
	}

	public bool InstallShipUpgrade(BaseShipUpgrade upgrade, bool respectAllowedSlots)
	{
		int num = 0;
		int count = MyShip.InstalledInventory.ItemsCopy.Count;
		for (int i = 0; i < count; i++)
		{
			if (MyShip.InstalledInventory.ItemsCopy[i] != null && MyShip.InstalledInventory.ItemsCopy[i] is BaseShipUpgrade && ((BaseShipUpgrade)MyShip.InstalledInventory.ItemsCopy[i]).IsPermanentUpgrade)
			{
				num++;
			}
		}
		if (respectAllowedSlots && MyShip.InstalledInventory.InventoryCount - num >= MyShip.ShipUpgradeSlots)
		{
			return false;
		}
		if (upgrade.BrokenState == BrokenStateEnum.Broken)
		{
			if (UniverseSaveFile.Get(upgrade.GroupKey, "P", string.Empty) == "SHIP")
			{
				UniverseSaveFile.Save(upgrade.GroupKey, "P", "PLAYER");
			}
			return false;
		}
		bool flag = true;
		if (MyShip.InstalledInventory.ItemsCopy != null)
		{
			foreach (IInventoryItem item in MyShip.InstalledInventory.ItemsCopy)
			{
				if (item is BaseShipUpgrade)
				{
					BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)item;
					if (baseShipUpgrade.UpgradeType == upgrade.UpgradeType)
					{
						flag = false;
						break;
					}
				}
			}
		}
		if (flag)
		{
			bool flag2 = true;
			if (!upgrade.IsPermanentUpgrade)
			{
				SlotInfo nextFreeSlot = MyShip.GetNextFreeSlot(upgrade.GroupKey);
				if (nextFreeSlot != null)
				{
					nextFreeSlot.InstallUpgrade(upgrade, MyShip.InstalledInventory);
				}
				else
				{
					flag2 = false;
				}
			}
			else
			{
				MyShip.InstalledInventory.AddInventoryItem(upgrade, null);
			}
			if (flag2)
			{
				EventManager.Instance.Publish(GeneralEventType.ShipUpgradeInstalled, new GeneralEventArgs(upgrade));
				bool flag3 = true;
				if (upgrade is LongRangeScannerUpgrade && upgrade.BrokenState == BrokenStateEnum.Broken)
				{
					GlobalSettings.GameState.ThePlayer.AddToInventory(upgrade);
					upgrade.SaveData("PLAYER", Inventory.InventoryCount - 1);
					return false;
				}
				if (flag3 && !GlobalSettings.IsTutorial)
				{
					upgrade.SaveData("SHIP", MyShip.InstalledInventory.InventoryCount - 1);
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public void UninstallShipUpgrade(BaseShipUpgrade upgrade)
	{
		SlotInfo slotByUpgrade = MyShip.GetSlotByUpgrade(upgrade);
		if (slotByUpgrade != null)
		{
			slotByUpgrade.UnInstallUpgrade();
		}
		else
		{
			int num = 0;
			num++;
		}
		EventManager.Instance.Publish(GeneralEventType.ShipUpgradeUninstalled, new GeneralEventArgs(upgrade));
		UniverseSaveFile.ClearGroup(upgrade.GroupKey, "SHIP");
	}

	public bool HasShipUpgradeInstalled(ShipUpgradeType upgradeType)
	{
		bool flag = true;
		foreach (IInventoryItem item in MyShip.InstalledInventory.ItemsCopy)
		{
			if (item is BaseShipUpgrade)
			{
				BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)item;
				if (baseShipUpgrade.UpgradeType == upgradeType)
				{
					return true;
				}
			}
		}
		return false;
	}

	public BaseShipUpgrade GetInstalledShipUpgrade(ShipUpgradeType upgradeType)
	{
		foreach (IInventoryItem item in MyShip.InstalledInventory.ItemsCopy)
		{
			if (item is BaseShipUpgrade)
			{
				BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)item;
				if (baseShipUpgrade.UpgradeType == upgradeType)
				{
					return baseShipUpgrade;
				}
			}
		}
		return null;
	}
}
