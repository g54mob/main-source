using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class EpiQkzHqJWHsmJWGtzHyFvtkMoVeb
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int IkgIYnxcnxepMilppQSSJMobcACOA(void* deviceInstance, IntPtr data);

	private readonly IntPtr EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	private readonly IkgIYnxcnxepMilppQSSJMobcACOA SmCbULdHvFnyCWdLLpSYHEPsMuCV;

	[CompilerGenerated]
	private List<mGCtkWxfHNgipjpNJrPlMcYgiHAeb> VqiziYJSpnEVMMinecXtgTHVAmFQ;

	public IntPtr GMaPHoiZAJyngdXeSoVFwLOeWHKm => EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	public List<mGCtkWxfHNgipjpNJrPlMcYgiHAeb> CDdmyUMzmklqyHuxQRUnfGmcgAtx
	{
		[CompilerGenerated]
		get
		{
			return VqiziYJSpnEVMMinecXtgTHVAmFQ;
		}
		[CompilerGenerated]
		private set
		{
			VqiziYJSpnEVMMinecXtgTHVAmFQ = vqiziYJSpnEVMMinecXtgTHVAmFQ;
		}
	}

	public unsafe EpiQkzHqJWHsmJWGtzHyFvtkMoVeb()
	{
		SmCbULdHvFnyCWdLLpSYHEPsMuCV = GQNsiIoWBgTyjZxVTsvejMUVCvvk;
		EetGmuBhqQLYShPkdlGmBVJKSvCAb = Marshal.GetFunctionPointerForDelegate((Delegate)SmCbULdHvFnyCWdLLpSYHEPsMuCV);
		CDdmyUMzmklqyHuxQRUnfGmcgAtx = new List<mGCtkWxfHNgipjpNJrPlMcYgiHAeb>();
	}

	[MonoPInvokeCallback(typeof(IkgIYnxcnxepMilppQSSJMobcACOA))]
	private unsafe static int GQNsiIoWBgTyjZxVTsvejMUVCvvk(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<EpiQkzHqJWHsmJWGtzHyFvtkMoVeb>(instanceId, out var instance))
		{
			return 1;
		}
		mGCtkWxfHNgipjpNJrPlMcYgiHAeb mGCtkWxfHNgipjpNJrPlMcYgiHAeb2 = new mGCtkWxfHNgipjpNJrPlMcYgiHAeb();
		mGCtkWxfHNgipjpNJrPlMcYgiHAeb2.ubvFUqtErpTMhZPdcRbSTBcoJcFu(ref *(mGCtkWxfHNgipjpNJrPlMcYgiHAeb.RmLbXXsPhyHBrlVhuIogHEgoytAKA*)P_0);
		instance.CDdmyUMzmklqyHuxQRUnfGmcgAtx.Add(mGCtkWxfHNgipjpNJrPlMcYgiHAeb2);
		return 1;
	}
}
