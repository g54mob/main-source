using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;

namespace NSMedieval.Goap.Goals
{
	public class RestGoal : LayDownBaseGoal
	{
		private const float RestStopMultiplier = 0.95f;

		private const float RestStartThreshold = 0.5f;

		public RestGoal(Agent selfAgent)
			: base("RestGoal", selfAgent)
		{
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
			if (!(base.AgentOwner is CreatureBase creatureBase))
			{
				return false;
			}
			if (creatureBase.IsOnFire)
			{
				return false;
			}
			if (creatureBase.IsWounded && !EndGoalCheck())
			{
				return true;
			}
			if (creatureBase.Stats.GetStat(StatType.Health).Current <= creatureBase.Stats.GetStat(StatType.Health).Max * 0.5f)
			{
				return true;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (!(base.AgentOwner is HumanoidInstance humanoidInstance))
			{
				base.EndGoalWith(condition);
				return;
			}
			string restEffector = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.RestEffector;
			humanoidInstance.Stats.EndEffector(restEffector);
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = MoveToBed(TargetIndex.A);
			if (goapAction != null)
			{
				yield return goapAction;
			}
			GoapAction goapAction2 = LayDownAction("Laydown", recoverSleepStat: true, TargetIndex.A);
			goapAction2.CompleteAtCondition(EndGoalCheck);
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
			yield return goapAction2;
		}

		private bool EndGoalCheck()
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.IsOnFire)
			{
				return true;
			}
			if (creatureBase.HasUntendendWounds() || creatureBase.Stats.GetActiveEffectors().Any((ActiveEffectorInfo item) => item.WoundInfo?.NeedRest ?? false))
			{
				return false;
			}
			StatInstance stat = creatureBase.Stats.GetStat(StatType.Health);
			if (stat != null && stat.Current < stat.Max * 0.95f)
			{
				return false;
			}
			if (!creatureBase.HasUntendendWounds() && creatureBase.Stats.GetActiveEffectors().All((ActiveEffectorInfo item) => item.WoundInfo == null || !item.WoundInfo.NeedRest))
			{
				return true;
			}
			if (!creatureBase.IsWounded && !creatureBase.IsReceivingWoundTreatman)
			{
				return true;
			}
			StatInstance stat2 = creatureBase.Stats.GetStat(StatType.Blood);
			if (stat2 != null && stat2.Current < stat2.Max * 0.95f)
			{
				return false;
			}
			StatInstance stat3 = creatureBase.Stats.GetStat(StatType.Consciousness);
			if (stat3 != null && stat3.Current <= stat3.Max * 0.95f)
			{
				return false;
			}
			StatInstance stat4 = creatureBase.Stats.GetStat(StatType.Pain);
			if (stat4 != null && stat4.Current <= stat4.Max * 0.95f)
			{
				return false;
			}
			return true;
		}

		private bool PrepareData()
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			BedComponentInstance bedComponentInstance = null;
			if (HasValidPreferedTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				bedComponentInstance = target.GetObjectAs<BedComponentInstance>();
				BuildingOwnershipInfo buildingOwnershipInfo = bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo;
				if ((buildingOwnershipInfo == null || !buildingOwnershipInfo.Occupied || bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance)) && bedComponentInstance.Blueprint.BedType == BedType.Medical && !bedComponentInstance.Underwater && !bedComponentInstance.IsOnFire && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), humanoidInstance))
				{
					SetTarget(TargetIndex.A, new TargetObject(bedComponentInstance));
					return true;
				}
				base.PreferredReservableHandler.ClearTarget();
			}
			bedComponentInstance = FindAndReserveBed(base.AgentOwner);
			SetTarget(TargetIndex.A, new TargetObject(bedComponentInstance));
			return bedComponentInstance != null;
		}
	}
}
