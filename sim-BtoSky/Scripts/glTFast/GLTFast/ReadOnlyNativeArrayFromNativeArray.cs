using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace GLTFast
{
	internal readonly struct ReadOnlyNativeArrayFromNativeArray<T> where T : unmanaged
	{
		private readonly ReadOnlyNativeArray<T> m_Array;

		public ReadOnlyNativeArray<T> Array => m_Array;

		public unsafe ReadOnlyNativeArrayFromNativeArray(NativeArray<T>.ReadOnly data)
		{
			void* unsafeReadOnlyPtr = data.GetUnsafeReadOnlyPtr();
			m_Array = new ReadOnlyNativeArray<T>(unsafeReadOnlyPtr, data.Length);
		}
	}
}
