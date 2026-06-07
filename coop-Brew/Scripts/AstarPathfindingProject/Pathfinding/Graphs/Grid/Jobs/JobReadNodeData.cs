using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pathfinding.Jobs;
using Unity.Collections;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	public struct JobReadNodeData : IJobParallelForBatched
	{
		private struct Reader : GridIterationUtilities.ISliceAction
		{
			public GridNodeBase[] nodes;

			public NativeArray<Vector3> nodePositions;

			public NativeArray<uint> nodePenalties;

			public NativeArray<int> nodeTags;

			public NativeArray<ulong> nodeConnections;

			public NativeArray<bool> nodeWalkableWithErosion;

			public NativeArray<bool> nodeWalkable;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Execute(uint outerIdx, uint innerIdx)
			{
			}
		}

		public GCHandle nodesHandle;

		public uint graphIndex;

		public Slice3D slice;

		[WriteOnly]
		public NativeArray<Vector3> nodePositions;

		[WriteOnly]
		public NativeArray<uint> nodePenalties;

		[WriteOnly]
		public NativeArray<int> nodeTags;

		[WriteOnly]
		public NativeArray<ulong> nodeConnections;

		[WriteOnly]
		public NativeArray<bool> nodeWalkableWithErosion;

		[WriteOnly]
		public NativeArray<bool> nodeWalkable;

		public bool allowBoundsChecks => false;

		public void Execute(int startIndex, int count)
		{
		}
	}
}
