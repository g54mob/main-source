using System;
using Pathfinding.Drawing;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pathfinding.PID
{
	[Serializable]
	[BurstCompile]
	public struct PIDMovement
	{
		public struct PersistentState
		{
			public float maxDesiredWallDistance;
		}

		[Flags]
		public enum DebugFlags
		{
			Nothing = 0,
			Position = 1,
			Tangent = 2,
			SidewaysClearance = 4,
			ForwardClearance = 8,
			Obstacles = 0x10,
			Funnel = 0x20,
			Path = 0x40,
			ApproachWithOrientation = 0x80,
			Rotation = 0x100
		}

		private struct EdgeBuffers
		{
			public FixedList512Bytes<float2> triangleRegionEdgesL;

			public FixedList512Bytes<float2> triangleRegionEdgesR;

			public FixedList512Bytes<float2> straightRegionEdgesL;

			public FixedList512Bytes<float2> straightRegionEdgesR;
		}

		public struct ControlParams
		{
			public Vector3 p;

			public float speed;

			public float rotation;

			public float maxDesiredWallDistance;

			public float3 endOfPath;

			public float3 facingDirectionAtEndOfPath;

			public NativeArray<float2> edges;

			public float3 nextCorner;

			public float agentRadius;

			public float remainingDistance;

			public float3 closestOnNavmesh;

			public DebugFlags debugFlags;

			public NativeMovementPlane movementPlane;
		}

		public float rotationSpeed;

		public float speed;

		public float maxRotationSpeed;

		public float maxOnSpotRotationSpeed;

		public float slowdownTime;

		public float slowdownTimeWhenTurningOnSpot;

		public float desiredWallDistance;

		public float leadInRadiusWhenApproachingDestination;

		[SerializeField]
		private byte allowRotatingOnSpotBacking;

		public const float DESTINATION_CLEARANCE_FACTOR = 4f;

		private static readonly ProfilerMarker MarkerSidewaysAvoidance;

		private static readonly ProfilerMarker MarkerPID;

		private static readonly ProfilerMarker MarkerOptimizeDirection;

		private static readonly ProfilerMarker MarkerSmallestDistance;

		private static readonly ProfilerMarker MarkerConvertObstacles;

		private const float ALLOWED_OVERLAP_FACTOR = 0.1f;

		private const float STEP_MULTIPLIER = 1f;

		private const float MAX_FRACTION_OF_REMAINING_DISTANCE = 0.9f;

		private const int OPTIMIZATION_ITERATIONS = 8;

		public bool allowRotatingOnSpot
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void ScaleByAgentScale(float agentScale)
		{
		}

		public float Speed(float remainingDistance)
		{
			return 0f;
		}

		public float Accelerate(float speed, float timeToReachMaxSpeed, float dt)
		{
			return 0f;
		}

		public float CurveFollowingStrength(float signedDistToClearArea, float radiusToWall, float remainingDistance)
		{
			return 0f;
		}

		private static bool ClipLineByHalfPlaneX(ref float2 a, ref float2 b, float x, float side)
		{
			return false;
		}

		private static void ClipLineByHalfPlaneYt(float2 a, float2 b, float y, float side, ref float mnT, ref float mxT)
		{
		}

		private static float2 MaxAngle(float2 a, float2 b, float2 c, bool clockwise)
		{
			return default(float2);
		}

		private static float2 MaxAngle(float2 a, float2 b, bool clockwise)
		{
			return default(float2);
		}

		private static void DrawChisel(float2 start, float2 direction, float pointiness, float length, float width, CommandBuilder draw, Color col)
		{
		}

		private static void SplitSegment(float2 e1, float2 e2, float desiredRadius, float length, float pointiness, ref EdgeBuffers buffers)
		{
		}

		private static void SplitSegment2(float2 e1, float2 e2, float desiredRadius, float pointiness, ref EdgeBuffers buffers)
		{
		}

		private static void SplitSegment3(float2 e1, float2 e2, float desiredRadius, bool inTriangularRegion, ref EdgeBuffers buffers)
		{
		}

		private static void SplitSegment4(float2 e1, float2 e2, bool inTriangularRegion, bool left, ref EdgeBuffers buffers)
		{
		}

		public static float2 OptimizeDirection(float2 start, float2 end, float desiredRadius, float remainingDistance, float pointiness, NativeArray<float2> edges, CommandBuilder draw, DebugFlags debugFlags)
		{
			return default(float2);
		}

		public static float SmallestDistanceWithinWedge(float2 point, float2 dir1, float2 dir2, float shrinkAmount, NativeArray<float2> edges)
		{
			return 0f;
		}

		public static float2 Linecast(float2 a, float2 b, NativeArray<float2> edges)
		{
			return default(float2);
		}

		public static Bounds InterestingEdgeBounds(ref PIDMovement settings, float3 position, float3 nextCorner, float height, NativeMovementPlane plane)
		{
			return default(Bounds);
		}

		private static float2 OffsetCornerForApproach(float2 position2D, float2 endOfPath2D, float2 facingDir2D, ref PIDMovement settings, float2 nextCorner2D, ref float gammaAngle, ref float gammaAngleWeight, DebugFlags debugFlags, ref CommandBuilder draw, NativeArray<float2> edges)
		{
			return default(float2);
		}

		public static AnglePIDControlOutput2D Control(ref PIDMovement settings, float dt, ref ControlParams controlParams, ref CommandBuilder draw, out float maxDesiredWallDistance)
		{
			maxDesiredWallDistance = default(float);
			return default(AnglePIDControlOutput2D);
		}
	}
}
