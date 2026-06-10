using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Animation;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public abstract class EventBaseGoal : Goal
	{
		protected readonly IEventParticipant Participant;

		protected string AnimationTrigger;

		protected bool TargetChairReserved;

		private string[] onEndEffectors;

		protected HumanoidInstance HumanoidInstance => base.AgentOwner as HumanoidInstance;

		public EventBaseGoal(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.None)
			: base(id, selfAgent, interruptMode)
		{
			AddInitStep(new ThreadSequenceStep(CacheEffectors, FindTargets));
			Participant = base.AgentOwner as IEventParticipant;
		}

		public override void Start()
		{
			base.Start();
			ChairComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>();
			if (objectAs != null && !objectAs.HasDisposed)
			{
				MonoSingleton<ReservationManager>.Instance.ReleaseAll(objectAs);
				TargetChairReserved = MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner);
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(HumanoidInstance.GetFullName());
					messageBuilder.AppendLiteral(" has reserved chair object : ");
					messageBuilder.AppendFormatted(TargetChairReserved);
				}
				Log.Trace(messageBuilder);
			}
		}

		private bool CacheEffectors()
		{
			if (GetEventInstance() == null)
			{
				return false;
			}
			onEndEffectors = GetEventInstance().GetParticipantEffectorParsed(Participant);
			Log.Debug($"{HumanoidInstance} On End Effectors " + string.Join(",", onEndEffectors), "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
			return true;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (GetEventInstance() == null)
			{
				return false;
			}
			if (GetEventInstance().Ended())
			{
				return false;
			}
			return true;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IEventParticipant;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (!(base.AgentOwner is CreatureBase { HasDisposed: false } creatureBase))
			{
				return;
			}
			PlayerTriggeredEventInstance eventInstance = GetEventInstance();
			if (eventInstance == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(86, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("EventBaseGoal ");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(": Event ended for ");
					messageBuilder.AppendFormatted(creatureBase.GetFullName());
					messageBuilder.AppendLiteral(". Event instance is null. Can't end goal with success.");
				}
				Log.Error(messageBuilder);
				return;
			}
			eventInstance.RemoveParticipantFromEvent(Participant);
			if (condition == GoalCondition.Succeeded)
			{
				FireEventEffectors(creatureBase);
				Room room = creatureBase.Room;
				List<string> list = room?.RoomType?.GetEatEffectors(room.Impressiveness);
				if (list != null && list.Count > 0)
				{
					creatureBase.Stats.StartEffectors(list);
				}
			}
		}

		protected virtual void FireEventEffectors(CreatureBase creature)
		{
			string[] array = onEndEffectors;
			foreach (string text in array)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(text);
					if ((object)byID != null && byID.IsReligious)
					{
						humanoidInstance.HumanoidBelief.FireBeliefEffector(text);
						continue;
					}
				}
				creature.Stats.StartEffector(text);
			}
		}

		protected abstract bool FindTargets();

		protected GoapAction GoToGatherPosition()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.Touch).FailAtCondition(EventEnded).FailAtCondition(EventFailed);
			IEventParticipant participant = Participant;
			HumanoidInstance npc = participant as HumanoidInstance;
			if (npc != null && npc.IsNpc())
			{
				goapAction.FailAtCondition(() => NpcPartyLeaving(npc));
			}
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status != ActionCompletionStatus.Success)
				{
					GetEventInstance().RemoveParticipantFromEvent(Participant);
					EndGoalWith(GoalCondition.Incompletable);
				}
				else
				{
					CheckIn();
				}
			};
			return goapAction;
		}

		protected GoapAction WaitForOthers()
		{
			GoapAction goapAction = GeneralActions.WaitForever("WaitingForOthers").TriggerAnimation("Bored", ActionAnimationMode.Interrupt).CompleteAtCondition(GetEventInstance().Started)
				.FailAtCondition(EventEnded)
				.FailAtCondition(EventFailed);
			IEventParticipant participant = Participant;
			HumanoidInstance npc = participant as HumanoidInstance;
			if (npc != null && npc.IsNpc())
			{
				goapAction.FailAtCondition(() => NpcPartyLeaving(npc));
			}
			return goapAction;
		}

		protected GoapAction FindEventPosition()
		{
			if (!GetTarget(TargetIndex.B).IsInitialized)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("EventBaseGoal ");
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(": Target B is not initialized.");
				}
				Log.Error(messageBuilder);
				return null;
			}
			if (!TargetChairReserved)
			{
				return GoToEventPosition();
			}
			return GoToEventChair();
		}

		protected GoapAction GoToEventChair()
		{
			return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B).SkipIfTargetReservationReleases(TargetIndex.B)
				.FailAtCondition(EventEnded)
				.FailAtCondition(EventFailed);
		}

		protected virtual GoapAction SitAction()
		{
			GoapAction sitAction = GeneralActions.Instant().TriggerAnimation("ChairSit", ActionAnimationMode.WaitForCompletion).SkipIfTargetDisposedForbidenOrNull(TargetIndex.B)
				.SkipIfTargetReservationReleases(TargetIndex.B);
			sitAction.OnPreInit = delegate
			{
				if (!sitAction.HasCompleted)
				{
					ChairComponentInstance objectAs = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>();
					if (objectAs != null && base.AgentOwner is IPathfindingAgent pathfindingAgent)
					{
						pathfindingAgent.PathDriver.Teleport(objectAs.GridDataPosition);
						Vector3 objectPosition = base.Agent.GetView().transform.position + Quaternion.Euler(0f, objectAs.Angle, 0f) * Vector3.right;
						base.Agent.GetView().FaceObject(objectPosition);
						OverrideBoneAnimation component = base.AgentOwner.GetTransform().GetComponent<OverrideBoneAnimation>();
						ChairComponent component2 = objectAs.Map.ChairComponentManager.GetComponent(objectAs);
						component.OverridePosition = component2.ChairSitPosition;
						component.StartOverrideAnimation();
					}
				}
			};
			sitAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success && base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
				{
					OverrideBoneAnimation overrideBoneAnimation = base.AgentOwner?.GetTransform()?.GetComponent<OverrideBoneAnimation>();
					if (overrideBoneAnimation != null)
					{
						overrideBoneAnimation.EndOverrideAnimation();
					}
					ChairComponentBlueprint chairComponentBlueprint = GetTarget(TargetIndex.B).GetObjectAs<ChairComponentInstance>()?.Blueprint;
					if (!(chairComponentBlueprint == null))
					{
						foreach (string workerEffector in chairComponentBlueprint.WorkerEffectors)
						{
							if (!string.IsNullOrEmpty(workerEffector))
							{
								humanoidInstance.Stats.StartEffector(workerEffector);
							}
						}
					}
				}
			};
			sitAction.SetMinimumDurationTime(1f);
			return sitAction;
		}

		protected GoapAction GoToEventPosition(Vector3 lookAtPointOverride = default(Vector3))
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition, lookAtPointOverride).FailAtCondition(EventEnded).FailAtCondition(EventFailed);
			IEventParticipant participant = Participant;
			HumanoidInstance npc = participant as HumanoidInstance;
			if (npc != null && npc.IsNpc())
			{
				goapAction.FailAtCondition(() => NpcPartyLeaving(npc));
			}
			goapAction.OnComplete = delegate
			{
				if (base.AgentOwner is CreatureBase creatureBase)
				{
					creatureBase.FaceObject(GetEventInstance().GetFurnitureCenterPosition().ToVector3World());
				}
			};
			return goapAction;
		}

		protected void SetGatheringPositionTarget()
		{
			SetTarget(TargetIndex.A, new TargetObject(GetEventInstance().GetMeetingPosition(Participant)));
		}

		protected void SetEventPositionTarget()
		{
			Vec3Int eventPosition = GetEventInstance().GetEventPosition(Participant);
			ChairComponentInstance componentInstance = VillageManager.ActiveVillage.Map.ChairComponentManager.GetComponentInstance(eventPosition);
			if (componentInstance != null && !componentInstance.HasDisposed)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(17, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(HumanoidInstance.GetFullName());
					messageBuilder.AppendLiteral(" reserving chair ");
					messageBuilder.AppendFormatted(componentInstance.UniqueID);
				}
				Log.Trace(messageBuilder);
				SetTarget(TargetIndex.B, new TargetObject(componentInstance));
			}
			else
			{
				SetTarget(TargetIndex.B, new TargetObject(eventPosition));
			}
		}

		protected abstract PlayerTriggeredEventInstance GetEventInstance();

		protected bool EventFailed()
		{
			bool isEnabled;
			if (!(base.AgentOwner is CreatureBase creatureBase))
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(" EventFailed: AgentOwner is not CreatureBase");
				}
				Log.Debug(messageBuilder);
				return true;
			}
			if (creatureBase.HasDied || creatureBase.HasDisposed)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(" EventFailed: AgentOwner has died or disposed");
				}
				Log.Debug(messageBuilder);
				return true;
			}
			if (!(base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance))
			{
				return false;
			}
			if (humanoidInstance.WorkerBehaviour.ForcedWorkHour != HourType.PlayerTriggeredEvent)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(70, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(" EventFailed: Worker ");
					messageBuilder.AppendFormatted(humanoidInstance);
					messageBuilder.AppendLiteral(" ForcedWorkHour is ");
					messageBuilder.AppendFormatted(humanoidInstance.WorkerBehaviour.ForcedWorkHour);
					messageBuilder.AppendLiteral(", and not PlayerTriggeredEvent");
				}
				Log.Debug(messageBuilder);
				return true;
			}
			return false;
		}

		protected bool EventEnded()
		{
			if (GetEventInstance() == null || GetEventInstance().Ended())
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(this);
					messageBuilder.AppendLiteral(" EventEnded: EventInstance is null or ended");
				}
				Log.Debug(messageBuilder);
				return true;
			}
			return false;
		}

		protected bool NpcPartyLeaving(HumanoidInstance npc)
		{
			if (!(npc.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget) is HumanoidInstance humanoidInstance))
			{
				return false;
			}
			if (humanoidInstance == npc)
			{
				return false;
			}
			if (humanoidInstance.HasDisposed || humanoidInstance.HasDied || humanoidInstance.HasFainted)
			{
				return true;
			}
			if (humanoidInstance.IsLeaving)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\EventBaseGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("NpcPartyLeaving: ");
					messageBuilder.AppendFormatted(humanoidInstance);
					messageBuilder.AppendLiteral(" IsLeaving");
				}
				Log.Debug(messageBuilder);
				return true;
			}
			return false;
		}

		protected void CheckIn()
		{
			GetEventInstance().CheckIn(((CreatureBase)base.AgentOwner).UniqueId);
		}
	}
}
