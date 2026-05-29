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
				if (outerIdx < nodes.Length)
				{
					GridNodeBase gridNodeBase = nodes[outerIdx];
					if (gridNodeBase != null)
					{
						nodePositions[(int)innerIdx] = (Vector3)gridNodeBase.position;
						nodePenalties[(int)innerIdx] = gridNodeBase.Penalty;
						nodeTags[(int)innerIdx] = (int)gridNodeBase.Tag;
						nodeConnections[(int)innerIdx] = ((gridNodeBase is GridNode gridNode) ? ((ulong)gridNode.GetAllConnectionInternal()) : ((ulong)(gridNodeBase as LevelGridNode).gridConnections));
						nodeWalkableWithErosion[(int)innerIdx] = gridNodeBase.Walkable;
						nodeWalkable[(int)innerIdx] = gridNodeBase.WalkableErosion;
						return;
					}
				}
				nodePositions[(int)innerIdx] = Vector3.zero;
				nodePenalties[(int)innerIdx] = 0u;
				nodeTags[(int)innerIdx] = 0;
				nodeConnections[(int)innerIdx] = 0uL;
				nodeWalkableWithErosion[(int)innerIdx] = false;
				nodeWalkable[(int)innerIdx] = false;
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
			Reader action = new Reader
			{
				nodes = (GridNodeBase[])nodesHandle.Target,
				nodePositions = nodePositions,
				nodePenalties = nodePenalties,
				nodeTags = nodeTags,
				nodeConnections = nodeConnections,
				nodeWalkableWithErosion = nodeWalkableWithErosion,
				nodeWalkable = nodeWalkable
			};
			GridIterationUtilities.ForEachCellIn3DSlice(slice, ref action);
		}
	}
}
