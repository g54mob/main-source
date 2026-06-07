using System;
using System.Runtime.InteropServices;

namespace GLTFast
{
	internal sealed class ReadOnlyNativeArrayFromManagedArray<T> : IDisposable where T : unmanaged
	{
		private GCHandle m_BufferHandle;

		private readonly bool m_Pinned;

		public ReadOnlyNativeArray<T> Array { get; }

		public unsafe ReadOnlyNativeArrayFromManagedArray(T[] original)
		{
			if (original == null)
			{
				throw new ArgumentNullException("original");
			}
			m_BufferHandle = GCHandle.Alloc(original, GCHandleType.Pinned);
			fixed (T* ptr = &original[0])
			{
				void* buffer = ptr;
				Array = new ReadOnlyNativeArray<T>(buffer, original.Length);
			}
			m_Pinned = true;
		}

		public void Dispose()
		{
			if (m_Pinned)
			{
				m_BufferHandle.Free();
			}
		}
	}
}
