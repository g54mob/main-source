using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public static class MathUtil
	{
		private const float APPROXIMATE_EPSILON = 0.0001f;

		private const float SNAP_EPSILON = 0.1f;

		public static readonly Vector3 VECTOR3_NAN = new Vector3(float.NaN, float.NaN, float.NaN);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetCorrectedLerp(float lerpAmount, float deltaTime, float fixedDeltaTime)
		{
			float num = 1f - lerpAmount;
			float y = deltaTime / fixedDeltaTime;
			return math.max(lerpAmount * (1f - math.pow(num, y)) / (1f - num), 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetOrtho(Vector3 v1, Vector3 v2)
		{
			return Vector3.Cross(v1, v2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximate(float a, float b)
		{
			return math.abs(a - b) < 0.0001f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximate(Vector3 a, Vector3 b)
		{
			if (Approximate(a.x, b.x) && Approximate(a.y, b.y))
			{
				return Approximate(a.z, b.z);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approximate(Quaternion a, Quaternion b)
		{
			if (Approximate(a.x, b.x) && Approximate(a.y, b.y) && Approximate(a.z, b.z))
			{
				return Approximate(a.w, b.w);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SetZeroIfNearZero(float v)
		{
			if (Approximate(v, 0f))
			{
				v = 0f;
			}
			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SetZeroIfNearZero(Vector3 v)
		{
			v.x = SetZeroIfNearZero(v.x);
			v.y = SetZeroIfNearZero(v.y);
			v.z = SetZeroIfNearZero(v.z);
			return v;
		}

		public static float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
		{
			return Vector3.Dot(Vector3.Cross(fwd, targetDir), up);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random GetRandom(int seed)
		{
			Unity.Mathematics.Random result = new Unity.Mathematics.Random((uint)seed);
			result.NextFloat();
			result.NextFloat();
			result.NextFloat();
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random GetRandom(int seed1, int seed2)
		{
			Unity.Mathematics.Random result = new Unity.Mathematics.Random((uint)Hash.Calculate(seed1, seed2));
			result.NextFloat();
			result.NextFloat();
			result.NextFloat();
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random GetRandom(int seed1, int seed2, int seed3)
		{
			Unity.Mathematics.Random result = new Unity.Mathematics.Random((uint)Hash.Calculate(seed1, seed2, seed3));
			result.NextFloat();
			result.NextFloat();
			result.NextFloat();
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random GetRandom(int seed1, int seed2, int seed3, int seed4)
		{
			Unity.Mathematics.Random result = new Unity.Mathematics.Random((uint)Hash.Calculate(seed1, seed2, seed3, seed4));
			result.NextFloat();
			result.NextFloat();
			result.NextFloat();
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DoesRayIntersectCircle(float2 rayOrigin, float2 rayDirection, float distance, float2 circlePos, float radius, out float hitDistance)
		{
			float num = radius * radius;
			if (math.lengthsq(rayOrigin - circlePos) <= num)
			{
				hitDistance = 0f;
				return true;
			}
			float2 x = circlePos - rayOrigin;
			float num2 = math.dot(x, rayDirection);
			float num3 = math.lengthsq(x);
			if (num2 < 0f && num3 > num)
			{
				hitDistance = 0f;
				return false;
			}
			float num4 = num3 - num2 * num2;
			if (num4 > num)
			{
				hitDistance = 0f;
				return false;
			}
			float num5 = math.sqrt(num - num4);
			return (hitDistance = ((!(num3 > num)) ? (num2 + num5) : (num2 - num5))) <= distance;
		}

		public static float SmoothDamp(float current, float target, ref float currentSpeed, float smoothTime, float maxSpeed = float.PositiveInfinity)
		{
			if (Approximate(Time.timeScale, 0f))
			{
				return current;
			}
			return Mathf.SmoothDamp(current, target, ref currentSpeed, smoothTime, maxSpeed);
		}

		public static float SmoothDampAngle(float current, float target, ref float currentSpeed, float smoothTime, float maxSpeed = float.PositiveInfinity)
		{
			if (Approximate(Time.timeScale, 0f))
			{
				return current;
			}
			return Mathf.SmoothDampAngle(current, target, ref currentSpeed, smoothTime, maxSpeed);
		}

		public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = float.PositiveInfinity)
		{
			if (Approximate(Time.timeScale, 0f))
			{
				return current;
			}
			return Vector3.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float RoundToIncrement(float value, float increment)
		{
			return math.round(value / increment) * increment;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 RoundToIncrement(Vector2 value, float increment)
		{
			value.x = RoundToIncrement(value.x, increment);
			value.y = RoundToIncrement(value.y, increment);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 RoundToIncrement(Vector3 value, float increment)
		{
			value.x = RoundToIncrement(value.x, increment);
			value.y = RoundToIncrement(value.y, increment);
			value.z = RoundToIncrement(value.z, increment);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CeilToIncrement(float value, float increment)
		{
			return math.ceil(value / increment) * increment;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float FloorToIncrement(float value, float increment)
		{
			return math.floor(value / increment) * increment;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SnapToward(float value, float dir)
		{
			if (dir > 0.1f)
			{
				return math.ceil(value);
			}
			if (dir < -0.1f)
			{
				return math.floor(value);
			}
			return math.round(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SnapToward(Vector3 value, Vector3 dir)
		{
			value.x = SnapToward(value.x, dir.x);
			value.y = SnapToward(value.y, dir.y);
			value.z = SnapToward(value.z, dir.z);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SnapTowardIncrement(float value, float dir, float increment)
		{
			if (dir > 0.1f)
			{
				return CeilToIncrement(value, increment);
			}
			if (dir < -0.1f)
			{
				return FloorToIncrement(value, increment);
			}
			return RoundToIncrement(value, increment);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SnapTowardIncrement(Vector3 value, Vector3 dir, float increment)
		{
			value.x = SnapTowardIncrement(value.x, dir.x, increment);
			value.y = SnapTowardIncrement(value.y, dir.y, increment);
			value.z = SnapTowardIncrement(value.z, dir.z, increment);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EncodeFloats16Precision(float a, float b)
		{
			return math.dot(y: new float2(1f, 1.5259022E-05f), x: new float2(math.floor(a * 65534f) / 65535f, math.floor(b * 65534f) / 65535f));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPowerOfTwo(uint number)
		{
			return (number & (number - 1)) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsPowerOfTwo(int number)
		{
			return (number & (number - 1)) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNan(Vector3 v)
		{
			if (!float.IsNaN(v.x) && !float.IsNaN(v.y))
			{
				return float.IsNaN(v.z);
			}
			return true;
		}

		public static Vector3 ZeroY(Vector3 v)
		{
			v.y = 0f;
			return v;
		}

		public static void GetBoxCorners(Vector3 position, Vector3 size, Quaternion rotation, out Vector3 c1, out Vector3 c2, out Vector3 c3, out Vector3 c4, out Vector3 c5, out Vector3 c6, out Vector3 c7, out Vector3 c8)
		{
			Vector3 vector = size / 2f;
			c1 = rotation * new Vector3(0f - vector.x, 0f - vector.y, 0f - vector.z) + position;
			c2 = rotation * new Vector3(0f - vector.x, vector.y, 0f - vector.z) + position;
			c3 = rotation * new Vector3(vector.x, vector.y, 0f - vector.z) + position;
			c4 = rotation * new Vector3(vector.x, 0f - vector.y, 0f - vector.z) + position;
			c5 = rotation * new Vector3(0f - vector.x, 0f - vector.y, vector.z) + position;
			c6 = rotation * new Vector3(0f - vector.x, vector.y, vector.z) + position;
			c7 = rotation * new Vector3(vector.x, vector.y, vector.z) + position;
			c8 = rotation * new Vector3(vector.x, 0f - vector.y, vector.z) + position;
		}

		public static void GetBoxCorners(Vector3 position, Vector3 size, Quaternion rotation, Vector3[] corners)
		{
			GetBoxCorners(position, size, rotation, out corners[0], out corners[1], out corners[2], out corners[3], out corners[4], out corners[5], out corners[6], out corners[7]);
		}
	}
}
