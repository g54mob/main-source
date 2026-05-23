using System;
using Unity.Burst;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobBuildConnections : IJob
	{
		public CompactVoxelField field;

		public int voxelWalkableHeight;

		public int voxelWalkableClimb;

		public void Execute()
		{
			int num = field.width * field.depth;
			int num2 = 0;
			int num3 = 0;
			while (num2 < num)
			{
				for (int i = 0; i < field.width; i++)
				{
					CompactVoxelCell compactVoxelCell = field.cells[i + num2];
					int j = compactVoxelCell.index;
					for (int num4 = compactVoxelCell.index + compactVoxelCell.count; j < num4; j++)
					{
						CompactVoxelSpan value = field.spans[j];
						value.con = uint.MaxValue;
						for (int k = 0; k < 4; k++)
						{
							int num5 = i + VoxelUtilityBurst.DX[k];
							int num6 = num2 + VoxelUtilityBurst.DZ[k] * field.width;
							if (num5 < 0 || num6 < 0 || num6 >= num || num5 >= field.width)
							{
								continue;
							}
							CompactVoxelCell compactVoxelCell2 = field.cells[num5 + num6];
							int l = compactVoxelCell2.index;
							for (int num7 = compactVoxelCell2.index + compactVoxelCell2.count; l < num7; l++)
							{
								CompactVoxelSpan compactVoxelSpan = field.spans[l];
								int num8 = Math.Max(value.y, compactVoxelSpan.y);
								if (Math.Min((int)(value.y + value.h), (int)(compactVoxelSpan.y + compactVoxelSpan.h)) - num8 >= voxelWalkableHeight && Math.Abs(compactVoxelSpan.y - value.y) <= voxelWalkableClimb)
								{
									uint num9 = (uint)(l - compactVoxelCell2.index);
									if (num9 <= 65535)
									{
										value.SetConnection(k, num9);
									}
									break;
								}
							}
						}
						field.spans[j] = value;
					}
				}
				num2 += field.width;
				num3++;
			}
		}
	}
}
