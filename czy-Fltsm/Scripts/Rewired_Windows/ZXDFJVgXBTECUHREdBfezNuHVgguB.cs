using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class ZXDFJVgXBTECUHREdBfezNuHVgguB
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int aPamkWEDLMCocmLyDDsZIMrUFhsfb(void* deviceInstance, IntPtr data);

	private readonly IntPtr wRtVNPwtsRHJehjosauNpnVrnxWI;

	private readonly aPamkWEDLMCocmLyDDsZIMrUFhsfb einfazbhRHfhTEKjvleTPzETQqVlA;

	[CompilerGenerated]
	private List<JwOsKFPjPBIlckyhencRQGSXVgXH> XEErkjBFhbkhNyijaCtVugwzLJaB;

	public IntPtr BrkxopsMmGEWvaHpUwjnOpFtfqTs => wRtVNPwtsRHJehjosauNpnVrnxWI;

	public List<JwOsKFPjPBIlckyhencRQGSXVgXH> tenHZMlLsLVBVhUnhRAViIfEwVap
	{
		[CompilerGenerated]
		get
		{
			return XEErkjBFhbkhNyijaCtVugwzLJaB;
		}
		[CompilerGenerated]
		private set
		{
			XEErkjBFhbkhNyijaCtVugwzLJaB = xEErkjBFhbkhNyijaCtVugwzLJaB;
		}
	}

	public unsafe ZXDFJVgXBTECUHREdBfezNuHVgguB()
	{
		einfazbhRHfhTEKjvleTPzETQqVlA = WvcfyLaISwTFBoTsLdHVMbFzchYH;
		wRtVNPwtsRHJehjosauNpnVrnxWI = Marshal.GetFunctionPointerForDelegate(einfazbhRHfhTEKjvleTPzETQqVlA);
		tenHZMlLsLVBVhUnhRAViIfEwVap = new List<JwOsKFPjPBIlckyhencRQGSXVgXH>();
	}

	[MonoPInvokeCallback(typeof(aPamkWEDLMCocmLyDDsZIMrUFhsfb))]
	private unsafe static int WvcfyLaISwTFBoTsLdHVMbFzchYH(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<ZXDFJVgXBTECUHREdBfezNuHVgguB>(instanceId, out var instance))
		{
			return 1;
		}
		JwOsKFPjPBIlckyhencRQGSXVgXH jwOsKFPjPBIlckyhencRQGSXVgXH = new JwOsKFPjPBIlckyhencRQGSXVgXH();
		jwOsKFPjPBIlckyhencRQGSXVgXH.HMtfNaGHtuYZnFlDnXNyrwVZJLPjA(ref *(JwOsKFPjPBIlckyhencRQGSXVgXH.QmwDQXANzcqfZydnmMTRblmDUysLc*)P_0);
		instance.tenHZMlLsLVBVhUnhRAViIfEwVap.Add(jwOsKFPjPBIlckyhencRQGSXVgXH);
		return 1;
	}
}
