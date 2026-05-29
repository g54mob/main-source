using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	internal static class VoxelUtilityBurst
	{
		public const int TagRegMask = 16383;

		public const int TagReg = 16384;

		public const ushort BorderReg = 32768;

		public const int RC_BORDER_VERTEX = 65536;

		public const int RC_AREA_BORDER = 131072;

		public const int VERTEX_BUCKET_COUNT = 4096;

		public const int RC_CONTOUR_TESS_WALL_EDGES = 1;

		public const int RC_CONTOUR_TESS_AREA_EDGES = 2;

		public const int RC_CONTOUR_TESS_TILE_EDGES = 4;

		public const int ContourRegMask = 65535;

		public static readonly int[] DX = new int[4] { -1, 0, 1, 0 };

		public static readonly int[] DZ = new int[4] { 0, 1, 0, -1 };

		public static void CalculateDistanceField(CompactVoxelField field, NativeArray<ushort> output)
		{
			int num = field.width * field.depth;
			for (int i = 0; i < num; i += field.width)
			{
				for (int j = 0; j < field.width; j++)
				{
					CompactVoxelCell compactVoxelCell = field.cells[j + i];
					int k = compactVoxelCell.index;
					for (int num2 = compactVoxelCell.index + compactVoxelCell.count; k < num2; k++)
					{
						CompactVoxelSpan compactVoxelSpan = field.spans[k];
						int num3 = 0;
						for (int l = 0; l < 4 && (long)compactVoxelSpan.GetConnection(l) != 63; l++)
						{
							num3++;
						}
						output[k] = (ushort)((num3 == 4) ? ushort.MaxValue : 0);
					}
				}
			}
			for (int m = 0; m < num; m += field.width)
			{
				for (int n = 0; n < field.width; n++)
				{
					int index = n + m;
					CompactVoxelCell compactVoxelCell2 = field.cells[index];
					int num4 = compactVoxelCell2.index;
					for (int num5 = compactVoxelCell2.index + compactVoxelCell2.count; num4 < num5; num4++)
					{
						CompactVoxelSpan compactVoxelSpan2 = field.spans[num4];
						int num6 = output[num4];
						if ((long)compactVoxelSpan2.GetConnection(0) != 63)
						{
							int neighbourIndex = field.GetNeighbourIndex(index, 0);
							int index2 = field.cells[neighbourIndex].index + compactVoxelSpan2.GetConnection(0);
							num6 = math.min(num6, output[index2] + 2);
							CompactVoxelSpan compactVoxelSpan3 = field.spans[index2];
							if ((long)compactVoxelSpan3.GetConnection(3) != 63)
							{
								int neighbourIndex2 = field.GetNeighbourIndex(neighbourIndex, 3);
								int index3 = field.cells[neighbourIndex2].index + compactVoxelSpan3.GetConnection(3);
								num6 = math.min(num6, output[index3] + 3);
							}
						}
						if ((long)compactVoxelSpan2.GetConnection(3) != 63)
						{
							int neighbourIndex3 = field.GetNeighbourIndex(index, 3);
							int index4 = field.cells[neighbourIndex3].index + compactVoxelSpan2.GetConnection(3);
							num6 = math.min(num6, output[index4] + 2);
							CompactVoxelSpan compactVoxelSpan4 = field.spans[index4];
							if ((long)compactVoxelSpan4.GetConnection(2) != 63)
							{
								int neighbourIndex4 = field.GetNeighbourIndex(neighbourIndex3, 2);
								int index5 = field.cells[neighbourIndex4].index + compactVoxelSpan4.GetConnection(2);
								num6 = math.min(num6, output[index5] + 3);
							}
						}
						output[num4] = (ushort)num6;
					}
				}
			}
			for (int num7 = num - field.width; num7 >= 0; num7 -= field.width)
			{
				for (int num8 = field.width - 1; num8 >= 0; num8--)
				{
					int index6 = num8 + num7;
					CompactVoxelCell compactVoxelCell3 = field.cells[index6];
					int num9 = compactVoxelCell3.index;
					for (int num10 = compactVoxelCell3.index + compactVoxelCell3.count; num9 < num10; num9++)
					{
						CompactVoxelSpan compactVoxelSpan5 = field.spans[num9];
						int num11 = output[num9];
						if ((long)compactVoxelSpan5.GetConnection(2) != 63)
						{
							int neighbourIndex5 = field.GetNeighbourIndex(index6, 2);
							int index7 = field.cells[neighbourIndex5].index + compactVoxelSpan5.GetConnection(2);
							num11 = math.min(num11, output[index7] + 2);
							CompactVoxelSpan compactVoxelSpan6 = field.spans[index7];
							if ((long)compactVoxelSpan6.GetConnection(1) != 63)
							{
								int neighbourIndex6 = field.GetNeighbourIndex(neighbourIndex5, 1);
								int index8 = field.cells[neighbourIndex6].index + compactVoxelSpan6.GetConnection(1);
								num11 = math.min(num11, output[index8] + 3);
							}
						}
						if ((long)compactVoxelSpan5.GetConnection(1) != 63)
						{
							int neighbourIndex7 = field.GetNeighbourIndex(index6, 1);
							int index9 = field.cells[neighbourIndex7].index + compactVoxelSpan5.GetConnection(1);
							num11 = math.min(num11, output[index9] + 2);
							CompactVoxelSpan compactVoxelSpan7 = field.spans[index9];
							if ((long)compactVoxelSpan7.GetConnection(0) != 63)
							{
								int neighbourIndex8 = field.GetNeighbourIndex(neighbourIndex7, 0);
								int index10 = field.cells[neighbourIndex8].index + compactVoxelSpan7.GetConnection(0);
								num11 = math.min(num11, output[index10] + 3);
							}
						}
						output[num9] = (ushort)num11;
					}
				}
			}
		}

		public static void BoxBlur(CompactVoxelField field, NativeArray<ushort> src, NativeArray<ushort> dst)
		{
			ushort num = 20;
			for (int num2 = field.width * field.depth - field.width; num2 >= 0; num2 -= field.width)
			{
				for (int num3 = field.width - 1; num3 >= 0; num3--)
				{
					int index = num3 + num2;
					CompactVoxelCell compactVoxelCell = field.cells[index];
					int i = compactVoxelCell.index;
					for (int num4 = compactVoxelCell.index + compactVoxelCell.count; i < num4; i++)
					{
						CompactVoxelSpan compactVoxelSpan = field.spans[i];
						ushort num5 = src[i];
						if (num5 < num)
						{
							dst[i] = num5;
							continue;
						}
						int num6 = num5;
						for (int j = 0; j < 4; j++)
						{
							if ((long)compactVoxelSpan.GetConnection(j) != 63)
							{
								int neighbourIndex = field.GetNeighbourIndex(index, j);
								int index2 = field.cells[neighbourIndex].index + compactVoxelSpan.GetConnection(j);
								num6 += src[index2];
								CompactVoxelSpan compactVoxelSpan2 = field.spans[index2];
								int num7 = (j + 1) & 3;
								if ((long)compactVoxelSpan2.GetConnection(num7) != 63)
								{
									int neighbourIndex2 = field.GetNeighbourIndex(neighbourIndex, num7);
									int index3 = field.cells[neighbourIndex2].index + compactVoxelSpan2.GetConnection(num7);
									num6 += src[index3];
								}
								else
								{
									num6 += num5;
								}
							}
							else
							{
								num6 += num5 * 2;
							}
						}
						dst[i] = (ushort)((float)(num6 + 5) / 9f);
					}
				}
			}
		}
	}
}
