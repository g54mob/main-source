using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class tpKlPeAxNPnffreYUAHLiMuplZpK
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int fJTdRxjWvGXpgjKbkVmFOseYhoUG(void* deviceInstance, IntPtr data);

	private readonly IntPtr gCHLRLMMTROdfhHdjSeFpmVcoRj;

	private readonly fJTdRxjWvGXpgjKbkVmFOseYhoUG uQapxaGEDQOujgaUJWGffIJYTlv;

	[CompilerGenerated]
	private List<iIIajitZMoAPEsjDGKqCvjhJFOaC> GqZZbeZBAknpLaEaOTxWBIOQkxw;

	public IntPtr NativePointer
	{
		get
		{
			return gCHLRLMMTROdfhHdjSeFpmVcoRj;
		}
	}

	public List<iIIajitZMoAPEsjDGKqCvjhJFOaC> EffectsInFile
	{
		[CompilerGenerated]
		get
		{
			return GqZZbeZBAknpLaEaOTxWBIOQkxw;
		}
		[CompilerGenerated]
		private set
		{
			GqZZbeZBAknpLaEaOTxWBIOQkxw = value;
		}
	}

	public unsafe tpKlPeAxNPnffreYUAHLiMuplZpK()
	{
		uQapxaGEDQOujgaUJWGffIJYTlv = QAkIsMHkzyBKdFkANRJqPRWqplT;
		gCHLRLMMTROdfhHdjSeFpmVcoRj = Marshal.GetFunctionPointerForDelegate(uQapxaGEDQOujgaUJWGffIJYTlv);
		EffectsInFile = new List<iIIajitZMoAPEsjDGKqCvjhJFOaC>();
	}

	[MonoPInvokeCallback(typeof(fJTdRxjWvGXpgjKbkVmFOseYhoUG))]
	private unsafe static int QAkIsMHkzyBKdFkANRJqPRWqplT(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		tpKlPeAxNPnffreYUAHLiMuplZpK instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<tpKlPeAxNPnffreYUAHLiMuplZpK>(instanceId, out instance))
		{
			return 1;
		}
		iIIajitZMoAPEsjDGKqCvjhJFOaC iIIajitZMoAPEsjDGKqCvjhJFOaC2 = new iIIajitZMoAPEsjDGKqCvjhJFOaC();
		iIIajitZMoAPEsjDGKqCvjhJFOaC2.CCXHeHFCFsQDMbnwdqXpPnwaKpIy(ref *(iIIajitZMoAPEsjDGKqCvjhJFOaC.FcCueSpkrkZZZJfwXPdXoMgIaYJ*)P_0);
		instance.EffectsInFile.Add(iIIajitZMoAPEsjDGKqCvjhJFOaC2);
		return 1;
	}
}
