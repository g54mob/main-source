using Pathfinding.Jobs;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Grid
{
	public static class GridIterationUtilities
	{
		public interface ISliceAction
		{
			void Execute(uint outerIdx, uint innerIdx);
		}

		public interface ISliceActionWithCoords
		{
			void Execute(uint outerIdx, uint innerIdx, int3 innerCoords);
		}

		public interface ICellAction
		{
			void Execute(uint idx, int x, int y, int z);
		}

		public interface INodeModifier
		{
			void ModifyNode(int dataIndex, int dataX, int dataLayer, int dataZ);
		}

		public interface IConnectionFilter
		{
			bool IsValidConnection(int dataIndex, int dataX, int dataLayer, int dataZ, int direction, int neighbourDataIndex);
		}

		public static void ForEachCellIn3DSlice<T>(Slice3D slice, ref T action) where T : struct, ISliceAction
		{
		}

		public static void ForEachCellIn3DSliceWithCoords<T>(Slice3D slice, ref T action) where T : struct, ISliceActionWithCoords
		{
		}

		public static void ForEachCellIn3DArray<T>(int3 size, ref T action) where T : struct, ICellAction
		{
		}

		public static void ForEachNode<T>(int3 arrayBounds, NativeArray<float4> nodeNormals, ref T callback) where T : struct, INodeModifier
		{
		}

		public static void FilterNodeConnections<T>(IntBounds bounds, NativeArray<ulong> nodeConnections, bool layeredDataLayout, ref T filter) where T : struct, IConnectionFilter
		{
		}

		public static int? GetNeighbourDataIndex(IntBounds bounds, NativeArray<ulong> nodeConnections, bool layeredDataLayout, int dataX, int dataLayer, int dataZ, int direction)
		{
			return null;
		}
	}
}
