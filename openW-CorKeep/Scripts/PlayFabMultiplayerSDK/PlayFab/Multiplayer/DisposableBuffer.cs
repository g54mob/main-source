using System;
using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer
{
	public class DisposableBuffer : IDisposable
	{
		public IntPtr IntPtr { get; private set; }

		public DisposableBuffer()
		{
			IntPtr = IntPtr.Zero;
			GC.SuppressFinalize(this);
		}

		public DisposableBuffer(int size)
		{
			IntPtr = Marshal.AllocHGlobal(size);
		}

		~DisposableBuffer()
		{
			Dispose(isDisposing: false);
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool isDisposing)
		{
			if (IntPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(IntPtr);
				IntPtr = IntPtr.Zero;
			}
		}
	}
}
