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
			GridNodeBase[] array = (GridNodeBase[])nodesHandle.Target;
			IntBounds intBounds = writeMask.Offset(-dataBounds.min);
			int3 size = writeMask.size;
			int num = startIndex / (size.x * size.y);
			int num2 = (startIndex + count) / (size.x * size.y);
			intBounds.min.z = writeMask.min.z + num - dataBounds.min.z;
			intBounds.max.z = writeMask.min.z + num2 - dataBounds.min.z;
			int3 size2 = dataBounds.size;
			for (int i = intBounds.min.y; i < intBounds.max.y; i++)
			{
				for (int j = intBounds.min.z; j < intBounds.max.z; j++)
				{
					int num3 = (i * size2.z + j) * size2.x;
					int num4 = (j + dataBounds.min.z) * nodeArrayBounds.x + dataBounds.min.x;
					int num5 = (i + dataBounds.min.y) * nodeArrayBounds.z * nodeArrayBounds.x + num4;
					for (int k = intBounds.min.x; k < intBounds.max.x; k++)
					{
						int index = num3 + k;
						int num6 = num5 + k;
						GridNodeBase gridNodeBase = array[num6];
						if (gridNodeBase != null)
						{
							gridNodeBase.GraphIndex = graphIndex;
							gridNodeBase.NodeInGridIndex = num4 + k;
							gridNodeBase.position = (Int3)nodePositions[index];
							gridNodeBase.Penalty = nodePenalties[index];
							gridNodeBase.Tag = (uint)nodeTags[index];
							if (gridNodeBase is GridNode gridNode)
							{
								gridNode.SetAllConnectionInternal((int)nodeConnections[index]);
							}
							else if (gridNodeBase is LevelGridNode levelGridNode)
							{
								levelGridNode.LayerCoordinateInGrid = i + dataBounds.min.y;
								levelGridNode.SetAllConnectionInternal(nodeConnections[index]);
							}
							gridNodeBase.Walkable = nodeWalkableWithErosion[index];
							gridNodeBase.WalkableErosion = nodeWalkable[index];
						}
					}
				}
			}
		}
	}
}
