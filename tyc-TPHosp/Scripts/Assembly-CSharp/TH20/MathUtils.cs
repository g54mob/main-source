using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public static class MathUtils
	{
		public static float Log2 = Mathf.Log(2f);

		private const double SquareMagnitudeThresholdForSafeNormalize = 9.999999494757506E-11;

		public static readonly Vector3 XZPlane = new Vector3(1f, 0f, 1f);

		public static double RoundToNextMultiple(double input, double factor)
		{
			return Math.Round(input / factor, MidpointRounding.AwayFromZero) * factor;
		}

		public static float ProportionThroughRange(float value, float low, float high)
		{
			return (value - low) / (high - low);
		}

		public static bool IsInRange(float value, float min, float max)
		{
			if (value >= min)
			{
				return value <= max;
			}
			return false;
		}

		public static bool IsInRange(int value, int min, int max)
		{
			if (value >= min)
			{
				return value <= max;
			}
			return false;
		}

		public static int Mod(int x, int m)
		{
			return (x % m + m) % m;
		}

		public static Vector3 SetX(Vector3 v, float x)
		{
			return new Vector3(x, v.y, v.z);
		}

		public static Vector3 SetY(Vector3 v, float y)
		{
			return new Vector3(v.x, y, v.z);
		}

		public static Vector3 SetZ(Vector3 v, float z)
		{
			return new Vector3(v.x, v.y, z);
		}

		public static Vector3 SetXz(Vector3 v, float x, float z)
		{
			return new Vector3(x, v.y, z);
		}

		public static float Map(float value, float inputRangeA, float inputRangeB, float outputRangeA, float outputRangeB)
		{
			if (inputRangeA == inputRangeB)
			{
				return outputRangeA;
			}
			float t = Mathf.Clamp01((value - inputRangeA) / (inputRangeB - inputRangeA));
			return Mathf.Lerp(outputRangeA, outputRangeB, t);
		}

		public static float MapToUnary(float value, float inputRangeA, float inputRangeB)
		{
			return Map(value, inputRangeA, inputRangeB, 0f, 1f);
		}

		public static float MapFromUnary(float value, float outputRangeA, float outputRangeB)
		{
			return Map(value, 0f, 1f, outputRangeA, outputRangeB);
		}

		public static double Clamp(double value, double min, double max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		public static int Clamp(int value, int min, int max)
		{
			return Math.Min(Math.Max(min, value), max);
		}

		public static float ClampAngle(float angle, float min, float max)
		{
			if (angle >= 180f)
			{
				angle -= 360f;
			}
			if (angle <= -180f)
			{
				angle += 360f;
			}
			if (angle < min)
			{
				angle = min;
			}
			else if (angle > max)
			{
				angle = max;
			}
			return angle;
		}

		public static bool IsNaN(Vector3 value)
		{
			if (!float.IsNaN(value.x) && !float.IsNaN(value.y))
			{
				return float.IsNaN(value.z);
			}
			return true;
		}

		public static void Swap<T>(ref T lhs, ref T rhs)
		{
			T val = lhs;
			lhs = rhs;
			rhs = val;
		}

		public static float DistanceToRange(float value, float rangeMin, float rangeMax)
		{
			if (!(value < rangeMin))
			{
				if (!(value > rangeMax))
				{
					return 0f;
				}
				return value - rangeMax;
			}
			return rangeMin - value;
		}

		public static void CoalesceRanges(List<KeyValuePair<float, float>> ranges)
		{
			ranges.Sort((KeyValuePair<float, float> x, KeyValuePair<float, float> y) => x.Key.CompareTo(y.Key));
			for (int num = 0; num < ranges.Count - 1; num++)
			{
				if (ranges[num].Value > ranges[num + 1].Key)
				{
					ranges[num] = new KeyValuePair<float, float>(ranges[num].Key, Mathf.Max(ranges[num].Value, ranges[num + 1].Value));
					ranges.RemoveAt(num + 1);
					num--;
				}
			}
		}

		public static bool CanBeSafelyNormalized(Vector3 vec)
		{
			return (double)vec.sqrMagnitude >= 9.999999494757506E-11;
		}

		public static Vector3 NormalizeOrZeroIfUnsafe(Vector3 vec)
		{
			if (!CanBeSafelyNormalized(vec))
			{
				return Vector3.zero;
			}
			return vec.normalized;
		}

		public static bool ApproximatelyZero(float a)
		{
			return (double)Mathf.Abs(a) < 1E-05;
		}

		public static bool Approximately(float a, float b, float tolerance)
		{
			return Mathf.Abs(a - b) <= tolerance;
		}

		public static int Square(int value)
		{
			return value * value;
		}

		public static float Square(float value)
		{
			return value * value;
		}

		public static int Sqrt(int num)
		{
			if (num == 0)
			{
				return 0;
			}
			int num2 = num / 2 + 1;
			for (int num3 = (num2 + num / num2) / 2; num3 < num2; num3 = (num2 + num / num2) / 2)
			{
				num2 = num3;
			}
			return num2;
		}

		public static Vector3 NearestPointOnLine(Vector3 start, Vector3 end, Vector3 pnt)
		{
			Vector3 vector = end - start;
			float magnitude = vector.magnitude;
			vector.Normalize();
			float value = Vector3.Dot(pnt - start, vector);
			value = Mathf.Clamp(value, 0f, magnitude);
			return start + vector * value;
		}

		public static bool NearestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 linePoint1, Vector3 lineVector1, Vector3 linePoint2, Vector3 lineVector2, bool mustBeOnLines)
		{
			closestPointLine1 = Vector3.zero;
			closestPointLine2 = Vector3.zero;
			float num = Vector3.Dot(lineVector1, lineVector1);
			float num2 = Vector3.Dot(lineVector1, lineVector2);
			float num3 = Vector3.Dot(lineVector2, lineVector2);
			float num4 = num * num3 - num2 * num2;
			if (num4 != 0f)
			{
				Vector3 rhs = linePoint1 - linePoint2;
				float num5 = Vector3.Dot(lineVector1, rhs);
				float num6 = Vector3.Dot(lineVector2, rhs);
				float num7 = (num2 * num6 - num5 * num3) / num4;
				float num8 = (num * num6 - num5 * num2) / num4;
				if (mustBeOnLines && (num7 < 0f || num7 > 1f || num8 < 0f || num8 > 1f))
				{
					return false;
				}
				closestPointLine1 = linePoint1 + lineVector1 * num7;
				closestPointLine2 = linePoint2 + lineVector2 * num8;
				return true;
			}
			return false;
		}

		public static Vector3 MakeDirectionVector(float angleInDegrees)
		{
			float f = angleInDegrees * ((float)Math.PI / 180f);
			return new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f));
		}

		public static float YawRotation(Vector3 direction)
		{
			if (direction.sqrMagnitude > 0.01f)
			{
				return Quaternion.LookRotation(direction).eulerAngles.y;
			}
			return 0f;
		}

		public static float CalculateRangeModifier(float value, float min, float max, float multiplierBelow, float multiplierAbove, float stableValue)
		{
			if (value < min)
			{
				return (0f - (value - min)) * multiplierBelow;
			}
			if (value > max)
			{
				return (value - max) * multiplierAbove;
			}
			return stableValue;
		}

		public static float SigmoidFunction(float x)
		{
			return 1f / (1f + Mathf.Exp(0f - x));
		}

		public static float LogisiticFunction(float x, float v, float min, float max)
		{
			return (max - min) / (1f + Mathf.Exp((0f - v) * x)) + min;
		}

		public static bool LineLineIntersection(Vector2 p1, Vector2 dir1, Vector2 p2, Vector2 dir2, out Vector2 intersection)
		{
			if (Mathf.Abs(Mathf.Abs(Vector2.Dot(dir1, dir2)) - 1f) < Mathf.Epsilon)
			{
				intersection = Vector2.zero;
				return false;
			}
			Vector2 lhs = new Vector2(0f - dir1.y, dir1.x);
			float num = Vector2.Dot(lhs, p1 + dir1 * Vector2.Dot(p2 - p1, dir1) - p2) / Vector2.Dot(lhs, dir2);
			intersection = p2 + new Vector2(dir2.x * num, dir2.y * num);
			return true;
		}

		public static void SegmentSegmentIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, out bool linesIntersect, out bool segmentsIntersect, out Vector2 intersection, out Vector2 closeP1, out Vector2 closeP2)
		{
			float num = p2.x - p1.x;
			float num2 = p2.y - p1.y;
			float num3 = p4.x - p3.x;
			float num4 = p4.y - p3.y;
			float num5 = num2 * num3 - num * num4;
			float num6 = ((p1.x - p3.x) * num4 + (p3.y - p1.y) * num3) / num5;
			if (float.IsInfinity(num6))
			{
				linesIntersect = false;
				segmentsIntersect = false;
				intersection = new Vector2(float.NaN, float.NaN);
				closeP1 = new Vector2(float.NaN, float.NaN);
				closeP2 = new Vector2(float.NaN, float.NaN);
				return;
			}
			float num7 = ((p3.x - p1.x) * num2 + (p1.y - p3.y) * num) / (0f - num5);
			linesIntersect = true;
			intersection = new Vector2(p1.x + num * num6, p1.y + num2 * num6);
			segmentsIntersect = num6 >= 0f && num6 <= 1f && num7 >= 0f && num7 <= 1f;
			if (num6 < 0f)
			{
				num6 = 0f;
			}
			else if (num6 > 1f)
			{
				num6 = 1f;
			}
			if (num7 < 0f)
			{
				num7 = 0f;
			}
			else if (num7 > 1f)
			{
				num7 = 1f;
			}
			closeP1 = new Vector2(p1.x + num * num6, p1.y + num2 * num6);
			closeP2 = new Vector2(p3.x + num3 * num7, p3.y + num4 * num7);
		}

		public static bool PosIsInTriangleXZ(Vector3 p, Vector3 p0, Vector3 p1, Vector3 p2)
		{
			float num = 0.5f * ((0f - p1.z) * p2.x + p0.z * (0f - p1.x + p2.x) + p0.x * (p1.z - p2.z) + p1.x * p2.z);
			int num2 = ((!(num < 0f)) ? 1 : (-1));
			float num3 = (p0.z * p2.x - p0.x * p2.z + (p2.z - p0.z) * p.x + (p0.x - p2.x) * p.z) * (float)num2;
			float num4 = (p0.x * p1.z - p0.z * p1.x + (p0.z - p1.z) * p.x + (p1.x - p0.x) * p.z) * (float)num2;
			if (num3 > 0f && num4 > 0f)
			{
				return num3 + num4 < 2f * num * (float)num2;
			}
			return false;
		}

		public static float InterpolateTo(float start, float end, float rate, float deltaTime)
		{
			float a = start + (end - start) * deltaTime * rate;
			if (!(end >= start))
			{
				return Mathf.Max(a, end);
			}
			return Mathf.Min(a, end);
		}

		public static float VolumeFractionToDecibelFraction(float volume, float minDecibel, float maxDecibel)
		{
			float num = Mathf.Pow(10f, minDecibel / 20f);
			float num2 = Mathf.Pow(10f, maxDecibel / 20f);
			float num3 = num + volume * (num2 - num);
			if (num3 <= 0f)
			{
				return -80f;
			}
			return Mathf.Clamp(20f * Mathf.Log10(num3), minDecibel, maxDecibel);
		}

		public static Rect CalculateRectFromTriangleXZ(Vector3 p0, Vector3 p1, Vector3 p2)
		{
			float x = p0.x;
			float z = p0.z;
			float x2 = p0.x;
			float z2 = p0.z;
			if (p1.x < x)
			{
				x = p1.x;
			}
			if (p2.x < x)
			{
				x = p2.x;
			}
			if (p1.z < z)
			{
				z = p1.z;
			}
			if (p2.z < z)
			{
				z = p2.z;
			}
			if (p1.x > x2)
			{
				x2 = p1.x;
			}
			if (p2.x > x2)
			{
				x2 = p2.x;
			}
			if (p1.z > z2)
			{
				z2 = p1.z;
			}
			if (p2.z > z2)
			{
				z2 = p2.z;
			}
			return new Rect(x, z, x2 - x, z2 - z);
		}
	}
}
