using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public static class MapRampLogic
	{
		public static bool CanEnterRampFromNode(MapNode fromNode, MapNode rampNode)
		{
			if (!rampNode.IsLayerRamp())
			{
				return false;
			}
			WorldObject layerRampObject = rampNode.GetLayerRampObject();
			return CanEnterRampFromNode(fromNode, layerRampObject);
		}

		public static void GetRampAccessNodes(MapNode rampNode, out MapNode lowAccessNode, out MapNode highAccessNode)
		{
			highAccessNode = (lowAccessNode = null);
			if (rampNode == null)
			{
				return;
			}
			if (rampNode.IsLadder())
			{
				lowAccessNode = rampNode.GetNodeBelow();
				highAccessNode = rampNode.GetNodeAbove()?.GetNodeAbove();
				if (lowAccessNode != null && !lowAccessNode.IsWalkable)
				{
					foreach (MapNode item in rampNode.ConnectionsSafe)
					{
						if (item.IsWalkable && item.Position.y <= rampNode.Position.y)
						{
							lowAccessNode = item;
							break;
						}
					}
				}
				if (highAccessNode != null && !highAccessNode.IsWalkable && rampNode.GetNodeAbove() != null)
				{
					foreach (MapNode item2 in rampNode.GetNodeAbove().ConnectionsSafe)
					{
						if (item2.IsWalkable && item2.Position.y > rampNode.Position.y)
						{
							highAccessNode = item2;
							break;
						}
					}
				}
			}
			else if ((rampNode.DataType & GridDataType.SlopeOrStairs) != GridDataType.None)
			{
				WorldObject worldObject = rampNode.GetWorldObject(GridDataType.SlopeOrStairs);
				if (worldObject != null)
				{
					Vector3 vector = new Vector3(3f, 0f, 0f);
					Vector3 vector2 = new Vector3(-1f, 1f, 0f);
					Quaternion quaternion = Quaternion.AngleAxis(worldObject.Angle, Vector3.up);
					vector = quaternion * vector;
					vector2 = quaternion * vector2;
					VillageMap map = rampNode.Map;
					lowAccessNode = map.GetNode(rampNode.Position + vector);
					highAccessNode = map.GetNode(rampNode.Position + vector2);
					GetRampLowHighNodes(worldObject, out var lowestNode, out var highestNode);
					if (lowAccessNode != null && lowestNode != null && !lowAccessNode.IsWalkable)
					{
						foreach (MapNode item3 in lowestNode.ConnectionsSafe)
						{
							if (item3.IsWalkable && item3.Position.y <= lowestNode.Position.y)
							{
								lowAccessNode = item3;
								break;
							}
						}
					}
					if (highAccessNode != null && highestNode != null && !highAccessNode.IsWalkable)
					{
						foreach (MapNode item4 in highestNode.ConnectionsSafe)
						{
							if (item4.IsWalkable && item4.Position.y >= highestNode.Position.y && !worldObject.Positions.Contains(item4.Position))
							{
								highAccessNode = item4;
								break;
							}
						}
					}
				}
			}
			if (lowAccessNode != null && !lowAccessNode.IsWalkable)
			{
				lowAccessNode = null;
			}
			if (highAccessNode != null && !highAccessNode.IsWalkable)
			{
				highAccessNode = null;
			}
		}

		public static bool CanEnterRampFromNode(MapNode fromNode, WorldObject ramp)
		{
			if (ramp == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\StaticLogic\\MapRampLogic.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Ramp not found on Node: ");
					messageBuilder.AppendFormatted(fromNode.Position);
					messageBuilder.AppendLiteral(". This might happen during loading only.");
				}
				Log.Warning(messageBuilder);
				return false;
			}
			if ((ramp.GridDataType & GridDataType.Slope) != GridDataType.None)
			{
				if (ramp.GridDataPosition.y == fromNode.Position.y)
				{
					return Vec3Int.Distance(GetSlopeLowestNode(ramp).Position, fromNode.Position) <= 1.005f;
				}
				if (fromNode.IsWater && ramp.GridDataPosition.y > fromNode.Position.y)
				{
					return GetSlopeLowestNode(ramp).WorldPosition.DistanceXZ(fromNode.WorldPosition) <= 1.005f;
				}
				if (fromNode.Position.y - ramp.GridDataPosition.y != 1)
				{
					return false;
				}
				MapNode slopeHighestNode = GetSlopeHighestNode(ramp);
				if (slopeHighestNode.Position.x == fromNode.Position.x)
				{
					return slopeHighestNode.Position.z == fromNode.Position.z;
				}
				return false;
			}
			if ((ramp.GridDataType & GridDataType.Stairs) != GridDataType.None)
			{
				if (ramp.GridDataPosition.y == fromNode.Position.y)
				{
					return Vec3Int.Distance(GetStairsLowestNode(ramp).Position, fromNode.Position) <= 1.005f;
				}
				if (fromNode.IsWater && ramp.GridDataPosition.y > fromNode.Position.y)
				{
					return GetStairsLowestNode(ramp).WorldPosition.DistanceXZ(fromNode.WorldPosition) <= 1.005f;
				}
				if (fromNode.Position.y - ramp.GridDataPosition.y != 1)
				{
					return false;
				}
				MapNode stairsHighestNode = GetStairsHighestNode(ramp);
				if (stairsHighestNode.Position.x == fromNode.Position.x)
				{
					return stairsHighestNode.Position.z == fromNode.Position.z;
				}
				return false;
			}
			if (ramp is BaseBuildingInstance { BuildingType: BuildingType.Ladder } baseBuildingInstance)
			{
				return !IsLadderBlocking(ramp.GetNode(), baseBuildingInstance.Angle, fromNode);
			}
			return false;
		}

		public static bool IsRampEntryNode(MapNode node)
		{
			if (!node.IsLayerRamp())
			{
				return false;
			}
			WorldObject layerRampObject = node.GetLayerRampObject();
			if ((node.DataType & GridDataType.Slope) != GridDataType.None)
			{
				if (GetSlopeLowestNode(layerRampObject) != node)
				{
					return GetSlopeHighestNode(layerRampObject) == node;
				}
				return true;
			}
			if ((node.DataType & GridDataType.Stairs) != GridDataType.None)
			{
				if (GetStairsLowestNode(layerRampObject) != node)
				{
					return GetStairsHighestNode(layerRampObject) == node;
				}
				return true;
			}
			Log.Error("This line should never be reached, but it will in the future, probably...", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\StaticLogic\\MapRampLogic.cs");
			return false;
		}

		public static void GetRampLowHighNodes(WorldObject ramp, out MapNode lowestNode, out MapNode highestNode)
		{
			if ((ramp.GridDataType & GridDataType.Slope) != GridDataType.None)
			{
				lowestNode = GetSlopeLowestNode(ramp);
				highestNode = GetSlopeHighestNode(ramp);
			}
			else if ((ramp.GridDataType & GridDataType.Stairs) != GridDataType.None)
			{
				lowestNode = GetStairsLowestNode(ramp);
				highestNode = GetStairsHighestNode(ramp);
			}
			else
			{
				lowestNode = (highestNode = null);
			}
		}

		public static MapNode GetSlopeLowestNode(WorldObject slope)
		{
			return slope?.Map.GetNode(slope.Positions[0]);
		}

		public static MapNode GetSlopeHighestNode(WorldObject slope)
		{
			if (slope == null)
			{
				return null;
			}
			VillageMap map = slope.Map;
			List<Vec3Int> positions = slope.Positions;
			return map.GetNode(positions[positions.Count - 1]);
		}

		public static MapNode GetStairsLowestNode(WorldObject stairs)
		{
			List<Vec3Int> list = stairs?.Positions;
			if (list != null)
			{
				return stairs.Map.GetNode(list[list.Count - 1]);
			}
			return null;
		}

		public static MapNode GetStairsHighestNode(WorldObject stairs)
		{
			return stairs.Map.GetNode(stairs.GridDataPosition);
		}

		public static bool IsLadderBlocking(MapNode ladderNode, float angle, MapNode targetNode)
		{
			if (ladderNode.BuildingType != BuildingType.Ladder)
			{
				return false;
			}
			if (targetNode.IsWater && ladderNode.Position.y > targetNode.Position.y)
			{
				return false;
			}
			if (Mathf.Approximately(angle, 180f))
			{
				return ladderNode.Position.z > targetNode.Position.z;
			}
			if (Mathf.Approximately(angle, 270f))
			{
				return ladderNode.Position.x > targetNode.Position.x;
			}
			if (Mathf.Approximately(angle, 0f))
			{
				return ladderNode.Position.z < targetNode.Position.z;
			}
			if (Mathf.Approximately(angle, 90f))
			{
				return ladderNode.Position.x < targetNode.Position.x;
			}
			return false;
		}
	}
}
