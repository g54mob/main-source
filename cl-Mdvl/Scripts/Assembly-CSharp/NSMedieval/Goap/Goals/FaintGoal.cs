using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village;

namespace NSMedieval.Goap.Goals
{
	public class FaintGoal : LayDownBaseGoal
	{
		public FaintGoal(Agent selfAgent)
			: base("FaintGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(HandleInitialReservations, FindBeds, ReserveFurniture));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}

		public override bool CanStart(bool isForced = false)
		{
			return ((CreatureBase)base.AgentOwner).HasFainted;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			StatsInstance statsInstance = ((CreatureBase)base.AgentOwner)?.Stats;
			if (MonoSingleton<LifeController>.IsInstantiated() && statsInstance != null)
			{
				MonoSingleton<LifeController>.Instance.WakeUp(statsInstance);
				MonoSingleton<LifeController>.Instance.WakeUpAfterFaint(statsInstance);
			}
			if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				string faintEffector = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.FaintEffector;
				humanoidInstance.Stats.EndEffector(faintEffector);
				MonoSingleton<ReservationManager>.Instance.ReleaseAll((IGoapAgentOwner)humanoidInstance);
				if (MonoSingleton<ReservationManager>.Instance.GetReservedBed(base.AgentOwner) != null)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseAll((IGoapAgentOwner)humanoidInstance);
				}
			}
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			CreatureBase owner = (CreatureBase)base.AgentOwner;
			GoapAction goapAction = LayDownAction("Laydown", recoverSleepStat: true, TargetIndex.A);
			goapAction.CompleteAtCondition(delegate
			{
				if (!owner.HasFainted && !owner.IsBeingCarried && !owner.IsReceivingWoundTreatman)
				{
					return true;
				}
				if (owner is HumanoidInstance { IsUnfaintPlanned: not false })
				{
					if (GlobalSaveController.CurrentVillageData.Raids.Any((ActiveRaidInfo raidInfo) => !raidInfo.HasEnded))
					{
						string restEffector = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.RestEffector;
						if (!owner.Stats.IsEffectorActive(restEffector))
						{
							return false;
						}
					}
					owner.UnFaint();
				}
				return false;
			});
			goapAction.OnInit = delegate
			{
				owner.CanReceiveWoundTreatment = true;
				if (owner is HumanoidInstance humanoidInstance)
				{
					string faintEffector = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker.DefaultHumanType.FaintEffector;
					if (!humanoidInstance.Stats.IsEffectorActive(faintEffector))
					{
						humanoidInstance.Stats.StartEffector(faintEffector);
					}
				}
			};
			goapAction.OnComplete = delegate
			{
				owner.CanReceiveWoundTreatment = false;
			};
			yield return goapAction;
		}

		private bool HandleInitialReservations()
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (HasValidPreferedTarget() && Vec3Int.Distance(base.PreferredReservableHandler.GetTarget().ReachablePosition, creatureBase.GetPosition()) <= LayDownBaseGoal.BedNearDistance)
			{
				MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
				QueueTarget(TargetIndex.A, base.PreferredReservableHandler.GetTarget());
				ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
				return true;
			}
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
			return true;
		}

		private bool FindBeds()
		{
			if (GetTarget(TargetIndex.A).IsInitialized)
			{
				return true;
			}
			ISleepAgent sleepAgent = (ISleepAgent)base.AgentOwner;
			List<WorldObject> targets = Map.BedComponentManager.IterateComponentWorldObjects((BedComponentInstance x) => !x.Underwater && (x.Blueprint.BedType == BedType.Basic || x.Blueprint.BedType == BedType.Medical)).ToList();
			List<TargetObject> list = PathfinderMedieval.FindMedievalObjects<BaseBuildingInstance>(sleepAgent, targets);
			if (list == null || list.Count <= 0)
			{
				return true;
			}
			Vec3Int agentGridPosition = sleepAgent.GetGridPosition();
			List<TargetObject> list2 = list.Where((TargetObject item) => Vec3Int.Distance(item.ReachablePosition, in agentGridPosition) <= LayDownBaseGoal.BedNearDistance).ToList();
			if (list2.Count == 0)
			{
				return true;
			}
			List<TargetObject> list3 = new List<TargetObject>();
			TargetObject[] array = list2.ToArray();
			for (int num = 0; num < array.Length; num++)
			{
				TargetObject targetObject = array[num];
				WorldObject objectAs = targetObject.GetObjectAs<WorldObject>();
				if (objectAs != null && !objectAs.HasDisposed)
				{
					BedComponentInstance componentInstance = Map.BedComponentManager.GetComponentInstance(objectAs);
					if (componentInstance != null && !componentInstance.HasDisposed)
					{
						list3.Add(new TargetObject(componentInstance, targetObject.ReachablePosition));
					}
				}
			}
			QueueTargets(TargetIndex.A, list3);
			return true;
		}

		private bool ReserveFurniture()
		{
			if (GetTarget(TargetIndex.A).IsInitialized)
			{
				return true;
			}
			ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
			return true;
		}
	}
}
