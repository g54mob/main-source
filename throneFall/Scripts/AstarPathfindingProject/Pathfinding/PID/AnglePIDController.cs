using System;
using Unity.Mathematics;

namespace Pathfinding.PID
{
	public static class AnglePIDController
	{
		private const float DampingRatio = 1f;

		public static float ApproximateTurningRadius(float followingStrength)
		{
			float num = 2f * math.sqrt(math.abs(followingStrength)) * 1f;
			return 1f / (num * (MathF.PI / 2f));
		}

		public static float RotationSpeedToFollowingStrength(float speed, float maxRotationSpeed)
		{
			float num = maxRotationSpeed / (MathF.PI * 2f * speed * 1f);
			return num * num;
		}

		public static float FollowingStrengthToRotationSpeed(float followingStrength)
		{
			return 1f / (ApproximateTurningRadius(followingStrength) * 0.5f);
		}

		public static AnglePIDControlOutput2D Control(ref PIDMovement settings, float followingStrength, float angle, float curveAngle, float curveCurvature, float curveDistanceSigned, float speed, float remainingDistance, float minRotationSpeed, bool isStationary, float dt)
		{
			float num = 2f * math.sqrt(math.abs(followingStrength)) * 1f;
			float num2 = 1f;
			float num3 = AstarMath.DeltaAngle(angle, curveAngle);
			float angle2 = curveAngle + math.sign(curveDistanceSigned) * MathF.PI * 0.5f;
			float num4 = AstarMath.DeltaAngle(angle, angle2);
			float num5 = followingStrength * math.abs(curveDistanceSigned) * num4;
			float num6 = num5 * speed * dt;
			float num7 = num * num3;
			float num8 = num + followingStrength * math.abs(curveDistanceSigned);
			float num9 = ((num8 > 1.1754944E-38f) ? ((num7 + num5) / num8) : 0f);
			float.IsFinite(num9);
			isStationary = settings.allowRotatingOnSpot && (math.abs(num9) > 2.0941856f || (isStationary && math.abs(num9) > 0.1f));
			if (isStationary)
			{
				float num10 = settings.Accelerate(speed, settings.slowdownTimeWhenTurningOnSpot, 0f - dt);
				float num11 = math.radians(settings.maxOnSpotRotationSpeed);
				bool flag = num11 * dt > math.abs(num9);
				if (num10 > 0f && !flag)
				{
					return AnglePIDControlOutput2D.WithMovementAtEnd(angle, angle, 0f, num10 * dt);
				}
				return AnglePIDControlOutput2D.WithMovementAtEnd(angle, angle + num9, math.clamp(num9, (0f - num11) * dt, num11 * dt), flag ? (speed * dt) : 0f);
			}
			speed = math.min(settings.Speed(remainingDistance), settings.Accelerate(speed, settings.slowdownTime, dt));
			if (math.abs(num3) > MathF.PI / 2f)
			{
				num6 = 0f;
			}
			if (math.abs(num7) > 0.0001f)
			{
				num7 = math.max(math.abs(num7), minRotationSpeed) * math.sign(num7);
			}
			float num12 = num7 * speed * dt;
			float x = math.abs(num6 / num4);
			float x2 = math.abs(num12 / num3);
			float y = 1f;
			float num13 = math.max(0f, math.cos(num3));
			float num14 = 1f;
			float num15 = speed * num14 * dt;
			float num16 = curveCurvature * num15;
			float num17 = num2 * num16 * num13;
			float num18 = math.max(1f, math.max(x, math.max(x2, y)));
			float num19 = (num17 + num12 + num6) / num18;
			float num20 = math.radians(settings.maxRotationSpeed);
			float num21 = math.max(0.1f, math.min(1f, num20 * dt / math.abs(num19)));
			return new AnglePIDControlOutput2D(angle, angle + num9, num19 * num21, num15 * num21);
		}
	}
}
