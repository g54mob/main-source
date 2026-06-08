using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public static class DroneUpgradeFactory
{
	private static bool _initialized = false;

	private static List<DroneUpgradeDefinition> _upgradeDefinitions = new List<DroneUpgradeDefinition>();

	private static int _nextUpgradeId = 1;

	private static System.Random _random = new System.Random();

	public static List<DroneUpgradeDefinition> UpgradeDefinitions
	{
		get
		{
			return _upgradeDefinitions;
		}
	}

	public static void Initialize()
	{
		if (!_initialized)
		{
			LoadUpgradeDefinitionLibrary();
			_nextUpgradeId = UniverseSaveFile.Get("LAST_DU_ID", 1);
			if (_nextUpgradeId == 1)
			{
				UniverseSaveFile.Save("LAST_DU_ID", _nextUpgradeId);
			}
			_initialized = true;
		}
	}

	private static void LoadUpgradeDefinitionLibrary()
	{
		TextAsset textAsset = (TextAsset)Resources.Load("Data/DroneUpgradeLibrary");
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//DroneUpgrades/UpgradeDefinition");
		foreach (XmlNode item in xmlNodeList)
		{
			DroneUpgradeDefinition definitionFromXml = GetDefinitionFromXml(item);
			if (!GlobalSettings.UPGRADE_IGNORE_ALWAYS_LIST.Contains(definitionFromXml.Type))
			{
				_upgradeDefinitions.Add(definitionFromXml);
			}
		}
	}

	private static DroneUpgradeDefinition GetDefinitionFromXml(XmlNode node)
	{
		return new DroneUpgradeDefinition(node.Attributes["type"].Value, node.Attributes["isVisible"].Value, node.Attributes["name"].Value, node.Attributes["description"].Value, node.Attributes["power"].Value, node.Attributes["weight"].Value, node.Attributes["cost"].Value, node.Attributes["modifierValue"].Value, node.Attributes["activisionCooldown"].Value, node.Attributes["activationDuration"].Value, node.Attributes["upgradeClass"].Value);
	}

	public static BaseDroneUpgrade CreateUpgradeInstance(DroneUpgradeType type)
	{
		return CreateUpgradeInstance(type, -1);
	}

	public static BaseDroneUpgrade CreateUpgradeInstance(DroneUpgradeType type, int id)
	{
		if (!_initialized)
		{
			Debug.LogWarning("DroneUpgradeFactory is not initialized!  Call Initialize() first.");
			return null;
		}
		BaseDroneUpgrade baseDroneUpgrade = null;
		DroneUpgradeDefinition droneUpgradeDefinition = null;
		int count = _upgradeDefinitions.Count;
		for (int i = 0; i < count; i++)
		{
			DroneUpgradeDefinition droneUpgradeDefinition2 = _upgradeDefinitions[i];
			if (droneUpgradeDefinition2.Type == type)
			{
				droneUpgradeDefinition = droneUpgradeDefinition2;
				break;
			}
		}
		if (droneUpgradeDefinition == null)
		{
			Debug.Log("Could not find drone upgrade type: " + type);
			return null;
		}
		switch (type)
		{
		case DroneUpgradeType.SpeedBoost:
			baseDroneUpgrade = new SpeedBoostUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Generator:
			baseDroneUpgrade = new GeneratorUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.SwarmTurret:
			baseDroneUpgrade = new SwarmTurretUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Scanner:
			baseDroneUpgrade = new ScannerUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Interface:
			baseDroneUpgrade = new InterfaceUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Gatherer:
			baseDroneUpgrade = new GathererUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.BruteTurret:
			baseDroneUpgrade = new BruteTurretUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Sensor:
			baseDroneUpgrade = new SensorUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.AreaSensor:
			baseDroneUpgrade = new AreaSensorUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Lure:
			baseDroneUpgrade = new LureUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Trap:
			baseDroneUpgrade = new TrapUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.ProximityMine:
			baseDroneUpgrade = new ProximityMineUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Stun:
			baseDroneUpgrade = new StunUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Repair:
			baseDroneUpgrade = new RepairUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.StealthField:
			baseDroneUpgrade = new StealthUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Shield:
			baseDroneUpgrade = new ShieldUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Teleporter:
			baseDroneUpgrade = new TeleporterUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Probe:
			baseDroneUpgrade = new ProbeUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Sonic:
			baseDroneUpgrade = new SonicUpgrade(droneUpgradeDefinition);
			((SonicUpgrade)baseDroneUpgrade).OverridePower(((SonicUpgrade)baseDroneUpgrade).TotalPower);
			break;
		case DroneUpgradeType.Tow:
			baseDroneUpgrade = new TowUpgrade(droneUpgradeDefinition);
			break;
		case DroneUpgradeType.Pry:
			baseDroneUpgrade = new PryUpgrade(droneUpgradeDefinition);
			break;
		}
		if (id == -1)
		{
			baseDroneUpgrade.Id = _nextUpgradeId++;
			UniverseSaveFile.Save("LAST_DU_ID", _nextUpgradeId);
		}
		else
		{
			baseDroneUpgrade.Id = id;
		}
		return baseDroneUpgrade;
	}

	public static BaseDroneUpgrade CreateRandom(out DroneUpgradeType upgradeType)
	{
		Initialize();
		DroneUpgradeDefinition droneUpgradeDefinition = CommonMethods.PickRandomItem(_upgradeDefinitions, _random);
		upgradeType = droneUpgradeDefinition.Type;
		return CreateUpgradeInstance(upgradeType);
	}
}
