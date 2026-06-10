using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FormCaravanGoal : Goal
	{
		private const string WaitingActionName = "CaravanWaiting";

		private const float WorkerMeetNearDistance = 5f;

		private const float RandomAroundMeetingPoint = 3f;

		private float movementSpeedMultiplier = 1f;

		private readonly CreatureBase creatureBase;

		public FormCaravanGoal(Agent selfAgent)
			: base("FormCaravanGoal", selfAgent)
		{
			creatureBase = base.AgentOwner as CreatureBase;
			AddInitStep(new ThreadSequenceStep(FindSpeedMultiplier, FindTargets));
		}

		public override bool CanStart(bool isForced = false)
		{
			return ((IFormCaravanAgent)base.AgentOwner)?.IsFormingCaravan() ?? false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			if (!AreAllWorkersNearMeetPoint())
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					base.Agent.ForceNextGoal("IdleGoal");
				});
			}
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IFormCaravanAgent;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailAtCondition(AnyWorkerHasFainted);
			yield return GeneralActions.WaitForever("CaravanWaiting").TriggerAnimation("Bored", ActionAnimationMode.Interrupt).CompleteAtCondition(AreAllWorkersNearMeetPoint)
				.FailAtCondition(AnyWorkerHasFainted);
			GoapAction leaveMapAction = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.Touch).FailAtCondition(AnyWorkerHasFainted);
			leaveMapAction.WithMovementSpeedMultiplier(movementSpeedMultiplier);
			leaveMapAction.OnInit = delegate
			{
				CaravanInstance caravan = GetCaravan();
				if (AnyWorkerHasFainted())
				{
					leaveMapAction.Complete(ActionCompletionStatus.Fail);
					return;
				}
				foreach (HumanoidInstance worker in caravan.Workers)
				{
					if (worker.GetGoapAgent() != null && !base.Id.Equals(worker.GetGoapAgent().CurrentGoalName))
					{
						worker.GetGoapAgent().Abort();
						worker.GetGoapAgent().ForceNextGoal(base.Id);
					}
				}
			};
			yield return leaveMapAction;
			GoapAction removeWorkerAction = new GoapAction("RemoveWorkerFromMap");
			removeWorkerAction.OnInit = delegate
			{
				IFormCaravanAgent formCaravanAgent = base.AgentOwner as IFormCaravanAgent;
				Vector3 worldPosition = GridUtils.GetWorldPosition(GetTarget(TargetIndex.B).ReachablePosition);
				if (Vector3.Distance(creatureBase.GetPosition(), worldPosition) >= 3f)
				{
					removeWorkerAction.Complete(ActionCompletionStatus.Fail);
				}
				else if (AnyWorkerHasFainted())
				{
					removeWorkerAction.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					CaravanInstance formingCaravanInstance = formCaravanAgent.GetFormingCaravanInstance();
					formCaravanAgent.IncognitoDispose();
					foreach (CreatureBase creature in formingCaravanInstance.Creatures)
					{
						if (creature is AnimalInstance animalInstance && animalInstance.RopedTo() == formCaravanAgent)
						{
							animalInstance.IncognitoDispose();
							animalInstance.ClearCaravanFormingData();
							animalInstance.GetGoapAgent().Abort();
						}
					}
					bool flag = true;
					foreach (HumanoidInstance worker2 in formingCaravanInstance.Workers)
					{
						if (!worker2.IsInIncognitoMode())
						{
							flag = false;
						}
						else
						{
							worker2.IncognitoDispose();
							worker2.ClearCaravanFormingData();
						}
					}
					if (flag)
					{
						foreach (CreatureBase creature2 in formingCaravanInstance.Creatures)
						{
							if (creature2 is AnimalInstance animalInstance2)
							{
								if (!animalInstance2.IsInIncognitoMode())
								{
									animalInstance2.IncognitoDispose();
									animalInstance2.ClearCaravanFormingData();
									animalInstance2.GetGoapAgent().Abort();
								}
							}
							else if (creature2 is HumanoidInstance humanoidInstance && !humanoidInstance.IsInIncognitoMode())
							{
								humanoidInstance.IncognitoDispose();
								humanoidInstance.ClearCaravanFormingData();
								humanoidInstance.GetGoapAgent().Abort();
							}
						}
						MonoSingleton<CaravanManager>.Instance.StartCaravan(formingCaravanInstance);
					}
				}
			};
			yield return removeWorkerAction;
		}

		private bool FindSpeedMultiplier()
		{
			if (base.AgentOwner?.GetGoapAgent() == null)
			{
				return false;
			}
			if (GetCaravan()?.Workers == null)
			{
				return false;
			}
			movementSpeedMultiplier = 1f;
			return true;
		}

		private bool FindTargets()
		{
			CaravanInstance caravan = GetCaravan();
			if (caravan == null)
			{
				return false;
			}
			creatureBase.GetHashCode();
			SetTarget(TargetIndex.A, new TargetObject(caravan.GetMeetingPosition(creatureBase)));
			SetTarget(TargetIndex.B, new TargetObject(caravan.GetExitPosition(creatureBase)));
			return true;
		}

		private bool AnyWorkerHasFainted()
		{
			CaravanInstance caravan = GetCaravan();
			if (caravan == null)
			{
				return true;
			}
			if (caravan.Workers.Any((HumanoidInstance worker) => worker == null || worker.HasFainted || worker.WorkerBehaviour.IsCrazy || worker.HasDied || worker.HasDisposed))
			{
				return true;
			}
			if (caravan.Creatures.Any((CreatureBase creature) => creature.HasFainted || creature.HasDied || creature.HasDisposed))
			{
				return true;
			}
			return false;
		}

		private bool AreAllWorkersNearMeetPoint()
		{
			CaravanInstance caravan = GetCaravan();
			if (caravan == null)
			{
				return false;
			}
			foreach (HumanoidInstance worker in caravan.Workers)
			{
				if (!worker.IsInIncognitoMode())
				{
					if (Vector3.Distance(worker.GetPosition(), GridUtils.GetWorldPosition(caravan.GetMeetingPosition(worker))) > 5f)
					{
						return false;
					}
					if (worker.GetGoapAgent() != null && worker.GetGoapAgent().GetCurrentGoal() != null && worker.GetGoapAgent().GetCurrentGoal().CurrentAction != null && !"CaravanWaiting".Equals(worker.GetGoapAgent().GetCurrentGoal().CurrentAction.Id))
					{
						return false;
					}
				}
			}
			foreach (CreatureBase creature in caravan.Creatures)
			{
				if (!creature.IsInIncognitoMode() && Vector3.Distance(creature.GetPosition(), GridUtils.GetWorldPosition(caravan.GetMeetingPosition(creature))) > 5f && creature is AnimalInstance animalInstance && animalInstance.RopedTo() != null && Vector3.Distance(animalInstance.GetPosition(), animalInstance.RopedTo().GetPosition()) > 5f && PathfinderUtil.IsPathPossible(animalInstance, animalInstance.RopedTo()))
				{
					return false;
				}
			}
			return true;
		}

		private CaravanInstance GetCaravan()
		{
			return (base.AgentOwner as IFormCaravanAgent)?.GetFormingCaravanInstance();
		}
	}
}
