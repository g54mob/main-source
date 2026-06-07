using System;
using UnityEngine;

namespace Rewired.Utils
{
	public class MathTools
	{
		private const float kXNtNXNUOfuFbmPjqjtgMLwaolFj = 1E-10f;

		private const double ZtrKCkOBtxBKlPKXXydlGLoCjeFBA = 1E-10;

		private const float wXBQfeqjPtBvJHsxyyUTBfUNkVPxA = 0.0001f;

		public const float PI = (float)Math.PI;

		public const float Infinity = float.PositiveInfinity;

		public const float NegativeInfinity = float.NegativeInfinity;

		public const float Deg2Rad = (float)Math.PI / 180f;

		public const float Rad2Deg = 57.29578f;

		public const float Epsilon = float.Epsilon;

		public static sbyte Abs(sbyte value)
		{
			return 0;
		}

		public static short Abs(short value)
		{
			return 0;
		}

		public static int Abs(int value)
		{
			return 0;
		}

		public static long Abs(long value)
		{
			return 0L;
		}

		public static float Abs(float value)
		{
			return 0f;
		}

		public static double Abs(double value)
		{
			return 0.0;
		}

		public static bool Approximately(float a, float b)
		{
			return false;
		}

		public static bool ApproximatelyZero(float a)
		{
			return false;
		}

		public static bool IsZero(float value)
		{
			return false;
		}

		public static bool IsZero(float value, float threshold)
		{
			return false;
		}

		public static bool IsZero(double value)
		{
			return false;
		}

		public static bool IsZero(double value, double threshold)
		{
			return false;
		}

		public static bool IsExactlyEqual(float a, float b)
		{
			return false;
		}

		public static bool IsExactlyEqual(double a, double b)
		{
			return false;
		}

		public static bool IsNear(float value, float targetValue)
		{
			return false;
		}

		public static bool IsNear(float value, float targetValue, float threshold)
		{
			return false;
		}

		public static bool IsNearZero(float value)
		{
			return false;
		}

		public static bool IsNearZero(float value, float threshold)
		{
			return false;
		}

		public static bool IsNearOrWholeNumber(float value)
		{
			return false;
		}

		public static bool IsNearOrWholeNumber(float value, float threshold)
		{
			return false;
		}

		public static bool IsNearOrWholeNumber(float value, out int number)
		{
			number = default(int);
			return false;
		}

		public static bool IsNearOrWholeNumber(float value, out int number, float threshold)
		{
			number = default(int);
			return false;
		}

		public static float RoundOffIfNearWholeNumber(float value)
		{
			return 0f;
		}

		public static float RoundOffIfNearWholeNumber(float value, float threshold)
		{
			return 0f;
		}

		public static bool IsEven(int value)
		{
			return false;
		}

		public static float ValueInNewRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax)
		{
			return 0f;
		}

		public static int ValueInNewRange(int oldValue, int oldMin, int oldMax, int newMin, int newMax)
		{
			return 0;
		}

		public static sbyte Max(sbyte a, sbyte b)
		{
			return 0;
		}

		public static byte Max(byte a, byte b)
		{
			return 0;
		}

		public static short Max(short a, short b)
		{
			return 0;
		}

		public static ushort Max(ushort a, ushort b)
		{
			return 0;
		}

		public static int Max(int a, int b)
		{
			return 0;
		}

		public static uint Max(uint a, uint b)
		{
			return 0u;
		}

		public static long Max(long a, long b)
		{
			return 0L;
		}

		public static ulong Max(ulong a, ulong b)
		{
			return 0uL;
		}

		public static float Max(float a, float b)
		{
			return 0f;
		}

		public static double Max(double a, double b)
		{
			return 0.0;
		}

		public static sbyte Min(sbyte a, sbyte b)
		{
			return 0;
		}

		public static byte Min(byte a, byte b)
		{
			return 0;
		}

		public static short Min(short a, short b)
		{
			return 0;
		}

		public static ushort Min(ushort a, ushort b)
		{
			return 0;
		}

		public static int Min(int a, int b)
		{
			return 0;
		}

		public static uint Min(uint a, uint b)
		{
			return 0u;
		}

		public static long Min(long a, long b)
		{
			return 0L;
		}

		public static ulong Min(ulong a, ulong b)
		{
			return 0uL;
		}

		public static float Min(float a, float b)
		{
			return 0f;
		}

		public static double Min(double a, double b)
		{
			return 0.0;
		}

		public static sbyte MaxMagnitude(sbyte a, sbyte b)
		{
			return 0;
		}

		public static byte MaxMagnitude(byte a, byte b)
		{
			return 0;
		}

		public static short MaxMagnitude(short a, short b)
		{
			return 0;
		}

		public static ushort MaxMagnitude(ushort a, ushort b)
		{
			return 0;
		}

		public static int MaxMagnitude(int a, int b)
		{
			return 0;
		}

		public static uint MaxMagnitude(uint a, uint b)
		{
			return 0u;
		}

		public static long MaxMagnitude(long a, long b)
		{
			return 0L;
		}

		public static ulong MaxMagnitude(ulong a, ulong b)
		{
			return 0uL;
		}

		public static float MaxMagnitude(float a, float b)
		{
			return 0f;
		}

		public static double MaxMagnitude(double a, double b)
		{
			return 0.0;
		}

		public static sbyte MinMagnitude(sbyte a, sbyte b)
		{
			return 0;
		}

		public static byte MinMagnitude(byte a, byte b)
		{
			return 0;
		}

		public static short MinMagnitude(short a, short b)
		{
			return 0;
		}

		public static ushort MinMagnitude(ushort a, ushort b)
		{
			return 0;
		}

		public static int MinMagnitude(int a, int b)
		{
			return 0;
		}

		public static uint MinMagnitude(uint a, uint b)
		{
			return 0u;
		}

		public static long MinMagnitude(long a, long b)
		{
			return 0L;
		}

		public static ulong MinMagnitude(ulong a, ulong b)
		{
			return 0uL;
		}

		public static float MinMagnitude(float a, float b)
		{
			return 0f;
		}

		public static double MinMagnitude(double a, double b)
		{
			return 0.0;
		}

		public static bool IsMoreMagnitudeOrEqual(sbyte a, sbyte b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(byte a, byte b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(short a, short b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(ushort a, ushort b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(int a, int b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(uint a, uint b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(long a, long b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(ulong a, ulong b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(float a, float b)
		{
			return false;
		}

		public static bool IsMoreMagnitudeOrEqual(double a, double b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(sbyte a, sbyte b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(byte a, byte b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(short a, short b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(ushort a, ushort b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(int a, int b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(uint a, uint b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(long a, long b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(ulong a, ulong b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(float a, float b)
		{
			return false;
		}

		public static bool IsLessMagnitudeOrEqual(double a, double b)
		{
			return false;
		}

		public static byte Clamp(byte value, byte min, byte max)
		{
			return 0;
		}

		public static sbyte Clamp(sbyte value, sbyte min, sbyte max)
		{
			return 0;
		}

		public static short Clamp(short value, short min, short max)
		{
			return 0;
		}

		public static ushort Clamp(ushort value, ushort min, ushort max)
		{
			return 0;
		}

		public static int Clamp(int value, int min, int max)
		{
			return 0;
		}

		public static uint Clamp(uint value, uint min, uint max)
		{
			return 0u;
		}

		public static long Clamp(long value, long min, long max)
		{
			return 0L;
		}

		public static ulong Clamp(ulong value, ulong min, ulong max)
		{
			return 0uL;
		}

		public static float Clamp(float value, float min, float max)
		{
			return 0f;
		}

		public static double Clamp(double value, double min, double max)
		{
			return 0.0;
		}

		public static float Clamp01(float value)
		{
			return 0f;
		}

		public static float ClampAngle360(float angle)
		{
			return 0f;
		}

		public static float ReverseAngleRotationDirection(float angle)
		{
			return 0f;
		}

		public static bool AngleIsNear(float angle, float targetAngle, float threshold)
		{
			return false;
		}

		public static bool AngleIsBetween(float angle, float min, float max)
		{
			return false;
		}

		internal static bool nrWVfWdyjLFcLcXwwhMVqwbJJzeA(int P_0, int P_1)
		{
			return false;
		}

		public static int IntPow(int x, uint pow)
		{
			return 0;
		}

		public static uint RoundUpToPowerOf2(uint value)
		{
			return 0u;
		}

		public static float BooleanToSign(bool b)
		{
			return 0f;
		}

		public static bool SignToBoolean(float sign)
		{
			return false;
		}

		public static float Sin(float value)
		{
			return 0f;
		}

		public static float Cos(float value)
		{
			return 0f;
		}

		public static float Tan(float value)
		{
			return 0f;
		}

		public static float Asin(float value)
		{
			return 0f;
		}

		public static float Acos(float value)
		{
			return 0f;
		}

		public static float Atan(float value)
		{
			return 0f;
		}

		public static float Atan2(float y, float x)
		{
			return 0f;
		}

		public static float Sqrt(float value)
		{
			return 0f;
		}

		public static float Pow(float value, float p)
		{
			return 0f;
		}

		public static float Exp(float power)
		{
			return 0f;
		}

		public static float Log(float value, float p)
		{
			return 0f;
		}

		public static float Log(float value)
		{
			return 0f;
		}

		public static float Log10(float value)
		{
			return 0f;
		}

		public static float Ceil(float value)
		{
			return 0f;
		}

		public static float Floor(float value)
		{
			return 0f;
		}

		public static float Round(float value)
		{
			return 0f;
		}

		public static int CeilToInt(float value)
		{
			return 0;
		}

		public static int FloorToInt(float value)
		{
			return 0;
		}

		public static int RoundToInt(float value)
		{
			return 0;
		}

		public static float Sign(float value)
		{
			return 0f;
		}

		public static int Sign(int value)
		{
			return 0;
		}

		public static float Repeat(float t, float length)
		{
			return 0f;
		}

		public static float DeltaAngle(float current, float target)
		{
			return 0f;
		}

		public static Vector2 MaxMagnitude(Vector2 a, Vector2 b)
		{
			return default(Vector2);
		}

		public static Vector3 MaxMagnitude(Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}

		public static Vector2 MinMagnitude(Vector2 a, Vector2 b)
		{
			return default(Vector2);
		}

		public static Vector3 MinMagnitude(Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}

		public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
		{
			return default(Vector2);
		}

		public static Vector2 Clamp(Vector2 value, float min, float max)
		{
			return default(Vector2);
		}

		public static Vector2 Clamp(Vector3 value, Vector3 min, Vector3 max)
		{
			return default(Vector2);
		}

		public static Vector2 Clamp(Vector3 value, float min, float max)
		{
			return default(Vector2);
		}

		public static float Cross(Vector2 a, Vector2 b)
		{
			return 0f;
		}

		public static float Multiply(Vector2 a, Vector2 b)
		{
			return 0f;
		}

		public static bool RectContains(Rect rect, Vector2 pos, float rotation = 0f)
		{
			return false;
		}

		public static Vector2 RotateWorldPoint(Vector2 point, Vector2 center, float angle)
		{
			return default(Vector2);
		}

		public static Vector2 RotateLocalPoint(Vector2 point, float angle)
		{
			return default(Vector2);
		}

		public static bool LineIntersectsRect(Vector2 point1, Vector2 point2, Rect rect, out float sqrMagnitude)
		{
			sqrMagnitude = default(float);
			return false;
		}

		public static bool LineSegementsIntersect(Vector2 line1p1, Vector2 line1p2, Vector2 line2p1, Vector2 line2p2, out Vector2 intersection, bool collinearIntersects = false)
		{
			intersection = default(Vector2);
			return false;
		}

		private static bool WUAtnzCayAlVjdDMuMQeckmIYEyS(Vector2 P_0, Vector2 P_1, Vector2 P_2, Vector2 P_3, out Vector2 P_4)
		{
			P_4 = default(Vector2);
			return false;
		}

		public static bool RectContains(Rect container, Rect child)
		{
			return false;
		}

		public static bool GetOffsetToContainRect(Rect container, Rect child, out Vector2 offset)
		{
			offset = default(Vector2);
			return false;
		}

		public static Matrix4x4 TransformTo(Transform from, Transform to)
		{
			return default(Matrix4x4);
		}

		public static Rect TransformRect(Rect fromRect, Transform from, Transform to)
		{
			return default(Rect);
		}

		public static Vector2 SnapVectorToNearestAngle(Vector2 vector, float angle)
		{
			return default(Vector2);
		}

		public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
		{
			return 0f;
		}
	}
}
