using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public static class MathExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MC2GetValue(this in float4x4 m, int index)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void MC2SetValue(this ref float4x4 m, int index, float value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MC2EvaluateCurveClamp01(this in float4x4 m, float time)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MC2EvaluateCurve(this in float4x4 m, float time)
		{
			return 0f;
		}
	}
}
