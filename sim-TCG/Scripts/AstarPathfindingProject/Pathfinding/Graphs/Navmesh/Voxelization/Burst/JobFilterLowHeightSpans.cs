using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Pathfinding.Graphs.Navmesh.Voxelization.Burst
{
	[BurstCompile(CompileSynchronously = true)]
	internal struct JobFilterLowHeightSpans : IJob
	{
		public LinkedVoxelField field;

		public uint voxelWalkableHeight;

		public void Execute()
		{
			int num = field.width * field.depth;
			NativeList<LinkedVoxelSpan> linkedSpans = field.linkedSpans;
			int num2 = 0;
			int num3 = 0;
			while (num2 < num)
			{
				for (int i = 0; i < field.width; i++)
				{
					int num4 = num2 + i;
					while (num4 != -1 && linkedSpans[num4].bottom != uint.MaxValue)
					{
						uint top = linkedSpans[num4].top;
						if (((linkedSpans[num4].next != -1) ? linkedSpans[linkedSpans[num4].next].bottom : 65536) - top < voxelWalkableHeight)
						{
							LinkedVoxelSpan value = linkedSpans[num4];
							value.area = 0;
							linkedSpans[num4] = value;
						}
						num4 = linkedSpans[num4].next;
					}
				}
				num2 += field.width;
				num3++;
			}
		}
	}
}
