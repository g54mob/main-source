using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[FVSerializableKey("HangingEventInstance", "")]
	public class HangingEventInstance : PlayerTriggeredEventInstance
	{
		private const string RopePrisonerToHangingEventGoal = "RopePrisonerToHangingEventGoal";

		private const float PrisonerFactionFriendliness = -30f;

		private const float PrisonerFactionFriendlinessWithParticipants = -40f;

		private const float PrisonerEnemyFriendliness = 20f;

		private const float PrisonerFriendFriendliness = -20f;

		private FactionInstance prisonerFaction;

		public HangingEventInstance()
		{
		}

		public void NoPrisonerCancelEvent()
		{
			ChangeStateEnd();
		}

		public override void Initialize()
		{
			base.Initialize();
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (CanParticipate(key) && CanPathFind(key))
				{
					AddRemoveParticipant(key, add: true);
				}
			}
			HumanoidInstance humanoidInstance = MonoSingleton<NPCManager>.Instance.PickRandom((HumanoidInstance humanoidInstance2) => humanoidInstance2.ActiveBehaviour is PrisonerBehaviour { IsPlayerVillagePrisoner: not false } && CanParticipate(humanoidInstance2));
			if (humanoidInstance != null)
			{
				AddRemovePrisoner(humanoidInstance, add: true);
				prisonerFaction = humanoidInstance.Faction;
			}
		}

		protected override bool CanOverrideGatheringTimeout()
		{
			if (base.AttendeesByType[EventAttendeeType.PrisonerParticipant] == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\HangingEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.Blueprint.GetID());
					messageBuilder.AppendLiteral(" event instance:  Participants list is null");
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (base.AttendeesByType[EventAttendeeType.PrisonerParticipant].Count < 1)
			{
				return false;
			}
			if (!(base.AttendeesByType[EventAttendeeType.PrisonerParticipant].First() is CreatureBase creatureBase) || !CheckedInIds.Contains(creatureBase.UniqueId))
			{
				return false;
			}
			return base.CanOverrideGatheringTimeout();
		}

		public override bool CanStart()
		{
			if (base.AttendeesByType[EventAttendeeType.PrisonerParticipant] == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\PlayerTriggeredEventSystem\\HangingEventInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.Blueprint.GetID());
					messageBuilder.AppendLiteral(" event instance:  Participants list is null");
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (base.AttendeesByType[EventAttendeeType.PrisonerParticipant].Count < 1)
			{
				return false;
			}
			return base.CanStart();
		}

		public IEventParticipant GetRandomParticipant(EventAttendeeType attendeeType, Predicate<IEventParticipant> filter = null)
		{
			using PooledList<IEventParticipant> pooledList = ListPool<IEventParticipant>.GetJanitor(IterateAttendees(attendeeType, filter));
			if (pooledList.Count == 0)
			{
				return null;
			}
			int num = UnityEngine.Random.Range(0, pooledList.Count);
			int num2 = 0;
			foreach (IEventParticipant item in pooledList)
			{
				if (num2 == num)
				{
					return item;
				}
				num2++;
			}
			return null;
		}

		protected override void StartGathering()
		{
			IEventParticipant randomParticipant = GetRandomParticipant(EventAttendeeType.Participant, (IEventParticipant participant) => participant is HumanoidInstance humanoidInstance && humanoidInstance.WorkerBehaviour != null);
			if (randomParticipant != null)
			{
				base.ParticipantGoalIds[randomParticipant] = "RopePrisonerToHangingEventGoal";
				base.ReservedPositions.AddRange(base.HostBuilding.GetComponentInstance<GallowsComponentInstance>().WorkplacePositions);
				base.AnimationPositions.AddRange(base.HostBuilding.GetComponentInstance<GallowsComponentInstance>().AnimationPositions);
				base.StartGathering();
			}
		}

		protected override void FireEventSpecificEffectors()
		{
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (!(item.ActiveBehaviour is PrisonerBehaviour { Owner: null }))
				{
					continue;
				}
				string[] factionPrisonerEffectors;
				if (item.Faction == prisonerFaction)
				{
					factionPrisonerEffectors = GetFactionPrisonerEffectors();
					foreach (string text in factionPrisonerEffectors)
					{
						if (!string.IsNullOrEmpty(text))
						{
							item.Stats.StartEffector(text);
						}
					}
					continue;
				}
				factionPrisonerEffectors = GetNonFactionPrisonerEffectors();
				foreach (string text2 in factionPrisonerEffectors)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						item.Stats.StartEffector(text2);
					}
				}
			}
		}

		protected override void FireFactionFriendlinessEffectors()
		{
			if (NpcFriendlinessFired || prisonerFaction == null || prisonerFaction.IsPermanentlyHostile())
			{
				return;
			}
			FactionInstance factionInstance = ((base.AllParticipantsUnique.FirstOrDefault() is HumanoidInstance humanoidInstance) ? humanoidInstance.Faction : null);
			if (factionInstance == null || factionInstance != prisonerFaction)
			{
				prisonerFaction.AddFriendliness(-30f);
			}
			else
			{
				prisonerFaction.AddFriendliness(-40f);
			}
			foreach (FactionInstance enemyFactionInstance in prisonerFaction.GetEnemyFactionInstances())
			{
				if (!enemyFactionInstance.IsPermanentlyHostile())
				{
					enemyFactionInstance.AddFriendliness(20f);
				}
			}
			foreach (FactionInstance friendlyFactionInstance in prisonerFaction.GetFriendlyFactionInstances())
			{
				friendlyFactionInstance.AddFriendliness(-20f);
			}
			prisonerFaction = null;
			base.FireFactionFriendlinessEffectors();
		}

		public override IEnumerable<PlayerTriggeredEventInfo> IterateEventQualityInfo()
		{
			yield return GetParticipantInfo();
			yield return GetCooldownInfo();
		}

		public HangingEventInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
