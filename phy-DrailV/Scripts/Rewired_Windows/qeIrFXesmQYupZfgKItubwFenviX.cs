using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class qeIrFXesmQYupZfgKItubwFenviX
{
	private readonly List<Delegate> wbsxCSJzRZAInKRcuQxdqgPewEmJ;

	private readonly IntPtr JzXYEbVXXGiuezksPcggDqyOAYpp;

	public IntPtr eRuooOpUXUMNyxAVfhJQXVsDGDql => JzXYEbVXXGiuezksPcggDqyOAYpp;

	public qeIrFXesmQYupZfgKItubwFenviX(int P_0)
	{
		JzXYEbVXXGiuezksPcggDqyOAYpp = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		wbsxCSJzRZAInKRcuQxdqgPewEmJ = new List<Delegate>();
	}

	public unsafe void IXgwkXpLPoCbHQDnUXKJxQSfpmng(Delegate P_0)
	{
		int count = wbsxCSJzRZAInKRcuQxdqgPewEmJ.Count;
		wbsxCSJzRZAInKRcuQxdqgPewEmJ.Add(P_0);
		((IntPtr*)(void*)JzXYEbVXXGiuezksPcggDqyOAYpp)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
