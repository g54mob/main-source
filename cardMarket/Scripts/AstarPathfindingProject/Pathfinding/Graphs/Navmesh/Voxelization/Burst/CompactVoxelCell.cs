namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct CompactVoxelCell
	{
		public int index;

		public int count;

		public CompactVoxelCell(int i, int c)
		{
			index = i;
			count = c;
		}
	}
}
