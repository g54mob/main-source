using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Behaviour.UI;
using Assets.Behaviour.UI.Construction;
using Assets.Behaviour.Util;
using Assets.Source.Ability;
using Assets.Source.Buff;
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

			public override string Name => Translation.Translate("@ConstructionTech", Tech.Name);

			public override Sprite Icon => Tech.Icon;

			public TechConstructionProgress(TechNode parent)
			{
				Tech = parent;
			}

			public TechConstructionProgress(TechNode parent, float time, IEnumerable<KeyValuePair<ItemType, BigInteger>> materials)
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

		public double EntropyDecayPerSecond = 0.001;

		public const int BaseInventorySpace = 100;

		public const int BaseCityBuilderParts = 5;

		public static GamePlayer Current;

		public static ItemType CityPartItem = "city_block";

		public static ItemType RocketPartItem = "rocket_segment";

		public static ItemType DemoTurtleItem = "demo_turtle";

		public static TechNode AutoUpgradeTech = "t8_auto_upgrade";

		public static TechNode AutoUpgradeTech2 = "t8_auto_upgrade_2";

		public static TechNode AutoUpgradeTech3 = "t8_auto_upgrade_3";

		public bool Integrity = true;

		public int Prestige;

		public int RocketsLaunched;

		public int AscensionCount;

		public bool GlitchFrameInteracted;

		public List<ItemType> RecentItems;

		public Vector2Int RecentMapPosition;

		public bool RecentInOverview;

		public float TechCameraPosition;

		private BigInteger[] _tieredInventorySpace;

		private BigInteger[] _itemInventorySpace;

		private BigInteger[] _inventory;

		private bool[] _techUnlocked;

		private bool[] _itemVisible;

		private bool[] _secretButtons;

		private float _prestigeMultiplier;

		public PersistentStats SessionStats;

		public PersistentStats TotalStats;

		private ProductionStats _volatileStats;

		private readonly List<ConstructionProgress> _construction;

		private readonly Dictionary<TechNode, ConstructionProgress> _techConstruction;

		public bool DoAutoUpgrade;

		public bool ConstructionPaused;

		private List<ActivatedAbility> _abilities = new List<ActivatedAbility>();

		private Dictionary<ActivatedAbility, float> _cooldowns = new Dictionary<ActivatedAbility, float>();

		public double AbilityEntropy = 1.0;

		private float _timePlayedSecond;

		private float _entropyTimer;

		private List<FrameBuff> _buffs = new List<FrameBuff>();

		public static float AutoUpgradeTime
		{
			get
			{
				if (Current.HasTech(AutoUpgradeTech3))
				{
					return 0.5f;
				}
				if (Current.HasTech(AutoUpgradeTech2))
				{
					return 1f;
				}
				return 2f;
			}
		}

		public WorldMap Map { get; private set; }

		public int TechTier { get; private set; } = 1;

		public BigInteger CityBuilderPartsCost => GameMath.Multiply(5, Math.Pow(1.05, CityBuilderTiles));

		public int CityBuilderTiles { get; private set; }

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

		public float CityProductivityMultiplier => 1f + (float)CityBuilderTiles * 0.0005f;

		public BigInteger RocketParts => GetInventoryCount(RocketPartItem);

		public BigInteger DemoTurtleParts => GetInventoryCount(DemoTurtleItem);

		public IEnumerable<ConstructionProgress> Construction => _construction;

		public int ConstructionCount => _construction.Count;

		public IEnumerable<ActivatedAbility> Abilities => _abilities;

		public IEnumerable<FrameBuff> Buffs => _buffs;

		public GamePlayer()
		{
			_inventory = new BigInteger[ItemType.Count];
			_itemVisible = new bool[ItemType.Count];
			_techUnlocked = new bool[TechNode.Count];
			_techConstruction = new Dictionary<TechNode, ConstructionProgress>();
			_construction = new List<ConstructionProgress>();
			_tieredInventorySpace = new BigInteger[14];
			_itemInventorySpace = new BigInteger[ItemType.Count];
			_secretButtons = new bool[12];
			SessionStats = new PersistentStats();
			TotalStats = new PersistentStats();
			_volatileStats = new ProductionStats();
			RecentItems = new List<ItemType>();
		}

		public bool IsItemVisible(ItemType type)
		{
			return _itemVisible[type.Ordinal];
		}

		public IEnumerable<ItemType> GetInventoryItems()
		{
			for (int i = 0; i < _inventory.Length; i++)
			{
				if (_inventory[i] > 0L)
				{
					yield return ItemType.Get(i);
				}
			}
		}

		public BigInteger GetInventoryCount(ItemType item)
		{
			return _inventory[item.Ordinal];
		}

		public bool HasCost(IEnumerable<KeyValuePair<ItemType, BigInteger>> cost, int multiplier = 1)
		{
			foreach (KeyValuePair<ItemType, BigInteger> item in cost)
			{
				if (GetInventoryCount(item.Key) < item.Value * multiplier)
				{
					return false;
				}
			}
			return true;
		}

		public bool CanAddInventoryItem(ItemType type, BigInteger count)
		{
			return GetInventoryCapacity(type) >= GetInventoryCount(type) + count;
		}

		public void AddInventoryItem(ItemType type, BigInteger count, bool addToStats, bool handCraft = false)
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

		public bool RemoveInventoryItem(ItemType type, BigInteger count, bool addToStats)
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

		public BigInteger ConsumeInventoryItem(ItemType type, BigInteger toConsume)
		{
			BigInteger bigInteger = _inventory[type.Ordinal];
			BigInteger bigInteger2;
			if (bigInteger >= toConsume)
			{
				_inventory[type.Ordinal] = bigInteger - toConsume;
				bigInteger2 = toConsume;
			}
			else
			{
				_inventory[type.Ordinal] = 0;
				bigInteger2 = bigInteger;
			}
			if (bigInteger2 > 0L)
			{
				_volatileStats.AddConsumption(type, bigInteger2);
			}
			return bigInteger2;
		}

		public BigInteger GetInventoryCapacity(ItemType type)
		{
			if (type == RocketPartItem || type == DemoTurtleItem || type == CityPartItem)
			{
				return int.MaxValue;
			}
			BigInteger bigInteger;
			if (type == ItemType.GlitchedWidget)
			{
				bigInteger = _itemInventorySpace[type.Ordinal];
			}
			else
			{
				int num = type.Tier;
				if (num > 12)
				{
					num = 12;
				}
				bigInteger = _tieredInventorySpace[0] + _tieredInventorySpace[num] + _itemInventorySpace[type.Ordinal];
			}
			return GameMath.Multiply(100 + bigInteger, Math.Max(1f, PrestigeMultiplier - 5f));
		}

		public void AddInventorySpace(int tier, BigInteger amt)
		{
			_tieredInventorySpace[tier] += amt;
		}

		public void AddItemStorage(ItemType type, BigInteger amt)
		{
			_itemInventorySpace[type.Ordinal] += amt;
		}

		public double GetProductionStats(ItemType type)
		{
			return _volatileStats.GetProduction(type);
		}

		public double GetConsumptionStats(ItemType type)
		{
			return _volatileStats.GetConsumption(type);
		}

		public double GetMaxProduction(ItemType type)
		{
			double num = 0.0;
			foreach (WorldFrame frame in WorldMap.Current.Frames)
			{
				if (frame is CraftingFrame craftingFrame)
				{
					num += craftingFrame.GetMaxProduction(type);
				}
			}
			return num;
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
				UIStatusMessage.Show(Translation.Translate("@TechNodeStatusMessage", tech.Name), tech.Icon, persistent: false);
			}
			_checkAllTechAchievement();
		}

		private void _checkAllTechAchievement()
		{
			AchievementManager.CheckAchievement(new AchievementChecker("AllTech", delegate
			{
				foreach (TechNode node in TechNode.Nodes)
				{
					if (!node.Hidden && !HasTech(node))
					{
						return false;
					}
				}
				return true;
			}));
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
			UIStatusMessage.Show(Translation.Translate("@StatusMessageTierReached", tier, GameMath.FormatTime(SessionStats.PlayTime)), "Numerals_" + (tier - 1), persistent: true);
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
				UIStatusMessage.Show(Translation.Translate("@StatusMessageLaunchFacility", GameMath.FormatTime(SessionStats.PlayTime)), "Items_60", persistent: true);
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
				UIStatusMessage.Show(Translation.Translate("@StatusMessageRocketLaunched", GameMath.FormatTime(SessionStats.PlayTime)), "Items_60", persistent: true);
			}
		}

		public bool GetSecretButton(int idx)
		{
			return _secretButtons[idx];
		}

		public void TriggerSecretButton(int idx)
		{
			if (!_secretButtons[idx])
			{
				UIStatusMessage.Show("@StatusMessageSecretButton", "Numerals_" + idx, persistent: false);
			}
			_secretButtons[idx] = true;
			int num = 0;
			for (int i = 0; i < _secretButtons.Length; i++)
			{
				if (_secretButtons[i])
				{
					num++;
				}
			}
			SteamStatsManager.Set(SteamStatType.SecretButtons, num);
		}

		public void AddActivatedAbility(ActivatedAbility aa)
		{
			_abilities.Add(aa);
			UIStatusMessage.Show(Translation.Translate("@ActivatedAbilityUnlocked", aa.DisplayName), aa.IconName, persistent: false);
			if ((bool)GameUI.Instance)
			{
				GameUI.Instance.UpdateAbilityUI();
			}
		}

		public float GetCooldown(ActivatedAbility aa)
		{
			if (_cooldowns.TryGetValue(aa, out var value))
			{
				return value;
			}
			return 0f;
		}

		public virtual bool AddBuff(FrameBuff fb)
		{
			foreach (FrameBuff buff in Buffs)
			{
				if (!buff.CanCoexistWith(fb))
				{
					return false;
				}
				if (buff.AddStack(fb))
				{
					return true;
				}
			}
			fb.AddDuration(fb.BaseDuration);
			_buffs.Add(fb);
			return true;
		}

		public void UpdateCityParts()
		{
			while (GetInventoryCount(CityPartItem) >= CityBuilderPartsCost)
			{
				ConsumeInventoryItem(CityPartItem, CityBuilderPartsCost);
				CityBuilderTiles++;
				Map.ExpandCityBuilder();
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
			if (!ConstructionPaused)
			{
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
			_entropyTimer += delta;
			if (_entropyTimer >= 1f)
			{
				_entropyTimer -= 1f;
				if (AbilityEntropy > 1.0)
				{
					double num = AbilityEntropy * EntropyDecayPerSecond;
					AbilityEntropy = Math.Max(1.0, AbilityEntropy - num);
				}
			}
			for (int j = 0; j < _buffs.Count; j++)
			{
				if (_buffs[j].Update(null, delta))
				{
					_buffs.RemoveAt(j);
					j--;
				}
			}
		}

		public double GetBuffSpeedMultiplier(bool handCraft)
		{
			if (_buffs.Count == 0)
			{
				return 1.0;
			}
			double num = 1.0;
			foreach (FrameBuff buff in _buffs)
			{
				num *= buff.GetSpeedMultiplier(null, handCraft);
			}
			return num;
		}

		public double GetBuffProductivityMultiplier(bool handCraft)
		{
			if (_buffs.Count == 0)
			{
				return 1.0;
			}
			double num = 1.0;
			foreach (FrameBuff buff in _buffs)
			{
				num *= buff.GetProductivityMultiplier(null, handCraft);
			}
			return num;
		}

		public double GetBuffParallelMultiplier(bool handCraft)
		{
			if (_buffs.Count == 0)
			{
				return 1.0;
			}
			double num = 1.0;
			foreach (FrameBuff buff in _buffs)
			{
				num *= buff.GetParallelMultiplier(null, handCraft);
			}
			return num;
		}

		public JsonValue ToJson()
		{
			JsonObject jsonObject = new JsonObject();
			for (int i = 0; i < _inventory.Length; i++)
			{
				if (_inventory[i] > 0L)
				{
					jsonObject[ItemType.Get(i)] = _inventory[i].ToString();
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
			JsonArray jsonArray3 = new JsonArray();
			for (int k = 0; k < _secretButtons.Length; k++)
			{
				jsonArray3.Add(_secretButtons[k]);
			}
			JsonArray jsonArray4 = new JsonArray();
			foreach (ActivatedAbility ability in _abilities)
			{
				jsonArray4.Add(ability.Identifier);
			}
			JsonObject jsonObject3 = new JsonObject();
			foreach (KeyValuePair<ActivatedAbility, float> cooldown in _cooldowns)
			{
				jsonObject3[cooldown.Key.Identifier] = cooldown.Value;
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
				{ "AscensionCount", AscensionCount },
				{ "DoAutoUpgrade", DoAutoUpgrade },
				{ "SecretButtons", jsonArray3 },
				{ "GlitchFrameInteracted", GlitchFrameInteracted },
				{ "CityBuilderTiles", CityBuilderTiles },
				{ "Abilities", jsonArray4 },
				{ "Cooldowns", jsonObject3 },
				{ "AbilityEntropy", AbilityEntropy },
				{
					"Buffs",
					_buffs.ToJsonArray()
				}
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
				AscensionCount = val["AscensionCount"],
				DoAutoUpgrade = val["DoAutoUpgrade"],
				GlitchFrameInteracted = val["GlitchFrameInteracted"],
				CityBuilderTiles = val["CityBuilderTiles"],
				AbilityEntropy = val["AbilityEntropy"]
			});
			if (double.IsNaN(gamePlayer.AbilityEntropy) || gamePlayer.AbilityEntropy < 1.0)
			{
				gamePlayer.AbilityEntropy = 1.0;
			}
			gamePlayer.Map = WorldMap.FromJson(val["Map"]);
			foreach (KeyValuePair<string, JsonValue> item in val["Inventory"].AsJsonObject)
			{
				ItemType itemType = ItemType.Get(item.Key);
				if (item.Value.IsInteger)
				{
					gamePlayer._inventory[itemType.Ordinal] = item.Value.AsInteger;
				}
				else
				{
					gamePlayer._inventory[itemType.Ordinal] = BigInteger.Parse(item.Value.AsString ?? "0");
				}
				gamePlayer._itemVisible[itemType.Ordinal] = true;
			}
			if (val["RocketParts"].IsInteger)
			{
				gamePlayer._inventory[RocketPartItem.Ordinal] = val["RocketParts"].AsInteger;
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
			if (val["SecretButtons"].IsJsonArray)
			{
				JsonArray asJsonArray = val["SecretButtons"].AsJsonArray;
				for (int i = 0; i < asJsonArray.Count; i++)
				{
					gamePlayer._secretButtons[i] = asJsonArray[i];
				}
			}
			if (val["Abilities"].IsJsonArray)
			{
				foreach (JsonValue item5 in val["Abilities"].AsJsonArray)
				{
					gamePlayer._abilities.Add(ActivatedAbility.Get(item5));
				}
				foreach (KeyValuePair<string, JsonValue> item6 in val["Cooldowns"].AsJsonObject)
				{
					gamePlayer._cooldowns.Add(ActivatedAbility.Get(item6.Key), (float)item6.Value.AsNumber);
				}
			}
			if (val["Buffs"].IsJsonArray)
			{
				gamePlayer._buffs.FromJsonArray(val["Buffs"], FrameBuff.FromJson);
			}
			if (gamePlayer.HasTech("t4_tech") && gamePlayer.TechTier == 3)
			{
				gamePlayer.SetTechTier(4);
				gamePlayer.AddTech("t4f_copper_ore");
				gamePlayer.AddTech("t4f_copper_ingot");
				gamePlayer.AddTech("t4f_plastic");
				gamePlayer.AddTech("t4f_circuit_board");
				gamePlayer.AddTech("t4f_computational_widget");
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
				worldMap.CreateGlitchedFrame();
			}
			while (!worldMap.HasStartingArea());
			worldMap.AddFrame(new T1BasicWidget(), new Vector2Int(0, 0));
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
			foreach (TechNode node in TechNode.Nodes)
			{
				node.ResetCost();
			}
		}

		public static float GetPrestigeMultiplier(int prestige)
		{
			return 1 + prestige;
		}
	}
}
