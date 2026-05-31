using System;
using System.Collections.Generic;
using Assets.Behaviour.UI;
using Assets.Behaviour.UI.Construction;
using Assets.Behaviour.Util;
using Assets.Source.Item;
using Assets.Source.Util;
using Assets.Source.World;
using Assets.Source.World.Frames;
using LightJson;
using UnityEngine;

namespace Assets.Source.Player
{
	public class GamePlayer : IJsonSource
	{
		public class TechConstructionProgress : ConstructionProgress
		{
			public TechNode Tech { get; private set; }

			public override string Name => "Tech: " + Tech.Name;

			public override Sprite Icon => Tech.Icon;

			public TechConstructionProgress(TechNode parent)
			{
				Tech = parent;
			}

			public TechConstructionProgress(TechNode parent, float time, IEnumerable<KeyValuePair<ItemType, int>> materials)
				: base(time, materials)
			{
				Tech = parent;
			}

			protected override void OnConstructionCompleted()
			{
				Current._techConstruction.Remove(Tech);
				Current.AddTech(Tech, notify: true);
				TechTreeUI.Instance.UpdateNodes();
			}

			protected override void OnConstructionCanceled()
			{
				Current._techConstruction.Remove(Tech);
				TechTreeUI.Instance.UpdateNodes();
			}
		}

		public const int BaseInventorySpace = 100;

		public const float AutoUpgradeTime = 2f;

		public static GamePlayer Current;

		public static ItemType RocketPartItem = "rocket_segment";

		public static ItemType DemoTurtleItem = "demo_turtle";

		public static TechNode AutoUpgradeTech = "t8_auto_upgrade";

		public bool Integrity = true;

		public int Prestige;

		public int RocketsLaunched;

		public List<ItemType> RecentItems;

		public Vector2Int RecentMapPosition;

		public bool RecentInOverview;

		public float TechCameraPosition;

		private int[] _tieredInventorySpace;

		private int[] _itemInventorySpace;

		private int[] _inventory;

		private bool[] _techUnlocked;

		private bool[] _itemVisible;

		private float _prestigeMultiplier;

		public PersistentStats SessionStats;

		public PersistentStats TotalStats;

		private ProductionStats _volatileStats;

		private readonly List<ConstructionProgress> _construction;

		private readonly Dictionary<TechNode, ConstructionProgress> _techConstruction;

		public bool DoAutoUpgrade;

		public bool ConstructionPaused;

		private float _timePlayedSecond;

		public WorldMap Map { get; private set; }

		public int TechTier { get; private set; } = 1;

		public float PrestigeMultiplier
		{
			get
			{
				if (_prestigeMultiplier == 0f)
				{
					_prestigeMultiplier = GetPrestigeMultiplier(Prestige);
				}
				return _prestigeMultiplier;
			}
		}

		public int RocketParts => GetInventoryCount(RocketPartItem);

		public int DemoTurtleParts => GetInventoryCount(DemoTurtleItem);

		public IEnumerable<ConstructionProgress> Construction => _construction;

		public int ConstructionCount => _construction.Count;

		internal int GetInventoryCount(object omegaWidget)
		{
			throw new NotImplementedException();
		}

		public GamePlayer()
		{
			_inventory = new int[ItemType.Count];
			_itemVisible = new bool[ItemType.Count];
			_techUnlocked = new bool[TechNode.Count];
			_techConstruction = new Dictionary<TechNode, ConstructionProgress>();
			_construction = new List<ConstructionProgress>();
			_tieredInventorySpace = new int[14];
			_itemInventorySpace = new int[ItemType.Count];
			SessionStats = new PersistentStats();
			TotalStats = new PersistentStats();
			_volatileStats = new ProductionStats();
			RecentItems = new List<ItemType>();
		}

		public bool IsItemVisible(ItemType type)
		{
			return _itemVisible[type.Ordinal];
		}

		public int GetInventoryCount(ItemType item)
		{
			return _inventory[item.Ordinal];
		}

		public bool HasCost(IEnumerable<KeyValuePair<ItemType, int>> cost)
		{
			foreach (KeyValuePair<ItemType, int> item in cost)
			{
				if (GetInventoryCount(item.Key) < item.Value)
				{
					return false;
				}
			}
			return true;
		}

		public bool CanAddInventoryItem(ItemType type, int count)
		{
			return GetInventoryCapacity(type) >= GetInventoryCount(type) + count;
		}

		public void AddInventoryItem(ItemType type, int count, bool addToStats, bool handCraft = false)
		{
			_inventory[type.Ordinal] += count;
			_itemVisible[type.Ordinal] = true;
			if (addToStats)
			{
				SessionStats.AddItemCrafted(type, count, handCraft);
				TotalStats.AddItemCrafted(type, count, handCraft);
				_volatileStats.AddProduction(type, count);
			}
		}

		public bool RemoveInventoryItem(ItemType type, int count, bool addToStats)
		{
			if (_inventory[type.Ordinal] >= count)
			{
				_inventory[type.Ordinal] -= count;
				if (addToStats)
				{
					_volatileStats.AddConsumption(type, count);
				}
				return true;
			}
			return false;
		}

		public int ConsumeInventoryItem(ItemType type, int toConsume)
		{
			int num = _inventory[type.Ordinal];
			int num2;
			if (num >= toConsume)
			{
				_inventory[type.Ordinal] = num - toConsume;
				num2 = toConsume;
			}
			else
			{
				_inventory[type.Ordinal] = 0;
				num2 = num;
			}
			if (num2 > 0)
			{
				_volatileStats.AddConsumption(type, num2);
			}
			return num2;
		}

		public int GetInventoryCapacity(ItemType type)
		{
			if (type == RocketPartItem || type == DemoTurtleItem)
			{
				return int.MaxValue;
			}
			int num = type.Tier;
			if (num > 12)
			{
				num = 12;
			}
			return Mathf.RoundToInt(100f * (1f + 0.5f * (float)Prestige) + (float)(_tieredInventorySpace[0] + _tieredInventorySpace[num] + _itemInventorySpace[type.Ordinal]) * (1f + 0.1f * (float)Prestige));
		}

		public void AddInventorySpace(int tier, int amt)
		{
			_tieredInventorySpace[tier] += amt;
		}

		public void AddItemStorage(ItemType type, int amt)
		{
			_itemInventorySpace[type.Ordinal] += amt;
		}

		public float GetProductionStats(ItemType type)
		{
			return _volatileStats.GetProduction(type);
		}

		public float GetConsumptionStats(ItemType type)
		{
			return _volatileStats.GetConsumption(type);
		}

		public void SetTechTier(int tier)
		{
			TechTier = tier;
			SteamStatsManager.Set(SteamStatType.TechTier, tier);
		}

		public bool HasTech(TechNode tech)
		{
			return _techUnlocked[tech.Ordinal];
		}

		public void AddTech(TechNode tech, bool notify = false)
		{
			_techUnlocked[tech.Ordinal] = true;
			tech.OnUnlock?.Invoke(this);
			WorldManager.Instance?.ReloadActiveUpgrades();
			OverviewUI instance = OverviewUI.Instance;
			if ((object)instance != null && instance.FullScreenActive)
			{
				WorldOverview.Instance.ReloadAvailableUpgrades(tech);
			}
			if (notify && !tech.Identifier.EndsWith("_tech"))
			{
				UIStatusMessage.Show("Tech unlocked: " + tech.Name, tech.Icon, persistent: false);
			}
		}

		public void StartTechConstruction(TechNode tech)
		{
			TechConstructionProgress techConstructionProgress = new TechConstructionProgress(tech, 0f, tech.GetCost());
			_techConstruction[tech] = techConstructionProgress;
			AddConstruction(techConstructionProgress);
		}

		public void CancelTechConstruction(TechNode tech)
		{
			_techConstruction[tech].Cancel();
		}

		public ConstructionProgress GetTechConstruction(TechNode node)
		{
			_techConstruction.TryGetValue(node, out var value);
			return value;
		}

		public void AddConstruction(ConstructionProgress progress)
		{
			if (_construction.Count > 0 && _construction[_construction.Count - 1] is TechConstructionProgress techConstructionProgress && techConstructionProgress.Tech.NodeType == TechNodeType.Tier)
			{
				_construction.Insert(_construction.Count - 1, progress);
			}
			else
			{
				_construction.Add(progress);
			}
			ConstructionUI.Instance?.ConstructionAdded(progress);
		}

		public void RemoveConstruction(ConstructionProgress progress)
		{
			_construction.Remove(progress);
			ConstructionUI.Instance?.ConstructionRemoved(progress);
		}

		public void PrioritizeConstruction(ConstructionProgress progress)
		{
			if (_construction.Remove(progress))
			{
				_construction.Insert(0, progress);
			}
		}

		public void AddTierBenchmark(int tier)
		{
			SessionStats.AddTierBenchmark(tier, SessionStats.PlayTime);
			TotalStats.AddTierBenchmark(tier, SessionStats.PlayTime);
			UIStatusMessage.Show("Reached Tier " + tier + " in " + GameMath.FormatTime(SessionStats.PlayTime), "Numerals_" + (tier - 1), persistent: true);
		}

		public void AddRocketSiloBenchmark()
		{
			if (SessionStats.RocketSiloTime == 0)
			{
				SessionStats.RocketSiloTime = SessionStats.PlayTime;
				if (TotalStats.RocketSiloTime == 0)
				{
					TotalStats.RocketSiloTime = SessionStats.PlayTime;
				}
				else
				{
					TotalStats.RocketSiloTime = Math.Min(TotalStats.RocketSiloTime, SessionStats.PlayTime);
				}
				UIStatusMessage.Show("Omega Launch Facility built in " + GameMath.FormatTime(SessionStats.PlayTime), "Items_60", persistent: true);
			}
		}

		public void AddRocketLaunchedBenchmark()
		{
			if (RocketsLaunched == 0)
			{
				SessionStats.RocketLaunchedTime = SessionStats.PlayTime;
				if (TotalStats.RocketLaunchedTime == 0)
				{
					TotalStats.RocketLaunchedTime = SessionStats.PlayTime;
				}
				else
				{
					TotalStats.RocketLaunchedTime = Math.Min(TotalStats.RocketSiloTime, SessionStats.PlayTime);
				}
				UIStatusMessage.Show("First rocket launched in " + GameMath.FormatTime(SessionStats.PlayTime), "Items_60", persistent: true);
			}
		}

		public void Update(float delta)
		{
			_timePlayedSecond += delta;
			if (_timePlayedSecond > 1f)
			{
				_timePlayedSecond -= 1f;
				SessionStats.AddTimePlayed(1);
				TotalStats.AddTimePlayed(1);
			}
			_volatileStats.Update(delta);
			if (ConstructionPaused)
			{
				return;
			}
			for (int i = 0; i < _construction.Count; i++)
			{
				ConstructionProgress constructionProgress = _construction[i];
				constructionProgress.Update(delta);
				if (constructionProgress.Progress == 1f)
				{
					_construction.RemoveAt(i);
					ConstructionUI.Instance?.ConstructionCompleted(constructionProgress);
					i--;
				}
			}
		}

		public JsonValue ToJson()
		{
			JsonObject jsonObject = new JsonObject();
			for (int i = 0; i < _inventory.Length; i++)
			{
				if (_inventory[i] > 0)
				{
					jsonObject[ItemType.Get(i)] = _inventory[i];
				}
			}
			JsonArray jsonArray = new JsonArray();
			for (int j = 0; j < _techUnlocked.Length; j++)
			{
				if (_techUnlocked[j])
				{
					jsonArray.Add(TechNode.Get(j).Identifier);
				}
			}
			JsonArray jsonArray2 = new JsonArray();
			foreach (ItemType recentItem in RecentItems)
			{
				jsonArray2.Add(recentItem.Identifier);
			}
			JsonObject jsonObject2 = new JsonObject();
			foreach (KeyValuePair<TechNode, ConstructionProgress> item in _techConstruction)
			{
				jsonObject2[item.Key] = item.Value.ToJson();
			}
			return new JsonObject
			{
				{
					"Map",
					Map.ToJson()
				},
				{ "MapX", RecentMapPosition.x },
				{ "MapY", RecentMapPosition.y },
				{ "RecentInOverview", RecentInOverview },
				{ "Inventory", jsonObject },
				{ "RecentItems", jsonArray2 },
				{ "Tech", jsonArray },
				{ "TechTier", TechTier },
				{ "TechConstruction", jsonObject2 },
				{ "TechCameraY", TechCameraPosition },
				{
					"SessionStats",
					SessionStats.ToJson()
				},
				{
					"TotalStats",
					TotalStats.ToJson()
				},
				{ "Prestige", Prestige },
				{ "RocketsLaunched", RocketsLaunched },
				{ "DoAutoUpgrade", DoAutoUpgrade }
			};
		}

		public static GamePlayer FromJson(JsonValue val)
		{
			GamePlayer current = Current;
			GamePlayer gamePlayer = (Current = new GamePlayer
			{
				RecentMapPosition = new Vector2Int(val["MapX"], val["MapY"]),
				RecentInOverview = val["RecentInOverview"],
				TechTier = val["TechTier"],
				TechCameraPosition = (float)val["TechCameraY"].AsNumber,
				Prestige = val["Prestige"],
				RocketsLaunched = val["RocketsLaunched"],
				DoAutoUpgrade = val["DoAutoUpgrade"]
			});
			gamePlayer.Map = WorldMap.FromJson(val["Map"]);
			foreach (KeyValuePair<string, JsonValue> item in val["Inventory"].AsJsonObject)
			{
				ItemType itemType = ItemType.Get(item.Key);
				gamePlayer._inventory[itemType.Ordinal] = item.Value;
				gamePlayer._itemVisible[itemType.Ordinal] = true;
			}
			if (val["RocketParts"].IsInteger)
			{
				gamePlayer._inventory[RocketPartItem.Ordinal] = val["RocketParts"];
			}
			foreach (JsonValue item2 in val["Tech"].AsJsonArray)
			{
				gamePlayer._techUnlocked[TechNode.Get(item2.AsString).Ordinal] = true;
			}
			foreach (JsonValue item3 in val["RecentItems"].AsJsonArray)
			{
				gamePlayer.RecentItems.Add(item3.AsString);
			}
			gamePlayer.RecentItems.Reverse();
			foreach (KeyValuePair<string, JsonValue> item4 in val["TechConstruction"].AsJsonObject)
			{
				TechNode techNode = item4.Key;
				TechConstructionProgress techConstructionProgress = new TechConstructionProgress(techNode);
				gamePlayer._techConstruction[techNode] = ConstructionProgress.FromJson(item4.Value, techConstructionProgress);
				gamePlayer.AddConstruction(techConstructionProgress);
			}
			if (val["SessionStats"].IsJsonObject)
			{
				gamePlayer.SessionStats.FromJson(val["SessionStats"]);
				gamePlayer.TotalStats.FromJson(val["TotalStats"]);
			}
			Current = current;
			return gamePlayer;
		}

		public static void StartNewGame()
		{
			WorldMap worldMap;
			do
			{
				worldMap = new WorldMap
				{
					Seed = (int)SeededRandom.Global.RandomInt()
				};
			}
			while (!worldMap.HasStartingArea());
			worldMap.AddFrame(new T1BasicWidget(), new Vector2Int(0, 0), updatePlacement: false);
			worldMap.GetTerrainBlock(-2, 1);
			worldMap.GetTerrainBlock(-2, 0);
			worldMap.GetTerrainBlock(-2, -1);
			worldMap.GetTerrainBlock(-2, -2);
			worldMap.GetTerrainBlock(1, -2);
			worldMap.GetTerrainBlock(0, -2);
			worldMap.GetTerrainBlock(-1, -2);
			Current = new GamePlayer();
			Current.Integrity = true;
			Current.Map = worldMap;
			Current.AddTech("t1_tech");
			Current.AddInventoryItem("iron_ingot", 5, addToStats: false);
			Current.RecentItems.Add("iron_ingot");
		}

		public static float GetPrestigeMultiplier(int prestige)
		{
			return 1 + prestige;
		}
	}
}
