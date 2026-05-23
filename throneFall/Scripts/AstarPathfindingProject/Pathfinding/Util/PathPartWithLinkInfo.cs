namespace Pathfinding.Util
{
	public struct PathPartWithLinkInfo
	{
		public int startIndex;

		public int endIndex;

		public OffMeshLinks.OffMeshLinkTracer linkInfo;

		public Funnel.PartType type
		{
			get
			{
				if (linkInfo.link == null)
				{
					return Funnel.PartType.NodeSequence;
				}
				return Funnel.PartType.OffMeshLink;
			}
		}

		public PathPartWithLinkInfo(int startIndex, int endIndex, OffMeshLinks.OffMeshLinkTracer linkInfo = default(OffMeshLinks.OffMeshLinkTracer))
		{
			this.startIndex = startIndex;
			this.endIndex = endIndex;
			this.linkInfo = linkInfo;
		}
	}
}
