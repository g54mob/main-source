using Pathfinding.Jobs;
using Unity.Collections;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct VoxelMesh : IArenaDisposable
	{
		public NativeList<Int3> verts;

		public NativeList<int> tris;

		public NativeList<int> areas;

		void IArenaDisposable.DisposeWith(DisposeArena arena)
		{
			arena.Add(verts);
			arena.Add(tris);
			arena.Add(areas);
		}
	}
}
