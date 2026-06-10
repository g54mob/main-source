using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Types;

namespace NSMedieval.Village.Map
{
	public class RegionBridgeLogic
	{
		public static bool IsBridgeNode(MapNode node)
		{
			if ((node.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
			{
				return true;
			}
			if (!node.CheckIsDataType(GridDataType.SlopeOrStairs | GridDataType.BuildingFinished | GridDataType.Furniture | GridDataType.FurnitureGate))
			{
				return false;
			}
			foreach (WorldObject worldObject in node.WorldObjects)
			{
				if (worldObject != null && (worldObject.GridDataType & (GridDataType.SlopeOrStairs | GridDataType.BuildingFinished | GridDataType.Furniture | GridDataType.FurnitureGate)) != GridDataType.None)
				{
					if ((worldObject.GridDataType & GridDataType.Slope) != GridDataType.None)
					{
						return worldObject.GridDataPosition.Equals(node.Position);
					}
					if (worldObject is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Finished } baseBuildingInstance && baseBuildingInstance.Blueprint != null && baseBuildingInstance.Blueprint.IsRegionBridge)
					{
						_ = worldObject.GridDataType & GridDataType.Stairs;
						return true;
					}
				}
			}
			return false;
		}
	}
}
