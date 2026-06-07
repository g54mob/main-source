using Pathfinding.Jobs;
using Unity.Collections;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	public struct LinkedVoxelField : IArenaDisposable
	{
		public const uint MaxHeight = 65536u;

		public const int MaxHeightInt = 65536;

		public const uint InvalidSpanValue = uint.MaxValue;

		public const float AvgSpanLayerCountEstimate = 8f;

		public int width;

		public int depth;

		public int height;

		public bool flatten;

		public NativeList<LinkedVoxelSpan> linkedSpans;

		private NativeList<int> removedStack;

		private NativeList<CellMinMax> linkedCellMinMax;

		public LinkedVoxelField(int width, int depth, int height)
		{
			this.width = 0;
			this.depth = 0;
			this.height = 0;
			flatten = false;
			linkedSpans = default(NativeList<LinkedVoxelSpan>);
			removedStack = default(NativeList<int>);
			linkedCellMinMax = default(NativeList<CellMinMax>);
		}

		void IArenaDisposable.DisposeWith(DisposeArena arena)
		{
		}

		public void ResetLinkedVoxelSpans()
		{
		}

		private void PushToSpanRemovedStack(int index)
		{
		}

		public int GetSpanCount()
		{
			return 0;
		}

		public void ResolveSolid(int index, int objectID, int voxelWalkableClimb)
		{
		}

		public void SetWalkableBackground()
		{
		}

		public void AddFlattenedSpan(int index, int area)
		{
		}

		public void AddLinkedSpan(int index, int bottom, int top, int area, int voxelWalkableClimb, int objectID)
		{
		}
	}
}
