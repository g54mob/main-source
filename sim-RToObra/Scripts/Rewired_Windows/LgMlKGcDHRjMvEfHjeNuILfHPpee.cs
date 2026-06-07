using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class LgMlKGcDHRjMvEfHjeNuILfHPpee
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int sAczZhVUAKPxdtgbxpGMzBrrfLQe(void* deviceInstance, IntPtr data);

	private readonly IntPtr gCHLRLMMTROdfhHdjSeFpmVcoRj;

	private readonly sAczZhVUAKPxdtgbxpGMzBrrfLQe uQapxaGEDQOujgaUJWGffIJYTlv;

	[CompilerGenerated]
	private List<bccKCUcyBKIsSSvyKGasfkgcTNw> azQDGAusjKBwtfSpbxHbECzzjFkr;

	public IntPtr NativePointer
	{
		get
		{
			return gCHLRLMMTROdfhHdjSeFpmVcoRj;
		}
	}

	public List<bccKCUcyBKIsSSvyKGasfkgcTNw> EffectInfos
	{
		[CompilerGenerated]
		get
		{
			return azQDGAusjKBwtfSpbxHbECzzjFkr;
		}
		[CompilerGenerated]
		private set
		{
			azQDGAusjKBwtfSpbxHbECzzjFkr = value;
		}
	}

	public unsafe LgMlKGcDHRjMvEfHjeNuILfHPpee()
	{
		uQapxaGEDQOujgaUJWGffIJYTlv = voGkXcUEHylUaeGkzfuMwzqXnAN;
		gCHLRLMMTROdfhHdjSeFpmVcoRj = Marshal.GetFunctionPointerForDelegate(uQapxaGEDQOujgaUJWGffIJYTlv);
		EffectInfos = new List<bccKCUcyBKIsSSvyKGasfkgcTNw>();
	}

	[MonoPInvokeCallback(typeof(sAczZhVUAKPxdtgbxpGMzBrrfLQe))]
	private unsafe static int voGkXcUEHylUaeGkzfuMwzqXnAN(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		LgMlKGcDHRjMvEfHjeNuILfHPpee instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<LgMlKGcDHRjMvEfHjeNuILfHPpee>(instanceId, out instance))
		{
			return 1;
		}
		bccKCUcyBKIsSSvyKGasfkgcTNw bccKCUcyBKIsSSvyKGasfkgcTNw2 = new bccKCUcyBKIsSSvyKGasfkgcTNw();
		bccKCUcyBKIsSSvyKGasfkgcTNw2.CCXHeHFCFsQDMbnwdqXpPnwaKpIy(ref *(bccKCUcyBKIsSSvyKGasfkgcTNw.pwZhhVRcOdDyoovAOBgjbzimZdC*)P_0);
		instance.EffectInfos.Add(bccKCUcyBKIsSSvyKGasfkgcTNw2);
		return 1;
	}
}
