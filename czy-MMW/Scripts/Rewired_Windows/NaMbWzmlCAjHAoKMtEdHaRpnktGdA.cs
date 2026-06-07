using System.Runtime.InteropServices;

internal static class NaMbWzmlCAjHAoKMtEdHaRpnktGdA
{
	public unsafe static int LEtGWSeXpJvaPlKgjOfRPpnMdEhB(int P_0, tEMvMDgcwZeueXxszEJiRQqrAbCz P_1)
	{
		return emNPzkkpcdVeedUrHcQCmOLUQRGR(P_0, &P_1);
	}

	private unsafe static int emNPzkkpcdVeedUrHcQCmOLUQRGR(int P_0, void* P_1)
	{
		return vfuAiKLVRYGaNsyitTmuTXodeUQA.HCSPLIPKlUEHoHivvmDYJleKFSzO switch
		{
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_4 => posvJvJjdWfwyAchHIuGcLkNSoSG(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_3 => NdtMLebnyZcymohpmkBXZMrLfudp(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_2 => EruHwLyTwpMGEwjGXBvpYXGocMQl(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_1 => xLNoRNlgOwbqEqieqUzHWLNHBCXm(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_9_1_0 => roEtIIjzHpgwmYQxpsAzPqtfvehd(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int roEtIIjzHpgwmYQxpsAzPqtfvehd(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int xLNoRNlgOwbqEqieqUzHWLNHBCXm(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int EruHwLyTwpMGEwjGXBvpYXGocMQl(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int NdtMLebnyZcymohpmkBXZMrLfudp(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int posvJvJjdWfwyAchHIuGcLkNSoSG(int P_0, void* P_1);

	public unsafe static int lHqpUXQyNGcUDGdMYdUELjKhllSr(int P_0, out iEoHiNBpxuqYdDLSfjoMCydwpsYiB P_1)
	{
		P_1 = default(iEoHiNBpxuqYdDLSfjoMCydwpsYiB);
		int result;
		fixed (iEoHiNBpxuqYdDLSfjoMCydwpsYiB* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = SFUghHYetdmecpxmKwBUvSupYidb(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int SFUghHYetdmecpxmKwBUvSupYidb(int P_0, void* P_1)
	{
		if (vfuAiKLVRYGaNsyitTmuTXodeUQA.ndkiLucqiNiogGxsBykcfgjXVeJD && vfuAiKLVRYGaNsyitTmuTXodeUQA.pKCtecQkuOCIVFtsHUGGpDIhkxpd != null)
		{
			return vfuAiKLVRYGaNsyitTmuTXodeUQA.pKCtecQkuOCIVFtsHUGGpDIhkxpd(P_0, P_1);
		}
		return vfuAiKLVRYGaNsyitTmuTXodeUQA.HCSPLIPKlUEHoHivvmDYJleKFSzO switch
		{
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_4 => sZdtpxjjhLzuweAtmAXlBEJnNAjxA(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_3 => UFVXaXiuKjBfifGdNBgnyBFrzaWL(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_2 => sKvqQpJmBcFAGiNSTzRCkGpqBMTb(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_1 => inzcFiBWyCmcWAhBQonxkwXDIkew(P_0, P_1), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_9_1_0 => QJjeKNfziOdZgFIGGhrxhsFtJLCeB(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int QJjeKNfziOdZgFIGGhrxhsFtJLCeB(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int inzcFiBWyCmcWAhBQonxkwXDIkew(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int sKvqQpJmBcFAGiNSTzRCkGpqBMTb(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int UFVXaXiuKjBfifGdNBgnyBFrzaWL(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int sZdtpxjjhLzuweAtmAXlBEJnNAjxA(int P_0, void* P_1);

	public unsafe static int bWgiHeFxrxtlmXnDtbjjoHdjuaFg(int P_0, YOcwOWQuGxprAWETvnkFQJssgSEs P_1, out xuLbIRvuyJbJtfamXnyOqSgQtuMTA P_2)
	{
		P_2 = default(xuLbIRvuyJbJtfamXnyOqSgQtuMTA);
		int result;
		fixed (xuLbIRvuyJbJtfamXnyOqSgQtuMTA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = VoajbZXHcvjWhsdGWIEuWOpcUBxU(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int VoajbZXHcvjWhsdGWIEuWOpcUBxU(int P_0, int P_1, void* P_2)
	{
		return vfuAiKLVRYGaNsyitTmuTXodeUQA.HCSPLIPKlUEHoHivvmDYJleKFSzO switch
		{
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_4 => oNBQlMRVkPNFEDJxVDMghiOVQpmNA(P_0, P_1, P_2), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_3 => AwLTeellAEdvBDJgxwjkfvhfVYQP(P_0, P_1, P_2), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_2 => BvLorUiBtZkyCTjDFVZonQIdjhCq(P_0, P_1, P_2), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_1_1 => HPWpfIYiMFsrfyEoCEKNULedlyBR(P_0, P_1, P_2), 
			xfzjGOmskvZtGUvshJSLmbDHsoTQ.XINPUT_9_1_0 => yAbvkkykDlCNqFcPyXtzMfVJXNDoA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int yAbvkkykDlCNqFcPyXtzMfVJXNDoA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int HPWpfIYiMFsrfyEoCEKNULedlyBR(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int BvLorUiBtZkyCTjDFVZonQIdjhCq(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int AwLTeellAEdvBDJgxwjkfvhfVYQP(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int oNBQlMRVkPNFEDJxVDMghiOVQpmNA(int P_0, int P_1, void* P_2);
}
