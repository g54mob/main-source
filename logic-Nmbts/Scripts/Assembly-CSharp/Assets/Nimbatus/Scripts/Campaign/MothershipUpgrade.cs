using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DeployCosts;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Campaign
{
	public class MothershipUpgrade : SerializedScriptableObject
	{
		public EMothershipUpgradeType Type;

		public Texture2D Icon;

		public TranslationTerm Name;

		public TranslationTerm Description;

		public int MinLevel;

		public int MaxLevel = 3;

		public Dictionary<int, ItemPrice> PricePerLevel = new Dictionary<int, ItemPrice>();

		public ItemPrice GetPrice(int level)
		{
			if (PricePerLevel.ContainsKey(level))
			{
				return PricePerLevel[level];
			}
			return null;
		}

		public string GetValue(int level, bool comparative = false)
		{
			string text = "";
			switch (Type)
			{
			case EMothershipUpgradeType.DroneHangar:
			{
				string translation2 = LocalizationManager.GetTranslation("MothershipUpgrades/DroneHangarThreshold");
				string text3 = DeployCostHelper.GetThreshold(level).ToString();
				if (comparative)
				{
					text3 = text3 + LabelHelper.Green + " → " + DeployCostHelper.GetThreshold(level + 1) + LabelHelper.White;
				}
				LocalizationManager.ApplyLocalizationParams(ref translation2, new Dictionary<string, string> { { "Value", text3 } });
				text += translation2;
				break;
			}
			case EMothershipUpgradeType.DroneFabrication:
				text += LocalizationManager.GetTranslation("MothershipUpgrades/DroneFabricationCost");
				text = text + " " + DeployCostHelper.GetPartCost(level);
				if (comparative)
				{
					text = text + LabelHelper.Green + " → " + DeployCostHelper.GetPartCost(level + 1);
				}
				break;
			case EMothershipUpgradeType.Drive:
				text += LocalizationManager.GetTranslation("MothershipUpgrades/DriveDecrease");
				text = text + " " + (ThreatHelper.GetThreatReduction(level) * 100f).ToString("F1") + "%";
				if (comparative)
				{
					text = text + LabelHelper.Green + " → " + (ThreatHelper.GetThreatReduction(level + 1) * 100f).ToString("F1") + "%";
				}
				break;
			case EMothershipUpgradeType.WarpDrive:
				text += LocalizationManager.GetTranslation((level == MaxLevel) ? "MothershipUpgrades/WarpDriveRepaired" : "MothershipUpgrades/WarpDriveDestroyed");
				break;
			case EMothershipUpgradeType.Bridge:
			{
				string translation = LocalizationManager.GetTranslation("MothershipUpgrades/BridgeEffect");
				string text2 = level.ToString();
				if (comparative)
				{
					text2 = text2 + LabelHelper.Green + " → " + (level + 1) + LabelHelper.White;
				}
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { { "Level", text2 } });
				text += translation;
				break;
			}
			case EMothershipUpgradeType.Sensors:
			{
				int num = level + (comparative ? 1 : 0);
				if (level == 0 && comparative)
				{
					text += LabelHelper.Green;
				}
				if (num >= 1)
				{
					text += LocalizationManager.GetTranslation("MothershipUpgrades/SensorsLevel1");
				}
				if (level == 1 && comparative)
				{
					text += LabelHelper.Green;
				}
				if (num >= 2)
				{
					text = text + LabelHelper.NewLine + LocalizationManager.GetTranslation("MothershipUpgrades/SensorsLevel2");
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("Type", Type, null);
			}
			return text;
		}
	}
}
