using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class DJmHAgilrIRQeTIRIHNgaezwiAek
{
	public unsafe static int qvPlWjeBbZyIyWKfcibeVBvugdfHA(int P_0, int P_1, out YVMawcBlUHErwbWVZyrQvufFEqNP P_2)
	{
		if (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi >= haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_4)
		{
			P_2 = default(YVMawcBlUHErwbWVZyrQvufFEqNP);
			return 0;
		}
		P_2 = default(YVMawcBlUHErwbWVZyrQvufFEqNP);
		int result;
		fixed (YVMawcBlUHErwbWVZyrQvufFEqNP* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = tIJortcKygdlkzFwmFuRGXVtDTVwA(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int tIJortcKygdlkzFwmFuRGXVtDTVwA(int P_0, int P_1, void* P_2)
	{
		switch (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi)
		{
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3:
			return ObsICtIPkwUOBGHxxygBLqdlHfGcb(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_2:
			return cvlrSDVXtojPEcibTtNvxTuZMReP(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_1:
			return VJaIswDkfBjfgbRXVhREeGnZYyBdA(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_9_1_0:
			return wIvKtANdByjVCfHCXgWpNqErVTGjA(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wIvKtANdByjVCfHCXgWpNqErVTGjA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int VJaIswDkfBjfgbRXVhREeGnZYyBdA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cvlrSDVXtojPEcibTtNvxTuZMReP(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ObsICtIPkwUOBGHxxygBLqdlHfGcb(int P_0, int P_1, void* P_2);

	public unsafe static int XNQbuFdAuHrSGdkBEHtbBEJuCIcEA(int P_0, ramHFCfkFFXmCnknQWnLiygydkgKA P_1)
	{
		return DwaPIyBTGSRyhYVIOfkbeVyWFZNH(P_0, &P_1);
	}

	private unsafe static int DwaPIyBTGSRyhYVIOfkbeVyWFZNH(int P_0, void* P_1)
	{
		switch (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi)
		{
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_4:
			return tzEtIuRjKhXHiNhxUJDuHcFttotC(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3:
			return UFSgQYVTzJVEWLGnjzEIHOmNJkRX(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_2:
			return TeIEroXgdnAeXLRWMJIWCWuGStfb(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_1:
			return JAxrcunUcGHjsQtjMbeGesssCwDg(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_9_1_0:
			return UGIPRprCjOkdOMImmohdYTsZjTZP(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UGIPRprCjOkdOMImmohdYTsZjTZP(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JAxrcunUcGHjsQtjMbeGesssCwDg(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TeIEroXgdnAeXLRWMJIWCWuGStfb(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UFSgQYVTzJVEWLGnjzEIHOmNJkRX(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tzEtIuRjKhXHiNhxUJDuHcFttotC(int P_0, void* P_1);

	public unsafe static int rYRwiowQxvuBCZVtXjYMrIXxHKNj(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (Guid* ptr = &P_1)
		{
			void* ptr2 = ptr;
			fixed (Guid* ptr3 = &P_2)
			{
				void* ptr4 = ptr3;
				result = evTPJPVPAgCNVVOAiROWUxRZRGPT(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int evTPJPVPAgCNVVOAiROWUxRZRGPT(int P_0, void* P_1, void* P_2)
	{
		switch (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi)
		{
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3:
			return JaLEozBUPVdJDCuIBlzWgZffOLGde(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_2:
			return yzzcHQhjJQpQgrhlHPgOiZSVGvMIA(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_1:
			return tfDsFQVjSFBcbhjeaYoAuSArmCOY(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_9_1_0:
			return SyCUmcyFPugZcRWqUAAXasVwFVhF(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SyCUmcyFPugZcRWqUAAXasVwFVhF(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tfDsFQVjSFBcbhjeaYoAuSArmCOY(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yzzcHQhjJQpQgrhlHPgOiZSVGvMIA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JaLEozBUPVdJDCuIBlzWgZffOLGde(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int YcsrpofQUCgAdQpmwsIHLwbXhUwU(int P_0, out szUSrYdGEqLOFeUPKPIdPPtaOdyV P_1)
	{
		P_1 = default(szUSrYdGEqLOFeUPKPIdPPtaOdyV);
		int result;
		fixed (szUSrYdGEqLOFeUPKPIdPPtaOdyV* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = TQjMlzzpMTPVRGbXjuixgQdCAZFU(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int TQjMlzzpMTPVRGbXjuixgQdCAZFU(int P_0, void* P_1)
	{
		if (jQXZxnZotZMoKXvWXxLTaBmrxJae.XtIADVbpaeGnYADARQhamHWAHEniA && jQXZxnZotZMoKXvWXxLTaBmrxJae.CrucJlOFmzbtFEhMjvHHdbPRXbVP != null)
		{
			return jQXZxnZotZMoKXvWXxLTaBmrxJae.CrucJlOFmzbtFEhMjvHHdbPRXbVP(P_0, P_1);
		}
		switch (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi)
		{
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_4:
			return oVYbpveaMeMsyTdzlRklSdAVpDOOA(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3:
			return NhzYLWytYpsBXVLawsPMRXLCVeYc(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_2:
			return WREzByAFkWNJrtzQASkVtCWTmWaA(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_1:
			return DXvPgQxqPVSkvGdNYkbhBQrTBPbk(P_0, P_1);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_9_1_0:
			return TxRUWDZMzQmAirrnENDuZHaaakGH(P_0, P_1);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TxRUWDZMzQmAirrnENDuZHaaakGH(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DXvPgQxqPVSkvGdNYkbhBQrTBPbk(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WREzByAFkWNJrtzQASkVtCWTmWaA(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NhzYLWytYpsBXVLawsPMRXLCVeYc(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oVYbpveaMeMsyTdzlRklSdAVpDOOA(int P_0, void* P_1);

	public unsafe static int IAVGCMwfyTgSSvtqVLvoqcIRVMTH(int P_0, UQWGHLeQbjehaNbCUbKmUdkhLDyEA P_1, out jUbxDShELFCTFDJtkkSnWnyRGvoLA P_2)
	{
		P_2 = default(jUbxDShELFCTFDJtkkSnWnyRGvoLA);
		int result;
		fixed (jUbxDShELFCTFDJtkkSnWnyRGvoLA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = FmGIIqxiXxrIZyIHVFYbRCHEVjOM(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int FmGIIqxiXxrIZyIHVFYbRCHEVjOM(int P_0, int P_1, void* P_2)
	{
		switch (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi)
		{
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_4:
			return OLNmLEVzchwayMraPoDJsidMSaue(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3:
			return zhIeQpvrYoenkDjPpkBFPsCLAJMOA(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_2:
			return RVgedHwotmztLxCUAEVffOvQNzDWA(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_1:
			return nLuYpqajmqJQYtRpduKgmsFCvVXv(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_9_1_0:
			return BYHjXMMybwDRXzicrtVjcYCHXrYF(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BYHjXMMybwDRXzicrtVjcYCHXrYF(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nLuYpqajmqJQYtRpduKgmsFCvVXv(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RVgedHwotmztLxCUAEVffOvQNzDWA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int zhIeQpvrYoenkDjPpkBFPsCLAJMOA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OLNmLEVzchwayMraPoDJsidMSaue(int P_0, int P_1, void* P_2);

	public unsafe static int WaBvnvtTtckrdMtYujXzJLpyBHdC(int P_0, pDoDCHSuQpoVQVhYOkSvmnZhebDZ P_1, out ckTqxJcotNODsWleHqEVcczsxZUA P_2)
	{
		P_2 = default(ckTqxJcotNODsWleHqEVcczsxZUA);
		int result;
		fixed (ckTqxJcotNODsWleHqEVcczsxZUA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = QgExbJOidlFEQIhPHOOHbuKxBrbG(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int QgExbJOidlFEQIhPHOOHbuKxBrbG(int P_0, int P_1, void* P_2)
	{
		switch (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi)
		{
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3:
			return vOrcyBpNdtNkqEmDMflgIYwNYKeR(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_2:
			return fsVTXWMSXaDRiUaWwnELOoOcXNqS(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_1:
			return WzRWSVrJxOxNWfLgyaPVatiVhkVj(P_0, P_1, P_2);
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_9_1_0:
			return TkuVyeerdHnxEDzbvrRpZZsqNobr(P_0, P_1, P_2);
		default:
			return 0;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TkuVyeerdHnxEDzbvrRpZZsqNobr(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int WzRWSVrJxOxNWfLgyaPVatiVhkVj(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int fsVTXWMSXaDRiUaWwnELOoOcXNqS(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vOrcyBpNdtNkqEmDMflgIYwNYKeR(int P_0, int P_1, void* P_2);

	public static void LdiJLxkGlgCESvhYRapEKyPqWqdI(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0)
	{
		duVeAsNGQQLLJWKnDqLGUEJvdQLS(P_0);
	}

	private static void duVeAsNGQQLLJWKnDqLGUEJvdQLS(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0)
	{
		switch (jQXZxnZotZMoKXvWXxLTaBmrxJae.XDTialqhoSsiDPQdYEZHpaHyxYbi)
		{
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_3:
			nGgQfedRPmnTShrwkqwQGwtFtOqt(P_0);
			break;
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_2:
			SNbkycXrtcQiOIYbGvQteaONFXyN(P_0);
			break;
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_1_1:
			xlGEJlIWGRYRPNYuaMfhRTDoCOFcA(P_0);
			break;
		case haHwBVoGVlDboBrdUwqeJRPGOhlgA.XINPUT_9_1_0:
			znwjfRycpPljMbqqlohNYVqYHjbf(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void znwjfRycpPljMbqqlohNYVqYHjbf(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void xlGEJlIWGRYRPNYuaMfhRTDoCOFcA(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void SNbkycXrtcQiOIYbGvQteaONFXyN(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void nGgQfedRPmnTShrwkqwQGwtFtOqt(FKpUUKpxWqVWVqLSTppLuedJkJtg P_0);
}
