using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class SYRJXsOvuAMgKQIQZTNnDojsuJwo
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int DsgLqCaIhyLgSNqLBArfkVrObpXFA(void* deviceInstance, IntPtr data);

	private readonly IntPtr WPwEkbnpcFuHQRkKpyqWoElkDgJHA;

	private readonly DsgLqCaIhyLgSNqLBArfkVrObpXFA SUdrpixPWYchihVLnyLILWPcifUU;

	[CompilerGenerated]
	private List<XrtLlTELuBOyElAOedzfGFRRvJSP> ZkeceDITBVbcHWRivWvUuGjsIEZD;

	public IntPtr iMLNzeqPAPoESfhHCdFUmqSUjZgi => WPwEkbnpcFuHQRkKpyqWoElkDgJHA;

	public List<XrtLlTELuBOyElAOedzfGFRRvJSP> TYWlOwqqRheiSdtYbgozEczumpzX
	{
		[CompilerGenerated]
		get
		{
			return ZkeceDITBVbcHWRivWvUuGjsIEZD;
		}
		[CompilerGenerated]
		private set
		{
			ZkeceDITBVbcHWRivWvUuGjsIEZD = zkeceDITBVbcHWRivWvUuGjsIEZD;
		}
	}

	public unsafe SYRJXsOvuAMgKQIQZTNnDojsuJwo()
	{
		SUdrpixPWYchihVLnyLILWPcifUU = jrOoKZYxuQATUJmnxCBCgyDNAyFeb;
		WPwEkbnpcFuHQRkKpyqWoElkDgJHA = Marshal.GetFunctionPointerForDelegate(SUdrpixPWYchihVLnyLILWPcifUU);
		TYWlOwqqRheiSdtYbgozEczumpzX = new List<XrtLlTELuBOyElAOedzfGFRRvJSP>();
	}

	[MonoPInvokeCallback(typeof(DsgLqCaIhyLgSNqLBArfkVrObpXFA))]
	private unsafe static int jrOoKZYxuQATUJmnxCBCgyDNAyFeb(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<SYRJXsOvuAMgKQIQZTNnDojsuJwo>(instanceId, out var instance))
		{
			return 1;
		}
		XrtLlTELuBOyElAOedzfGFRRvJSP item = new XrtLlTELuBOyElAOedzfGFRRvJSP((IntPtr)P_0);
		instance.TYWlOwqqRheiSdtYbgozEczumpzX.Add(item);
		return 1;
	}
}
