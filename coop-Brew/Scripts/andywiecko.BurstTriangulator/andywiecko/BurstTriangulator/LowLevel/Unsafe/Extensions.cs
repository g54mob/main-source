using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	public static class Extensions
	{
		public static void Triangulate(this UnsafeTriangulator @this, InputData<double2> input, OutputData<double2> output, Args args, Allocator allocator)
		{
		}

		public static void PlantHoleSeeds(this UnsafeTriangulator @this, InputData<double2> input, OutputData<double2> output, Args args, Allocator allocator)
		{
		}

		public static void RefineMesh(this UnsafeTriangulator @this, OutputData<double2> output, Allocator allocator, double areaThreshold = 1.0, double angleThreshold = 0.0872664626, bool constrainBoundary = false)
		{
		}

		public static void Triangulate(this UnsafeTriangulator<float2> @this, InputData<float2> input, OutputData<float2> output, Args args, Allocator allocator)
		{
		}

		public static void PlantHoleSeeds(this UnsafeTriangulator<float2> @this, InputData<float2> input, OutputData<float2> output, Args args, Allocator allocator)
		{
		}

		public static void RefineMesh(this UnsafeTriangulator<float2> @this, OutputData<float2> output, Allocator allocator, float areaThreshold = 1f, float angleThreshold = 0.08726646f, bool constrainBoundary = false)
		{
		}

		public static void Triangulate(this UnsafeTriangulator<Vector2> @this, InputData<Vector2> input, OutputData<Vector2> output, Args args, Allocator allocator)
		{
		}

		public static void PlantHoleSeeds(this UnsafeTriangulator<Vector2> @this, InputData<Vector2> input, OutputData<Vector2> output, Args args, Allocator allocator)
		{
		}

		public static void RefineMesh(this UnsafeTriangulator<Vector2> @this, OutputData<Vector2> output, Allocator allocator, float areaThreshold = 1f, float angleThreshold = 0.08726646f, bool constrainBoundary = false)
		{
		}

		public static void Triangulate(this UnsafeTriangulator<double2> @this, InputData<double2> input, OutputData<double2> output, Args args, Allocator allocator)
		{
		}

		public static void PlantHoleSeeds(this UnsafeTriangulator<double2> @this, InputData<double2> input, OutputData<double2> output, Args args, Allocator allocator)
		{
		}

		public static void RefineMesh(this UnsafeTriangulator<double2> @this, OutputData<double2> output, Allocator allocator, double areaThreshold = 1.0, double angleThreshold = 0.0872664626, bool constrainBoundary = false)
		{
		}

		public static void Triangulate(this UnsafeTriangulator<int2> @this, InputData<int2> input, OutputData<int2> output, Args args, Allocator allocator)
		{
		}

		public static void PlantHoleSeeds(this UnsafeTriangulator<int2> @this, InputData<int2> input, OutputData<int2> output, Args args, Allocator allocator)
		{
		}
	}
}
