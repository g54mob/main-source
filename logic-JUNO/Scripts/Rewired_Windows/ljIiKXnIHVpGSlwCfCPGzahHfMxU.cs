using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class ljIiKXnIHVpGSlwCfCPGzahHfMxU
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int pkLTPHrHzdDxrBZzGOpcLiywqMchA(void* deviceInstance, IntPtr data);

	private readonly IntPtr lrMBlFJURotggyfBOhJgCSJOLOEb;

	private readonly pkLTPHrHzdDxrBZzGOpcLiywqMchA oNwbliBNxTOJPUAphEXhUBEFbWJN;

	[CompilerGenerated]
	private List<eFKGNVWtQeUVbuyDdjMHIWodHBcm> pJyCUFGuWhtGzPExaiipgJiAJOObb;

	public IntPtr WRQHFoMaOUiKffxTqwFkZbPNuKMS => lrMBlFJURotggyfBOhJgCSJOLOEb;

	public List<eFKGNVWtQeUVbuyDdjMHIWodHBcm> nsIEjagaunSEKrDJWBCbtbJkLjJj
	{
		[CompilerGenerated]
		get
		{
			return pJyCUFGuWhtGzPExaiipgJiAJOObb;
		}
		[CompilerGenerated]
		private set
		{
			pJyCUFGuWhtGzPExaiipgJiAJOObb = list;
		}
	}

	public unsafe ljIiKXnIHVpGSlwCfCPGzahHfMxU()
	{
		oNwbliBNxTOJPUAphEXhUBEFbWJN = CUWnQTeSkPrqOxpLxhMVaUjisLgR;
		lrMBlFJURotggyfBOhJgCSJOLOEb = Marshal.GetFunctionPointerForDelegate(oNwbliBNxTOJPUAphEXhUBEFbWJN);
		nsIEjagaunSEKrDJWBCbtbJkLjJj = new List<eFKGNVWtQeUVbuyDdjMHIWodHBcm>();
	}

	[MonoPInvokeCallback(typeof(pkLTPHrHzdDxrBZzGOpcLiywqMchA))]
	private unsafe static int CUWnQTeSkPrqOxpLxhMVaUjisLgR(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<ljIiKXnIHVpGSlwCfCPGzahHfMxU>(instanceId, out var instance))
		{
			return 1;
		}
		eFKGNVWtQeUVbuyDdjMHIWodHBcm eFKGNVWtQeUVbuyDdjMHIWodHBcm2 = new eFKGNVWtQeUVbuyDdjMHIWodHBcm();
		eFKGNVWtQeUVbuyDdjMHIWodHBcm2.OMqggyijfmNmpNtIgYUQJqfXDvJK(ref *(eFKGNVWtQeUVbuyDdjMHIWodHBcm.MSmJTLTGqowUTxnEWfMNcldvvWujA*)P_0);
		instance.nsIEjagaunSEKrDJWBCbtbJkLjJj.Add(eFKGNVWtQeUVbuyDdjMHIWodHBcm2);
		return 1;
	}
}
