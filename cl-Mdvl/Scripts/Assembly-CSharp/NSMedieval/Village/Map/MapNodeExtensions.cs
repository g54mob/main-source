using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Types;

namespace NSMedieval.Village.Map
{
	public static class MapNodeExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWorldObjects(this MapNode mapNode)
		{
			if (mapNode?.WorldObjects != null)
			{
				return mapNode.WorldObjects.Count > 0;
			}
			return false;
		}

		public static bool HasWorldObjects(this MapNode mapNode, Func<WorldObject, bool> condition)
		{
			if (mapNode?.WorldObjects == null || mapNode.WorldObjects.Count == 0)
			{
				return false;
			}
			foreach (WorldObject worldObject in mapNode.WorldObjects)
			{
				if (condition(worldObject))
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsBuilding(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return false;
			}
			foreach (WorldObject worldObject in mapNode.WorldObjects)
			{
				if (worldObject is BaseBuildingInstance)
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsBuilding(this MapNode mapNode, BaseBuildingInstance target)
		{
			if (mapNode == null)
			{
				return false;
			}
			foreach (WorldObject worldObject in mapNode.WorldObjects)
			{
				if (worldObject is BaseBuildingInstance baseBuildingInstance && target == baseBuildingInstance)
				{
					return true;
				}
			}
			return false;
		}

		public static IEnumerable<WorldObject> GetWorldObjects(this MapNode mapNode, GridDataType type)
		{
			return mapNode?.WorldObjects.Where((WorldObject item) => (type & item.GridDataType) != 0);
		}

		public static IEnumerable<WorldObject> GetWorldObjects(this MapNode mapNode, WorldObjectType type)
		{
			return mapNode?.WorldObjects.Where((WorldObject item) => item.Type == type);
		}

		public static WorldObject GetWorldObject(this MapNode mapNode, WorldObjectType type, Func<WorldObject, bool> condition)
		{
			return mapNode?.WorldObjects.FirstOrDefault((WorldObject item) => item.Type == type && condition(item));
		}

		public static WorldObject GetLadders(this MapNode mapNode)
		{
			return mapNode?.WorldObjects.FirstOrDefault((WorldObject item) => item is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.BuildingType == BuildingType.Ladder);
		}

		public static WorldObject GetWorldObject(this MapNode mapNode, GridDataType type = GridDataType.All, Func<WorldObject, bool> condition = null)
		{
			if (mapNode == null)
			{
				return null;
			}
			if ((mapNode.DataType & type) == 0)
			{
				return null;
			}
			if (condition == null)
			{
				for (int i = 0; i < mapNode.WorldObjects.Count; i++)
				{
					if ((type & mapNode.WorldObjects[i].GridDataType) != GridDataType.None)
					{
						return mapNode.WorldObjects[i];
					}
				}
				return null;
			}
			for (int j = 0; j < mapNode.WorldObjects.Count; j++)
			{
				WorldObject worldObject = mapNode.WorldObjects[j];
				if ((type & worldObject.GridDataType) != GridDataType.None && condition(worldObject))
				{
					return worldObject;
				}
			}
			return null;
		}

		public static WorldObject GetWorldObject(this MapNode mapNode, WorldObjectType type)
		{
			if (mapNode == null)
			{
				return null;
			}
			foreach (WorldObject worldObject in mapNode.WorldObjects)
			{
				if (worldObject.Type == type)
				{
					return worldObject;
				}
			}
			return null;
		}

		public static void UpdateWorldObjectReachability(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return;
			}
			foreach (WorldObject worldObject in mapNode.WorldObjects)
			{
				if (!worldObject.HasDisposed)
				{
					worldObject.UpdateReachability();
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsVoxelAir(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return false;
			}
			return mapNode.VoxelTypeIdByte == 0;
		}

		public static bool IsVoxelFloor(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return false;
			}
			return (mapNode.Tag & (MapNodeTags.Floor | MapNodeTags.FloorPassthrough)) != 0;
		}

		public static bool IsVoxelWall(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return false;
			}
			return (mapNode.Tag & MapNodeTags.Wall) != 0;
		}

		public static bool IsVoxelDoor(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return false;
			}
			return (mapNode.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.DoorAlwaysOpen)) != 0;
		}

		public static bool IsLayerRamp(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return false;
			}
			if ((mapNode.DataType & GridDataType.SlopeOrStairs) != GridDataType.None)
			{
				return true;
			}
			if ((mapNode.Tag & MapNodeTags.Ladder) != MapNodeTags.None && (mapNode.BuildingType & BuildingType.Ladder) != 0)
			{
				return true;
			}
			return false;
		}

		public static bool IsSlopeOrStairs(this MapNode node)
		{
			if (node == null)
			{
				return false;
			}
			return (node.DataType & GridDataType.SlopeOrStairs) != 0;
		}

		public static bool IsLadder(this MapNode node)
		{
			if (node == null)
			{
				return false;
			}
			return (node.Tag & MapNodeTags.Ladder) != 0;
		}

		public static WorldObject GetLayerRampObject(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return null;
			}
			WorldObject worldObject = mapNode.GetWorldObject(GridDataType.SlopeOrStairs);
			if (worldObject != null)
			{
				return worldObject;
			}
			return mapNode.GetWorldObject(GridDataType.BuildingFinished, (WorldObject o) => o is BaseBuildingInstance baseBuildingInstance && baseBuildingInstance.BuildingType == BuildingType.Ladder);
		}

		public static bool IsEdge(this MapNode mapNode)
		{
			if (mapNode == null)
			{
				return false;
			}
			if (mapNode.Position.x != 0 && mapNode.Position.z != 0 && mapNode.Position.x < mapNode.Map.Size.x - 1)
			{
				return mapNode.Position.z >= mapNode.Map.Size.z - 1;
			}
			return true;
		}
	}
}
