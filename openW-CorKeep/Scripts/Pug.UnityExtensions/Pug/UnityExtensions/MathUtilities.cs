using System;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class MathUtilities
	{
		public static class Float3
		{
			public static readonly float3 up = new float3(0f, 1f, 0f);

			public static readonly float3 forward = new float3(0f, 0f, 1f);
		}

		public const float Ef = MathF.E;

		public const double Ed = Math.E;

		private static readonly float3 backF3 = new float3(0f, 0f, -1f);

		private static readonly float3 forwardF3 = new float3(0f, 0f, 1f);

		private static readonly float3 leftF3 = new float3(-1f, 0f, 0f);

		private static readonly float3 rightF3 = new float3(1f, 0f, 0f);

		public static int Negmod(int k, int n)
		{
			return (k % n + n) % n;
		}

		public static float SteepSine(float x, float elevation)
		{
			float f = Mathf.Sin(x);
			return Mathf.Sign(f) * (1f - Mathf.Exp((0f - Mathf.Abs(f)) * elevation));
		}

		public static float SteepCosine(float x, float elevation)
		{
			float f = Mathf.Cos(x);
			return Mathf.Sign(f) * (1f - Mathf.Exp((0f - Mathf.Abs(f)) * elevation));
		}

		public static int Clamp(int x, int low, int high)
		{
			if (x < low)
			{
				x = low;
			}
			if (x > high)
			{
				x = high;
			}
			return x;
		}

		public static float NearestFloorMultipleOf(float number, float multiple)
		{
			bool num = number < 0f;
			if (num)
			{
				number = 0f - number;
			}
			number = Mathf.Floor(number / multiple) * multiple;
			if (num)
			{
				number = 0f - number;
			}
			return number;
		}

		public static float NearestMultipleOf(float number, float multiple)
		{
			bool num = number < 0f;
			if (num)
			{
				number = 0f - number;
			}
			number = Mathf.Round(number / multiple) * multiple;
			if (num)
			{
				number = 0f - number;
			}
			return number;
		}

		public static double NearestFloorMultipleOf(double number, double multiple)
		{
			bool num = number < 0.0;
			if (num)
			{
				number = 0.0 - number;
			}
			number = Math.Floor(number / multiple) * multiple;
			if (num)
			{
				number = 0.0 - number;
			}
			return number;
		}

		public static double NearestMultipleOf(double number, double multiple)
		{
			bool num = number < 0.0;
			if (num)
			{
				number = 0.0 - number;
			}
			number = Math.Round(number / multiple) * multiple;
			if (num)
			{
				number = 0.0 - number;
			}
			return number;
		}

		internal static float PseudoLog01(float x)
		{
			x = Mathf.Clamp01(x);
			return 2f - 2f / (1f + x);
		}

		public static float Pow01(float x, float k = MathF.E)
		{
			return (Mathf.Pow(k, Mathf.Clamp01(x)) - 1f) / (k - 1f);
		}

		public static float Pow01Mirrored(float x, float k = MathF.E)
		{
			if (!(x < 0f))
			{
				return Pow01(x, k);
			}
			return 0f - Pow01(0f - x, k);
		}

		public static float StepifyValue(float x, float steps)
		{
			return Mathf.Round(x * steps) / steps;
		}

		public static Vector2 CurveFilterOnNonDominantAxis(Vector2 vector, AnimationCurve animationCurve)
		{
			float num = vector.x;
			float num2 = vector.y;
			float num3 = Mathf.Abs(num);
			float num4 = Mathf.Abs(num2);
			bool flag = num3 > num4;
			if (flag ? (num3 > Mathf.Epsilon) : (num4 > Mathf.Epsilon))
			{
				float time = (flag ? (num4 / num3) : (num3 / num4));
				float value = animationCurve.Evaluate(time);
				value = Mathf.Clamp01(value);
				if (flag)
				{
					num2 *= value;
				}
				else
				{
					num *= value;
				}
			}
			return new Vector2(num, num2);
		}

		public static float SinRamp01(float x, float maxX = 1f)
		{
			x /= maxX;
			x *= MathF.PI / 2f;
			return Mathf.Clamp01(Mathf.Sin(x));
		}

		public static float Angle(float2 x, float2 y)
		{
			return math.acos(math.dot(math.normalize(x), math.normalize(y)));
		}

		public static bool LinesIntersect(float2 a, float2 b, float2 c, float2 d)
		{
			float2 float5 = new float2(c.x - a.x, c.y - a.y);
			float2 float6 = new float2(b.x - a.x, b.y - a.y);
			float2 float7 = new float2(d.x - c.x, d.y - c.y);
			float num = float5.x * float6.y - float5.y * float6.x;
			float num2 = float5.x * float7.y - float5.y * float7.x;
			float num3 = float6.x * float7.y - float6.y * float7.x;
			if (math.abs(num) < 0.0001f)
			{
				if (c.x - a.x < -0.0001f == c.x - b.x < -0.0001f)
				{
					return c.y - a.y < -0.0001f != c.y - b.y < -0.0001f;
				}
				return true;
			}
			if (math.abs(num3) < 0.0001f)
			{
				return false;
			}
			float num4 = 1f / num3;
			float num5 = num2 * num4;
			float num6 = num * num4;
			if (num5 >= 0.0001f && num5 <= 0.9999f && num6 >= 0.0001f)
			{
				return num6 <= 0.9999f;
			}
			return false;
		}

		public static bool PointIsWithinCircle(float2 point, float2 center, float radius)
		{
			return math.distancesq(center, point) <= radius * radius;
		}

		public static bool IntersectsCircle(float2 a, float2 b, float2 center, float radius)
		{
			if (math.all(a == b))
			{
				return PointIsWithinCircle(a, center, radius);
			}
			float2 float5 = b - a;
			float valueToClamp = math.dot(center - a, float5) / math.dot(float5, float5);
			valueToClamp = math.clamp(valueToClamp, 0f, 1f);
			float2 float6 = a + valueToClamp * float5;
			return math.lengthsq(center - float6) <= radius * radius;
		}

		public static bool NextPosOnLine(int2 start, int2 end, ref int2 pos)
		{
			if (math.all(pos == end))
			{
				return false;
			}
			float num = ((end.x == start.x) ? float.PositiveInfinity : math.abs((float)(end.y - start.y) / (float)(end.x - start.x)));
			int2 int5 = pos - end;
			float num2 = ((int5.x == 0) ? float.PositiveInfinity : math.abs((float)int5.y / (float)int5.x));
			int2 int6 = math.select(math.select((int2)0, (int2)1, int5 < 0), -1, int5 > 0);
			if (math.all(int6 == 0))
			{
				return false;
			}
			if (num < num2)
			{
				pos.y += int6.y;
			}
			else if (num > num2 || num < 1f)
			{
				pos.x += int6.x;
			}
			else
			{
				pos.y += int6.y;
			}
			return true;
		}

		public static float SquiggleNoise(float pointOnLine, float period, float freq, uint seed = 0u)
		{
			return noise.pnoise(new float2(pointOnLine * freq, seed), new float2(period * freq, 4.2949673E+09f));
		}

		public static void Rol(this ref ulong ul)
		{
			ul.Rol(1);
		}

		public static void Rol(this ref ulong ul, int N)
		{
			ul = (ul << N) | (ul >> 64 - N);
		}

		public static void Ror(this ref ulong ul)
		{
			ul.Ror(1);
		}

		public static void Ror(this ref ulong ul, int N)
		{
			ul = (ul << 64 - N) | (ul >> N);
		}

		public static void Rol(this ref uint ul)
		{
			ul.Rol(1);
		}

		public static void Rol(this ref uint ul, int N)
		{
			ul = (ul << N) | (ul >> 32 - N);
		}

		public static void Ror(this ref uint ul)
		{
			ul.Ror(1);
		}

		public static void Ror(this ref uint ul, int N)
		{
			ul = (ul << 32 - N) | (ul >> N);
		}

		public static float3 DominantSideF3(float3 dir)
		{
			float num = math.abs(dir.x);
			float num2 = math.abs(dir.z);
			if (num + num2 <= 1E-05f)
			{
				return float3.zero;
			}
			if (num >= num2)
			{
				if (dir.x > 0f)
				{
					return rightF3;
				}
				return leftF3;
			}
			if (dir.z > 0f)
			{
				return forwardF3;
			}
			return backF3;
		}

		public static ulong BinomialCoefficient(int n, int k)
		{
			ulong num = (ulong)n;
			ulong num2 = (ulong)k;
			ulong num3 = 1uL;
			if (k > n)
			{
				return 0uL;
			}
			for (ulong num4 = 1uL; num4 <= num2; num4++)
			{
				num3 *= num--;
				num3 /= num4;
			}
			return num3;
		}

		public static float3 YAxisLerp(float3 currentDirection, float3 targetDirection, float t, float maxRotationStepDegrees = 180f)
		{
			currentDirection.y = 0f;
			if (math.all(currentDirection == default(float3)))
			{
				currentDirection = Float3.forward;
			}
			float3 float5 = targetDirection;
			float5.y = 0f;
			if (math.all(float5 == default(float3)))
			{
				float5 = Float3.forward;
			}
			float num = 0f - math.sign(currentDirection.x * float5.z - currentDirection.z * float5.x);
			float x = math.clamp(math.degrees(math.acos(math.clamp(math.dot(math.normalize(currentDirection), math.normalize(float5)), -1f, 1f))) * num * t, 0f - maxRotationStepDegrees, maxRotationStepDegrees);
			quaternion q = math.mul(b: quaternion.LookRotation(new float3(currentDirection.x, currentDirection.y, currentDirection.z), Float3.up), a: quaternion.RotateY(math.radians(x)));
			return math.mul(q, Float3.forward);
		}

		public static float3 YAxisRotation(float3 currentDirection, float3 targetDirection, float rotationSpeedDegrees)
		{
			return YAxisLerp(currentDirection, targetDirection, 1f, rotationSpeedDegrees);
		}

		public static Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			float knotInterval = GetKnotInterval(p0, p1, 0.5f);
			float num = GetKnotInterval(p1, p2, 0.5f) + knotInterval;
			float b = GetKnotInterval(p2, p3, 0.5f) + num;
			float u = Mathf.LerpUnclamped(knotInterval, num, t);
			Vector3 c = Remap(0f, knotInterval, p0, p1, u);
			Vector3 vector = Remap(knotInterval, num, p1, p2, u);
			Vector3 d = Remap(num, b, p2, p3, u);
			Vector3 c2 = Remap(0f, num, c, vector, u);
			Vector3 d2 = Remap(knotInterval, b, vector, d, u);
			return Remap(knotInterval, num, c2, d2, u);
		}

		private static Vector3 Remap(float a, float b, Vector3 c, Vector3 d, float u)
		{
			return Vector3.LerpUnclamped(c, d, (u - a) / (b - a));
		}

		private static float GetKnotInterval(Vector3 a, Vector3 b, float alpha)
		{
			return Mathf.Pow(Vector3.SqrMagnitude(a - b), 0.5f * alpha);
		}

		public static void GetAutoCurveEnds(Vector3[] curvePoints, out Vector3 startPoint, out Vector3 endPoint)
		{
			int num = curvePoints.Length - 1;
			Vector3 inDirection = curvePoints[2] - curvePoints[1];
			Vector3 normalized = (curvePoints[1] - curvePoints[0]).normalized;
			startPoint = curvePoints[0] + Vector3.Reflect(inDirection, normalized);
			Vector3 inDirection2 = curvePoints[num - 2] - curvePoints[num - 1];
			Vector3 normalized2 = (curvePoints[num - 1] - curvePoints[num]).normalized;
			endPoint = curvePoints[num] + Vector3.Reflect(inDirection2, normalized2);
		}

		public static Vector3 GetPointOnCurve(Vector3[] curvePoints, Vector3 startPoint, Vector3 endPoint, int i, float t)
		{
			Vector3 p = ((i > 0) ? curvePoints[i - 1] : startPoint);
			Vector3 p2 = curvePoints[i];
			Vector3 p3 = curvePoints[i + 1];
			Vector3 p4 = ((i + 2 < curvePoints.Length) ? curvePoints[i + 2] : endPoint);
			return CatmullRom(p, p2, p3, p4, t);
		}

		public static Vector3 GetPointOnCurve(Vector3[] curvePoints, float[] distToNextPoint, float totalLength, Vector3 startPoint, Vector3 endPoint, float t)
		{
			int num = curvePoints.Length;
			if (distToNextPoint.Length < num - 1)
			{
				Debug.LogError($"distToNextPoint has too few elements! (was {distToNextPoint.Length}, need {num - 1})");
				return default(Vector3);
			}
			float num2 = totalLength * t;
			float num3 = 0f;
			for (int i = 0; i < num - 1; i++)
			{
				float num4 = num3 + distToNextPoint[i];
				if (num4 > num2)
				{
					float t2 = (num2 - num3) / (num4 - num3);
					return GetPointOnCurve(curvePoints, startPoint, endPoint, i, t2);
				}
				num3 = num4;
			}
			return curvePoints[num - 1];
		}

		public static float powCos(float x, float e)
		{
			float x2 = math.cos(x);
			return math.sign(x2) * (1f - math.pow(1f - math.abs(x2), 2f));
		}

		public static float powSin(float x, float e)
		{
			float x2 = math.sin(x);
			return math.sign(x2) * (1f - math.pow(1f - math.abs(x2), 2f));
		}

		public static double powCos(double x, double e)
		{
			double x2 = math.cos(x);
			return math.sign(x2) * (1.0 - math.pow(1.0 - math.abs(x2), 2.0));
		}

		public static double powSin(double x, double e)
		{
			double x2 = math.sin(x);
			return math.sign(x2) * (1.0 - math.pow(1.0 - math.abs(x2), 2.0));
		}
	}
}
