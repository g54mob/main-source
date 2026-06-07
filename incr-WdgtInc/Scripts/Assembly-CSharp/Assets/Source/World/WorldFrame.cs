using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Behaviour.Util;
using Assets.Source.Buff;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using Assets.Source.World.Frames;
using LightJson;
using UnityEngine;

namespace Assets.Source.World
{
	public abstract class WorldFrame : IJsonSource
	{
		private class UpgradeConstructionProgress : ConstructionProgress
		{
			private WorldFrame _parent;

			private FrameUpgrade _upgrade;

			public FrameUpgrade Upgrade { get; private set; }

			public override string Name => Translation.Translate("@ConstructionUpgrade", _upgrade.Name);

			public override Sprite Icon => _upgrade.RequiredTech.Icon;

			public UpgradeConstructionProgress(WorldFrame parent, FrameUpgrade upgrade)
			{
				_parent = parent;
				_upgrade = upgrade;
			}

			public UpgradeConstructionProgress(WorldFrame parent, FrameUpgrade upgrade, float time, IEnumerable<KeyValuePair<ItemType, BigInteger>> materials)
				: base(time, materials)
			{
				_parent = parent;
				_upgrade = upgrade;
			}

			public override bool CanProceedConstruction()
			{
				return _parent.Construction == null;
			}

			protected override void OnConstructionCompleted()
			{
				_parent._upgradeConstruction.Remove(_upgrade);
				_parent._upgrades[_upgrade.FrameOrdinal] = true;
				_parent.OnUpgradeConstructionCompleted(_upgrade);
				_parent.ActiveFrame?.UpdateUpgradeSlot(new WorldAnchor(WorldAnchorType.Upgrade, _upgrade.FrameOrdinal));
				UpdateFullyUpgradedAchievement();
			}

			protected override void OnConstructionCanceled()
			{
				_parent._upgradeConstruction.Remove(_upgrade);
				_parent.ActiveFrame?.UpdateUpgradeSlot(new WorldAnchor(WorldAnchorType.Upgrade, _upgrade.FrameOrdinal));
			}
		}

		private class FrameConstructionProgress : ConstructionProgress
		{
			private WorldFrame _frame;

			public override string Name => Translation.Translate("@ConstructionFrame", _frame.DisplayName);

			public override Sprite Icon => _frame.Icon;

			public FrameConstructionProgress(WorldFrame parent)
			{
				_frame = parent;
			}

			public FrameConstructionProgress(WorldFrame parent, float time, IEnumerable<KeyValuePair<ItemType, BigInteger>> materials)
				: base(time, materials)
			{
				_frame = parent;
			}

			protected override void OnConstructionCompleted()
			{
				_frame.Construction = null;
				_frame.OnConstructionCompleted();
				_frame.UpdatePlacementBonus();
				foreach (WorldFrame adjacentFrame in _frame.GetAdjacentFrames())
				{
					adjacentFrame.UpdatePlacementBonus(_frame);
				}
				UpdatePlacementBonusAchievement();
				_checkFramesBuiltAchievement();
				if (_frame.Terrain == 8)
				{
					_checkPlacementAchievementCity(_frame);
					return;
				}
				foreach (byte item in _frame.GetAdjacentTerrain(includeSelf: false, onlyCardinal: true))
				{
					if (item == 0)
					{
						_checkPlacementAchievementWater(_frame);
						break;
					}
				}
			}

			private void _checkFramesBuiltAchievement()
			{
				AchievementManager.CheckAchievement(new AchievementChecker("FramesBuilt", delegate
				{
					int num = 0;
					foreach (WorldFrame frame in WorldMap.Current.Frames)
					{
						if (frame.Construction == null)
						{
							num++;
						}
					}
					SteamStatsManager.Set(SteamStatType.FramesBuilt, num);
					return false;
				}));
			}

			private void _checkPlacementAchievementWater(WorldFrame frame)
			{
				AchievementManager.CheckAchievement(new AchievementChecker("BuildWater", delegate
				{
					for (int i = 0; i < WorldMap.Directions.Length; i++)
					{
						Vector2Int vector2Int = frame.Position + WorldMap.Directions[i];
						if (WorldMap.Current.GetTerrain(vector2Int) == 0)
						{
							foreach (Vector2Int item in WorldMap.Current.GetTileArea(vector2Int))
							{
								for (int j = 0; j < WorldMap.Directions.Length; j++)
								{
									Vector2Int pos = item + WorldMap.Directions[j];
									if (WorldMap.Current.GetTerrain(pos) != 0)
									{
										WorldFrame frame2 = WorldMap.Current.GetFrame(pos);
										if (frame2 == null || frame2.Construction != null)
										{
											return false;
										}
									}
								}
							}
						}
					}
					return true;
				}));
			}

			private void _checkPlacementAchievementCity(WorldFrame frame)
			{
				AchievementManager.CheckAchievement(new AchievementChecker("BuildCity", delegate
				{
					foreach (Vector2Int item in WorldMap.Current.GetTileArea(frame.Position))
					{
						WorldFrame frame2 = WorldMap.Current.GetFrame(item);
						if (frame2 == null || frame2.Construction != null)
						{
							return false;
						}
					}
					return true;
				}));
			}

			protected override void OnConstructionCanceled()
			{
				WorldMap.Current.RemoveFrame(_frame);
				for (int i = 0; i < _frame.AutoWorkerMax; i++)
				{
					_frame.GetAutoWorker(i)?.CancelConstruction();
				}
				foreach (FrameUpgrade item in new List<FrameUpgrade>(_frame._upgradeConstruction.Keys))
				{
					_frame.CancelUpgradeConstruction(item);
				}
			}
		}

		public const double CostMultiplier = 50.0;

		private static Dictionary<string, WorldFrame> _previews = new Dictionary<string, WorldFrame>();

		private static List<WorldFrame> _framesWithPlacementBonus;

		public readonly string Identifier;

		public bool IsPlaced;

		public WorldOverviewCell ActiveCell;

		public List<FrameBuff> Buffs = new List<FrameBuff>();

		protected double _extraCostMultiplier = 1.0;

		protected List<ItemType> _firstCost;

		protected List<ItemType> _baseCost;

		protected float _baseConstructionTime = 1f;

		protected AutoWorker[] _workers;

		protected TechNode[] _tierUpgrades;

		protected FrameUpgrade[] _availableUpgrades;

		protected bool[] _upgrades;

		private Dictionary<FrameUpgrade, ConstructionProgress> _upgradeConstruction;

		protected Dictionary<ItemType, BigInteger> _calcFirstCost;

		protected Dictionary<ItemType, BigInteger> _calcBaseCost;

		protected Dictionary<ItemType, BigInteger> _calcWorkerFirstCost;

		protected Dictionary<ItemType, BigInteger> _calcWorkerBaseCost;

		private bool _hasLogistics0;

		private bool _hasLogistics2;

		private double _logisticsBonus;

		public virtual double AutoworkerCostMultiplier => 6.0;

		public Vector2Int Position { get; private set; }

		public ActiveWorldFrame ActiveFrame { get; private set; }

		public string PrefabName => Identifier;

		public ConstructionProgress Construction { get; protected set; }

		public ItemType ItemHint { get; protected set; }

		public string IconName { get; protected set; }

		public Sprite Icon => ItemHint?.Icon ?? SpriteLibrary.Get(IconName);

		public abstract int AutoWorkerMax { get; }

		public int AutoWorkerCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < AutoWorkerMax; i++)
				{
					if (_workers[i] != null)
					{
						num++;
					}
				}
				return num;
			}
		}

		public bool CheaperFirstWorker { get; protected set; } = true;

		public virtual TechNode RequiredTech => null;

		public TechNode PlacementTech { get; protected set; }

		public virtual string PlacementGuideHint => null;

		public virtual string DisplayName => RequiredTech.Name;

		public virtual string Description => RequiredTech.Description;

		public virtual int Tier => RequiredTech.Tier;

		public virtual bool Buildable => true;

		public virtual bool Movable => true;

		public virtual bool Deconstructable => true;

		public virtual bool IsUnlocked => GamePlayer.Current.HasTech(RequiredTech);

		public bool UnderConstruction => Construction != null;

		public string MusicName { get; protected set; }

		public bool MusicIsImportant { get; protected set; }

		public int ServitudeLevel { get; private set; }

		public double CurrentPlacementBonus { get; private set; } = 1.0;

		public byte Terrain => WorldMap.Current.GetTerrain(Position);

		public WorldFrame()
		{
			Identifier = GetType().Name;
			_workers = new AutoWorker[AutoWorkerMax];
			_tierUpgrades = TechNode.GetTierUpgrades(Tier);
			_availableUpgrades = FrameUpgrade.GetUpgrades(Identifier).ToArray();
			_upgrades = new bool[_availableUpgrades.Length];
			_upgradeConstruction = new Dictionary<FrameUpgrade, ConstructionProgress>();
		}

		public void SetFrameActive(ActiveWorldFrame frame)
		{
			ActiveFrame = frame;
			if (frame != null)
			{
				SetupActiveFrame(frame);
			}
		}

		public void UpdatePosition(Vector2Int pos)
		{
			Position = pos;
		}

		public void Update(float delta)
		{
			if (Construction == null)
			{
				ActiveUpdate(delta);
			}
		}

		public virtual void ActiveUpdate(float delta)
		{
			for (int i = 0; i < Buffs.Count; i++)
			{
				if (Buffs[i].Update(this, delta))
				{
					Buffs.RemoveAt(i);
					i--;
				}
			}
			for (int j = 0; j < _workers.Length; j++)
			{
				if (_workers[j] != null)
				{
					_workers[j].Update(delta);
				}
			}
		}

		public virtual IList<ItemType> GetFirstCost()
		{
			return _firstCost;
		}

		public virtual IList<ItemType> GetBaseCost()
		{
			return _baseCost;
		}

		public virtual void StartConstruction(IEnumerable<KeyValuePair<ItemType, BigInteger>> materials)
		{
			Construction = new FrameConstructionProgress(this, _baseConstructionTime, materials);
			GamePlayer.Current.AddConstruction(Construction);
		}

		public virtual void OnAddFrame()
		{
		}

		public virtual void OnConstructionCompleted()
		{
		}

		public virtual void OnDeconstructionCompleted()
		{
		}

		public virtual void UpdatePlacementBonus(WorldFrame triggeredBy = null)
		{
			bool flag = false;
			byte terrain = Terrain;
			if (terrain == 8 && GamePlayer.Current.HasTech(TechNode.IndenturedServitude))
			{
				flag = true;
			}
			else if (terrain == 9 && GamePlayer.Current.HasTech(TechNode.IndenturedServitude3))
			{
				flag = true;
			}
			if (flag)
			{
				ServitudeLevel = ((!GamePlayer.Current.HasTech(TechNode.IndenturedServitude2)) ? 1 : 2);
			}
			else
			{
				ServitudeLevel = 0;
			}
			if (this is T6Graveyard || this is T6Incinerator)
			{
				ServitudeLevel = 0;
			}
			_hasLogistics0 = GamePlayer.Current.HasTech(TechNode.LogisticHub0);
			_hasLogistics2 = GamePlayer.Current.HasTech(TechNode.LogisticHub2);
			_logisticsBonus = 0.0;
			int num = 0;
			if (!(this is T3LogisticsHub))
			{
				foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
				{
					if (!(adjacentFrame is T3LogisticsHub t3LogisticsHub))
					{
						continue;
					}
					if (_hasLogistics0)
					{
						_logisticsBonus += t3LogisticsHub.GetLogisticsBonus(this);
						num++;
						continue;
					}
					double logisticsBonus = t3LogisticsHub.GetLogisticsBonus(this);
					if (logisticsBonus > _logisticsBonus)
					{
						_logisticsBonus = logisticsBonus;
						num = 1;
					}
				}
				if (num > 1)
				{
					_logisticsBonus *= Math.Pow(0.9, num - 1);
				}
			}
			if (num == 8)
			{
				SteamAchievement.Trigger("LogisticsSurround");
			}
			if (PlacementTech != null && GamePlayer.Current.HasTech(PlacementTech))
			{
				CurrentPlacementBonus = CalculatePlacementBonus(triggeredBy);
			}
		}

		protected virtual double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			return 1.0;
		}

		public virtual void OnUpgradeConstructionCompleted(FrameUpgrade key)
		{
		}

		public void CancelConstruction()
		{
			Construction.Cancel();
		}

		public virtual void SetupActiveFrame(ActiveWorldFrame frame)
		{
			AutoWorker[] workers = _workers;
			for (int i = 0; i < workers.Length; i++)
			{
				workers[i]?.SetupActiveFrame(frame);
			}
		}

		public virtual void AddCustomTooltipLines(UITooltip tooltip)
		{
		}

		public virtual void CopyFrom(WorldFrame frame)
		{
		}

		public virtual void ButtonClicked(WorldAnchor anchor)
		{
			if (anchor.AnchorType == WorldAnchorType.AutoWorker)
			{
				PurchaseAutoWorker(anchor);
			}
			else if (anchor.AnchorType == WorldAnchorType.Upgrade)
			{
				PurchaseUpgrade(anchor);
			}
			else if (anchor.AnchorType == WorldAnchorType.HandCraft)
			{
				AchievementManager.Instance.AddAchievementClick();
			}
		}

		public virtual IEnumerable<KeyValuePair<ItemType, BigInteger>> GetPurchaseCost(int? nthFrame = null, bool includeUnderConstruction = true)
		{
			if (_calcBaseCost == null)
			{
				_calcFirstCost = GameMath.CreateItemCost(Identifier, Tier, 50.0 * _extraCostMultiplier, GetFirstCost() ?? GetBaseCost());
				_calcBaseCost = GameMath.CreateItemCost(Identifier, Tier, 50.0 * _extraCostMultiplier, GetBaseCost());
			}
			int frameCount = nthFrame ?? WorldMap.Current.GetFrameCount(Identifier, includeUnderConstruction);
			if (frameCount < 0)
			{
				frameCount = WorldMap.Current.GetFrameCount(Identifier, includeUnderConstruction) + frameCount;
			}
			if (frameCount == 0)
			{
				foreach (KeyValuePair<ItemType, BigInteger> item in _calcFirstCost)
				{
					yield return item;
				}
				yield break;
			}
			foreach (KeyValuePair<ItemType, BigInteger> item2 in _calcBaseCost)
			{
				yield return KeyValuePair.Create(item2.Key, GameMath.Multiply(item2.Value, GetCostMultiplier(frameCount)));
			}
		}

		public virtual double GetCostMultiplier(int frameCount)
		{
			double num = 1.0 + 0.5 * (double)Math.Max(0, GamePlayer.Current.Prestige - 4);
			bool flag = GamePlayer.Current.HasTech("t3u_frame_cost");
			bool flag2 = GamePlayer.Current.HasTech("t6u_frame_cost");
			bool flag3 = GamePlayer.Current.HasTech("t9u_frame_cost");
			bool flag4 = GamePlayer.Current.HasTech("t11u_frame_cost");
			double x = 1.15 - (flag ? 0.01 : 0.0) - (flag2 ? 0.01 : 0.0) - (flag3 ? 0.01 : 0.0) - (flag4 ? 0.01 : 0.0);
			int num2 = Math.Min(8, frameCount);
			num *= Math.Pow(x, num2);
			frameCount -= num2;
			if (frameCount <= 0)
			{
				return num;
			}
			int num3 = Math.Min(20, frameCount);
			num *= Math.Pow(flag ? 1.03 : 1.15, num3);
			frameCount -= num3;
			if (frameCount <= 0)
			{
				return num;
			}
			int num4 = Math.Min(40, frameCount);
			num *= Math.Pow(flag2 ? 1.03 : 1.12, num4);
			frameCount -= num4;
			if (frameCount <= 0)
			{
				return num;
			}
			int num5 = Math.Min(60, frameCount);
			num *= Math.Pow(flag3 ? 1.02 : 1.12, num5);
			frameCount -= num5;
			if (frameCount <= 0)
			{
				return num;
			}
			return num * Math.Pow(flag4 ? (1.0099999904632568 + 1E-05 * (double)frameCount / ((GamePlayer.Current.Prestige > 0) ? Math.Pow(GamePlayer.Current.Prestige, 0.35) : 1.0)) : 1.1, frameCount);
		}

		public virtual bool IsValidPlacement(WorldMap map, Vector2Int pos)
		{
			return true;
		}

		public int GetAutoWorkerTier()
		{
			int num = 0;
			for (int i = 0; i < _workers.Length; i++)
			{
				if (_workers[i] != null)
				{
					num++;
				}
			}
			return num;
		}

		public virtual IEnumerable<KeyValuePair<ItemType, BigInteger>> GetAutoWorkerCost(int? nthWorker = null)
		{
			if (!nthWorker.HasValue)
			{
				nthWorker = GetAutoWorkerTier();
			}
			if (_calcWorkerFirstCost == null)
			{
				_calcWorkerFirstCost = GameMath.CreateItemCost("Autoworker" + Identifier, Tier, AutoworkerCostMultiplier, GetFirstCost() ?? GetBaseCost());
				_calcWorkerBaseCost = GameMath.CreateItemCost("Autoworker" + Identifier, Tier, AutoworkerCostMultiplier, GetBaseCost());
				if (_calcWorkerFirstCost.Count == 0 || !CheaperFirstWorker)
				{
					_calcWorkerFirstCost = _calcWorkerBaseCost;
				}
			}
			Dictionary<ItemType, BigInteger> dictionary = ((nthWorker == 0) ? _calcWorkerFirstCost : _calcWorkerBaseCost);
			foreach (KeyValuePair<ItemType, BigInteger> item in dictionary)
			{
				yield return KeyValuePair.Create(item.Key, GameMath.Multiply(item.Value, Math.Pow(1.2, nthWorker.Value)));
			}
		}

		public abstract AutoWorker CreateAutoWorker(WorldAnchor slot);

		public virtual void PurchaseAutoWorker(WorldAnchor anchor, Dictionary<ItemType, BigInteger> cost = null)
		{
			AutoWorker autoWorker = CreateAutoWorker(anchor);
			autoWorker.StartConstruction(cost ?? GetAutoWorkerCost());
			_workers[anchor.Slot] = autoWorker;
			ActiveFrame?.UpdateAutoWorker(anchor);
			ActiveCell?.UpdateWarningIcon();
		}

		public virtual float GetSpeedMultiplier(bool handCraft)
		{
			double num = GetUpgradeMultiplier(FrameUpgradeType.Speed) * (double)GetSpeedPenaltyMultiplier() * GamePlayer.Current.GetBuffSpeedMultiplier(handCraft) * GetServitudeSpeedMultiplier() * GetLogisticsSpeedMultiplier();
			foreach (FrameBuff buff in Buffs)
			{
				num *= buff.GetSpeedMultiplier(this, handCraft);
			}
			if (num >= 26.0)
			{
				SteamAchievement.Trigger("BigSpeedMultiplier");
			}
			return (float)num;
		}

		public double GetServitudeSpeedMultiplier()
		{
			if (ServitudeLevel <= 0)
			{
				return 1.0;
			}
			return 1.4;
		}

		public double GetLogisticsSpeedMultiplier()
		{
			if (!(_logisticsBonus > 0.0))
			{
				return 1.0;
			}
			return 1.0 + _logisticsBonus * 0.4;
		}

		public virtual float GetSpeedPenaltyMultiplier()
		{
			return 1f;
		}

		public virtual double GetProductivityMultiplier(bool handCraft)
		{
			double num = GetUpgradeMultiplier(FrameUpgradeType.Productivity) * (double)GamePlayer.Current.CityProductivityMultiplier * GamePlayer.Current.GetBuffProductivityMultiplier(handCraft) * GetServitudeProductivityMultiplier() * GetLogisticsProductivityMultiplier();
			foreach (FrameBuff buff in Buffs)
			{
				num *= buff.GetProductivityMultiplier(this, handCraft);
			}
			return num;
		}

		public double GetServitudeProductivityMultiplier()
		{
			if (ServitudeLevel != 2)
			{
				return 1.0;
			}
			return 1.05;
		}

		public double GetLogisticsProductivityMultiplier()
		{
			if (!_hasLogistics2 || !(_logisticsBonus > 0.0))
			{
				return 1.0;
			}
			return 1.0 + _logisticsBonus * 0.05;
		}

		public virtual double GetParallelMultiplier(bool handCraft)
		{
			double num = GetUpgradeMultiplier(handCraft ? FrameUpgradeType.HandcraftingParallel : FrameUpgradeType.Parallel) * (double)GamePlayer.Current.PrestigeMultiplier * GamePlayer.Current.GetBuffParallelMultiplier(handCraft);
			foreach (FrameBuff buff in Buffs)
			{
				num *= buff.GetParallelMultiplier(this, handCraft);
			}
			return num;
		}

		public double GetUpgradeMultiplier(FrameUpgradeType type, int? flag = null)
		{
			double num = 1.0;
			for (int i = 0; i < _availableUpgrades.Length; i++)
			{
				if (_upgrades[i] && _availableUpgrades[i].UpgradeType == type && (!flag.HasValue || _availableUpgrades[i].UpgradeFlag == flag))
				{
					num *= _availableUpgrades[i].UpgradeMultiplier;
				}
			}
			for (int j = 0; j < _tierUpgrades.Length; j++)
			{
				if (GamePlayer.Current.HasTech(_tierUpgrades[j]) && _tierUpgrades[j].UpgradeType == type && (!flag.HasValue || _tierUpgrades[j].UpgradeFlag == flag))
				{
					num = ((_tierUpgrades[j].Tier <= Tier) ? (num * _tierUpgrades[j].UpgradeMultiplier) : (num * _tierUpgrades[j].LowerTierMultiplier));
				}
			}
			if (PlacementTech != null && PlacementTech.UpgradeType == type && (!flag.HasValue || PlacementTech.UpgradeFlag == flag))
			{
				num *= CurrentPlacementBonus;
			}
			return num;
		}

		public void RemoveAutoWorker(AutoWorker worker)
		{
			WorldAnchor slot = worker.Slot;
			_workers[slot.Slot] = null;
			ActiveFrame?.UpdateAutoWorker(slot);
		}

		public AutoWorker GetAutoWorker(int slot)
		{
			return _workers[slot];
		}

		public IEnumerable<FrameUpgrade> GetAvailableUpgrades()
		{
			return _availableUpgrades;
		}

		public bool HasUpgrade(FrameUpgrade upgrade)
		{
			return _upgrades[upgrade.FrameOrdinal];
		}

		public bool UpgradeUnderConstruction(FrameUpgrade upgrade)
		{
			return _upgradeConstruction.ContainsKey(upgrade);
		}

		protected virtual int CheckAndPayCost(WorldAnchor anchor, IEnumerable<KeyValuePair<ItemType, BigInteger>> cost, int maxPayments, bool addToStats)
		{
			BigInteger bigInteger = maxPayments;
			foreach (KeyValuePair<ItemType, BigInteger> item in cost)
			{
				BigInteger inventoryCount = GamePlayer.Current.GetInventoryCount(item.Key);
				if (inventoryCount < item.Value)
				{
					ActiveFrame?.ShowNeedItem(anchor, item.Key, item.Value);
					return 0;
				}
				bigInteger = BigInteger.Min(bigInteger, inventoryCount / item.Value);
			}
			foreach (KeyValuePair<ItemType, BigInteger> item2 in cost)
			{
				GamePlayer.Current.RemoveInventoryItem(item2.Key, item2.Value * bigInteger, addToStats);
			}
			return (int)bigInteger;
		}

		public virtual void PurchaseUpgrade(WorldAnchor anchor)
		{
			FrameUpgrade frameUpgrade = FrameUpgrade.Get(Identifier, anchor.Slot);
			UpgradeConstructionProgress upgradeConstructionProgress = new UpgradeConstructionProgress(this, frameUpgrade, 0f, frameUpgrade.GetCost());
			_upgradeConstruction[frameUpgrade] = upgradeConstructionProgress;
			GamePlayer.Current.AddConstruction(upgradeConstructionProgress);
			ActiveFrame?.UpdateUpgradeSlot(anchor);
			ActiveCell?.UpdateWarningIcon();
		}

		public virtual void AddUpgrade(FrameUpgrade upgrade)
		{
			_upgrades[upgrade.FrameOrdinal] = true;
		}

		public ConstructionProgress GetUpgradeConstruction(FrameUpgrade upgrade)
		{
			_upgradeConstruction.TryGetValue(upgrade, out var value);
			return value;
		}

		public void CancelUpgradeConstruction(FrameUpgrade upgrade)
		{
			_upgradeConstruction[upgrade].Cancel();
		}

		public FrameUpgrade GetCustomUpgrade(int flag)
		{
			for (int i = 0; i < _availableUpgrades.Length; i++)
			{
				if (_availableUpgrades[i].UpgradeType == FrameUpgradeType.Custom && _availableUpgrades[i].UpgradeFlag == flag)
				{
					return _availableUpgrades[i];
				}
			}
			return null;
		}

		public virtual bool IsPartlyUpgraded()
		{
			for (int i = 0; i < _workers.Length; i++)
			{
				if (_workers[i] != null)
				{
					return true;
				}
			}
			for (int j = 0; j < _upgrades.Length; j++)
			{
				if (_upgrades[j])
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool IsFullyUpgrading()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < _availableUpgrades.Length; i++)
			{
				if (_availableUpgrades[i].IsAvailable)
				{
					num2++;
				}
				if (HasUpgrade(_availableUpgrades[i]) || UpgradeUnderConstruction(_availableUpgrades[i]))
				{
					num++;
				}
			}
			int num3 = 0;
			int autoWorkerMax = AutoWorkerMax;
			for (int j = 0; j < autoWorkerMax; j++)
			{
				if (_workers[j] != null)
				{
					num3++;
				}
			}
			if (num >= num2)
			{
				return num3 >= autoWorkerMax;
			}
			return false;
		}

		public virtual bool IsFullyUpgraded()
		{
			for (int i = 0; i < _upgrades.Length; i++)
			{
				if (!_upgrades[i])
				{
					return false;
				}
			}
			for (int j = 0; j < AutoWorkerMax; j++)
			{
				if (_workers[j] == null || _workers[j].UnderConstruction)
				{
					return false;
				}
			}
			return true;
		}

		public IEnumerable<KeyValuePair<ItemType, BigInteger>> getDeconstructRefund()
		{
			foreach (KeyValuePair<ItemType, BigInteger> item in GetPurchaseCost(-1, includeUnderConstruction: false))
			{
				yield return KeyValuePair.Create(item.Key, GameMath.Multiply(item.Value, 0.75));
			}
		}

		public virtual bool PurchaseCheapestUpgrade()
		{
			for (int i = 0; i < AutoWorkerMax; i++)
			{
				if (GetAutoWorker(i) == null)
				{
					PurchaseAutoWorker(new WorldAnchor(WorldAnchorType.AutoWorker, i));
					return true;
				}
			}
			for (int j = 0; j < _upgrades.Length; j++)
			{
				if (!_upgrades[j] && _availableUpgrades[j].RequiredTech.IsPurchased && !_upgradeConstruction.ContainsKey(_availableUpgrades[j]))
				{
					PurchaseUpgrade(new WorldAnchor(WorldAnchorType.Upgrade, j));
					return true;
				}
			}
			return false;
		}

		public IEnumerable<WorldFrame> GetAdjacentFrames()
		{
			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (x != 0 || y != 0)
					{
						WorldFrame frame = WorldMap.Current.GetFrame(new Vector2Int(Position.x + x, Position.y + y));
						if (frame != null && frame.Construction == null)
						{
							yield return frame;
						}
					}
				}
			}
		}

		public IEnumerable<byte> GetAdjacentTerrain(bool includeSelf = false, bool onlyCardinal = false)
		{
			if (onlyCardinal)
			{
				for (int i = 0; i < WorldMap.Directions.Length; i++)
				{
					yield return WorldMap.Current.GetTerrain(Position + WorldMap.Directions[i]);
				}
				yield break;
			}
			for (int i = -1; i <= 1; i++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (includeSelf || i != 0 || y != 0)
					{
						yield return WorldMap.Current.GetTerrain(new Vector2Int(Position.x + i, Position.y + y));
					}
				}
			}
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
			Buffs.Add(fb);
			if ((bool)ActiveCell)
			{
				ActiveCell.AddBuff(fb);
			}
			return true;
		}

		protected virtual void LoadFromJson(JsonValue val)
		{
			Position = new Vector2Int(val["X"], val["Y"]);
			JsonValue jsonValue = val["Workers"];
			for (int i = 0; i < _workers.Length; i++)
			{
				JsonValue jsonValue2 = jsonValue[i];
				if (jsonValue2 != JsonValue.Null)
				{
					_workers[i] = AutoWorker.FromJson(this, jsonValue2);
				}
			}
			foreach (JsonValue item in val["Upgrades"].AsJsonArray)
			{
				_upgrades[FrameUpgrade.Get(item.AsString).FrameOrdinal] = true;
			}
			if (val.AsJsonObject.ContainsKey("Construction"))
			{
				FrameConstructionProgress frameConstructionProgress = new FrameConstructionProgress(this);
				Construction = ConstructionProgress.FromJson(val["Construction"], frameConstructionProgress);
				GamePlayer.Current.AddConstruction(frameConstructionProgress);
			}
			foreach (KeyValuePair<string, JsonValue> item2 in val["UpgradeConstruction"].AsJsonObject)
			{
				FrameUpgrade frameUpgrade = FrameUpgrade.Get(Identifier, int.Parse(item2.Key));
				UpgradeConstructionProgress upgradeConstructionProgress = new UpgradeConstructionProgress(this, frameUpgrade);
				_upgradeConstruction[frameUpgrade] = ConstructionProgress.FromJson(item2.Value, upgradeConstructionProgress);
				GamePlayer.Current.AddConstruction(upgradeConstructionProgress);
			}
			if (val["Buffs"].IsJsonArray)
			{
				Buffs.FromJsonArray(val["Buffs"], FrameBuff.FromJson);
			}
		}

		public virtual JsonValue ToJson()
		{
			JsonArray jsonArray = new JsonArray();
			for (int i = 0; i < _workers.Length; i++)
			{
				jsonArray.Add(_workers[i]?.ToJson() ?? JsonValue.Null);
			}
			JsonArray jsonArray2 = new JsonArray();
			for (int j = 0; j < _upgrades.Length; j++)
			{
				if (_upgrades[j])
				{
					jsonArray2.Add(FrameUpgrade.Get(Identifier, j).RequiredTech.Identifier);
				}
			}
			JsonObject jsonObject = new JsonObject();
			foreach (KeyValuePair<FrameUpgrade, ConstructionProgress> item in _upgradeConstruction)
			{
				jsonObject[item.Key.FrameOrdinal.ToString()] = item.Value.ToJson();
			}
			JsonObject jsonObject2 = new JsonObject
			{
				{ "X", Position.x },
				{ "Y", Position.y },
				{ "Type", Identifier },
				{ "Workers", jsonArray },
				{ "Upgrades", jsonArray2 },
				{ "UpgradeConstruction", jsonObject }
			};
			if (Construction != null)
			{
				jsonObject2["Construction"] = Construction.ToJson();
			}
			jsonObject2["Buffs"] = Buffs.ToJsonArray();
			return jsonObject2;
		}

		public static WorldFrame Create(string name)
		{
			return (WorldFrame)Type.GetType("Assets.Source.World.Frames." + name).GetConstructor(new Type[0]).Invoke(new object[0]);
		}

		public static WorldFrame GetPreview(string name)
		{
			if (_previews.TryGetValue(name, out var value))
			{
				return value;
			}
			value = Create(name);
			_previews[name] = value;
			return value;
		}

		public static WorldFrame FromJson(JsonValue val)
		{
			WorldFrame worldFrame = Create(val["Type"]);
			worldFrame.LoadFromJson(val);
			return worldFrame;
		}

		public static void UpdatePlacementBonusAchievement()
		{
			if (_framesWithPlacementBonus == null)
			{
				_framesWithPlacementBonus = new List<WorldFrame>();
				foreach (WorldFrame value in _previews.Values)
				{
					if (value.PlacementTech != null)
					{
						_framesWithPlacementBonus.Add(value);
					}
				}
			}
			AchievementManager.CheckAchievement(new AchievementChecker("PlacementBonus", delegate
			{
				HashSet<string> hashSet = new HashSet<string>();
				int num = 0;
				foreach (WorldFrame frame in WorldMap.Current.Frames)
				{
					if (frame.CurrentPlacementBonus > 1.0)
					{
						num++;
						hashSet.Add(frame.Identifier);
					}
				}
				SteamStatsManager.Set(SteamStatType.PlacementBonus, num);
				if (hashSet.Count == _framesWithPlacementBonus.Count)
				{
					SteamAchievement.Trigger("PlacementAll");
				}
				return false;
			}));
		}

		public static void UpdateFullyUpgradedAchievement()
		{
			AchievementManager.CheckAchievement(new AchievementChecker("FullyUpgraded", delegate
			{
				int num = 0;
				foreach (WorldFrame frame in WorldMap.Current.Frames)
				{
					if (frame.IsFullyUpgraded())
					{
						num++;
					}
				}
				SteamStatsManager.Set(SteamStatType.FramesUpgraded, num);
				return false;
			}));
		}
	}
}
