using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class sRgeWweVKGXQPqleXxsdDRFRGKuK
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int mBKVRaopitOMNQFcqYJFdiGBmU(void* deviceInstance, IntPtr data);

	private readonly IntPtr tkIGqgtIwxjuCkXnyDpVvseOkZD;

	private readonly mBKVRaopitOMNQFcqYJFdiGBmU fqbGqHjzpkWVQgbYWnLpGdohkzDz;

	[CompilerGenerated]
	private List<wgrxsaianMUzjNMhgoWaIreVzBL> jiTIlmEIfSJLDanelqyUuyKIQCT;

	public IntPtr NativePointer => tkIGqgtIwxjuCkXnyDpVvseOkZD;

	public List<wgrxsaianMUzjNMhgoWaIreVzBL> DeviceInstances
	{
		[CompilerGenerated]
		get
		{
			return jiTIlmEIfSJLDanelqyUuyKIQCT;
		}
		[CompilerGenerated]
		private set
		{
			jiTIlmEIfSJLDanelqyUuyKIQCT = value;
		}
	}

	public unsafe sRgeWweVKGXQPqleXxsdDRFRGKuK()
	{
		fqbGqHjzpkWVQgbYWnLpGdohkzDz = abldmrPcTlDDEAcbUeKPUszPZyO;
		tkIGqgtIwxjuCkXnyDpVvseOkZD = Marshal.GetFunctionPointerForDelegate((Delegate)fqbGqHjzpkWVQgbYWnLpGdohkzDz);
		DeviceInstances = new List<wgrxsaianMUzjNMhgoWaIreVzBL>();
	}

	[MonoPInvokeCallback(typeof(mBKVRaopitOMNQFcqYJFdiGBmU))]
	private unsafe static int abldmrPcTlDDEAcbUeKPUszPZyO(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<sRgeWweVKGXQPqleXxsdDRFRGKuK>(instanceId, out var instance))
		{
			return 1;
		}
		wgrxsaianMUzjNMhgoWaIreVzBL wgrxsaianMUzjNMhgoWaIreVzBL2 = new wgrxsaianMUzjNMhgoWaIreVzBL();
		wgrxsaianMUzjNMhgoWaIreVzBL2.ZXWljcfhlKeirbwwnVKxodNeLfEH(ref *(wgrxsaianMUzjNMhgoWaIreVzBL.vTMRlblFodeecWWBmSFaSnRSCLw*)P_0);
		instance.DeviceInstances.Add(wgrxsaianMUzjNMhgoWaIreVzBL2);
		return 1;
	}
}
