using Beans.Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct RecalculateBoundsJob : IJob
	{
		public NativeArray<bounds> bounds;

		public NativeArray<float3> vertices;

		public void Execute()
		{
			float num = float.PositiveInfinity;
			float num2 = float.PositiveInfinity;
			float num3 = float.PositiveInfinity;
			float num4 = float.NegativeInfinity;
			float num5 = float.NegativeInfinity;
			float num6 = float.NegativeInfinity;
			int length = vertices.Length;
			for (int i = 0; i < length; i++)
			{
				float3 float5 = vertices[i];
				if (float5.x < num)
				{
					num = float5.x;
				}
				if (float5.y < num2)
				{
					num2 = float5.y;
				}
				if (float5.z < num3)
				{
					num3 = float5.z;
				}
				if (float5.x > num4)
				{
					num4 = float5.x;
				}
				if (float5.y > num5)
				{
					num5 = float5.y;
				}
				if (float5.z > num6)
				{
					num6 = float5.z;
				}
			}
			bounds value = new bounds
			{
				min = math.float3(num, num2, num3),
				max = math.float3(num4, num5, num6)
			};
			bounds[0] = value;
		}
	}
}
