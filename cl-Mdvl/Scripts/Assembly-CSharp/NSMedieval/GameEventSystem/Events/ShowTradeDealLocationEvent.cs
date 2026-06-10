using System;
using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.ShowTradeDealLocationEvent", "")]
	public class ShowTradeDealLocationEvent : BeggarEvent
	{
		private const int BodyGuardStrengthPoints = 250;

		[SerializeField]
		private List<HumanoidInstance> guards;

		private SortingGroupsWithWealth selectedGroupToDeliver;

		private List<SortingGroupsWithWealth> dialogOptionTraderDemands = new List<SortingGroupsWithWealth>();

		public ShowTradeDealLocationEvent()
		{
		}

		public override void OnNegotiatorLeaveMap()
		{
			base.OnNegotiatorLeaveMap();
			foreach (HumanoidInstance guard in guards)
			{
				guard.RetreatFromMap();
			}
		}

		public override bool CanStart()
		{
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.TradeDeals.Count > 0)
			{
				return false;
			}
			foreach (GameEventInstance runningEvent in MonoSingleton<GameEventSystem>.Instance.RunningEvents)
			{
				if (runningEvent.Blueprint.GetID() == base.Blueprint.GetID())
				{
					return false;
				}
			}
			foreach (WorldMapMarkerPlace marker in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.Markers)
			{
				if (marker.HasTradeDeal)
				{
					return false;
				}
			}
			return base.CanStart();
		}

		public override void Dispose()
		{
			base.Dispose();
			guards?.Clear();
			guards = null;
		}

		public override void OnNegotiationChatOptionChosen(string dialogName, int optionIndex, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			if (!(dialogName != "start") && chatInitiator is HumanoidInstance && chatTarget is HumanoidInstance humanoidInstance && humanoidInstance.ActiveBehaviour is INegotiator && optionIndex != 3)
			{
				FinishNegotiation(optionIndex);
			}
		}

		public override void FormatChatDialogContent(string dialogName, DialogContent dialogContent, CreatureBase chatInitiator, CreatureBase chatTarget)
		{
			dialogContent.Localize();
			dialogContent.Format(DialogFormatFunction);
			System.Random random = new System.Random();
			dialogOptionTraderDemands = new List<SortingGroupsWithWealth>(base.Blueprint.TradeDealDemands);
			dialogOptionTraderDemands.ShuffleInPlace(random);
			StringBuilder stringBuilder = new StringBuilder();
			FactionInstance factionInstance = (chatTarget as HumanoidInstance)?.Faction;
			for (int i = 0; i < 3; i++)
			{
				SortingGroupsWithWealth sortingGroupsWithWealth = dialogOptionTraderDemands[i];
				DialogOption dialogOption = dialogContent.Options[i];
				stringBuilder.Clear();
				stringBuilder.Append(MonoSingleton<LocalizationController>.Instance.GetText("trade_deal_demand_option"));
				stringBuilder.Replace("<resources>", MonoSingleton<LocalizationController>.Instance.GetText(sortingGroupsWithWealth.TextKey));
				stringBuilder.Replace("<wealth>", sortingGroupsWithWealth.MinimumWealth.ToString());
				stringBuilder.Replace("<faction_name>", factionInstance?.NameLocalized);
				dialogOption.Text = stringBuilder.ToString();
			}
		}

		protected override void SpawnNPC(bool _)
		{
			base.SpawnNPC(setStartPosition: false);
			(base.Negotiator.ActiveBehaviour as BeggarBehaviour)?.SetOnlyNegotiateWithRole("broker", 0, "cannot_negotiate_with_non_broker");
			SpawnGuards(base.Negotiator.Faction, base.Negotiator.OriginVillage);
		}

		protected override void Subscribe()
		{
			base.Subscribe();
			MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent += OnFriendlinessChanged;
		}

		protected override void Unsubscribe()
		{
			base.Unsubscribe();
			if (MonoSingleton<FactionsController>.IsInstantiated())
			{
				MonoSingleton<FactionsController>.Instance.FriendlinessChangedEvent -= OnFriendlinessChanged;
			}
		}

		private void FinishNegotiation(int optionIndex)
		{
			if (optionIndex >= 0 && optionIndex < dialogOptionTraderDemands.Count)
			{
				selectedGroupToDeliver = dialogOptionTraderDemands[optionIndex];
				if (selectedGroupToDeliver != null)
				{
					MapPlaceGenerator.MaybeSpawnTradeDealPlace(1f, base.Blueprint.StashMarkerDurationRangeMinutes, base.Blueprint.StashMarkerSpawnDistanceRange, base.Negotiator.Faction).SetMandatoryResourceGroups(selectedGroupToDeliver);
				}
			}
			base.NegotiationFinishedEvent?.Invoke(NegotiationEndResult.SuccessTraded);
		}

		private string DialogFormatFunction(string text)
		{
			if (!text.Contains("<village_name>") && !text.Contains("<faction_name>"))
			{
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(text);
			stringBuilder.Replace("<village_name>", GlobalSaveController.CurrentVillageData.Name);
			stringBuilder.Replace("<faction_name>", base.Negotiator.Faction.NameLocalized);
			return stringBuilder.ToString();
		}

		private void SpawnGuards(FactionInstance faction, VillagePlaceReference originVillage)
		{
			int pointsToSpend = 250;
			if (!MonoSingleton<RaidEnemySelector>.Instance.PurchaseBodyGuards(in pointsToSpend, out var enemiesToSpawn, faction.BlueprintId))
			{
				MonoSingleton<RaidEnemySelector>.Instance.PurchaseBodyGuards(in pointsToSpend, out enemiesToSpawn, "general");
			}
			guards = new List<HumanoidInstance>();
			foreach (IEnemyPurchaseUnit item in enemiesToSpawn)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\ShowTradeDealLocationEvent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Will spawn guard:'");
					messageBuilder.AppendFormatted(item.GetID());
					messageBuilder.AppendLiteral("'.");
				}
				GameEventInstance.Logger.Info(in messageBuilder);
				HumanoidInstance bodyguard = MonoSingleton<NPCManager>.Instance.SpawnTraderBodyguard(item.GetID(), faction.GetRandomBodyType(), Vector3.zero, originVillage?.VillageValue, faction, this);
				MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
				{
					bodyguard.GetGoapAgent()?.StartTicker();
				});
				bodyguard.CustomWarningMessage = null;
				guards.Add(bodyguard);
			}
			using PooledList<HumanoidInstance> pooledList = ListPool<HumanoidInstance>.GetJanitor();
			pooledList.AddRange(guards);
			pooledList.Add(base.Negotiator);
			NPCStartPositionManager.SetStartPositionsForAgents(base.Negotiator.WalkableModel, pooledList);
		}

		private void OnFriendlinessChanged(FactionFriendliness friendliness, FactionInstance faction)
		{
			if ((friendliness == FactionFriendliness.Hostile || friendliness == FactionFriendliness.PermanentlyHostile) && base.Negotiator != null && base.Negotiator.OriginVillage?.FactionInstance != null && base.Negotiator.OriginVillage.FactionId == faction.BlueprintId)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GameEventSystem\\Core\\Events\\Visitor\\ShowTradeDealLocationEvent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Became enemies with ");
					messageBuilder.AppendFormatted(faction.BlueprintId);
					messageBuilder.AppendLiteral(", ending event!");
				}
				GameEventInstance.Logger.Info(in messageBuilder);
				ForceEnd();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("guards", guards);
		}

		public ShowTradeDealLocationEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			guards = deserializer.ReadObjectList<HumanoidInstance>("guards");
		}
	}
}
