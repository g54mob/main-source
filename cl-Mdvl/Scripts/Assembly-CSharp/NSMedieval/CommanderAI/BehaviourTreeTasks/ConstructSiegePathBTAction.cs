using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Siege")]
	[Description("Constructs path from siegeGroup position to siegeTarget positions, sets resultPath on success")]
	public class ConstructSiegePathBTAction : UnitsBTActionBase
	{
		[RequiredField]
		public BBParameter<IDamageTakingAgent> siegeTarget;

		public BBParameter<List<MapNode>> resultPath;

		private PathProcessingTask pathTask;

		protected override string info => "Construct siege path for " + base.info;

		protected override void OnStart()
		{
			if (CombatUtils.IsNullOrDisposed(base.UnitForPathfinding.Humanoid, siegeTarget.value))
			{
				EndAction(success: false);
				return;
			}
			MapNode node = base.UnitForPathfinding.Humanoid.GetNode();
			MapNode node2 = siegeTarget.value.GetNode();
			Log.Info($"Constructing siege path to target '{siegeTarget.value}', unit for pathfinding is {base.UnitForPathfinding.Humanoid}", SiegeTraversalProvider.LogPath);
			Vec3Int position = node.Position;
			Vec3Int position2 = node2.Position;
			SiegeTraversalProvider traversalProvider = new SiegeTraversalProvider(Repository<PathfindingPenaltyRepository, PathfindingPenalty>.Instance.GetByID("enemy"), base.agent.SiegePathfinderModifiers);
			SiegePath path = SiegePath.Construct(position, position2, VillageManager.ActiveVillage.Map, traversalProvider);
			pathTask = MonoSingleton<PathProcessorManager>.Instance.ScheduleProcessPath(path);
			PathProcessingTask pathProcessingTask = pathTask;
			pathProcessingTask.OnComplete = (Action<PathProcessingTask>)Delegate.Combine(pathProcessingTask.OnComplete, new Action<PathProcessingTask>(OnPathCalculated));
		}

		protected override void OnStop()
		{
			if (pathTask != null)
			{
				PathProcessingTask pathProcessingTask = pathTask;
				pathProcessingTask.OnComplete = (Action<PathProcessingTask>)Delegate.Remove(pathProcessingTask.OnComplete, new Action<PathProcessingTask>(OnPathCalculated));
				pathTask = null;
			}
		}

		private void OnPathCalculated(PathProcessingTask task)
		{
			if (task.State != PathProcessingTaskState.Completed || task.Path.NodePath.Count <= 0)
			{
				Log.Trace("Failed to calculate siege path", SiegeTraversalProvider.LogPath);
				EndAction(success: false);
			}
			else
			{
				ConstructSiegePath(task.Path);
			}
		}

		private void ConstructSiegePath(Path path)
		{
			MapNode mapNode = null;
			if (IsSiegeWalkable(path))
			{
				Log.Trace("Failed to construct siege path: IsSiegeWalkable TRUE", SiegeTraversalProvider.LogPath);
				EndAction(success: false);
				return;
			}
			foreach (MapNode item in path.NodePath)
			{
			}
			resultPath.SetValue(path.NodePath);
			EndAction(success: true);
		}

		private bool IsSiegeWalkable(Path path)
		{
			MapNode mapNode = null;
			foreach (MapNode item in path.NodePath)
			{
				if (mapNode != null && !SiegeTraversalProvider.IsSiegeWalkable(mapNode, item))
				{
					return false;
				}
				mapNode = item;
			}
			return true;
		}

		private void ParsePathToAction(MapNode start, MapNode destination)
		{
			SiegeTraversalProvider.IsFloorBreak(start, destination);
			SiegeTraversalProvider.IsBuildLadder(start, destination);
			SiegeTraversalProvider.IsAirGap(start, destination);
			SiegeTraversalProvider.IsAirBridge(start, destination);
			SiegeTraversalProvider.IsWaterStepUpAttackPlank(start, destination);
			SiegeTraversalProvider.IsWallBreak(start, destination);
			SiegeTraversalProvider.IsWallMine(start, destination);
		}
	}
}
