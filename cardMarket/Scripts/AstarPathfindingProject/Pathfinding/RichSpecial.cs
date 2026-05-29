namespace Pathfinding
{
	public class RichSpecial : RichPathPart
	{
		public OffMeshLinks.OffMeshLinkTracer nodeLink;

		public FakeTransform first => new FakeTransform
		{
			position = nodeLink.relativeStart,
			rotation = (nodeLink.isReverse ? nodeLink.link.end.rotation : nodeLink.link.start.rotation)
		};

		public FakeTransform second => new FakeTransform
		{
			position = nodeLink.relativeEnd,
			rotation = (nodeLink.isReverse ? nodeLink.link.start.rotation : nodeLink.link.end.rotation)
		};

		public bool reverse => nodeLink.isReverse;

		public override void OnEnterPool()
		{
			nodeLink = default(OffMeshLinks.OffMeshLinkTracer);
		}

		public RichSpecial Initialize(OffMeshLinks.OffMeshLinkTracer nodeLink)
		{
			this.nodeLink = nodeLink;
			return this;
		}
	}
}
