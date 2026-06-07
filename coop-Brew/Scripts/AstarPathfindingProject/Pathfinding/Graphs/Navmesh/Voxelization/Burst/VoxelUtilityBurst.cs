using Unity.Collections;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	internal static class VoxelUtilityBurst
	{
		public const int TagRegMask = 16383;

		public const int TagReg = 16384;

		public const ushort BorderReg = 32768;

		public const int RC_BORDER_VERTEX = 65536;

		public const int RC_AREA_BORDER = 131072;

		public const int VERTEX_BUCKET_COUNT = 4096;

		public const int RC_CONTOUR_TESS_WALL_EDGES = 1;

		public const int RC_CONTOUR_TESS_AREA_EDGES = 2;

		public const int RC_CONTOUR_TESS_TILE_EDGES = 4;

		public const int ContourRegMask = 65535;

		public static readonly int[] DX;

		public static readonly int[] DZ;

		public static void CalculateDistanceField(CompactVoxelField field, NativeArray<ushort> output)
		{
		}

		public static void BoxBlur(CompactVoxelField field, NativeArray<ushort> src, NativeArray<ushort> dst)
		{
		}
	}
}
