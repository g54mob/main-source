using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class LVbAjYjVnqLmmHuJDBGGsBdzcOcRA
{
	private readonly List<Delegate> ACJPLQwVryeKmFLvuSPRqsjXiaTT;

	private readonly IntPtr heyCzQaMdZTBhQaYubbztveWXnBiA;

	public IntPtr GpGKwckOeObdHOlbuOVdVYDANnIn => heyCzQaMdZTBhQaYubbztveWXnBiA;

	public LVbAjYjVnqLmmHuJDBGGsBdzcOcRA(int P_0)
	{
		heyCzQaMdZTBhQaYubbztveWXnBiA = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		ACJPLQwVryeKmFLvuSPRqsjXiaTT = new List<Delegate>();
	}

	public unsafe void shfnuSXjyHYPgdnSJtEKRfRxWJem(Delegate P_0)
	{
		int count = ACJPLQwVryeKmFLvuSPRqsjXiaTT.Count;
		ACJPLQwVryeKmFLvuSPRqsjXiaTT.Add(P_0);
		((IntPtr*)(void*)heyCzQaMdZTBhQaYubbztveWXnBiA)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
