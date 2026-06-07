using System;
using System.Collections.Generic;
using UnityEngine;

public static class Mathk
{
	public const int kMaxInt = 2147483647;

	public const int kIndexNone = -2147483648;

	public const long kMaxLong = 9223372036854775807L;

	public const string kHexChars = "0123456789ABCDEF";

	public static System.Random RndGen;

	public const int kYearBasis = 2040;

	public const int kSecsInMin = 60;

	public const int kSecsInHour = 3600;

	public const int kSecsInDay = 86400;

	public const int kSecsInYear = 31536000;

	public const int kKLimit = 1000;

	public const int kMLimit = 1000000;

	public const int kBLimit = 1000000000;

	public const int kKDivisor = 1000;

	public const int kMDivisor = 1000000;

	public const int kBDivisor = 1000000000;

	private const float kSqrt2 = 1.4142135f;

	private const byte k_MaxByteForOverexposedColor = 191;

	public static float GetUnseededRandomNumber()
	{
		return 0f;
	}

	public static bool Passed(int prevVal, int newVal, int tgtVal)
	{
		return false;
	}

	public static int ModX(int toMod, int theMod)
	{
		return 0;
	}

	public static float ModX(float toMod, float theMod)
	{
		return 0f;
	}

	public static float ModTheta(float theta)
	{
		return 0f;
	}

	public static float DeltaTheta(float theta1, float theta2)
	{
		return 0f;
	}

	public static Vector3 Lerp2(Vector3 from, Vector3 to, float speed, float thresh)
	{
		return default(Vector3);
	}

	public static bool IsBetween(int n, int check1, int check2)
	{
		return false;
	}

	public static int Sign(float n)
	{
		return 0;
	}

	public static int RandomSignUnseeded()
	{
		return 0;
	}

	public static int RandomSign()
	{
		return 0;
	}

	public static float RandomValue(this System.Random r)
	{
		return 0f;
	}

	public static float RandomRange(this System.Random r, float min, float max)
	{
		return 0f;
	}

	public static int RandomRange(this System.Random r, int min, int max)
	{
		return 0;
	}

	public static int RandomSign(this System.Random r)
	{
		return 0;
	}

	public static int RandomIdx<T>(T[] arr, System.Random r)
	{
		return 0;
	}

	public static int RandomIdx<T>(List<T> arr, System.Random r)
	{
		return 0;
	}

	public static Vector2 UnseededRandomOnUnitCircle()
	{
		return default(Vector2);
	}

	public static Vector3 UnseededRandomOnUnitCircle3()
	{
		return default(Vector3);
	}

	public static float GetAngle(Vector2 v1, Vector2 v2)
	{
		return 0f;
	}

	public static Vector2 Rotate(this Vector2 v, float degrees)
	{
		return default(Vector2);
	}

	public static Vector2 RotateCardinal(this Vector2 v, int amt)
	{
		return default(Vector2);
	}

	public static bool IsAngleInBounds(float theta, float b1, float b2)
	{
		return false;
	}

	public static bool IsAngleInRadius(float theta, float center, float radius)
	{
		return false;
	}

	public static Vector2 Polar(float r, float theta)
	{
		return default(Vector2);
	}

	public static string ToRoman(int number)
	{
		return null;
	}

	public static float ClampAngle(float deg)
	{
		return 0f;
	}

	public static char GetHex(int i)
	{
		return '\0';
	}

	public static string RGBToHex(Color color)
	{
		return null;
	}

	public static string ApplyColorTag(string txt, Color color)
	{
		return null;
	}

	public static Color AddHue(Color c, float h)
	{
		return default(Color);
	}

	public static Color AddHSV(Color c, float h, float s, float v)
	{
		return default(Color);
	}

	public static int GetSecondOfDay(DateTime dt)
	{
		return 0;
	}

	public static int GetSecondOfYear(DateTime dt)
	{
		return 0;
	}

	public static int GetSecondsSince2040(DateTime dt)
	{
		return 0;
	}

	public static int GetSecondsSince2040()
	{
		return 0;
	}

	public static float GetDeltaTime(TimeSpan ts)
	{
		return 0f;
	}

	public static string FormatSeconds(float sec)
	{
		return null;
	}

	public static string FormatMilliseconds(int ms)
	{
		return null;
	}

	public static string FormatSeconds(int sec)
	{
		return null;
	}

	public static string FormatSecondsWithFraction(float sec)
	{
		return null;
	}

	public static string FormatDate(DateTime dt)
	{
		return null;
	}

	public static string FormatDate(int secsSince2040)
	{
		return null;
	}

	public static DateTime SecsToDateTime(int secsSince2040)
	{
		return default(DateTime);
	}

	private static int _Log2Int(long num, int exp)
	{
		return 0;
	}

	public static int Log2(long num)
	{
		return 0;
	}

	public static long Min(long l1, long l2)
	{
		return 0L;
	}

	public static long Max(long l1, long l2)
	{
		return 0L;
	}

	public static long Pow(long num, int exp)
	{
		return 0L;
	}

	public static long Pow2Long(int exp)
	{
		return 0L;
	}

	public static int Pow2(int exp)
	{
		return 0;
	}

	public static string GetTruncatedString(this int num, int margin = 1)
	{
		return null;
	}

	public static int RoundToNearestTruncation(int num)
	{
		return 0;
	}

	public static bool IsOverrideSatisfied(BoolOverride bOverride, bool checkBool)
	{
		return false;
	}

	public static float Round(float num, int numDigits)
	{
		return 0f;
	}

	public static float Round(float num, float roundingFactor)
	{
		return 0f;
	}

	public static int RoundToInt(float num, float roundingFactor)
	{
		return 0;
	}

	public static float Ceil(float num, float roundingFactor)
	{
		return 0f;
	}

	public static CardinalDir GetOpposite(this CardinalDir dir)
	{
		return default(CardinalDir);
	}

	public static Vector2 GetDirOffset(this CardinalDir dir)
	{
		return default(Vector2);
	}

	public static Vector2 GetDirOffset(this PrincipleDir dir)
	{
		return default(Vector2);
	}

	public static Vector2Int GetDirOffsetInt(this CardinalDir dir)
	{
		return default(Vector2Int);
	}

	public static CardinalDir GetClosestCardinalDir(Vector2 dir)
	{
		return default(CardinalDir);
	}

	public static bool IsVertical(this CardinalDir dir)
	{
		return false;
	}

	public static bool IsHorizontal(this CardinalDir dir)
	{
		return false;
	}

	public static PrincipleDir MirrorX(this PrincipleDir dir)
	{
		return default(PrincipleDir);
	}

	public static PrincipleDir GetOpposite(this PrincipleDir dir)
	{
		return default(PrincipleDir);
	}

	public static float PowLerp(float start, float tgt, float power, float pct)
	{
		return 0f;
	}

	public static float InvPowLerp(float start, float tgt, float power, float val)
	{
		return 0f;
	}

	public static Vector2 Scale(this Vector2 vec, float x, float y)
	{
		return default(Vector2);
	}

	public static Vector3 Scale(this Vector3 vec, float x, float y, float z)
	{
		return default(Vector3);
	}

	public static Vector2 Mirror(this Vector2 vec, bool mirrorX, bool mirrorY)
	{
		return default(Vector2);
	}

	public static Vector2 Mirror(this Vector2 vec, SpriteRenderer rend)
	{
		return default(Vector2);
	}

	public static Vector3 Mirror(this Vector3 vec, bool mirrorX, bool mirrorY)
	{
		return default(Vector3);
	}

	public static Vector3 Mirror(this Vector3 vec, SpriteRenderer rend)
	{
		return default(Vector3);
	}

	public static void Log(object msg)
	{
	}

	public static void LogStack(object msg)
	{
	}

	public static bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 intersection)
	{
		return false;
	}

	public static void DecomposeHdrColor(Color linearColorHdr, out Color32 baseLinearColor, out float exposure)
	{
		baseLinearColor = default(Color32);
		exposure = default(float);
	}

	public static Vector2 ToVector2(this Vector2Int v)
	{
		return default(Vector2);
	}

	public static float InverseLerpUnclamped(float min, float max, float val)
	{
		return 0f;
	}

	public static int GetNumDigits(this int n)
	{
		return 0;
	}
}
