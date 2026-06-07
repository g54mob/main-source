using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class SWakJJwcOXdUlDvznHmUSuWuXrJtA
{
	private readonly List<Delegate> RVAvjRLOQLksrAgPSCvPRuGUgTcY;

	private readonly IntPtr kudHVZrUGiCngjHwQMLpEnLTxIkW;

	public IntPtr LjVZYhXVTjJPIVhRCSpdiNaZpGzq => kudHVZrUGiCngjHwQMLpEnLTxIkW;

	public SWakJJwcOXdUlDvznHmUSuWuXrJtA(int P_0)
	{
		kudHVZrUGiCngjHwQMLpEnLTxIkW = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		RVAvjRLOQLksrAgPSCvPRuGUgTcY = new List<Delegate>();
	}

	public unsafe void xlsTVRoOAaegdaNPrLWMoBowxGTJ(Delegate P_0)
	{
		int count = RVAvjRLOQLksrAgPSCvPRuGUgTcY.Count;
		RVAvjRLOQLksrAgPSCvPRuGUgTcY.Add(P_0);
		((IntPtr*)(void*)kudHVZrUGiCngjHwQMLpEnLTxIkW)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
