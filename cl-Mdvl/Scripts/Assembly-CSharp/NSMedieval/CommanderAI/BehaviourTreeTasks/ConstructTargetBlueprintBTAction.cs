using FoxyVoxel.Logging;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Construction;
using NSMedieval.Extensions;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Unit Orders")]
	[Description("Issue construct order on buildTarget blueprint and wait until building is finished")]
	public class ConstructTargetBlueprintBTAction : UnitsBTActionBase
	{
		[RequiredField]
		public BBParameter<BaseBuildingInstance> buildTarget;

		protected override string info => $"{base.info}: Construct blueprint {buildTarget}";

		protected override void OnStart()
		{
			if (buildTarget?.value == null || base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
			}
			else
			{
				Log.Info($"ConstructBTAction starts building {buildTarget.value.GetBuildingName()} at {buildTarget.value.GridDataPosition}", SiegeTraversalProvider.LogPath);
			}
		}

		protected override void OnTick()
		{
			if (buildTarget.value == null || base.Units == null || base.UnitCount == 0)
			{
				Log.Info("ConstructBTAction failed because no units or no build target.", SiegeTraversalProvider.LogPath);
				EndAction(success: false);
				return;
			}
			if (buildTarget.value.HasDied)
			{
				Log.Info($"Building {buildTarget.value} was destroyed", SiegeTraversalProvider.LogPath);
				EndAction(success: false);
				buildTarget.value = null;
				return;
			}
			if (buildTarget.value.ConstructionPhase == ConstructionPhase.Finished)
			{
				Log.Info("ConstructBTAction succeeded because construction phase is finished.", SiegeTraversalProvider.LogPath);
				EndAction(success: true);
				buildTarget.value = null;
				return;
			}
			if (buildTarget.value.IsReachabilityUpdateInProgress)
			{
				Log.Trace($"Reachability update is in progress for build target, waiting ({buildTarget.value})", SiegeTraversalProvider.LogPath);
				return;
			}
			Log.Trace($"Reachable positions for target blueprint {buildTarget.value}: {buildTarget.value.ReachablePositions.ToPrettyString(newLineSeparator: true)}", SiegeTraversalProvider.LogPath);
			bool flag = false;
			bool flag2 = false;
			foreach (CommanderAIUnit unit in base.Units)
			{
				if (unit.Humanoid.HasDiedOrFainted || unit.Humanoid.HasDisposed)
				{
					continue;
				}
				flag = true;
				if (PathfinderUtil.IsPathPossible(unit.Humanoid, buildTarget.value))
				{
					flag2 = true;
					if (!(unit.CurrentOrder is ConstructBuildingOrder constructBuildingOrder) || !constructBuildingOrder.IsForBuilding(buildTarget.value))
					{
						unit.CurrentOrder = new ConstructBuildingOrder(buildTarget.value.BlueprintId, buildTarget.value.GetGridPosition(), 0, isSiegeWeapon: false);
					}
				}
			}
			if (!flag)
			{
				Log.Info("ConstructBTAction failed because all units died.", SiegeTraversalProvider.LogPath);
				buildTarget.value = null;
				EndAction(success: false);
			}
			else if (!flag2)
			{
				Log.Info($"ConstructBTAction failed because no one can reach {buildTarget.value}.", SiegeTraversalProvider.LogPath);
				buildTarget.value = null;
				EndAction(success: false);
			}
		}

		protected override void OnStop(bool interrupted)
		{
			if (interrupted)
			{
				return;
			}
			foreach (CommanderAIUnit unit in base.Units)
			{
				unit.CurrentOrder = MoveOrder.Stop(unit);
			}
		}
	}
}
