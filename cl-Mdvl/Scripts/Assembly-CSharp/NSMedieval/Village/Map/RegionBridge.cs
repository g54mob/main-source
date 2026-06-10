using FoxyVoxel.Logging;

namespace NSMedieval.Village.Map
{
	public sealed class RegionBridge : Region
	{
		private MapNode node;

		public override bool IsBridge => true;

		public MapNodeTags Tags => node.Tag;

		public MapNode Node => node;

		public RegionBridge(int uniqueId, VillageMap map)
			: base(uniqueId, map)
		{
		}

		public override void AddNode(MapNode node)
		{
			if (base.Nodes.Count > 0)
			{
				Log.Error("Tried to add multiple nodes to bridge region", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\RegionBridge.cs");
				return;
			}
			this.node = node;
			base.AddNode(node);
		}

		public override void Dispose()
		{
			base.Dispose();
			node = null;
		}
	}
}
