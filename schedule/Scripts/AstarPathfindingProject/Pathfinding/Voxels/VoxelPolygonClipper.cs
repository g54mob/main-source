namespace Pathfinding.Voxels
{
	internal struct VoxelPolygonClipper
	{
		public float[] x;

		public float[] y;

		public float[] z;

		public int n;

		public int this[int i]
		{
			set
			{
			}
		}

		public VoxelPolygonClipper(int capacity)
		{
			x = null;
			y = null;
			z = null;
			n = 0;
		}

		public void ClipPolygonAlongX(ref VoxelPolygonClipper result, float multi, float offset)
		{
		}

		public void ClipPolygonAlongZWithYZ(ref VoxelPolygonClipper result, float multi, float offset)
		{
		}

		public void ClipPolygonAlongZWithY(ref VoxelPolygonClipper result, float multi, float offset)
		{
		}
	}
}
