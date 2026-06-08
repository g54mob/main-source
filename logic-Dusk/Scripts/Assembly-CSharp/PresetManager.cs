using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using UnityEngine;

public static class PresetManager
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DroneUpgradePresetDefinition
	{
		public int SlotNumber { get; set; }

		public DroneUpgradeType UpgradeType { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DronePresetDefinition
	{
		public int ID { get; set; }

		public List<DroneUpgradePresetDefinition> DroneUpgradeList { get; set; }
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PresetDefinition
	{
		public string ID { get; set; }

		public List<DronePresetDefinition> DroneList { get; set; }
	}

	public static bool PresetInUse = false;

	public static int PresetIndex = -1;

	public static List<PresetDefinition> PresetList;

	public static PresetDefinition SnapshotPreset = default(PresetDefinition);

	private static bool isInitialized = false;

	public static bool HasSnapshot
	{
		get
		{
			if (SnapshotPreset.DroneList == null || SnapshotPreset.DroneList.Count == 0)
			{
				return false;
			}
			return true;
		}
	}

	public static void Initialze()
	{
		if (!isInitialized)
		{
			DroneUpgradeFactory.Initialize();
			LoadPresets();
		}
	}

	public static void LoadPresets()
	{
		if (PresetList == null)
		{
			PresetList = new List<PresetDefinition>();
		}
		else
		{
			PresetList.Clear();
		}
		List<DroneUpgradeDefinition> upgradeDefinitions = DroneUpgradeFactory.UpgradeDefinitions;
		TextAsset textAsset = (TextAsset)Resources.Load("Data/DronePresets");
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//DronePresets/Preset");
		foreach (XmlNode item4 in xmlNodeList)
		{
			PresetDefinition item = new PresetDefinition
			{
				ID = item4.Attributes["id"].Value,
				DroneList = new List<DronePresetDefinition>()
			};
			XmlNodeList xmlNodeList2 = item4.SelectNodes("Drone");
			foreach (XmlNode item5 in xmlNodeList2)
			{
				DronePresetDefinition item2 = new DronePresetDefinition
				{
					ID = XmlConvert.ToInt32(item5.Attributes["id"].Value),
					DroneUpgradeList = new List<DroneUpgradePresetDefinition>()
				};
				XmlNodeList xmlNodeList3 = item5.SelectNodes("DroneUpgrade");
				foreach (XmlNode item6 in xmlNodeList3)
				{
					bool flag = false;
					DroneUpgradePresetDefinition item3 = new DroneUpgradePresetDefinition
					{
						SlotNumber = XmlConvert.ToInt32(item6.Attributes["slot"].Value)
					};
					string value = item6.Attributes["name"].Value;
					foreach (DroneUpgradeDefinition item7 in upgradeDefinitions)
					{
						if (item7.Name.StartsWith(value))
						{
							item3.UpgradeType = item7.Type;
							flag = true;
							break;
						}
					}
					if (flag)
					{
						item2.DroneUpgradeList.Add(item3);
					}
				}
				item.DroneList.Add(item2);
			}
			PresetList.Add(item);
		}
	}

	public static void TakeSnapshot(List<IDrone> droneList)
	{
		PresetInUse = false;
		PresetIndex = -1;
		if (SnapshotPreset.DroneList == null)
		{
			SnapshotPreset.DroneList = new List<DronePresetDefinition>();
		}
		else
		{
			SnapshotPreset.DroneList.Clear();
		}
		SnapshotPreset.ID = "SNAPSHOT";
		SnapshotPreset.DroneList = new List<DronePresetDefinition>();
		foreach (IDrone drone in droneList)
		{
			if (drone == null)
			{
				continue;
			}
			DronePresetDefinition item = new DronePresetDefinition
			{
				ID = drone.DroneNumber - 1,
				DroneUpgradeList = new List<DroneUpgradePresetDefinition>()
			};
			if (drone.NumberOfUpgradesInstalled() > 0)
			{
				int num = -1;
				foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
				{
					num++;
					if (upgrade != null)
					{
						DroneUpgradePresetDefinition item2 = new DroneUpgradePresetDefinition
						{
							SlotNumber = num,
							UpgradeType = upgrade.Definition.Type
						};
						item.DroneUpgradeList.Add(item2);
					}
				}
			}
			SnapshotPreset.DroneList.Add(item);
		}
	}

	public static void ClearSnapshot()
	{
		if (SnapshotPreset.DroneList != null)
		{
			SnapshotPreset.DroneList.Clear();
			SnapshotPreset.DroneList = null;
		}
	}

	public static void LoadPreset(string presetName, List<IDrone> droneList)
	{
		if (PresetList.Any((PresetDefinition x) => x.ID.ToLower().Equals(presetName, StringComparison.InvariantCultureIgnoreCase)))
		{
			PresetDefinition preset = PresetList.FirstOrDefault((PresetDefinition x) => x.ID.ToLower().Equals(presetName, StringComparison.InvariantCultureIgnoreCase));
			foreach (IDrone drone in droneList)
			{
				if (drone != null)
				{
					drone.RemoveAllUpgrades();
				}
			}
			BuildDronesFromPresetDefinition(preset, droneList);
		}
		else
		{
			Debug.LogWarning(string.Format("Could not locate a preset named '{0}'", presetName));
		}
	}

	public static void LoadPreset(int presetIndex, List<IDrone> droneList)
	{
		foreach (IDrone drone in droneList)
		{
			if (drone != null)
			{
				drone.RemoveAllUpgrades();
			}
		}
		PresetDefinition preset = PresetList[presetIndex];
		BuildDronesFromPresetDefinition(preset, droneList);
		GameplayManager.ShowConsoleMessage("Preset '" + preset.ID + "' set", ConsoleMessageType.Info);
	}

	public static void BuildDronesFromPresetDefinition(PresetDefinition preset, List<IDrone> droneList)
	{
		foreach (DronePresetDefinition drone in preset.DroneList)
		{
			int iD = drone.ID;
			if (iD < droneList.Count)
			{
				foreach (DroneUpgradePresetDefinition droneUpgrade in drone.DroneUpgradeList)
				{
					droneList[iD].AddDroneUpgrade(droneUpgrade.SlotNumber, DroneUpgradeFactory.CreateUpgradeInstance(droneUpgrade.UpgradeType));
				}
			}
			else
			{
				Debug.LogWarning("Invalid Drone Index in Preset: " + preset.ID);
			}
		}
	}
}
