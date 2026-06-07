using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;

public class MathUtils
{
	public const float CONST_EPSILON = 1E-06f;

	public const float Rad2Deg = 57.29578f;

	public const float Deg2Rad = (float)Math.PI / 180f;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Clamp(float v, float min, float max)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float DistanceBetweenSqrd(float x1, float y1, float x2, float y2)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float DistanceBetween(float x1, float y1, float x2, float y2)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float AngleBetweenPoints(float2 p1, float2 p2)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool FuzzyEqual(float value, float target, float range = 0.0001f)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool FuzzyGreaterThan(float value, float target, float range = 0.0001f)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool FuzzyLessThan(float value, float target, float range = 0.0001f)
	{
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Min(float a, float b, float c, float d)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Max(float a, float b, float c, float d)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int CeilToIntClamped(float v, int minValue = -2147483648, int maxValue = 2147483647)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FloorToIntClamped(float v, int minValue = -2147483648, int maxValue = 2147483647)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int RoundToIntClamped(float v, int minValue = -2147483648, int maxValue = 2147483647)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float SubtractValueCapped(float baseValue, float valueToSubtract)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float AddValueCapped(float baseValue, float valueToAdd)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float FixFloatOverflowPositive(float value)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float TryFixNegativeFloat(float value)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Pow(int num, int exp)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
	public static int DivideRoundingUp(int a, int b)
	{
		return 0;
	}

	public static bool LineToLineIntersection(float2 startA, float2 endA, float2 startB, float2 endB, out float2 intersection)
	{
		intersection = default(float2);
		return false;
	}

	public static float2 RotateFloat2(float2 vector, float angleDegrees)
	{
		return default(float2);
	}

	public static int WrapInsideRange(int value, int range)
	{
		return 0;
	}

	public static float2 RandomPointInAnnulus(float2 origin, float minRadius, float maxRadius)
	{
		return default(float2);
	}

	public static bool IsInsideCircle(float x, float y, float radius, float pointX, float pointY)
	{
		return false;
	}

	public static float GetOverlapX(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		return 0f;
	}

	public static float GetOverlapY(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		return 0f;
	}

	public static bool SeparateX(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		return false;
	}

	public static bool SeparateY(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		return false;
	}

	public static float TileCheckX(Body body, PhaserTile tile, float tileLeft, float tileRight, float tileBias, bool isLayer)
	{
		return 0f;
	}

	private static void ProcessTileSeparationX(Body body, float x)
	{
	}

	public static float TileCheckY(Body body, PhaserTile tile, float tileTop, float tileBottom, float tileBias, bool isLayer)
	{
		return 0f;
	}

	private static void ProcessTileSeparationY(Body body, float y)
	{
	}
}
