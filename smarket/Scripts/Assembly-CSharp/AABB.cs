using System;
using Unity.Mathematics;
using UnityEngine;

public struct AABB : IEquatable<AABB>
{
	public float3 Min;

	public float3 Max;

	public static AABB FromBounds(Bounds bounds)
	{
		return default(AABB);
	}

	public static AABB FromCenterSize(float3 center, float3 size)
	{
		return default(AABB);
	}

	public static AABB FromMinMax(float3 min, float3 max)
	{
		return default(AABB);
	}

	public void Encapsulate(float3 point)
	{
	}

	public void Encapsulate(AABB bounds)
	{
	}

	public Bounds ToBounds()
	{
		return default(Bounds);
	}

	public bool Equals(AABB other)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}
}
