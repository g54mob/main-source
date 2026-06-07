using Unity.Collections;

namespace Pathfinding.Graphs.Grid
{
	public interface GridAdjacencyMapper
	{
		int LayerCount(IntBounds bounds);

		int GetNeighbourIndex(int nodeIndexXZ, int nodeIndex, int direction, NativeArray<ulong> nodeConnections, NativeArray<int> neighbourOffsets, int layerStride);

		bool HasConnection(int nodeIndex, int direction, NativeArray<ulong> nodeConnections);
	}
}
