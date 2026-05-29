namespace Pathfinding.Voxels
{
	public struct CompactVoxelSpan
	{
		public ushort y;

		public uint con;

		public uint h;

		public int reg;

		public CompactVoxelSpan(ushort bottom, uint height)
		{
			y = 0;
			con = 0u;
			h = 0u;
			reg = 0;
		}

		public void SetConnection(int dir, uint value)
		{
		}

		public int GetConnection(int dir)
		{
			return 0;
		}
	}
}
