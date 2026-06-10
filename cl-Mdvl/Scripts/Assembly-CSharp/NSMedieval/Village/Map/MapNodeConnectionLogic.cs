using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Water;

namespace NSMedieval.Village.Map
{
	public static class MapNodeConnectionLogic
	{
		public static List<MapNode> GenerateNeighborsNonDiagonal(MapNode mapNode)
		{
			List<MapNode> list = ListPool<MapNode>.Get();
			foreach (MapNode item in MapNodeUtils.IterateNeighboursNonDiagonal(mapNode))
			{
				list.Add(item);
			}
			return list;
		}

		public static List<MapNode> GenerateConnections(MapNode selfNode)
		{
			WaterManager waterManager = VillageManager.ActiveVillage.Map.WaterManager;
			if (selfNode.CheckIsDataType(GridDataType.Slope) && (waterManager.GetWaterLevelAsDepth(selfNode.Index) & WaterDepthLevel.High) == 0)
			{
				return HandleSlopeConnections(selfNode);
			}
			if (selfNode.CheckIsDataType(GridDataType.Stairs) && (waterManager.GetWaterLevelAsDepth(selfNode.Index) & WaterDepthLevel.High) == 0)
			{
				return HandleStairsConnection(selfNode);
			}
			if ((selfNode.Tag & MapNodeTags.Ladder) != MapNodeTags.None && (selfNode.WaterLevel & WaterDepthLevel.High) == 0 && (selfNode.BuildingType & BuildingType.Ladder) != 0 && (selfNode.DataType & GridDataType.BuildingFinished) != GridDataType.None)
			{
				return HandleLadderConnection(selfNode);
			}
			if (selfNode.IsWater && selfNode.WaterLevel > WaterDepthLevel.Low && selfNode.Map.WaterManager.GetWaterDepthLevel(selfNode.Index) != WaterDepthLevel.Low)
			{
				return HandleWaterConnection(selfNode);
			}
			List<MapNode> list = ListPool<MapNode>.Get();
			MapNode nodeBelow = selfNode.GetNodeBelow();
			if (nodeBelow != null && nodeBelow.IsLayerRamp() && MapRampLogic.CanEnterRampFromNode(selfNode, nodeBelow))
			{
				list.Add(nodeBelow);
			}
			foreach (MapNode item in MapNodeUtils.IterateEachNeighbourOnLevel(selfNode))
			{
				MapNode nodeBelow2 = item.GetNodeBelow();
				if (nodeBelow2 != null && nodeBelow2.IsWater && IsDiagonalValid(selfNode, nodeBelow2) && nodeBelow2.IsWalkable && item.Map.WaterManager.CanClimbOut(nodeBelow2) && (item.Tag & (MapNodeTags.Floor | MapNodeTags.FloorPassthrough)) == 0)
				{
					list.Add(nodeBelow2);
				}
				if ((!item.IsLayerRamp() || MapRampLogic.CanEnterRampFromNode(selfNode, item)) && IsDiagonalValid(selfNode, item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		private static List<MapNode> HandleWaterConnection(MapNode selfNode)
		{
			List<MapNode> newConnections = ListPool<MapNode>.Get();
			WaterManager waterManager = selfNode.Map.WaterManager;
			MapNode nodeAboveSelf = selfNode.GetNodeAbove();
			MapNodeUtils.ForEachNeighbourOnLevel(selfNode, delegate(MapNode item)
			{
				if (item == selfNode)
				{
					return true;
				}
				if (!item.IsWater && (item.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorAlwaysOpen)) == 0)
				{
					return true;
				}
				if (!IsDiagonalValid(selfNode, item))
				{
					return true;
				}
				if (item.IsLayerRamp() && !MapRampLogic.CanEnterRampFromNode(selfNode, item))
				{
					return true;
				}
				if (!item.IsWalkable || !item.IsVoxelAir() || item.IsVoxelWall())
				{
					return true;
				}
				MapNode nodeAbove = item.GetNodeAbove();
				if (nodeAbove != null && !nodeAbove.IsVoxelFloor() && (nodeAbove.WaterDepthLevel & WaterDepthLevel.High) != 0 && !waterManager.IsWaterEnclosed(nodeAbove))
				{
					return true;
				}
				newConnections.Add(item);
				return true;
			});
			if (!waterManager.IsWaterEnclosed(selfNode))
			{
				return newConnections;
			}
			if (nodeAboveSelf != null && nodeAboveSelf.IsWater && waterManager.IsWaterEnclosed(nodeAboveSelf) && waterManager.IsWaterFull(selfNode) && nodeAboveSelf.IsVoxelAir() && !nodeAboveSelf.IsVoxelFloor() && !nodeAboveSelf.IsVoxelWall())
			{
				newConnections.Add(nodeAboveSelf);
			}
			if (waterManager.CanClimbOut(selfNode))
			{
				MapNodeUtils.ForEachNeighbourOnLevel(nodeAboveSelf, delegate(MapNode itemAbove)
				{
					if (itemAbove == nodeAboveSelf)
					{
						return true;
					}
					if (!itemAbove.IsVoxelAir() || itemAbove.IsVoxelWall())
					{
						return true;
					}
					if (!IsDiagonalValid(selfNode, itemAbove))
					{
						return true;
					}
					if (itemAbove.IsLayerRamp())
					{
						WorldObject worldObject = itemAbove.GetWorldObject(GridDataType.Stairs);
						if (worldObject != null && MapRampLogic.GetStairsLowestNode(worldObject) != itemAbove)
						{
							return true;
						}
						WorldObject worldObject2 = itemAbove.GetWorldObject(GridDataType.Slope);
						if (worldObject2 != null && MapRampLogic.GetSlopeLowestNode(worldObject2) != itemAbove)
						{
							return true;
						}
						if (MapRampLogic.CanEnterRampFromNode(selfNode, itemAbove))
						{
							newConnections.Add(itemAbove);
						}
						return true;
					}
					if (itemAbove.IsWalkable && (!itemAbove.IsWater || waterManager.CanWalkInside(itemAbove)))
					{
						newConnections.Add(itemAbove);
						return true;
					}
					return true;
				});
			}
			return newConnections;
		}

		private static List<MapNode> HandleLadderConnection(MapNode selfNode)
		{
			List<MapNode> newConnections = ListPool<MapNode>.Get();
			float ladderRotation = selfNode.GetWorldObject(GridDataType.BuildingFinished, (WorldObject o) => o is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.BuildingType == BuildingType.Ladder).Angle;
			MapNodeUtils.ForEachNeighbourOnLevel(selfNode, delegate(MapNode item)
			{
				if (selfNode == item)
				{
					return true;
				}
				if (!item.IsWalkable)
				{
					return true;
				}
				if (item.IsLayerRamp() && !MapRampLogic.CanEnterRampFromNode(selfNode, item))
				{
					return true;
				}
				if (!IsDiagonalValid(selfNode, item))
				{
					return true;
				}
				if (MapRampLogic.IsLadderBlocking(selfNode, ladderRotation, item))
				{
					return true;
				}
				newConnections.Add(item);
				return true;
			});
			MapNode nodeAbove = selfNode.GetNodeAbove();
			if (nodeAbove != null)
			{
				newConnections.Add(nodeAbove);
			}
			MapNode nodeBelow = selfNode.GetNodeBelow();
			if (nodeBelow != null && nodeBelow.IsLayerRamp() && MapRampLogic.CanEnterRampFromNode(selfNode, nodeBelow))
			{
				newConnections.Add(nodeBelow);
			}
			if (nodeBelow != null && !nodeBelow.IsLayerRamp() && nodeBelow.IsWater && (nodeBelow.WaterLevel & WaterDepthLevel.High) != 0 && nodeBelow.Map.WaterManager.CanClimbOut(nodeBelow))
			{
				newConnections.Add(nodeBelow);
			}
			return newConnections;
		}

		private static List<MapNode> HandleSlopeConnections(MapNode selfNode)
		{
			WorldObject worldObject = selfNode.GetWorldObject(GridDataType.Slope);
			if (worldObject == null)
			{
				return null;
			}
			List<MapNode> newConnections = ListPool<MapNode>.Get();
			GenerateNeighboursStairsConnections(worldObject, selfNode, newConnections);
			if (MapRampLogic.GetSlopeLowestNode(worldObject) == selfNode)
			{
				newConnections.Add(selfNode.Map.GetNode(worldObject.Positions[2]));
				MapNodeUtils.ForEachNeighbourOnLevel(selfNode, delegate(MapNode item)
				{
					if (selfNode == item || selfNode.Position.y != item.Position.y)
					{
						return true;
					}
					if (item.IsLayerRamp() && MapRampLogic.GetStairsLowestNode(item.GetWorldObject(GridDataType.Stairs)) != item && MapRampLogic.GetSlopeLowestNode(item.GetWorldObject(GridDataType.Slope)) != item)
					{
						return true;
					}
					if (!IsDiagonalValid(selfNode, item))
					{
						return true;
					}
					newConnections.Add(item);
					return true;
				});
				MapNodeUtils.ForEachNonDiagonalNeighbourOnLevel(selfNode, delegate(MapNode item)
				{
					if (item == selfNode)
					{
						return true;
					}
					MapNode nodeBelow = item.GetNodeBelow();
					if (nodeBelow != null && nodeBelow.IsWater && IsDiagonalValid(selfNode, nodeBelow) && nodeBelow.IsWalkable && item.Map.WaterManager.CanClimbOut(nodeBelow))
					{
						newConnections.Add(nodeBelow);
					}
					return true;
				});
				return newConnections;
			}
			if (MapRampLogic.GetSlopeHighestNode(worldObject) == selfNode)
			{
				MapNode node = selfNode.Map.GetNode(selfNode.Position + Vec3Int.up);
				if (node != null)
				{
					newConnections.Add(node);
				}
				newConnections.Add(selfNode.Map.GetNode(worldObject.Positions[1]));
				return newConnections;
			}
			GenerateMiddleConnections(worldObject, selfNode, newConnections);
			return newConnections;
		}

		private static List<MapNode> HandleStairsConnection(MapNode selfNode)
		{
			List<MapNode> newConnections = ListPool<MapNode>.Get();
			WorldObject worldObject = selfNode.GetWorldObject(GridDataType.Stairs);
			if (worldObject == null)
			{
				ListPool<MapNode>.Return(newConnections);
				return null;
			}
			GenerateNeighboursStairsConnections(worldObject, selfNode, newConnections);
			if (MapRampLogic.GetStairsLowestNode(worldObject) == selfNode)
			{
				List<Vec3Int> positions = worldObject.Positions;
				newConnections.Add(selfNode.Map.GetNode(positions[positions.Count - 2]));
				int y = selfNode.Position.y;
				foreach (MapNode item in MapNodeUtils.IterateEachNeighbor(selfNode))
				{
					if (selfNode != item && y == item.Position.y && (!item.IsLayerRamp() || item.GetLadders() != null || MapRampLogic.GetStairsLowestNode(item.GetWorldObject(GridDataType.Stairs)) == item || MapRampLogic.GetSlopeLowestNode(item.GetWorldObject(GridDataType.Slope)) == item) && IsDiagonalValid(selfNode, item))
					{
						newConnections.Add(item);
					}
				}
				MapNodeUtils.ForEachNonDiagonalNeighbourOnLevel(selfNode, delegate(MapNode item)
				{
					if (item == selfNode)
					{
						return true;
					}
					MapNode nodeBelow = item.GetNodeBelow();
					if (nodeBelow != null && nodeBelow.IsWater && IsDiagonalValid(selfNode, nodeBelow) && nodeBelow.IsWalkable && item.Map.WaterManager.CanClimbOut(nodeBelow))
					{
						newConnections.Add(nodeBelow);
					}
					return true;
				});
				return newConnections;
			}
			if (MapRampLogic.GetStairsHighestNode(worldObject) == selfNode)
			{
				List<Vec3Int> positions2 = worldObject.Positions;
				MapNode node = selfNode.Map.GetNode(selfNode.Position + Vec3Int.up);
				if (node != null)
				{
					newConnections.Add(node);
				}
				newConnections.Add(selfNode.Map.GetNode(positions2[1]));
				return newConnections;
			}
			GenerateMiddleConnections(worldObject, selfNode, newConnections);
			return newConnections;
		}

		private static void GenerateNeighboursStairsConnections(WorldObject stairsOnNode, MapNode selfNode, List<MapNode> newConnections)
		{
			int posFound = stairsOnNode.Positions.IndexOf(selfNode.Position);
			if (posFound < 0)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\StaticLogic\\MapNodeConnectionLogic.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Stairs node not found in stairsOnNode world object. POS: ");
					messageBuilder.AppendFormatted(selfNode.Position);
				}
				Log.Error(messageBuilder);
				return;
			}
			MapNodeUtils.ForEachNeighbourOnLevel(selfNode, delegate(MapNode node)
			{
				if ((node.DataType & GridDataType.SlopeOrStairs) == 0 || node == selfNode)
				{
					return true;
				}
				WorldObject worldObject = node.GetWorldObject(GridDataType.SlopeOrStairs);
				BaseBuildingInstance baseBuildingInstance = worldObject as BaseBuildingInstance;
				SlopeInstance slopeInstance = worldObject as SlopeInstance;
				int num = -1;
				if (baseBuildingInstance != null)
				{
					if (stairsOnNode == baseBuildingInstance)
					{
						return true;
					}
					num = baseBuildingInstance.Positions.IndexOf(node.Position);
				}
				else
				{
					if (slopeInstance == null)
					{
						return true;
					}
					num = slopeInstance.Positions.IndexOf(node.Position);
				}
				bool flag = node.Position.x != selfNode.Position.x && node.Position.z != selfNode.Position.z;
				if ((num < 0 || num != posFound) && ((num - posFound != 1 && num - posFound != -1) || !flag))
				{
					return true;
				}
				if (num == posFound && node.Position.x != selfNode.Position.x && node.Position.z != selfNode.Position.z)
				{
					return true;
				}
				newConnections.Add(node);
				return true;
			});
		}

		private static void GenerateMiddleConnections(WorldObject slopeOrStair, MapNode selfNode, List<MapNode> newConnections)
		{
			int num = slopeOrStair.Positions.FindIndex((Vec3Int item) => item.Equals(selfNode.Position));
			if (num < 1)
			{
				Log.Error("Something is wrong. SelfNode is not in the middle. This should never happen. " + selfNode.Position.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\StaticLogic\\MapNodeConnectionLogic.cs");
				return;
			}
			MapNode node = selfNode.Map.GetNode(slopeOrStair.Positions[num - 1]);
			MapNode node2 = selfNode.Map.GetNode(slopeOrStair.Positions[num + 1]);
			if (node == null || node2 == null)
			{
				Log.Error("Something is wrong. Some of the middle nodes are null. " + node?.ToString() + " | " + node2, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\StaticLogic\\MapNodeConnectionLogic.cs");
				return;
			}
			newConnections.Add(node);
			newConnections.Add(node2);
		}

		private static bool IsDiagonalValid(MapNode selfNode, MapNode connectionNode)
		{
			if (selfNode.Position.x == connectionNode.Position.x || selfNode.Position.z == connectionNode.Position.z)
			{
				return true;
			}
			VillageMap map = selfNode.Map;
			Vec3Int position = selfNode.Position;
			Vec3Int position2 = connectionNode.Position;
			MapNode node = map.GetNode(position.x, position.y, position2.z);
			if (node == null || !node.IsWalkable)
			{
				return false;
			}
			MapNode node2 = map.GetNode(position2.x, position.y, position.z);
			if (node2 == null || !node2.IsWalkable)
			{
				return false;
			}
			if (node.IsLayerRamp() || node2.IsLayerRamp())
			{
				return false;
			}
			return true;
		}
	}
}
