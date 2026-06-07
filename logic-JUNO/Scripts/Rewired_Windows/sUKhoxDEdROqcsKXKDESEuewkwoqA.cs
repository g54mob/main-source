using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class sUKhoxDEdROqcsKXKDESEuewkwoqA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int usWNAhlQNmlvIBWsYNTsLOxrUEdt(void* deviceInstance, IntPtr data);

	private readonly IntPtr iBTnINIpmWhWjujRinVcbWcoZzq;

	private readonly usWNAhlQNmlvIBWsYNTsLOxrUEdt CYTadSvWswSJndHVIGbmHrVkzInRA;

	[CompilerGenerated]
	private List<IAgdmKbxxCierJHKqWSFAjDwBDjEb> LAisIylGKnSlWdDDWFfmSGVcvFIL;

	public IntPtr mXPAVhtFvjBEJXijGqxAuLXyprYd => iBTnINIpmWhWjujRinVcbWcoZzq;

	public List<IAgdmKbxxCierJHKqWSFAjDwBDjEb> LKYwoaJsZRAbIgxXNXfOKhUHLkihb
	{
		[CompilerGenerated]
		get
		{
			return LAisIylGKnSlWdDDWFfmSGVcvFIL;
		}
		[CompilerGenerated]
		private set
		{
			LAisIylGKnSlWdDDWFfmSGVcvFIL = lAisIylGKnSlWdDDWFfmSGVcvFIL;
		}
	}

	public unsafe sUKhoxDEdROqcsKXKDESEuewkwoqA()
	{
		CYTadSvWswSJndHVIGbmHrVkzInRA = sKygsCQoNQKvcapHAbAcXixeOXgk;
		iBTnINIpmWhWjujRinVcbWcoZzq = Marshal.GetFunctionPointerForDelegate(CYTadSvWswSJndHVIGbmHrVkzInRA);
		LKYwoaJsZRAbIgxXNXfOKhUHLkihb = new List<IAgdmKbxxCierJHKqWSFAjDwBDjEb>();
	}

	[MonoPInvokeCallback(typeof(usWNAhlQNmlvIBWsYNTsLOxrUEdt))]
	private unsafe static int sKygsCQoNQKvcapHAbAcXixeOXgk(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<sUKhoxDEdROqcsKXKDESEuewkwoqA>(instanceId, out var instance))
		{
			return 1;
		}
		IAgdmKbxxCierJHKqWSFAjDwBDjEb agdmKbxxCierJHKqWSFAjDwBDjEb = new IAgdmKbxxCierJHKqWSFAjDwBDjEb();
		agdmKbxxCierJHKqWSFAjDwBDjEb.BlLuKGvmHIjZwFoayZMjxEsseNTDA(ref *(IAgdmKbxxCierJHKqWSFAjDwBDjEb.tEbWPHiGLfbXnRNaRytQNcdoFtjgA*)P_0);
		instance.LKYwoaJsZRAbIgxXNXfOKhUHLkihb.Add(agdmKbxxCierJHKqWSFAjDwBDjEb);
		return 1;
	}
}
