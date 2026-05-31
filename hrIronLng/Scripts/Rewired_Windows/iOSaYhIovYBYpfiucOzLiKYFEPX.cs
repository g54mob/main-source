using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class iOSaYhIovYBYpfiucOzLiKYFEPX : FgWgxCSfHbOCKeqhjQMaYTLjaRh
{
	[CompilerGenerated]
	private UjWdPKrIisWRvtOtTtqXWszemnj YuethMIzjQMTKFersiGVmDXiAdr;

	public UjWdPKrIisWRvtOtTtqXWszemnj Callback
	{
		[CompilerGenerated]
		get
		{
			return YuethMIzjQMTKFersiGVmDXiAdr;
		}
		[CompilerGenerated]
		private set
		{
			YuethMIzjQMTKFersiGVmDXiAdr = value;
		}
	}

	protected abstract PojoqhxAgqdkLQGTsHxSXVOZQji GetVtbl { get; }

	public unsafe virtual void BVmTKMsAVVqdkfwNjSwlgNFzTsh(UjWdPKrIisWRvtOtTtqXWszemnj P_0)
	{
		Callback = P_0;
		base.NativePointer = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.NativePointer, GetVtbl.Pointer);
		((IntPtr*)(void*)base.NativePointer)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe override void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (base.NativePointer != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.NativePointer)[1]).Free();
			Marshal.FreeHGlobal(base.NativePointer);
			base.NativePointer = IntPtr.Zero;
		}
		Callback = null;
		base.KRgasgBmyLeCeDGJhNGqwMeOqCwJ(P_0);
	}

	internal unsafe static T bVCGsFglwTnnkcMqICpTmFPpqIzw<T>(IntPtr P_0) where T : iOSaYhIovYBYpfiucOzLiKYFEPX
	{
		return (T)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
