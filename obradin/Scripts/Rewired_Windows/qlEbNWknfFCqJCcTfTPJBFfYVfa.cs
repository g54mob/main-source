using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class qlEbNWknfFCqJCcTfTPJBFfYVfa
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int tfFRNNGAJJbFQBgvIxcUkHkIezjL(void* deviceInstance, IntPtr data);

	private readonly IntPtr gCHLRLMMTROdfhHdjSeFpmVcoRj;

	private readonly tfFRNNGAJJbFQBgvIxcUkHkIezjL uQapxaGEDQOujgaUJWGffIJYTlv;

	[CompilerGenerated]
	private List<CwPulMNvQcCYLBIDFFYYMQMiYz> ziWLDfuJCsSwdyseaTXUOJAjlea;

	public IntPtr NativePointer
	{
		get
		{
			return gCHLRLMMTROdfhHdjSeFpmVcoRj;
		}
	}

	public List<CwPulMNvQcCYLBIDFFYYMQMiYz> Objects
	{
		[CompilerGenerated]
		get
		{
			return ziWLDfuJCsSwdyseaTXUOJAjlea;
		}
		[CompilerGenerated]
		private set
		{
			ziWLDfuJCsSwdyseaTXUOJAjlea = value;
		}
	}

	public unsafe qlEbNWknfFCqJCcTfTPJBFfYVfa()
	{
		uQapxaGEDQOujgaUJWGffIJYTlv = irnCLtZyznUcUfjGDrdLTQYdeJG;
		gCHLRLMMTROdfhHdjSeFpmVcoRj = Marshal.GetFunctionPointerForDelegate(uQapxaGEDQOujgaUJWGffIJYTlv);
		Objects = new List<CwPulMNvQcCYLBIDFFYYMQMiYz>();
	}

	[MonoPInvokeCallback(typeof(tfFRNNGAJJbFQBgvIxcUkHkIezjL))]
	private unsafe static int irnCLtZyznUcUfjGDrdLTQYdeJG(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		qlEbNWknfFCqJCcTfTPJBFfYVfa instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<qlEbNWknfFCqJCcTfTPJBFfYVfa>(instanceId, out instance))
		{
			return 1;
		}
		CwPulMNvQcCYLBIDFFYYMQMiYz cwPulMNvQcCYLBIDFFYYMQMiYz = new CwPulMNvQcCYLBIDFFYYMQMiYz();
		cwPulMNvQcCYLBIDFFYYMQMiYz.CCXHeHFCFsQDMbnwdqXpPnwaKpIy(ref *(CwPulMNvQcCYLBIDFFYYMQMiYz.pmebXFijVNNXCnZQSiMNlbZTfrbz*)P_0);
		instance.Objects.Add(cwPulMNvQcCYLBIDFFYYMQMiYz);
		return 1;
	}
}
