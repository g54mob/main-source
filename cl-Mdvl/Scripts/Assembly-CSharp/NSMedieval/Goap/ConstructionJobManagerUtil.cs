using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap
{
	public static class ConstructionJobManagerUtil
	{
		private const int MinRegionNodes = 100;

		public static bool WouldJobEncloseRegion(VillageMap map, MapNode jobNode, out WorldDirection avoidReachableDirections, out bool errorHappened, bool wouldRemoveNode = false)
		{
			errorHappened = false;
			avoidReachableDirections = WorldDirection.None;
			if (map == null || jobNode == null)
			{
				return false;
			}
			if (!wouldRemoveNode)
			{
				return DoWouldEncloseFloodFill(jobNode, out avoidReachableDirections, out errorHappened);
			}
			if (!jobNode.IsSlopeOrStairs() && !jobNode.IsLadder())
			{
				if (!jobNode.IsWalkable)
				{
					jobNode = jobNode.GetNodeAbove();
				}
				if (jobNode == null)
				{
					return false;
				}
				bool result = DoWouldEncloseFloodFill(jobNode, out avoidReachableDirections, out errorHappened);
				avoidReachableDirections |= WorldDirection.C | WorldDirection.UC;
				return result;
			}
			MapNode mapNode = null;
			MapNode mapNode2 = null;
			if (jobNode.IsLadder())
			{
				mapNode = jobNode;
				mapNode2 = jobNode.GetNodeAbove();
			}
			else
			{
				if ((jobNode.DataType & GridDataType.Slope) != GridDataType.None)
				{
					WorldObject worldObject = jobNode.GetWorldObject(GridDataType.Slope);
					mapNode = MapRampLogic.GetSlopeLowestNode(worldObject);
					mapNode2 = MapRampLogic.GetSlopeHighestNode(worldObject);
				}
				else if ((jobNode.DataType & GridDataType.Stairs) != GridDataType.None)
				{
					WorldObject worldObject2 = jobNode.GetWorldObject(GridDataType.Stairs);
					mapNode = MapRampLogic.GetStairsLowestNode(worldObject2);
					mapNode2 = MapRampLogic.GetStairsHighestNode(worldObject2);
				}
				if (mapNode == null || mapNode2 == null)
				{
					return false;
				}
				mapNode2 = mapNode2.GetNodeAbove();
			}
			if (mapNode2 == null)
			{
				return false;
			}
			avoidReachableDirections = WorldDirection.C;
			if (mapNode.IsDeadEnd && mapNode2.IsDeadEnd)
			{
				return false;
			}
			MapRampLogic.GetRampAccessNodes(jobNode, out var lowAccessNode, out var highAccessNode);
			if (mapNode.IsDeadEnd)
			{
				if (highAccessNode != null)
				{
					avoidReachableDirections = ~ReachabilityUtil.GetNeighbourDirection(jobNode, highAccessNode);
				}
				return false;
			}
			if (mapNode2.IsDeadEnd)
			{
				if (lowAccessNode != null)
				{
					avoidReachableDirections = ~ReachabilityUtil.GetNeighbourDirection(jobNode, lowAccessNode);
				}
				avoidReachableDirections &= ~WorldDirection.AllHorizontal;
				return false;
			}
			if (DoWouldEncloseFloodFill(mapNode, out var avoidReachableDirections2, out errorHappened))
			{
				avoidReachableDirections |= WorldDirection.AllHorizontal | WorldDirection.AllLower;
				return true;
			}
			if (DoWouldEncloseFloodFill(mapNode2, out avoidReachableDirections2, out errorHappened))
			{
				avoidReachableDirections |= WorldDirection.AllUpper;
				return true;
			}
			return false;
		}

		public static float CalculateRelativePriority(short jobPriority, in Vector3 jobPosition, in Vector3 agentPosition, float yModifier = 1f)
		{
			float num = (jobPosition - agentPosition).magnitude + yModifier * Mathf.Abs(jobPosition.y - agentPosition.y);
			return (float)jobPriority - 10f * num;
		}

		private static bool DoWouldEncloseFloodFill(MapNode jobNode, out WorldDirection avoidReachableDirections, out bool threadExceptionHappened)
		{
			threadExceptionHappened = false;
			avoidReachableDirections = WorldDirection.None;
			Vec3Int position = jobNode.Position;
			bool flag = false;
			bool flag2 = false;
			SlopeInstance slope = jobNode.GetWorldObject(GridDataType.Slope) as SlopeInstance;
			StairsComponentInstance stairs = jobNode.Map.StairsComponentManager.GetComponentInstance(jobNode.Position);
			LadderComponentInstance ladder = ((!jobNode.IsLadder()) ? null : (jobNode.Map.LadderComponentManager.GetComponentInstance(jobNode.Position) ?? jobNode.Map.LadderComponentManager.GetComponentInstance(jobNode.Position - Vec3Int.up)));
			foreach (MapNode item in jobNode.ConnectionsSafe)
			{
				if (!CanSpread(jobNode, item))
				{
					continue;
				}
				bool isEnabled;
				if (!item.IsWalkable)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(57, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManagerUtil.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("WouldEncloseRegion_");
						messageBuilder.AppendFormatted(position);
						messageBuilder.AppendLiteral(" connection ");
						messageBuilder.AppendFormatted(item.Position);
						messageBuilder.AppendLiteral(" is not walkable, skipping");
					}
					Log.Trace(messageBuilder);
					continue;
				}
				flag2 = true;
				int num = 1;
				try
				{
					foreach (MapNode item2 in FloodFillUtil.IterateFloodFillConnections(item, 100f, null, preferNonWater: false, CanSpread))
					{
						_ = item2;
						num++;
						if (num >= 100)
						{
							break;
						}
					}
				}
				catch (InvalidOperationException)
				{
					Log.Warning("(Safe) InvalidOperationException occurred during flood fill, WouldEnclose() failed - conservatively returning 'true'", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\ConstructionJobManager\\ConstructionJobManagerUtil.cs");
					avoidReachableDirections = WorldDirection.None;
					threadExceptionHappened = true;
					isEnabled = true;
					return isEnabled;
				}
				if (num < 100)
				{
					flag = true;
					avoidReachableDirections |= ReachabilityUtil.GetNeighbourDirection(jobNode, item);
				}
				if (ladder == null)
				{
					continue;
				}
				WorldDirection neighbourDirection = ReachabilityUtil.GetNeighbourDirection(jobNode, item);
				avoidReachableDirections = ~neighbourDirection;
				isEnabled = flag;
				return isEnabled;
			}
			if (!flag2)
			{
				return true;
			}
			return flag;
			bool CanSpread(MapNode source, MapNode destination)
			{
				if (destination == jobNode)
				{
					return false;
				}
				if (slope != null && slope.Positions.Contains(destination.Position))
				{
					return false;
				}
				if (stairs != null && stairs.Positions.Contains(destination.Position))
				{
					return false;
				}
				if (ladder != null && destination.IsLadder() && (destination.Position == ladder.GridDataPosition || destination.Position == ladder.GridDataPosition + Vec3Int.up))
				{
					return false;
				}
				return CanSpreadFilter(source, destination);
			}
		}

		private static bool CanSpreadFilter(MapNode node, MapNode connection)
		{
			if (IsFloodFillObstacle(connection))
			{
				return false;
			}
			Vec3Int vec3Int = connection.Position - node.Position;
			if (vec3Int.x == 0 || vec3Int.y != 0 || vec3Int.z == 0)
			{
				return true;
			}
			Vec3Int gridPosition = node.Position + Vec3Int.right * vec3Int.x;
			Vec3Int gridPosition2 = node.Position + Vec3Int.forward * vec3Int.z;
			MapNode node2 = node.Map.GetNode(gridPosition);
			MapNode node3 = node.Map.GetNode(gridPosition2);
			if (!IsFloodFillObstacle(node2))
			{
				return !IsFloodFillObstacle(node3);
			}
			return false;
		}

		private static bool IsFloodFillObstacle(MapNode iterNode)
		{
			if (iterNode == null)
			{
				return true;
			}
			return !iterNode.IsWalkable;
		}

		public static bool IsInEnclosedRegion(MapNode node)
		{
			if (node == null)
			{
				return false;
			}
			int num = 0;
			foreach (MapNode item in FloodFillUtil.IterateFloodFillConnections(node, 100f, null, preferNonWater: false, CanSpreadFilter))
			{
				_ = item;
				num++;
				if (num >= 100)
				{
					return false;
				}
			}
			return true;
		}
	}
}
