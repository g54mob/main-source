using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public class NativeObjectRef : IDisposable
	{
		private bool m_disposed;

		public IntPtr Pointer { get; private set; }

		public NativeObjectRef(IntPtr ptr, bool autoRetain)
		{
		}

		~NativeObjectRef()
		{
		}

		private void Retain()
		{
		}

		private void Release()
		{
		}

		protected virtual void RetainInternal(IntPtr ptr)
		{
		}

		protected virtual void ReleaseInternal(IntPtr ptr)
		{
		}

		public void Dispose()
		{
		}

		private void Dispose(bool disposing)
		{
		}
	}
}
