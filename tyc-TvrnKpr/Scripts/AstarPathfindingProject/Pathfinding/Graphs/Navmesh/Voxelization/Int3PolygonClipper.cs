using Pathfinding.Collections;

namespace Pathfinding.Graphs.Navmesh.Voxelization
{
	internal struct Int3PolygonClipper
	{
		private unsafe fixed float clipPolygonCache[21];

		public int ClipPolygon(UnsafeSpan<Int3> vIn, int n, UnsafeSpan<Int3> vOut, int multi, int offset, int axis)
		{
			return 0;
		}
	}
}
