using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class PatientGoal : LayDownBaseGoal
	{
		private readonly Dictionary<BedComponentInstance, int> bedsWithScore = new Dictionary<BedComponentInstance, int>();

		private bool isHealAtPlaceByDoctor;

		private HumanoidInstance reservedDoctor;

		public PatientGoal(Agent selfAgent)
			: base("PatientGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>(preferLastTarget: false));
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is CreatureBase creatureBase)
			{
				return creatureBase is ISleepAgent;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.HasUntendendWounds() && !CombatUtils.CheckIsInCombat(creatureBase))
			{
				return !creatureBase.IsOnFire;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.PreferredReservableHandler?.SetPreferLastReserved(value: true);
			base.PreferredReservableHandler?.ClearTarget();
			if (base.AgentOwner is HumanoidInstance { HasDisposed: false, HasDied: false } humanoidInstance)
			{
				if (isHealAtPlaceByDoctor)
				{
					humanoidInstance.CanReceiveWoundTreatment = false;
				}
				string restEffector = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.RestEffector;
				humanoidInstance.Stats.EndEffector(restEffector);
				base.EndGoalWith(condition);
			}
			else
			{
				base.EndGoalWith(condition);
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = MoveToBed(TargetIndex.A);
			if (goapAction != null && !isHealAtPlaceByDoctor)
			{
				yield return goapAction;
			}
			GoapAction goapAction2 = LayDownAction("Laydown", recoverSleepStat: true, TargetIndex.A);
			goapAction2.CompleteAtCondition(EndGoalCheck);
			goapAction2.TickOnInterval(1f, IntervalTick);
			goapAction2.OnInit = delegate
			{
				if (base.AgentOwner is CreatureBase creatureBase)
				{
					creatureBase.CanReceiveWoundTreatment = true;
				}
				if (base.AgentOwner is HumanoidInstance humanoidInstance)
				{
					string restEffector = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.RestEffector;
					if (!humanoidInstance.Stats.IsEffectorActive(restEffector))
					{
						humanoidInstance.Stats.StartEffector(restEffector);
					}
				}
			};
			goapAction2.OnComplete = delegate
			{
				if (base.AgentOwner is CreatureBase creatureBase)
				{
					creatureBase.CanReceiveWoundTreatment = false;
				}
			};
			goapAction2.FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A);
			GoapAction waitForTend = new GoapAction("WaitForTend");
			waitForTend.CompleteAtCondition(EndGoalCheck);
			waitForTend.FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			waitForTend.OnInit = delegate
			{
				if (base.AgentOwner is CreatureBase creatureBase)
				{
					creatureBase.CanReceiveWoundTreatment = true;
				}
			};
			float startTime = Time.time;
			waitForTend.OnTick = delegate
			{
				if (!(Time.time - startTime < 0.5f) && reservedDoctor?.GetGoapAgent()?.CurrentGoalName != "TendWoundsGoal")
				{
					waitForTend.Complete(ActionCompletionStatus.Fail);
				}
			};
			waitForTend.OnComplete = delegate
			{
				if (base.AgentOwner is CreatureBase creatureBase)
				{
					creatureBase.CanReceiveWoundTreatment = false;
					isHealAtPlaceByDoctor = false;
					reservedDoctor = null;
				}
			};
			if (isHealAtPlaceByDoctor)
			{
				yield return waitForTend;
			}
			else
			{
				yield return goapAction2;
			}
		}

		private void IntervalTick(GoapAction action)
		{
			if (!((HumanoidInstance)base.AgentOwner).GetGoapAgent().GoalScheduler.IsEnabled("PatientGoal"))
			{
				EndGoalWith(GoalCondition.Incompletable);
			}
		}

		private bool EndGoalCheck()
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.HasUntendendWounds())
			{
				return creatureBase.IsOnFire;
			}
			return true;
		}

		private bool PrepareData()
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			BedComponentInstance bedComponentInstance = null;
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				HumanoidInstance objectAs = target.GetObjectAs<HumanoidInstance>();
				if (objectAs != null)
				{
					isHealAtPlaceByDoctor = true;
					reservedDoctor = objectAs;
					SetTarget(TargetIndex.B, new TargetObject(objectAs));
					MonoSingleton<ReservationManager>.Instance.ClearPreferedReservable(humanoidInstance);
					return true;
				}
				if (HasValidPreferedTarget())
				{
					bedComponentInstance = target.GetObjectAs<BedComponentInstance>();
					if ((bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo == null || !bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo.Occupied || bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance)) && bedComponentInstance.Blueprint.BedType == BedType.Medical && (bedComponentInstance.Underwater || !MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), humanoidInstance)))
					{
						bedComponentInstance = null;
					}
					base.PreferredReservableHandler.ClearTarget();
				}
			}
			if (bedComponentInstance == null)
			{
				bedComponentInstance = FindAndReserveBed(base.AgentOwner);
			}
			SetTarget(TargetIndex.A, new TargetObject(bedComponentInstance));
			return bedComponentInstance != null;
		}
	}
}
