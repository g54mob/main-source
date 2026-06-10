using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Managers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.State
{
	[FVSerializableKey("TraderBehaviour", "TraderBehavior")]
	public class TraderBehaviour : HumanoidBehaviour, ITrader
	{
		private TraderType traderType;

		private TradingPostComponentInstance tradingPostComponentInstance;

		private BaseBuildingInstance tradingPostBuildingInstance;

		private Vec3Int tradingPostReservedPosition;

		public BaseBuildingInstance TradingPostBuildingInstance
		{
			get
			{
				return tradingPostBuildingInstance;
			}
			set
			{
				tradingPostBuildingInstance = value;
			}
		}

		public Vec3Int TradingPostReservedPosition
		{
			get
			{
				return tradingPostReservedPosition;
			}
			set
			{
				tradingPostReservedPosition = value;
			}
		}

		public TradingPostComponentInstance TradingPostComponentInstance
		{
			get
			{
				if (tradingPostComponentInstance == null && tradingPostBuildingInstance != null)
				{
					tradingPostComponentInstance = tradingPostBuildingInstance.GetComponentInstance<TradingPostComponentInstance>();
				}
				return tradingPostComponentInstance;
			}
			set
			{
				tradingPostComponentInstance = value;
				tradingPostBuildingInstance = tradingPostComponentInstance?.OwnerBuilding;
				if (value == null)
				{
					tradingPostReservedPosition = Vec3Int.zero;
				}
			}
		}

		public bool KnowsRumoursBanditCamp { get; set; }

		public bool DontShowDialogOnTalkTo { get; set; }

		public IWorldMapPlaceReference BanditCampToldSettlerAbout { get; set; }

		public override BehaviourType BehaviourType => BehaviourType.Trader;

		public TraderType TraderType => traderType;

		public override string IndicatorPrefabName => "trader_indicator";

		public override string OverheadBillboardPrefabName => "trader_overhead_billboard";

		public Storage Storage => base.Humanoid.Storage;

		public FactionInstance Faction => base.Humanoid.Faction;

		protected override string HumanTypeId => "trader";

		public int TradingPostReservedPositionIndex { get; set; }

		public TraderBehaviour()
		{
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			base.Humanoid.SetWalkableModel(base.Humanoid.CurrentHumanType.WalkableModelFriendly);
			base.Humanoid.SetCombatAiAgent("TraderAgent");
			base.Humanoid.CombatAi.SetState(CombatAiState.IsAggressive, false);
		}

		public override void OnSpawn()
		{
			base.OnSpawn();
			if (GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				return;
			}
			List<EquipmentInstance> list = new List<EquipmentInstance>();
			list.AddRange(base.Inventory.GetEquipments());
			foreach (EquipmentInstance item in list)
			{
				MonoSingleton<NPCController>.Instance.EquipItem(item, base.Inventory);
			}
		}

		protected override Agent CreateGoapAgent()
		{
			return new TraderGoapAgent(base.Humanoid);
		}

		public override string GetMultiselectName()
		{
			return "trader";
		}

		public override string GetGoapAgentId()
		{
			return "trader";
		}

		public override void OnTrapTriggered(TrapComponentInstance trap)
		{
		}

		public override void Dispose()
		{
			foreach (AnimalInstance item in base.Humanoid.Pets.ToList())
			{
				if (!item.HasDisposed)
				{
					item.AssignPetOwner(null);
					item.RopeTo(null);
					item.SetAnimalType(AnimalType.Domestic);
					item.LeaveMap();
				}
			}
			tradingPostBuildingInstance = null;
			tradingPostComponentInstance = null;
			tradingPostReservedPosition = Vec3Int.zero;
			base.Dispose();
		}

		public void InitTrader(TraderType traderType)
		{
			this.traderType = traderType;
			if (GlobalSaveController.CurrentVillageData.DateAndTime.DaysTotal < 15)
			{
				Log.Info("KnowsRumours = False because for the first 15 days, no trader is allowed to know rumours", "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\TraderBehaviour.cs");
				KnowsRumoursBanditCamp = false;
			}
			else
			{
				KnowsRumoursBanditCamp = UnityEngine.Random.value < traderType.KnowsRumoursBanditCampChance;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\TraderBehaviour.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("InitTrader knowsRumoursBanditCamp = ");
				messageBuilder.AppendFormatted(KnowsRumoursBanditCamp);
				messageBuilder.AppendLiteral(", humanoid: ");
				messageBuilder.AppendFormatted(base.Humanoid);
			}
			Log.Info(messageBuilder);
		}

		public float GetSellMultiplier()
		{
			AttributeInstance attributeInstance = base.Humanoid.Stats.GetAttributeInstance(AttributeType.TradingValueNPC);
			if (attributeInstance != null)
			{
				return 1.4f * attributeInstance.Value * Faction.TradeDealMultiplier;
			}
			return 1.4f * Faction.TradeDealMultiplier;
		}

		public float GetBuyMultiplier()
		{
			AttributeInstance attributeInstance = base.Humanoid.Stats.GetAttributeInstance(AttributeType.TradingValueNPC);
			if (attributeInstance != null)
			{
				return 0.6f / attributeInstance.Value;
			}
			return 0.6f;
		}

		public List<TradeResource> GetResources(ITrader otherTrader)
		{
			int workersCount = MonoSingleton<WorkerManager>.Instance.GetWorkersCount();
			int count = MonoSingleton<CaptiveNpcManager>.Instance.PlayersCaptives.Count;
			List<TradeResource> resources = TraderUtils.GetResources(base.Humanoid.Storage);
			foreach (AnimalInstance item3 in MonoSingleton<AnimalManager>.Instance.Animals.Keys.Where((AnimalInstance animal) => animal.PetOwner == base.Humanoid))
			{
				TraderStockItem traderStockItem = item3.TraderStockItem;
				TradeForbiddenReason forbidden = ((traderStockItem != null && traderStockItem.Type == TraderStockType.AnimalNoTrade) ? TradeForbiddenReason.AnimalNoTrade : TradeForbiddenReason.None);
				TradeResource item = new TradeResource(item3, forbidden);
				resources.Add(item);
			}
			float multiplierInterpolated = MonoSingleton<CaptiveNpcManager>.Instance.MaxCaptivesToSellByPlayerCaptivesCount.GetMultiplierInterpolated(count);
			multiplierInterpolated = Math.Max(multiplierInterpolated, MonoSingleton<CaptiveNpcManager>.Instance.MaxCaptivesToSellByPlayerWorkersCount.GetMultiplierInterpolated(workersCount));
			int num = 0;
			foreach (HumanoidInstance item4 in MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.IsCaptive() && npc.CaptiveNpcBehaviour.Owner == base.Humanoid))
			{
				TradeForbiddenReason tradeForbiddenReason = base.Humanoid.Faction?.GetPrisonerTradeStatus(item4) ?? TradeForbiddenReason.None;
				if ((float)num >= multiplierInterpolated)
				{
					tradeForbiddenReason = TradeForbiddenReason.WontOfferMorePrisoners;
				}
				if (tradeForbiddenReason == TradeForbiddenReason.None)
				{
					num++;
				}
				TradeResource item2 = new TradeResource(item4, tradeForbiddenReason);
				resources.Add(item2);
			}
			return resources;
		}

		public string GetTraderName()
		{
			return base.Humanoid.Info.GetFullName();
		}

		public string GetSettlementName()
		{
			return base.Humanoid.OriginVillage?.Value?.Name;
		}

		public Sprite GetHeraldryCrest()
		{
			return base.Humanoid.GetHeraldryCrest();
		}

		public Sprite GetHeraldryBackground()
		{
			return base.Humanoid.GetHeraldryBackground();
		}

		public float GetBargainMultiplier()
		{
			return 1f;
		}

		public void AddItemToStorage(TradeResource tradeResource, int count)
		{
			if (tradeResource.IsCreature)
			{
				if (tradeResource.Creature is AnimalInstance animalInstance)
				{
					animalInstance.AssignPetOwner(base.Humanoid);
					animalInstance.RopeTo(base.Humanoid);
					animalInstance.SetAnimalType(AnimalType.DomesticNpc);
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.None, animalInstance);
				}
				else if (tradeResource.Creature is HumanoidInstance humanoidInstance && humanoidInstance.IsCaptive())
				{
					if (!(humanoidInstance.ActiveBehaviour is PrisonerBehaviour))
					{
						humanoidInstance.SetActiveBehaviour<PrisonerBehaviour>();
					}
					humanoidInstance.PrisonerBehaviour.Owner = base.Humanoid;
					humanoidInstance.RopeTo(base.Humanoid);
				}
				return;
			}
			ResourceInstance resourceToAdd = new ResourceInstance(tradeResource.Resource, count);
			int num = base.Humanoid.Storage.Add(resourceToAdd, count);
			if (num < count)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\TraderBehaviour.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trader: Added ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(count);
					messageBuilder.AppendLiteral(" to the storage. There was not enough space.");
				}
				Log.Error(messageBuilder);
			}
		}

		public void RemoveItemFromStorage(TradeResource tradeResource, int count)
		{
			base.Humanoid.Storage.Consume(tradeResource.Resource, count);
		}

		public bool CanTradeResource(TradeResource resource)
		{
			return TraderUtils.CanTradeResource(TraderType, resource, base.Humanoid.OriginVillage?.VillageValue, base.Humanoid.Faction, useMapTypeModifiers: false);
		}

		public void OnSettlerTalkTo(WorkerBehaviour worker)
		{
			if (DontShowDialogOnTalkTo)
			{
				MonoSingleton<TradingManager>.Instance.OpenTradingMenu(worker, this);
			}
			else
			{
				MonoSingleton<ChatGraphManager>.Instance.StartNew("merchant", worker.Humanoid, base.Humanoid);
			}
		}

		public bool IsTraderFriendly()
		{
			return true;
		}

		public int GetStorageCapacity()
		{
			int num = traderType.StorageCapacity;
			if (base.Humanoid.Pets != null)
			{
				foreach (AnimalInstance pet in base.Humanoid.Pets)
				{
					if (pet?.LifePhase != null)
					{
						num += pet.LifePhase.CaravanStorageCapacity;
					}
				}
			}
			foreach (CaptiveNpcBehaviour captive in MonoSingleton<CaptiveNpcManager>.Instance.Captives)
			{
				if (captive.Owner == base.Humanoid)
				{
					int caravanStorageCapacity = captive.Humanoid.CaravanStorageCapacity;
					if (caravanStorageCapacity > 0)
					{
						num += caravanStorageCapacity;
					}
				}
			}
			return num;
		}

		public float GetMinimumNutrition()
		{
			return 0f;
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			return Faction.GetPrisonerTradeStatus(creatureBase);
		}

		public float GetPerResourcePriceMultiplier(TradeResource resource)
		{
			return TraderUtils.GetPerResourcePriceMultiplier(traderType, resource, base.Humanoid.OriginVillage?.VillageValue, base.Humanoid.Faction, useMapTypeModifiers: false);
		}

		public VillagePlace GetTraderVillagePlace()
		{
			return base.Humanoid.OriginVillage?.VillageValue;
		}

		public Vec3Int GetGridPosition()
		{
			return base.Humanoid.GetGridPosition();
		}

		public override void Serialize(FVSerializer serializer)
		{
			serializer.Write("traderTypeId", traderType.GetID());
			serializer.Write("tradingPost", tradingPostBuildingInstance);
			serializer.Write("tradingPostReservedPosition", tradingPostReservedPosition);
			serializer.Write("TradingPostReservedPositionIndex", TradingPostReservedPositionIndex);
			serializer.Write("knowsRumoursBanditCamp", KnowsRumoursBanditCamp);
			serializer.Write("banditCampToldSettlerAbout", BanditCampToldSettlerAbout);
			serializer.Write("DontShowDialogOnTalkTo", DontShowDialogOnTalkTo);
		}

		public TraderBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			string text = deserializer.ReadString("traderTypeId");
			traderType = Repository<TraderTypeRepository, TraderType>.Instance.GetByID(text);
			if (traderType == null)
			{
				throw new Exception("Trader type '" + text + "' not found. Failed to load trader.");
			}
			tradingPostBuildingInstance = deserializer.ReadObject<BaseBuildingInstance>("tradingPost");
			tradingPostReservedPosition = deserializer.ReadVec3Int("tradingPostReservedPosition");
			TradingPostReservedPositionIndex = deserializer.ReadInt("TradingPostReservedPositionIndex");
			KnowsRumoursBanditCamp = deserializer.ReadBool("knowsRumoursBanditCamp", defaultValue: true);
			BanditCampToldSettlerAbout = deserializer.ReadObject<IWorldMapPlaceReference>("banditCampToldSettlerAbout");
			DontShowDialogOnTalkTo = deserializer.ReadBool("DontShowDialogOnTalkTo");
		}
	}
}
