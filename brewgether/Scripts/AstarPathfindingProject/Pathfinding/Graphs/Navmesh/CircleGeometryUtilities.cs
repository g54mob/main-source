using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct CircleGeometryUtilities
	{
		private static readonly float[] circleRadiusAdjustmentFactors;

		public static int CircleSteps(Matrix4x4 matrix, float radius, float maxError)
		{
			return 0;
		}

		[GenerateTestsForBurstCompatibility]
		public static float CircleRadiusAdjustmentFactor(int steps)
		{
			return 0f;
		}
	}
}
