using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct GetSurfaceChunksJob : IJobParallelFor
	{
		public int SizeVox;

		public float HeightmapScaleY;

		public int SizeOfMesh;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> Heights;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> Holes;

		[NativeDisableParallelForRestriction]
		public NativeParallelHashSet<int>.ParallelWriter ChunkOnSurfaceY;

		public void Execute(int index)
		{
			int3 pi = Utils.HoleIndexToXZ(index, SizeVox);
			if (Utils.IsOnHole(pi, SizeVox, Holes))
			{
				int item = RoundingDownDivision((int)(Heights[Utils.XYZToHeightIndex(pi, SizeVox)] / HeightmapScaleY) - 1, SizeOfMesh);
				ChunkOnSurfaceY.Add(item);
			}
		}

		private static int RoundingDownDivision(int a, int b)
		{
			int num = a / b;
			if (a >= 0 || a == b * num)
			{
				return num;
			}
			return num - 1;
		}
	}
}
