using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class UGYcLfBfRfOHAyaOwffaAnSfXuTgb
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int NVNZDOTzRyRfVDjiLajsCXEGUFCn(void* deviceInstance, IntPtr data);

	private readonly IntPtr ISXmNcLLklYzihMykauyFAuVLvSm;

	private readonly NVNZDOTzRyRfVDjiLajsCXEGUFCn MsgdQZHArmPPyiCZWkdIRBkxqnWg;

	[CompilerGenerated]
	private List<awcGNSLeBwuDDBpLMflzghvdBTKv> PfQHHCdwvWKjekIttVpriCmKLgZo;

	public IntPtr EEEaoiMKSwLCOBgsTjMBeDlbgYMaA => ISXmNcLLklYzihMykauyFAuVLvSm;

	public List<awcGNSLeBwuDDBpLMflzghvdBTKv> QLPUZCufuXLNCpepZalfEhJnqStDA
	{
		[CompilerGenerated]
		get
		{
			return PfQHHCdwvWKjekIttVpriCmKLgZo;
		}
		[CompilerGenerated]
		private set
		{
			PfQHHCdwvWKjekIttVpriCmKLgZo = pfQHHCdwvWKjekIttVpriCmKLgZo;
		}
	}

	public unsafe UGYcLfBfRfOHAyaOwffaAnSfXuTgb()
	{
		MsgdQZHArmPPyiCZWkdIRBkxqnWg = CbbDBYAGXHoRXYpBSnJqnxnYHMrQA;
		ISXmNcLLklYzihMykauyFAuVLvSm = Marshal.GetFunctionPointerForDelegate((Delegate)MsgdQZHArmPPyiCZWkdIRBkxqnWg);
		QLPUZCufuXLNCpepZalfEhJnqStDA = new List<awcGNSLeBwuDDBpLMflzghvdBTKv>();
	}

	[MonoPInvokeCallback(typeof(NVNZDOTzRyRfVDjiLajsCXEGUFCn))]
	private unsafe static int CbbDBYAGXHoRXYpBSnJqnxnYHMrQA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<UGYcLfBfRfOHAyaOwffaAnSfXuTgb>(instanceId, out var instance))
		{
			return 1;
		}
		awcGNSLeBwuDDBpLMflzghvdBTKv awcGNSLeBwuDDBpLMflzghvdBTKv2 = new awcGNSLeBwuDDBpLMflzghvdBTKv();
		awcGNSLeBwuDDBpLMflzghvdBTKv2.sjPwxiJbxODcHrNnvJtANOHfHgFJA(ref *(awcGNSLeBwuDDBpLMflzghvdBTKv.ZRhPmFAwrJvkPNnhlgMyiYXrglGTA*)P_0);
		instance.QLPUZCufuXLNCpepZalfEhJnqStDA.Add(awcGNSLeBwuDDBpLMflzghvdBTKv2);
		return 1;
	}
}
