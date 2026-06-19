using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public static class MapUIBurstedUtility
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void UpscaleTimestampData_0000610B_0024PostfixBurstDelegate(in NativeArray<PugColorARGB32> sourceLowRes, ref NativeArray<PugColorARGB32> targetHighRes);

	internal static class UpscaleTimestampData_0000610B_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<UpscaleTimestampData_0000610B_0024PostfixBurstDelegate>(UpscaleTimestampData).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in NativeArray<PugColorARGB32> sourceLowRes, ref NativeArray<PugColorARGB32> targetHighRes)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeArray<PugColorARGB32>, ref NativeArray<PugColorARGB32>, void>)functionPointer)(ref sourceLowRes, ref targetHighRes);
					return;
				}
			}
			UpscaleTimestampData_0024BurstManaged(in sourceLowRes, ref targetHighRes);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void DownscaleTimestampData_0000610C_0024PostfixBurstDelegate(in NativeArray<PugColorARGB32> sourceHighRes, ref NativeArray<PugColorARGB32> targetLowRes);

	internal static class DownscaleTimestampData_0000610C_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<DownscaleTimestampData_0000610C_0024PostfixBurstDelegate>(DownscaleTimestampData).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in NativeArray<PugColorARGB32> sourceHighRes, ref NativeArray<PugColorARGB32> targetLowRes)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeArray<PugColorARGB32>, ref NativeArray<PugColorARGB32>, void>)functionPointer)(ref sourceHighRes, ref targetLowRes);
					return;
				}
			}
			DownscaleTimestampData_0024BurstManaged(in sourceHighRes, ref targetLowRes);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate byte FindClosestColorMatch_0000610D_0024PostfixBurstDelegate(in Color color, in NativeArray<Color> indexedColors, ref NativeHashMap<Color, byte> colorToIndex);

	internal static class FindClosestColorMatch_0000610D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<FindClosestColorMatch_0000610D_0024PostfixBurstDelegate>(FindClosestColorMatch).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static byte Invoke(in Color color, in NativeArray<Color> indexedColors, ref NativeHashMap<Color, byte> colorToIndex)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					return ((delegate* unmanaged[Cdecl]<ref Color, ref NativeArray<Color>, ref NativeHashMap<Color, byte>, byte>)functionPointer)(ref color, ref indexedColors, ref colorToIndex);
				}
			}
			return FindClosestColorMatch_0024BurstManaged(in color, in indexedColors, ref colorToIndex);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void GetColorFromColorIndex_0000610E_0024PostfixBurstDelegate(in NativeArray<byte> source, in NativeArray<Color> indexToColor, ref NativeArray<PugColorARGB32> target);

	internal static class GetColorFromColorIndex_0000610E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<GetColorFromColorIndex_0000610E_0024PostfixBurstDelegate>(GetColorFromColorIndex).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in NativeArray<byte> source, in NativeArray<Color> indexToColor, ref NativeArray<PugColorARGB32> target)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeArray<byte>, ref NativeArray<Color>, ref NativeArray<PugColorARGB32>, void>)functionPointer)(ref source, ref indexToColor, ref target);
					return;
				}
			}
			GetColorFromColorIndex_0024BurstManaged(in source, in indexToColor, ref target);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void GetColorIndexFromColor_0000610F_0024PostfixBurstDelegate(in NativeArray<PugColorARGB32> source, in NativeArray<Color> indexToColor, ref NativeArray<byte> target, ref NativeHashMap<Color, byte> colorToIndex);

	internal static class GetColorIndexFromColor_0000610F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<GetColorIndexFromColor_0000610F_0024PostfixBurstDelegate>(GetColorIndexFromColor).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in NativeArray<PugColorARGB32> source, in NativeArray<Color> indexToColor, ref NativeArray<byte> target, ref NativeHashMap<Color, byte> colorToIndex)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeArray<PugColorARGB32>, ref NativeArray<Color>, ref NativeArray<byte>, ref NativeHashMap<Color, byte>, void>)functionPointer)(ref source, ref indexToColor, ref target, ref colorToIndex);
					return;
				}
			}
			GetColorIndexFromColor_0024BurstManaged(in source, in indexToColor, ref target, ref colorToIndex);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void UpdateMapPartWithColorIndexing_00006110_0024PostfixBurstDelegate(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingHighResTimestamps, ref NativeArray<byte> currentColorIndex, ref NativeArray<PugColorARGB32> currentLowResTimestamps, in NativeArray<Color> indexToColor, ref NativeHashMap<Color, byte> colorToIndex);

	internal static class UpdateMapPartWithColorIndexing_00006110_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<UpdateMapPartWithColorIndexing_00006110_0024PostfixBurstDelegate>(UpdateMapPartWithColorIndexing).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingHighResTimestamps, ref NativeArray<byte> currentColorIndex, ref NativeArray<PugColorARGB32> currentLowResTimestamps, in NativeArray<Color> indexToColor, ref NativeHashMap<Color, byte> colorToIndex)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeArray<PugColorARGB32>, ref NativeArray<PugColorARGB32>, ref NativeArray<byte>, ref NativeArray<PugColorARGB32>, ref NativeArray<Color>, ref NativeHashMap<Color, byte>, void>)functionPointer)(ref incomingColor, ref incomingHighResTimestamps, ref currentColorIndex, ref currentLowResTimestamps, ref indexToColor, ref colorToIndex);
					return;
				}
			}
			UpdateMapPartWithColorIndexing_0024BurstManaged(in incomingColor, in incomingHighResTimestamps, ref currentColorIndex, ref currentLowResTimestamps, in indexToColor, ref colorToIndex);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void UpdateMapPart_00006111_0024PostfixBurstDelegate(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingTimestamps, ref NativeArray<PugColorARGB32> currentColor, ref NativeArray<PugColorARGB32> currentTimestamps);

	internal static class UpdateMapPart_00006111_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<UpdateMapPart_00006111_0024PostfixBurstDelegate>(UpdateMapPart).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingTimestamps, ref NativeArray<PugColorARGB32> currentColor, ref NativeArray<PugColorARGB32> currentTimestamps)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref NativeArray<PugColorARGB32>, ref NativeArray<PugColorARGB32>, ref NativeArray<PugColorARGB32>, ref NativeArray<PugColorARGB32>, void>)functionPointer)(ref incomingColor, ref incomingTimestamps, ref currentColor, ref currentTimestamps);
					return;
				}
			}
			UpdateMapPart_0024BurstManaged(in incomingColor, in incomingTimestamps, ref currentColor, ref currentTimestamps);
		}
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(UpscaleTimestampData_0000610B_0024PostfixBurstDelegate))]
	public static void UpscaleTimestampData(in NativeArray<PugColorARGB32> sourceLowRes, ref NativeArray<PugColorARGB32> targetHighRes)
	{
		UpscaleTimestampData_0000610B_0024BurstDirectCall.Invoke(in sourceLowRes, ref targetHighRes);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(DownscaleTimestampData_0000610C_0024PostfixBurstDelegate))]
	public static void DownscaleTimestampData(in NativeArray<PugColorARGB32> sourceHighRes, ref NativeArray<PugColorARGB32> targetLowRes)
	{
		DownscaleTimestampData_0000610C_0024BurstDirectCall.Invoke(in sourceHighRes, ref targetLowRes);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(FindClosestColorMatch_0000610D_0024PostfixBurstDelegate))]
	public static byte FindClosestColorMatch(in Color color, in NativeArray<Color> indexedColors, ref NativeHashMap<Color, byte> colorToIndex)
	{
		return FindClosestColorMatch_0000610D_0024BurstDirectCall.Invoke(in color, in indexedColors, ref colorToIndex);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(GetColorFromColorIndex_0000610E_0024PostfixBurstDelegate))]
	public static void GetColorFromColorIndex(in NativeArray<byte> source, in NativeArray<Color> indexToColor, ref NativeArray<PugColorARGB32> target)
	{
		GetColorFromColorIndex_0000610E_0024BurstDirectCall.Invoke(in source, in indexToColor, ref target);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(GetColorIndexFromColor_0000610F_0024PostfixBurstDelegate))]
	public static void GetColorIndexFromColor(in NativeArray<PugColorARGB32> source, in NativeArray<Color> indexToColor, ref NativeArray<byte> target, ref NativeHashMap<Color, byte> colorToIndex)
	{
		GetColorIndexFromColor_0000610F_0024BurstDirectCall.Invoke(in source, in indexToColor, ref target, ref colorToIndex);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(UpdateMapPartWithColorIndexing_00006110_0024PostfixBurstDelegate))]
	public static void UpdateMapPartWithColorIndexing(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingHighResTimestamps, ref NativeArray<byte> currentColorIndex, ref NativeArray<PugColorARGB32> currentLowResTimestamps, in NativeArray<Color> indexToColor, ref NativeHashMap<Color, byte> colorToIndex)
	{
		UpdateMapPartWithColorIndexing_00006110_0024BurstDirectCall.Invoke(in incomingColor, in incomingHighResTimestamps, ref currentColorIndex, ref currentLowResTimestamps, in indexToColor, ref colorToIndex);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(UpdateMapPart_00006111_0024PostfixBurstDelegate))]
	public static void UpdateMapPart(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingTimestamps, ref NativeArray<PugColorARGB32> currentColor, ref NativeArray<PugColorARGB32> currentTimestamps)
	{
		UpdateMapPart_00006111_0024BurstDirectCall.Invoke(in incomingColor, in incomingTimestamps, ref currentColor, ref currentTimestamps);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void UpscaleTimestampData_0024BurstManaged(in NativeArray<PugColorARGB32> sourceLowRes, ref NativeArray<PugColorARGB32> targetHighRes)
	{
		for (int i = 0; i < 256; i++)
		{
			for (int j = 0; j < 256; j++)
			{
				PugColorARGB32 value = sourceLowRes[i * 256 + j];
				int2 int5 = new int2(j, i) * 1;
				for (int k = 0; k < 1; k++)
				{
					for (int l = 0; l < 1; l++)
					{
						targetHighRes[(int5.y + k) * 256 + int5.x + l] = value;
					}
				}
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void DownscaleTimestampData_0024BurstManaged(in NativeArray<PugColorARGB32> sourceHighRes, ref NativeArray<PugColorARGB32> targetLowRes)
	{
		for (int i = 0; i < 256; i++)
		{
			for (int j = 0; j < 256; j++)
			{
				int2 int5 = new int2(j, i) * 1;
				int index = i * 256 + j;
				PugColorARGB32 pugColorARGB = default(PugColorARGB32);
				for (int k = 0; k < 1; k++)
				{
					for (int l = 0; l < 1; l++)
					{
						int index2 = (int5.y + k) * 256 + int5.x + l;
						PugColorARGB32 pugColorARGB2 = sourceHighRes[index2];
						if (MapUI.TimestampIsNewer(pugColorARGB2, pugColorARGB))
						{
							pugColorARGB = pugColorARGB2;
						}
					}
				}
				targetLowRes[index] = pugColorARGB;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static byte FindClosestColorMatch_0024BurstManaged(in Color color, in NativeArray<Color> indexedColors, ref NativeHashMap<Color, byte> colorToIndex)
	{
		if (colorToIndex.TryGetValue(color, out var item))
		{
			return item;
		}
		float4 float5 = new float4(color.r, color.g, color.b, 1f);
		float num = float.MaxValue;
		int num2 = 0;
		for (int i = 0; i < indexedColors.Length; i++)
		{
			float4 float6 = new float4(indexedColors[i].r, indexedColors[i].g, indexedColors[i].b, 1f);
			float num3 = math.lengthsq(float5 - float6);
			if (num3 < num)
			{
				num = num3;
				num2 = i;
			}
		}
		colorToIndex[color] = (byte)num2;
		return (byte)num2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void GetColorFromColorIndex_0024BurstManaged(in NativeArray<byte> source, in NativeArray<Color> indexToColor, ref NativeArray<PugColorARGB32> target)
	{
		for (int i = 0; i < 65536; i++)
		{
			target[i] = indexToColor[source[i]].gamma;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void GetColorIndexFromColor_0024BurstManaged(in NativeArray<PugColorARGB32> source, in NativeArray<Color> indexToColor, ref NativeArray<byte> target, ref NativeHashMap<Color, byte> colorToIndex)
	{
		for (int i = 0; i < 65536; i++)
		{
			target[i] = FindClosestColorMatch(((Color)source[i]).linear, in indexToColor, ref colorToIndex);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void UpdateMapPartWithColorIndexing_0024BurstManaged(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingHighResTimestamps, ref NativeArray<byte> currentColorIndex, ref NativeArray<PugColorARGB32> currentLowResTimestamps, in NativeArray<Color> indexToColor, ref NativeHashMap<Color, byte> colorToIndex)
	{
		for (int i = 0; i < 256; i++)
		{
			for (int j = 0; j < 256; j++)
			{
				int index = i * 256 + j;
				PugColorARGB32 pugColorARGB = currentLowResTimestamps[index];
				int2 int5 = new int2(j, i) * 1;
				PugColorARGB32 pugColorARGB2 = pugColorARGB;
				for (int k = 0; k < 1; k++)
				{
					for (int l = 0; l < 1; l++)
					{
						int index2 = (int5.y + k) * 256 + int5.x + l;
						Color color = incomingColor[index2];
						PugColorARGB32 pugColorARGB3 = incomingHighResTimestamps[index2];
						if (currentColorIndex[index2] == 0 || MapUI.TimestampIsNewer(pugColorARGB3, pugColorARGB))
						{
							currentColorIndex[index2] = FindClosestColorMatch(color.linear, in indexToColor, ref colorToIndex);
							if (MapUI.TimestampIsNewer(pugColorARGB3, pugColorARGB2))
							{
								pugColorARGB2 = pugColorARGB3;
							}
						}
					}
				}
				currentLowResTimestamps[index] = pugColorARGB2;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void UpdateMapPart_0024BurstManaged(in NativeArray<PugColorARGB32> incomingColor, in NativeArray<PugColorARGB32> incomingTimestamps, ref NativeArray<PugColorARGB32> currentColor, ref NativeArray<PugColorARGB32> currentTimestamps)
	{
		for (int i = 0; i < 65536; i++)
		{
			if (MapUI.TimestampIsNewer(incomingTimestamps[i], currentTimestamps[i]))
			{
				currentTimestamps[i] = incomingTimestamps[i];
				currentColor[i] = incomingColor[i];
			}
		}
	}
}
