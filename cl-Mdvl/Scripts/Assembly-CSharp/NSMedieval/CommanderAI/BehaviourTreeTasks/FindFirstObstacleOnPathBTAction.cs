using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village.Map.Pathfinding;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Find the first obstacle on the path to a given target or the target itself if there is no obstacle")]
	public class FindFirstObstacleOnPathBTAction : UnitsBTActionBaseThread
	{
		[RequiredField]
		public BBParameter<IDamageTakingAgent> target;

		public BBParameter<IDamageTakingAgent> saveObstacleAs;

		private Path path;

		private IDamageTakingAgent obstacle;

		protected override string info => $"{saveObstacleAs} = First obstacle on path to {target} OR {target}";

		protected override void OnStart()
		{
			obstacle = null;
			saveObstacleAs.SetValue(null);
			if (base.Units == null || base.UnitCount == 0 || target?.value == null || target.value.HasDisposed)
			{
				Log.Trace("Units null or empty or target null", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				EndAction(success: false);
			}
			else
			{
				base.OnStart();
			}
		}

		protected override bool OnThread()
		{
			if (FindObstacle(base.UnitForPathfinding))
			{
				return true;
			}
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (!CombatUtils.IsNullOrDisposed(unit.Humanoid) && FindObstacle(unit))
				{
					return true;
				}
			}
			return false;
		}

		private bool FindObstacle(CommanderAIUnit unit)
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting FindObstacle for ");
				messageBuilder.AppendFormatted(unit.Humanoid);
			}
			Log.Trace(messageBuilder);
			path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(unit.Humanoid, target.value, forceMelee: true);
			if (path != null)
			{
				MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(path);
				if (path.State == PathState.Calculated)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Direct path found to target ");
						messageBuilder.AppendFormatted(target.value);
					}
					Log.Trace(messageBuilder);
					obstacle = target.value;
					Path.ReleasePath(path);
					return true;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Direct path NOT found to target ");
					messageBuilder.AppendFormatted(target.value);
				}
				Log.Trace(messageBuilder);
			}
			if (path != null)
			{
				Path.ReleasePath(path);
			}
			path = P2PPath.Construct(unit.Humanoid, target.value.GetGridPosition());
			if (path == null)
			{
				Log.Trace("Path null after trying to construct", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				return false;
			}
			path.TraversalProvider = PathTraversalProvider.DefaultProvider;
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(path);
			if (path.State != PathState.Calculated)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Path calc failed, no reachable obstacle we can clear on path to ");
					messageBuilder.AppendFormatted(target.value);
				}
				Log.Trace(messageBuilder);
				Path.ReleasePath(path);
				return false;
			}
			DoorComponentInstance firstReachableDoor = CombatAiUtils.GetFirstReachableDoor(path, unit.Humanoid);
			if (firstReachableDoor != null)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Obstacle is a DOOR ");
					messageBuilder.AppendFormatted(firstReachableDoor.OwnerBuilding);
				}
				Log.Trace(messageBuilder);
				obstacle = firstReachableDoor.OwnerBuilding;
				Path.ReleasePath(path);
				return true;
			}
			HumanoidInstance firstReachableWorkerObstacle = CombatAiUtils.GetFirstReachableWorkerObstacle(path, unit.Humanoid);
			if (firstReachableWorkerObstacle != null)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Obstacle is a WORKER ");
					messageBuilder.AppendFormatted(firstReachableWorkerObstacle);
				}
				Log.Trace(messageBuilder);
				obstacle = firstReachableWorkerObstacle;
				Path.ReleasePath(path);
				return true;
			}
			Log.Trace("Failed, obstacle is not a door or a worker", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
			Path.ReleasePath(path);
			return false;
		}

		protected override void OnDoneCallback(bool result)
		{
			if (!result)
			{
				EndAction(success: false);
				return;
			}
			saveObstacleAs.SetValue(obstacle);
			EndAction();
		}

		protected override void OnTick()
		{
			if (base.Units == null || base.UnitCount == 0)
			{
				Log.Trace("Units null or empty", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				EndAction(success: false);
			}
			else if (target?.value == null || target.value.HasDisposed || target.value.HasDied)
			{
				Log.Trace("Target dead", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\FindFirstObstacleOnPathBTAction.cs");
				EndAction(success: false);
			}
		}
	}
}
