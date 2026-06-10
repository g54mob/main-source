using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class RopeEnemyGoal : Goal
	{
		private readonly List<HumanoidInstance> prisoners;

		private PrisonerBehaviour prisonerToEscort;

		private GameObject ropeEffect;

		public RopeEnemyGoal(Agent selfAgent)
			: base("RopeEnemyGoal", selfAgent)
		{
			prisoners = new List<HumanoidInstance>();
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestPrisoner));
			AddInitStep(new ThreadSequenceStep(null, FindJailCell));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (ropeEffect != null)
			{
				Object.Destroy(ropeEffect);
				ropeEffect = null;
			}
			prisonerToEscort?.Humanoid?.RopeTo(null);
			if (base.AgentOwner != null && !base.AgentOwner.HasDisposed)
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				((HumanoidInstance)base.AgentOwner).GetAgentView<HumanoidView>().IsRunningDisabledGoap = false;
			}
			base.EndGoalWith(condition);
		}

		private bool FindClosestPrisoner()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				HumanoidInstance objectAs = target.GetObjectAs<HumanoidInstance>();
				if (objectAs != null && objectAs.IsCaptive() && CommonGoalMethods.CheckCanRopePrisoner(objectAs))
				{
					QueueTarget(TargetIndex.A, target);
					if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
					{
						prisonerToEscort = objectAs.PrisonerBehaviour;
						return true;
					}
					Log.Warning("Haven't been able to reserve and select Preferred Target for RopeEnemyGoal, clearing targets and cancelling goal", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopeEnemyGoal.cs");
					return false;
				}
			}
			List<TargetObject> targets = PathfinderTargetable.FindObjects((IPathfindingAgent)base.AgentOwner, prisoners, -1, CommonGoalMethods.CheckCanRopePrisoner);
			QueueTargets(TargetIndex.A, targets);
			if (!ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
			{
				return false;
			}
			PrisonerBehaviour prisonerBehaviour = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().PrisonerBehaviour;
			if (prisonerBehaviour == null)
			{
				return false;
			}
			prisonerToEscort = prisonerBehaviour;
			return true;
		}

		private bool FindJailCell()
		{
			if (!PrisonerUtil.FindJailCellPositionForEscort(base.AgentOwner as CreatureBase, out var position))
			{
				return false;
			}
			SetTarget(TargetIndex.B, new TargetObject(position));
			return true;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!(base.AgentOwner is CreatureBase creatureBase) || !creatureBase.Map.RoomDetection.RoomTypeExists("prison_cell"))
			{
				return false;
			}
			prisoners.Clear();
			prisoners.AddRange(MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.IsPrisoner() && npc.ActiveBehaviour is PrisonerBehaviour { IsInPrisonCell: false, Owner: null } && npc.RopedTo() == null && !npc.HasFainted));
			return prisoners.Count != 0;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => prisonerToEscort.IsInPrisonCell)
				.FailAtCondition(() => prisonerToEscort == null || prisonerToEscort.Humanoid.HasDiedOrFainted || prisonerToEscort.Humanoid.HasDisposed);
			HumanoidInstance ropeOwner = base.AgentOwner as HumanoidInstance;
			GoapAction goapAction = new GoapAction("ForcePrisonerToFollow");
			goapAction.OnInit = delegate
			{
				ropeOwner.FaceObject(prisonerToEscort.Humanoid.GetTransform());
				ropeOwner.GetAgentView<HumanoidView>().IsRunningDisabledGoap = true;
				MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(prisonerToEscort.Humanoid, ropeOwner);
				MonoSingleton<ReservationManager>.Instance.TryToExclusiveReservation(ropeOwner, prisonerToEscort.Humanoid, 1f);
				prisonerToEscort.Humanoid.RopeTo(ropeOwner, matchSpeed: true);
				prisonerToEscort.MarkAsSurrendered();
				ropeEffect = CommonGoalMethods.CreateRopeEffect(ropeOwner, prisonerToEscort.Humanoid);
				prisonerToEscort.GoapAgent.Abort();
				prisonerToEscort.GoapAgent.ForceNextGoal("RopedFollowGoal");
			};
			yield return goapAction;
			yield return GeneralActions.Wait(3f).TriggerAnimation("Roping", ActionAnimationMode.Ignore);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.4f).FailAtCondition(() => prisonerToEscort == null || prisonerToEscort.Humanoid.HasDiedOrFainted || prisonerToEscort.Humanoid.HasDisposed)
				.TickOnInterval(1f, delegate(GoapAction action)
				{
					if (!RoomIsPrison(GetTarget(TargetIndex.B).ReachablePosition))
					{
						action.Complete(ActionCompletionStatus.Fail);
					}
				});
			Room targetRoom = prisonerToEscort.Humanoid.Map.RoomDetection.GetRoom(GetTarget(TargetIndex.B).ReachablePosition);
			GoapAction goapAction2 = new GoapAction("Release prisoner");
			goapAction2.CompleteMode = ActionCompleteMode.Never;
			goapAction2.AddGoalEndingCondition(delegate
			{
				if (prisonerToEscort?.Humanoid == null || prisonerToEscort.Humanoid.HasDiedOrFainted || prisonerToEscort.Humanoid.HasDisposed || !RoomIsPrison(GetTarget(TargetIndex.B).ReachablePosition))
				{
					return GoalCondition.Incompletable;
				}
				if (prisonerToEscort.Humanoid.Room == targetRoom)
				{
					(base.AgentOwner as HumanoidInstance)?.FaceObject(prisonerToEscort.Humanoid.GetTransform());
					prisonerToEscort.GoapAgent.Abort();
					return GoalCondition.Succeeded;
				}
				return GoalCondition.OnGoing;
			});
			yield return goapAction2;
			yield return GeneralActions.Wait(3f).TriggerAnimation("Roping", ActionAnimationMode.Ignore);
		}

		private bool RoomIsPrison(in Vec3Int position)
		{
			return base.AgentOwner.Map.RoomDetection.GetRoom(position)?.RoomType?.Prison == true;
		}
	}
}
