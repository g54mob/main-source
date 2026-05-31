using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
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

			public override string Name => "Upgrade: " + _upgrade.Name;

			public override Sprite Icon => _upgrade.RequiredTech.Icon;

			public UpgradeConstructionProgress(WorldFrame parent, FrameUpgrade upgrade)
			{
				_parent = parent;
				_upgrade = upgrade;
			}

			public UpgradeConstructionProgress(WorldFrame parent, FrameUpgrade upgrade, float time, IEnumerable<KeyValuePair<ItemType, int>> materials)
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

			public override string Name => "Frame: " + _frame.DisplayName;

			public override Sprite Icon => _frame.Icon;

			public FrameConstructionProgress(WorldFrame parent)
			{
				_frame = parent;
			}

			public FrameConstructionProgress(WorldFrame parent, float time, IEnumerable<KeyValuePair<ItemType, int>> materials)
				: base(time, materials)
			{
				_frame = parent;
			}

			protected override void OnConstructionCompleted()
			{
				_frame.Construction = null;
				_frame.OnConstructionCompleted();
			}

			protected override void OnConstructionCanceled()
			{
				WorldMap.Current.RemoveFrame(_frame);
				for (int i = 0; i < _frame.AutoWorkerCount; i++)
				{
					_frame.GetAutoWorker(i)?.CancelConstruction();
				}
				foreach (FrameUpgrade item in new List<FrameUpgrade>(_frame._upgradeConstruction.Keys))
				{
					_frame.CancelUpgradeConstruction(item);
				}
			}
		}

		public const float CostMultiplier = 50f;

		private static Dictionary<string, WorldFrame> _previews = new Dictionary<string, WorldFrame>();

		public readonly string Identifier;

		public WorldOverviewCell ActiveCell;

		protected float _extraCostMultiplier = 1f;

		protected List<ItemType> _firstCost;

		protected List<ItemType> _baseCost;

		protected float _baseConstructionTime = 1f;

		protected AutoWorker[] _workers;

		protected TechNode[] _tierUpgrades;

		protected FrameUpgrade[] _availableUpgrades;

		protected bool[] _upgrades;

		private Dictionary<FrameUpgrade, ConstructionProgress> _upgradeConstruction;

		private Dictionary<ItemType, int> _calcFirstCost;

		private Dictionary<ItemType, int> _calcBaseCost;

		private Dictionary<ItemType, int> _calcWorkerFirstCost;

		private Dictionary<ItemType, int> _calcWorkerBaseCost;

		public virtual float AutoworkerCostMultiplier => 6f;

		public Vector2Int Position { get; private set; }

		public ActiveWorldFrame ActiveFrame { get; private set; }

		public string PrefabName => Identifier;

		public ConstructionProgress Construction { get; protected set; }

		public ItemType ItemHint { get; protected set; }

		public string IconName { get; protected set; }

		public Sprite Icon => ItemHint?.Icon ?? SpriteLibrary.Get(IconName);

		public abstract int AutoWorkerCount { get; }

		public bool CheaperFirstWorker { get; protected set; } = true;

		public virtual TechNode RequiredTech => null;

		public TechNode PlacementTech { get; protected set; }

		public virtual string DisplayName => RequiredTech.Name;

		public virtual string Description => RequiredTech.Description;

		public virtual int Tier => RequiredTech.Tier;

		public virtual bool IsUnlocked => GamePlayer.Current.HasTech(RequiredTech);

		public bool UnderConstruction => Construction != null;

		public string MusicName { get; protected set; }

		public bool MusicIsImportant { get; protected set; }

		public float CurrentPlacementBonus { get; private set; } = 1f;

		public byte Terrain => WorldMap.Current.GetTerrain(Position);

		public WorldFrame()
		{
			Identifier = GetType().Name;
			_workers = new AutoWorker[AutoWorkerCount];
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
			for (int i = 0; i < _workers.Length; i++)
			{
				if (_workers[i] != null)
				{
					_workers[i].Update(delta);
				}
			}
		}

		public virtual void StartConstruction(IEnumerable<KeyValuePair<ItemType, int>> materials)
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

		public void UpdatePlacementBonus()
		{
			if (PlacementTech != null && GamePlayer.Current.HasTech(PlacementTech))
			{
				CurrentPlacementBonus = CalculatePlacementBonus();
			}
		}

		protected virtual float CalculatePlacementBonus()
		{
			return 1f;
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
		}

		public virtual IEnumerable<KeyValuePair<ItemType, int>> GetPurchaseCost(int? nthFrame = null)
		{
			if (_calcBaseCost == null)
			{
				_calcFirstCost = GameMath.CreateItemCost(Identifier, Tier, 50f * _extraCostMultiplier, _firstCost ?? _baseCost);
				_calcBaseCost = GameMath.CreateItemCost(Identifier, Tier, 50f * _extraCostMultiplier, _baseCost);
			}
			int frameCount = nthFrame ?? WorldMap.Current.GetFrameCount(Identifier);
			if (frameCount < 0)
			{
				frameCount = WorldMap.Current.GetFrameCount(Identifier) + frameCount;
			}
			if (frameCount == 0)
			{
				foreach (KeyValuePair<ItemType, int> item in _calcFirstCost)
				{
					yield return item;
				}
				yield break;
			}
			foreach (KeyValuePair<ItemType, int> item2 in _calcBaseCost)
			{
				float num = (float)item2.Value * GetCostMultiplier(frameCount);
				if (num > 2.1474836E+09f)
				{
					yield return KeyValuePair.Create(item2.Key, int.MaxValue);
				}
				else
				{
					yield return KeyValuePair.Create(item2.Key, Mathf.RoundToInt(num));
				}
			}
		}

		public float GetCostMultiplier(int frameCount)
		{
			float num = 1f + 0.5f * (float)GamePlayer.Current.Prestige;
			bool flag = GamePlayer.Current.HasTech("t3u_frame_cost");
			bool flag2 = GamePlayer.Current.HasTech("t6u_frame_cost");
			bool flag3 = GamePlayer.Current.HasTech("t9u_frame_cost");
			bool flag4 = GamePlayer.Current.HasTech("t11u_frame_cost");
			float f = 1.15f - (flag ? 0.01f : 0f) - (flag2 ? 0.01f : 0f) - (flag3 ? 0.01f : 0f) - (flag4 ? 0.01f : 0f);
			int num2 = Math.Min(8, frameCount);
			num *= Mathf.Pow(f, num2);
			frameCount -= num2;
			if (frameCount <= 0)
			{
				return num;
			}
			int num3 = Math.Min(20, frameCount);
			num *= Mathf.Pow(flag ? 1.03f : 1.15f, num3);
			frameCount -= num3;
			if (frameCount <= 0)
			{
				return num;
			}
			int num4 = Math.Min(40, frameCount);
			num *= Mathf.Pow(flag2 ? 1.03f : 1.12f, num4);
			frameCount -= num4;
			if (frameCount <= 0)
			{
				return num;
			}
			int num5 = Math.Min(60, frameCount);
			num *= Mathf.Pow(flag3 ? 1.02f : 1.12f, num5);
			frameCount -= num5;
			if (frameCount <= 0)
			{
				return num;
			}
			return num * Mathf.Pow(flag4 ? (1.01f + 1E-05f * (float)frameCount / ((GamePlayer.Current.Prestige > 0) ? Mathf.Pow(GamePlayer.Current.Prestige, 0.35f) : 1f)) : 1.1f, frameCount);
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

		public virtual IEnumerable<KeyValuePair<ItemType, int>> GetAutoWorkerCost(int? nthWorker = null)
		{
			if (!nthWorker.HasValue)
			{
				nthWorker = GetAutoWorkerTier();
			}
			if (_calcWorkerFirstCost == null)
			{
				_calcWorkerFirstCost = GameMath.CreateItemCost("Autoworker" + Identifier, Tier, AutoworkerCostMultiplier, _firstCost);
				_calcWorkerBaseCost = GameMath.CreateItemCost("Autoworker" + Identifier, Tier, AutoworkerCostMultiplier, _baseCost);
				if (_calcWorkerFirstCost.Count == 0 || !CheaperFirstWorker)
				{
					_calcWorkerFirstCost = _calcWorkerBaseCost;
				}
			}
			Dictionary<ItemType, int> dictionary = ((nthWorker == 0) ? _calcWorkerFirstCost : _calcWorkerBaseCost);
			foreach (KeyValuePair<ItemType, int> item in dictionary)
			{
				yield return KeyValuePair.Create(item.Key, Mathf.RoundToInt((float)item.Value * Mathf.Pow(1.2f, nthWorker.Value)));
			}
		}

		public abstract AutoWorker CreateAutoWorker(WorldAnchor slot);

		public virtual void PurchaseAutoWorker(WorldAnchor anchor)
		{
			AutoWorker autoWorker = CreateAutoWorker(anchor);
			autoWorker.StartConstruction(GetAutoWorkerCost());
			_workers[anchor.Slot] = autoWorker;
			ActiveFrame?.UpdateAutoWorker(anchor);
			ActiveCell?.UpdateWarningIcon();
		}

		public virtual float GetSpeedMultiplier()
		{
			return GetUpgradeMultiplier(FrameUpgradeType.Speed) * GetSpeedPenaltyMultiplier();
		}

		public virtual float GetSpeedPenaltyMultiplier()
		{
			return 1f;
		}

		public virtual float GetProductivityMultiplier()
		{
			return GetUpgradeMultiplier(FrameUpgradeType.Productivity);
		}

		public virtual float GetParallelMultiplier(bool handCraft)
		{
			return GetUpgradeMultiplier(handCraft ? FrameUpgradeType.HandcraftingParallel : FrameUpgradeType.Parallel) * GamePlayer.Current.PrestigeMultiplier;
		}

		public float GetUpgradeMultiplier(FrameUpgradeType type, int? flag = null)
		{
			float num = 1f;
			for (int i = 0; i < _availableUpgrades.Length; i++)
			{
				if (_upgrades[i] && _availableUpgrades[i].UpgradeType == type && (!flag.HasValue || _availableUpgrades[i].UpgradeFlag == (float?)flag))
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

		protected virtual int CheckAndPayCost(WorldAnchor anchor, IEnumerable<KeyValuePair<ItemType, int>> cost, int maxPayments, bool addToStats)
		{
			int num = maxPayments;
			foreach (KeyValuePair<ItemType, int> item in cost)
			{
				int inventoryCount = GamePlayer.Current.GetInventoryCount(item.Key);
				if (inventoryCount < item.Value)
				{
					ActiveFrame?.ShowNeedItem(anchor, item.Key, item.Value);
					return 0;
				}
				num = Math.Min(num, inventoryCount / item.Value);
			}
			foreach (KeyValuePair<ItemType, int> item2 in cost)
			{
				GamePlayer.Current.RemoveInventoryItem(item2.Key, item2.Value * num, addToStats);
			}
			return num;
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
				if (_availableUpgrades[i].UpgradeType == FrameUpgradeType.Custom && _availableUpgrades[i].UpgradeFlag == (float)flag)
				{
					return _availableUpgrades[i];
				}
			}
			return null;
		}

		public bool IsFullyUpgraded()
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
			int autoWorkerCount = AutoWorkerCount;
			for (int j = 0; j < autoWorkerCount; j++)
			{
				if (_workers[j] != null)
				{
					num3++;
				}
			}
			if (num >= num2)
			{
				return num3 >= autoWorkerCount;
			}
			return false;
		}

		public IEnumerable<KeyValuePair<ItemType, int>> getDeconstructRefund()
		{
			foreach (KeyValuePair<ItemType, int> item in GetPurchaseCost(-1))
			{
				yield return KeyValuePair.Create(item.Key, Mathf.RoundToInt((float)item.Value * 0.75f));
			}
		}

		public virtual IEnumerable<KeyValuePair<ItemType, int>> GetCheapestUpgradeCost()
		{
			yield break;
		}

		public virtual bool PurchaseCheapestUpgrade()
		{
			for (int i = 0; i < AutoWorkerCount; i++)
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
						if (frame != null)
						{
							yield return frame;
						}
					}
				}
			}
		}

		public IEnumerable<byte> GetAdjacentTerrain(bool includeSelf = false)
		{
			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (includeSelf || x != 0 || y != 0)
					{
						yield return WorldMap.Current.GetTerrain(new Vector2Int(Position.x + x, Position.y + y));
					}
				}
			}
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
	}
}
