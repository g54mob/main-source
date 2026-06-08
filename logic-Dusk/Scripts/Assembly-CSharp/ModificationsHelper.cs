using System;
using System.Collections.Generic;

public class ModificationsHelper
{
	private static Dictionary<Type, List<IModification>> _modificationsByType;

	private static List<IModification> _emptyList = new List<IModification>();

	public static int CalculateScrapValue(IInventoryItem item)
	{
		int result = 0;
		if (item is TempInventoryItem)
		{
			item = (item as TempInventoryItem).OriginalItem;
		}
		if (item is BaseDroneUpgrade)
		{
			BaseDroneUpgrade baseDroneUpgrade = (BaseDroneUpgrade)item;
			result = ((baseDroneUpgrade.BrokenState == BrokenStateEnum.OK) ? 3 : ((baseDroneUpgrade.BrokenState != BrokenStateEnum.ErrorsDetected) ? 1 : 2));
		}
		else if (item is BaseShipUpgrade)
		{
			BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)item;
			result = ((baseShipUpgrade.BrokenState == BrokenStateEnum.OK) ? 6 : ((baseShipUpgrade.BrokenState != BrokenStateEnum.ErrorsDetected) ? 4 : 5));
		}
		else if (item is IDrone)
		{
			IDrone drone = (IDrone)item;
			result = ((!drone.IsDead && drone.CurrentHitPoints == drone.TotalHitpoints) ? 9 : ((drone.IsDead || !(drone.CurrentHitPoints > 0f)) ? 7 : 8));
		}
		return result;
	}

	public static bool HasModificationsForType(Type typeOfTargetObject)
	{
		if (_modificationsByType == null)
		{
			LoadModifications();
		}
		List<IModification> value = null;
		if (typeOfTargetObject.IsSubclassOf(typeof(BaseDroneUpgrade)) && _modificationsByType.TryGetValue(typeof(BaseDroneUpgrade), out value))
		{
			return true;
		}
		return _modificationsByType.ContainsKey(typeOfTargetObject);
	}

	public static List<IModification> GetModificationsForType(Type typeOfTargetObject)
	{
		if (_modificationsByType == null)
		{
			LoadModifications();
		}
		List<IModification> value = null;
		if (typeOfTargetObject.IsSubclassOf(typeof(BaseDroneUpgrade)) && _modificationsByType.TryGetValue(typeof(BaseDroneUpgrade), out value))
		{
			List<IModification> list = new List<IModification>();
			list.AddRange(value);
			if (_modificationsByType.TryGetValue(typeOfTargetObject, out value))
			{
				list.AddRange(value);
			}
			return list;
		}
		if (_modificationsByType.TryGetValue(typeOfTargetObject, out value))
		{
			return value;
		}
		return _emptyList;
	}

	private static void LoadModifications()
	{
		_modificationsByType = new Dictionary<Type, List<IModification>>();
		List<IModification> list = new List<IModification>();
		_modificationsByType[typeof(NonVisualDrone)] = list;
		list.Add(new RepairHpMod());
		list.Add(new RepairFullHpMod());
		list.Add(new DroneSpeedMod());
		list.Add(new IncreaseMaxHpMod());
		list.Add(new RepairDroneVideoMod());
		List<IModification> list2 = new List<IModification>();
		_modificationsByType[typeof(BaseDroneUpgrade)] = list2;
		list2.Add(new RepairDroneUpgradeMod());
		List<IModification> list3 = new List<IModification>();
		_modificationsByType[typeof(BruteTurretUpgrade)] = list3;
		list3.Add(new AddGattlingAmmoMod());
		List<IModification> list4 = new List<IModification>();
		_modificationsByType[typeof(LureUpgrade)] = list4;
		list4.Add(new AddLuresMod());
		list4.Add(new MagneticMod());
		List<IModification> list5 = new List<IModification>();
		_modificationsByType[typeof(ProximityMineUpgrade)] = list5;
		list5.Add(new AddMinesMod());
		list5.Add(new MagneticMod());
		List<IModification> list6 = new List<IModification>();
		_modificationsByType[typeof(AreaSensorUpgrade)] = list6;
		list6.Add(new AddMotionSensorsMod());
		List<IModification> list7 = new List<IModification>();
		_modificationsByType[typeof(ProbeUpgrade)] = list7;
		list7.Add(new AddProbesMod());
		list7.Add(new IncreaseProbeHpMod());
		list7.Add(new ProbeStealthMod());
		List<IModification> list8 = new List<IModification>();
		_modificationsByType[typeof(RepairUpgrade)] = list8;
		list8.Add(new AddRepairJuiceMod());
		List<IModification> list9 = new List<IModification>();
		_modificationsByType[typeof(SensorUpgrade)] = list9;
		list9.Add(new AddSensorsMod());
		list9.Add(new MagneticMod());
		List<IModification> list10 = new List<IModification>();
		_modificationsByType[typeof(StunUpgrade)] = list10;
		list10.Add(new AddStunMinesMod());
		list10.Add(new MagneticMod());
		List<IModification> list11 = new List<IModification>();
		_modificationsByType[typeof(TrapUpgrade)] = list11;
		list11.Add(new AddTrapsMod());
		list11.Add(new MagneticMod());
		List<IModification> list12 = new List<IModification>();
		_modificationsByType[typeof(ShieldUpgrade)] = list12;
		list12.Add(new RepairShieldMod());
		list12.Add(new ShieldRechargeMod());
		list12.Add(new ShieldRadiationMod());
		List<IModification> list13 = new List<IModification>();
		_modificationsByType[typeof(StealthUpgrade)] = list13;
		list13.Add(new StealthRechargeMod());
		List<IModification> list14 = new List<IModification>();
		_modificationsByType[typeof(SonicUpgrade)] = list14;
		list14.Add(new SonicRechargeMod());
		List<IModification> list15 = new List<IModification>();
		_modificationsByType[typeof(TeleporterUpgrade)] = list15;
		list15.Add(new TeleportMod());
		List<IModification> list16 = new List<IModification>();
		_modificationsByType[typeof(ShipSurveyor)] = list16;
		list16.Add(new RepairShipUpgradeMod());
		list16.Add(new RadiationDetectorMod());
		List<IModification> list17 = new List<IModification>();
		_modificationsByType[typeof(TransporterShipUpgrade)] = list17;
		list17.Add(new RepairShipUpgradeMod());
		List<IModification> list18 = new List<IModification>();
		_modificationsByType[typeof(LongRangeScannerUpgrade)] = list18;
		list18.Add(new RepairShipUpgradeMod());
		List<IModification> list19 = new List<IModification>();
		_modificationsByType[typeof(QuarentineBypassUpgrade)] = list19;
		list19.Add(new RepairShipUpgradeMod());
		List<IModification> list20 = new List<IModification>();
		_modificationsByType[typeof(RemotePowerShipUpgrade)] = list20;
		list20.Add(new RepairShipUpgradeMod());
		List<IModification> list21 = new List<IModification>();
		_modificationsByType[typeof(PowerManagerShipUpgrade)] = list21;
		list21.Add(new RepairShipUpgradeMod());
		List<IModification> list22 = new List<IModification>();
		_modificationsByType[typeof(CannonPermUpgrade)] = list22;
		list22.Add(new CannonRechargeMod());
		List<IModification> list23 = new List<IModification>();
		_modificationsByType[typeof(DecontaminatePermUpgrade)] = list23;
		list23.Add(new DecontaminateRechargeMod());
		List<IModification> list24 = new List<IModification>();
		_modificationsByType[typeof(OverloadPermUpgrade)] = list24;
		list24.Add(new OverloadRechargeMod());
		List<IModification> list25 = new List<IModification>();
		_modificationsByType[typeof(SlotInfo)] = list25;
		list25.Add(new RepairShipSlotMod());
		List<IModification> list26 = new List<IModification>();
		_modificationsByType[typeof(DungeonInfo)] = list26;
		list26.Add(new RepairShipVisualMod());
	}

	public static string GetUpgradeIndicators(ModificationStorageIdEnum storageID)
	{
		string text = "*";
		if ((storageID & ModificationStorageIdEnum.ProbeStealth) == ModificationStorageIdEnum.ProbeStealth)
		{
			text += "s";
		}
		if ((storageID & ModificationStorageIdEnum.ShieldRadiation) == ModificationStorageIdEnum.ShieldRadiation)
		{
			text += "a";
		}
		if ((storageID & ModificationStorageIdEnum.StealthRecharge) == ModificationStorageIdEnum.StealthRecharge)
		{
			text += "r";
		}
		if ((storageID & ModificationStorageIdEnum.DroneSpeed) == ModificationStorageIdEnum.DroneSpeed)
		{
			text += "Sp";
		}
		if ((storageID & ModificationStorageIdEnum.SUSurveyorRadiation) == ModificationStorageIdEnum.SUSurveyorRadiation)
		{
			text += "d";
		}
		if ((storageID & ModificationStorageIdEnum.MagneticMod) == ModificationStorageIdEnum.MagneticMod)
		{
			text += "m";
		}
		if ((storageID & ModificationStorageIdEnum.SonicRecharge) == ModificationStorageIdEnum.SonicRecharge)
		{
			text += "r";
		}
		if ((storageID & ModificationStorageIdEnum.TeleportMod) == ModificationStorageIdEnum.TeleportMod)
		{
			text += "t";
		}
		if (text.Length == 1)
		{
			return string.Empty;
		}
		return text;
	}

	public static string GetShieldUpgradeIndicators(ModificationStorageIdEnum storageID)
	{
		string text = "*";
		if ((storageID & ModificationStorageIdEnum.ShieldRadiation) == ModificationStorageIdEnum.ShieldRadiation)
		{
			text += "x";
		}
		if ((storageID & ModificationStorageIdEnum.ShieldRecharge) == ModificationStorageIdEnum.ShieldRecharge)
		{
			text += "r";
		}
		if (text.Length == 1)
		{
			return string.Empty;
		}
		return text;
	}
}
