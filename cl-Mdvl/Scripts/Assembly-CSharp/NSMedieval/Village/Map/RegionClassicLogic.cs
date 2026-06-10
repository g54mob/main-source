using System.Collections.Generic;

namespace NSMedieval.Village.Map
{
	public static class RegionClassicLogic
	{
		public static Region FillRegionFromNode(MapNode startNode)
		{
			return RegionCommonLogic.FillRegionFromNode(startNode, CanAddToRegion);
		}

		public static void TrimExpandRegion(Region region, ref List<MapNode> removedNodes)
		{
			RegionCommonLogic.TrimExpandRegion(region, ref removedNodes, CanAddToRegion);
		}

		public static bool CanAddToRegion(MapNode node, Region region, bool ignoreRegionMaxLimit = false)
		{
			if (node.Region != null && node.Region != region)
			{
				return false;
			}
			if (!node.IsWalkable)
			{
				return false;
			}
			if (RegionBridgeLogic.IsBridgeNode(node))
			{
				if (region != null)
				{
					if (region.IsBridge)
					{
						return region.Nodes.Contains(node);
					}
					return false;
				}
				return true;
			}
			if (region != null && region.IsBridge)
			{
				return false;
			}
			if (region == null)
			{
				return true;
			}
			if (node.IsFire != region.IsFire)
			{
				return false;
			}
			if (!ignoreRegionMaxLimit)
			{
				return region.Nodes.Count < 420;
			}
			return true;
		}
	}
}
