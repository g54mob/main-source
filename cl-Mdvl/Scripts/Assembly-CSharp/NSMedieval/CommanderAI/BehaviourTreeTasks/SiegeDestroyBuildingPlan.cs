using FoxyVoxel.Logging;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Siege")]
	[Description("Takes current and previous path nodes, decides if some building needs to be broken. Returns success if target is set to building we want to break.")]
	public class SiegeDestroyBuildingPlan : CommanderAIBTActionBase
	{
		public BBParameter<MapNode> currentNode;

		public BBParameter<MapNode> previousNode;

		public BBParameter<IDamageTakingAgent> target;

		protected override void OnStart()
		{
			if (currentNode.isNoneOrNull || previousNode.isNoneOrNull)
			{
				EndAction(success: false);
				return;
			}
			MapNode value = previousNode.value;
			MapNode value2 = currentNode.value;
			BaseBuildingInstance baseBuildingInstance = null;
			if (SiegeTraversalProvider.IsDoorBreak(value, value2))
			{
				Log.Trace($"Is door break {value.Position} -> {value2.Position}", SiegeTraversalProvider.LogPath);
				baseBuildingInstance = value2.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.Door | BuildingType.FenceGate, value2.Position);
			}
			if (SiegeTraversalProvider.IsFloorBreak(value, value2))
			{
				Log.Trace($"Is floor break {value.Position} -> {value2.Position}", SiegeTraversalProvider.LogPath);
				baseBuildingInstance = ((value.Position.y <= value2.Position.y) ? value2.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.Floor, value2.Position) : value.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.Floor, value.Position));
			}
			if (SiegeTraversalProvider.IsWallBreak(value, value2))
			{
				Log.Trace($"Is wall break {value.Position} -> {value2.Position}", SiegeTraversalProvider.LogPath);
				baseBuildingInstance = value2.Map.BuildingsManagerMain.GetFirstBuilding(BuildingType.Wall | BuildingType.Roof | BuildingType.Window, value2.Position);
			}
			if (baseBuildingInstance == null)
			{
				Log.Trace($"Nothing to break {value.Position} -> {value2.Position}", SiegeTraversalProvider.LogPath);
				EndAction(success: false);
			}
			else
			{
				Log.Info($"Siege destroy plan is targeting {baseBuildingInstance.GetBuildingName()} at {baseBuildingInstance.GridDataPosition}", SiegeTraversalProvider.LogPath);
				target.SetValue(baseBuildingInstance);
				EndAction(success: true);
			}
		}
	}
}
