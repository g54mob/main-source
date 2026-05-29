using System.Runtime.InteropServices;
using Pathfinding.Graphs.Navmesh.Jobs;

namespace Pathfinding.Graphs.Navmesh
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RecastBuilder
	{
		public static TileBuilder BuildTileMeshes(RecastGraph graph, TileLayout tileLayout, IntRect tileRect)
		{
			return new TileBuilder(graph, tileLayout, tileRect);
		}

		public static JobBuildNodes BuildNodeTiles(RecastGraph graph, TileLayout tileLayout)
		{
			return new JobBuildNodes(graph, tileLayout);
		}
	}
}
