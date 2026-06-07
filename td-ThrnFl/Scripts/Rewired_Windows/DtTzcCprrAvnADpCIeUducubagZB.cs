using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class DtTzcCprrAvnADpCIeUducubagZB
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int PBsHWudpDZvbGnkCpIBqbIvAdqfT(void* deviceInstance, IntPtr data);

	private readonly IntPtr PHOWFEFRajxxTMdMwNKHDATfvvJl;

	private readonly PBsHWudpDZvbGnkCpIBqbIvAdqfT YRZoARFGJtEBacMKAeidVLRpkFEH;

	[CompilerGenerated]
	private List<AodSAiScqKpIYYZiIATPTmzBbbjJA> ZNZKDmuagTbKUjcGVlQddUhCkeFMb;

	public IntPtr qNbZQNSWgetCQRGuLNboYrAvMiNT => PHOWFEFRajxxTMdMwNKHDATfvvJl;

	public List<AodSAiScqKpIYYZiIATPTmzBbbjJA> NAzPZTgQCFKolLfihxVhcfKKtvKH
	{
		[CompilerGenerated]
		get
		{
			return ZNZKDmuagTbKUjcGVlQddUhCkeFMb;
		}
		[CompilerGenerated]
		private set
		{
			ZNZKDmuagTbKUjcGVlQddUhCkeFMb = zNZKDmuagTbKUjcGVlQddUhCkeFMb;
		}
	}

	public unsafe DtTzcCprrAvnADpCIeUducubagZB()
	{
		YRZoARFGJtEBacMKAeidVLRpkFEH = kpxfDshyEpqenPJkCcoNcloeQtvnc;
		PHOWFEFRajxxTMdMwNKHDATfvvJl = Marshal.GetFunctionPointerForDelegate(YRZoARFGJtEBacMKAeidVLRpkFEH);
		NAzPZTgQCFKolLfihxVhcfKKtvKH = new List<AodSAiScqKpIYYZiIATPTmzBbbjJA>();
	}

	[MonoPInvokeCallback(typeof(PBsHWudpDZvbGnkCpIBqbIvAdqfT))]
	private unsafe static int kpxfDshyEpqenPJkCcoNcloeQtvnc(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<DtTzcCprrAvnADpCIeUducubagZB>(instanceId, out var instance))
		{
			return 1;
		}
		AodSAiScqKpIYYZiIATPTmzBbbjJA aodSAiScqKpIYYZiIATPTmzBbbjJA = new AodSAiScqKpIYYZiIATPTmzBbbjJA();
		aodSAiScqKpIYYZiIATPTmzBbbjJA.ksDPrNrOHYLkInXhNbyYEfanjvGy(ref *(AodSAiScqKpIYYZiIATPTmzBbbjJA.wZRWYmFoIIGSsZqbrWgPiIiNVylO*)P_0);
		instance.NAzPZTgQCFKolLfihxVhcfKKtvKH.Add(aodSAiScqKpIYYZiIATPTmzBbbjJA);
		return 1;
	}
}
