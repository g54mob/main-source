using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public static class MarshalUtility
	{
		public static string ToString(IntPtr stringPtr)
		{
			return null;
		}

		public static IntPtr GetIntPtr(object value)
		{
			return (IntPtr)0;
		}

		public static void FreeUnmanagedStringArray(IntPtr unmanagedArrayPtr, int count)
		{
		}

		public static IntPtr CreateUnmanagedArray(IntPtr[] managedArray)
		{
			return (IntPtr)0;
		}

		public static void ReleaseUnmanagedArray(IntPtr unmanagedArrayPtr)
		{
		}

		public static IntPtr[] CreateManagedArray(IntPtr arrayPtr, int length)
		{
			return null;
		}

		public static string[] CreateStringArray(IntPtr arrayPtr, int length)
		{
			return null;
		}

		public static T PtrToStructure<T>(IntPtr ptr) where T : struct
		{
			return default(T);
		}

		public static TOutput[] ConvertNativeArrayItems<TInput, TOutput>(IntPtr arrayPtr, int length, Converter<TInput, TOutput> converter, bool includeNullObjects) where TInput : struct where TOutput : class
		{
			return null;
		}

		public static TOutput[] ConvertNativeArrayItems<TOutput>(IntPtr arrayPtr, int length, Converter<IntPtr, TOutput> converter, bool includeNullObjects) where TOutput : class
		{
			return null;
		}
	}
}
