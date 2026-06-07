using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class DBfTcoOkYAEvznadNRSKjOTILLnG
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int HJeOcbQrAIGxvJCQgWRRTISmaBWi(void* deviceInstance, IntPtr data);

	private readonly IntPtr ISXmNcLLklYzihMykauyFAuVLvSm;

	private readonly HJeOcbQrAIGxvJCQgWRRTISmaBWi MsgdQZHArmPPyiCZWkdIRBkxqnWg;

	[CompilerGenerated]
	private List<TzaSquScqQuKBKfZmMDjyRhGfmGP> OUUAZcgtWChBtAxszUBbwCmJFHUFb;

	public IntPtr EEEaoiMKSwLCOBgsTjMBeDlbgYMaA => ISXmNcLLklYzihMykauyFAuVLvSm;

	public List<TzaSquScqQuKBKfZmMDjyRhGfmGP> hscvyuuWXsMFnHZHuJGyxhCBuZCh
	{
		[CompilerGenerated]
		get
		{
			return OUUAZcgtWChBtAxszUBbwCmJFHUFb;
		}
		[CompilerGenerated]
		private set
		{
			OUUAZcgtWChBtAxszUBbwCmJFHUFb = oUUAZcgtWChBtAxszUBbwCmJFHUFb;
		}
	}

	public unsafe DBfTcoOkYAEvznadNRSKjOTILLnG()
	{
		MsgdQZHArmPPyiCZWkdIRBkxqnWg = HPmKabhvLjFHyJkmAhhqHsbGHbZVA;
		ISXmNcLLklYzihMykauyFAuVLvSm = Marshal.GetFunctionPointerForDelegate((Delegate)MsgdQZHArmPPyiCZWkdIRBkxqnWg);
		hscvyuuWXsMFnHZHuJGyxhCBuZCh = new List<TzaSquScqQuKBKfZmMDjyRhGfmGP>();
	}

	[MonoPInvokeCallback(typeof(HJeOcbQrAIGxvJCQgWRRTISmaBWi))]
	private unsafe static int HPmKabhvLjFHyJkmAhhqHsbGHbZVA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<DBfTcoOkYAEvznadNRSKjOTILLnG>(instanceId, out var instance))
		{
			return 1;
		}
		TzaSquScqQuKBKfZmMDjyRhGfmGP tzaSquScqQuKBKfZmMDjyRhGfmGP = new TzaSquScqQuKBKfZmMDjyRhGfmGP();
		tzaSquScqQuKBKfZmMDjyRhGfmGP.sjPwxiJbxODcHrNnvJtANOHfHgFJA(ref *(TzaSquScqQuKBKfZmMDjyRhGfmGP.IPIQnsGaydpkkVIYyzvdHuTVTixK*)P_0);
		instance.hscvyuuWXsMFnHZHuJGyxhCBuZCh.Add(tzaSquScqQuKBKfZmMDjyRhGfmGP);
		return 1;
	}
}
