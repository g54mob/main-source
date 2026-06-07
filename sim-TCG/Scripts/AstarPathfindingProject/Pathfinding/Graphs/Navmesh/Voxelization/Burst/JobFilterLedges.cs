using Pathfinding.Util;
using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobFilterLedges : IJob
	{
		public LinkedVoxelField field;

		public uint voxelWalkableHeight;

		public int voxelWalkableClimb;

		public float cellSize;

		public float cellHeight;

		public void Execute()
		{
			UnsafeSpan<LinkedVoxelSpan> unsafeSpan = field.linkedSpans.AsUnsafeSpan();
			int num = field.width * field.depth;
			int width = field.width;
			int num2 = 0;
			int num3 = 0;
			while (num2 < num)
			{
				for (int i = 0; i < width; i++)
				{
					if (unsafeSpan[i + num2].bottom == uint.MaxValue)
					{
						continue;
					}
					for (int num4 = i + num2; num4 != -1; num4 = unsafeSpan[num4].next)
					{
						if (unsafeSpan[num4].area != 0)
						{
							if (i == 0 || num2 == 0 || num2 == num - width || i == width - 1)
							{
								unsafeSpan[num4].area = 0;
							}
							else
							{
								int top = (int)unsafeSpan[num4].top;
								int num5 = (int)((unsafeSpan[num4].next != -1) ? unsafeSpan[unsafeSpan[num4].next].bottom : 65536);
								int num6 = 65536;
								int num7 = (int)unsafeSpan[num4].top;
								int num8 = num7;
								for (int j = 0; j < 4; j++)
								{
									int num9 = i + VoxelUtilityBurst.DX[j];
									int num10 = num2 + VoxelUtilityBurst.DZ[j] * width;
									int num11 = num9 + num10;
									int num12 = -voxelWalkableClimb;
									int y = (int)((unsafeSpan[num11].bottom != uint.MaxValue) ? unsafeSpan[num11].bottom : 65536);
									if (math.min(num5, y) - math.max(top, num12) > voxelWalkableHeight)
									{
										num6 = math.min(num6, num12 - top);
									}
									if (unsafeSpan[num11].bottom == uint.MaxValue)
									{
										continue;
									}
									for (int num13 = num11; num13 != -1; num13 = unsafeSpan[num13].next)
									{
										ref LinkedVoxelSpan reference = ref unsafeSpan[num13];
										num12 = (int)reference.top;
										if (num12 > num5 - voxelWalkableHeight)
										{
											break;
										}
										y = (int)((reference.next != -1) ? unsafeSpan[reference.next].bottom : 65536);
										if (math.min(num5, y) - math.max(top, num12) > voxelWalkableHeight)
										{
											num6 = math.min(num6, num12 - top);
											if (math.abs(num12 - top) <= voxelWalkableClimb)
											{
												if (num12 < num7)
												{
													num7 = num12;
												}
												if (num12 > num8)
												{
													num8 = num12;
												}
											}
										}
									}
								}
								if (num6 < -voxelWalkableClimb || num8 - num7 > voxelWalkableClimb)
								{
									unsafeSpan[num4].area = 0;
								}
							}
						}
					}
				}
				num2 += width;
				num3++;
			}
		}
	}
}
