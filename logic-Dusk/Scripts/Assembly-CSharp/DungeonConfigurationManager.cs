using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public static class DungeonConfigurationManager
{
	public class DifficultyValues
	{
		public const float WEIGHT_INFESTATION = 0.75f;

		public const float WEIGHT_ENEMYRATIO = 0.75f;

		public const float WEIGHT_HULLINTEGRITY = 1f;

		public const float WEIGHT_TRANSPORTER = 0.5f;

		public const float WEIGHT_ASTEROID = 1f;

		public const float WEIGHT_EVENT_DOOR = 0.25f;

		public const float WEIGHT_EVENT_CLOSE = 0.25f;

		public const float WEIGHT_EVENT_CHEW = 0.3f;

		public const float WEIGHT_VENT = 0.1f;

		public float InfestationTypeValue { get; set; }

		public float EnemyRatioValue { get; set; }

		public float HullIntegrityValue { get; set; }

		public float TransporterValue { get; set; }

		public float AsteroidValue { get; set; }

		public float EventDoorValue { get; set; }

		public float EventCloseValue { get; set; }

		public float EventSwarmChewValue { get; set; }

		public float VentValue { get; set; }

		public float GetWeightedDifficulty()
		{
			float num = 4.9f;
			return (InfestationTypeValue * 0.75f + EnemyRatioValue * 0.75f + HullIntegrityValue * 1f + TransporterValue * 0.5f + AsteroidValue * 1f + EventDoorValue * 0.25f + EventCloseValue * 0.25f + EventSwarmChewValue * 0.3f + VentValue * 0.1f) / num;
		}
	}

	public class EarlyPlayConfiguration
	{
		public bool IsDesignedShip { get; set; }

		public string DesignedShipFile { get; set; }

		public int AgeMin { get; set; }

		public int AgeMax { get; set; }

		public int VisibleRationMin { get; set; }

		public int VisibleRationMax { get; set; }

		public int HiddenRationMin { get; set; }

		public int HiddenRationMax { get; set; }

		public int ScrapMax { get; set; }

		public int EnemyCountMin { get; set; }

		public int EnemyCountMax { get; set; }

		public ShipInfestationType[] EnemyTypes { get; set; }

		public string[] ShipTypes { get; set; }

		public bool AllowNormalEnemyLogic { get; set; }

		public DifficultyValues DifficultyValues { get; set; }
	}

	public class DungeonHelper
	{
		public class DungeonClassDefinition
		{
			public DungeonDefinition Parent { get; private set; }

			public string name { get; set; }

			public int minWidthOverride { get; set; }

			public int maxWidthOverride { get; set; }

			public float heightRatioOverride { get; set; }

			public int earlyPlayRankingOverride { get; set; }

			public int scrapContainerMin { get; set; }

			public int scrapContainerMax { get; set; }

			public int pfuelChargeContainerMin { get; set; }

			public int pfuelReserveContainerMax { get; set; }

			public string imageFileName { get; set; }

			public int chanceOfQuarentineOverride { get; set; }

			private DungeonClassDefinition()
			{
			}

			public DungeonClassDefinition(DungeonDefinition parent)
			{
				Parent = parent;
			}
		}

		public class DungeonDefinition
		{
			public enum UseTypeEnum
			{
				Normal = 0,
				ObjectiveOnly = 1,
				ObjectiveORNormal = 2
			}

			private List<DungeonClassDefinition> classList;

			public string name { get; private set; }

			public DungeonTypeEnum dungeonType { get; private set; }

			public int minWidth { get; set; }

			public int maxWidth { get; set; }

			public float heightRatio { get; set; }

			public int earlyPlayRanking { get; set; }

			public int scrapContainerMin { get; set; }

			public int scrapContainerMax { get; set; }

			public int pfuelChargeContainerMin { get; set; }

			public int pfuelReserveContainerMax { get; set; }

			public string imageFileName { get; set; }

			public bool suppressCommandeer { get; set; }

			public bool suppressPermShipUpgrades { get; set; }

			public string allowedShipTypes { get; set; }

			public int chanceOfQuarentine { get; set; }

			public UseTypeEnum useType { get; set; }

			public int CountClass
			{
				get
				{
					if (classList != null)
					{
						return classList.Count;
					}
					return 0;
				}
			}

			public int CountClassForDaily
			{
				get
				{
					if (classList != null)
					{
						return classList.Where((DungeonClassDefinition x) => x != null && x.name != "C" && x.name != "D").Count();
					}
					return 0;
				}
			}

			public DungeonPropertyHeader propertyHeader { get; set; }

			private DungeonDefinition()
			{
			}

			public DungeonDefinition(string name, DungeonTypeEnum dungeonType)
			{
				this.name = name;
				this.dungeonType = dungeonType;
			}

			public void AddClass(string name, int minWidthOverride, int maxWidthOverride, float heightRatioOverride, int earlyPlayRankingOverride, int scrapContainerMin, int scrapContainerMax, int pfuelChargeContainerMin, int pfuelReserveContainerMax, int chanceOfQuarentine, string imageFileName)
			{
				if (classList == null)
				{
					classList = new List<DungeonClassDefinition>();
				}
				DungeonClassDefinition dungeonClassDefinition = new DungeonClassDefinition(this);
				dungeonClassDefinition.name = name;
				dungeonClassDefinition.minWidthOverride = minWidthOverride;
				dungeonClassDefinition.maxWidthOverride = maxWidthOverride;
				dungeonClassDefinition.heightRatioOverride = heightRatioOverride;
				dungeonClassDefinition.earlyPlayRankingOverride = earlyPlayRankingOverride;
				dungeonClassDefinition.scrapContainerMin = scrapContainerMin;
				dungeonClassDefinition.scrapContainerMax = scrapContainerMax;
				dungeonClassDefinition.pfuelChargeContainerMin = pfuelChargeContainerMin;
				dungeonClassDefinition.pfuelReserveContainerMax = pfuelReserveContainerMax;
				dungeonClassDefinition.chanceOfQuarentineOverride = chanceOfQuarentine;
				dungeonClassDefinition.imageFileName = imageFileName;
				DungeonClassDefinition item = dungeonClassDefinition;
				classList.Add(item);
			}

			public DungeonClassDefinition GetClassDefinition(int classIdx)
			{
				if (classList != null && classList.Count > classIdx)
				{
					return classList[classIdx];
				}
				return null;
			}

			public List<DungeonClassDefinition> GetClassList()
			{
				return classList;
			}

			public string GetClassName(int classIdx)
			{
				if (classList != null && classList.Count > classIdx)
				{
					return classList[classIdx].name;
				}
				return string.Empty;
			}

			public Coordinate2D GetRandomSize(DungeonClassDefinition classDef, System.Random rnd)
			{
				int minWidthOverride = minWidth;
				int maxWidthOverride = maxWidth;
				float heightRatioOverride = heightRatio;
				int num = 0;
				int num2 = 0;
				if (classDef != null)
				{
					if (classDef.minWidthOverride != 0)
					{
						minWidthOverride = classDef.minWidthOverride;
					}
					if (classDef.maxWidthOverride != 0)
					{
						maxWidthOverride = classDef.maxWidthOverride;
					}
					if (classDef.heightRatioOverride != 0f)
					{
						heightRatioOverride = classDef.heightRatioOverride;
					}
				}
				num = ((rnd != null) ? rnd.Next(minWidthOverride, maxWidthOverride + 1) : UnityEngine.Random.Range(minWidthOverride, maxWidthOverride + 1));
				num2 = Mathf.RoundToInt((float)num * heightRatioOverride);
				return new Coordinate2D(num, num2);
			}
		}

		public class DungeonPropertyHeader
		{
			public float chanceRare { get; set; }

			public DungeonProperty propertyCommon { get; set; }

			public DungeonProperty propertyRare { get; set; }

			public DungeonRoomConfig dungeonRoomConfig { get; set; }
		}

		public class DungeonProperty
		{
			public bool hasAirlock { get; set; }

			public int airlockMin { get; set; }

			public int airlockMax { get; set; }

			public bool hasPowerGrid { get; set; }

			public int powerGridMin { get; set; }

			public int powerGridMax { get; set; }

			public bool hasTerminal { get; set; }

			public float terminalRatioMin { get; set; }

			public float terminalRatioMax { get; set; }

			public bool hasDefense { get; set; }

			public float defenseRatioMin { get; set; }

			public float defenseRatioMax { get; set; }

			public bool hasDrone { get; set; }

			public float droneRatioMin { get; set; }

			public float droneRatioMax { get; set; }

			public bool hasDroneQty { get; set; }

			public int droneQtyMin { get; set; }

			public int droneQtyMax { get; set; }

			public bool hasDroneDisabledChanceSet { get; set; }

			public int droneDisabledChance { get; set; }

			public bool hasShipUpgrade { get; set; }

			public float shipUpgradeRatioMin { get; set; }

			public float shipUpgradeRatioMax { get; set; }

			public bool hasShipUpgradeSecondWorkingChance { get; set; }

			public float shipUpgradeSecondWorkingChance { get; set; }

			public bool hasShipUpgradeQty { get; set; }

			public int shipUpgradeQtyMin { get; set; }

			public int shipUpgradeQtyMax { get; set; }

			public bool hasShipUpgradeWorkingChanceSet { get; set; }

			public int shipUpgradeWorkingChance { get; set; }

			public bool hasShipUpgradeBrokenChanceSet { get; set; }

			public int shipUpgradeBrokenChance { get; set; }

			public bool hasVisibleRations { get; set; }

			public bool hasHiddenRations { get; set; }

			public int rationVisibleMin { get; set; }

			public int rationVisibleMax { get; set; }

			public int rationHiddenMin { get; set; }

			public int rationHiddenMax { get; set; }

			public float rationRatioMin { get; set; }

			public float rationRatioMax { get; set; }

			public bool hasFuelAccess { get; set; }

			public bool hasChancePropulsionFuel { get; set; }

			public bool hasChanceJumpFuel { get; set; }

			public int fuelAccessMin { get; set; }

			public int fuelAccessMax { get; set; }

			public int chancePropulsionFuel { get; set; }

			public int chanceJumpFuel { get; set; }

			public int propulsionFuelMin { get; set; }

			public int propulsionFuelMax { get; set; }

			public int jumpFuelMin { get; set; }

			public int jumpFuelMax { get; set; }

			public bool hasTransporter { get; set; }

			public int transporterExtraMin { get; set; }

			public int transporterExtraMax { get; set; }
		}

		public class DungeonRoomConfig
		{
			public List<DungeonRoomConfigRoom> roomTileList { get; set; }

			public int roomWeight { get; set; }
		}

		public class DungeonRoomConfigRoom
		{
			public string name { get; set; }

			public int weight { get; set; }

			public int weightAdj { get; set; }

			public int tileWeight { get; set; }

			public int wallWeight { get; set; }

			public int debrisWeight { get; set; }

			public int propWeight { get; set; }

			public float debrisFactor { get; set; }

			public float propFactor { get; set; }

			public List<DungeonRoomConfigTile> tileList { get; set; }

			public List<DungeonRoomConfigWall> wallList { get; set; }

			public List<DungeonRoomConfigDebris> debrisList { get; set; }

			public List<DungeonRoomConfigProp> propList { get; set; }

			public string cornerFileName { get; set; }
		}

		public class DungeonAssetConfig
		{
			public string fileName { get; set; }

			public int weight { get; set; }

			public int weightAdj { get; set; }

			public override string ToString()
			{
				return string.Format("{0} - {1}", fileName, weight);
			}
		}

		public class DungeonRoomConfigTile : DungeonAssetConfig
		{
			public string longSide { get; set; }
		}

		public class DungeonRoomConfigWall : DungeonAssetConfig
		{
		}

		public class DungeonRoomConfigDebris : DungeonAssetConfig
		{
		}

		public class DungeonRoomConfigProp : DungeonAssetConfig
		{
			public int chanceOfRotate { get; set; }

			public float rotateMin { get; set; }

			public float rotateMax { get; set; }

			public bool excludeFromCollision { get; set; }
		}

		private static Dictionary<string, DungeonPropertyHeader> dungeonPropertyDict;

		private static List<DungeonDefinition> dungeonDefinitionList;

		public static void Initialize()
		{
			if (dungeonDefinitionList == null)
			{
				LoadDungeonTypeLibrary();
			}
		}

		public static void DeInitalize()
		{
			dungeonDefinitionList = null;
		}

		public static KeyValuePair<DungeonDefinition, DungeonClassDefinition> GetRandomEarlyPlayShipClass(string[] shipTypes)
		{
			DungeonDefinition key = null;
			DungeonClassDefinition value = null;
			if (dungeonDefinitionList == null)
			{
				Initialize();
			}
			if (shipTypes != null && shipTypes.Length > 0)
			{
				List<KeyValuePair<DungeonDefinition, DungeonClassDefinition>> list = new List<KeyValuePair<DungeonDefinition, DungeonClassDefinition>>();
				IEnumerable<DungeonDefinition> enumerable = dungeonDefinitionList.Where((DungeonDefinition x) => x != null && x.dungeonType == DungeonTypeEnum.Derelict);
				if (enumerable != null)
				{
					int num = 0;
					bool flag = false;
					do
					{
						int num2 = UnityEngine.Random.Range(0, shipTypes.Length);
						string[] shipNameParts = shipTypes[num2].Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						DungeonDefinition dungeonDefinition = enumerable.FirstOrDefault((DungeonDefinition x) => x != null && x.name.ToLower() == shipNameParts[0].ToLower());
						if (dungeonDefinition != null)
						{
							if (!string.IsNullOrEmpty(shipNameParts[1]))
							{
								List<DungeonClassDefinition> classList = dungeonDefinition.GetClassList();
								if (classList.Any((DungeonClassDefinition x) => x != null && x.name.ToLower() == shipNameParts[1].ToLower()))
								{
									key = dungeonDefinition;
									value = classList.First((DungeonClassDefinition x) => x != null && x.name.ToLower() == shipNameParts[1].ToLower());
									flag = true;
								}
							}
							else
							{
								key = dungeonDefinition;
								flag = true;
							}
						}
						num++;
					}
					while (num < 100 && !flag);
				}
			}
			return new KeyValuePair<DungeonDefinition, DungeonClassDefinition>(key, value);
		}

		public static KeyValuePair<DungeonDefinition, DungeonClassDefinition> GetRandomShipClass()
		{
			return GetRandomDungeonDefinition(DungeonTypeEnum.Derelict);
		}

		public static KeyValuePair<DungeonDefinition, DungeonClassDefinition> GetRandomStationClass()
		{
			return GetRandomDungeonDefinition(DungeonTypeEnum.Station);
		}

		public static KeyValuePair<DungeonDefinition, DungeonClassDefinition> GetRandomOutpostClass()
		{
			return GetRandomDungeonDefinition(DungeonTypeEnum.Outpost);
		}

		private static KeyValuePair<DungeonDefinition, DungeonClassDefinition> GetRandomDungeonDefinition(DungeonTypeEnum dungeonType)
		{
			DungeonDefinition key = null;
			DungeonClassDefinition value = null;
			if (dungeonDefinitionList == null)
			{
				Initialize();
			}
			IEnumerable<DungeonDefinition> enumerable = dungeonDefinitionList.Where((DungeonDefinition x) => x != null && x.dungeonType == dungeonType && x.useType != DungeonDefinition.UseTypeEnum.ObjectiveOnly);
			if (enumerable != null && enumerable.Count() > 0)
			{
				int index = UnityEngine.Random.Range(0, enumerable.Count());
				key = enumerable.ElementAt(index);
				if (enumerable.ElementAt(index).CountClass > 0)
				{
					value = ((GlobalSettings.gameMode == GameModeEnum.DailyChallenge) ? enumerable.ElementAt(index).GetClassDefinition(UnityEngine.Random.Range(0, enumerable.ElementAt(index).CountClassForDaily)) : enumerable.ElementAt(index).GetClassDefinition(UnityEngine.Random.Range(0, enumerable.ElementAt(index).CountClass)));
				}
			}
			return new KeyValuePair<DungeonDefinition, DungeonClassDefinition>(key, value);
		}

		public static List<DungeonDefinition> GetAllDungeonDefinition(DungeonTypeEnum dungeonType)
		{
			List<DungeonDefinition> list = new List<DungeonDefinition>();
			if (dungeonDefinitionList == null)
			{
				Initialize();
			}
			IEnumerable<DungeonDefinition> source = dungeonDefinitionList.Where((DungeonDefinition x) => x != null && x.dungeonType == dungeonType);
			return source.ToList();
		}

		public static KeyValuePair<DungeonDefinition, DungeonClassDefinition> GetDungeonDefinition(DungeonTypeEnum dungeonType, string defName)
		{
			return GetDungeonDefinition(dungeonType, defName, string.Empty);
		}

		public static KeyValuePair<DungeonDefinition, DungeonClassDefinition> GetDungeonDefinition(DungeonTypeEnum dungeonType, string defName, string className)
		{
			DungeonDefinition dungeonDefinition = null;
			DungeonClassDefinition value = null;
			if (dungeonDefinitionList == null)
			{
				Initialize();
			}
			dungeonDefinition = dungeonDefinitionList.FirstOrDefault((DungeonDefinition x) => x != null && x.dungeonType == dungeonType && x.name.ToLower() == defName.ToLower());
			if (dungeonDefinition != null && !string.IsNullOrEmpty(className))
			{
				value = dungeonDefinition.GetClassList().FirstOrDefault((DungeonClassDefinition x) => x != null && x.name.ToLower() == className.ToLower());
			}
			return new KeyValuePair<DungeonDefinition, DungeonClassDefinition>(dungeonDefinition, value);
		}

		private static void LoadDungeonTypeLibrary()
		{
			TextAsset textAsset = (TextAsset)Resources.Load("Data/DungeonDefinitions");
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(textAsset.text);
			XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//DungeonDefinitions/properties/property");
			dungeonPropertyDict = new Dictionary<string, DungeonPropertyHeader>();
			if (xmlNodeList.Count > 0)
			{
				foreach (XmlNode item in xmlNodeList)
				{
					if (item.Attributes["name"] == null)
					{
						Debug.LogError("<property>, in DungeonDefinisions, requires a 'name' attribute");
						continue;
					}
					DungeonPropertyHeader dungeonPropertyHeader = new DungeonPropertyHeader();
					string value = item.Attributes["name"].Value;
					dungeonPropertyDict.Add(value, dungeonPropertyHeader);
					foreach (XmlNode childNode in item.ChildNodes)
					{
						bool flag = true;
						bool flag2 = false;
						string text = childNode.Name.ToLower();
						switch (text)
						{
						case "rare":
						{
							string value2 = childNode.Attributes["chance"].Value;
							int result = 0;
							if (int.TryParse(value2, out result))
							{
								dungeonPropertyHeader.chanceRare = result;
							}
							break;
						}
						case "roomconfig":
							flag2 = true;
							break;
						default:
							flag = false;
							Debug.LogWarning(string.Format("'<Properties>' node includes unsupported child node with the name of '{0}'", text));
							break;
						case "common":
							break;
						}
						if (!flag)
						{
							continue;
						}
						if (!flag2)
						{
							DungeonProperty dungeonProperty = new DungeonProperty();
							XmlNodeList xmlNodeList2 = childNode.SelectNodes("add");
							foreach (XmlNode item2 in xmlNodeList2)
							{
								string value3 = item2.Attributes["type"].Value;
								string value4 = item2.Attributes["min"].Value;
								string value5 = item2.Attributes["max"].Value;
								float result2 = 0f;
								float result3 = 0f;
								float.TryParse(value4, out result2);
								float.TryParse(value5, out result3);
								switch (value3)
								{
								case "airlock":
									dungeonProperty.hasAirlock = true;
									dungeonProperty.airlockMin = (int)result2;
									dungeonProperty.airlockMax = (int)result3;
									break;
								case "terminal":
									dungeonProperty.hasTerminal = true;
									dungeonProperty.terminalRatioMin = result2;
									dungeonProperty.terminalRatioMax = result3;
									break;
								case "defense":
									dungeonProperty.hasDefense = true;
									dungeonProperty.defenseRatioMin = result2;
									dungeonProperty.defenseRatioMax = result3;
									break;
								case "drone":
									dungeonProperty.hasDrone = true;
									dungeonProperty.droneRatioMin = result2;
									dungeonProperty.droneRatioMax = result3;
									if (item2.Attributes["minQty"] != null || item2.Attributes["maxQty"] != null)
									{
										dungeonProperty.hasDroneQty = true;
										dungeonProperty.droneQtyMin = 0;
										dungeonProperty.droneQtyMax = int.MaxValue;
										if (item2.Attributes["minQty"] != null)
										{
											string value12 = item2.Attributes["minQty"].Value;
											int result10 = 0;
											if (int.TryParse(value12, out result10))
											{
												dungeonProperty.droneQtyMin = result10;
											}
										}
										if (item2.Attributes["maxQty"] != null)
										{
											string value13 = item2.Attributes["maxQty"].Value;
											int result11 = 0;
											if (int.TryParse(value13, out result11))
											{
												dungeonProperty.droneQtyMax = result11;
											}
										}
									}
									if (item2.Attributes["disabledChance"] != null)
									{
										string empty = string.Empty;
										int result12 = 0;
										empty = item2.Attributes["disabledChance"].Value;
										if (int.TryParse(empty, out result12))
										{
											dungeonProperty.droneDisabledChance = result12;
											dungeonProperty.hasDroneDisabledChanceSet = true;
										}
									}
									break;
								case "shipupgrade":
									dungeonProperty.hasShipUpgrade = true;
									dungeonProperty.shipUpgradeRatioMin = result2;
									dungeonProperty.shipUpgradeRatioMax = result3;
									if (item2.Attributes["minQty"] != null || item2.Attributes["maxQty"] != null)
									{
										dungeonProperty.hasShipUpgradeQty = true;
										dungeonProperty.shipUpgradeQtyMin = 0;
										dungeonProperty.shipUpgradeQtyMax = int.MaxValue;
										if (item2.Attributes["minQty"] != null)
										{
											string value14 = item2.Attributes["minQty"].Value;
											int result13 = 0;
											if (int.TryParse(value14, out result13))
											{
												dungeonProperty.shipUpgradeQtyMin = result13;
											}
										}
										if (item2.Attributes["maxQty"] != null)
										{
											string value15 = item2.Attributes["maxQty"].Value;
											int result14 = 0;
											if (int.TryParse(value15, out result14))
											{
												dungeonProperty.shipUpgradeQtyMax = result14;
											}
										}
									}
									if (item2.Attributes["filledChanceWorking"] != null)
									{
										string empty2 = string.Empty;
										int result15 = 0;
										empty2 = item2.Attributes["filledChanceWorking"].Value;
										if (int.TryParse(empty2, out result15))
										{
											dungeonProperty.shipUpgradeWorkingChance = result15;
											dungeonProperty.hasShipUpgradeWorkingChanceSet = true;
										}
									}
									if (item2.Attributes["filledChanceBroken"] != null)
									{
										string empty3 = string.Empty;
										int result16 = 0;
										empty3 = item2.Attributes["filledChanceBroken"].Value;
										if (int.TryParse(empty3, out result16))
										{
											dungeonProperty.shipUpgradeBrokenChance = result16;
											dungeonProperty.hasShipUpgradeBrokenChanceSet = true;
										}
									}
									if (item2.Attributes["secondWorkingChance"] != null)
									{
										string empty4 = string.Empty;
										int result17 = 0;
										empty4 = item2.Attributes["secondWorkingChance"].Value;
										if (int.TryParse(empty4, out result17))
										{
											dungeonProperty.shipUpgradeSecondWorkingChance = result17;
											dungeonProperty.hasShipUpgradeSecondWorkingChance = true;
										}
									}
									break;
								case "powergrid":
									dungeonProperty.hasPowerGrid = true;
									dungeonProperty.powerGridMin = (int)result2;
									dungeonProperty.powerGridMax = (int)result3;
									break;
								case "ration":
									dungeonProperty.hasVisibleRations = true;
									dungeonProperty.rationVisibleMin = (int)result2;
									dungeonProperty.rationVisibleMax = (int)result3;
									if (item2.Attributes["minHidden"] != null || item2.Attributes["maxHidden"] != null)
									{
										dungeonProperty.hasHiddenRations = true;
										dungeonProperty.rationHiddenMin = 0;
										dungeonProperty.rationHiddenMax = int.MaxValue;
										if (item2.Attributes["minHidden"] != null)
										{
											string value8 = item2.Attributes["minHidden"].Value;
											int result6 = 0;
											if (int.TryParse(value8, out result6))
											{
												dungeonProperty.rationHiddenMin = result6;
											}
										}
										if (item2.Attributes["maxHidden"] != null)
										{
											string value9 = item2.Attributes["maxHidden"].Value;
											int result7 = 0;
											if (int.TryParse(value9, out result7))
											{
												dungeonProperty.rationHiddenMax = result7;
											}
										}
									}
									if (item2.Attributes["roomFactorMin"] == null && item2.Attributes["roomFactorMax"] == null)
									{
										break;
									}
									dungeonProperty.rationRatioMin = 0f;
									dungeonProperty.rationRatioMax = 0f;
									if (item2.Attributes["roomFactorMin"] != null)
									{
										string value10 = item2.Attributes["roomFactorMin"].Value;
										float result8 = 0f;
										if (float.TryParse(value10, out result8))
										{
											dungeonProperty.rationRatioMin = result8;
										}
									}
									if (item2.Attributes["roomFactorMax"] != null)
									{
										string value11 = item2.Attributes["roomFactorMax"].Value;
										float result9 = 0f;
										if (float.TryParse(value11, out result9))
										{
											dungeonProperty.rationRatioMax = result9;
										}
									}
									break;
								case "fuelaccess":
								{
									dungeonProperty.hasFuelAccess = true;
									dungeonProperty.fuelAccessMin = (int)result2;
									dungeonProperty.fuelAccessMax = (int)result3;
									if (item2.Attributes["chancePropulsionFuel"] != null)
									{
										dungeonProperty.hasChancePropulsionFuel = true;
										dungeonProperty.propulsionFuelMin = 0;
										dungeonProperty.propulsionFuelMax = int.MaxValue;
										string value6 = item2.Attributes["chancePropulsionFuel"].Value;
										int result4 = 0;
										if (int.TryParse(value6, out result4))
										{
											dungeonProperty.chancePropulsionFuel = result4;
										}
										if (item2.Attributes["minPropulsionFuel"] != null)
										{
											value6 = item2.Attributes["minPropulsionFuel"].Value;
											if (int.TryParse(value6, out result4))
											{
												dungeonProperty.propulsionFuelMin = result4;
											}
										}
										if (item2.Attributes["maxPropulsionFuel"] != null)
										{
											value6 = item2.Attributes["maxPropulsionFuel"].Value;
											if (int.TryParse(value6, out result4))
											{
												dungeonProperty.propulsionFuelMax = result4;
											}
										}
									}
									if (item2.Attributes["chanceJumpFuel"] == null)
									{
										break;
									}
									dungeonProperty.hasChanceJumpFuel = true;
									dungeonProperty.jumpFuelMin = 0;
									dungeonProperty.jumpFuelMax = int.MaxValue;
									string value7 = item2.Attributes["chanceJumpFuel"].Value;
									int result5 = 0;
									if (int.TryParse(value7, out result5))
									{
										dungeonProperty.chanceJumpFuel = result5;
									}
									if (dungeonProperty.chanceJumpFuel <= 0)
									{
										break;
									}
									if (item2.Attributes["minJumpFuel"] != null)
									{
										value7 = item2.Attributes["minJumpFuel"].Value;
										if (int.TryParse(value7, out result5))
										{
											dungeonProperty.jumpFuelMin = result5;
										}
									}
									if (item2.Attributes["maxJumpFuel"] != null)
									{
										value7 = item2.Attributes["maxJumpFuel"].Value;
										if (int.TryParse(value7, out result5))
										{
											dungeonProperty.jumpFuelMax = result5;
										}
									}
									break;
								}
								case "transport":
									dungeonProperty.hasTransporter = true;
									dungeonProperty.transporterExtraMin = (int)result2;
									dungeonProperty.transporterExtraMax = (int)result3;
									break;
								}
								if (text == "common")
								{
									dungeonPropertyHeader.propertyCommon = dungeonProperty;
								}
								else if (text == "rare")
								{
									dungeonPropertyHeader.propertyRare = dungeonProperty;
								}
							}
							continue;
						}
						DungeonRoomConfig dungeonRoomConfig = new DungeonRoomConfig();
						dungeonRoomConfig.roomTileList = new List<DungeonRoomConfigRoom>();
						foreach (XmlNode childNode2 in childNode.ChildNodes)
						{
							DungeonRoomConfigRoom dungeonRoomConfigRoom = new DungeonRoomConfigRoom();
							dungeonRoomConfigRoom.name = ((childNode2.Attributes["name"] == null) ? "err" : childNode2.Attributes["name"].Value);
							dungeonRoomConfigRoom.weight = ((childNode2.Attributes["weight"] != null) ? Convert.ToInt32(childNode2.Attributes["weight"].Value) : 0);
							dungeonRoomConfig.roomWeight += dungeonRoomConfigRoom.weight;
							dungeonRoomConfigRoom.weightAdj = dungeonRoomConfig.roomWeight;
							foreach (XmlNode childNode3 in childNode2.ChildNodes)
							{
								string text2 = childNode3.Name.ToLower();
								switch (text2)
								{
								case "corner":
									dungeonRoomConfigRoom.cornerFileName = ((childNode3.Attributes["file"] == null) ? "err" : childNode3.Attributes["file"].Value);
									continue;
								case "debris":
								{
									float result19 = 1f;
									if (childNode3.Attributes["factor"] != null && !float.TryParse(childNode3.Attributes["factor"].Value, out result19))
									{
										result19 = 1f;
									}
									dungeonRoomConfigRoom.debrisFactor = result19;
									break;
								}
								case "prop":
								{
									float result18 = 1f;
									if (childNode3.Attributes["factor"] != null && !float.TryParse(childNode3.Attributes["factor"].Value, out result18))
									{
										result18 = 1f;
									}
									dungeonRoomConfigRoom.propFactor = result18;
									break;
								}
								}
								XmlNodeList xmlNodeList3 = childNode3.SelectNodes("add");
								foreach (XmlNode item3 in xmlNodeList3)
								{
									DungeonAssetConfig dungeonAssetConfig = null;
									switch (text2)
									{
									case "tile":
										dungeonAssetConfig = new DungeonRoomConfigTile();
										dungeonAssetConfig.fileName = ((item3.Attributes["file"] == null) ? "err" : item3.Attributes["file"].Value);
										dungeonAssetConfig.weight = ((item3.Attributes["weight"] != null) ? Convert.ToInt32(item3.Attributes["weight"].Value) : 0);
										((DungeonRoomConfigTile)dungeonAssetConfig).longSide = ((item3.Attributes["longSide"] == null) ? string.Empty : item3.Attributes["longSide"].Value);
										dungeonRoomConfigRoom.tileWeight += dungeonAssetConfig.weight;
										dungeonAssetConfig.weightAdj = dungeonRoomConfigRoom.tileWeight;
										if (dungeonRoomConfigRoom.tileList == null)
										{
											dungeonRoomConfigRoom.tileList = new List<DungeonRoomConfigTile>();
										}
										dungeonRoomConfigRoom.tileList.Add((DungeonRoomConfigTile)dungeonAssetConfig);
										break;
									case "wall":
										dungeonAssetConfig = new DungeonRoomConfigWall();
										dungeonAssetConfig.fileName = ((item3.Attributes["file"] == null) ? "err" : item3.Attributes["file"].Value);
										dungeonAssetConfig.weight = ((item3.Attributes["weight"] != null) ? Convert.ToInt32(item3.Attributes["weight"].Value) : 0);
										dungeonRoomConfigRoom.wallWeight += dungeonAssetConfig.weight;
										dungeonAssetConfig.weightAdj = dungeonRoomConfigRoom.wallWeight;
										if (dungeonRoomConfigRoom.wallList == null)
										{
											dungeonRoomConfigRoom.wallList = new List<DungeonRoomConfigWall>();
										}
										dungeonRoomConfigRoom.wallList.Add((DungeonRoomConfigWall)dungeonAssetConfig);
										break;
									case "debris":
										dungeonAssetConfig = new DungeonRoomConfigDebris();
										dungeonAssetConfig.fileName = ((item3.Attributes["file"] == null) ? "err" : item3.Attributes["file"].Value);
										dungeonAssetConfig.weight = ((item3.Attributes["weight"] != null) ? Convert.ToInt32(item3.Attributes["weight"].Value) : 0);
										dungeonRoomConfigRoom.debrisWeight += dungeonAssetConfig.weight;
										dungeonAssetConfig.weightAdj = dungeonRoomConfigRoom.debrisWeight;
										if (dungeonRoomConfigRoom.debrisList == null)
										{
											dungeonRoomConfigRoom.debrisList = new List<DungeonRoomConfigDebris>();
										}
										dungeonRoomConfigRoom.debrisList.Add((DungeonRoomConfigDebris)dungeonAssetConfig);
										break;
									case "prop":
									{
										dungeonAssetConfig = new DungeonRoomConfigProp();
										dungeonAssetConfig.fileName = ((item3.Attributes["file"] == null) ? "err" : item3.Attributes["file"].Value);
										dungeonAssetConfig.weight = ((item3.Attributes["weight"] != null) ? Convert.ToInt32(item3.Attributes["weight"].Value) : 0);
										((DungeonRoomConfigProp)dungeonAssetConfig).chanceOfRotate = ((item3.Attributes["chanceOfRotate"] == null) ? 20 : Convert.ToInt32(item3.Attributes["chanceOfRotate"].Value));
										float result20 = -180f;
										float result21 = 180f;
										string s = ((item3.Attributes["rotateMin"] == null) ? "-180" : item3.Attributes["weight"].Value);
										string s2 = ((item3.Attributes["rotateMax"] == null) ? "180" : item3.Attributes["rotateMax"].Value);
										float.TryParse(s, out result20);
										float.TryParse(s2, out result21);
										((DungeonRoomConfigProp)dungeonAssetConfig).rotateMin = result20;
										((DungeonRoomConfigProp)dungeonAssetConfig).rotateMax = result21;
										((DungeonRoomConfigProp)dungeonAssetConfig).excludeFromCollision = item3.Attributes["excludeFromCollision"] != null && Convert.ToBoolean(item3.Attributes["excludeFromCollision"].Value);
										dungeonRoomConfigRoom.propWeight += dungeonAssetConfig.weight;
										dungeonAssetConfig.weightAdj = dungeonRoomConfigRoom.propWeight;
										if (dungeonRoomConfigRoom.propList == null)
										{
											dungeonRoomConfigRoom.propList = new List<DungeonRoomConfigProp>();
										}
										dungeonRoomConfigRoom.propList.Add((DungeonRoomConfigProp)dungeonAssetConfig);
										break;
									}
									default:
										Debug.LogWarning(string.Format("'<room>' node includes unsupported child node with the name of '{0}'", text2));
										break;
									}
								}
							}
							dungeonRoomConfig.roomTileList.Add(dungeonRoomConfigRoom);
						}
						dungeonPropertyHeader.dungeonRoomConfig = dungeonRoomConfig;
					}
				}
				if (dungeonPropertyDict.ContainsKey("default"))
				{
					DungeonProperty propertyCommon = dungeonPropertyDict["default"].propertyCommon;
					Dictionary<string, DungeonPropertyHeader>.Enumerator enumerator7 = dungeonPropertyDict.GetEnumerator();
					while (enumerator7.MoveNext())
					{
						if (!(enumerator7.Current.Key != "default"))
						{
							continue;
						}
						for (int i = 0; i < 2; i++)
						{
							DungeonProperty dungeonProperty2 = null;
							switch (i)
							{
							case 0:
								dungeonProperty2 = enumerator7.Current.Value.propertyCommon;
								break;
							case 1:
								dungeonProperty2 = enumerator7.Current.Value.propertyRare;
								break;
							}
							if (dungeonProperty2 == null)
							{
								dungeonProperty2 = propertyCommon;
							}
							else
							{
								if (propertyCommon.hasAirlock && !dungeonProperty2.hasAirlock)
								{
									dungeonProperty2.hasAirlock = true;
									dungeonProperty2.airlockMin = propertyCommon.airlockMin;
									dungeonProperty2.airlockMax = propertyCommon.airlockMax;
								}
								if (propertyCommon.hasDefense && !dungeonProperty2.hasDefense)
								{
									dungeonProperty2.hasDefense = true;
									dungeonProperty2.defenseRatioMin = propertyCommon.defenseRatioMin;
									dungeonProperty2.defenseRatioMax = propertyCommon.defenseRatioMax;
								}
								if (propertyCommon.hasDrone && !dungeonProperty2.hasDrone)
								{
									dungeonProperty2.hasDrone = true;
									dungeonProperty2.droneRatioMin = propertyCommon.droneRatioMin;
									dungeonProperty2.droneRatioMax = propertyCommon.droneRatioMax;
								}
								if (propertyCommon.hasDroneQty && !dungeonProperty2.hasDroneQty)
								{
									dungeonProperty2.hasDroneQty = true;
									dungeonProperty2.droneQtyMin = propertyCommon.droneQtyMin;
									dungeonProperty2.droneQtyMax = propertyCommon.droneQtyMax;
								}
								if (propertyCommon.hasDroneDisabledChanceSet && !dungeonProperty2.hasDroneDisabledChanceSet)
								{
									dungeonProperty2.hasDroneDisabledChanceSet = true;
									dungeonProperty2.droneDisabledChance = propertyCommon.droneDisabledChance;
								}
								if (propertyCommon.hasPowerGrid && !dungeonProperty2.hasPowerGrid)
								{
									dungeonProperty2.hasPowerGrid = true;
									dungeonProperty2.powerGridMin = propertyCommon.powerGridMin;
									dungeonProperty2.powerGridMax = propertyCommon.powerGridMax;
								}
								if (propertyCommon.hasTerminal && !dungeonProperty2.hasTerminal)
								{
									dungeonProperty2.hasTerminal = true;
									dungeonProperty2.terminalRatioMin = propertyCommon.terminalRatioMin;
									dungeonProperty2.terminalRatioMax = propertyCommon.terminalRatioMax;
								}
								if (propertyCommon.hasShipUpgrade && !dungeonProperty2.hasShipUpgrade)
								{
									dungeonProperty2.hasShipUpgrade = true;
									dungeonProperty2.shipUpgradeRatioMin = propertyCommon.shipUpgradeRatioMin;
									dungeonProperty2.shipUpgradeRatioMax = propertyCommon.shipUpgradeRatioMax;
								}
								if (propertyCommon.hasShipUpgradeQty && !dungeonProperty2.hasShipUpgradeQty)
								{
									dungeonProperty2.hasShipUpgradeQty = true;
									dungeonProperty2.shipUpgradeQtyMin = propertyCommon.shipUpgradeQtyMin;
									dungeonProperty2.shipUpgradeQtyMax = propertyCommon.shipUpgradeQtyMax;
								}
								if (propertyCommon.hasShipUpgradeSecondWorkingChance && !dungeonProperty2.hasShipUpgradeSecondWorkingChance)
								{
									dungeonProperty2.hasShipUpgradeSecondWorkingChance = true;
									dungeonProperty2.shipUpgradeSecondWorkingChance = propertyCommon.shipUpgradeSecondWorkingChance;
								}
								if (propertyCommon.hasShipUpgradeWorkingChanceSet && !dungeonProperty2.hasShipUpgradeWorkingChanceSet)
								{
									dungeonProperty2.hasShipUpgradeWorkingChanceSet = true;
									dungeonProperty2.shipUpgradeWorkingChance = propertyCommon.shipUpgradeWorkingChance;
								}
								if (propertyCommon.hasShipUpgradeBrokenChanceSet && !dungeonProperty2.hasShipUpgradeBrokenChanceSet)
								{
									dungeonProperty2.hasShipUpgradeBrokenChanceSet = true;
									dungeonProperty2.shipUpgradeBrokenChance = propertyCommon.shipUpgradeBrokenChance;
								}
								if (propertyCommon.hasVisibleRations && !dungeonProperty2.hasVisibleRations)
								{
									dungeonProperty2.hasVisibleRations = true;
									dungeonProperty2.rationVisibleMin = propertyCommon.rationVisibleMin;
									dungeonProperty2.rationVisibleMax = propertyCommon.rationVisibleMax;
									dungeonProperty2.rationRatioMin = propertyCommon.rationRatioMin;
									dungeonProperty2.rationRatioMax = propertyCommon.rationRatioMax;
								}
								if (propertyCommon.hasHiddenRations && !dungeonProperty2.hasHiddenRations)
								{
									dungeonProperty2.hasHiddenRations = true;
									dungeonProperty2.rationHiddenMin = propertyCommon.rationHiddenMin;
									dungeonProperty2.rationHiddenMax = propertyCommon.rationHiddenMax;
								}
								if (propertyCommon.hasFuelAccess && !dungeonProperty2.hasFuelAccess)
								{
									dungeonProperty2.hasFuelAccess = true;
									dungeonProperty2.fuelAccessMin = propertyCommon.fuelAccessMin;
									dungeonProperty2.fuelAccessMax = propertyCommon.fuelAccessMax;
								}
								if (propertyCommon.hasTransporter && !dungeonProperty2.hasTransporter)
								{
									dungeonProperty2.hasTransporter = true;
									dungeonProperty2.transporterExtraMin = propertyCommon.transporterExtraMin;
									dungeonProperty2.transporterExtraMax = propertyCommon.transporterExtraMax;
								}
								if (propertyCommon.hasChancePropulsionFuel && !dungeonProperty2.hasChancePropulsionFuel)
								{
									dungeonProperty2.hasChancePropulsionFuel = true;
									dungeonProperty2.chancePropulsionFuel = propertyCommon.chancePropulsionFuel;
									dungeonProperty2.propulsionFuelMin = propertyCommon.propulsionFuelMin;
									dungeonProperty2.propulsionFuelMax = propertyCommon.propulsionFuelMax;
								}
								if (propertyCommon.hasChanceJumpFuel && !dungeonProperty2.hasChanceJumpFuel)
								{
									dungeonProperty2.hasChanceJumpFuel = true;
									dungeonProperty2.chanceJumpFuel = propertyCommon.chanceJumpFuel;
									dungeonProperty2.jumpFuelMin = propertyCommon.jumpFuelMin;
									dungeonProperty2.jumpFuelMax = propertyCommon.jumpFuelMax;
								}
							}
							switch (i)
							{
							case 0:
								enumerator7.Current.Value.propertyCommon = dungeonProperty2;
								break;
							case 1:
								enumerator7.Current.Value.propertyRare = dungeonProperty2;
								break;
							}
						}
						if (enumerator7.Current.Value.dungeonRoomConfig == null)
						{
							enumerator7.Current.Value.dungeonRoomConfig = dungeonPropertyDict["default"].dungeonRoomConfig;
						}
					}
				}
			}
			XmlNodeList xmlNodeList4 = xmlDocument.SelectNodes("//DungeonDefinitions/definition");
			dungeonDefinitionList = new List<DungeonDefinition>();
			foreach (XmlNode item4 in xmlNodeList4)
			{
				DungeonDefinition dungeonDefinition = new DungeonDefinition(item4.Attributes["name"].Value, (DungeonTypeEnum)(int)Enum.Parse(typeof(DungeonTypeEnum), item4.Attributes["type"].Value, true));
				dungeonDefinition.minWidth = ((item4.Attributes["minWidth"] != null) ? Convert.ToInt32(item4.Attributes["minWidth"].Value) : 0);
				dungeonDefinition.maxWidth = ((item4.Attributes["maxWidth"] != null) ? Convert.ToInt32(item4.Attributes["maxWidth"].Value) : 0);
				dungeonDefinition.earlyPlayRanking = ((item4.Attributes["earlyPlayRanking"] != null) ? Convert.ToInt32(item4.Attributes["earlyPlayRanking"].Value) : 0);
				dungeonDefinition.scrapContainerMin = ((item4.Attributes["scrapContainerMin"] == null) ? 50 : Convert.ToInt32(item4.Attributes["scrapContainerMin"].Value));
				dungeonDefinition.scrapContainerMax = ((item4.Attributes["scrapContainerMax"] == null) ? 50 : Convert.ToInt32(item4.Attributes["scrapContainerMax"].Value));
				dungeonDefinition.pfuelChargeContainerMin = ((item4.Attributes["pfuelChargeContainerMin"] == null) ? 6 : Convert.ToInt32(item4.Attributes["pfuelChargeContainerMin"].Value));
				dungeonDefinition.pfuelReserveContainerMax = ((item4.Attributes["pfuelReserveContainerMax"] == null) ? 6 : Convert.ToInt32(item4.Attributes["pfuelReserveContainerMax"].Value));
				dungeonDefinition.imageFileName = ((item4.Attributes["image"] == null) ? string.Empty : item4.Attributes["image"].Value);
				dungeonDefinition.suppressCommandeer = item4.Attributes["suppressCommandeer"] != null && Convert.ToBoolean(item4.Attributes["suppressCommandeer"].Value);
				dungeonDefinition.suppressPermShipUpgrades = item4.Attributes["suppressPermShipUpgrades"] != null && Convert.ToBoolean(item4.Attributes["suppressPermShipUpgrades"].Value);
				dungeonDefinition.allowedShipTypes = ((item4.Attributes["allowedShipTypes"] == null) ? "all" : item4.Attributes["allowedShipTypes"].Value.ToLower());
				dungeonDefinition.chanceOfQuarentine = ((item4.Attributes["chanceOfQuarentine"] != null) ? Convert.ToInt32(item4.Attributes["chanceOfQuarentine"].Value) : 0);
				DungeonDefinition dungeonDefinition2 = dungeonDefinition;
				if (item4.Attributes["sizeRatio"] != null)
				{
					string value16 = item4.Attributes["sizeRatio"].Value;
					if (!string.IsNullOrEmpty(value16))
					{
						string[] array = value16.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length == 2)
						{
							float num = Convert.ToInt32(array[0]);
							float num2 = Convert.ToInt32(array[1]);
							if (num != 1f)
							{
								if (num > 1f)
								{
									num2 /= num;
									num /= num;
									dungeonDefinition2.heightRatio = num2;
								}
								else
								{
									Debug.LogWarning(string.Format("DungeonDefinitions.xml has a bad heightRatio value on the '{0}' definition: {1}.  The first value must be => 1.", dungeonDefinition2.name, value16));
								}
							}
							else
							{
								dungeonDefinition2.heightRatio = num2;
							}
						}
						else
						{
							Debug.LogWarning(string.Format("DungeonDefinitions.xml has a bad heightRatio value on the '{0}' definition: {1}.  Expected format is N:M OR set leave off (or make empty) if you expect the ratio to come from a class override.", dungeonDefinition2.name, value16));
						}
					}
				}
				if (item4.Attributes["useType"] != null)
				{
					string value17 = item4.Attributes["useType"].Value;
					try
					{
						dungeonDefinition2.useType = (DungeonDefinition.UseTypeEnum)(int)Enum.Parse(typeof(DungeonDefinition.UseTypeEnum), value17, true);
					}
					catch (Exception)
					{
						dungeonDefinition2.useType = DungeonDefinition.UseTypeEnum.Normal;
					}
				}
				XmlNodeList xmlNodeList5 = item4.SelectNodes("class");
				if (xmlNodeList5.Count > 0)
				{
					foreach (XmlNode item5 in xmlNodeList5)
					{
						string value18 = item5.Attributes["name"].Value;
						int minWidthOverride = ((item5.Attributes["minWidth"] != null) ? Convert.ToInt32(item5.Attributes["minWidth"].Value) : 0);
						int maxWidthOverride = ((item5.Attributes["maxWidth"] != null) ? Convert.ToInt32(item5.Attributes["maxWidth"].Value) : 0);
						int earlyPlayRankingOverride = ((item5.Attributes["earlyPlayRanking"] != null) ? Convert.ToInt32(item5.Attributes["earlyPlayRanking"].Value) : 0);
						int scrapContainerMin = ((item5.Attributes["scrapContainerMin"] == null) ? dungeonDefinition2.scrapContainerMin : Convert.ToInt32(item5.Attributes["scrapContainerMin"].Value));
						int scrapContainerMax = ((item5.Attributes["scrapContainerMax"] == null) ? dungeonDefinition2.scrapContainerMax : Convert.ToInt32(item5.Attributes["scrapContainerMax"].Value));
						int pfuelChargeContainerMin = ((item5.Attributes["pfuelChargeContainerMin"] == null) ? dungeonDefinition2.pfuelChargeContainerMin : Convert.ToInt32(item5.Attributes["pfuelChargeContainerMin"].Value));
						int pfuelReserveContainerMax = ((item5.Attributes["pfuelReserveContainerMax"] == null) ? dungeonDefinition2.pfuelReserveContainerMax : Convert.ToInt32(item5.Attributes["pfuelReserveContainerMax"].Value));
						int chanceOfQuarentine = ((item5.Attributes["chanceOfQuarentine"] == null) ? dungeonDefinition2.chanceOfQuarentine : Convert.ToInt32(item5.Attributes["chanceOfQuarentine"].Value));
						string imageFileName = ((item5.Attributes["image"] == null) ? string.Empty : item5.Attributes["image"].Value);
						string text3 = ((item5.Attributes["scrapContainerFactor"] == null) ? "1" : item5.Attributes["scrapContainerFactor"].Value);
						float heightRatioOverride = 0f;
						if (item5.Attributes["sizeRatio"] != null)
						{
							string value19 = item5.Attributes["sizeRatio"].Value;
							if (!string.IsNullOrEmpty(value19))
							{
								string[] array2 = value19.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
								if (array2.Length == 2)
								{
									float num3 = Convert.ToInt32(array2[0]);
									float num4 = Convert.ToInt32(array2[1]);
									if (num3 != 1f)
									{
										if (num3 > 1f)
										{
											num4 /= num3;
											num3 /= num3;
											heightRatioOverride = num4;
										}
										else
										{
											Debug.LogWarning(string.Format("DungeonDefinitions.xml has a bad heightRatio value on the '{0}' definition, for class '{1}': {2}.  The first value must be => 1.", dungeonDefinition2.name, value18, value19));
										}
									}
								}
								else
								{
									Debug.LogWarning(string.Format("DungeonDefinitions.xml has a bad heightRatio value on the '{0}' definition, for class '{1}': {2}.  Expected format is N:M OR set leave off (or make empty) if you expect the ratio to come from a class override.", dungeonDefinition2.name, value18, value19));
								}
							}
						}
						if (item5.Attributes["property"] != null)
						{
							string value20 = item5.Attributes["property"].Value;
							if (dungeonPropertyDict.ContainsKey(value20))
							{
								dungeonDefinition2.propertyHeader = dungeonPropertyDict[value20];
							}
						}
						else if (dungeonPropertyDict.ContainsKey("default"))
						{
							dungeonDefinition2.propertyHeader = dungeonPropertyDict["default"];
						}
						dungeonDefinition2.AddClass(value18, minWidthOverride, maxWidthOverride, heightRatioOverride, earlyPlayRankingOverride, scrapContainerMin, scrapContainerMax, pfuelChargeContainerMin, pfuelReserveContainerMax, chanceOfQuarentine, imageFileName);
					}
				}
				else if (item4.Attributes["property"] != null)
				{
					string value21 = item4.Attributes["property"].Value;
					if (dungeonPropertyDict.ContainsKey(value21))
					{
						dungeonDefinition2.propertyHeader = dungeonPropertyDict[value21];
					}
				}
				else if (dungeonPropertyDict.ContainsKey("default"))
				{
					dungeonDefinition2.propertyHeader = dungeonPropertyDict["default"];
				}
				dungeonDefinitionList.Add(dungeonDefinition2);
			}
		}
	}

	public const int NUMBEROF_STARTER_SYSTEMS = 4;

	public static int GetDungeonConfigurationSeed(DungeonInfo dungeon)
	{
		int num = -1;
		num = GalaxySaveFile.Get(dungeon.GroupKey, "SEED_C", -1);
		if (num == -1)
		{
			int seed = UnityEngine.Random.seed;
			num = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
			GalaxySaveFile.Save(dungeon.GroupKey, "SEED_C", num);
			UnityEngine.Random.seed = seed;
		}
		return num;
	}

	public static float CalculateOverallDifficulty(DungeonInfo dungeon)
	{
		int dungeonConfigurationSeed = GetDungeonConfigurationSeed(dungeon);
		int seed = UnityEngine.Random.seed;
		UnityEngine.Random.seed = dungeonConfigurationSeed;
		dungeon.CalculatedDifficultyValues = new DifficultyValues
		{
			InfestationTypeValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			EnemyRatioValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			HullIntegrityValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			TransporterValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			AsteroidValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			EventDoorValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			EventCloseValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			EventSwarmChewValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax),
			VentValue = UnityEngine.Random.Range(dungeon.OriginalDifficultyMin, dungeon.OriginalDifficultyMax)
		};
		UnityEngine.Random.seed = seed;
		return dungeon.CalculatedDifficultyValues.GetWeightedDifficulty();
	}

	public static EarlyPlayConfiguration[] GetEarlyPlayDifficultyValues()
	{
		return new EarlyPlayConfiguration[4]
		{
			new EarlyPlayConfiguration
			{
				AgeMin = 10,
				AgeMax = 30,
				IsDesignedShip = true,
				DesignedShipFile = "nursery_1-1",
				ScrapMax = 48,
				DifficultyValues = new DifficultyValues
				{
					InfestationTypeValue = 0f,
					EnemyRatioValue = 0f,
					HullIntegrityValue = 0f,
					TransporterValue = 0f,
					AsteroidValue = 0f,
					EventDoorValue = 0f,
					EventCloseValue = 0f,
					EventSwarmChewValue = 0f
				}
			},
			new EarlyPlayConfiguration
			{
				AgeMin = 10,
				AgeMax = 30,
				IsDesignedShip = true,
				DesignedShipFile = "nursery_2-1",
				ScrapMax = 35,
				DifficultyValues = new DifficultyValues
				{
					InfestationTypeValue = 0f,
					EnemyRatioValue = 0f,
					HullIntegrityValue = 0f,
					TransporterValue = 0f,
					AsteroidValue = 0f,
					EventDoorValue = 0f,
					EventCloseValue = 0f,
					EventSwarmChewValue = 0f
				}
			},
			new EarlyPlayConfiguration
			{
				AgeMin = 10,
				AgeMax = 30,
				IsDesignedShip = true,
				DesignedShipFile = "Nursery_3-1",
				ScrapMax = 65,
				DifficultyValues = new DifficultyValues
				{
					InfestationTypeValue = 0f,
					EnemyRatioValue = 0f,
					HullIntegrityValue = 0f,
					TransporterValue = 0f,
					AsteroidValue = 0f,
					EventDoorValue = 0f,
					EventCloseValue = 0f,
					EventSwarmChewValue = 0f
				}
			},
			new EarlyPlayConfiguration
			{
				AgeMin = 10,
				AgeMax = 30,
				IsDesignedShip = true,
				DesignedShipFile = "Nursery_4-1",
				ScrapMax = 50,
				DifficultyValues = new DifficultyValues
				{
					InfestationTypeValue = 0f,
					EnemyRatioValue = 0f,
					HullIntegrityValue = 0f,
					TransporterValue = 0f,
					AsteroidValue = 0f,
					EventDoorValue = 0f,
					EventCloseValue = 0f,
					EventSwarmChewValue = 0f
				}
			}
		};
	}
}
