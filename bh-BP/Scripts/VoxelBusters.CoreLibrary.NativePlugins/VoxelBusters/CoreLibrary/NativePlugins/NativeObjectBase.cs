using System;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public abstract class NativeObjectBase : INativeObject, IDisposable
	{
		protected bool IsDisposed { get; private set; }

		public NativeObjectRef NativeObjectRef { get; protected set; }

		protected NativeObjectBase(NativeObjectRef nativeObjectRef = null)
		{
		}

		~NativeObjectBase()
		{
		}

		public IntPtr AddrOfNativeObject()
		{
			return (IntPtr)0;
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
