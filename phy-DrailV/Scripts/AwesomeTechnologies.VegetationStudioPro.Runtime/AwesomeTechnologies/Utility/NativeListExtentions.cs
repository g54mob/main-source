using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace AwesomeTechnologies.Utility
{
	public static class NativeListExtentions
	{
		public unsafe static void ClearMemory<T>(this NativeList<T> nativeList) where T : struct
		{
			UnsafeUtility.MemClear(nativeList.GetUnsafePtr(), nativeList.Length * UnsafeUtility.SizeOf<T>());
		}

		public static void CompactMemory<T>(this NativeList<T> nativeList) where T : struct
		{
			nativeList.Clear();
			nativeList.Capacity = 0;
		}
	}
}
