using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.State
{
	[FVSerializableKey("NegotiatorBehaviour", "NegotiatorBehavior")]
	public class NegotiatorBehaviour : HumanoidBehaviour, INegotiator, ITrader
	{
		private TraderType traderType;

		private bool wantsToNegotiate;

		private int? wontNegotiateWithWorkerId;

		private string wontNegotiateWithWorkerBBTTextKey;

		public override BehaviourType BehaviourType => BehaviourType.Negotiator;

		public TraderType TraderType
		{
			get
			{
				return traderType;
			}
			set
			{
				traderType = value;
			}
		}

		public bool WantsToNegotiate
		{
			get
			{
				return wantsToNegotiate;
			}
			set
			{
				wantsToNegotiate = value;
			}
		}

		public int? WontNegotiateWithWorkerId
		{
			get
			{
				return wontNegotiateWithWorkerId;
			}
			set
			{
				wontNegotiateWithWorkerId = value;
			}
		}

		public string WontNegotiateWithWorkerBBTTextKey
		{
			get
			{
				return wontNegotiateWithWorkerBBTTextKey;
			}
			set
			{
				wontNegotiateWithWorkerBBTTextKey = value;
			}
		}

		public FactionInstance Faction => base.Humanoid.Faction;

		protected override string HumanTypeId => "enemy";

		public override string IndicatorPrefabName => "negotiator_indicator";

		public event INegotiator.InteractedWithHandler InteractedWithEvent;

		public NegotiatorBehaviour()
		{
		}

		protected override void OnBeforeFirstActivate()
		{
			WantsToNegotiate = true;
		}

		protected override void OnActivate()
		{
			base.OnActivate();
			base.Humanoid.SetWalkableModel(base.Humanoid.CurrentHumanType.WalkableModelFriendly);
			base.Humanoid.SetCombatAiAgent("NegotiatorNPCAgent");
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
			return new NPCNegotiatorGoapAgent(base.Humanoid);
		}

		public override string GetMultiselectName()
		{
			return "negotiator";
		}

		public override string GetGoapAgentId()
		{
			return "negotiator";
		}

		public void OnInteractedWith(HumanoidInstance worker)
		{
			this.InteractedWithEvent?.Invoke(worker);
		}

		public string GetLocalizedMenuItemText()
		{
			return MonoSingleton<LocalizationController>.Instance.GetText("general_negotiate_with").Replace("<negotiator_name>", base.Humanoid.Info.GetFullName());
		}

		public float GetSellMultiplier()
		{
			return 1.4f;
		}

		public float GetBuyMultiplier()
		{
			return 0.6f;
		}

		public List<TradeResource> GetResources(ITrader otherTrader)
		{
			return new List<TradeResource>();
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
				if (tradeResource.Creature is HumanoidInstance humanoidInstance && humanoidInstance.IsCaptive())
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
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\NegotiatorBehaviour.cs");
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
			Log.Error("Tried to remove item from Negotiator storage. Negotiators don't offer any resources, this should not happen!", "C:\\GIT\\dev\\Assets\\Scripts\\Models\\State\\NPC\\Behaviors\\NegotiatorBehaviour.cs");
		}

		public float GetPerResourcePriceMultiplier(TradeResource resource)
		{
			return TraderUtils.GetPerResourcePriceMultiplier(traderType, resource, base.Humanoid.OriginVillage?.VillageValue, base.Humanoid.Faction, useMapTypeModifiers: false) * GetExtortionResourcePriceMultiplier(resource);
		}

		public bool CanTradeResource(TradeResource resource)
		{
			List<string> list = ListPool<string>.Get();
			list.Add("dont_trade_neutral");
			bool num = TraderUtils.CanTradeResource(TraderType, resource, base.Humanoid.OriginVillage?.VillageValue, base.Humanoid.Faction, useMapTypeModifiers: false, list);
			ListPool<string>.Return(list);
			if (num)
			{
				return AcceptsResource(resource.Resource);
			}
			return false;
		}

		private bool AcceptsResource(Resource resource)
		{
			if (base.Humanoid.Faction == null)
			{
				return true;
			}
			foreach (TraderStockModifier extortionStockModifier in base.Humanoid.Faction.Blueprint.ExtortionStockModifiers)
			{
				if (!extortionStockModifier.CanTradeResource(resource))
				{
					return false;
				}
			}
			return true;
		}

		private float GetExtortionResourcePriceMultiplier(TradeResource resource)
		{
			if (base.Humanoid.Faction == null)
			{
				return 1f;
			}
			float num = 1f;
			foreach (TraderStockModifier extortionStockModifier in base.Humanoid.Faction.Blueprint.ExtortionStockModifiers)
			{
				num *= extortionStockModifier.GetPriceModifier(resource);
			}
			return num;
		}

		public VillagePlace GetTraderVillagePlace()
		{
			return base.Humanoid.OriginVillage?.VillageValue;
		}

		public bool IsTraderFriendly()
		{
			return true;
		}

		public int GetStorageCapacity()
		{
			return traderType.StorageCapacity;
		}

		public float GetMinimumNutrition()
		{
			return 0f;
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			if (base.Humanoid.Faction == null)
			{
				return TradeForbiddenReason.None;
			}
			return base.Humanoid.Faction.GetPrisonerTradeStatus(creatureBase);
		}

		public override void Serialize(FVSerializer serializer)
		{
			serializer.Write("traderTypeId", traderType.GetID());
			serializer.Write("wantsToNegotiate", wantsToNegotiate);
			serializer.Write("wontNegotiateWithWorkerId", wontNegotiateWithWorkerId);
			serializer.Write("wontNegotiateWithWorkerBBTTextKey", wontNegotiateWithWorkerBBTTextKey);
		}

		public NegotiatorBehaviour(FVDeserializer deserializer)
			: base(deserializer)
		{
			string text = deserializer.ReadString("traderTypeId");
			traderType = Repository<TraderTypeRepository, TraderType>.Instance.GetByID(text);
			if (traderType == null)
			{
				throw new Exception("Trader type '" + text + "' not found. Failed to load negotiator.");
			}
			wantsToNegotiate = deserializer.ReadBool("wantsToNegotiate");
			wontNegotiateWithWorkerId = deserializer.ReadNullableInt("wontNegotiateWithWorkerId");
			wontNegotiateWithWorkerBBTTextKey = deserializer.ReadString("wontNegotiateWithWorkerBBTTextKey");
		}
	}
}
