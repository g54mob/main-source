using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using Coherence.Log;

namespace Coherence.Utils
{
	public static class Bounds
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CheckPositionForNanAndInfinity(ref Vector3 value, Logger logger)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Clamp(int value, int min, int max)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint Clamp(uint value, uint min, uint max)
		{
			return 0u;
		}

		[Conditional("DEBUG")]
		public static void Check(float value, float min, float max, string variableName, Logger logger)
		{
		}

		[Conditional("DEBUG")]
		public static void Check(int value, int min, int max, string variableName, Logger logger)
		{
		}

		[Conditional("DEBUG")]
		public static void Check(uint value, uint min, uint max, string variableName, Logger logger)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SanitizeNanAndInfinity(ref float value, ref bool hasNanOrInfinity)
		{
		}
	}
}
