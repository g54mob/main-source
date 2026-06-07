namespace Pathfinding.Clipper2Lib
{
	internal readonly struct IntersectNode
	{
		public readonly Point64 pt;

		public readonly Active edge1;

		public readonly Active edge2;

		public IntersectNode(Point64 pt, Active edge1, Active edge2)
		{
			this.pt = default(Point64);
			this.edge1 = null;
			this.edge2 = null;
		}
	}
}
