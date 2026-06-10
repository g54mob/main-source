using System.Linq;
using NSMedieval.Model;
using NSMedieval.Water;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class TagTraversalProvider : PathTraversalProvider
	{
		private MapNodeTags notWalkableTags;

		public MapNodeTags NotWalkableTags
		{
			get
			{
				return notWalkableTags;
			}
			set
			{
				notWalkableTags = value;
			}
		}

		public TagTraversalProvider(TagTraversalProvider provider)
			: base(provider.PenaltyModel)
		{
			notWalkableTags = provider.notWalkableTags;
		}

		public TagTraversalProvider(PathfindingPenalty penalty)
			: base(penalty)
		{
		}

		public TagTraversalProvider(PathfindingPenalty penalty, MapNodeTags notWalkableTags)
			: base(penalty)
		{
			this.notWalkableTags = notWalkableTags;
		}

		public override bool CanStandOnNode(MapNode node)
		{
			if (!node.IsWalkable)
			{
				return false;
			}
			if (node.Tag != MapNodeTags.None)
			{
				return (node.Tag & notWalkableTags) == 0;
			}
			return true;
		}

		public override bool CanTraverse(MapNode nodeTo, MapNode nodeFrom)
		{
			if (CanStandOnNode(nodeTo))
			{
				return true;
			}
			if ((nodeTo.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
			{
				if ((nodeFrom.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
				{
					return nodeTo.Position.y == nodeFrom.Position.y;
				}
				return true;
			}
			return false;
		}

		public override bool CanStandOnRegion(Region region)
		{
			if (region == null)
			{
				return true;
			}
			if ((notWalkableTags & MapNodeTags.Fire) != MapNodeTags.None && region.IsFire)
			{
				return false;
			}
			if ((notWalkableTags & (MapNodeTags.WaterLevelLow | MapNodeTags.WaterLevelMedium | MapNodeTags.WaterLevelHigh)) != MapNodeTags.None)
			{
				MapNode mapNode = region.Nodes[0];
				if (mapNode.VoxelTypeIdByte == 0)
				{
					WaterDepthLevel waterDepthLevel = mapNode.WaterDepthLevel;
					if (((waterDepthLevel & WaterDepthLevel.Low) != 0 && (notWalkableTags & MapNodeTags.WaterLevelLow) != MapNodeTags.None) || ((waterDepthLevel & WaterDepthLevel.Medium) != 0 && (notWalkableTags & MapNodeTags.WaterLevelMedium) != MapNodeTags.None) || ((waterDepthLevel & WaterDepthLevel.High) != 0 && (notWalkableTags & MapNodeTags.WaterLevelHigh) != MapNodeTags.None))
					{
						return false;
					}
					if (!region.IsBridge || (waterDepthLevel & (WaterDepthLevel.Low | WaterDepthLevel.Medium)) == 0)
					{
						return true;
					}
				}
			}
			if (region.IsBridge)
			{
				RegionBridge regionBridge = (RegionBridge)region;
				if (regionBridge.Tags != MapNodeTags.None)
				{
					return (regionBridge.Tags & notWalkableTags) == 0;
				}
				return true;
			}
			return true;
		}

		public override bool CanTraverse(Region regionTo, Region regionFrom)
		{
			if (CanStandOnRegion(regionTo))
			{
				return true;
			}
			RegionBridge regionBridge = regionTo as RegionBridge;
			RegionBridge regionBridge2 = regionFrom as RegionBridge;
			if (((regionBridge != null && (regionBridge.Tags & MapNodeTags.Ladder) != MapNodeTags.None) || (regionBridge2 != null && (regionBridge2.Tags & MapNodeTags.Ladder) != MapNodeTags.None)) && regionTo.Nodes.First().Position.y == regionFrom.Nodes.First().Position.y)
			{
				return true;
			}
			return false;
		}
	}
}
