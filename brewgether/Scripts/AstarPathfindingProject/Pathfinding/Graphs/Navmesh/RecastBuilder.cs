using System.Runtime.InteropServices;
using Pathfinding.Collections;
using Pathfinding.Graphs.Navmesh.Jobs;

namespace Pathfinding.Graphs.Navmesh
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RecastBuilder
	{
		public static TileBuilder BuildTileMeshes(RecastGraph graph, TileLayout tileLayout, IntRect tileRect)
		{
			return default(TileBuilder);
		}

		public static JobBuildNodes BuildNodeTiles(RecastGraph graph, TileLayout tileLayout)
		{
			return default(JobBuildNodes);
		}

		public static TileCutter CutTiles(NavmeshBase graph, GridLookup<NavmeshClipper> cuts, TileLayout tileLayout)
		{
			return default(TileCutter);
		}
	}
}
