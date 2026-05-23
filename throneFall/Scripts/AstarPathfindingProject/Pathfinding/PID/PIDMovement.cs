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

		private static readonly ProfilerMarker MarkerSidewaysAvoidance = new ProfilerMarker("SidewaysAvoidance");

		private static readonly ProfilerMarker MarkerPID = new ProfilerMarker("PID");

		private static readonly ProfilerMarker MarkerOptimizeDirection = new ProfilerMarker("OptimizeDirection");

		private static readonly ProfilerMarker MarkerSmallestDistance = new ProfilerMarker("ClosestDistance");

		private static readonly ProfilerMarker MarkerConvertObstacles = new ProfilerMarker("ConvertObstacles");

		private const float ALLOWED_OVERLAP_FACTOR = 0.1f;

		private const float STEP_MULTIPLIER = 1f;

		private const float MAX_FRACTION_OF_REMAINING_DISTANCE = 0.9f;

		private const int OPTIMIZATION_ITERATIONS = 8;

		public bool allowRotatingOnSpot
		{
			get
			{
				return allowRotatingOnSpotBacking != 0;
			}
			set
			{
				allowRotatingOnSpotBacking = (byte)(value ? 1u : 0u);
			}
		}

		public void ScaleByAgentScale(float agentScale)
		{
			speed *= agentScale;
			leadInRadiusWhenApproachingDestination *= agentScale;
			desiredWallDistance *= agentScale;
		}

		public float Speed(float remainingDistance)
		{
			if (speed <= 0f)
			{
				return 0f;
			}
			if (slowdownTime <= 0f)
			{
				if (!(remainingDistance <= 0.0001f))
				{
					return speed;
				}
				return 0f;
			}
			float num = Mathf.Min(1f, Mathf.Sqrt(2f * remainingDistance / (speed * slowdownTime)));
			return speed * num;
		}

		public float Accelerate(float speed, float timeToReachMaxSpeed, float dt)
		{
			if (timeToReachMaxSpeed > 0.001f)
			{
				float num = this.speed / timeToReachMaxSpeed;
				return math.clamp(speed + dt * num, 0f, this.speed);
			}
			if (!(dt > 0f))
			{
				return 0f;
			}
			return this.speed;
		}

		public float CurveFollowingStrength(float signedDistToClearArea, float radiusToWall, float remainingDistance)
		{
			float num = math.max(1E-05f, speed);
			float x = math.max(AnglePIDController.RotationSpeedToFollowingStrength(num, math.radians(rotationSpeed)), 40f * math.pow(math.abs(signedDistToClearArea) / math.max(0.0001f, radiusToWall), 1f));
			float num2 = remainingDistance / num;
			return math.max(x, math.min(80f, math.pow(1f / math.max(0f, num2 - 0.2f), 3f)));
		}

		private static bool ClipLineByHalfPlaneX(ref float2 a, ref float2 b, float x, float side)
		{
			bool flag = (a.x - x) * side < 0f;
			bool flag2 = (b.x - x) * side < 0f;
			if (flag && flag2)
			{
				return false;
			}
			if (flag != flag2)
			{
				float s = math.unlerp(a.x, b.x, x);
				float2 float5 = math.lerp(a, b, s);
				if (flag)
				{
					a = float5;
				}
				else
				{
					b = float5;
				}
			}
			return true;
		}

		private static void ClipLineByHalfPlaneYt(float2 a, float2 b, float y, float side, ref float mnT, ref float mxT)
		{
			bool flag = (a.y - y) * side < 0f;
			bool flag2 = (b.y - y) * side < 0f;
			if (flag && flag2)
			{
				mnT = 1f;
				mxT = 0f;
			}
			else if (flag != flag2)
			{
				float y2 = math.unlerp(a.y, b.y, y);
				if (flag)
				{
					mnT = math.max(mnT, y2);
				}
				else
				{
					mxT = math.min(mxT, y2);
				}
			}
		}

		private static float2 MaxAngle(float2 a, float2 b, float2 c, bool clockwise)
		{
			a = math.select(a, b, VectorMath.Determinant(a, b) < 0f == clockwise);
			a = math.select(a, c, VectorMath.Determinant(a, c) < 0f == clockwise);
			return a;
		}

		private static float2 MaxAngle(float2 a, float2 b, bool clockwise)
		{
			return math.select(a, b, VectorMath.Determinant(a, b) < 0f == clockwise);
		}

		private static void DrawChisel(float2 start, float2 direction, float pointiness, float length, float width, CommandBuilder draw, Color col)
		{
			draw.PushColor(col);
			float2 float5 = start + (direction * pointiness + new float2(0f - direction.y, direction.x)) * width;
			float2 float6 = start + (direction * pointiness - new float2(0f - direction.y, direction.x)) * width;
			draw.xz.Line(start, float5, col);
			draw.xz.Line(start, float6, col);
			float num = length - pointiness * width;
			if (num > 0f)
			{
				draw.xz.Ray(float5, direction * num, col);
				draw.xz.Ray(float6, direction * num, col);
			}
			draw.PopColor();
		}

		private static void SplitSegment(float2 e1, float2 e2, float desiredRadius, float length, float pointiness, ref EdgeBuffers buffers)
		{
			float num = desiredRadius * 2f;
			if ((e1.y < 0f - num && e2.y < 0f - num) || (e1.y > num && e2.y > num) || !ClipLineByHalfPlaneX(ref e1, ref e2, 0f, 1f) || !VectorMath.SegmentCircleIntersectionFactors(e1, e2, length * length, out var t, out var t2))
			{
				return;
			}
			float num2 = desiredRadius * 0.01f;
			if (VectorMath.SegmentCircleIntersectionFactors(e1, e2, num2 * num2, out var t3, out var t4) && t3 < t2 && t4 > t)
			{
				if (t3 > t && t3 < t2)
				{
					SplitSegment2(math.lerp(e1, e2, t), math.lerp(e1, e2, t3), desiredRadius, pointiness, ref buffers);
				}
				if (t4 > t && t4 < t2)
				{
					SplitSegment2(math.lerp(e1, e2, t4), math.lerp(e1, e2, t2), desiredRadius, pointiness, ref buffers);
				}
			}
			else
			{
				SplitSegment2(math.lerp(e1, e2, t), math.lerp(e1, e2, t2), desiredRadius, pointiness, ref buffers);
			}
		}

		private static void SplitSegment2(float2 e1, float2 e2, float desiredRadius, float pointiness, ref EdgeBuffers buffers)
		{
			if (VectorMath.SegmentCircleIntersectionFactors(e1, e2, (pointiness * pointiness + 1f) * desiredRadius * desiredRadius, out var t, out var t2))
			{
				if (t > 0f && t2 < 1f)
				{
					SplitSegment3(e1, math.lerp(e1, e2, t), desiredRadius, inTriangularRegion: false, ref buffers);
					SplitSegment3(math.lerp(e1, e2, t), math.lerp(e1, e2, t2), desiredRadius, inTriangularRegion: true, ref buffers);
					SplitSegment3(math.lerp(e1, e2, t2), e2, desiredRadius, inTriangularRegion: false, ref buffers);
				}
				else if (t > 0f)
				{
					SplitSegment3(e1, math.lerp(e1, e2, t), desiredRadius, inTriangularRegion: false, ref buffers);
					SplitSegment3(math.lerp(e1, e2, t), e2, desiredRadius, inTriangularRegion: true, ref buffers);
				}
				else if (t2 < 1f)
				{
					SplitSegment3(e1, math.lerp(e1, e2, t2), desiredRadius, inTriangularRegion: true, ref buffers);
					SplitSegment3(math.lerp(e1, e2, t2), e2, desiredRadius, inTriangularRegion: false, ref buffers);
				}
				else
				{
					SplitSegment3(e1, e2, desiredRadius, inTriangularRegion: true, ref buffers);
				}
			}
			else
			{
				SplitSegment3(e1, e2, desiredRadius, inTriangularRegion: false, ref buffers);
			}
		}

		private static void SplitSegment3(float2 e1, float2 e2, float desiredRadius, bool inTriangularRegion, ref EdgeBuffers buffers)
		{
			float2 a = e1;
			float2 b = e2;
			if (b.x < a.x)
			{
				a.y -= 0.01f;
				b.y -= 0.01f;
			}
			else
			{
				a.y += 0.01f;
				b.y += 0.01f;
			}
			bool flag = a.y > 0f;
			if (!flag)
			{
				Memory.Swap(ref e1, ref e2);
				Memory.Swap(ref a, ref b);
			}
			float num = math.unlerp(a.y, b.y, 0f);
			bool flag2 = math.isfinite(num);
			if (num <= 0f || num >= 1f || !flag2)
			{
				SplitSegment4(e1, e2, inTriangularRegion, flag, ref buffers);
				return;
			}
			float2 float5 = e1 + num * (e2 - e1);
			float num2 = math.lengthsq(e1 - float5);
			float num3 = math.lengthsq(e2 - float5);
			float num4 = desiredRadius * 0.1f;
			float num5 = num4 * num4;
			if (num2 > num5 || num2 >= num3)
			{
				SplitSegment4(e1, float5, inTriangularRegion, left: true, ref buffers);
			}
			if (num3 > num5 || num3 >= num2)
			{
				SplitSegment4(float5, e2, inTriangularRegion, left: false, ref buffers);
			}
		}

		private static void SplitSegment4(float2 e1, float2 e2, bool inTriangularRegion, bool left, ref EdgeBuffers buffers)
		{
			if (!math.all(math.abs(e1 - e2) < 0.01f))
			{
				ref FixedList512Bytes<float2> reference = ref buffers.triangleRegionEdgesL;
				if (!inTriangularRegion)
				{
					reference = ref !left ? ref buffers.straightRegionEdgesR : ref buffers.straightRegionEdgesL;
				}
				else if (!left)
				{
					reference = ref buffers.triangleRegionEdgesR;
				}
				if (reference.Length + 2 <= reference.Capacity)
				{
					reference.AddNoResize(in e1);
					reference.AddNoResize(in e2);
				}
			}
		}

		public static float2 OptimizeDirection(float2 start, float2 end, float desiredRadius, float remainingDistance, float pointiness, NativeArray<float2> edges, CommandBuilder draw, DebugFlags debugFlags)
		{
			float num = math.length(end - start);
			float2 float5 = math.normalizesafe(end - start);
			num *= 0.999f;
			num = math.min(0.9f * remainingDistance, num);
			if (desiredRadius <= 0.0001f)
			{
				return float5;
			}
			float num2 = num;
			float num3 = 1f / num2;
			EdgeBuffers buffers = default(EdgeBuffers);
			for (int i = 0; i < edges.Length; i += 2)
			{
				float2 e = VectorMath.ComplexMultiplyConjugate(edges[i] - start, float5);
				float2 e2 = VectorMath.ComplexMultiplyConjugate(edges[i + 1] - start, float5);
				SplitSegment(e, e2, desiredRadius, num, pointiness, ref buffers);
			}
			float2 float6 = new float2(1f, 0f);
			for (int j = 0; j < 8; j++)
			{
				if ((debugFlags & DebugFlags.ForwardClearance) != DebugFlags.Nothing)
				{
					Color blue = Palette.Colorbrewer.Set1.Blue;
					blue.a = 0.5f;
					float2 float7 = VectorMath.ComplexMultiply(float6, float5);
					DrawChisel(start, float7, pointiness, num, desiredRadius, draw, blue);
					draw.xz.Ray(start, float7 * num, Palette.Colorbrewer.Set1.Purple);
					draw.xz.Circle(start, remainingDistance, blue);
				}
				float2 float8 = new float2(0f, desiredRadius);
				float2 float9 = new float2(0f, 0f - desiredRadius);
				float2 float10 = new float2(num, 0f);
				float2 float11 = new float2(num, 0f);
				for (int k = 0; k < buffers.straightRegionEdgesL.Length; k += 2)
				{
					float2 float12 = VectorMath.ComplexMultiplyConjugate(buffers.straightRegionEdgesL[k], float6);
					float2 float13 = VectorMath.ComplexMultiplyConjugate(buffers.straightRegionEdgesL[k + 1], float6);
					float10 = MaxAngle(float10, float12 - float8, float13 - float8, clockwise: true);
				}
				for (int l = 0; l < buffers.straightRegionEdgesR.Length; l += 2)
				{
					float2 float14 = VectorMath.ComplexMultiplyConjugate(buffers.straightRegionEdgesR[l], float6);
					float2 float15 = VectorMath.ComplexMultiplyConjugate(buffers.straightRegionEdgesR[l + 1], float6);
					float11 = MaxAngle(float11, float14 - float9, float15 - float9, clockwise: false);
				}
				float2 b = math.normalizesafe(VectorMath.ComplexMultiply(new float2(pointiness * desiredRadius, desiredRadius), float6));
				float2 b2 = math.normalizesafe(VectorMath.ComplexMultiply(new float2(pointiness * desiredRadius, 0f - desiredRadius), float6));
				for (int m = 0; m < buffers.triangleRegionEdgesL.Length; m += 2)
				{
					float2 float16 = VectorMath.ComplexMultiplyConjugate(buffers.triangleRegionEdgesL[m], b);
					float2 float17 = VectorMath.ComplexMultiplyConjugate(buffers.triangleRegionEdgesL[m + 1], b);
					float2 b3 = ((float17.y < float16.y) ? float17 : float16);
					if (b3.y < 0f)
					{
						float10 = MaxAngle(float10, b3, clockwise: true);
					}
				}
				for (int n = 0; n < buffers.triangleRegionEdgesR.Length; n += 2)
				{
					float2 float18 = VectorMath.ComplexMultiplyConjugate(buffers.triangleRegionEdgesR[n], b2);
					float2 float19 = VectorMath.ComplexMultiplyConjugate(buffers.triangleRegionEdgesR[n + 1], b2);
					float2 b4 = ((float19.y > float18.y) ? float19 : float18);
					if (b4.y > 0f)
					{
						float11 = MaxAngle(float11, b4, clockwise: false);
					}
				}
				float num4 = 1f / math.max(1E-06f, num2 - float10.x * float10.x) - num3;
				float num5 = 1f / math.max(1E-06f, num2 - float11.x * float11.x) - num3;
				float2 y = math.normalizesafe(float10 * num5 + float11 * num4);
				float2 b5 = math.lerp(new float2(1f, 0f), y, 1f);
				float6 = math.normalizesafe(VectorMath.ComplexMultiply(float6, b5));
				num = ((float10.y != 0f || float11.y != 0f) ? math.min(num, math.max(desiredRadius * 2f, math.min(float10.x, float11.x) * 2f)) : math.min(remainingDistance * 0.9f, math.min(num * 1.1f, num2 * 1.2f)));
			}
			float6 = VectorMath.ComplexMultiply(float6, float5);
			if ((debugFlags & DebugFlags.ForwardClearance) != DebugFlags.Nothing)
			{
				DrawChisel(start, float6, pointiness, num, desiredRadius, draw, Color.black);
			}
			return float6;
		}

		public static float SmallestDistanceWithinWedge(float2 point, float2 dir1, float2 dir2, float shrinkAmount, NativeArray<float2> edges)
		{
			dir1 = math.normalizesafe(dir1);
			dir2 = math.normalizesafe(dir2);
			if (math.dot(dir1, dir2) > 0.999f)
			{
				return float.PositiveInfinity;
			}
			float num = math.sign(VectorMath.Determinant(dir1, dir2));
			shrinkAmount *= num;
			float num2 = float.PositiveInfinity;
			for (int i = 0; i < edges.Length; i += 2)
			{
				float2 float5 = edges[i] - point;
				float2 float6 = edges[i + 1] - point;
				float2 a = VectorMath.ComplexMultiplyConjugate(float5, dir1);
				float2 b = VectorMath.ComplexMultiplyConjugate(float6, dir1);
				float2 a2 = VectorMath.ComplexMultiplyConjugate(float5, dir2);
				float2 b2 = VectorMath.ComplexMultiplyConjugate(float6, dir2);
				float mnT = 0f;
				float mxT = 1f;
				ClipLineByHalfPlaneYt(a, b, shrinkAmount, num, ref mnT, ref mxT);
				if (!(mnT > mxT))
				{
					ClipLineByHalfPlaneYt(a2, b2, 0f - shrinkAmount, 0f - num, ref mnT, ref mxT);
					if (!(mnT > mxT))
					{
						float num3 = math.lengthsq(float6 - float5);
						float s = math.clamp(math.dot(float5, float5 - float6) * math.rcp(num3), mnT, mxT);
						float y = math.lengthsq(math.lerp(float5, float6, s));
						num2 = math.select(num2, math.min(num2, y), num3 > 1.1754944E-38f);
					}
				}
			}
			return math.sqrt(num2);
		}

		public static float2 Linecast(float2 a, float2 b, NativeArray<float2> edges)
		{
			float num = 1f;
			for (int i = 0; i < edges.Length; i += 2)
			{
				float2 float5 = edges[i];
				float2 float6 = edges[i + 1];
				VectorMath.LineLineIntersectionFactors(a, b - a, float5, float6 - float5, out var factor, out var factor2);
				if (factor2 >= 0f && factor2 <= 1f && factor > 0f)
				{
					num = math.min(num, factor);
				}
			}
			return a + (b - a) * num;
		}

		public static Bounds InterestingEdgeBounds(ref PIDMovement settings, float3 position, float3 nextCorner, float height, NativeMovementPlane plane)
		{
			float3 float5 = math.mul(math.conjugate(plane.rotation), position);
			float3 float6 = math.mul(math.conjugate(plane.rotation), nextCorner);
			Bounds result = new Bounds(float5 + new float3(0f, height * 0.25f, 0f), new Vector3(0f, 1.5f * height, 0f));
			float6.y = float5.y;
			result.Encapsulate(float6);
			if (settings.rotationSpeed > 0f)
			{
				float x = settings.speed / math.radians(settings.rotationSpeed);
				result.Expand(new Vector3(1f, 0f, 1f) * math.max(x, settings.desiredWallDistance * 8f * 1f));
			}
			return result;
		}

		private static float2 OffsetCornerForApproach(float2 position2D, float2 endOfPath2D, float2 facingDir2D, ref PIDMovement settings, float2 nextCorner2D, ref float gammaAngle, ref float gammaAngleWeight, DebugFlags debugFlags, ref CommandBuilder draw, NativeArray<float2> edges)
		{
			float2 x = endOfPath2D - position2D;
			if (math.dot(math.normalizesafe(x), facingDir2D) < -0.2f)
			{
				return nextCorner2D;
			}
			float2 float5 = new float2(0f - x.y, x.x);
			float2 float6 = new float2(0f - facingDir2D.y, facingDir2D.x);
			float2 float7 = (position2D + endOfPath2D) * 0.5f;
			bool intersects;
			float2 float8 = VectorMath.LineIntersectionPoint(float7, float7 + float5, endOfPath2D, endOfPath2D + float6, out intersects);
			if (!intersects)
			{
				return nextCorner2D;
			}
			float num = SmallestDistanceWithinWedge(endOfPath2D - 0.01f * facingDir2D, float6 - 0.1f * facingDir2D, -float6 - 0.1f * facingDir2D, 0.001f, edges);
			float x2 = settings.leadInRadiusWhenApproachingDestination;
			x2 = math.min(x2, num * 0.9f);
			float num2 = math.length(float8 - endOfPath2D);
			float num3 = math.abs(math.dot(math.normalizesafe(x), float6));
			float num4 = 1f / math.sqrt(1f - num3 * num3) * math.length(x) * 0.5f;
			num4 /= math.min(x2, num2);
			num4 = math.tanh(num4);
			num4 *= math.min(x2, num2);
			float2 float9 = nextCorner2D - facingDir2D * num4;
			if ((debugFlags & DebugFlags.ApproachWithOrientation) != DebugFlags.Nothing)
			{
				draw.xz.Circle(float8, num2, Color.blue);
				draw.xz.Arrow(position2D, float9, Palette.Colorbrewer.Set1.Orange);
			}
			if (math.lengthsq(Linecast(position2D, float9, edges) - float9) > 0.01f)
			{
				return nextCorner2D;
			}
			return float9;
		}

		public static AnglePIDControlOutput2D Control(ref PIDMovement settings, float dt, ref ControlParams controlParams, ref CommandBuilder draw, out float maxDesiredWallDistance)
		{
			if (dt <= 0f)
			{
				maxDesiredWallDistance = controlParams.maxDesiredWallDistance;
				return new AnglePIDControlOutput2D
				{
					rotationDelta = 0f,
					positionDelta = float2.zero
				};
			}
			NativeMovementPlane movementPlane = controlParams.movementPlane;
			float elevation;
			float2 float5 = movementPlane.ToPlane(controlParams.p, out elevation);
			if (controlParams.debugFlags != DebugFlags.Nothing)
			{
				draw.PushMatrix(math.mul(new float4x4(movementPlane.rotation, float3.zero), float4x4.Translate(new float3(0f, elevation, 0f))));
			}
			if ((controlParams.debugFlags & DebugFlags.Position) != DebugFlags.Nothing)
			{
				draw.xz.Cross(controlParams.closestOnNavmesh, 0.05f, Color.red);
			}
			NativeArray<float2> edges = controlParams.edges;
			if ((controlParams.debugFlags & DebugFlags.Obstacles) != DebugFlags.Nothing)
			{
				draw.PushLineWidth(2f);
				draw.PushColor(Color.red);
				for (int i = 0; i < edges.Length; i += 2)
				{
					draw.xz.Line(edges[i], edges[i + 1]);
				}
				draw.PopColor();
				draw.PopLineWidth();
			}
			float2 float6 = movementPlane.ToPlane(controlParams.nextCorner);
			float curveCurvature = 0f;
			float gammaAngle = 0f;
			float gammaAngleWeight = 0f;
			float num = controlParams.rotation + MathF.PI / 2f;
			float2 float7 = math.normalizesafe(movementPlane.ToPlane(controlParams.facingDirectionAtEndOfPath));
			bool num2 = controlParams.remainingDistance < controlParams.agentRadius * 0.1f;
			if (!num2 && settings.leadInRadiusWhenApproachingDestination > 0f && math.any(float7 != 0f))
			{
				float2 float8 = movementPlane.ToPlane(controlParams.endOfPath);
				if (math.lengthsq(float8 - float6) <= 0.1f)
				{
					float2 float9 = OffsetCornerForApproach(float5, float8, float7, ref settings, float6, ref gammaAngle, ref gammaAngleWeight, controlParams.debugFlags, ref draw, edges);
					float6 = float9;
					float num3 = settings.speed * 0.1f;
					if (num3 > 0.001f)
					{
						math.sincos(num, out var s, out var c);
						float2 float10 = new float2(c, s);
						curveCurvature = math.asin(VectorMath.Determinant(c2: math.normalizesafe(OffsetCornerForApproach(float5 + float10 * num3, float8, float7, ref settings, float6, ref gammaAngle, ref gammaAngleWeight, DebugFlags.Nothing, ref draw, edges) - float5), c1: math.normalizesafe(float9 - float5))) / num3;
					}
				}
			}
			float num4 = settings.desiredWallDistance;
			num4 = math.max(0f, math.min(num4, (controlParams.remainingDistance - num4) / 4f));
			float6 = Linecast(float5, float6, edges);
			float2 float11 = OptimizeDirection(float5, float6, num4, controlParams.remainingDistance, 2f, edges, draw, controlParams.debugFlags);
			maxDesiredWallDistance = controlParams.maxDesiredWallDistance + settings.speed * 0.1f * dt;
			float num5 = maxDesiredWallDistance;
			float curveDistanceSigned = 0f;
			float signedDistToClearArea = 0f;
			maxDesiredWallDistance = math.min(maxDesiredWallDistance, num5);
			if ((controlParams.debugFlags & DebugFlags.Tangent) != DebugFlags.Nothing)
			{
				draw.Arrow(controlParams.p, controlParams.p + new Vector3(float11.x, 0f, float11.y), Palette.Colorbrewer.Set1.Orange);
			}
			AnglePIDControlOutput2D result;
			if (num2)
			{
				float num6 = math.min(settings.Speed(controlParams.remainingDistance), settings.Accelerate(controlParams.speed, settings.slowdownTime, dt));
				float2 float12 = float6 - float5;
				float num7 = math.length(float12);
				if (math.any(float7 != 0f))
				{
					float num8 = math.atan2(float7.y, float7.x);
					float num9 = dt * math.radians(settings.maxRotationSpeed);
					result = new AnglePIDControlOutput2D
					{
						rotationDelta = math.clamp(AstarMath.DeltaAngle(num, num8), 0f - num9, num9),
						targetRotation = num8 - MathF.PI / 2f,
						positionDelta = ((num7 > 1.1754944E-38f) ? (float12 * (dt * num6 / num7)) : float12)
					};
				}
				else
				{
					result = new AnglePIDControlOutput2D
					{
						rotationDelta = 0f,
						targetRotation = num - MathF.PI / 2f,
						positionDelta = ((num7 > 1.1754944E-38f) ? (float12 * (dt * num6 / num7)) : float12)
					};
				}
			}
			else
			{
				float followingStrength = settings.CurveFollowingStrength(signedDistToClearArea, num5, controlParams.remainingDistance);
				float num10 = math.atan2(float11.y, float11.x);
				float minRotationSpeed = 0f;
				if (math.abs(AstarMath.DeltaAngle(num10, num)) > 0.003141593f)
				{
					math.sincos(num, out var s2, out var c2);
					float2 float13 = new float2(c2, s2);
					float num11 = SmallestDistanceWithinWedge(float5, float11, float13, controlParams.agentRadius * 0.1f, edges);
					if ((controlParams.debugFlags & DebugFlags.ForwardClearance) != DebugFlags.Nothing && float.IsFinite(num11))
					{
						draw.xz.Arc(float5, float5 + float13 * num11, float5 + float11, Palette.Colorbrewer.Set1.Purple);
					}
					if (num11 > 0.001f && num11 * 1.01f < controlParams.remainingDistance)
					{
						minRotationSpeed = math.rcp(num11) * 2f;
					}
				}
				result = AnglePIDController.Control(ref settings, followingStrength, num, num10 + AstarMath.DeltaAngle(num10, gammaAngle) * gammaAngleWeight, curveCurvature, curveDistanceSigned, controlParams.speed, controlParams.remainingDistance, minRotationSpeed, controlParams.speed < settings.speed * 0.1f, dt);
				result.targetRotation -= MathF.PI / 2f;
			}
			if (controlParams.debugFlags != DebugFlags.Nothing)
			{
				draw.PopMatrix();
			}
			return result;
		}
	}
}
