using AwesomeTechnologies.Utility;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies
{
	[BurstCompile(CompileSynchronously = true)]
	public struct SampleVegetatiomMaskLineJob : IJobParallelForDefer
	{
		public NativeArray<float3> Position;

		public NativeArray<byte> Excluded;

		public LineSegment2D LineSegment2D;

		public float AdditionalWidth;

		public float AdditionalWidthMax;

		public float NoiseScale;

		public float Width;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				Vector2 point = new Vector2(Position[index].x, Position[index].z);
				float num = noise.snoise(new float2(point.x / NoiseScale, point.y / NoiseScale));
				num += 1f;
				num /= 2f;
				num = math.clamp(num, 0f, 1f);
				float num2 = math.lerp(AdditionalWidth, AdditionalWidthMax, num);
				if (LineSegment2D.DistanceToPoint(point) < num2 + Width / 2f)
				{
					Excluded[index] = 1;
				}
			}
		}
	}
}
