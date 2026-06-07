using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class jwzGTEgJThlahTtazxrQriNiTCg : CndQdhRoXYCqAIOwkhIvRMCMVjY
{
	[CompilerGenerated]
	private VJvDCfEiULZhxmTbSdcYPJiPZwU XzRFcrHRXpSyWtEgpCaEjoWDJRK;

	public VJvDCfEiULZhxmTbSdcYPJiPZwU Callback
	{
		[CompilerGenerated]
		get
		{
			return XzRFcrHRXpSyWtEgpCaEjoWDJRK;
		}
		[CompilerGenerated]
		private set
		{
			XzRFcrHRXpSyWtEgpCaEjoWDJRK = value;
		}
	}

	protected abstract KOSpfYuVMNhRBqeDjgdReUZePoTb GetVtbl { get; }

	public unsafe virtual void GVPNrpnUrcRcuBVNsoUmnQYWdWW(VJvDCfEiULZhxmTbSdcYPJiPZwU P_0)
	{
		Callback = P_0;
		base.NativePointer = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.NativePointer, GetVtbl.Pointer);
		((IntPtr*)(void*)base.NativePointer)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe override void Dispose(bool P_0)
	{
		if (base.NativePointer != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.NativePointer)[1]).Free();
			Marshal.FreeHGlobal(base.NativePointer);
			base.NativePointer = IntPtr.Zero;
		}
		Callback = null;
		base.Dispose(P_0);
	}

	internal unsafe static T ipxdwiyZIyRGswxsXxvYYDCBVUG<T>(IntPtr P_0) where T : jwzGTEgJThlahTtazxrQriNiTCg
	{
		return (T)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
