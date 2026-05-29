using System.Runtime.InteropServices;
using Unity.Collections;

namespace Pathfinding.Graphs.Grid
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct LayeredGridAdjacencyMapper : GridAdjacencyMapper
	{
		public int LayerCount(IntBounds bounds)
		{
			return bounds.size.y;
		}

		public int GetNeighbourIndex(int nodeIndexXZ, int nodeIndex, int direction, NativeArray<ulong> nodeConnections, NativeArray<int> neighbourOffsets, int layerStride)
		{
			return nodeIndexXZ + neighbourOffsets[direction] + (int)((nodeConnections[nodeIndex] >> 4 * direction) & 0xF) * layerStride;
		}

		public bool HasConnection(int nodeIndex, int direction, NativeArray<ulong> nodeConnections)
		{
			return ((nodeConnections[nodeIndex] >> 4 * direction) & 0xF) != 15;
		}
	}
}
