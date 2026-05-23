using System;
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
			int3 size = slice.slice.size;
			(int, int, int) outerStrides = slice.outerStrides;
			int item = outerStrides.Item2;
			int item2 = outerStrides.Item3;
			int outerStartIndex = slice.outerStartIndex;
			uint num = 0u;
			for (int i = 0; i < size.y; i++)
			{
				for (int j = 0; j < size.z; j++)
				{
					int num2 = i * item + j * item2 + outerStartIndex;
					int num3 = 0;
					while (num3 < size.x)
					{
						action.Execute((uint)(num2 + num3), num);
						num3++;
						num++;
					}
				}
			}
		}

		public static void ForEachCellIn3DSliceWithCoords<T>(Slice3D slice, ref T action) where T : struct, ISliceActionWithCoords
		{
			int3 size = slice.slice.size;
			(int, int, int) outerStrides = slice.outerStrides;
			int item = outerStrides.Item2;
			int item2 = outerStrides.Item3;
			int outerStartIndex = slice.outerStartIndex;
			uint num = (uint)(size.x * size.y * size.z - 1);
			for (int num2 = size.y - 1; num2 >= 0; num2--)
			{
				for (int num3 = size.z - 1; num3 >= 0; num3--)
				{
					int num4 = num2 * item + num3 * item2 + outerStartIndex;
					int num5 = size.x - 1;
					while (num5 >= 0)
					{
						action.Execute((uint)(num4 + num5), num, new int3(num5, num2, num3));
						num5--;
						num--;
					}
				}
			}
		}

		public static void ForEachCellIn3DArray<T>(int3 size, ref T action) where T : struct, ICellAction
		{
			uint num = (uint)(size.x * size.y * size.z - 1);
			for (int num2 = size.y - 1; num2 >= 0; num2--)
			{
				for (int num3 = size.z - 1; num3 >= 0; num3--)
				{
					int num4 = size.x - 1;
					while (num4 >= 0)
					{
						action.Execute(num, num4, num2, num3);
						num4--;
						num--;
					}
				}
			}
		}

		public static void ForEachNode<T>(int3 arrayBounds, NativeArray<float4> nodeNormals, ref T callback) where T : struct, INodeModifier
		{
			int num = 0;
			for (int i = 0; i < arrayBounds.y; i++)
			{
				for (int j = 0; j < arrayBounds.z; j++)
				{
					int num2 = 0;
					while (num2 < arrayBounds.x)
					{
						if (math.any(nodeNormals[num]))
						{
							callback.ModifyNode(num, num2, i, j);
						}
						num2++;
						num++;
					}
				}
			}
		}

		public unsafe static void FilterNodeConnections<T>(IntBounds bounds, NativeArray<ulong> nodeConnections, bool layeredDataLayout, ref T filter) where T : struct, IConnectionFilter
		{
			int3 size = bounds.size;
			int* ptr = stackalloc int[8];
			for (int i = 0; i < 8; i++)
			{
				ptr[i] = GridGraph.neighbourZOffsets[i] * size.x + GridGraph.neighbourXOffsets[i];
			}
			int num = size.x * size.z;
			int num2 = 0;
			for (int j = 0; j < size.y; j++)
			{
				for (int k = 0; k < size.z; k++)
				{
					int num3 = 0;
					while (num3 < size.x)
					{
						ulong num4 = nodeConnections[num2];
						if (layeredDataLayout)
						{
							for (int l = 0; l < 8; l++)
							{
								int num5 = (int)((num4 >> 4 * l) & 0xF);
								if (num5 != 15 && !filter.IsValidConnection(num2, num3, j, k, l, num2 + ptr[l] + (num5 - j) * num))
								{
									num4 |= (ulong)(15L << 4 * l);
								}
							}
						}
						else
						{
							for (int m = 0; m < 8; m++)
							{
								if (((int)num4 & (1 << m)) != 0 && !filter.IsValidConnection(num2, num3, j, k, m, num2 + ptr[m]))
								{
									num4 &= (ulong)(~(1L << m));
								}
							}
						}
						nodeConnections[num2] = num4;
						num3++;
						num2++;
					}
				}
			}
		}

		public static int? GetNeighbourDataIndex(IntBounds bounds, NativeArray<ulong> nodeConnections, bool layeredDataLayout, int dataX, int dataLayer, int dataZ, int direction)
		{
			int num = GridGraph.neighbourXOffsets[direction];
			int num2 = GridGraph.neighbourZOffsets[direction];
			int num3 = dataX + num;
			int num4 = dataZ + num2;
			int x = bounds.size.x;
			int num5 = bounds.size.x * bounds.size.z;
			int index = dataLayer * num5 + dataZ * x + dataX;
			int num6 = num4 * x + num3;
			if (layeredDataLayout)
			{
				ulong num7 = (nodeConnections[index] >> 4 * direction) & 0xF;
				if (num7 == 15)
				{
					return null;
				}
				if (num3 < 0 || num4 < 0 || num3 >= bounds.size.x || num4 >= bounds.size.z)
				{
					throw new Exception("Node has an invalid connection to a node outside the bounds of the graph");
				}
				num6 += (int)num7 * num5;
			}
			else if ((nodeConnections[index] & (ulong)(1L << direction)) == 0L)
			{
				return null;
			}
			if (num3 < 0 || num4 < 0 || num3 >= bounds.size.x || num4 >= bounds.size.z)
			{
				throw new Exception("Node has an invalid connection to a node outside the bounds of the graph");
			}
			return num6;
		}
	}
}
