using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class zmOJlfDCdiCGHeQbKxXwAxjfChSB
{
	private readonly List<Delegate> oXShbrkxUroHEVvqfcyWndkVezGE;

	private readonly IntPtr JfEHrAAUFChFWiZltQwZiufMxMrb;

	public IntPtr wLLCQXgyDPcTrSRsnhegUOBWHjTS => JfEHrAAUFChFWiZltQwZiufMxMrb;

	public zmOJlfDCdiCGHeQbKxXwAxjfChSB(int P_0)
	{
		JfEHrAAUFChFWiZltQwZiufMxMrb = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		oXShbrkxUroHEVvqfcyWndkVezGE = new List<Delegate>();
	}

	public unsafe void GIkUBlHtIEsoQxakWOEZGHDtXSdM(Delegate P_0)
	{
		int count = oXShbrkxUroHEVvqfcyWndkVezGE.Count;
		oXShbrkxUroHEVvqfcyWndkVezGE.Add(P_0);
		((IntPtr*)(void*)JfEHrAAUFChFWiZltQwZiufMxMrb)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
