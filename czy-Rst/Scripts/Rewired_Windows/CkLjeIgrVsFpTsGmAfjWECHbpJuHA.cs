using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class CkLjeIgrVsFpTsGmAfjWECHbpJuHA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int IGXPYAEVrHjwdFVXKkyojIAaivfP(void* deviceInstance, IntPtr data);

	private readonly IntPtr EKpdfIaDFwaxnpKRpYTDIvftwzlB;

	private readonly IGXPYAEVrHjwdFVXKkyojIAaivfP eDScvhIkAFXGCfjeAFQmCTopDppqA;

	[CompilerGenerated]
	private List<qpzCcdMUThEhWJJvcjvJGTijXwxeb> fVdmDlMkjCZbdfmlGgBauHwfCXMF;

	public IntPtr KMOQEUACbWYqkFxXIVpIYuunYkEl => EKpdfIaDFwaxnpKRpYTDIvftwzlB;

	public List<qpzCcdMUThEhWJJvcjvJGTijXwxeb> lgBweNwczqcyfDtcLvGInJjEIDwWA
	{
		[CompilerGenerated]
		get
		{
			return fVdmDlMkjCZbdfmlGgBauHwfCXMF;
		}
		[CompilerGenerated]
		private set
		{
			fVdmDlMkjCZbdfmlGgBauHwfCXMF = list;
		}
	}

	public unsafe CkLjeIgrVsFpTsGmAfjWECHbpJuHA()
	{
		eDScvhIkAFXGCfjeAFQmCTopDppqA = WzhovtrPxhDWLibwKStqxUWxbPmJ;
		EKpdfIaDFwaxnpKRpYTDIvftwzlB = Marshal.GetFunctionPointerForDelegate(eDScvhIkAFXGCfjeAFQmCTopDppqA);
		lgBweNwczqcyfDtcLvGInJjEIDwWA = new List<qpzCcdMUThEhWJJvcjvJGTijXwxeb>();
	}

	[MonoPInvokeCallback(typeof(IGXPYAEVrHjwdFVXKkyojIAaivfP))]
	private unsafe static int WzhovtrPxhDWLibwKStqxUWxbPmJ(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<CkLjeIgrVsFpTsGmAfjWECHbpJuHA>(instanceId, out var instance))
		{
			return 1;
		}
		qpzCcdMUThEhWJJvcjvJGTijXwxeb qpzCcdMUThEhWJJvcjvJGTijXwxeb2 = new qpzCcdMUThEhWJJvcjvJGTijXwxeb();
		qpzCcdMUThEhWJJvcjvJGTijXwxeb2.dqIUIzWbrdzYBZfPcajdJLVfeUPL(ref *(qpzCcdMUThEhWJJvcjvJGTijXwxeb.FJcwJoJphAEYSVMXFcAYClYjTAjxA*)P_0);
		instance.lgBweNwczqcyfDtcLvGInJjEIDwWA.Add(qpzCcdMUThEhWJJvcjvJGTijXwxeb2);
		return 1;
	}
}
