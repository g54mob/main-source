using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class DataUtility
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 PackInt2(int d0, int d1)
		{
			return default(int2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 PackInt2(in int2 d)
		{
			return default(int2);
		}

		public static int3 PackInt3(int d0, int d1, int d2)
		{
			return default(int3);
		}

		public static int3 PackInt3(in int3 d)
		{
			return default(int3);
		}

		public static int4 PackInt4(int d0, int d1, int d2, int d3)
		{
			return default(int4);
		}

		public static int4 PackInt4(int4 d)
		{
			return default(int4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Pack32(int hi, int low)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Pack32Sort(int a, int b)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack32Hi(uint pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack32Low(uint pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Pack12_20(int hi, int low)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack12_20Hi(uint pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack12_20Low(uint pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Unpack12_20(uint pack, out int hi, out int low)
		{
			hi = default(int);
			low = default(int);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Pack64(int x, int y, int z, int w)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Pack64(in int4 a)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 Unpack64(in ulong pack)
		{
			return default(int4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack64X(in ulong pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack64Y(in ulong pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack64Z(in ulong pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Unpack64W(in ulong pack)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Pack32(int x, int y, int z, int w)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong Pack32(in int4 a)
		{
			return 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 Unpack32(in uint pack)
		{
			return default(int4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int RemainingData(in int3 data, in int2 use)
		{
			return 0;
		}

		public static float4x4 ConvertAnimationCurve(AnimationCurve curve)
		{
			return default(float4x4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EvaluateCurve(in float4x4 curve, float time)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExBitFlag16 SetColliderType(ExBitFlag16 flag, ColliderManager.ColliderType ctype)
		{
			return default(ExBitFlag16);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ColliderManager.ColliderType GetColliderType(in ExBitFlag16 flag)
		{
			return default(ColliderManager.ColliderType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ExBitFlag16 SetSymmetryType(ExBitFlag16 flag, ColliderManager.SymmetryType stype)
		{
			return default(ExBitFlag16);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ColliderManager.SymmetryType GetSymmetryType(in ExBitFlag16 flag)
		{
			return default(ColliderManager.SymmetryType);
		}

		public static void ArrayCopy<T>(T[] src, ref T[] dst)
		{
		}
	}
}
