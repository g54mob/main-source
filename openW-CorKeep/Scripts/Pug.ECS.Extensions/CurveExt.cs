using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public static class CurveExt
{
	public const float OneThird = 1f / 3f;

	public const float TwoThird = 2f / 3f;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Evaluate([NoAlias] this ref BlobAssetReference<BlobCurve> blob, in float time)
	{
		return blob.Value.Evaluate(in time);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EvaluateIgnoreWrapMode([NoAlias] this ref BlobAssetReference<BlobCurve> blob, in float time)
	{
		return blob.Value.EvaluateIgnoreWrapMode(in time);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Evaluate([NoAlias] this ref BlobCurveSampler sampler, in float time)
	{
		return sampler.Curve.Value.Evaluate(in time, ref sampler.Cache);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float EvaluateIgnoreWrapMode([NoAlias] this ref BlobCurveSampler sampler, in float time)
	{
		return sampler.Curve.Value.EvaluateIgnoreWrapMode(in time, ref sampler.Cache);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static WrapMode ToNative(this UnityEngine.WrapMode mode)
	{
		switch (mode)
		{
		default:
			return WrapMode.Clamp;
		case UnityEngine.WrapMode.Loop:
			return WrapMode.Loop;
		case UnityEngine.WrapMode.PingPong:
			return WrapMode.PingPong;
		case UnityEngine.WrapMode.Once:
		case UnityEngine.WrapMode.ClampForever:
			return WrapMode.Clamp;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float ModPlus([NoAlias] in float value, in float range)
	{
		float num = value % range;
		return math.select(num + range, num, num >= 0f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool Approximately([NoAlias] this in float value, in float equals)
	{
		return math.abs(value - equals) < 1.1921E-07f;
	}
}
