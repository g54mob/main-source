using System.Runtime.InteropServices;
using Pathfinding.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	public struct JobWriteNodeData : IJobParallelForBatched
	{
		public GCHandle nodesHandle;

		public uint graphIndex;

		public int3 nodeArrayBounds;

		public IntBounds dataBounds;

		public IntBounds writeMask;

		[ReadOnly]
		public NativeArray<Vector3> nodePositions;

		[ReadOnly]
		public NativeArray<uint> nodePenalties;

		[ReadOnly]
		public NativeArray<int> nodeTags;

		[ReadOnly]
		public NativeArray<ulong> nodeConnections;

		[ReadOnly]
		public NativeArray<bool> nodeWalkableWithErosion;

		[ReadOnly]
		public NativeArray<bool> nodeWalkable;

		public bool allowBoundsChecks => false;

		public void Execute(int startIndex, int count)
		{
		}
	}
}
