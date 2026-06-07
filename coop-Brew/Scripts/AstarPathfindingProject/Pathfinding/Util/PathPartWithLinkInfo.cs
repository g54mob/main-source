namespace Pathfinding.Util
{
	public struct PathPartWithLinkInfo
	{
		public int startIndex;

		public int endIndex;

		public OffMeshLinks.OffMeshLinkTracer linkInfo;

		public Funnel.PartType type => default(Funnel.PartType);

		public PathPartWithLinkInfo(int startIndex, int endIndex, OffMeshLinks.OffMeshLinkTracer linkInfo = default(OffMeshLinks.OffMeshLinkTracer))
		{
			this.startIndex = 0;
			this.endIndex = 0;
			this.linkInfo = default(OffMeshLinks.OffMeshLinkTracer);
		}
	}
}
