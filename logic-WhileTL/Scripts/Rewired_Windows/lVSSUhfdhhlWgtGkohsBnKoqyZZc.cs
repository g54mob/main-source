using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class lVSSUhfdhhlWgtGkohsBnKoqyZZc
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int yuxTWaMBoattbJNoebBAGvnqyqTUA(void* deviceInstance, IntPtr data);

	private readonly IntPtr ISXmNcLLklYzihMykauyFAuVLvSm;

	private readonly yuxTWaMBoattbJNoebBAGvnqyqTUA MsgdQZHArmPPyiCZWkdIRBkxqnWg;

	[CompilerGenerated]
	private List<DanGrRdlaxdHxAlTEuJYVPHCOJeb> EOAYBhhBSuXuiAkDgxLEySjKSCXd;

	public IntPtr EEEaoiMKSwLCOBgsTjMBeDlbgYMaA => ISXmNcLLklYzihMykauyFAuVLvSm;

	public List<DanGrRdlaxdHxAlTEuJYVPHCOJeb> cZdjVUFgLPdsehmRWSkrwQKOyGSRA
	{
		[CompilerGenerated]
		get
		{
			return EOAYBhhBSuXuiAkDgxLEySjKSCXd;
		}
		[CompilerGenerated]
		private set
		{
			EOAYBhhBSuXuiAkDgxLEySjKSCXd = eOAYBhhBSuXuiAkDgxLEySjKSCXd;
		}
	}

	public unsafe lVSSUhfdhhlWgtGkohsBnKoqyZZc()
	{
		MsgdQZHArmPPyiCZWkdIRBkxqnWg = RXQfqJBTvIzIrjqdeqCvkWHsfDumA;
		ISXmNcLLklYzihMykauyFAuVLvSm = Marshal.GetFunctionPointerForDelegate((Delegate)MsgdQZHArmPPyiCZWkdIRBkxqnWg);
		cZdjVUFgLPdsehmRWSkrwQKOyGSRA = new List<DanGrRdlaxdHxAlTEuJYVPHCOJeb>();
	}

	[MonoPInvokeCallback(typeof(yuxTWaMBoattbJNoebBAGvnqyqTUA))]
	private unsafe static int RXQfqJBTvIzIrjqdeqCvkWHsfDumA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<lVSSUhfdhhlWgtGkohsBnKoqyZZc>(instanceId, out var instance))
		{
			return 1;
		}
		DanGrRdlaxdHxAlTEuJYVPHCOJeb danGrRdlaxdHxAlTEuJYVPHCOJeb = new DanGrRdlaxdHxAlTEuJYVPHCOJeb();
		danGrRdlaxdHxAlTEuJYVPHCOJeb.sjPwxiJbxODcHrNnvJtANOHfHgFJA(ref *(DanGrRdlaxdHxAlTEuJYVPHCOJeb.mOqANLJuXyGAuhZIfCTkXqLbSQYC*)P_0);
		instance.cZdjVUFgLPdsehmRWSkrwQKOyGSRA.Add(danGrRdlaxdHxAlTEuJYVPHCOJeb);
		return 1;
	}
}
