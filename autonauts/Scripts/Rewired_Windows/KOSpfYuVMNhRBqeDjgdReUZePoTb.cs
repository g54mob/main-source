using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class KOSpfYuVMNhRBqeDjgdReUZePoTb
{
	private readonly List<Delegate> QLqJNXFRhEFPJzhZJEgEBTJgpcN;

	private readonly IntPtr vvJUeiFqjPbjEKIVqMaFoByCgPAI;

	public IntPtr Pointer
	{
		get
		{
			return vvJUeiFqjPbjEKIVqMaFoByCgPAI;
		}
	}

	public KOSpfYuVMNhRBqeDjgdReUZePoTb(int numberOfCallbackMethods)
	{
		vvJUeiFqjPbjEKIVqMaFoByCgPAI = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
		QLqJNXFRhEFPJzhZJEgEBTJgpcN = new List<Delegate>();
	}

	public unsafe void yOsCNUpjNbXuhxSXpVhyIGknimM(Delegate P_0)
	{
		int count = QLqJNXFRhEFPJzhZJEgEBTJgpcN.Count;
		QLqJNXFRhEFPJzhZJEgEBTJgpcN.Add(P_0);
		((IntPtr*)(void*)vvJUeiFqjPbjEKIVqMaFoByCgPAI)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
