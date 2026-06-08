using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class kiUcNJVlbDiUFZMANgySDecsoISU : HZStzgFbKgQueAMMQVfvQcfMtXa
{
	[CompilerGenerated]
	private YcEKPykyufPoBZCDgnRECPtNieq MunasiFbHMOgJlEBsbOOidJnPa;

	public YcEKPykyufPoBZCDgnRECPtNieq Callback
	{
		[CompilerGenerated]
		get
		{
			return MunasiFbHMOgJlEBsbOOidJnPa;
		}
		[CompilerGenerated]
		private set
		{
			MunasiFbHMOgJlEBsbOOidJnPa = value;
		}
	}

	protected abstract DhfnTXocDlpvnmvADoLLNcCucRl GetVtbl { get; }

	public unsafe virtual void XcqbVqdtLKNrEHBlIGziwanWbzsI(YcEKPykyufPoBZCDgnRECPtNieq P_0)
	{
		Callback = P_0;
		base.NativePointer = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.NativePointer, GetVtbl.Pointer);
		((IntPtr*)(void*)base.NativePointer)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe override void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (base.NativePointer != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.NativePointer)[1]).Free();
			Marshal.FreeHGlobal(base.NativePointer);
			base.NativePointer = IntPtr.Zero;
		}
		Callback = null;
		base.WYoEhOBxiSjIYKwbsCHdGOUBXDbi(P_0);
	}

	internal unsafe static T fOCcfhJusOxlKwqUfroEWJdFgRmw<T>(IntPtr P_0) where T : kiUcNJVlbDiUFZMANgySDecsoISU
	{
		return (T)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
