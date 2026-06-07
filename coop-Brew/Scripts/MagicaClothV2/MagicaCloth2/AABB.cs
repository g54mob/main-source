using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MagicaCloth2
{
	[Serializable]
	public struct AABB : IEquatable<AABB>
	{
		public float3 Min;

		public float3 Max;

		public float3 Extents => default(float3);

		public float3 HalfExtents => default(float3);

		public float3 Center => default(float3);

		public float MaxSideLength => 0f;

		public bool IsValid => false;

		public float SurfaceArea => 0f;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public AABB(in float3 min, in float3 max)
		{
			Min = default(float3);
			Max = default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AABB CreateFromCenterAndExtents(float3 center, float3 extents)
		{
			return default(AABB);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AABB CreateFromCenterAndHalfExtents(float3 center, float3 halfExtents)
		{
			return default(AABB);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(in float3 point)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Contains(in AABB aabb)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Overlaps(in AABB aabb)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Expand(float signedDistance)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(in AABB aabb)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encapsulate(in float3 point)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(AABB other)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Transform(in float4x4 toM)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
