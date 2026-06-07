namespace tripolygon.UModeler
{
	public enum EPolygonCacheRefreshFlag
	{
		None = 0,
		RenderableMesh = 1,
		AABB = 2,
		WorldAABB = 4,
		UVAABB = 8,
		BSPTree = 16,
		Segments = 32,
		PrivateFlags = 64,
		SmallestX = 128,
		ConvexHull = 256,
		All = 511
	}
}
