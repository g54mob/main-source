using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class BUnDnWsKNpzYPvEanegVengIBKp
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int WqlgtTyBHrjhYWTBwJWgcfvMdNbf(void* deviceInstance, IntPtr data);

	private readonly IntPtr LPlsAsjSbYEgEEbGYGZZyfNqkbrF;

	private readonly WqlgtTyBHrjhYWTBwJWgcfvMdNbf VhknwtfwrDwomwZYEbeXTNsevuWc;

	[CompilerGenerated]
	private List<QPehVWUKQAvyCyMgNBScQJYRNVkD> YrtgedMEfIciNAPJGryHsuSwCOhcA;

	public IntPtr rVApNxsDjMIxWdyLtYRBiOMYQxGo => LPlsAsjSbYEgEEbGYGZZyfNqkbrF;

	public List<QPehVWUKQAvyCyMgNBScQJYRNVkD> UdFGRjmkpapkEmIIIgSwAOdwefVW
	{
		[CompilerGenerated]
		get
		{
			return YrtgedMEfIciNAPJGryHsuSwCOhcA;
		}
		[CompilerGenerated]
		private set
		{
			YrtgedMEfIciNAPJGryHsuSwCOhcA = yrtgedMEfIciNAPJGryHsuSwCOhcA;
		}
	}

	public unsafe BUnDnWsKNpzYPvEanegVengIBKp()
	{
		VhknwtfwrDwomwZYEbeXTNsevuWc = mrTYEAGAMBAcKYqpOtIHgyTVmVxH;
		LPlsAsjSbYEgEEbGYGZZyfNqkbrF = Marshal.GetFunctionPointerForDelegate(VhknwtfwrDwomwZYEbeXTNsevuWc);
		UdFGRjmkpapkEmIIIgSwAOdwefVW = new List<QPehVWUKQAvyCyMgNBScQJYRNVkD>();
	}

	[MonoPInvokeCallback(typeof(WqlgtTyBHrjhYWTBwJWgcfvMdNbf))]
	private unsafe static int mrTYEAGAMBAcKYqpOtIHgyTVmVxH(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<BUnDnWsKNpzYPvEanegVengIBKp>(instanceId, out var instance))
		{
			return 1;
		}
		QPehVWUKQAvyCyMgNBScQJYRNVkD item = new QPehVWUKQAvyCyMgNBScQJYRNVkD((IntPtr)P_0);
		instance.UdFGRjmkpapkEmIIIgSwAOdwefVW.Add(item);
		return 1;
	}
}
