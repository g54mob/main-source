using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

namespace LitMotion
{
	[BurstCompile]
	internal static class VibrationHelper
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void EvaluateStrength_00000166_0024PostfixBurstDelegate(in float strength, in int frequency, in float dampingRatio, in float t, out float result);

		internal static class EvaluateStrength_00000166_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<EvaluateStrength_00000166_0024PostfixBurstDelegate>(EvaluateStrength).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(in float strength, in int frequency, in float dampingRatio, in float t, out float result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref float, ref int, ref float, ref float, ref float, void>)functionPointer)(ref strength, ref frequency, ref dampingRatio, ref t, ref result);
						return;
					}
				}
				EvaluateStrength_0024BurstManaged(in strength, in frequency, in dampingRatio, in t, out result);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void EvaluateStrength_00000167_0024PostfixBurstDelegate(in Vector2 strength, in int frequency, in float dampingRatio, in float t, out Vector2 result);

		internal static class EvaluateStrength_00000167_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<EvaluateStrength_00000167_0024PostfixBurstDelegate>(EvaluateStrength).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(in Vector2 strength, in int frequency, in float dampingRatio, in float t, out Vector2 result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref Vector2, ref int, ref float, ref float, ref Vector2, void>)functionPointer)(ref strength, ref frequency, ref dampingRatio, ref t, ref result);
						return;
					}
				}
				EvaluateStrength_0024BurstManaged(in strength, in frequency, in dampingRatio, in t, out result);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void EvaluateStrength_00000168_0024PostfixBurstDelegate(in Vector3 strength, in int frequency, in float dampingRatio, in float t, out Vector3 result);

		internal static class EvaluateStrength_00000168_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<EvaluateStrength_00000168_0024PostfixBurstDelegate>(EvaluateStrength).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(in Vector3 strength, in int frequency, in float dampingRatio, in float t, out Vector3 result)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref Vector3, ref int, ref float, ref float, ref Vector3, void>)functionPointer)(ref strength, ref frequency, ref dampingRatio, ref t, ref result);
						return;
					}
				}
				EvaluateStrength_0024BurstManaged(in strength, in frequency, in dampingRatio, in t, out result);
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EEvaluateStrength_00000166_0024PostfixBurstDelegate))]
		public static void EvaluateStrength(in float strength, in int frequency, in float dampingRatio, in float t, out float result)
		{
			EvaluateStrength_00000166_0024BurstDirectCall.Invoke(in strength, in frequency, in dampingRatio, in t, out result);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EEvaluateStrength_00000167_0024PostfixBurstDelegate))]
		public static void EvaluateStrength(in Vector2 strength, in int frequency, in float dampingRatio, in float t, out Vector2 result)
		{
			EvaluateStrength_00000167_0024BurstDirectCall.Invoke(in strength, in frequency, in dampingRatio, in t, out result);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(LitMotion_002EEvaluateStrength_00000168_0024PostfixBurstDelegate))]
		public static void EvaluateStrength(in Vector3 strength, in int frequency, in float dampingRatio, in float t, out Vector3 result)
		{
			EvaluateStrength_00000168_0024BurstDirectCall.Invoke(in strength, in frequency, in dampingRatio, in t, out result);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void EvaluateStrength_0024BurstManaged(in float strength, in int frequency, in float dampingRatio, in float t, out float result)
		{
			if (t == 1f || t == 0f)
			{
				result = 0f;
				return;
			}
			float x = ((float)frequency * t - 0.5f) * MathF.PI;
			float num = dampingRatio * (float)frequency / (MathF.PI * 2f);
			result = strength * math.pow(MathF.E, (0f - num) * t) * math.cos(x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void EvaluateStrength_0024BurstManaged(in Vector2 strength, in int frequency, in float dampingRatio, in float t, out Vector2 result)
		{
			if (t == 1f || t == 0f)
			{
				result = Vector2.zero;
				return;
			}
			float x = ((float)frequency * t - 0.5f) * MathF.PI;
			float num = dampingRatio * (float)frequency / (MathF.PI * 2f);
			result = math.cos(x) * math.pow(MathF.E, (0f - num) * t) * strength;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void EvaluateStrength_0024BurstManaged(in Vector3 strength, in int frequency, in float dampingRatio, in float t, out Vector3 result)
		{
			if (t == 1f || t == 0f)
			{
				result = Vector3.zero;
				return;
			}
			float x = ((float)frequency * t - 0.5f) * MathF.PI;
			float num = dampingRatio * (float)frequency / (MathF.PI * 2f);
			result = math.cos(x) * math.pow(MathF.E, (0f - num) * t) * strength;
		}
	}
}
