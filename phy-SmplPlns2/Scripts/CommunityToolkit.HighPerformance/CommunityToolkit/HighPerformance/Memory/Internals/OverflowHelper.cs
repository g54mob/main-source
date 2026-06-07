using System;
using System.Runtime.CompilerServices;

namespace CommunityToolkit.HighPerformance.Memory.Internals
{
	internal static class OverflowHelper
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void EnsureIsInNativeIntRange(int height, int width, int pitch)
		{
			checked
			{
				_ = unchecked((nint)checked(width + pitch)) * unchecked((nint)Math.Max(height - 1, 0)) + Math.Max(unchecked(width - 1), 0);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ComputeInt32Area(int height, int width, int pitch)
		{
			checked
			{
				return (width + pitch) * Math.Max(unchecked(height - 1), 0) + width;
			}
		}
	}
}
