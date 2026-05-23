using System;
using UnityEngine;

namespace Pathfinding.Util
{
	public static class MovementUtilities
	{
		public static float FilterRotationDirection(ref Vector2 state, ref Vector2 state2, Vector2 deltaPosition, float threshold, float deltaTime, bool avoidingOtherAgents)
		{
			Vector2 vector = state;
			if (!avoidingOtherAgents)
			{
				state += deltaPosition * 10f;
			}
			else
			{
				state += deltaPosition;
			}
			state *= Mathf.Clamp01(1f - deltaTime * 0.5f);
			float num = state.magnitude;
			if (num > threshold * 2f)
			{
				state *= threshold * 2f / num;
				num = threshold * 2f;
			}
			state2 += (state - vector) * 0.5f;
			state2 *= Mathf.Clamp01(1f - deltaTime * 0.5f);
			if (!(num > threshold))
			{
				return 0f;
			}
			return 1f;
		}

		public static Vector2 ClampVelocity(Vector2 velocity, float maxSpeed, float speedLimitFactor, bool slowWhenNotFacingTarget, bool preventMovingBackwards, Vector2 forward)
		{
			float num = maxSpeed * speedLimitFactor;
			if (slowWhenNotFacingTarget && (forward.x != 0f || forward.y != 0f))
			{
				float magnitude;
				Vector2 vector = VectorMath.Normalize(velocity, out magnitude);
				float num2 = Vector2.Dot(vector, forward);
				float num3 = Mathf.Clamp(num2 + 0.707f, 0.2f, 1f);
				num *= num3;
				magnitude = Mathf.Min(magnitude, num);
				if (preventMovingBackwards)
				{
					float f = Mathf.Min(Mathf.Acos(Mathf.Clamp(num2, -1f, 1f)), (20f + 180f * (1f - speedLimitFactor * speedLimitFactor)) * (MathF.PI / 180f));
					float num4 = Mathf.Sin(f);
					float num5 = Mathf.Cos(f);
					num4 *= Mathf.Sign(vector.x * forward.y - vector.y * forward.x);
					return new Vector2(forward.x * num5 + forward.y * num4, forward.y * num5 - forward.x * num4) * magnitude;
				}
				return vector * magnitude;
			}
			return Vector2.ClampMagnitude(velocity, num);
		}

		public static Vector2 CalculateAccelerationToReachPoint(Vector2 deltaPosition, Vector2 targetVelocity, Vector2 currentVelocity, float forwardsAcceleration, float rotationSpeed, float maxSpeed, Vector2 forwardsVector)
		{
			if (forwardsAcceleration <= 0f)
			{
				return Vector2.zero;
			}
			float magnitude = currentVelocity.magnitude;
			float a = magnitude * rotationSpeed * (MathF.PI / 180f);
			a = Mathf.Max(a, forwardsAcceleration);
			deltaPosition = VectorMath.ComplexMultiplyConjugate(deltaPosition, forwardsVector);
			targetVelocity = VectorMath.ComplexMultiplyConjugate(targetVelocity, forwardsVector);
			currentVelocity = VectorMath.ComplexMultiplyConjugate(currentVelocity, forwardsVector);
			float num = 1f / (forwardsAcceleration * forwardsAcceleration);
			float num2 = 1f / (a * a);
			if (targetVelocity == Vector2.zero)
			{
				float num3 = 0.01f;
				float num4 = 10f;
				while (num4 - num3 > 0.01f)
				{
					float num5 = (num4 + num3) * 0.5f;
					Vector2 vector = (6f * deltaPosition - 4f * num5 * currentVelocity) / (num5 * num5);
					Vector2 vector2 = 6f * (num5 * currentVelocity - 2f * deltaPosition) / (num5 * num5 * num5);
					Vector2 vector3 = vector + vector2 * num5;
					if (vector.x * vector.x * num + vector.y * vector.y * num2 > 1f || vector3.x * vector3.x * num + vector3.y * vector3.y * num2 > 1f)
					{
						num3 = num5;
					}
					else
					{
						num4 = num5;
					}
				}
				Vector2 a2 = (6f * deltaPosition - 4f * num4 * currentVelocity) / (num4 * num4);
				a2.y *= 2f;
				float num6 = a2.x * a2.x * num + a2.y * a2.y * num2;
				if (num6 > 1f)
				{
					a2 /= Mathf.Sqrt(num6);
				}
				return VectorMath.ComplexMultiply(a2, forwardsVector);
			}
			float magnitude2;
			Vector2 vector4 = VectorMath.Normalize(targetVelocity, out magnitude2);
			float magnitude3 = deltaPosition.magnitude;
			Vector2 a3 = ((deltaPosition - vector4 * Math.Min(0.5f * magnitude3 * magnitude2 / (magnitude + magnitude2), maxSpeed * 1.5f)).normalized * maxSpeed - currentVelocity) * 10f;
			float num7 = a3.x * a3.x * num + a3.y * a3.y * num2;
			if (num7 > 1f)
			{
				a3 /= Mathf.Sqrt(num7);
			}
			return VectorMath.ComplexMultiply(a3, forwardsVector);
		}
	}
}
