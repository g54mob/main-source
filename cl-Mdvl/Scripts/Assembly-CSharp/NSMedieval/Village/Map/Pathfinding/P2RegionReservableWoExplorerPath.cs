using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;

namespace NSMedieval.Village.Map.Pathfinding
{
	public sealed class P2RegionReservableWoExplorerPath : Path
	{
		public enum RegionExplorerCallbackResult
		{
			None = 0,
			Continue = 1,
			Skip = 2,
			Finish = 3
		}

		private GridDataType dataType;

		private WorldObjectType worldObjectType;

		private Func<WorldObject, bool> condition;

		private Func<WorldObject, Vec3Int, RegionExplorerCallbackResult> onPathFound;

		private HashSet<Region> closedRegions;

		private Queue<Region> openRegions;

		private HashSet<WorldObject> alreadyVisitedObjects;

		private Queue<WorldObject> objectQueue;

		private HashSet<PathSearchNode> usedNodes;

		private Queue<Region> expandRegionInternalCache;

		private bool doQuickSearch;

		private int regionExpandCount;

		private Region startRegion;

		public override IEnumerable<Vec3Int> EndPositions
		{
			get
			{
				yield return default(Vec3Int);
			}
		}

		internal P2RegionReservableWoExplorerPath()
			: base(PathType.P2WorldObjRegionExplorerPath)
		{
		}

		public static P2RegionReservableWoExplorerPath Construct(IPathfindingAgent agent, Vec3Int startPos, GridDataType gdType, WorldObjectType woType, bool doQuickSearch, Func<WorldObject, bool> condition, Func<WorldObject, Vec3Int, RegionExplorerCallbackResult> onPathFound)
		{
			if (agent.Map == null)
			{
				throw new Exception("Can not construct path for agent without map. " + agent);
			}
			P2RegionReservableWoExplorerPath p2RegionReservableWoExplorerPath = (P2RegionReservableWoExplorerPath)PathPool.Get(PathType.P2WorldObjRegionExplorerPath);
			p2RegionReservableWoExplorerPath.Map = agent.Map;
			p2RegionReservableWoExplorerPath.Start = ((startPos != Vec3Int.zero) ? startPos : agent.GetGridPosition());
			p2RegionReservableWoExplorerPath.dataType = gdType;
			p2RegionReservableWoExplorerPath.worldObjectType = woType;
			p2RegionReservableWoExplorerPath.doQuickSearch = doQuickSearch;
			p2RegionReservableWoExplorerPath.condition = condition;
			p2RegionReservableWoExplorerPath.onPathFound = onPathFound;
			p2RegionReservableWoExplorerPath.regionExpandCount = 0;
			Path.SetCoreConstructionParameters(agent, p2RegionReservableWoExplorerPath);
			return p2RegionReservableWoExplorerPath;
		}

		protected override bool Initialize(PathProcessor processor)
		{
			if (base.Agent.Map.GetObjectCount(dataType) == 0)
			{
				return false;
			}
			closedRegions = HashSetPool<Region>.Get();
			openRegions = QueuePool<Region>.Get();
			objectQueue = QueuePool<WorldObject>.Get();
			alreadyVisitedObjects = HashSetPool<WorldObject>.Get();
			expandRegionInternalCache = QueuePool<Region>.Get();
			if (!doQuickSearch)
			{
				usedNodes = HashSetPool<PathSearchNode>.Get();
			}
			return base.Initialize(processor);
		}

		protected override void ResetToDefaultState()
		{
			HashSetPool<Region>.Return(closedRegions);
			QueuePool<Region>.Return(openRegions);
			QueuePool<WorldObject>.Return(objectQueue);
			QueuePool<Region>.Return(expandRegionInternalCache);
			HashSetPool<WorldObject>.Return(alreadyVisitedObjects);
			if (!doQuickSearch)
			{
				HashSetPool<PathSearchNode>.Return(usedNodes);
			}
			openRegions = null;
			closedRegions = null;
			objectQueue = null;
			alreadyVisitedObjects = null;
			condition = null;
			expandRegionInternalCache = null;
			onPathFound = null;
			usedNodes = null;
			base.ResetToDefaultState();
			_ = regionExpandCount;
			_ = 0;
		}

		protected override bool CalculatePath(PathProcessor processor)
		{
			if (base.State != PathState.Processing)
			{
				return false;
			}
			MapNode node = base.Map.GetNode(base.Start);
			if (node?.Region == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(69, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Path\\P2RegionReservableWoExplorerPath.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Could not find P2WorldObjRegionExplorerPath start node! ");
					messageBuilder.AppendFormatted(base.Start);
					messageBuilder.AppendLiteral(" reg ");
					messageBuilder.AppendFormatted(node?.Region);
					messageBuilder.AppendLiteral(" Agent: ");
					messageBuilder.AppendFormatted(base.Agent);
				}
				Log.Warning(messageBuilder);
				return false;
			}
			startRegion = node.Region;
			openRegions.Enqueue(node.Region);
			bool flag = false;
			while (true)
			{
				WorldObject worldObject = ExploreForWorldObject(processor);
				if (base.State != PathState.Processing || worldObject == null)
				{
					break;
				}
				if (worldObject.HasDisposed || !condition(worldObject) || !MonoSingleton<ReservationManager>.Instance.TryReserveObject(worldObject, base.Agent))
				{
					continue;
				}
				processor.ClosedNodes.Clear();
				Vec3Int lhs = FindPathToWorldObject(worldObject, node, processor);
				if (lhs == Vec3Int.zero)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(worldObject, base.Agent);
					continue;
				}
				RegionExplorerCallbackResult regionExplorerCallbackResult = onPathFound(worldObject, lhs);
				switch (regionExplorerCallbackResult)
				{
				case RegionExplorerCallbackResult.Finish:
					return true;
				case RegionExplorerCallbackResult.Skip:
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(worldObject, base.Agent);
					break;
				}
				flag = flag || regionExplorerCallbackResult == RegionExplorerCallbackResult.Continue;
			}
			return flag;
		}

		protected override void OnCalculationsDone(PathProcessor processor)
		{
			if (!doQuickSearch)
			{
				foreach (PathSearchNode usedNode in usedNodes)
				{
					usedNode.TagA = false;
				}
			}
			base.OnCalculationsDone(processor);
		}

		private Vec3Int FindPathToWorldObject(WorldObject obj, MapNode startNode, PathProcessor processor)
		{
			if (doQuickSearch)
			{
				return obj.GetFirstReachablePosition(base.Agent);
			}
			Vec3Int rhs;
			foreach (Vec3Int reachablePosition in obj.ReachablePositions)
			{
				if (reachablePosition.y != startNode.Position.y)
				{
					continue;
				}
				Vec3Int lhs = ExploreForPath(reachablePosition);
				rhs = Vec3Int.zero;
				if (lhs == rhs)
				{
					break;
				}
				rhs = lhs;
				goto IL_00e8;
			}
			foreach (Vec3Int reachablePosition2 in obj.ReachablePositions)
			{
				if (reachablePosition2.y == startNode.Position.y)
				{
					continue;
				}
				rhs = ExploreForPath(reachablePosition2);
				goto IL_00e8;
			}
			return Vec3Int.zero;
			IL_00e8:
			return rhs;
			Vec3Int ExploreForPath(Vec3Int pos)
			{
				MapNode node = base.Map.GetNode(pos);
				SetHTarget(node);
				return ExplorePath(startNode, processor)?.Node.Position ?? Vec3Int.zero;
			}
		}

		protected override bool IsTargetFound(PathSearchNode node)
		{
			return node.TagA;
		}

		private WorldObject ExploreForWorldObject(PathProcessor processor)
		{
			if (objectQueue.Count == 0)
			{
				if (FloodExploreRegions())
				{
					return ExploreForWorldObject(processor);
				}
				if (objectQueue.Count > 0)
				{
					return ExploreForWorldObject(processor);
				}
				return null;
			}
			WorldObject worldObject = objectQueue.Dequeue();
			if (!doQuickSearch)
			{
				foreach (PathSearchNode usedNode in usedNodes)
				{
					usedNode.TagA = false;
				}
				usedNodes.Clear();
				foreach (Vec3Int reachablePosition in worldObject.ReachablePositions)
				{
					PathSearchNode searchNode = processor.GetSearchNode(reachablePosition);
					searchNode.TagA = true;
					usedNodes.Add(searchNode);
				}
			}
			return worldObject;
		}

		private bool FloodExploreRegions()
		{
			expandRegionInternalCache.Clear();
			foreach (Region openRegion in openRegions)
			{
				regionExpandCount++;
				if (!base.TraversalProvider.CanTraverse(startRegion, openRegion))
				{
					continue;
				}
				if ((openRegion.GridDataType & dataType) != GridDataType.None)
				{
					foreach (WorldObject reachableObject in openRegion.ReachableObjects)
					{
						if ((reachableObject.GridDataType & dataType) != GridDataType.None && (worldObjectType == WorldObjectType.None || reachableObject.Type == worldObjectType) && alreadyVisitedObjects.Add(reachableObject) && PathfinderUtil.IsPathPossible(base.Agent, reachableObject))
						{
							objectQueue.Enqueue(reachableObject);
						}
					}
				}
				expandRegionInternalCache.Enqueue(openRegion);
			}
			openRegions.Clear();
			while (expandRegionInternalCache.Count > 0)
			{
				Region region = expandRegionInternalCache.Dequeue();
				closedRegions.Add(region);
				foreach (Region connection in region.Connections)
				{
					if (!closedRegions.Contains(connection) && base.TraversalProvider.CanTraverse(connection, region))
					{
						closedRegions.Add(connection);
						openRegions.Enqueue(connection);
					}
				}
			}
			return openRegions.Count > 0;
		}
	}
}
