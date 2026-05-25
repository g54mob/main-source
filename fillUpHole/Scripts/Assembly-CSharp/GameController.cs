using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using V1;

public class GameController : MonoBehaviour
{
	public class UpgradeInfo
	{
		public BaseShardBLevelAttribute LevelUpAttribute = new BaseShardBLevelAttribute("LevelUp", 1, (int l) => l + 1, () => true);

		public BaseMoneyAttribute CanVacuumAttribute = new BaseMoneyAttribute("CanVacuum", () => 2500, () => true);

		public BaseShardBLevelAttribute CanAbilityThrowAllAttribute = new BaseShardBLevelAttribute("CanAbilityThrowAll", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanAbilityCloneAttribute = new BaseShardBLevelAttribute("CanAbilityClone", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanAbilityAllHappyAttribute = new BaseShardBLevelAttribute("CanAbilityAllHappy", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanAbilityBulldozerAttribute = new BaseShardBLevelAttribute("CanAbilityBulldozer", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanAbilityCompressAllInStorageAttribute = new BaseShardBLevelAttribute("CanAbilityCompressAllInStorage", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanAbilityCompressAllOnMapAttribute = new BaseShardBLevelAttribute("CanAbilityCompressAllOnMap", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanAbilityAirplaneAttribute = new BaseShardBLevelAttribute("CanAbilityAirplane", 1, (int l) => l + 1, () => true);

		public BaseResearchLevelAttribute CanAbilityAirplaneMoreAttribute = new BaseResearchLevelAttribute("CanAbilityAirplaneMore", 1, (int l) => 500, () => true);

		public BaseShardBLevelAttribute CanAbilityDoubleAllOnMapAttribute = new BaseShardBLevelAttribute("CanAbilityDoubleAllOnMap", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanAbilityLowerAllStabilityAttribute = new BaseShardBLevelAttribute("CanAbilityLowerAllStability", 1, (int l) => l + 1, () => true);

		public BaseShardBLevelAttribute CanDeviceTransition1Attribute = new BaseShardBLevelAttribute("CanDeviceTransition1", 1, (int l) => 1, () => true);

		public BaseShardYLevelAttribute CanDeviceTransition2Attribute = new BaseShardYLevelAttribute("CanDeviceTransition2", 1, (int l) => 3, () => true);

		public BaseShardYLevelAttribute CanDeviceTransition3Attribute = new BaseShardYLevelAttribute("CanDeviceTransition3", 1, (int l) => 3, () => true);

		public List<BaseSavableAttribute> GetAttributes()
		{
			return new List<BaseSavableAttribute>
			{
				LevelUpAttribute, CanVacuumAttribute, CanAbilityThrowAllAttribute, CanAbilityCloneAttribute, CanAbilityAllHappyAttribute, CanAbilityBulldozerAttribute, CanAbilityCompressAllInStorageAttribute, CanAbilityCompressAllOnMapAttribute, CanAbilityAirplaneAttribute, CanAbilityDoubleAllOnMapAttribute,
				CanAbilityLowerAllStabilityAttribute, CanAbilityAirplaneMoreAttribute, CanDeviceTransition1Attribute, CanDeviceTransition2Attribute, CanDeviceTransition3Attribute
			};
		}

		public void Reset()
		{
			foreach (BaseSavableAttribute attribute in GetAttributes())
			{
				attribute.Reset();
			}
		}

		public int GetCharacterCarryLimit()
		{
			return 1 + Training.GlobalInfo.CarryAttribute.Level;
		}

		public float CharHappySpeed()
		{
			float num = 1.2f;
			if (Training.GlobalInfo.CanFasterPeonAttribute.IsEnabled)
			{
				num += 0.2f;
			}
			return num + 0.1f * (float)Training.GlobalInfo.SpeedAttribute.Level;
		}

		public float CharNormalSpeed()
		{
			if (Training.GlobalInfo.CanContentIsHappyAttribute.IsEnabled)
			{
				return CharHappySpeed();
			}
			float num = 1f;
			if (Training.GlobalInfo.CanFasterPeonAttribute.IsEnabled)
			{
				num += 0.2f;
			}
			return num;
		}

		public float CharSadSpeed()
		{
			float num = 0.7f;
			if (Training.GlobalInfo.CanFasterPeonAttribute.IsEnabled)
			{
				num += 0.2f;
			}
			return num;
		}

		public float GetCharacterSpeed(bool isHappy, bool isContent, bool isSad)
		{
			float num = 1f;
			if (isHappy)
			{
				num = CharHappySpeed();
			}
			if (isContent)
			{
				num = CharNormalSpeed();
			}
			if (isSad)
			{
				num = CharSadSpeed();
			}
			return 6f * num;
		}

		public void SetData(Dictionary<string, int> data)
		{
			SetDataAttribute(data, "Main", GetAttributes());
			if (data.ContainsKey("Catapult.TotalExecutionCount"))
			{
				Catapult.GlobalInfo.TotalExecutionCount = data["Catapult.TotalExecutionCount"];
			}
			if (data.ContainsKey("Catapult.TotalGarbageOut"))
			{
				Catapult.GlobalInfo.TotalGarbageOut = data["Catapult.TotalGarbageOut"];
			}
			if (data.ContainsKey("Catapult.StabilityLevel"))
			{
				Catapult.GlobalInfo.StabilityLevel = data["Catapult.StabilityLevel"];
			}
			if (data.ContainsKey("Catapult.EvilExplosionCount"))
			{
				Catapult.GlobalInfo.EvilExplosionCount = data["Catapult.EvilExplosionCount"];
			}
			if (data.ContainsKey("Catapult.TotalEvilCount"))
			{
				Catapult.GlobalInfo.TotalEvilCount = data["Catapult.TotalEvilCount"];
			}
			if (data.ContainsKey("Catapult.HasSpawnBook"))
			{
				Catapult.GlobalInfo.HasSpawnBook = data["Catapult.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Catapult", Catapult.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Compressor.TotalExecutionCount"))
			{
				Compressor.GlobalInfo.TotalExecutionCount = data["Compressor.TotalExecutionCount"];
			}
			if (data.ContainsKey("Compressor.TotalGarbageOut"))
			{
				Compressor.GlobalInfo.TotalGarbageOut = data["Compressor.TotalGarbageOut"];
			}
			if (data.ContainsKey("Compressor.StabilityLevel"))
			{
				Compressor.GlobalInfo.StabilityLevel = data["Compressor.StabilityLevel"];
			}
			if (data.ContainsKey("Compressor.EvilExplosionCount"))
			{
				Compressor.GlobalInfo.EvilExplosionCount = data["Compressor.EvilExplosionCount"];
			}
			if (data.ContainsKey("Compressor.TotalEvilCount"))
			{
				Compressor.GlobalInfo.TotalEvilCount = data["Compressor.TotalEvilCount"];
			}
			if (data.ContainsKey("Compressor.HasSpawnBook"))
			{
				Compressor.GlobalInfo.HasSpawnBook = data["Compressor.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Compressor", Compressor.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Drone.TotalExecutionCount"))
			{
				Drone.GlobalInfo.TotalExecutionCount = data["Drone.TotalExecutionCount"];
			}
			if (data.ContainsKey("Drone.TotalGarbageOut"))
			{
				Drone.GlobalInfo.TotalGarbageOut = data["Drone.TotalGarbageOut"];
			}
			if (data.ContainsKey("Drone.StabilityLevel"))
			{
				Drone.GlobalInfo.StabilityLevel = data["Drone.StabilityLevel"];
			}
			if (data.ContainsKey("Drone.EvilExplosionCount"))
			{
				Drone.GlobalInfo.EvilExplosionCount = data["Drone.EvilExplosionCount"];
			}
			if (data.ContainsKey("Drone.TotalEvilCount"))
			{
				Drone.GlobalInfo.TotalEvilCount = data["Drone.TotalEvilCount"];
			}
			if (data.ContainsKey("Drone.HasSpawnBook"))
			{
				Drone.GlobalInfo.HasSpawnBook = data["Drone.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Drone", Drone.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Helicopter.TotalExecutionCount"))
			{
				Helicopter.GlobalInfo.TotalExecutionCount = data["Helicopter.TotalExecutionCount"];
			}
			if (data.ContainsKey("Helicopter.TotalGarbageOut"))
			{
				Helicopter.GlobalInfo.TotalGarbageOut = data["Helicopter.TotalGarbageOut"];
			}
			if (data.ContainsKey("Helicopter.StabilityLevel"))
			{
				Helicopter.GlobalInfo.StabilityLevel = data["Helicopter.StabilityLevel"];
			}
			if (data.ContainsKey("Helicopter.EvilExplosionCount"))
			{
				Helicopter.GlobalInfo.EvilExplosionCount = data["Helicopter.EvilExplosionCount"];
			}
			if (data.ContainsKey("Helicopter.TotalEvilCount"))
			{
				Helicopter.GlobalInfo.TotalEvilCount = data["Helicopter.TotalEvilCount"];
			}
			if (data.ContainsKey("Helicopter.HasSpawnBook"))
			{
				Helicopter.GlobalInfo.HasSpawnBook = data["Helicopter.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Helicopter", Helicopter.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("HotAirStation.TotalExecutionCount"))
			{
				HotAirStation.GlobalInfo.TotalExecutionCount = data["HotAirStation.TotalExecutionCount"];
			}
			if (data.ContainsKey("HotAirStation.TotalGarbageOut"))
			{
				HotAirStation.GlobalInfo.TotalGarbageOut = data["HotAirStation.TotalGarbageOut"];
			}
			if (data.ContainsKey("HotAirStation.StabilityLevel"))
			{
				HotAirStation.GlobalInfo.StabilityLevel = data["HotAirStation.StabilityLevel"];
			}
			if (data.ContainsKey("HotAirStation.EvilExplosionCount"))
			{
				HotAirStation.GlobalInfo.EvilExplosionCount = data["HotAirStation.EvilExplosionCount"];
			}
			if (data.ContainsKey("HotAirStation.TotalEvilCount"))
			{
				HotAirStation.GlobalInfo.TotalEvilCount = data["HotAirStation.TotalEvilCount"];
			}
			if (data.ContainsKey("HotAirStation.HasSpawnBook"))
			{
				HotAirStation.GlobalInfo.HasSpawnBook = data["HotAirStation.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "HotAirStation", HotAirStation.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("House.TotalExecutionCount"))
			{
				House.GlobalInfo.TotalExecutionCount = data["House.TotalExecutionCount"];
			}
			if (data.ContainsKey("House.TotalGarbageOut"))
			{
				House.GlobalInfo.TotalGarbageOut = data["House.TotalGarbageOut"];
			}
			if (data.ContainsKey("House.StabilityLevel"))
			{
				House.GlobalInfo.StabilityLevel = data["House.StabilityLevel"];
			}
			if (data.ContainsKey("House.EvilExplosionCount"))
			{
				House.GlobalInfo.EvilExplosionCount = data["House.EvilExplosionCount"];
			}
			if (data.ContainsKey("House.TotalEvilCount"))
			{
				House.GlobalInfo.TotalEvilCount = data["House.TotalEvilCount"];
			}
			if (data.ContainsKey("House.HasSpawnBook"))
			{
				House.GlobalInfo.HasSpawnBook = data["House.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "House", House.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Industry.TotalExecutionCount"))
			{
				Industry.GlobalInfo.TotalExecutionCount = data["Industry.TotalExecutionCount"];
			}
			if (data.ContainsKey("Industry.TotalGarbageOut"))
			{
				Industry.GlobalInfo.TotalGarbageOut = data["Industry.TotalGarbageOut"];
			}
			if (data.ContainsKey("Industry.StabilityLevel"))
			{
				Industry.GlobalInfo.StabilityLevel = data["Industry.StabilityLevel"];
			}
			if (data.ContainsKey("Industry.EvilExplosionCount"))
			{
				Industry.GlobalInfo.EvilExplosionCount = data["Industry.EvilExplosionCount"];
			}
			if (data.ContainsKey("Industry.TotalEvilCount"))
			{
				Industry.GlobalInfo.TotalEvilCount = data["Industry.TotalEvilCount"];
			}
			if (data.ContainsKey("Industry.HasSpawnBook"))
			{
				Industry.GlobalInfo.HasSpawnBook = data["Industry.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Industry", Industry.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Power.TotalExecutionCount"))
			{
				Power.GlobalInfo.TotalExecutionCount = data["Power.TotalExecutionCount"];
			}
			if (data.ContainsKey("Power.TotalGarbageOut"))
			{
				Power.GlobalInfo.TotalGarbageOut = data["Power.TotalGarbageOut"];
			}
			if (data.ContainsKey("Power.StabilityLevel"))
			{
				Power.GlobalInfo.StabilityLevel = data["Power.StabilityLevel"];
			}
			if (data.ContainsKey("Power.EvilExplosionCount"))
			{
				Power.GlobalInfo.EvilExplosionCount = data["Power.EvilExplosionCount"];
			}
			if (data.ContainsKey("Power.TotalEvilCount"))
			{
				Power.GlobalInfo.TotalEvilCount = data["Power.TotalEvilCount"];
			}
			if (data.ContainsKey("Power.HasSpawnBook"))
			{
				Power.GlobalInfo.HasSpawnBook = data["Power.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Power", Power.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Research.TotalExecutionCount"))
			{
				Research.GlobalInfo.TotalExecutionCount = data["Research.TotalExecutionCount"];
			}
			if (data.ContainsKey("Research.TotalGarbageOut"))
			{
				Research.GlobalInfo.TotalGarbageOut = data["Research.TotalGarbageOut"];
			}
			if (data.ContainsKey("Research.StabilityLevel"))
			{
				Research.GlobalInfo.StabilityLevel = data["Research.StabilityLevel"];
			}
			if (data.ContainsKey("Research.EvilExplosionCount"))
			{
				Research.GlobalInfo.EvilExplosionCount = data["Research.EvilExplosionCount"];
			}
			if (data.ContainsKey("Research.TotalEvilCount"))
			{
				Research.GlobalInfo.TotalEvilCount = data["Research.TotalEvilCount"];
			}
			if (data.ContainsKey("Research.HasSpawnBook"))
			{
				Research.GlobalInfo.HasSpawnBook = data["Research.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Research", Research.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Store.TotalExecutionCount"))
			{
				Store.GlobalInfo.TotalExecutionCount = data["Store.TotalExecutionCount"];
			}
			if (data.ContainsKey("Store.TotalGarbageOut"))
			{
				Store.GlobalInfo.TotalGarbageOut = data["Store.TotalGarbageOut"];
			}
			if (data.ContainsKey("Store.StabilityLevel"))
			{
				Store.GlobalInfo.StabilityLevel = data["Store.StabilityLevel"];
			}
			if (data.ContainsKey("Store.EvilExplosionCount"))
			{
				Store.GlobalInfo.EvilExplosionCount = data["Store.EvilExplosionCount"];
			}
			if (data.ContainsKey("Store.TotalEvilCount"))
			{
				Store.GlobalInfo.TotalEvilCount = data["Store.TotalEvilCount"];
			}
			if (data.ContainsKey("Store.HasSpawnBook"))
			{
				Store.GlobalInfo.HasSpawnBook = data["Store.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Store", Store.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Temple.TotalExecutionCount"))
			{
				Temple.GlobalInfo.TotalExecutionCount = data["Temple.TotalExecutionCount"];
			}
			if (data.ContainsKey("Temple.TotalGarbageOut"))
			{
				Temple.GlobalInfo.TotalGarbageOut = data["Temple.TotalGarbageOut"];
			}
			if (data.ContainsKey("Temple.StabilityLevel"))
			{
				Temple.GlobalInfo.StabilityLevel = data["Temple.StabilityLevel"];
			}
			if (data.ContainsKey("Temple.EvilExplosionCount"))
			{
				Temple.GlobalInfo.EvilExplosionCount = data["Temple.EvilExplosionCount"];
			}
			if (data.ContainsKey("Temple.TotalEvilCount"))
			{
				Temple.GlobalInfo.TotalEvilCount = data["Temple.TotalEvilCount"];
			}
			if (data.ContainsKey("Temple.HasSpawnBook"))
			{
				Temple.GlobalInfo.HasSpawnBook = data["Temple.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Temple", Temple.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Training.TotalExecutionCount"))
			{
				Training.GlobalInfo.TotalExecutionCount = data["Training.TotalExecutionCount"];
			}
			if (data.ContainsKey("Training.TotalGarbageOut"))
			{
				Training.GlobalInfo.TotalGarbageOut = data["Training.TotalGarbageOut"];
			}
			if (data.ContainsKey("Training.StabilityLevel"))
			{
				Training.GlobalInfo.StabilityLevel = data["Training.StabilityLevel"];
			}
			if (data.ContainsKey("Training.EvilExplosionCount"))
			{
				Training.GlobalInfo.EvilExplosionCount = data["Training.EvilExplosionCount"];
			}
			if (data.ContainsKey("Training.TotalEvilCount"))
			{
				Training.GlobalInfo.TotalEvilCount = data["Training.TotalEvilCount"];
			}
			if (data.ContainsKey("Training.HasSpawnBook"))
			{
				Training.GlobalInfo.HasSpawnBook = data["Training.HasSpawnBook"] == 1;
			}
			SetDataAttribute(data, "Training", Training.GlobalInfo.GetStaticAttributes());
			if (data.ContainsKey("Rock.TotalExecutionCount"))
			{
				Rock.GlobalInfo.TotalExecutionCount = data["Rock.TotalExecutionCount"];
			}
			if (data.ContainsKey("Rock.TotalGarbageOut"))
			{
				Rock.GlobalInfo.TotalGarbageOut = data["Rock.TotalGarbageOut"];
			}
			SetDataAttribute(data, "Rock", Rock.GlobalInfo.GetStaticAttributes());
		}

		public void SetDataAttribute(Dictionary<string, int> data, string name, List<BaseSavableAttribute> attributes)
		{
			foreach (BaseSavableAttribute attribute in attributes)
			{
				if (data.ContainsKey(name + "." + attribute.Name))
				{
					attribute.ForceLevel(data[name + "." + attribute.Name]);
				}
				if (attribute is BaseTrainingAttribute)
				{
					((BaseTrainingAttribute)attribute).Amount = data[name + "." + attribute.Name + "Amount"];
				}
			}
		}

		public Dictionary<string, int> GetData()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			GetDataAttribute(dictionary, "Main", GetAttributes());
			dictionary.Add("Catapult.TotalExecutionCount", Catapult.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Catapult.TotalGarbageOut", Catapult.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Catapult.StabilityLevel", Catapult.GlobalInfo.StabilityLevel);
			dictionary.Add("Catapult.EvilExplosionCount", Catapult.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Catapult.TotalEvilCount", Catapult.GlobalInfo.TotalEvilCount);
			dictionary.Add("Catapult.HasSpawnBook", Catapult.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Catapult", Catapult.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Helicopter.TotalExecutionCount", Helicopter.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Helicopter.TotalGarbageOut", Helicopter.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Helicopter.StabilityLevel", Helicopter.GlobalInfo.StabilityLevel);
			dictionary.Add("Helicopter.EvilExplosionCount", Helicopter.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Helicopter.TotalEvilCount", Helicopter.GlobalInfo.TotalEvilCount);
			dictionary.Add("Helicopter.HasSpawnBook", Helicopter.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Helicopter", Helicopter.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Drone.TotalExecutionCount", Drone.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Drone.TotalGarbageOut", Drone.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Drone.StabilityLevel", Drone.GlobalInfo.StabilityLevel);
			dictionary.Add("Drone.EvilExplosionCount", Drone.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Drone.TotalEvilCount", Drone.GlobalInfo.TotalEvilCount);
			dictionary.Add("Drone.HasSpawnBook", Drone.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Drone", Drone.GlobalInfo.GetStaticAttributes());
			dictionary.Add("HotAirStation.TotalExecutionCount", HotAirStation.GlobalInfo.TotalExecutionCount);
			dictionary.Add("HotAirStation.TotalGarbageOut", HotAirStation.GlobalInfo.TotalGarbageOut);
			dictionary.Add("HotAirStation.StabilityLevel", HotAirStation.GlobalInfo.StabilityLevel);
			dictionary.Add("HotAirStation.EvilExplosionCount", HotAirStation.GlobalInfo.EvilExplosionCount);
			dictionary.Add("HotAirStation.TotalEvilCount", HotAirStation.GlobalInfo.TotalEvilCount);
			dictionary.Add("HotAirStation.HasSpawnBook", HotAirStation.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "HotAirStation", HotAirStation.GlobalInfo.GetStaticAttributes());
			dictionary.Add("House.TotalExecutionCount", House.GlobalInfo.TotalExecutionCount);
			dictionary.Add("House.TotalGarbageOut", House.GlobalInfo.TotalGarbageOut);
			dictionary.Add("House.StabilityLevel", House.GlobalInfo.StabilityLevel);
			dictionary.Add("House.EvilExplosionCount", House.GlobalInfo.EvilExplosionCount);
			dictionary.Add("House.TotalEvilCount", House.GlobalInfo.TotalEvilCount);
			dictionary.Add("House.HasSpawnBook", House.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "House", House.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Research.TotalExecutionCount", Research.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Research.TotalGarbageOut", Research.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Research.StabilityLevel", Research.GlobalInfo.StabilityLevel);
			dictionary.Add("Research.EvilExplosionCount", Research.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Research.TotalEvilCount", Research.GlobalInfo.TotalEvilCount);
			dictionary.Add("Research.HasSpawnBook", Research.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Research", Research.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Store.TotalExecutionCount", Store.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Store.TotalGarbageOut", Store.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Store.StabilityLevel", Store.GlobalInfo.StabilityLevel);
			dictionary.Add("Store.EvilExplosionCount", Store.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Store.TotalEvilCount", Store.GlobalInfo.TotalEvilCount);
			dictionary.Add("Store.HasSpawnBook", Store.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Store", Store.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Temple.TotalExecutionCount", Temple.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Temple.TotalGarbageOut", Temple.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Temple.StabilityLevel", Temple.GlobalInfo.StabilityLevel);
			dictionary.Add("Temple.EvilExplosionCount", Temple.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Temple.TotalEvilCount", Temple.GlobalInfo.TotalEvilCount);
			dictionary.Add("Temple.HasSpawnBook", Temple.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Temple", Temple.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Training.TotalExecutionCount", Training.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Training.TotalGarbageOut", Training.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Training.StabilityLevel", Training.GlobalInfo.StabilityLevel);
			dictionary.Add("Training.EvilExplosionCount", Training.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Training.TotalEvilCount", Training.GlobalInfo.TotalEvilCount);
			dictionary.Add("Training.HasSpawnBook", Training.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Training", Training.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Industry.TotalExecutionCount", Industry.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Industry.TotalGarbageOut", Industry.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Industry.StabilityLevel", Industry.GlobalInfo.StabilityLevel);
			dictionary.Add("Industry.EvilExplosionCount", Industry.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Industry.TotalEvilCount", Industry.GlobalInfo.TotalEvilCount);
			dictionary.Add("Industry.HasSpawnBook", Industry.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Industry", Industry.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Power.TotalExecutionCount", Power.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Power.TotalGarbageOut", Power.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Power.StabilityLevel", Power.GlobalInfo.StabilityLevel);
			dictionary.Add("Power.EvilExplosionCount", Power.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Power.TotalEvilCount", Power.GlobalInfo.TotalEvilCount);
			dictionary.Add("Power.HasSpawnBook", Power.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Power", Power.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Compressor.TotalExecutionCount", Compressor.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Compressor.TotalGarbageOut", Compressor.GlobalInfo.TotalGarbageOut);
			dictionary.Add("Compressor.StabilityLevel", Compressor.GlobalInfo.StabilityLevel);
			dictionary.Add("Compressor.EvilExplosionCount", Compressor.GlobalInfo.EvilExplosionCount);
			dictionary.Add("Compressor.TotalEvilCount", Compressor.GlobalInfo.TotalEvilCount);
			dictionary.Add("Compressor.HasSpawnBook", Compressor.GlobalInfo.HasSpawnBook ? 1 : 0);
			GetDataAttribute(dictionary, "Compressor", Compressor.GlobalInfo.GetStaticAttributes());
			dictionary.Add("Rock.TotalExecutionCount", Rock.GlobalInfo.TotalExecutionCount);
			dictionary.Add("Rock.TotalGarbageOut", Rock.GlobalInfo.TotalGarbageOut);
			GetDataAttribute(dictionary, "Rock", Rock.GlobalInfo.GetStaticAttributes());
			return dictionary;
		}

		public void GetDataAttribute(Dictionary<string, int> data, string name, List<BaseSavableAttribute> attributes)
		{
			foreach (BaseSavableAttribute attribute in attributes)
			{
				data.Add(name + "." + attribute.Name, attribute.Level);
				if (attribute is BaseTrainingAttribute)
				{
					data.Add(name + "." + attribute.Name + "Amount", ((BaseTrainingAttribute)attribute).Amount);
				}
			}
		}
	}

	public static GameController Instance;

	public static Color EvilColor = new Color(0.5f, 0f, 0f);

	public static Color MoneyColor = new Color(0.99607843f, 47f / 51f, 0f);

	public static Color RPColor = new Color(1f, 64f / 85f, 0.79607844f);

	public static Color BlueShardColor = new Color(0.30980393f, 0.56078434f, 62f / 85f);

	public static Color YellowShardColor = new Color(74f / 85f, 0.61960787f, 13f / 51f);

	public static Color RedShardColor = new Color(0.64705884f, 16f / 85f, 16f / 85f);

	public static Color BookColor = new Color(48f / 85f, 14f / 15f, 48f / 85f);

	public GameObject HoleLocation;

	public GameObject HoleFarLocation;

	public GameObject EndOfMapLocation;

	public GameObject SpawnLocation;

	public GameObject InitialGarbageLocation;

	public GameObject BulldozerTemplate;

	public GameObject AirplaneTemplate;

	public GameObject FlyingMinionTemplate;

	public List<AbilityButton> AbilityButtons;

	public InGameMenuController InGameMenuController;

	public PrestigeController PrestigeControl;

	public CloudGenerator CloudGenerat;

	public ColumnsController ColumnsController;

	public List<Temple_Entity> Portals;

	public SignChar SignChar;

	public GameObject BuildingContainer;

	public GarbageController GarbageController;

	public PeonController PeonController;

	public ToastPanel ToastPanel;

	public ResourceInfo Money = new ResourceInfo();

	public ResourceInfo ResearchPoint = new ResourceInfo();

	public ResourceInfo Book = new ResourceInfo();

	public ResourceInfo YellowPoint = new ResourceInfo();

	public ResourceInfo RedPoint = new ResourceInfo();

	public ResourceInfo BluePoint = new ResourceInfo();

	public ResourceInfo HoleFilled = new ResourceInfo();

	public Golem Golem;

	public int PrestigeCount;

	public int MaxFilled = 500;

	public static int TotalGarbageCreated = 0;

	public static int TotalTossedGarbage = 0;

	public static int TotalCloudClick = 0;

	public static int TotalCloudClickDestroyed = 0;

	public static int TotalCloudDestroyed = 0;

	public static int TotalPeonTrashThrow = 0;

	public static int TotalPeonThrow = 0;

	public static int TotalBlockedOutput = 0;

	public static bool SeeStats = false;

	public bool SeeAllNodes;

	public bool CanViewOnTop;

	public bool AreBuildingOnTop;

	public float TimePlayed;

	public Image DiskImage;

	private List<Ability> _abilities = new List<Ability>
	{
		new Ability(Ability.AbilityTypeEnum.Bulldozer),
		new Ability(Ability.AbilityTypeEnum.ClonePeon),
		new Ability(Ability.AbilityTypeEnum.FullHapiness),
		new Ability(Ability.AbilityTypeEnum.PowerCompress),
		new Ability(Ability.AbilityTypeEnum.CompressAll),
		new Ability(Ability.AbilityTypeEnum.ProcessAll),
		new Ability(Ability.AbilityTypeEnum.DoubleAll),
		new Ability(Ability.AbilityTypeEnum.Airplane),
		new Ability(Ability.AbilityTypeEnum.Reset),
		new Ability(Ability.AbilityTypeEnum.LowerDurability)
	};

	public const float BUILDING_WIDTH = 7f;

	public const int MAX_PRESTIGE = 8;

	public const bool IS_DEBUG = false;

	public const bool IS_FILM = false;

	public const int GOLUMN_COLUMN = 14;

	public GameObject BottomRight;

	public GameObject TopLeft;

	public Hole Hole;

	public float LastSave;

	public bool FreezeSave;

	public List<AchievementDefinition> Achievements = AchievementDefinition.GetDefinitions();

	private float _achivementCheckTimer;

	public float _timerSpawnFlying;

	public static UpgradeInfo GlobalInfo = new UpgradeInfo();

	public const float DEFAULT_CHAR_SPEED = 6f;

	public List<Ability> Abilities => _abilities;

	private void Awake()
	{
		Instance = this;
		LastSave = 0f;
	}

	private void Start()
	{
		if (!Global.WentToMainMenu)
		{
			SceneManager.LoadScene("MainMenu");
		}
		DiskImage.gameObject.SetActive(value: false);
		foreach (Temple_Entity portal in Portals)
		{
			portal.gameObject.SetActive(value: false);
		}
		GarbageController.SetBounds(TopLeft.transform.position, new Vector3(HoleFarLocation.transform.position.x, BottomRight.transform.position.y, 0f));
		PeonController.SetBounds(TopLeft.transform.position, new Vector3(HoleFarLocation.transform.position.x, BottomRight.transform.position.y, 0f));
		ColumnsController.Init();
		if (SaveManager.GameData != null)
		{
			TutorialController.DisableTutorial();
			LoadData();
		}
		else
		{
			GlobalInfo.Reset();
			Catapult.GlobalInfo.Reset();
			Compressor.GlobalInfo.Reset();
			Drone.GlobalInfo.Reset();
			Helicopter.GlobalInfo.Reset();
			HotAirStation.GlobalInfo.Reset();
			House.GlobalInfo.Reset();
			Industry.GlobalInfo.Reset();
			Power.GlobalInfo.Reset();
			Research.GlobalInfo.Reset();
			Rock.GlobalInfo.Reset();
			Store.GlobalInfo.Reset();
			Temple.GlobalInfo.Reset();
			Training.GlobalInfo.Reset();
			Money.Reset();
			Book.Reset();
			ResearchPoint.Reset();
			YellowPoint.Reset();
			RedPoint.Reset();
			BluePoint.Reset();
			TimePlayed = 0f;
			TotalGarbageCreated = 0;
			PrestigeCount = 0;
			HoleFilled.Reset();
			House.GlobalInfo.LevelUpAttribute.ForceLevel(1);
			Rock.GlobalInfo.LevelUpAttribute.ForceLevel(1);
			GetMaxFilled();
			ColumnsController.VerifyAndAddNewcolumn();
			for (int i = 0; i < 25; i++)
			{
				GarbageController.Generate(new Vector3(InitialGarbageLocation.transform.position.x + UnityEngine.Random.Range(-1f, 1f), InitialGarbageLocation.transform.position.y, 0f), 2, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.None, isEvil: false);
			}
		}
		if (Global.IsNewGame)
		{
			SignChar.StartPulse();
			Global.IsNewGame = false;
			Music2Controller.Instance.PlayBeginingWind();
		}
		else
		{
			Music2Controller.Instance.PlayMainMusic();
		}
	}

	private void Update()
	{
		TimePlayed += Time.deltaTime;
		if (IsHoleFilled())
		{
			CharDisplay.HasQuestionBubble = true;
			PeonController.DropAllGarbage();
		}
		else
		{
			CharDisplay.HasQuestionBubble = false;
		}
		foreach (Ability ability in _abilities)
		{
			ability.ReduceDelay(Time.deltaTime);
		}
		foreach (AbilityButton abilityButton in AbilityButtons)
		{
			bool active = false;
			switch (abilityButton.AbilityType)
			{
			case Ability.AbilityTypeEnum.Bulldozer:
				active = GlobalInfo.CanAbilityBulldozerAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.ClonePeon:
				active = GlobalInfo.CanAbilityCloneAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.FullHapiness:
				active = GlobalInfo.CanAbilityAllHappyAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.PowerCompress:
				active = GlobalInfo.CanAbilityCompressAllInStorageAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.CompressAll:
				active = GlobalInfo.CanAbilityCompressAllOnMapAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.ProcessAll:
				active = GlobalInfo.CanAbilityThrowAllAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.DoubleAll:
				active = GlobalInfo.CanAbilityDoubleAllOnMapAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.Airplane:
				active = GlobalInfo.CanAbilityAirplaneAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.Reset:
				active = Research.GlobalInfo.CanResetAbilitiesAttribute.IsEnabled;
				break;
			case Ability.AbilityTypeEnum.LowerDurability:
				active = GlobalInfo.CanAbilityLowerAllStabilityAttribute.IsEnabled;
				break;
			}
			abilityButton.gameObject.SetActive(active);
		}
		LastSave += Time.deltaTime;
		if (LastSave >= 60f && !FreezeSave)
		{
			SaveData();
		}
		_achivementCheckTimer += Time.deltaTime;
		if (_achivementCheckTimer > 1f)
		{
			_achivementCheckTimer -= 1f;
			if (AchievementDefinition.ProcessAchievements(Achievements))
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_quest_completed);
				Instance.ToastPanel.AddItem("A new quest can be completed.");
			}
		}
		if (FlyingMinion.FlyingSpeed <= 0 || IsHoleFilled())
		{
			return;
		}
		float deltaSpeed = FlyingMinion.GetDeltaSpeed();
		_timerSpawnFlying += Time.deltaTime;
		if (_timerSpawnFlying >= deltaSpeed)
		{
			_timerSpawnFlying = 0f;
			List<ColumnController> columns = ColumnsController.GetColumns();
			float dropX = 0f;
			if (columns.Count > 0)
			{
				dropX = columns[UnityEngine.Random.Range(0, columns.Count)].transform.position.x;
			}
			GameObject obj = UnityEngine.Object.Instantiate(FlyingMinionTemplate, base.transform);
			obj.GetComponent<FlyingMinion>().Setup(dropX);
			obj.gameObject.SetActive(value: true);
		}
	}

	public static int GetMaxPrestigeCount()
	{
		if (Installation.IsDemo())
		{
			return Installation.GetDemoMaxPrestige();
		}
		return 8;
	}

	public int AddPrestigeCountTax(int amount, bool isBuilding = true)
	{
		amount += (int)((float)amount * ((float)Instance.PrestigeCount * 0.25f));
		return amount;
	}

	public float GetCloudChance()
	{
		return 0.005f + 0.005f * (float)Research.GlobalInfo.CanMoreCloudAttribute.Level;
	}

	public bool ExecuteAbility(Ability.AbilityTypeEnum type)
	{
		if (!Ability.CanRunAbility(_abilities, type))
		{
			return false;
		}
		Ability.ResetDelay(_abilities, type);
		Ability.IncreaseUseCount(_abilities, type);
		switch (type)
		{
		case Ability.AbilityTypeEnum.Bulldozer:
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(BulldozerTemplate, base.transform);
			float num = GarbageController.FindFartestGarbage();
			gameObject.transform.position = new Vector3(num - 5f, gameObject.transform.position.y, gameObject.transform.position.z);
			gameObject.SetActive(value: true);
			break;
		}
		case Ability.AbilityTypeEnum.ClonePeon:
			PeonController.GenerateMultiplePeon(SpawnLocation.transform.position);
			break;
		case Ability.AbilityTypeEnum.FullHapiness:
			PeonController.SetAllHappy();
			break;
		case Ability.AbilityTypeEnum.PowerCompress:
			ColumnsController.ProcessAllCompressor();
			break;
		case Ability.AbilityTypeEnum.CompressAll:
			GarbageController.ExecuteCompressAbility();
			break;
		case Ability.AbilityTypeEnum.ProcessAll:
			ColumnsController.ProcessAllCatapult();
			break;
		case Ability.AbilityTypeEnum.DoubleAll:
			GarbageController.ExecuteZapAllAbility();
			break;
		case Ability.AbilityTypeEnum.Airplane:
			if (GlobalInfo.CanAbilityAirplaneMoreAttribute.IsEnabled)
			{
				ExecuteAirplane(smallGarbage: false, mediumGarbage: false, largeGarbage: true);
			}
			else
			{
				ExecuteAirplane(smallGarbage: false, mediumGarbage: true, largeGarbage: false);
			}
			break;
		case Ability.AbilityTypeEnum.Reset:
			foreach (Ability ability in _abilities)
			{
				ability.ResetDelay();
			}
			break;
		case Ability.AbilityTypeEnum.LowerDurability:
			ColumnsController.LowerAllDurability(0.1f);
			break;
		}
		return true;
	}

	public void ExecuteAirplane(bool smallGarbage, bool mediumGarbage, bool largeGarbage)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(AirplaneTemplate, base.transform);
		gameObject.GetComponent<Airplane>().DropSmallGarbage(smallGarbage, mediumGarbage, largeGarbage);
		float lowestColumnX = ColumnsController.GetLowestColumnX();
		gameObject.transform.position = new Vector3(lowestColumnX - 5f, 7f, gameObject.transform.position.z);
		gameObject.SetActive(value: true);
	}

	public bool IsHoleFilled()
	{
		if (HoleFilled.Amount >= MaxFilled)
		{
			return true;
		}
		return false;
	}

	public float GetHolePercentage()
	{
		float num = 0f;
		if (HoleFilled.Amount > 0)
		{
			num = (float)HoleFilled.Amount / (float)MaxFilled;
			if (num > 1f)
			{
				num = 1f;
			}
		}
		return num;
	}

	public Vector3 GetThrowLocation(Vector3 origin, Garbage g)
	{
		Vector3 result = Hole.GetThrowLocation();
		foreach (ColumnController column in ColumnsController.GetColumns())
		{
			if (column.Buildings != null && column.gameObject.transform.position.x > origin.x && column.Buildings.CanHaveThrowGarbage(g))
			{
				Vector3 vector = column.Buildings.ThrowGarbageLocation();
				if (vector.x < result.x)
				{
					result = vector;
				}
			}
		}
		return result;
	}

	public void DropGarbage(GarbageInfo g)
	{
		int num = 0;
		int amount = g.Weight + Compressor.GlobalInfo.CanGarbageMoreMoneyAttribute.Level;
		num = g.GetSize();
		if (Helicopter.GlobalInfo.CanIncreaseSizeOfGarbageAttribute.IsEnabled)
		{
			num *= 2;
		}
		if (HoleFilled.Amount < MaxFilled)
		{
			GlobalSfx2Controller.Instance.PlayFromDistance(SoundManager.SoundTypeEnum.ga_gain_money, HoleLocation.transform.position.x);
			GainMoney(amount);
			HoleFilled.AddAmount(num);
			if (HoleFilled.Amount > MaxFilled)
			{
				HoleFilled.Amount = MaxFilled;
			}
		}
	}

	public void GainMoney(int amount)
	{
		Money.AddAmount(amount);
	}

	public void GainBook(int amount)
	{
		Book.AddAmount(amount);
	}

	public void GainRP(int amount)
	{
		ResearchPoint.AddAmount(amount);
	}

	public void GainBluePoint(int amount)
	{
		BluePoint.AddAmount(amount);
	}

	public void GainYellowPoint(int amount)
	{
		YellowPoint.AddAmount(amount);
	}

	public void GainRedPoint(int amount)
	{
		RedPoint.AddAmount(amount);
	}

	public void ExecutePrestige()
	{
		float num = 0f;
		int num2 = 0;
		List<Vector3> list = new List<Vector3>();
		GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_earthquake);
		CameraController.Instance.PrestigeShake();
		Hole.DestroyAll();
		foreach (ColumnController column in ColumnsController.GetColumns())
		{
			if (column.Buildings != null && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Rock && column.Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Hole)
			{
				num2++;
				num += column.transform.position.x;
				if (Power.GlobalInfo.CanPrestigeRemoveStabilityAttribute.IsEnabled)
				{
					column.EarthquakeReduceStability();
				}
				else
				{
					column.DestroyBuilding(null, Instance.GetPrestigeDestroyPercentage(), canOutputMedium: false);
				}
				list.Add(column.transform.position);
			}
			else if (column.Buildings != null && column.Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Rock)
			{
				((Rock)column.Buildings).RemoveFlyWorkers();
			}
		}
		num = ((num2 != 0 && num != 0f) ? (num / (float)num2) : 0f);
		int amountToThrow = (int)((float)Money.Amount * GetPrestigeMoneyKeptPercentage());
		PrestigeCount++;
		HoleFilled.Reset();
		Money.Amount = 0;
		GetMaxFilled();
		PeonController.DropAllGarbage();
		GarbageController.UnreserveAll();
		PrestigeControl.StartAnimation(list, num, amountToThrow);
		Music2Controller.Instance.PlayMainMusic();
	}

	private void GetMaxFilled()
	{
		if (PrestigeCount == 0)
		{
			MaxFilled = 200;
		}
		else
		{
			MaxFilled = 300 * (PrestigeCount + 1) * (PrestigeCount + 1);
		}
		if (PrestigeCount != 0 && PrestigeCount != 1)
		{
			if (PrestigeCount == 2)
			{
				MaxFilled = (int)((float)MaxFilled * 1.25f);
			}
			else if (PrestigeCount == 3)
			{
				MaxFilled = (int)((float)MaxFilled * 1.5f);
			}
			else if (PrestigeCount == 4)
			{
				MaxFilled = (int)((float)MaxFilled * 2f);
			}
			else if (PrestigeCount == 5)
			{
				MaxFilled = (int)((float)MaxFilled * 2.5f);
			}
			else if (PrestigeCount == 6)
			{
				MaxFilled = (int)((float)MaxFilled * 3f);
			}
			else if (PrestigeCount == 7)
			{
				MaxFilled = (int)((float)MaxFilled * 4f);
			}
			else if (PrestigeCount == 8)
			{
				MaxFilled = (int)((float)MaxFilled * 5f);
			}
		}
		if (CharDisplay.HasHat)
		{
			if (PrestigeCount <= 3)
			{
				MaxFilled *= 3;
			}
			else if (PrestigeCount <= 6)
			{
				MaxFilled = (int)((double)(float)MaxFilled * 3.5);
			}
			else
			{
				MaxFilled *= 4;
			}
		}
	}

	public void QuitGame()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void ToggleBuildingOnTop()
	{
		if (CanViewOnTop)
		{
			AreBuildingOnTop = !AreBuildingOnTop;
			if (AreBuildingOnTop)
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_buildingfocus_on);
			}
			else
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_buildingfocus_off);
			}
			ColumnsController.ToggleBuildingOnTop(AreBuildingOnTop);
		}
	}

	private void LoadData()
	{
		if (SaveManager.GameData == null)
		{
			return;
		}
		Money.Reset();
		Book.Reset();
		ResearchPoint.Reset();
		YellowPoint.Reset();
		RedPoint.Reset();
		BluePoint.Reset();
		HoleFilled.Reset();
		TimePlayed = SaveManager.GameData.TimePlayed;
		CanViewOnTop = SaveManager.GameData.CanViewOnTop == 1;
		SeeAllNodes = SaveManager.GameData.SeeAllNodes == 1;
		Money.Amount = SaveManager.GameData.Money;
		Book.Amount = SaveManager.GameData.Book;
		ResearchPoint.Amount = SaveManager.GameData.ResearchPoint;
		YellowPoint.Amount = SaveManager.GameData.YellowPoint;
		RedPoint.Amount = SaveManager.GameData.RedPoint;
		BluePoint.Amount = SaveManager.GameData.BluePoint;
		Money.TotalAmount = SaveManager.GameData.TotalMoney;
		Book.TotalAmount = SaveManager.GameData.TotalBook;
		ResearchPoint.TotalAmount = SaveManager.GameData.TotalResearchPoint;
		YellowPoint.TotalAmount = SaveManager.GameData.TotalYellowPoint;
		RedPoint.TotalAmount = SaveManager.GameData.TotalRedPoint;
		BluePoint.TotalAmount = SaveManager.GameData.TotalBluePoint;
		HoleFilled.Amount = SaveManager.GameData.HoleFilled;
		HoleFilled.TotalAmount = SaveManager.GameData.HoleFilled;
		TotalGarbageCreated = SaveManager.GameData.TotalGarbageCreated;
		TotalTossedGarbage = SaveManager.GameData.TotalTossedGarbage;
		TotalCloudClick = SaveManager.GameData.TotalCloudClick;
		TotalCloudClickDestroyed = SaveManager.GameData.TotalCloudClickDestroyed;
		TotalCloudDestroyed = SaveManager.GameData.TotalCloudDestroyed;
		TotalPeonTrashThrow = SaveManager.GameData.TotalPeonTrashThrow;
		TotalPeonThrow = SaveManager.GameData.TotalPeonThrow;
		TotalBlockedOutput = SaveManager.GameData.TotalBlockedOutput;
		Instance.Hole.DeadPeonCount = SaveManager.GameData.DeadPeonCount;
		Golem.SetupFromLoad(SaveManager.GameData.Golem_IsMoving == 1, SaveManager.GameData.Golem_IsDestroyed == 1, (float)SaveManager.GameData.Golem_X / 10f);
		Golem._trashWeight = SaveManager.GameData.Golem_TrashWeight;
		Golem._trashSize = SaveManager.GameData.Golem_TrashSize;
		PrestigeCount = SaveManager.GameData.PrestigeCount;
		for (int i = 0; i < SaveManager.GameData.AbilityDelay.Count; i++)
		{
			Ability.SetDelay(_abilities, (Ability.AbilityTypeEnum)i, SaveManager.GameData.AbilityDelay[i]);
		}
		if (SaveManager.GameData.Special == 8492)
		{
			CharDisplay.HasHat = true;
		}
		else
		{
			CharDisplay.HasHat = false;
		}
		if (SaveManager.GameData.IsRelax == 1)
		{
			CharDisplay.HasRelax = true;
		}
		else
		{
			CharDisplay.HasRelax = false;
		}
		GetMaxFilled();
		GlobalInfo.SetData(SaveKeyValueList.ToDictionary(SaveManager.GameData.MainUpgrades));
		foreach (CharacterData character in SaveManager.GameData.Characters)
		{
			PeonController.SpawnCharacterAtLocation(Instance.SpawnLocation.transform.position)._hapinessLeft = character.HapinessLeft;
		}
		foreach (BuildingData building in SaveManager.GameData.Buildings)
		{
			if (building.Index == 0)
			{
				continue;
			}
			if (building.Index >= ColumnsController.GetColumns().Count)
			{
				ColumnsController.AddEmptyColumn();
			}
			List<ColumnController> columns = ColumnsController.GetColumns();
			if (building.BuildingType == -1 || building.Index <= 0 || building.Index >= columns.Count)
			{
				continue;
			}
			columns[building.Index].CreateFirstBuilding((BaseBuilding.BuildingTypeEnum)building.BuildingType);
			Dictionary<string, int> dictionary = SaveKeyValueList.ToDictionary(building.Data);
			columns[building.Index].Buildings.SetData(dictionary);
			if (!dictionary.ContainsKey("WorkingCount"))
			{
				continue;
			}
			int num = dictionary["WorkingCount"];
			for (int j = 0; j < num; j++)
			{
				CharV2 charV = Instance.PeonController.FindWorkerForJob(columns[building.Index].Buildings);
				if (charV != null)
				{
					columns[building.Index].Buildings.AddWorker(charV);
				}
			}
		}
		ColumnsController.VerifyAndAddNewcolumn(addRocks: false);
		for (int k = 0; k < SaveManager.GameData.Garbage_X.Count; k++)
		{
			GarbageController.PreLoadGarbage(new Vector3((float)SaveManager.GameData.Garbage_X[k] / 10f, UnityEngine.Random.Range(-4f, 0f), 0f), SaveManager.GameData.Garbage_Weight[k], (GarbageInfo.GarbageTypeEnum)SaveManager.GameData.Garbage_GarbageType[k], (GarbageInfo.CameFromEnum)SaveManager.GameData.Garbage_CameFrom[k], SaveManager.GameData.Garbage_IsEvil[k] == 1, SaveManager.GameData.Garbage_IsZap[k] == 1);
		}
		for (int l = 0; l < SaveManager.GameData.Achievements.Count; l++)
		{
			foreach (AchievementDefinition achievement in Achievements)
			{
				if (achievement.AchievementType == (AchievementDefinition.AchievementTypeEnum)SaveManager.GameData.Achievements[l].Index)
				{
					achievement.IsActivated = SaveManager.GameData.Achievements[l].IsActivated == 1;
					achievement.CanActivate = SaveManager.GameData.Achievements[l].CanActivate == 1;
				}
			}
		}
	}

	public void SaveData()
	{
		DiskImage.gameObject.SetActive(value: true);
		SaveManager.ClearGameSaveData();
		SaveManager.GameData = new MainData();
		SaveManager.GameData.TimeCreated = DateTime.Now;
		SaveManager.GameData.TimePlayed = TimePlayed;
		SaveManager.GameData.TotalGarbageCreated = TotalGarbageCreated;
		SaveManager.GameData.TotalTossedGarbage = TotalTossedGarbage;
		SaveManager.GameData.TotalCloudClick = TotalCloudClick;
		SaveManager.GameData.TotalCloudClickDestroyed = TotalCloudClickDestroyed;
		SaveManager.GameData.TotalCloudDestroyed = TotalCloudDestroyed;
		SaveManager.GameData.TotalPeonTrashThrow = TotalPeonTrashThrow;
		SaveManager.GameData.TotalPeonThrow = TotalPeonThrow;
		SaveManager.GameData.TotalBlockedOutput = TotalBlockedOutput;
		SaveManager.GameData.CanViewOnTop = (CanViewOnTop ? 1 : 0);
		SaveManager.GameData.SeeAllNodes = (SeeAllNodes ? 1 : 0);
		SaveManager.GameData.DeadPeonCount = Instance.Hole.DeadPeonCount;
		SaveManager.GameData.Golem_IsMoving = (Golem.IsMoving ? 1 : 0);
		SaveManager.GameData.Golem_IsDestroyed = (Golem.IsDestroyed ? 1 : 0);
		SaveManager.GameData.Golem_X = (int)(Golem.transform.position.x * 10f);
		SaveManager.GameData.Golem_TrashWeight = Golem._trashWeight;
		SaveManager.GameData.Golem_TrashSize = Golem._trashSize;
		SaveManager.GameData.HoleFilled = HoleFilled.Amount;
		SaveManager.GameData.PrestigeCount = PrestigeCount;
		SaveManager.GameData.Money = Money.Amount;
		SaveManager.GameData.Book = Book.Amount;
		SaveManager.GameData.ResearchPoint = ResearchPoint.Amount;
		SaveManager.GameData.YellowPoint = YellowPoint.Amount;
		SaveManager.GameData.RedPoint = RedPoint.Amount;
		SaveManager.GameData.BluePoint = BluePoint.Amount;
		SaveManager.GameData.TotalMoney = Money.TotalAmount;
		SaveManager.GameData.TotalBook = Book.TotalAmount;
		SaveManager.GameData.TotalResearchPoint = ResearchPoint.TotalAmount;
		SaveManager.GameData.TotalYellowPoint = YellowPoint.TotalAmount;
		SaveManager.GameData.TotalRedPoint = RedPoint.TotalAmount;
		SaveManager.GameData.TotalBluePoint = BluePoint.TotalAmount;
		for (int i = 0; i < _abilities.Count; i++)
		{
			SaveManager.GameData.AbilityDelay.Add((int)Ability.GetDelay(_abilities, (Ability.AbilityTypeEnum)i));
		}
		SaveManager.GameData.MainUpgrades = SaveKeyValueList.FromDictionary(GlobalInfo.GetData());
		if (CharDisplay.HasHat)
		{
			SaveManager.GameData.Special = 8492;
		}
		else
		{
			SaveManager.GameData.Special = 0;
		}
		if (CharDisplay.HasRelax)
		{
			SaveManager.GameData.IsRelax = 1;
		}
		else
		{
			SaveManager.GameData.IsRelax = 0;
		}
		SaveManager.GameData.Characters.Clear();
		foreach (CharV2 character in PeonController.GetCharacters())
		{
			CharacterData characterData = new CharacterData();
			characterData.HapinessLeft = character._hapinessLeft;
			SaveManager.GameData.Characters.Add(characterData);
		}
		SaveManager.GameData.Buildings.Clear();
		int num = 0;
		List<GarbageData> list = new List<GarbageData>();
		foreach (ColumnController column in ColumnsController.GetColumns())
		{
			if (column.Buildings == null)
			{
				BuildingData buildingData = new BuildingData();
				buildingData.Index = num;
				buildingData.BuildingType = -1;
				SaveManager.GameData.Buildings.Add(buildingData);
			}
			else
			{
				BuildingData buildingData2 = new BuildingData();
				buildingData2.Index = num;
				buildingData2.BuildingType = (int)column.Buildings.BuildingType;
				buildingData2.Data = SaveKeyValueList.FromDictionary(column.Buildings.GetData());
				SaveManager.GameData.Buildings.Add(buildingData2);
				List<GarbageInfo> list2 = null;
				if (column.Buildings is Catapult)
				{
					list2 = ((Catapult)column.Buildings).GetAllStored();
				}
				else if (column.Buildings is Compressor)
				{
					list2 = ((Compressor)column.Buildings).GetAllStored();
				}
				else if (column.Buildings is HotAirStation)
				{
					list2 = ((HotAirStation)column.Buildings).GetAllStored();
				}
				if (list2 != null)
				{
					foreach (GarbageInfo item in list2)
					{
						GarbageData garbageData = new GarbageData();
						garbageData.X = column.Buildings.transform.position.x + UnityEngine.Random.Range(-2f, 2f);
						garbageData.GarbageType = (int)item.GarbageType;
						garbageData.CameFrom = (int)item.CameFrom;
						garbageData.Weight = item.Weight;
						garbageData.IsEvil = (item.IsEvil ? 1 : 0);
						garbageData.IsZap = (item.IsZap ? 1 : 0);
						list.Add(garbageData);
					}
				}
			}
			num++;
		}
		SaveManager.GameData.Garbage_X.Clear();
		SaveManager.GameData.Garbage_GarbageType.Clear();
		SaveManager.GameData.Garbage_CameFrom.Clear();
		SaveManager.GameData.Garbage_Weight.Clear();
		SaveManager.GameData.Garbage_IsEvil.Clear();
		SaveManager.GameData.Garbage_IsZap.Clear();
		foreach (Garbage activeGarbage in GarbageController.ActiveGarbages)
		{
			if (activeGarbage != null)
			{
				GarbageData garbageData2 = new GarbageData();
				garbageData2.X = activeGarbage.transform.position.x;
				garbageData2.GarbageType = (int)activeGarbage.Info.GarbageType;
				garbageData2.CameFrom = (int)activeGarbage.Info.CameFrom;
				garbageData2.Weight = activeGarbage.Info.Weight;
				garbageData2.IsEvil = (activeGarbage.Info.IsEvil ? 1 : 0);
				garbageData2.IsZap = (activeGarbage.Info.IsZap ? 1 : 0);
				list.Add(garbageData2);
			}
		}
		foreach (CharV2 character2 in PeonController.GetCharacters())
		{
			foreach (Garbage item2 in character2.GarbageInHand)
			{
				GarbageData garbageData3 = new GarbageData();
				garbageData3.X = character2.transform.position.x;
				garbageData3.GarbageType = (int)item2.Info.GarbageType;
				garbageData3.CameFrom = (int)item2.Info.CameFrom;
				garbageData3.Weight = item2.Info.Weight;
				garbageData3.IsEvil = (item2.Info.IsEvil ? 1 : 0);
				garbageData3.IsZap = (item2.Info.IsZap ? 1 : 0);
				list.Add(garbageData3);
			}
		}
		foreach (GarbageData item3 in list)
		{
			SaveManager.GameData.Garbage_X.Add((int)(item3.X * 10f));
			SaveManager.GameData.Garbage_GarbageType.Add(item3.GarbageType);
			SaveManager.GameData.Garbage_CameFrom.Add(item3.CameFrom);
			SaveManager.GameData.Garbage_Weight.Add(item3.Weight);
			SaveManager.GameData.Garbage_IsEvil.Add(item3.IsEvil);
			SaveManager.GameData.Garbage_IsZap.Add(item3.IsZap);
		}
		foreach (AchievementDefinition achievement in Achievements)
		{
			AchivementData achivementData = new AchivementData();
			achivementData.Index = (int)achievement.AchievementType;
			achivementData.IsActivated = (achievement.IsActivated ? 1 : 0);
			achivementData.CanActivate = (achievement.CanActivate ? 1 : 0);
			SaveManager.GameData.Achievements.Add(achivementData);
		}
		SaveManager.SaveGameData();
		DiskImage.gameObject.SetActive(value: false);
		LastSave = 0f;
	}

	public int ColorToInt(Color color)
	{
		int num = Mathf.Clamp((int)(color.r * 255f), 0, 255);
		int num2 = Mathf.Clamp((int)(color.g * 255f), 0, 255);
		int num3 = Mathf.Clamp((int)(color.b * 255f), 0, 255);
		int num4 = Mathf.Clamp((int)(color.a * 255f), 0, 255);
		return (num << 24) | (num2 << 16) | (num3 << 8) | num4;
	}

	public Color IntToColor(int colorInt)
	{
		float r = (float)((colorInt >> 24) & 0xFF) / 255f;
		float g = (float)((colorInt >> 16) & 0xFF) / 255f;
		float b = (float)((colorInt >> 8) & 0xFF) / 255f;
		float a = (float)(colorInt & 0xFF) / 255f;
		return new Color(r, g, b, a);
	}

	public float GetManualDestroyPercentage()
	{
		if (Power.GlobalInfo.CanMoreManualDestroyAttribute.IsEnabled)
		{
			return 0.2f + 0.1f * (float)Power.GlobalInfo.CanMoreManualDestroyAttribute.Level;
		}
		return 0.2f;
	}

	public float GetStabilityDestroyPercentage()
	{
		if (Power.GlobalInfo.CanMoreStabilityDestroyAttribute.IsEnabled)
		{
			return 0.7f + 0.1f * (float)Power.GlobalInfo.CanMoreStabilityDestroyAttribute.Level;
		}
		return 0.7f;
	}

	public float GetPrestigeDestroyPercentage()
	{
		return 0.75f;
	}

	public float GetPrestigeMoneyKeptPercentage()
	{
		return 0.1f + 0.1f * (float)Power.GlobalInfo.CanMorePrestigeAttribute.Level;
	}

	public void OpenSteam()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		if (!Installation.IsSteamConnected() || !ApiManager.Instance.OpenSteamForWishlist())
		{
			Application.OpenURL(Global.SteamUrl);
		}
	}

	public void OpenItch()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		Application.OpenURL(Global.ItchUrl);
	}

	public string GetTimePlayedString()
	{
		return DelaTimeToString(TimePlayed);
	}

	public static string DelaTimeToString(float timeDelta)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(timeDelta);
		if ((int)timeSpan.TotalDays > 0)
		{
			return (int)timeSpan.TotalDays + "d " + timeSpan.Hours + "h " + timeSpan.Minutes + "m " + timeSpan.Seconds + "s";
		}
		if ((int)timeSpan.TotalHours > 0)
		{
			return timeSpan.Hours + "h " + timeSpan.Minutes + "m " + timeSpan.Seconds + "s";
		}
		if ((int)timeSpan.TotalMinutes > 0)
		{
			return timeSpan.Minutes + "m " + timeSpan.Seconds + "s";
		}
		return (int)timeSpan.TotalSeconds + "s";
	}
}
