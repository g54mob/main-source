using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.NativeCollections
{
	public static class Utils
	{
		public unsafe static void IncrementAt(NativeArray<int> bytes, int index)
		{
			Interlocked.Increment(ref *(int*)((byte*)bytes.GetUnsafePtr() + (nint)index * (nint)4));
		}

		public unsafe static void InterlockedAddDouble(NativeArray<long> array, int index, double value, long multiplier = 1000000L, double safeMin = -1000000.0, double safeMax = 1000000.0)
		{
			long value2 = (long)(math.clamp(value, safeMin, safeMax) * (double)multiplier);
			Interlocked.Add(ref *(long*)((byte*)array.GetUnsafePtr() + (nint)index * (nint)8), value2);
		}

		public unsafe static void SetZeroAt(NativeArray<int> bytes, int index)
		{
			Interlocked.Exchange(ref *(int*)((byte*)bytes.GetUnsafePtr() + (nint)index * (nint)4), 0);
		}
	}
}
