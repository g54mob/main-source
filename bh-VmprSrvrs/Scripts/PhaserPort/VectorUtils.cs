using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public static class VectorUtils
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float3 ToFloat3(this float2 v)
	{
		return default(float3);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float3 ToFloat3(this float2 v, float vz)
	{
		return default(float3);
	}

	public static float2 setToPolar(this float2 v, float azimuth, float radius = 1f)
	{
		return default(float2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float2 RotatePoint(float2 target, float angle, float2 origin)
	{
		return default(float2);
	}

	public static float2 ToFloat2(this Vector2 v)
	{
		return default(float2);
	}

	public static float2 ToFloat2(this Vector3 v)
	{
		return default(float2);
	}

	public static Vector2 ToVector2(this Vector3 v)
	{
		return default(Vector2);
	}

	public static Vector2 ToVector2(this float2 v)
	{
		return default(Vector2);
	}

	public static Vector3 ToVector3(this Vector2 v)
	{
		return default(Vector3);
	}

	public static Vector3 ToVector3(this float2 v)
	{
		return default(Vector3);
	}

	public static void Set(this Vector2 v, double x, double y)
	{
	}
}
