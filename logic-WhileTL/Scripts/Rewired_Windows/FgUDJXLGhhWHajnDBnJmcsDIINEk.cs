using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class FgUDJXLGhhWHajnDBnJmcsDIINEk
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int RSBtsJsblcDsHFnufuNEbnzXnHUp(void* deviceInstance, IntPtr data);

	private readonly IntPtr ISXmNcLLklYzihMykauyFAuVLvSm;

	private readonly RSBtsJsblcDsHFnufuNEbnzXnHUp MsgdQZHArmPPyiCZWkdIRBkxqnWg;

	[CompilerGenerated]
	private List<QwScmJdmgUCtFSaUJsEzIDYwhVDrA> gLNLBNKruYcGUsnbJgbrpzlpadTW;

	public IntPtr EEEaoiMKSwLCOBgsTjMBeDlbgYMaA => ISXmNcLLklYzihMykauyFAuVLvSm;

	public List<QwScmJdmgUCtFSaUJsEzIDYwhVDrA> iKqqGFTgoXBWGBRKlUlSbXwbdmFjA
	{
		[CompilerGenerated]
		get
		{
			return gLNLBNKruYcGUsnbJgbrpzlpadTW;
		}
		[CompilerGenerated]
		private set
		{
			gLNLBNKruYcGUsnbJgbrpzlpadTW = list;
		}
	}

	public unsafe FgUDJXLGhhWHajnDBnJmcsDIINEk()
	{
		MsgdQZHArmPPyiCZWkdIRBkxqnWg = yugnCzEALCoqkJkXUBnHxFnXeasEA;
		ISXmNcLLklYzihMykauyFAuVLvSm = Marshal.GetFunctionPointerForDelegate((Delegate)MsgdQZHArmPPyiCZWkdIRBkxqnWg);
		iKqqGFTgoXBWGBRKlUlSbXwbdmFjA = new List<QwScmJdmgUCtFSaUJsEzIDYwhVDrA>();
	}

	[MonoPInvokeCallback(typeof(RSBtsJsblcDsHFnufuNEbnzXnHUp))]
	private unsafe static int yugnCzEALCoqkJkXUBnHxFnXeasEA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<FgUDJXLGhhWHajnDBnJmcsDIINEk>(instanceId, out var instance))
		{
			return 1;
		}
		QwScmJdmgUCtFSaUJsEzIDYwhVDrA qwScmJdmgUCtFSaUJsEzIDYwhVDrA = new QwScmJdmgUCtFSaUJsEzIDYwhVDrA();
		qwScmJdmgUCtFSaUJsEzIDYwhVDrA.sjPwxiJbxODcHrNnvJtANOHfHgFJA(ref *(QwScmJdmgUCtFSaUJsEzIDYwhVDrA.qjoBoZbvISmhxavZmtrzOyFadAXFA*)P_0);
		instance.iKqqGFTgoXBWGBRKlUlSbXwbdmFjA.Add(qwScmJdmgUCtFSaUJsEzIDYwhVDrA);
		return 1;
	}
}
