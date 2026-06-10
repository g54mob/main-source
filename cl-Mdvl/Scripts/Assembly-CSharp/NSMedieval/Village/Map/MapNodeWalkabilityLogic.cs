using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Types;

namespace NSMedieval.Village.Map
{
	public static class MapNodeWalkabilityLogic
	{
		internal static bool IsOccupiedByUnWalkableBuilding(MapNode node)
		{
			foreach (WorldObject worldObject in node.WorldObjects)
			{
				if ((worldObject.GridDataType & (GridDataType.BuildingFinished | GridDataType.Roof)) == 0)
				{
					continue;
				}
				BaseBuildingInstance baseBuildingInstance = (BaseBuildingInstance)worldObject;
				if (!(baseBuildingInstance.Blueprint == null) && baseBuildingInstance.BuildingType != BuildingType.Ladder)
				{
					if ((baseBuildingInstance.BuildingType & BuildingType.Window) != 0)
					{
						return true;
					}
					if (baseBuildingInstance.GetPathfindingPenalty() >= ushort.MaxValue)
					{
						return true;
					}
				}
			}
			return false;
		}

		internal static bool IsOccupiedByWalkableBuilding(MapNode node)
		{
			foreach (WorldObject worldObject in node.WorldObjects)
			{
				if (worldObject != null && (worldObject.GridDataType & GridDataType.BuildingFinished) != GridDataType.None && worldObject is BaseBuildingInstance baseBuildingInstance)
				{
					if (baseBuildingInstance.BuildingType == BuildingType.Ladder)
					{
						return true;
					}
					if (baseBuildingInstance.ConstructionPhase == ConstructionPhase.Finished && (baseBuildingInstance.BuildingType & (BuildingType.Floor | BuildingType.Door | BuildingType.Merlon | BuildingType.BarnDoor)) != 0)
					{
						return true;
					}
				}
			}
			if (node.DataType.HasFlag(GridDataType.Drawbridge))
			{
				return true;
			}
			return false;
		}

		internal static bool CanSupportWalkabilityAbove(MapNode node, MapNode nodeAbove)
		{
			if (nodeAbove == null)
			{
				return false;
			}
			if (!node.IsVoxelAir())
			{
				return true;
			}
			if (node.IsLayerRamp() && MapRampLogic.CanEnterRampFromNode(nodeAbove, node))
			{
				return true;
			}
			foreach (WorldObject worldObject in node.WorldObjects)
			{
				if ((worldObject.GridDataType & GridDataType.BuildingFinished) != GridDataType.None && worldObject is BaseBuildingInstance baseBuildingInstance)
				{
					if ((baseBuildingInstance.BuildingType & (BuildingType.Wall | BuildingType.Window | BuildingType.Door | BuildingType.BarnDoor)) != 0)
					{
						return true;
					}
					if (baseBuildingInstance.BuildingType == BuildingType.Ladder)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
