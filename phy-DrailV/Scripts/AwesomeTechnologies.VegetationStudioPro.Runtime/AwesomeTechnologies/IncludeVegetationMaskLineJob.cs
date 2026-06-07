using AwesomeTechnologies.Utility;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies
{
	[BurstCompile(CompileSynchronously = true)]
	public struct IncludeVegetationMaskLineJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float3> Position;

		public NativeArray<float> VegetationMaskScale;

		public NativeArray<float> VegetationMaskDensity;

		public float Denisty;

		public float Scale;

		public LineSegment2D LineSegment2D;

		public float Width;

		public void Execute(int index)
		{
			if (Excluded[index] != 1 && LineSegment2Dextention.DistanceToPoint(point: new Vector2(Position[index].x, Position[index].z), lineSegment: LineSegment2D) < Width / 2f)
			{
				VegetationMaskScale[index] = math.max(VegetationMaskScale[index], Scale);
				VegetationMaskDensity[index] = math.max(VegetationMaskDensity[index], Denisty);
			}
		}
	}
}
