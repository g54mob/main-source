using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace LitMotion.Collections
{
	[BurstCompile]
	internal static class NativeAnimationCurveHelper
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate float Evaluate_0000029E_0024PostfixBurstDelegate(Keyframe* ptr, int length, WrapMode preWrapMode, WrapMode postWrapMode, float time);

		internal static class Evaluate_0000029E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<Evaluate_0000029E_0024PostfixBurstDelegate>(Evaluate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static float Invoke(Keyframe* ptr, int length, WrapMode preWrapMode, WrapMode postWrapMode, float time)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<Keyframe*, int, WrapMode, WrapMode, float, float>)functionPointer)(ptr, length, preWrapMode, postWrapMode, time);
					}
				}
				return Evaluate_0024BurstManaged(ptr, length, preWrapMode, postWrapMode, time);
			}
		}

		private static readonly float4x4 curveMatrix = new float4x4(1f, 0f, 0f, 0f, -3f, 3f, 0f, 0f, 3f, -6f, 3f, 0f, -1f, 3f, -3f, 1f);

		private static readonly float3x3 curveMatrixPrime = new float3x3(1f, 0f, 0f, -2f, 2f, 0f, 1f, -2f, 1f);

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002ECollections_002EEvaluate_0000029E_0024PostfixBurstDelegate))]
		public unsafe static float Evaluate(Keyframe* ptr, int length, WrapMode preWrapMode, WrapMode postWrapMode, float time)
		{
			return Evaluate_0000029E_0024BurstDirectCall.Invoke(ptr, length, preWrapMode, postWrapMode, time);
		}

		private unsafe static int GetInsertionIndexForSortedArray(Keyframe* ptr, int length, ref Keyframe keyframe)
		{
			int num = new UnsafeList<Keyframe>(ptr, length).BinarySearch(keyframe, default(KeyframeComparer));
			if (num < 0)
			{
				num = ~num;
			}
			return num;
		}

		private unsafe static float WrapTime(Keyframe* ptr, int length, WrapMode preWrapMode, WrapMode postWrapMode, float time)
		{
			float time2 = ptr[length - 1].time;
			if (time < 0f)
			{
				switch (preWrapMode)
				{
				case WrapMode.Default:
				case WrapMode.Once:
				case WrapMode.ClampForever:
					time = 0f;
					break;
				case WrapMode.Loop:
					time = time % time2 - ptr->time;
					break;
				case WrapMode.PingPong:
					time = Mathf.PingPong(time, time2 - ptr->time);
					break;
				}
			}
			else if (time > time2)
			{
				switch (postWrapMode)
				{
				case WrapMode.Default:
				case WrapMode.ClampForever:
					time = time2;
					break;
				case WrapMode.Once:
					time = 0f;
					break;
				case WrapMode.Loop:
					time = time % time2 - ptr->time;
					break;
				case WrapMode.PingPong:
					time = Mathf.PingPong(time, time2 - ptr->time);
					break;
				}
			}
			return time;
		}

		private static float Evaluate(float time, ref Keyframe keyframe, ref Keyframe nextKeyframe)
		{
			if (!math.isfinite(keyframe.outTangent) || !math.isfinite(nextKeyframe.inTangent))
			{
				return keyframe.value;
			}
			float num = nextKeyframe.time - keyframe.time;
			float t = (time - keyframe.time) / num;
			float num2 = ((keyframe.weightedMode >= WeightedMode.Out) ? keyframe.outWeight : (1f / 3f));
			float num3 = ((nextKeyframe.weightedMode >= WeightedMode.In) ? nextKeyframe.inWeight : (1f / 3f));
			float tBottom = 0f;
			float tTop = 1f;
			float diff = float.MaxValue;
			float4 xCoords = new float4(keyframe.time, keyframe.time + num2 * num, nextKeyframe.time - num3 * num, nextKeyframe.time);
			float4 curveXCoords = math.mul(curveMatrix, xCoords);
			GetTWithNewtonMethod(time, in xCoords, in curveXCoords, ref t, ref tBottom, ref tTop, ref diff);
			GetTWithBisectionMethod(time, in curveXCoords, ref t, ref tBottom, ref tTop, ref diff);
			return CubicBezier(math.mul(b: new float4(keyframe.value, keyframe.value + num2 * keyframe.outTangent * num, nextKeyframe.value - num3 * nextKeyframe.inTangent * num, nextKeyframe.value), a: curveMatrix), t);
		}

		private static float CubicBezier(in float4 curveMatrix, float t)
		{
			float num = t * t;
			return math.dot(new float4(1f, t, num, num * t), curveMatrix);
		}

		private static float CubicBezier(in float3 curveMatrix, float t)
		{
			return math.dot(new float3(1f, t, t * t), curveMatrix);
		}

		private static float DeCasteljauBezier(int degree, float4 coords, float t)
		{
			float num = 1f - t;
			for (int i = 1; i <= degree; i++)
			{
				for (int j = 0; j <= degree - i; j++)
				{
					coords[j] = num * coords[j] + t * coords[j + 1];
				}
			}
			return coords[0];
		}

		private static void GetTWithBisectionMethod(float time, in float4 curveXCoords, ref float t, ref float tBottom, ref float tTop, ref float diff)
		{
			int num = 0;
			while (diff > 1E-07f && num < 20)
			{
				num++;
				t = (tTop + tBottom) * 0.5f;
				float num2 = CubicBezier(in curveXCoords, t);
				diff = math.abs(num2 - time);
				UpdateTLimits(num2, time, t, ref tBottom, ref tTop);
			}
		}

		private static void GetTWithNewtonMethod(float time, in float4 xCoords, in float4 curveXCoords, ref float t, ref float tBottom, ref float tTop, ref float diff)
		{
			int num = 0;
			float4 float5 = default(float4);
			for (int i = 0; i < 3; i++)
			{
				float5[i] = (xCoords[i + 1] - xCoords[i]) * 3f;
			}
			float4 primePrimeCoords = default(float4);
			for (int j = 0; j < 2; j++)
			{
				primePrimeCoords[j] = (float5[j + 1] - float5[j]) * 2f;
			}
			float3 curvePrimeCoords = math.mul(curveMatrixPrime, float5.xyz);
			while (diff > 1E-07f && num < 20)
			{
				num++;
				float coordAtT;
				float num2 = UseNewtonMethod(curveXCoords, time, t, curvePrimeCoords, primePrimeCoords, out coordAtT);
				float num3 = math.abs(coordAtT - time);
				if (!(num2 < 0f) && !(num2 > 1f) && !(num3 > diff))
				{
					diff = num3;
					UpdateTLimits(coordAtT, time, t, ref tBottom, ref tTop);
					t = num2;
					continue;
				}
				break;
			}
		}

		private static float UseNewtonMethod(float4 curveCoords, float coord, float t, float3 curvePrimeCoords, float4 primePrimeCoords, out float coordAtT)
		{
			coordAtT = CubicBezier(in curveCoords, t);
			float num = CubicBezier(in curvePrimeCoords, t);
			float num2 = DeCasteljauBezier(1, primePrimeCoords, t);
			float num3 = coordAtT - coord;
			float num4 = num3 * num;
			float num5 = num3 * num2 + num * num;
			return t - num4 / num5;
		}

		private static void UpdateTLimits(float x, float time, float t, ref float tBottom, ref float tTop)
		{
			if (x > time)
			{
				tTop = math.clamp(t, tBottom, tTop);
			}
			else
			{
				tBottom = math.clamp(t, tBottom, tTop);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal unsafe static float Evaluate_0024BurstManaged(Keyframe* ptr, int length, WrapMode preWrapMode, WrapMode postWrapMode, float time)
		{
			time = WrapTime(ptr, length, preWrapMode, postWrapMode, time);
			Keyframe keyframe = new Keyframe
			{
				time = time
			};
			int num = GetInsertionIndexForSortedArray(ptr, length, ref keyframe);
			if (num == 0)
			{
				num++;
			}
			else if (num == length)
			{
				num = length - 1;
			}
			keyframe = ptr[num - 1];
			Keyframe nextKeyframe = ptr[num];
			return Evaluate(time, ref keyframe, ref nextKeyframe);
		}
	}
}
