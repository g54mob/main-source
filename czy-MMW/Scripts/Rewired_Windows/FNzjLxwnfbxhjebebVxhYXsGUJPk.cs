using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class FNzjLxwnfbxhjebebVxhYXsGUJPk
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int ciAzIsnCdsDLZcVKpzUCONnTkZZX(void* deviceInstance, IntPtr data);

	private readonly IntPtr ymVappEPMvsaZuOWMLCUoaJiUXreA;

	private readonly ciAzIsnCdsDLZcVKpzUCONnTkZZX gSHQZHQftrMAozLJVInKqMACMrqe;

	[CompilerGenerated]
	private List<NmeNOpqJNpvsXZGMMFZCJOCAUrey> TCuSZAwPrLMFwXgEOyqkfLcegdwIA;

	public IntPtr TTSbSZLFWkdzOLRVkzLqHrDgoWeN => ymVappEPMvsaZuOWMLCUoaJiUXreA;

	public List<NmeNOpqJNpvsXZGMMFZCJOCAUrey> fGRlpcKWUbyogKdLVgFYtkdRtlFm
	{
		[CompilerGenerated]
		get
		{
			return TCuSZAwPrLMFwXgEOyqkfLcegdwIA;
		}
		[CompilerGenerated]
		private set
		{
			TCuSZAwPrLMFwXgEOyqkfLcegdwIA = tCuSZAwPrLMFwXgEOyqkfLcegdwIA;
		}
	}

	public unsafe FNzjLxwnfbxhjebebVxhYXsGUJPk()
	{
		gSHQZHQftrMAozLJVInKqMACMrqe = YFUFLvJNoIWouLjdxEDEHWFgPWpo;
		ymVappEPMvsaZuOWMLCUoaJiUXreA = Marshal.GetFunctionPointerForDelegate(gSHQZHQftrMAozLJVInKqMACMrqe);
		fGRlpcKWUbyogKdLVgFYtkdRtlFm = new List<NmeNOpqJNpvsXZGMMFZCJOCAUrey>();
	}

	[MonoPInvokeCallback(typeof(ciAzIsnCdsDLZcVKpzUCONnTkZZX))]
	private unsafe static int YFUFLvJNoIWouLjdxEDEHWFgPWpo(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<FNzjLxwnfbxhjebebVxhYXsGUJPk>(instanceId, out var instance))
		{
			return 1;
		}
		NmeNOpqJNpvsXZGMMFZCJOCAUrey nmeNOpqJNpvsXZGMMFZCJOCAUrey = new NmeNOpqJNpvsXZGMMFZCJOCAUrey();
		nmeNOpqJNpvsXZGMMFZCJOCAUrey.DEVdoYmOTEsVGGJxLvifhWZYvfaG(ref *(NmeNOpqJNpvsXZGMMFZCJOCAUrey.IzCmzhiSFMWPeScVIbvSopmTxYBm*)P_0);
		instance.fGRlpcKWUbyogKdLVgFYtkdRtlFm.Add(nmeNOpqJNpvsXZGMMFZCJOCAUrey);
		return 1;
	}
}
