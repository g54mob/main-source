using System.Runtime.InteropServices;
using Unity.Collections;

namespace Pathfinding.Graphs.Grid
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct LayeredGridAdjacencyMapper : GridAdjacencyMapper
	{
		public int LayerCount(IntBounds bounds)
		{
			return 0;
		}

		public int GetNeighbourIndex(int nodeIndexXZ, int nodeIndex, int direction, NativeArray<ulong> nodeConnections, NativeArray<int> neighbourOffsets, int layerStride)
		{
			return 0;
		}

		public bool HasConnection(int nodeIndex, int direction, NativeArray<ulong> nodeConnections)
		{
			return false;
		}
	}
}
