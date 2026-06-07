using UnityEngine;

namespace Pathfinding.Voxels
{
	public class VoxelArea
	{
		public const uint MaxHeight = 65536u;

		public const int MaxHeightInt = 65536;

		public const uint InvalidSpanValue = uint.MaxValue;

		public const float AvgSpanLayerCountEstimate = 8f;

		public readonly int width;

		public readonly int depth;

		public CompactVoxelSpan[] compactSpans;

		public CompactVoxelCell[] compactCells;

		public int compactSpanCount;

		public ushort[] tmpUShortArr;

		public int[] areaTypes;

		public ushort[] dist;

		public ushort maxDistance;

		public int maxRegions;

		public int[] DirectionX;

		public int[] DirectionZ;

		public Vector3[] VectorDirection;

		private int linkedSpanCount;

		public LinkedVoxelSpan[] linkedSpans;

		private int[] removedStack;

		private int removedStackCount;

		public void Reset()
		{
		}

		private void ResetLinkedVoxelSpans()
		{
		}

		public VoxelArea(int width, int depth)
		{
		}

		public int GetSpanCountAll()
		{
			return 0;
		}

		public int GetSpanCount()
		{
			return 0;
		}

		private void PushToSpanRemovedStack(int index)
		{
		}

		public void AddLinkedSpan(int index, uint bottom, uint top, int area, int voxelWalkableClimb)
		{
		}
	}
}
