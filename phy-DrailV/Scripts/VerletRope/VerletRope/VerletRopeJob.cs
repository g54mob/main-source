using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace VerletRope
{
	[BurstCompile]
	public struct VerletRopeJob : IJob
	{
		private NativeArray<Point> points;

		private NativeArray<Stick> sticks;

		private readonly int iterations;

		private readonly float bendingCorrectionFactor;

		private readonly float dt;

		private readonly float friction;

		private readonly float floorLevel;

		private readonly float floorFriction;

		private readonly float floorBendingScale;

		private readonly float3 gravity;

		private readonly quaternion firstPointLocalRotation;

		[ReadOnly]
		private readonly NativeArray<BurstPlane> cameraPlanes;

		private readonly float4x4 localToWorldMatrix;

		[WriteOnly]
		private NativeArray<bool> isMeshInFrustum;

		private readonly float maxV;

		public VerletRopeJob(NativeArray<Point> points, NativeArray<Stick> sticks, int iterations, float bendingCorrectionFactor, float dt, float maxV, float friction, float floorLevel, float floorFriction, float floorBendingScale, float3 gravity, quaternion firstPointLocalRotation, NativeArray<BurstPlane> cameraPlanes, float4x4 localToWorldMatrix, NativeArray<bool> isMeshInFrustum)
		{
			this.points = points;
			this.sticks = sticks;
			this.iterations = iterations;
			this.bendingCorrectionFactor = bendingCorrectionFactor;
			this.dt = dt;
			this.maxV = maxV;
			this.friction = friction;
			this.floorLevel = floorLevel;
			this.floorFriction = floorFriction;
			this.floorBendingScale = floorBendingScale;
			this.gravity = gravity;
			this.firstPointLocalRotation = firstPointLocalRotation;
			this.cameraPlanes = cameraPlanes;
			this.localToWorldMatrix = localToWorldMatrix;
			this.isMeshInFrustum = isMeshInFrustum;
		}

		public void Execute()
		{
			UpdatePoints(dt, maxV);
			float maxStick = maxV / (float)iterations;
			for (int i = 0; i < iterations; i++)
			{
				UpdateDistanceConstraints(maxStick);
				UpdateBendingConstraints(maxStick);
			}
			ResetPinsAndUpdateRotationsAndCalculateBounds();
		}

		private void UpdatePoints(float dt, float maxV)
		{
			for (int i = 0; i < points.Length; i++)
			{
				Point value = points[i];
				if (!value.pinned)
				{
					bool flag = value.curPos.y <= floorLevel;
					float3 vector = (value.curPos - value.oldPos) * (flag ? floorFriction : friction) + gravity * dt;
					vector = ClampMagnitude(vector, maxV);
					value.oldPos = value.curPos;
					value.curPos += vector;
					if (value.curPos.y <= floorLevel)
					{
						value.curPos.y = math.max(value.curPos.y, floorLevel);
						value.floorBendingMultiplier = floorBendingScale;
					}
					else
					{
						value.floorBendingMultiplier = 1f;
					}
				}
				else
				{
					value.oldPos = value.curPos;
					value.curPos = value.pinLocalPos;
					value.floorBendingMultiplier = 1f;
				}
				points[i] = value;
			}
		}

		private void UpdateBendingConstraints(float maxStick)
		{
			for (int i = 0; i < sticks.Length - 1; i++)
			{
				Stick stick = sticks[i];
				Stick stick2 = sticks[i + 1];
				Point value = points[stick.p1];
				Point value2 = points[stick.p2];
				Point value3 = points[stick2.p2];
				float num = (value.addedBendingCorrection + value2.addedBendingCorrection) * 0.5f;
				float num2 = (value.floorBendingMultiplier + value2.floorBendingMultiplier) * 0.5f;
				float num3 = stick.length + stick2.length;
				float3 float5 = value3.curPos - value.curPos;
				float num4 = math.length(float5);
				float num5 = (num3 - num4) / num4 * 0.5f * (bendingCorrectionFactor + num) * num2;
				float3 vector = float5 * num5;
				vector = ClampMagnitude(vector, maxStick);
				if (!value.pinned)
				{
					value.curPos -= vector;
				}
				if (!value3.pinned)
				{
					value3.curPos += vector;
				}
				points[stick.p1] = value;
				points[stick.p2] = value2;
				points[stick2.p2] = value3;
			}
		}

		private void UpdateDistanceConstraints(float maxStick)
		{
			for (int i = 0; i < sticks.Length; i++)
			{
				Stick value = sticks[i];
				Point value2 = points[value.p1];
				Point value3 = points[value.p2];
				if (value2.pinned && value3.pinned)
				{
					value.length = math.distance(value2.curPos, value3.curPos);
				}
				else
				{
					float3 obj = value3.curPos - value2.curPos;
					float num = math.length(obj);
					float num2 = (value.length - num) / num * 0.5f;
					float3 vector = obj * num2;
					vector = ClampMagnitude(vector, maxStick);
					if (!value2.pinned)
					{
						value2.curPos -= vector;
					}
					if (!value3.pinned)
					{
						value3.curPos += vector;
					}
				}
				points[value.p1] = value2;
				points[value.p2] = value3;
				sticks[i] = value;
			}
		}

		private void ResetPinsAndUpdateRotationsAndCalculateBounds()
		{
			float3 float5 = math.mul(firstPointLocalRotation, new float3(0f, 1f, 0f));
			BurstBounds bounds = default(BurstBounds);
			for (int i = 0; i < points.Length; i++)
			{
				Point value = points[i];
				value.pinned = false;
				float3 curPos = value.curPos;
				float3 float6;
				float3 float7;
				if (i == 0)
				{
					float6 = points[i + 1].curPos;
					float7 = curPos + (curPos - float6);
				}
				else if (i == points.Length - 1)
				{
					float7 = points[i - 1].curPos;
					float6 = curPos + (curPos - float7);
				}
				else
				{
					float7 = points[i - 1].curPos;
					float6 = points[i + 1].curPos;
				}
				float3 localForward = float6 - float7;
				float3 float8 = ((i != 0) ? math.cross(new BurstPlane(float7, curPos, curPos + float5).normal, curPos - float7) : float5);
				value.localForward = localForward;
				value.localUp = float8;
				float5 = float8;
				points[i] = value;
				if (i == 0)
				{
					bounds = new BurstBounds(math.mul(localToWorldMatrix, math.float4(value.curPos, 1f)).xyz);
				}
				else
				{
					bounds.Encapsulate(math.mul(localToWorldMatrix, math.float4(value.curPos, 1f)).xyz);
				}
				bounds.Expand(0.1f);
				isMeshInFrustum[0] = MeshInitialGenerateJob.FrustumIntersectsBounds(cameraPlanes, bounds);
			}
		}

		private static float3 ClampMagnitude(float3 vector, float maxLength)
		{
			float num = math.lengthsq(vector);
			if (num <= maxLength * maxLength)
			{
				return vector;
			}
			return vector * (maxLength / math.sqrt(num));
		}
	}
}
