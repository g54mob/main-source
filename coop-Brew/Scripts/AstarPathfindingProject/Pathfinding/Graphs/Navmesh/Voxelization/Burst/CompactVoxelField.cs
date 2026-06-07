using Pathfinding.Jobs;
using Unity.Collections;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct CompactVoxelField : IArenaDisposable
	{
		public const int UnwalkableArea = 0;

		public const uint NotConnected = 63u;

		public readonly int voxelWalkableHeight;

		public readonly int width;

		public readonly int depth;

		public NativeList<CompactVoxelSpan> spans;

		public NativeList<CompactVoxelCell> cells;

		public NativeList<int> areaTypes;

		public const int MaxLayers = 65535;

		public CompactVoxelField(int width, int depth, int voxelWalkableHeight, Allocator allocator)
		{
			this.voxelWalkableHeight = 0;
			this.width = 0;
			this.depth = 0;
			spans = default(NativeList<CompactVoxelSpan>);
			cells = default(NativeList<CompactVoxelCell>);
			areaTypes = default(NativeList<int>);
		}

		void IArenaDisposable.DisposeWith(DisposeArena arena)
		{
		}

		public int GetNeighbourIndex(int index, int direction)
		{
			return 0;
		}

		public void BuildFromLinkedField(LinkedVoxelField field)
		{
		}
	}
}
