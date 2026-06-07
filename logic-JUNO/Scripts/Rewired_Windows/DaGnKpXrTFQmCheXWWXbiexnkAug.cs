using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class DaGnKpXrTFQmCheXWWXbiexnkAug
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int KwlsveoYSUdGDJqtIGsymQRxTogS(void* deviceInstance, IntPtr data);

	private readonly IntPtr TBPCZoRNjMHFTLzQNhvhdIZmhnQe;

	private readonly KwlsveoYSUdGDJqtIGsymQRxTogS xqBfnMiarGcoDKqShxyLfYeHReLGA;

	[CompilerGenerated]
	private List<vxiCnzBiTAuClAvepiFbKnhCEGsW> RsXtgaOLmQjYvtSybcwFfowpdgZWA;

	public IntPtr zmKbsvjYEnBAricPHZLevXzrKnbyA => TBPCZoRNjMHFTLzQNhvhdIZmhnQe;

	public List<vxiCnzBiTAuClAvepiFbKnhCEGsW> IvkulNtRcWFXdXlwbVxPsgOfFmtG
	{
		[CompilerGenerated]
		get
		{
			return RsXtgaOLmQjYvtSybcwFfowpdgZWA;
		}
		[CompilerGenerated]
		private set
		{
			RsXtgaOLmQjYvtSybcwFfowpdgZWA = rsXtgaOLmQjYvtSybcwFfowpdgZWA;
		}
	}

	public unsafe DaGnKpXrTFQmCheXWWXbiexnkAug()
	{
		xqBfnMiarGcoDKqShxyLfYeHReLGA = GuSrrYUcPgogPorFYiizuREPqcIF;
		TBPCZoRNjMHFTLzQNhvhdIZmhnQe = Marshal.GetFunctionPointerForDelegate(xqBfnMiarGcoDKqShxyLfYeHReLGA);
		IvkulNtRcWFXdXlwbVxPsgOfFmtG = new List<vxiCnzBiTAuClAvepiFbKnhCEGsW>();
	}

	[MonoPInvokeCallback(typeof(KwlsveoYSUdGDJqtIGsymQRxTogS))]
	private unsafe static int GuSrrYUcPgogPorFYiizuREPqcIF(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<DaGnKpXrTFQmCheXWWXbiexnkAug>(instanceId, out var instance))
		{
			return 1;
		}
		vxiCnzBiTAuClAvepiFbKnhCEGsW vxiCnzBiTAuClAvepiFbKnhCEGsW2 = new vxiCnzBiTAuClAvepiFbKnhCEGsW();
		vxiCnzBiTAuClAvepiFbKnhCEGsW2.CEqNQdhUsluPdehDwvjZGgEufmA(ref *(vxiCnzBiTAuClAvepiFbKnhCEGsW.awWaSFqCQQjlxIjIzrBJYMkjhWfg*)P_0);
		instance.IvkulNtRcWFXdXlwbVxPsgOfFmtG.Add(vxiCnzBiTAuClAvepiFbKnhCEGsW2);
		return 1;
	}
}
