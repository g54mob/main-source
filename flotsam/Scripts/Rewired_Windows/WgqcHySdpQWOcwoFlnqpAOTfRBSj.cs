using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class WgqcHySdpQWOcwoFlnqpAOTfRBSj
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int LLTPAxuwraEamlYWzBzUxVHLlrjb(void* deviceInstance, IntPtr data);

	private readonly IntPtr SnHXyhdfxJjtejZnDIKvjNyvezPc;

	private readonly LLTPAxuwraEamlYWzBzUxVHLlrjb IDMEIsjDEIVYKHAlBtOXCdandFaD;

	[CompilerGenerated]
	private List<FlMSHkYjGDQfaVDyGFHjZpPSTNud> ToPlDoCdOToDfsMGLyoAnsstMEjN;

	public IntPtr kRifucgOSDAEaLCMijBYBbeHyvYBA => SnHXyhdfxJjtejZnDIKvjNyvezPc;

	public List<FlMSHkYjGDQfaVDyGFHjZpPSTNud> LvafuukOrXGmNBTHAUhEXRxrlBRA
	{
		[CompilerGenerated]
		get
		{
			return ToPlDoCdOToDfsMGLyoAnsstMEjN;
		}
		[CompilerGenerated]
		private set
		{
			ToPlDoCdOToDfsMGLyoAnsstMEjN = toPlDoCdOToDfsMGLyoAnsstMEjN;
		}
	}

	public unsafe WgqcHySdpQWOcwoFlnqpAOTfRBSj()
	{
		IDMEIsjDEIVYKHAlBtOXCdandFaD = tbohXGGjIQdwClmBkxYCrlWYuvuA;
		SnHXyhdfxJjtejZnDIKvjNyvezPc = Marshal.GetFunctionPointerForDelegate(IDMEIsjDEIVYKHAlBtOXCdandFaD);
		LvafuukOrXGmNBTHAUhEXRxrlBRA = new List<FlMSHkYjGDQfaVDyGFHjZpPSTNud>();
	}

	[MonoPInvokeCallback(typeof(LLTPAxuwraEamlYWzBzUxVHLlrjb))]
	private unsafe static int tbohXGGjIQdwClmBkxYCrlWYuvuA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<WgqcHySdpQWOcwoFlnqpAOTfRBSj>(instanceId, out var instance))
		{
			return 1;
		}
		FlMSHkYjGDQfaVDyGFHjZpPSTNud item = new FlMSHkYjGDQfaVDyGFHjZpPSTNud((IntPtr)P_0);
		instance.LvafuukOrXGmNBTHAUhEXRxrlBRA.Add(item);
		return 1;
	}
}
