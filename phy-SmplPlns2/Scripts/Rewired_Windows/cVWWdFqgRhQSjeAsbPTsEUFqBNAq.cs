using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class cVWWdFqgRhQSjeAsbPTsEUFqBNAq
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int pKfjoYTCtmAJeGSYbzUlKiJgRgMg(void* deviceInstance, IntPtr data);

	private readonly IntPtr uZPOQQiWPkODyIZQuQasVAnfHCcKA;

	private readonly pKfjoYTCtmAJeGSYbzUlKiJgRgMg GVPxuxFlGsoJozrJGfXGcTvMROnd;

	[CompilerGenerated]
	private List<KswZlTgxZepEMLQDWtOwkjSBrdWW> gvHsDGtjeqdGOuwDCElSGpZsRgpm;

	public IntPtr OpUbwLbSQPnYSnoiyTIxnnWgpGBn => uZPOQQiWPkODyIZQuQasVAnfHCcKA;

	public List<KswZlTgxZepEMLQDWtOwkjSBrdWW> tdsWudKggimBQCyVQcQIWrrgGwRo
	{
		[CompilerGenerated]
		get
		{
			return gvHsDGtjeqdGOuwDCElSGpZsRgpm;
		}
		[CompilerGenerated]
		private set
		{
			gvHsDGtjeqdGOuwDCElSGpZsRgpm = list;
		}
	}

	public unsafe cVWWdFqgRhQSjeAsbPTsEUFqBNAq()
	{
		GVPxuxFlGsoJozrJGfXGcTvMROnd = tOWLlwhiJQKecvDanmrkUesUFRwz;
		uZPOQQiWPkODyIZQuQasVAnfHCcKA = Marshal.GetFunctionPointerForDelegate(GVPxuxFlGsoJozrJGfXGcTvMROnd);
		tdsWudKggimBQCyVQcQIWrrgGwRo = new List<KswZlTgxZepEMLQDWtOwkjSBrdWW>();
	}

	[MonoPInvokeCallback(typeof(pKfjoYTCtmAJeGSYbzUlKiJgRgMg))]
	private unsafe static int tOWLlwhiJQKecvDanmrkUesUFRwz(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<cVWWdFqgRhQSjeAsbPTsEUFqBNAq>(instanceId, out var instance))
		{
			return 1;
		}
		KswZlTgxZepEMLQDWtOwkjSBrdWW kswZlTgxZepEMLQDWtOwkjSBrdWW = new KswZlTgxZepEMLQDWtOwkjSBrdWW();
		kswZlTgxZepEMLQDWtOwkjSBrdWW.nLYIcpUVdoNrFcjJQgjyehfvjBTLA(ref *(KswZlTgxZepEMLQDWtOwkjSBrdWW.RQSLufXISamhKRxhYbkWkgZkCWBcA*)P_0);
		instance.tdsWudKggimBQCyVQcQIWrrgGwRo.Add(kswZlTgxZepEMLQDWtOwkjSBrdWW);
		return 1;
	}
}
