using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime
{
	public abstract class SafeEquatableHandle : SafeHandle
	{
		public IntPtr Handle => (IntPtr)0;

		public SafeEquatableHandle(IntPtr invalidHandleValue, bool ownsHandle, IntPtr handle)
			: base((IntPtr)0, ownsHandle: false)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(SafeEquatableHandle handle1, SafeEquatableHandle handle2)
		{
			return false;
		}

		public static bool operator !=(SafeEquatableHandle handle1, SafeEquatableHandle handle2)
		{
			return false;
		}
	}
}
