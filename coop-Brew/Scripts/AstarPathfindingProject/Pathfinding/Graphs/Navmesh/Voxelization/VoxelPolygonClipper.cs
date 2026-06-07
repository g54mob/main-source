using Unity.Burst;

namespace Pathfinding.Graphs.Navmesh.Voxelization
{
	internal struct VoxelPolygonClipper
	{
		public unsafe fixed float x[8];

		public unsafe fixed float y[8];

		public unsafe fixed float z[8];

		public int n;

		public int this[int i]
		{
			set
			{
			}
		}

		public void ClipPolygonAlongX([NoAlias] ref VoxelPolygonClipper result, float multi, float offset)
		{
		}

		public void ClipPolygonAlongZWithYZ([NoAlias] ref VoxelPolygonClipper result, float multi, float offset)
		{
		}

		public void ClipPolygonAlongZWithY([NoAlias] ref VoxelPolygonClipper result, float multi, float offset)
		{
		}
	}
}
