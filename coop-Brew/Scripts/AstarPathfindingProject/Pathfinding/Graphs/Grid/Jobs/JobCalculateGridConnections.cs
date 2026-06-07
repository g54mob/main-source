using Pathfinding.Collections;
using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Grid.Jobs
{
	[BurstCompile(FloatMode = FloatMode.Fast, CompileSynchronously = true)]
	public struct JobCalculateGridConnections : IJobParallelForBatched
	{
		public float maxStepHeight;

		public float4x4 graphToWorld;

		public IntBounds bounds;

		public int3 arrayBounds;

		public NumNeighbours neighbours;

		public float characterHeight;

		public bool use2D;

		public bool cutCorners;

		public bool maxStepUsesSlope;

		public bool layeredDataLayout;

		[ReadOnly]
		public UnsafeSpan<bool> nodeWalkable;

		[ReadOnly]
		public UnsafeSpan<float4> nodeNormals;

		[ReadOnly]
		public UnsafeSpan<Vector3> nodePositions;

		[WriteOnly]
		public UnsafeSpan<ulong> nodeConnections;

		public bool allowBoundsChecks => false;

		public static bool IsValidConnection(float y, float y2, float maxStepHeight)
		{
			return false;
		}

		public static bool IsValidConnection(float2 yRange, float2 yRange2, float maxStepHeight, float characterHeight)
		{
			return false;
		}

		private static float ConnectionY(UnsafeSpan<float3> nodePositions, UnsafeSpan<float4> nodeNormals, NativeArray<float4> normalToHeightOffset, int nodeIndex, int dir, float4 up, bool reverse)
		{
			return 0f;
		}

		private static float2 ConnectionYRange(UnsafeSpan<float3> nodePositions, UnsafeSpan<float4> nodeNormals, NativeArray<float4> normalToHeightOffset, int nodeIndex, int layerStride, int y, int maxY, int dir, float4 up, bool reverse)
		{
			return default(float2);
		}

		private static NativeArray<float4> HeightOffsetProjections(float4x4 graphToWorldTranform, bool maxStepUsesSlope)
		{
			return default(NativeArray<float4>);
		}

		public void Execute(int start, int count)
		{
		}

		public void ExecuteFlat(int start, int count)
		{
		}

		public void ExecuteLayered(int start, int count)
		{
		}
	}
}
