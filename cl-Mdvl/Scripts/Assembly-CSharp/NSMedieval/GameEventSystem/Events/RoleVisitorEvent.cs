using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.GameEventSystem.Events
{
	[FVSerializableKey("GameEvents.RoleVisitorEvent", "")]
	public abstract class RoleVisitorEvent : GameEventInstance, IVisitorDataHolder, IVisitorEvent
	{
		public static Action EventStart;

		protected HumanoidInstance visitor;

		protected VillagePlace OriginVillage;

		private const string fvs_npcVisitor = "npcVisitor";

		public HumanoidInstance Visitor => visitor;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			EventStart = null;
		}

		protected abstract string GetVisitorBlueprintId();

		protected RoleVisitorEvent()
		{
		}

		public override void Dispose()
		{
			base.Dispose();
			EventStart = null;
			visitor = null;
			OriginVillage = null;
		}

		public bool Contains(HumanoidInstance npcInstance)
		{
			return Visitor == npcInstance;
		}

		protected abstract HumanoidInstance GetNpcInstance();

		protected override GameEventPhaseBase GetStartingPhase()
		{
			EventStart?.Invoke();
			SpawnVisitor();
			return PhaseBuilder.LinkPhases(new AddHistoricalEntryPhase(), new RoleVisitorVisitPhase());
		}

		public override bool CanStart()
		{
			if (!base.CanStart())
			{
				return false;
			}
			if (!GetOriginVillage(GetVisitorBlueprintId(), out var villagePlace))
			{
				return false;
			}
			OriginVillage = villagePlace;
			return true;
		}

		public override string GetEventInfo(GameEvent.DialogContent dialogContent)
		{
			return HumanoidRoleUtils.ParseRoleText(MonoSingleton<LocalizationController>.Instance.GetText(dialogContent.DescriptionTextKey, Visitor.Info).Replace("<faction_name>", Visitor.Faction?.NameLocalized ?? string.Empty), Visitor, Visitor.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.Blueprint);
		}

		public override string GetEventName(GameEvent.DialogContent dialogContent, BodyType bodyType)
		{
			return HumanoidRoleUtils.ParseRoleText(base.GetEventName(dialogContent, bodyType), Visitor, Visitor.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.Blueprint);
		}

		protected bool GetOriginVillage(string blueprintId, out VillagePlace villagePlace)
		{
			return Repository<NPCRepository, NPC>.Instance.GetByID(blueprintId).TryGetRandomValidOriginVillage(out villagePlace, base.Blueprint.Friendliness);
		}

		private void SpawnVisitor()
		{
			visitor = GetNpcInstance();
			List<CreatureBase> agents = new List<CreatureBase> { Visitor };
			NPCStartPositionManager.SetStartPositionsForAgents(Visitor.WalkableModel, agents);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				Visitor.GetGoapAgent()?.StartTicker();
			});
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("npcVisitor", visitor);
		}

		public RoleVisitorEvent(FVDeserializer deserializer)
			: base(deserializer)
		{
			visitor = deserializer.ReadObject<HumanoidInstance>("npcVisitor");
		}
	}
}
