using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class sRGwxsXtuchvcBDkZpnIRLIgIIzg
{
	private readonly List<Delegate> dwiCIgyZfwoLykOlqeoTaFPQwuMr;

	private readonly IntPtr EUFwlkQatJKttLeIeUIxzZABvoMj;

	public IntPtr vHtdpQslyYwHTvqjgkvlPCdFvmHF => EUFwlkQatJKttLeIeUIxzZABvoMj;

	public sRGwxsXtuchvcBDkZpnIRLIgIIzg(int P_0)
	{
		EUFwlkQatJKttLeIeUIxzZABvoMj = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		dwiCIgyZfwoLykOlqeoTaFPQwuMr = new List<Delegate>();
	}

	public unsafe void XgAhwgPxlDbTuDMdFpWMOTzybCdEb(Delegate P_0)
	{
		int count = dwiCIgyZfwoLykOlqeoTaFPQwuMr.Count;
		dwiCIgyZfwoLykOlqeoTaFPQwuMr.Add(P_0);
		((IntPtr*)(void*)EUFwlkQatJKttLeIeUIxzZABvoMj)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
