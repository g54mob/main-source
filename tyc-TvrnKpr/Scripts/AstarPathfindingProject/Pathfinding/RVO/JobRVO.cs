using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Pathfinding.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.RVO
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Default)]
	public struct JobRVO<MovementPlaneWrapper> : IJobParallelForBatched where MovementPlaneWrapper : struct, IMovementPlaneWrapper
	{
		private struct SortByKey : IComparer<int>
		{
			public UnsafeSpan<float> keys;

			public int Compare(int x, int y)
			{
				return 0;
			}
		}

		private struct ORCALine
		{
			public float2 point;

			public float2 direction;

			public void DrawAsHalfPlane(CommandBuilder draw, float halfPlaneLength, float halfPlaneWidth, Color color)
			{
			}

			public ORCALine(float2 position, float2 relativePosition, float2 velocity, float2 otherVelocity, float combinedRadius, float timeStep, float invTimeHorizon)
			{
				point = default(float2);
				direction = default(float2);
			}
		}

		private struct LinearProgram2Output
		{
			public float2 velocity;

			public int firstFailedLineIndex;
		}

		[ReadOnly]
		public SimulatorBurst.AgentData agentData;

		[ReadOnly]
		public SimulatorBurst.TemporaryAgentData temporaryAgentData;

		[ReadOnly]
		public NavmeshEdges.NavmeshBorderData navmeshEdgeData;

		[WriteOnly]
		public SimulatorBurst.AgentOutputData output;

		public float deltaTime;

		public float symmetryBreakingBias;

		public float priorityMultiplier;

		public bool useNavmeshAsObstacle;

		private const int MaxObstacleCount = 50;

		private static readonly ProfilerMarker MarkerConvertObstacles1;

		private static readonly ProfilerMarker MarkerConvertObstacles2;

		public bool allowBoundsChecks => false;

		public void Execute(int startIndex, int batchSize)
		{
		}

		private static void InsertionSort<T, U>(UnsafeSpan<T> data, U comparer) where T : struct where U : IComparer<T>
		{
		}

		private void GenerateObstacleVOs(int agentIndex, NativeList<int> adjacentObstacleIdsScratch, NativeArray<int2> adjacentObstacleVerticesScratch, NativeArray<float> segmentDistancesScratch, NativeArray<int> sortedVerticesScratch, NativeArray<ORCALine> orcaLines, NativeArray<int> orcaLineToAgent, [NoAlias] ref int numLines, [NoAlias] in MovementPlaneWrapper movementPlane, float2 optimalVelocity)
		{
		}

		public void ExecuteORCA(int startIndex, int batchSize)
		{
		}

		private float CalculateForwardClearance(NativeSlice<int> neighbours, MovementPlaneWrapper movementPlane, float3 position, float radius, float2 targetDir)
		{
			return 0f;
		}

		private static bool leftOrColinear(float2 vector1, float2 vector2)
		{
			return false;
		}

		private static bool left(float2 vector1, float2 vector2)
		{
			return false;
		}

		private static bool rightOrColinear(float2 vector1, float2 vector2)
		{
			return false;
		}

		private static bool right(float2 vector1, float2 vector2)
		{
			return false;
		}

		private static float det(float2 vector1, float2 vector2)
		{
			return 0f;
		}

		private static float2 rot90(float2 v)
		{
			return default(float2);
		}

		private static float DistanceInsideVOs(UnsafeSpan<ORCALine> lines, float2 velocity)
		{
			return 0f;
		}

		private static bool BiasDesiredVelocity(UnsafeSpan<ORCALine> lines, ref float2 desiredVelocity, ref float2 targetPointInVelocitySpace, float maxBiasRadians)
		{
			return false;
		}

		private static bool ClipLine(ORCALine line, ORCALine clipper, ref float tLeft, ref float tRight)
		{
			return false;
		}

		private static bool ClipBoundary(NativeArray<ORCALine> lines, int lineIndex, float radius, out float tLeft, out float tRight)
		{
			tLeft = default(float);
			tRight = default(float);
			return false;
		}

		private static bool LinearProgram1D(NativeArray<ORCALine> lines, int lineIndex, float radius, float2 optimalVelocity, bool directionOpt, ref float2 result)
		{
			return false;
		}

		private static LinearProgram2Output LinearProgram2D(NativeArray<ORCALine> lines, int numLines, float radius, float2 optimalVelocity, bool directionOpt)
		{
			return default(LinearProgram2Output);
		}

		private static float ClosestPointOnSegment(float2 a, float2 dir, float2 p, float t0, float t1)
		{
			return 0f;
		}

		private static float2 ClosestSegmentSegmentPointNonIntersecting(ORCALine a, ORCALine b, float ta1, float ta2, float tb1, float tb2)
		{
			return default(float2);
		}

		private static LinearProgram2Output LinearProgram2DCollapsedSegment(NativeArray<ORCALine> lines, int numLines, int startLine, float radius, float2 currentResult, float2 optimalVelocityStart, float2 optimalVelocityDir, float optimalTLeft, float optimalTRight)
		{
			return default(LinearProgram2Output);
		}

		private static LinearProgram2Output LinearProgram2DSegment(NativeArray<ORCALine> lines, int numLines, float radius, float2 optimalVelocityStart, float2 optimalVelocityDir, float optimalTLeft, float optimalTRight, float optimalT)
		{
			return default(LinearProgram2Output);
		}

		private static void LinearProgram3D(NativeArray<ORCALine> lines, int numLines, int numFixedLines, int beginLine, float radius, ref float2 result, NativeArray<ORCALine> scratchBuffer)
		{
		}

		private static void DrawVO(CommandBuilder draw, float2 circleCenter, float radius, float2 origin, Color color)
		{
		}
	}
}
