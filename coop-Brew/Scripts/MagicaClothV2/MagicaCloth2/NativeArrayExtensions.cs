using Unity.Collections;

namespace MagicaCloth2
{
	public static class NativeArrayExtensions
	{
		public static void MC2DisposeSafe<T>(this ref NativeArray<T> array) where T : struct
		{
		}

		public static void MC2Resize<T>(this ref NativeArray<T> array, int size, Allocator allocator = Allocator.Persistent, NativeArrayOptions options = NativeArrayOptions.ClearMemory) where T : struct
		{
		}

		public static byte[] MC2ToRawBytes<T>(this ref NativeArray<T> array) where T : struct
		{
			return null;
		}

		public static NativeArray<T> MC2FromRawBytes<T>(byte[] bytes, Allocator allocator = Allocator.Persistent) where T : struct
		{
			return default(NativeArray<T>);
		}
	}
}
