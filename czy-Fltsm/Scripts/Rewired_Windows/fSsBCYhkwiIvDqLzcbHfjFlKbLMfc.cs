using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class fSsBCYhkwiIvDqLzcbHfjFlKbLMfc
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int yNJIHeFxKvvMpxHlgpsZLAwpBUub(void* deviceInstance, IntPtr data);

	private readonly IntPtr xVxEpJkwirFwEtgFjNgxAmNmCOoR;

	private readonly yNJIHeFxKvvMpxHlgpsZLAwpBUub RYnKlfRYWtDQMKaeVhbDrfpBBqdL;

	[CompilerGenerated]
	private List<LUAvOYgjedilikZYXnAjfduEnrWS> bzfROHfCVvEnwDLADSfTBzbjTNbR;

	public IntPtr LKcBjUnPpCfMaUhvldWkoymnSGVq => xVxEpJkwirFwEtgFjNgxAmNmCOoR;

	public List<LUAvOYgjedilikZYXnAjfduEnrWS> cBIjPmJQDtqmiinOHPEXLZJdbwjXC
	{
		[CompilerGenerated]
		get
		{
			return bzfROHfCVvEnwDLADSfTBzbjTNbR;
		}
		[CompilerGenerated]
		private set
		{
			bzfROHfCVvEnwDLADSfTBzbjTNbR = list;
		}
	}

	public unsafe fSsBCYhkwiIvDqLzcbHfjFlKbLMfc()
	{
		RYnKlfRYWtDQMKaeVhbDrfpBBqdL = orahQlpmuRmLCOsvkUhvJEEHqJyS;
		xVxEpJkwirFwEtgFjNgxAmNmCOoR = Marshal.GetFunctionPointerForDelegate(RYnKlfRYWtDQMKaeVhbDrfpBBqdL);
		cBIjPmJQDtqmiinOHPEXLZJdbwjXC = new List<LUAvOYgjedilikZYXnAjfduEnrWS>();
	}

	[MonoPInvokeCallback(typeof(yNJIHeFxKvvMpxHlgpsZLAwpBUub))]
	private unsafe static int orahQlpmuRmLCOsvkUhvJEEHqJyS(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<fSsBCYhkwiIvDqLzcbHfjFlKbLMfc>(instanceId, out var instance))
		{
			return 1;
		}
		LUAvOYgjedilikZYXnAjfduEnrWS lUAvOYgjedilikZYXnAjfduEnrWS = new LUAvOYgjedilikZYXnAjfduEnrWS();
		lUAvOYgjedilikZYXnAjfduEnrWS.kIuNXgQMUpeYpNNSXCxfgtNoDRBq(ref *(LUAvOYgjedilikZYXnAjfduEnrWS.WTwGZeFbljIMkymqLQqJfexbkCBq*)P_0);
		instance.cBIjPmJQDtqmiinOHPEXLZJdbwjXC.Add(lUAvOYgjedilikZYXnAjfduEnrWS);
		return 1;
	}
}
