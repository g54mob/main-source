using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class WaorTXtnqkbfjuskgPhDutHhryHO
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int rzJODNjGQmaGLcGHezcEmmXKzViF(void* deviceInstance, IntPtr data);

	private readonly IntPtr EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	private readonly rzJODNjGQmaGLcGHezcEmmXKzViF SmCbULdHvFnyCWdLLpSYHEPsMuCV;

	[CompilerGenerated]
	private List<BgIhxwjXwppofLcqXhVNjPpQtyjP> lpxDTrliwsaHbhvCpJXhGzAoPGdcb;

	public IntPtr GMaPHoiZAJyngdXeSoVFwLOeWHKm => EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	public List<BgIhxwjXwppofLcqXhVNjPpQtyjP> oisyOZJaRVcMPkNDrkaVQzAcDqKT
	{
		[CompilerGenerated]
		get
		{
			return lpxDTrliwsaHbhvCpJXhGzAoPGdcb;
		}
		[CompilerGenerated]
		private set
		{
			lpxDTrliwsaHbhvCpJXhGzAoPGdcb = list;
		}
	}

	public unsafe WaorTXtnqkbfjuskgPhDutHhryHO()
	{
		SmCbULdHvFnyCWdLLpSYHEPsMuCV = INRQQNSVPHDiOaujOIJnstwhnPzw;
		EetGmuBhqQLYShPkdlGmBVJKSvCAb = Marshal.GetFunctionPointerForDelegate((Delegate)SmCbULdHvFnyCWdLLpSYHEPsMuCV);
		oisyOZJaRVcMPkNDrkaVQzAcDqKT = new List<BgIhxwjXwppofLcqXhVNjPpQtyjP>();
	}

	[MonoPInvokeCallback(typeof(rzJODNjGQmaGLcGHezcEmmXKzViF))]
	private unsafe static int INRQQNSVPHDiOaujOIJnstwhnPzw(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<WaorTXtnqkbfjuskgPhDutHhryHO>(instanceId, out var instance))
		{
			return 1;
		}
		BgIhxwjXwppofLcqXhVNjPpQtyjP item = new BgIhxwjXwppofLcqXhVNjPpQtyjP((IntPtr)P_0);
		instance.oisyOZJaRVcMPkNDrkaVQzAcDqKT.Add(item);
		return 1;
	}
}
