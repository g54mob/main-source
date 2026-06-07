using System.Runtime.InteropServices;
using Unity.Collections;

namespace Pathfinding.Graphs.Grid
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct FlatGridAdjacencyMapper : GridAdjacencyMapper
	{
		public int LayerCount(IntBounds bounds)
		{
			return 1;
		}

		public int GetNeighbourIndex(int nodeIndexXZ, int nodeIndex, int direction, NativeArray<ulong> nodeConnections, NativeArray<int> neighbourOffsets, int layerStride)
		{
			return nodeIndex + neighbourOffsets[direction];
		}

		public bool HasConnection(int nodeIndex, int direction, NativeArray<ulong> nodeConnections)
		{
			return ((nodeConnections[nodeIndex] >> direction) & 1) != 0;
		}
	}
}
