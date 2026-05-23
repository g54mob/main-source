using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class WZmAcmTOKJBWCvtjWGhZBJHWdeXD
{
	private readonly List<Delegate> SbKkExemrQvMUcOxwNOKWyPUuzX;

	private readonly IntPtr xQhhjMcrcBiTDRrwZiZhfsYmBMt;

	public IntPtr Pointer
	{
		get
		{
			return xQhhjMcrcBiTDRrwZiZhfsYmBMt;
		}
	}

	public WZmAcmTOKJBWCvtjWGhZBJHWdeXD(int numberOfCallbackMethods)
	{
		xQhhjMcrcBiTDRrwZiZhfsYmBMt = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
		SbKkExemrQvMUcOxwNOKWyPUuzX = new List<Delegate>();
	}

	public unsafe void uDKiPoBQnnPQqLgqMdXgjXYVZsWq(Delegate P_0)
	{
		int count = SbKkExemrQvMUcOxwNOKWyPUuzX.Count;
		SbKkExemrQvMUcOxwNOKWyPUuzX.Add(P_0);
		((IntPtr*)(void*)xQhhjMcrcBiTDRrwZiZhfsYmBMt)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
