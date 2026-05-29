using System;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	public struct CircleGeometryUtilities
	{
		private static readonly float[] circleRadiusAdjustmentFactors = new float[20]
		{
			1.56f, 1.25f, 1.15f, 1.1f, 1.07f, 1.05f, 1.04f, 1.03f, 1.03f, 1.02f,
			1.02f, 1.02f, 1.01f, 1.01f, 1.01f, 1.01f, 1.01f, 1.01f, 1.01f, 1.01f
		};

		public static int CircleSteps(Matrix4x4 matrix, float radius, float maxError)
		{
			float num = math.sqrt(math.max(math.max(math.lengthsq((Vector3)matrix.GetColumn(0)), math.lengthsq((Vector3)matrix.GetColumn(1))), math.lengthsq((Vector3)matrix.GetColumn(2))));
			float num2 = radius * num;
			float x = 1f - maxError / num2;
			return math.max(3, (int)math.ceil(MathF.PI / math.acos(x)));
		}

		public static float CircleRadiusAdjustmentFactor(int steps)
		{
			int num = steps - 3;
			if (num < circleRadiusAdjustmentFactors.Length)
			{
				if (num < 0)
				{
					throw new ArgumentOutOfRangeException("Steps must be at least 3");
				}
				return circleRadiusAdjustmentFactors[num];
			}
			return 1f;
		}
	}
}
