using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Dialogs.Data;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;
using UnityEngine;
using Utils;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.BeggarEvent", "")]
	public class BeggarEvent : GameEventInstance, INegotiationPhaseHolder
	{
		private const int NEWS_DIALOG_INDEX = 0;

		private ITrader currentPlayerTrader;

		private ITrader currentNegotiatorTrader;

		private float baseValueDemanded;

		public HumanoidInstance Negotiator { get; set; }

		public Action<NegotiationEndResult> NegotiationFinishedEvent { get; set; }

		public BeggarEvent()
		{
		}

		public override bool CanStart()
		{
			if (base.CanStart())
			{
				return GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.Any((VillagePlace village) => base.Blueprint.Friendliness.Contains(village.FactionInstance.GetFriendliness()));
			}
			return false;
		}

		protected override GameEventPhaseBase GetStartingPhase()
		{
			baseValueDemanded = CalculateValueDemanded();
			SpawnNPC(setStartPosition: true);
			Subscribe();
			NegotiationPhaseConfig config = new NegotiationPhaseConfig
			{
				ChatGraphId = base.Blueprint.ChatGraphId,
				NewsMessage = GameEventUtil.BuildNewsData(this, 0),
				CountdownDurationMinutes = base.Blueprint.GetRandomDurationMinutes(),
				UseExistingNegotiatorNPC = Negotiator
			};
			return new NegotiationPhase(in config).NextPhaseOn(NegotiationEndResult.SuccessTraded, new GlobalStatModifyPhase("infamy", -3f)).NextPhaseOn(NegotiationEndResult.FailPlayerRejected, new GlobalStatModifyPhase("infamy", 1f));
		}

		public virtual void OnNegotiationChatOptionChosen(string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (dialogName != "start" || !(chatInitiator is HumanoidInstance humanoidInstance) || !(chatTarget is HumanoidInstance { ActiveBehaviour: INegotiator activeBehaviour }))
			{
				return;
			}
			currentPlayerTrader = null;
			currentNegotiatorTrader = null;
			switch (optionIndex)
			{
			case 0:
			{
				if (!base.Blueprint.HasInterpolatedValue("valueDemandedBasedOnWealth"))
				{
					FinishNegotiation();
					break;
				}
				float num = 1f;
				AttributeInstance attribute = chatInitiator.GetAttribute(AttributeType.NegotiationMultiplier);
				if (attribute != null)
				{
					num = attribute.Value;
				}
				float valueDemanded = baseValueDemanded * num;
				MonoSingleton<TradingManager>.Instance.OpenBeggarMenu(humanoidInstance.WorkerBehaviour, activeBehaviour, valueDemanded);
				currentPlayerTrader = humanoidInstance.WorkerBehaviour;
				currentNegotiatorTrader = activeBehaviour;
				break;
			}
			case 1:
				NegotiationFinishedEvent?.Invoke(NegotiationEndResult.FailPlayerRejected);
				break;
			case 2:
				break;
			}
		}

		public virtual void OnNegotiatorLeaveMap()
		{
		}

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (playerTrader == currentPlayerTrader && otherTrader == currentNegotiatorTrader)
			{
				FinishNegotiation();
				currentPlayerTrader = null;
				currentNegotiatorTrader = null;
			}
		}

		protected virtual void FinishNegotiation()
		{
			using PooledList<string> mapIds = base.Blueprint.StashMarkerMapIds.ToPooledListJanitor();
			MapPlaceGenerator.MaybeSpawnLootStash(base.Blueprint.BeggarStashMarkerSpawnChance, base.Blueprint.LootConfigByWealth.Dictionary, base.Blueprint.StashMarkerDurationRangeMinutes, base.Blueprint.StashMarkerSpawnDistanceRange, mapIds);
			NegotiationFinishedEvent?.Invoke(NegotiationEndResult.SuccessTraded);
		}

		public override void OnLoaded(bool fromSave)
		{
			base.OnLoaded(fromSave);
			Subscribe();
		}

		public override void OnEnd()
		{
			base.OnEnd();
			Unsubscribe();
		}

		public override void Dispose()
		{
			base.Dispose();
			Unsubscribe();
		}

		protected virtual void Subscribe()
		{
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent += OnTradeApplied;
		}

		protected virtual void Unsubscribe()
		{
			if (MonoSingleton<TradingManager>.IsInstantiated())
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
			}
		}

		protected virtual void SpawnNPC(bool setStartPosition)
		{
			VillagePlace villagePlace = FactionUtil.GetVillagesByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).PickRandom();
			FactionInstance factionInstance = villagePlace?.FactionInstance;
			if (factionInstance == null)
			{
				factionInstance = FactionUtil.GetFactionsByFriendliness(base.Blueprint.Friendliness, base.Blueprint.ExcludeFactions).PickRandom();
			}
			if (base.Blueprint.ResetFactionFriendliness)
			{
				factionInstance.SetPlayerFriendliness(factionInstance.Blueprint.FriendlinessRange.Random(), showNotification: false, processRelatedFactions: false);
			}
			string text = base.Blueprint.NpcId ?? "beggar_1";
			Negotiator = MonoSingleton<NPCManager>.Instance.SpawnBeggar(text, factionInstance.GetRandomBodyType(), Vector3.zero, villagePlace, factionInstance, null, this);
			if (setStartPosition)
			{
				NPCStartPositionManager.SetStartPositionsForAgents(Negotiator.WalkableModel, new List<IPathfindingAgent> { Negotiator });
			}
			BeggarBehaviour obj = Negotiator.ActiveBehaviour as BeggarBehaviour;
			TraderType byID = Repository<TraderTypeRepository, TraderType>.Instance.GetByID("beggar_negotiator");
			if (byID == null)
			{
				throw new Exception("Trader type 'beggar_negotiator' not found. Failed to initialize negotiator.");
			}
			obj.TraderType = byID;
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				Negotiator.GetGoapAgent()?.StartTicker();
			});
		}

		public virtual void FormatChatDialogContent(string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			dialogContent.Localize();
			dialogContent.Format((string text) => TextFormatting.FormatText(text, chatInitiator.GetCharacterInfo()));
		}

		private float CalculateValueDemanded()
		{
			int x = (int)MonoSingleton<BaseWealth>.Instance.GetTotalWealth();
			return base.Blueprint.GetInterpolatedValue("valueDemandedBasedOnWealth", x);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("negotiator", Negotiator);
			serializer.Write("baseValueDemanded", baseValueDemanded);
		}

		public BeggarEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			Negotiator = deserializer.ReadObject<HumanoidInstance>("negotiator");
			baseValueDemanded = deserializer.ReadFloat("baseValueDemanded");
		}
	}
}
