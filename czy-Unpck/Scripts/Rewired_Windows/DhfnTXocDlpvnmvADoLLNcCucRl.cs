using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class DhfnTXocDlpvnmvADoLLNcCucRl
{
	private readonly List<Delegate> ZlVuLAHMLaEjnDzvrfZQWLmwItlK;

	private readonly IntPtr mBcipxDrZjNyiUrpSzLNtrVMXno;

	public IntPtr Pointer => mBcipxDrZjNyiUrpSzLNtrVMXno;

	public DhfnTXocDlpvnmvADoLLNcCucRl(int numberOfCallbackMethods)
	{
		mBcipxDrZjNyiUrpSzLNtrVMXno = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
		ZlVuLAHMLaEjnDzvrfZQWLmwItlK = new List<Delegate>();
	}

	public unsafe void lBHNSZbAVNerRAfkRkIsFHtcvewn(Delegate P_0)
	{
		int count = ZlVuLAHMLaEjnDzvrfZQWLmwItlK.Count;
		ZlVuLAHMLaEjnDzvrfZQWLmwItlK.Add(P_0);
		((IntPtr*)(void*)mBcipxDrZjNyiUrpSzLNtrVMXno)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
