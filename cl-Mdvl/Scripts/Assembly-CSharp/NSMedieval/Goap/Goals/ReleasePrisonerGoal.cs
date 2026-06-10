using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class ReleasePrisonerGoal : Goal
	{
		private readonly List<HumanoidInstance> captives;

		private CaptiveNpcBehaviour captiveToEscort;

		private GameObject ropeEffect;

		public ReleasePrisonerGoal(Agent selfAgent)
			: base("ReleasePrisonerGoal", selfAgent)
		{
			captives = new List<HumanoidInstance>();
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestCaptive));
			AddInitStep(new ThreadSequenceStep(null, FindClosestExitPoint));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			DestroyRope();
			base.EndGoalWith(condition);
		}

		public override void Dispose()
		{
			base.Dispose();
			captives.Clear();
			captiveToEscort = null;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (captives == null)
			{
				return false;
			}
			captives.Clear();
			captives.AddRange(MonoSingleton<NPCManager>.Instance.IterateNPCs((HumanoidInstance npc) => npc.IsCaptive() && npc.ActiveBehaviour is CaptiveNpcBehaviour { MarkedForReleasing: not false, Owner: null } && npc.RopedTo() == null && !npc.HasFainted));
			if (captives.Count == 0)
			{
				return false;
			}
			return true;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => !captiveToEscort.MarkedForReleasing);
			HumanoidInstance ropeOwner = base.AgentOwner as HumanoidInstance;
			GoapAction goapAction = new GoapAction("ForcePrisonerToFollow");
			goapAction.OnInit = delegate
			{
				ropeOwner?.FaceObject(captiveToEscort.Humanoid.GetTransform());
				MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(captiveToEscort.Humanoid, ropeOwner);
				MonoSingleton<ReservationManager>.Instance.TryToExclusiveReservation(ropeOwner, captiveToEscort.Humanoid, 1f);
				captiveToEscort.Humanoid.RopeTo(ropeOwner);
				ropeEffect = CommonGoalMethods.CreateRopeEffect(ropeOwner, captiveToEscort.Humanoid);
				captiveToEscort.GoapAgent.Abort();
				captiveToEscort.GoapAgent.ForceNextGoal("RopedFollowGoal");
			};
			yield return goapAction;
			yield return GeneralActions.Wait(3f).TriggerAnimation("Roping", ActionAnimationMode.Ignore);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition);
			GoapAction goapAction2 = new GoapAction("Release prisoner");
			goapAction2.CompleteMode = ActionCompleteMode.Never;
			goapAction2.OnInit = delegate
			{
				(base.AgentOwner as HumanoidInstance)?.FaceObject(captiveToEscort.Humanoid.GetTransform());
			};
			goapAction2.CompleteAtCondition(delegate
			{
				if (captiveToEscort?.Humanoid == null || captiveToEscort.Humanoid.HasDisposed || CombatUtils.IsNullOrDisposed(base.AgentOwner))
				{
					EndGoalWith(GoalCondition.Incompletable);
					return true;
				}
				if (((HumanoidInstance)base.AgentOwner).GetNode().IsEdge())
				{
					((HumanoidInstance)base.AgentOwner)?.FaceObject(captiveToEscort.Humanoid.GetTransform());
					captiveToEscort.GoapAgent.Abort();
					return true;
				}
				return false;
			});
			yield return goapAction2;
			yield return GeneralActions.Wait(3f).TriggerAnimation("Roping", ActionAnimationMode.Ignore);
			yield return new GoapAction("LeftMap")
			{
				OnInit = delegate
				{
					if (captiveToEscort != null)
					{
						float friendlinessBonusForRelease = MonoSingleton<CaptiveNpcManager>.Instance.GetFriendlinessBonusForRelease(captiveToEscort);
						if (friendlinessBonusForRelease > Mathf.Epsilon)
						{
							captiveToEscort.Humanoid.Faction?.AddFriendliness(friendlinessBonusForRelease);
						}
						MonoSingleton<CaptiveNpcManager>.Instance.FireEffectorForAllPrisoners("PrisonerSetFree");
						MonoSingleton<NPCController>.Instance.PrisonerReleased(captiveToEscort);
						if (captiveToEscort.Shackled)
						{
							captiveToEscort.Humanoid.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.LeftHand, forbidDroppedItem: true);
						}
						DestroyRope();
						captiveToEscort.Humanoid.DestroyStorage();
						captiveToEscort.Humanoid.DestroyEquipment();
						MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
						{
							if (captiveToEscort.Humanoid != null)
							{
								bool isEnabled;
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ReleasePrisonerGoal.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Prisoner was released ");
									messageBuilder.AppendFormatted(base.AgentOwner);
								}
								Log.Info(messageBuilder);
								MonoSingleton<NPCController>.Instance.RemoveNPC(captiveToEscort.Humanoid);
								string text = MonoSingleton<LocalizationController>.Instance.GetText("bbt_prisoner_released", captiveToEscort.Humanoid);
								MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(text);
							}
						});
					}
				}
			};
			yield return GeneralActions.Wait(3f).TriggerAnimation("IdleHappy", ActionAnimationMode.Ignore);
		}

		private bool FindClosestCaptive()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				HumanoidInstance objectAs = target.GetObjectAs<HumanoidInstance>();
				if (objectAs != null && !objectAs.HasDisposed && objectAs.IsCaptive())
				{
					QueueTarget(TargetIndex.A, target);
					if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
					{
						captiveToEscort = objectAs.CaptiveNpcBehaviour;
						return true;
					}
					Log.Warning("Haven't been able to reserve and select Preferred Target for RopeEnemyGoal, clearing targets and cancelling goal", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ReleasePrisonerGoal.cs");
					return false;
				}
			}
			List<TargetObject> targets = PathfinderTargetable.FindObjects((IPathfindingAgent)base.AgentOwner, captives, -1, CommonGoalMethods.CheckCanRopePrisoner);
			QueueTargets(TargetIndex.A, targets);
			if (!ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
			{
				return false;
			}
			CaptiveNpcBehaviour captiveNpcBehaviour = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().CaptiveNpcBehaviour;
			if (captiveNpcBehaviour == null)
			{
				return false;
			}
			captiveToEscort = captiveNpcBehaviour;
			return true;
		}

		private bool FindClosestExitPoint()
		{
			if (!MonoSingleton<NPCStartPositionManager>.IsInstantiated())
			{
				return false;
			}
			MapNode closestReachableEdgeNode = NPCStartPositionManager.GetClosestReachableEdgeNode((IPathfindingAgent)base.AgentOwner);
			if (closestReachableEdgeNode == null)
			{
				return false;
			}
			SetTarget(TargetIndex.B, new TargetObject(closestReachableEdgeNode.Position));
			return true;
		}

		private void DestroyRope()
		{
			if (ropeEffect != null)
			{
				Object.Destroy(ropeEffect);
				ropeEffect = null;
			}
			captiveToEscort?.Humanoid.RopeTo(null);
		}
	}
}
