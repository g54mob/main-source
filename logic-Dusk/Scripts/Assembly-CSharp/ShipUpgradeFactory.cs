using System;
using System.Collections.Generic;
using UnityEngine;

public static class ShipUpgradeFactory
{
	private static List<ShipUpgradeType> _upgradeDefinitions;

	private static bool _initialized;

	private static System.Random _random;

	private static int _nextUpgradeId = 1;

	public static void Reset()
	{
		_nextUpgradeId = UniverseSaveFile.Get("LAST_SU_ID", 1);
	}

	public static void Initialize()
	{
		if (!_initialized)
		{
			_random = new System.Random();
			_upgradeDefinitions = new List<ShipUpgradeType>();
			_upgradeDefinitions.Add(ShipUpgradeType.ShipSurveyor);
			_upgradeDefinitions.Add(ShipUpgradeType.Transporter);
			_upgradeDefinitions.Add(ShipUpgradeType.PowerManager);
			_upgradeDefinitions.Add(ShipUpgradeType.RemotePower);
			_upgradeDefinitions.Add(ShipUpgradeType.LongRangeScanner);
			_upgradeDefinitions.Add(ShipUpgradeType.Quarantine);
			_nextUpgradeId = UniverseSaveFile.Get("LAST_SU_ID", 1);
			if (_nextUpgradeId == 1)
			{
				UniverseSaveFile.Save("LAST_SU_ID", _nextUpgradeId);
			}
			_initialized = true;
		}
	}

	public static BaseShipUpgrade CreateUpgrade(ShipUpgradeType upgradeType)
	{
		return CreateUpgrade(upgradeType, -1);
	}

	public static BaseShipUpgrade CreateUpgrade(ShipUpgradeType upgradeType, int id)
	{
		Initialize();
		BaseShipUpgrade baseShipUpgrade = null;
		int id2 = id;
		if (id == -1)
		{
			id2 = _nextUpgradeId++;
			UniverseSaveFile.Save("LAST_SU_ID", _nextUpgradeId);
		}
		switch (upgradeType)
		{
		case ShipUpgradeType.ShipSurveyor:
			baseShipUpgrade = new ShipSurveyor(id2);
			break;
		case ShipUpgradeType.PowerManager:
			baseShipUpgrade = new PowerManagerShipUpgrade(id2);
			break;
		case ShipUpgradeType.RemotePower:
			baseShipUpgrade = new RemotePowerShipUpgrade(id2);
			break;
		case ShipUpgradeType.Transporter:
			baseShipUpgrade = new TransporterShipUpgrade(id2);
			break;
		case ShipUpgradeType.LongRangeScanner:
			baseShipUpgrade = new LongRangeScannerUpgrade(id2);
			break;
		case ShipUpgradeType.Quarantine:
			baseShipUpgrade = new QuarentineBypassUpgrade(id2);
			break;
		case ShipUpgradeType.PermCannon:
			baseShipUpgrade = new CannonPermUpgrade(id2);
			break;
		case ShipUpgradeType.PermDecontaminate:
			baseShipUpgrade = new DecontaminatePermUpgrade(id2);
			break;
		case ShipUpgradeType.PermCollector:
			baseShipUpgrade = new CollectorPermUpgrade(id2);
			break;
		case ShipUpgradeType.PermOverload:
			baseShipUpgrade = new OverloadPermUpgrade(id2);
			break;
		case ShipUpgradeType.PermSolder:
			baseShipUpgrade = new SoderPermUpgrade(id2);
			break;
		default:
			Debug.LogWarning("Bad ship upgrade type, can't create it: " + upgradeType);
			break;
		}
		baseShipUpgrade.MissionCountBeforeCanBreak = UnityEngine.Random.Range(4, 12);
		baseShipUpgrade.DaysTraveledUntilBreaks = UnityEngine.Random.Range(0, 1);
		return baseShipUpgrade;
	}

	public static BaseShipUpgrade CreateRandom(out ShipUpgradeType upgradeType)
	{
		return CreateRandom(_random, out upgradeType);
	}

	public static BaseShipUpgrade CreateRandom(System.Random rnd, out ShipUpgradeType upgradeType)
	{
		Initialize();
		upgradeType = CommonMethods.PickRandomItem(_upgradeDefinitions, rnd);
		return CreateUpgrade(upgradeType);
	}
}
