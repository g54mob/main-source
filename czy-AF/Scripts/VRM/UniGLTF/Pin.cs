using System;
using System.Runtime.InteropServices;

namespace UniGLTF
{
	public static class Pin
	{
		public static Pin<T> Create<T>(ArraySegment<T> src) where T : struct
		{
			return new Pin<T>(src);
		}

		public static Pin<T> Create<T>(T[] src) where T : struct
		{
			return Create(new ArraySegment<T>(src));
		}
	}
	public class Pin<T> : IDisposable where T : struct
	{
		private GCHandle m_pinnedArray;

		private ArraySegment<T> m_src;

		private bool disposedValue;

		public int Length => m_src.Count * Marshal.SizeOf(typeof(T));

		public IntPtr Ptr => new IntPtr(m_pinnedArray.AddrOfPinnedObject().ToInt64() + m_src.Offset);

		public Pin(ArraySegment<T> src)
		{
			m_src = src;
			m_pinnedArray = GCHandle.Alloc(src.Array, GCHandleType.Pinned);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (m_pinnedArray.IsAllocated)
				{
					m_pinnedArray.Free();
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}
	}
}
