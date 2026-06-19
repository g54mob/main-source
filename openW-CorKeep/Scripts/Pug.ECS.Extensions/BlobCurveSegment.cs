using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public struct BlobCurveSegment
{
	public float4 Factors;

	public static readonly float4x4 S_HermiteMat = math.float4x4(2f, 1f, 1f, -2f, -3f, -2f, -1f, 3f, 0f, 1f, 0f, 0f, 1f, 0f, 0f, 0f);

	public static readonly float4x4 S_BezierMat = math.float4x4(-1f, 3f, -3f, 1f, 3f, -6f, 3f, 0f, -3f, 3f, 0f, 0f, 1f, 0f, 0f, 0f);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float Sample(in float4 timeSerial)
	{
		return math.dot(Factors, timeSerial);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float4 PowerSerial(in float t)
	{
		float num = t * t;
		return math.float4(num * t, num, t, 1f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float4 UnityFactor(float v0, float t0, float t1, float v1, float duration)
	{
		return math.select(HermiteFactor(v0, t0 * duration, t1 * duration, v1), BezierFactor(v0, v0, v0, v0), math.isinf(t0) | math.isinf(t1));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float4 HermiteFactor(float v0, float m0, float m1, float v1)
	{
		return math.mul(S_HermiteMat, math.float4(v0, m0, m1, v1));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float4 BezierFactor(float p0, float p1, float p2, float p3)
	{
		return math.mul(S_BezierMat, math.float4(p0, p1, p2, p3));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float4 LinearFactor(float p0, float p3)
	{
		float num = (p3 - p0) * (1f / 3f);
		return BezierFactor(p0, p0 + num, p3 - num, p3);
	}

	public BlobCurveSegment(float4 factors)
	{
		Factors = factors;
	}

	public BlobCurveSegment(Keyframe k0, Keyframe k1)
	{
		this = Unity(k0.value, k0.outTangent, k1.inTangent, k1.value, k1.time - k0.time);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static BlobCurveSegment Unity(float v0, float tangent0, float tangent1, float v1, float duration)
	{
		return new BlobCurveSegment(UnityFactor(v0, tangent0, tangent1, v1, duration));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static BlobCurveSegment Hermite(float v0, float m0, float m1, float v1)
	{
		return new BlobCurveSegment(HermiteFactor(v0, m0, m1, v1));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static BlobCurveSegment Bezier(float p0, float p1, float p2, float p3)
	{
		return new BlobCurveSegment(BezierFactor(p0, p1, p2, p3));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static BlobCurveSegment Linear(float p0, float p3)
	{
		return new BlobCurveSegment(LinearFactor(p0, p3));
	}
}
