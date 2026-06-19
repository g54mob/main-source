using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct BlobCurve
{
	public struct CurveHeader
	{
		[NoAlias]
		public WrapMode WrapModePrev;

		[NoAlias]
		public WrapMode WrapModePost;

		[NoAlias]
		public int SegmentCount;

		[NoAlias]
		public float StartTime;

		[NoAlias]
		public float EndTime;

		[NoAlias]
		public BlobArray<float> Times;

		public float Duration => EndTime - StartTime;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe int SearchIgnoreWrapMode(in float time, [NoAlias] ref BlobCurveCache cache, [NoAlias] out float t)
		{
			float num = math.clamp(time, StartTime, EndTime);
			bool flag = num < cache.NeighborhoodTimes.x;
			bool flag2 = num > cache.NeighborhoodTimes.y;
			float num2;
			if (cache.Index >= 0 && !(flag || flag2))
			{
				num2 = cache.NeighborhoodTimes.y - cache.NeighborhoodTimes.x;
				t = math.select((num - cache.NeighborhoodTimes.x) / num2, 0f, num2 == 0f);
				return cache.Index;
			}
			float* unsafePtr = (float*)Times.GetUnsafePtr();
			int num3 = 0;
			int num4 = SegmentCount - 1;
			cache.Index = math.clamp(cache.Index, num3, num4);
			int2 int5 = math.int2(cache.Index - 1, cache.Index + 1);
			float4 float5 = *(float4*)(unsafePtr + cache.Index);
			flag &= float5.x <= num;
			flag2 &= num <= float5.w;
			if (flag || flag2)
			{
				cache.NeighborhoodTimes = (flag ? float5.xy : float5.zw);
				num2 = cache.NeighborhoodTimes.y - cache.NeighborhoodTimes.x;
				t = math.select((num - cache.NeighborhoodTimes.x) / num2, 0f, num2 == 0f);
				cache.Index = (flag ? int5.x : int5.y);
				return cache.Index;
			}
			bool flag3 = true;
			do
			{
				cache.NeighborhoodTimes = *(float2*)(unsafePtr + (cache.Index + 1));
				bool flag4 = num < cache.NeighborhoodTimes.x;
				bool flag5 = num > cache.NeighborhoodTimes.y;
				flag3 = flag4 || flag5;
				num3 = math.select(num3, cache.Index + 1, flag5);
				num4 = math.select(num4, cache.Index - 1, flag4);
				cache.Index = math.select(cache.Index, num3 + (num4 - num3 >> 1), flag3);
			}
			while (flag3 && num3 <= num4);
			num2 = cache.NeighborhoodTimes.y - cache.NeighborhoodTimes.x;
			t = math.select((num - cache.NeighborhoodTimes.x) / num2, 0f, num2.Approximately(0f));
			return cache.Index;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe int SearchIgnoreWrapMode(in float time, [NoAlias] out float t)
		{
			float num = math.clamp(time, StartTime, EndTime);
			float* unsafePtr = (float*)Times.GetUnsafePtr();
			float2 float5 = *(float2*)(unsafePtr + 1);
			float num2;
			if (num <= float5.y)
			{
				num2 = float5.y - float5.x;
				t = math.select((num - float5.x) / num2, 0f, num2 == 0f);
				return 0;
			}
			int num3 = 0;
			int num4 = SegmentCount - 1;
			int num5 = 0;
			bool flag = true;
			do
			{
				float5 = *(float2*)(unsafePtr + (num5 + 1));
				bool flag2 = num < float5.x;
				bool flag3 = num > float5.y;
				flag = flag2 || flag3;
				num3 = math.select(num3, num5 + 1, flag3);
				num4 = math.select(num4, num5 - 1, flag2);
				num5 = math.select(num5, num3 + (num4 - num3 >> 1), flag);
			}
			while (flag && num3 <= num4);
			num2 = float5.y - float5.x;
			t = math.select((num - float5.x) / num2, 0f, num2 == 0f);
			return num5;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe int Search(in float time, [NoAlias] ref BlobCurveCache cache, [NoAlias] out float t)
		{
			bool num = WrapModePrev == WrapMode.Clamp;
			bool flag = WrapModePost == WrapMode.Clamp;
			float num2;
			float range;
			if (num && flag)
			{
				num2 = math.clamp(time, StartTime, EndTime);
			}
			else
			{
				bool flag2 = time < StartTime;
				bool flag3 = time > EndTime;
				if (flag2 || flag3)
				{
					switch (flag2 ? WrapModePrev : WrapModePost)
					{
					default:
						num2 = (flag2 ? StartTime : EndTime);
						break;
					case WrapMode.Loop:
						num2 = CurveExt.ModPlus(time - StartTime, Duration) + StartTime;
						break;
					case WrapMode.PingPong:
					{
						range = Duration;
						float num3 = CurveExt.ModPlus(time - StartTime, in range);
						bool flag4 = ((int)math.floor((time - StartTime) / Duration) & 1) == 1;
						num2 = StartTime + (flag4 ? (Duration - num3) : num3);
						break;
					}
					}
				}
				else
				{
					num2 = time;
				}
			}
			bool flag5 = num2 < cache.NeighborhoodTimes.x;
			bool flag6 = num2 > cache.NeighborhoodTimes.y;
			if (cache.Index >= 0 && !(flag5 || flag6))
			{
				range = cache.NeighborhoodTimes.y - cache.NeighborhoodTimes.x;
				t = math.select((num2 - cache.NeighborhoodTimes.x) / range, 0f, range == 0f);
				return cache.Index;
			}
			float* unsafePtr = (float*)Times.GetUnsafePtr();
			int num4 = 0;
			int num5 = SegmentCount - 1;
			cache.Index = math.clamp(cache.Index, num4, num5);
			int2 int5 = math.int2(cache.Index - 1, cache.Index + 1);
			float4 float5 = *(float4*)(unsafePtr + cache.Index);
			flag5 &= float5.x <= num2;
			flag6 &= num2 <= float5.w;
			if (flag5 || flag6)
			{
				cache.NeighborhoodTimes = (flag5 ? float5.xy : float5.zw);
				range = cache.NeighborhoodTimes.y - cache.NeighborhoodTimes.x;
				t = math.select((num2 - cache.NeighborhoodTimes.x) / range, 0f, range == 0f);
				cache.Index = (flag5 ? int5.x : int5.y);
				return cache.Index;
			}
			bool flag7 = true;
			do
			{
				cache.NeighborhoodTimes = *(float2*)(unsafePtr + (cache.Index + 1));
				bool flag8 = num2 < cache.NeighborhoodTimes.x;
				bool flag9 = num2 > cache.NeighborhoodTimes.y;
				flag7 = flag8 || flag9;
				num4 = math.select(num4, cache.Index + 1, flag9);
				num5 = math.select(num5, cache.Index - 1, flag8);
				cache.Index = math.select(cache.Index, num4 + (num5 - num4 >> 1), flag7);
			}
			while (flag7 && num4 <= num5);
			range = cache.NeighborhoodTimes.y - cache.NeighborhoodTimes.x;
			t = math.select((num2 - cache.NeighborhoodTimes.x) / range, 0f, range == 0f);
			return cache.Index;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe int Search(in float time, [NoAlias] out float t)
		{
			bool num = WrapModePrev == WrapMode.Clamp;
			bool flag = WrapModePost == WrapMode.Clamp;
			float num2;
			float range;
			if (num && flag)
			{
				num2 = math.clamp(time, StartTime, EndTime);
			}
			else
			{
				bool flag2 = time < StartTime;
				bool flag3 = time > EndTime;
				if (flag2 || flag3)
				{
					switch (flag2 ? WrapModePrev : WrapModePost)
					{
					default:
						num2 = (flag2 ? StartTime : EndTime);
						break;
					case WrapMode.Loop:
						num2 = CurveExt.ModPlus(time - StartTime, Duration) + StartTime;
						break;
					case WrapMode.PingPong:
					{
						range = Duration;
						float num3 = CurveExt.ModPlus(time - StartTime, in range);
						bool flag4 = ((int)math.floor((time - StartTime) / Duration) & 1) == 1;
						num2 = StartTime + (flag4 ? (Duration - num3) : num3);
						break;
					}
					}
				}
				else
				{
					num2 = time;
				}
			}
			float* unsafePtr = (float*)Times.GetUnsafePtr();
			float2 float5 = *(float2*)(unsafePtr + 1);
			if (num2 <= float5.y)
			{
				range = float5.y - float5.x;
				t = math.select((num2 - float5.x) / range, 0f, range == 0f);
				return 0;
			}
			int num4 = 0;
			int num5 = SegmentCount - 1;
			int num6 = 0;
			bool flag5 = true;
			do
			{
				float5 = *(float2*)(unsafePtr + (num6 + 1));
				bool flag6 = num2 < float5.x;
				bool flag7 = num2 > float5.y;
				flag5 = flag6 || flag7;
				num4 = math.select(num4, num6 + 1, flag7);
				num5 = math.select(num5, num6 - 1, flag6);
				num6 = math.select(num6, num4 + (num5 - num4 >> 1), flag5);
			}
			while (flag5 && num4 <= num5);
			range = float5.y - float5.x;
			t = math.select((num2 - float5.x) / range, 0f, range == 0f);
			return num6;
		}
	}

	internal CurveHeader m_Header;

	public BlobArray<BlobCurveSegment> Segments;

	public unsafe ref CurveHeader Header => ref UnsafeUtility.AsRef<CurveHeader>(UnsafeUtility.AddressOf(ref m_Header));

	public unsafe ref BlobArray<float> Times => ref UnsafeUtility.AsRef<BlobArray<float>>(UnsafeUtility.AddressOf(ref m_Header.Times));

	public WrapMode WrapModePrev => m_Header.WrapModePrev;

	public WrapMode WrapModePost => m_Header.WrapModePost;

	public int SegmentCount => m_Header.SegmentCount;

	public float StartTime => m_Header.StartTime;

	public float EndTime => m_Header.EndTime;

	public float Duration => m_Header.Duration;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float EvaluateIgnoreWrapMode(in float time, [NoAlias] ref BlobCurveCache cache)
	{
		float t;
		int index = m_Header.SearchIgnoreWrapMode(in time, ref cache, out t);
		return Segments[index].Sample(BlobCurveSegment.PowerSerial(in t));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float EvaluateIgnoreWrapMode(in float time)
	{
		float t;
		int index = m_Header.SearchIgnoreWrapMode(in time, out t);
		return Segments[index].Sample(BlobCurveSegment.PowerSerial(in t));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float Evaluate(in float time, [NoAlias] ref BlobCurveCache cache)
	{
		float t;
		int index = m_Header.Search(in time, ref cache, out t);
		return Segments[index].Sample(BlobCurveSegment.PowerSerial(in t));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float Evaluate(in float time)
	{
		float t;
		int index = m_Header.Search(in time, out t);
		return Segments[index].Sample(BlobCurveSegment.PowerSerial(in t));
	}

	public static BlobAssetReference<BlobCurve> Create(AnimationCurve curve, Allocator allocator = Allocator.Persistent)
	{
		Keyframe[] keys = curve.keys;
		int num = keys.Length;
		bool flag = num == 1;
		int num2 = math.select(num - 1, 1, flag);
		BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		ref BlobCurve reference = ref blobBuilder.ConstructRoot<BlobCurve>();
		reference.m_Header.SegmentCount = num2;
		reference.m_Header.WrapModePrev = curve.preWrapMode.ToNative();
		reference.m_Header.WrapModePost = curve.postWrapMode.ToNative();
		if (flag)
		{
			Keyframe keyframe = keys[0];
			BlobBuilderArray<float> blobBuilderArray = blobBuilder.Allocate(ref reference.m_Header.Times, 4);
			blobBuilderArray[0] = (blobBuilderArray[1] = (blobBuilderArray[2] = (blobBuilderArray[3] = keyframe.time)));
			blobBuilder.Allocate(ref reference.Segments, 1)[0] = new BlobCurveSegment(keyframe, keyframe);
		}
		else
		{
			BlobBuilderArray<float> blobBuilderArray2 = blobBuilder.Allocate(ref reference.m_Header.Times, num + 2);
			BlobBuilderArray<BlobCurveSegment> blobBuilderArray3 = blobBuilder.Allocate(ref reference.Segments, num2);
			int num3 = 0;
			int num4 = 1;
			while (num3 < num2)
			{
				Keyframe k = keys[num3];
				blobBuilderArray2[num4] = k.time;
				blobBuilderArray3[num3] = new BlobCurveSegment(k, keys[num4]);
				num3 = num4++;
			}
			reference.m_Header.StartTime = keys[0].time;
			reference.m_Header.EndTime = (blobBuilderArray2[num] = keys[num2].time);
			blobBuilderArray2[0] = float.MaxValue;
			blobBuilderArray2[num + 1] = float.MinValue;
		}
		return blobBuilder.CreateBlobAssetReference<BlobCurve>(allocator);
	}

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void InputCurveCheck(AnimationCurve curve)
	{
		if (curve == null)
		{
			throw new NullReferenceException("Input curve is null");
		}
		if (curve.length == 0)
		{
			throw new ArgumentException("Input curve is empty (no keyframe)");
		}
		Keyframe[] keys = curve.keys;
		int i = 0;
		for (int num = keys.Length; i < num; i++)
		{
			Keyframe keyframe = keys[i];
			if (keyframe.weightedMode != WeightedMode.None)
			{
				UnityEngine.Debug.LogError($"Weight Not Supported! Key[{i},Weight[{keyframe.weightedMode},In{keyframe.inWeight},Out{keyframe.outWeight}],Time{keyframe.time},Value{keyframe.value}]");
			}
		}
	}
}
