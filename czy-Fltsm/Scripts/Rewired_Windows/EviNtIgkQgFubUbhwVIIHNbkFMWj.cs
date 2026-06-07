using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class EviNtIgkQgFubUbhwVIIHNbkFMWj
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int WSkzfWEeXDAONjEawOucasDnfqHd(void* deviceInstance, IntPtr data);

	private readonly IntPtr WOnpOjoJUJfSNRlTxZwTLZPeAaBn;

	private readonly WSkzfWEeXDAONjEawOucasDnfqHd udpZYfOBFTgqiVazcjsoSlUuLlNW;

	[CompilerGenerated]
	private List<aLSDFxIIAnFGinWoAXLDQXOymMRJ> npIQRJKNrAotVPNxsNAodoImEUsu;

	public IntPtr QRlelUKhsQGaMJdAgjxUyPUmEMyib => WOnpOjoJUJfSNRlTxZwTLZPeAaBn;

	public List<aLSDFxIIAnFGinWoAXLDQXOymMRJ> rgoHfPsigoSQXZBvzDaCQHPLFVSFA
	{
		[CompilerGenerated]
		get
		{
			return npIQRJKNrAotVPNxsNAodoImEUsu;
		}
		[CompilerGenerated]
		private set
		{
			npIQRJKNrAotVPNxsNAodoImEUsu = list;
		}
	}

	public unsafe EviNtIgkQgFubUbhwVIIHNbkFMWj()
	{
		udpZYfOBFTgqiVazcjsoSlUuLlNW = MdIgDnGhsfDlhvOvwMciBycwelMFA;
		WOnpOjoJUJfSNRlTxZwTLZPeAaBn = Marshal.GetFunctionPointerForDelegate(udpZYfOBFTgqiVazcjsoSlUuLlNW);
		rgoHfPsigoSQXZBvzDaCQHPLFVSFA = new List<aLSDFxIIAnFGinWoAXLDQXOymMRJ>();
	}

	[MonoPInvokeCallback(typeof(WSkzfWEeXDAONjEawOucasDnfqHd))]
	private unsafe static int MdIgDnGhsfDlhvOvwMciBycwelMFA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<EviNtIgkQgFubUbhwVIIHNbkFMWj>(instanceId, out var instance))
		{
			return 1;
		}
		aLSDFxIIAnFGinWoAXLDQXOymMRJ aLSDFxIIAnFGinWoAXLDQXOymMRJ2 = new aLSDFxIIAnFGinWoAXLDQXOymMRJ();
		aLSDFxIIAnFGinWoAXLDQXOymMRJ2.nlppwnKdotfmpxCQAEBdKWnuCcjjb(ref *(aLSDFxIIAnFGinWoAXLDQXOymMRJ.FrNcEkFjyYAoejCQfgmAIcegGWVeb*)P_0);
		instance.rgoHfPsigoSQXZBvzDaCQHPLFVSFA.Add(aLSDFxIIAnFGinWoAXLDQXOymMRJ2);
		return 1;
	}
}
