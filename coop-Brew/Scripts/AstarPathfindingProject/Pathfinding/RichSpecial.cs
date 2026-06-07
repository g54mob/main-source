namespace Pathfinding
{
	public class RichSpecial : RichPathPart
	{
		public OffMeshLinks.OffMeshLinkTracer nodeLink;

		public FakeTransform first => default(FakeTransform);

		public FakeTransform second => default(FakeTransform);

		public bool reverse => false;

		public override void OnEnterPool()
		{
		}

		public RichSpecial Initialize(OffMeshLinks.OffMeshLinkTracer nodeLink)
		{
			return null;
		}
	}
}
