using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class RepairBuildingGoal : Goal
	{
		private const float MinEnemyRange = 8f;

		private VillageMap map;

		public RepairBuildingGoal(Agent selfAgent)
			: base("RepairBuildingGoal", selfAgent)
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(new ThreadSequenceStep(null, PrepareData, ReserveTargets));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is IToolAgent toolAgent)
			{
				return toolAgent is IProductionAgent;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (map?.BuildingsManagerMain == null)
			{
				return false;
			}
			foreach (BaseBuildingInstance damagedBuilding in map.BuildingsManagerMain.GetDamagedBuildings())
			{
				if (!damagedBuilding.HasDisposed && !damagedBuilding.IsOnFire)
				{
					return true;
				}
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			((IToolAgent)base.AgentOwner).HideTool();
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailAtCondition(() => CheckIfShouldFailRepair(TargetIndex.A));
			GoapAction repairAction = null;
			repairAction = new GoapAction("RepairAction")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			repairAction.OnInit = delegate
			{
				((IToolAgent)base.AgentOwner).SetTool("hammer_item");
			};
			repairAction.TickOnInterval(1f, delegate
			{
				BaseBuildingInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
				if (objectAs == null || objectAs.HasDisposed)
				{
					repairAction.Complete(ActionCompletionStatus.Error);
				}
				else if (objectAs.IsOnFire)
				{
					repairAction.Complete(ActionCompletionStatus.Success);
				}
				else
				{
					StatInstance statInstance = objectAs.Stats?.GetStat(StatType.Health);
					if (statInstance == null)
					{
						Log.Error("Repairing building with no health stat? This should never happen...", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RepairBuildingGoal.cs");
						repairAction.Complete(ActionCompletionStatus.Error);
					}
					else if (statInstance.Current >= statInstance.Max - 0.5f)
					{
						repairAction.Complete(ActionCompletionStatus.Success);
					}
					else
					{
						float num = 8f;
						AttributeInstance attribute = ((IProductionAgent)base.AgentOwner).GetAttribute(AttributeType.GlobalWorkSpeed);
						if (attribute != null)
						{
							num /= attribute.Value;
						}
						objectAs.Repair(statInstance, num);
						if (statInstance.Current >= statInstance.Max - 0.5f)
						{
							repairAction.Complete(ActionCompletionStatus.Success);
						}
					}
				}
			});
			repairAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			repairAction.TriggerAnimation("Build", ActionAnimationMode.Interrupt);
			repairAction.FailAtCondition(() => CheckIfShouldFailRepair(TargetIndex.A));
			yield return repairAction;
		}

		private bool PrepareData()
		{
			List<TargetObject> list = PathfinderBuilding.FindDamaged((IToolAgent)base.AgentOwner, from building in map.BuildingsManagerMain.GetDamagedBuildings()
				where !building.IsOnFire && building.OwnedByPlayer()
				select building);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			using PooledList<HumanoidInstance> pooledList = MonoSingleton<NPCManager>.Instance.GetNPCsPooled();
			List<TargetObject> list2 = new List<TargetObject>();
			foreach (TargetObject item in list)
			{
				if (!(item.ObjectInstance is BaseBuildingInstance { IsOnFire: false, MarkedForDestruction: false, MarkedForMoving: false }))
				{
					continue;
				}
				bool flag = true;
				Vector3 worldPosition = GridUtils.GetWorldPosition(item.ReachablePosition);
				foreach (HumanoidInstance item2 in pooledList)
				{
					if (item2 != null && !item2.HasFainted && !item2.HasDisposed && !item2.HasDied && item2.IsEnemy() && Vector3.Distance(worldPosition, item2.GetPosition()) < 8f)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list2.Add(item);
				}
			}
			if (list2.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list2);
			return true;
		}

		private bool ReserveTargets()
		{
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}

		private bool CheckIfShouldFailRepair(TargetIndex index)
		{
			if (!(GetTarget(index).ObjectInstance is BaseBuildingInstance baseBuildingInstance))
			{
				return true;
			}
			if (!baseBuildingInstance.IsOnFire && !baseBuildingInstance.MarkedForDestruction && !baseBuildingInstance.MarkedForMoving)
			{
				return baseBuildingInstance.MarkedForUninstall;
			}
			return true;
		}
	}
}
