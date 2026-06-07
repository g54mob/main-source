using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class JQscIDfypAtAYJtRSBIoiqvJEYGd
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int vSKFVbcfctmCcCGUcfDCcdfbKpZQA(void* deviceInstance, IntPtr data);

	private readonly IntPtr EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	private readonly vSKFVbcfctmCcCGUcfDCcdfbKpZQA SmCbULdHvFnyCWdLLpSYHEPsMuCV;

	[CompilerGenerated]
	private List<ANsLNXWEspDSdAKCSAshgFvgdXNrb> yWzcmHgewlonckCfOFZtknGgUtDqA;

	public IntPtr GMaPHoiZAJyngdXeSoVFwLOeWHKm => EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	public List<ANsLNXWEspDSdAKCSAshgFvgdXNrb> sSSahLzUwkbnqFvUyoRQlhNiQgPgA
	{
		[CompilerGenerated]
		get
		{
			return yWzcmHgewlonckCfOFZtknGgUtDqA;
		}
		[CompilerGenerated]
		private set
		{
			yWzcmHgewlonckCfOFZtknGgUtDqA = list;
		}
	}

	public unsafe JQscIDfypAtAYJtRSBIoiqvJEYGd()
	{
		SmCbULdHvFnyCWdLLpSYHEPsMuCV = aDAglrfuRnhNChnDjLFFBbUrMmuXb;
		EetGmuBhqQLYShPkdlGmBVJKSvCAb = Marshal.GetFunctionPointerForDelegate((Delegate)SmCbULdHvFnyCWdLLpSYHEPsMuCV);
		sSSahLzUwkbnqFvUyoRQlhNiQgPgA = new List<ANsLNXWEspDSdAKCSAshgFvgdXNrb>();
	}

	[MonoPInvokeCallback(typeof(vSKFVbcfctmCcCGUcfDCcdfbKpZQA))]
	private unsafe static int aDAglrfuRnhNChnDjLFFBbUrMmuXb(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<JQscIDfypAtAYJtRSBIoiqvJEYGd>(instanceId, out var instance))
		{
			return 1;
		}
		ANsLNXWEspDSdAKCSAshgFvgdXNrb aNsLNXWEspDSdAKCSAshgFvgdXNrb = new ANsLNXWEspDSdAKCSAshgFvgdXNrb();
		aNsLNXWEspDSdAKCSAshgFvgdXNrb.ubvFUqtErpTMhZPdcRbSTBcoJcFu(ref *(ANsLNXWEspDSdAKCSAshgFvgdXNrb.VRaprLJZbHmCMJmogkeljzgumtUE*)P_0);
		instance.sSSahLzUwkbnqFvUyoRQlhNiQgPgA.Add(aNsLNXWEspDSdAKCSAshgFvgdXNrb);
		return 1;
	}
}
