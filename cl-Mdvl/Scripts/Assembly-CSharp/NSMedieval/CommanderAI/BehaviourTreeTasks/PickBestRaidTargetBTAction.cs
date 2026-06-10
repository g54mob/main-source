using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.CommanderAI.Utilities;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Pick the best target to attack")]
	public class PickBestRaidTargetBTAction : UnitsBTActionBase
	{
		public BBParameter<IDamageTakingAgent> saveAs;

		public BBParameter<IDamageTakingAgent> obstacleTargetDebug;

		private IDamageTakingAgent bestTarget;

		private static WalkableModel testWalkableModelNoDoors;

		protected override string info => $"{saveAs} = best raid target";

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			testWalkableModelNoDoors = null;
		}

		protected override void OnStart()
		{
			if ((object)testWalkableModelNoDoors == null)
			{
				testWalkableModelNoDoors = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentUnwalkableDoors();
			}
			bestTarget = null;
			MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(PickBestTargetThread, delegate(bool result)
			{
				if (!result)
				{
					Log.Debug("Repick FAIL", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
					EndAction(success: false);
				}
				else
				{
					bool isEnabled;
					if (saveAs.value != bestTarget)
					{
						FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Repick SUCCESS: ");
							messageBuilder.AppendFormatted(bestTarget);
						}
						Log.Debug(messageBuilder);
						saveAs.SetValue(bestTarget);
					}
					else
					{
						FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(35, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Repick SUCCESS (target unchanged): ");
							messageBuilder2.AppendFormatted(bestTarget);
						}
						Log.Trace(messageBuilder2);
					}
					EndAction();
				}
			});
		}

		private bool PickBestTargetThread()
		{
			bool isEnabled;
			if (PickDirectPathImmediateDangerDraftedWorker())
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PickDirectPathImmediateDangerDraftedWorker() found ");
					messageBuilder.AppendFormatted(bestTarget);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			if (saveAs.value is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker() && !CombatAiUtils.IsAgentDefeated(saveAs.value))
			{
				bestTarget = saveAs.value;
				return true;
			}
			if (PickDirectPathDraftedWorker())
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PickDirectPathDraftedWorker() found ");
					messageBuilder.AppendFormatted(bestTarget);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			if (PickWorkerPastAggressors())
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PickWorkerPastAggressors() found ");
					messageBuilder.AppendFormatted(bestTarget);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			if (PickHighestValueRoomBuilding())
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PickHighestValueRoomBuilding() found ");
					messageBuilder.AppendFormatted(bestTarget);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			if (PickDenseWorkersRegionWorker())
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\PickBestRaidTargetBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PickDenseWorkersRegionWorker() found ");
					messageBuilder.AppendFormatted(bestTarget);
				}
				Log.Trace(messageBuilder);
				return true;
			}
			return false;
		}

		private bool PickWorkerPastAggressors()
		{
			HumanoidInstance humanoidInstance = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.MaxItem((HumanoidInstance worker) => worker.CombatAi.GetState<float>(CombatAiState.LastAttackTime) + 100f / base.UnitForPathfinding.Humanoid.Distance(worker), null, delegate(HumanoidInstance worker)
			{
				if (CombatAiUtils.IsAgentDefeated(worker))
				{
					return false;
				}
				return (worker.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.LastAttackedTarget) is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsEnemy()) ? true : false;
			});
			if (humanoidInstance == null)
			{
				return false;
			}
			bestTarget = humanoidInstance;
			return true;
		}

		private bool PickDirectPathImmediateDangerDraftedWorker()
		{
			if (base.UnitCount < 3)
			{
				return false;
			}
			float num = float.MaxValue;
			int num2 = 0;
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (!CombatAiUtils.IsAgentDefeated(key) && key.WorkerBehaviour.IsDrafting)
				{
					float num3 = base.UnitForPathfinding.Humanoid.DistanceSquared(key);
					if (PathfinderUtil.IsPathPossible(base.UnitForPathfinding.Humanoid, key, testWalkableModelNoDoors) && num3 < num)
					{
						num2++;
						num = num3;
						bestTarget = key;
					}
				}
			}
			if (num2 >= 3)
			{
				return bestTarget != null;
			}
			return false;
		}

		private bool PickDirectPathDraftedWorker()
		{
			float num = float.MaxValue;
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				if (!CombatAiUtils.IsAgentDefeated(key) && key.WorkerBehaviour.IsDrafting)
				{
					float num2 = base.UnitForPathfinding.Humanoid.DistanceSquared(key);
					if (PathfinderUtil.IsPathPossible(base.UnitForPathfinding.Humanoid, key) && num2 < num)
					{
						num = num2;
						bestTarget = key;
					}
				}
			}
			return bestTarget != null;
		}

		private bool PickHighestValueRoomBuilding()
		{
			using PooledList<Region> pooledList = base.Map.RegionManager.Regions.ToPooledListJanitor((Region region) => region.TotalBuildingWealth >= 0f);
			pooledList.Sort((Region region1, Region region2) => region2.TotalBuildingWealth.CompareTo(region1.TotalBuildingWealth));
			if (pooledList.Count == 0)
			{
				return false;
			}
			foreach (Region item in pooledList)
			{
				if (item.ReachableBuildings.MaxItem((WorldObject obj) => ((BaseBuildingInstance)obj).GetWealth(), null, (WorldObject obj) => obj is BaseBuildingInstance baseBuildingInstance2 && (CommanderAIFilters.BuildingTypesToSpreadAttack & baseBuildingInstance2.BuildingType) != 0 && !CombatAiUtils.IsAgentDefeated(baseBuildingInstance2) && !base.Map.FirePresenceGrid.HasFirePresence(obj.GetGridPosition())) is BaseBuildingInstance baseBuildingInstance)
				{
					bestTarget = baseBuildingInstance;
					return true;
				}
			}
			return false;
		}

		private bool PickDenseWorkersRegionWorker()
		{
			PooledDictionary<int, int> workerCountByRegion = DictionaryPool<int, int>.GetJanitor();
			try
			{
				foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
				{
					if (!CombatAiUtils.IsAgentDefeated(key))
					{
						int uniqueId = key.GetNode().Region.UniqueId;
						workerCountByRegion.TryAdd(uniqueId, 0);
						workerCountByRegion[uniqueId]++;
					}
				}
				if (workerCountByRegion.Count == 0)
				{
					return false;
				}
				HumanoidInstance humanoidInstance = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.MaxItem((HumanoidInstance worker) => (float)workerCountByRegion[worker.GetNode().Region.UniqueId] + 100f / base.UnitForPathfinding.Humanoid.Distance(worker), null, (HumanoidInstance worker) => !CombatAiUtils.IsAgentDefeated(worker));
				if (humanoidInstance == null)
				{
					return false;
				}
				bestTarget = humanoidInstance;
				return true;
			}
			finally
			{
				((IDisposable)workerCountByRegion/*cast due to .constrained prefix*/).Dispose();
			}
		}
	}
}
