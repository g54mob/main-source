using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Pathfinding.Jobs
{
	[BurstCompile]
	public struct JobRotate3DArray<T> : IJob where T : struct
	{
		public NativeArray<T> arr;

		public int3 size;

		public int dx;

		public int dz;

		public void Execute()
		{
		}
	}
}
