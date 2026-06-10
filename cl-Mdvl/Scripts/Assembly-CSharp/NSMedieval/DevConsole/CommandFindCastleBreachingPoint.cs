using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using Raid.Config;

namespace NSMedieval.DevConsole
{
	public class CommandFindCastleBreachingPoint : ConsoleCommand
	{
		private MapNode startAttackNode;

		private MapNode goalAttackNode;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandFindCastleBreachingPoint()
		{
			Command = "findCastleBreachingPoint";
			Description = "Returns a path of nodes from a greathall to a node that can reach edge of the map";
			Help = "FindCastleBreachingPoint";
		}

		private void CommandMethod()
		{
			FindCastleAttackAndBreachPoints();
			SiegeTraversalProvider traversalProvider = new SiegeTraversalProvider(Repository<PathfindingPenaltyRepository, PathfindingPenalty>.Instance.GetByID("enemy"), SingletonModel<RaidSpawnSettings, RaidSpawnSettingsData>.I.StandardSiegePathfinderSettings);
			SiegePath siegePath = SiegePath.Construct(startAttackNode.Position, goalAttackNode.Position, VillageManager.ActiveVillage.Map, traversalProvider);
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(siegePath);
			Log.Info("Path processed!", SiegeTraversalProvider.LogPath);
			Log.Info($"Result: {siegePath.State}", SiegeTraversalProvider.LogPath);
			Log.Info($"Node count: {siegePath.NodePath.Count}", SiegeTraversalProvider.LogPath);
			foreach (MapNode item in siegePath.NodePath)
			{
				_ = item;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("<color=red>Path is built!!</color>");
		}

		private void FindCastleAttackAndBreachPoints()
		{
			MapNode mapNode = null;
			foreach (Room item in VillageManager.ActiveVillage.Map.RoomDetection.IterateRoomsSafe())
			{
				if (item.RoomType.IsGreatHall)
				{
					mapNode = item.AllNodes.PickRandom();
					break;
				}
			}
			goalAttackNode = mapNode;
			MonoSingleton<NPCStartPositionManager>.Instance.GetStartAndTarget(Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentUnwalkableDoors(), out var _, out var outStartingNodes, 1, 10, onlyTargetReachable: false);
			startAttackNode = outStartingNodes.PickRandom();
		}
	}
}
