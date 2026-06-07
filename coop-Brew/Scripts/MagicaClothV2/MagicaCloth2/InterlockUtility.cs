using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public static class InterlockUtility
	{
		internal const int ToFixed = 1000000;

		internal const float ToFloat = 1E-06f;

		internal unsafe static void AddFloat3(int index, float3 add, int* cntPt, int* sumPt)
		{
		}

		internal unsafe static void AddFloat3(int index, float3 add, int* sumPt)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static void Max(int index, float value, int* pt)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static float3 ReadAverageFloat3(int index, int* cntPt, int* sumPt)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static float3 ReadFloat3(int index, int* vecPt)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal unsafe static float ReadFloat(int index, int* floatPt)
		{
			return 0f;
		}
	}
}
