using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class hgoxKfRexCfSYPQUtEFTpjtrzsJP
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int HgAxNxoIgTedIKGJznnvsbWyBrnRA(void* deviceInstance, IntPtr data);

	private readonly IntPtr EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	private readonly HgAxNxoIgTedIKGJznnvsbWyBrnRA SmCbULdHvFnyCWdLLpSYHEPsMuCV;

	[CompilerGenerated]
	private List<JdCxZzLkhXGKluLnEWVBPbkWKqLl> EzydynNiRVcpWeDwpNuAyHfXCQVk;

	public IntPtr GMaPHoiZAJyngdXeSoVFwLOeWHKm => EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	public List<JdCxZzLkhXGKluLnEWVBPbkWKqLl> okZvgUtEVsPTUCOPNcQpOsnTNQCv
	{
		[CompilerGenerated]
		get
		{
			return EzydynNiRVcpWeDwpNuAyHfXCQVk;
		}
		[CompilerGenerated]
		private set
		{
			EzydynNiRVcpWeDwpNuAyHfXCQVk = ezydynNiRVcpWeDwpNuAyHfXCQVk;
		}
	}

	public unsafe hgoxKfRexCfSYPQUtEFTpjtrzsJP()
	{
		SmCbULdHvFnyCWdLLpSYHEPsMuCV = RmyNJDtrrhabZYWvrgkvjManfHeBb;
		EetGmuBhqQLYShPkdlGmBVJKSvCAb = Marshal.GetFunctionPointerForDelegate((Delegate)SmCbULdHvFnyCWdLLpSYHEPsMuCV);
		okZvgUtEVsPTUCOPNcQpOsnTNQCv = new List<JdCxZzLkhXGKluLnEWVBPbkWKqLl>();
	}

	[MonoPInvokeCallback(typeof(HgAxNxoIgTedIKGJznnvsbWyBrnRA))]
	private unsafe static int RmyNJDtrrhabZYWvrgkvjManfHeBb(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<hgoxKfRexCfSYPQUtEFTpjtrzsJP>(instanceId, out var instance))
		{
			return 1;
		}
		JdCxZzLkhXGKluLnEWVBPbkWKqLl jdCxZzLkhXGKluLnEWVBPbkWKqLl = new JdCxZzLkhXGKluLnEWVBPbkWKqLl();
		jdCxZzLkhXGKluLnEWVBPbkWKqLl.ubvFUqtErpTMhZPdcRbSTBcoJcFu(ref *(JdCxZzLkhXGKluLnEWVBPbkWKqLl.HpMboHsmIwcXgeuoaXzbwwcUHKrK*)P_0);
		instance.okZvgUtEVsPTUCOPNcQpOsnTNQCv.Add(jdCxZzLkhXGKluLnEWVBPbkWKqLl);
		return 1;
	}
}
