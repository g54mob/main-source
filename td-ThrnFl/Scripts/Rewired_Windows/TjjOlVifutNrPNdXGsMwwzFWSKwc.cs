using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class TjjOlVifutNrPNdXGsMwwzFWSKwc
{
	public unsafe static int DrpkcLLTYTtJoKhNRpeyEAltTBoB(int P_0, int P_1, out EtJebJDpMwxlTdxfZHCkvjnlnSrp P_2)
	{
		if (xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU >= pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_4)
		{
			P_2 = default(EtJebJDpMwxlTdxfZHCkvjnlnSrp);
			return 0;
		}
		P_2 = default(EtJebJDpMwxlTdxfZHCkvjnlnSrp);
		int result;
		fixed (EtJebJDpMwxlTdxfZHCkvjnlnSrp* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = mQaRGKaHvMBNIVmBRiVFawVctDgWA(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int mQaRGKaHvMBNIVmBRiVFawVctDgWA(int P_0, int P_1, void* P_2)
	{
		return xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU switch
		{
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3 => HnxWUriecjGDpoEUlgsQkCCGOgrUA(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_2 => pjdvLhVJlVIvCUjzFNScHxxsqxFl(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_1 => SRTJujlTkmFFHzHSfKEPCMEmqtxt(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_9_1_0 => dXlfduOvtPXXWCqIyOyBwcuRMVmT(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dXlfduOvtPXXWCqIyOyBwcuRMVmT(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SRTJujlTkmFFHzHSfKEPCMEmqtxt(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pjdvLhVJlVIvCUjzFNScHxxsqxFl(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HnxWUriecjGDpoEUlgsQkCCGOgrUA(int P_0, int P_1, void* P_2);

	public unsafe static int NQKIBciEwmHbfGJpOAPebatlhYOUA(int P_0, zXdjGtoSXgQepgzBUgUnoRyUsKYX P_1)
	{
		return aTahnMesXSRebsKCkHTJVNPbwySCA(P_0, &P_1);
	}

	private unsafe static int aTahnMesXSRebsKCkHTJVNPbwySCA(int P_0, void* P_1)
	{
		return xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU switch
		{
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_4 => viJhCZNCSfpVvfQFmRVXBwdgxxQd(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3 => JAIWFCrOXcBcfPtGFROOcOrwMLfS(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_2 => YWNuqlgKZQCnDDitwBGivhOXpNOT(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_1 => dlqgihtAtDkdPJmTRyhMrULqbjTl(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_9_1_0 => xjbfSsfRKAiLnpBlSIxwkDcWnMnV(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xjbfSsfRKAiLnpBlSIxwkDcWnMnV(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int dlqgihtAtDkdPJmTRyhMrULqbjTl(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YWNuqlgKZQCnDDitwBGivhOXpNOT(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int JAIWFCrOXcBcfPtGFROOcOrwMLfS(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int viJhCZNCSfpVvfQFmRVXBwdgxxQd(int P_0, void* P_1);

	public unsafe static int lrRgPjCOsSBEMFJICQMefzgvKxNNc(int P_0, out Guid P_1, out Guid P_2)
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
				result = RRIgeMOTKVIcgdgVWtKAjlrfaqIx(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int RRIgeMOTKVIcgdgVWtKAjlrfaqIx(int P_0, void* P_1, void* P_2)
	{
		return xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU switch
		{
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3 => uWfcVRYnFtBmuTApkiDbEkwUoxpJ(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_2 => EaVAJxKbQRmyqixwaxEFvDcqCUau(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_1 => qMnGqijRlnJsfmHgEbdBRJPCLtqc(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_9_1_0 => lxICfentOtdSWLkxkNYPtsTfttfF(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lxICfentOtdSWLkxkNYPtsTfttfF(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qMnGqijRlnJsfmHgEbdBRJPCLtqc(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int EaVAJxKbQRmyqixwaxEFvDcqCUau(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int uWfcVRYnFtBmuTApkiDbEkwUoxpJ(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int duBGCjfKgpxiCJrzjGFDZsMEoQUOA(int P_0, out qyFLqlfCGZvCiuLpWgnVcPlGjVSDb P_1)
	{
		P_1 = default(qyFLqlfCGZvCiuLpWgnVcPlGjVSDb);
		int result;
		fixed (qyFLqlfCGZvCiuLpWgnVcPlGjVSDb* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = YRqkmDEQNSuPtGNCRxHUGYrPpHqh(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int YRqkmDEQNSuPtGNCRxHUGYrPpHqh(int P_0, void* P_1)
	{
		if (xRUGkURngkKlvPjZVWYliaTXRZSh.bUViujcsRyyprfXGubolYUywafJJ && xRUGkURngkKlvPjZVWYliaTXRZSh.nLvnlIYvNfYzMaMviHGFUHVITnpj != null)
		{
			return xRUGkURngkKlvPjZVWYliaTXRZSh.nLvnlIYvNfYzMaMviHGFUHVITnpj(P_0, P_1);
		}
		return xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU switch
		{
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_4 => qCCLjVzKEoymzJBGJyIebnNOXdpP(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3 => MdsZxfyjPCVklGtpeWoeLDHIASWR(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_2 => cnAoVkTPFPBcNPNqcuYWPOLLmZKe(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_1 => clSZDEXJBrmdHjlytaMuNeNqNXui(P_0, P_1), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_9_1_0 => QtYRSjhmRrSHjpxvCmmiFlJovsKo(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QtYRSjhmRrSHjpxvCmmiFlJovsKo(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int clSZDEXJBrmdHjlytaMuNeNqNXui(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cnAoVkTPFPBcNPNqcuYWPOLLmZKe(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MdsZxfyjPCVklGtpeWoeLDHIASWR(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qCCLjVzKEoymzJBGJyIebnNOXdpP(int P_0, void* P_1);

	public unsafe static int pYFafAHxWSrqygEvIqIuXbBIZxJh(int P_0, WOPJEgIDdQArVapyKhtYfhoFkxGBb P_1, out fuoOEptqBeePsHoFyhrBbbubKTYKA P_2)
	{
		P_2 = default(fuoOEptqBeePsHoFyhrBbbubKTYKA);
		int result;
		fixed (fuoOEptqBeePsHoFyhrBbbubKTYKA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = XoPvhjHrBYjQiXerheTrrJbFDcnbA(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int XoPvhjHrBYjQiXerheTrrJbFDcnbA(int P_0, int P_1, void* P_2)
	{
		return xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU switch
		{
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_4 => gosCzoFRZoVDTtiKgDRpYLMwMKcuA(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3 => QQaHkOftzlnXAmxZOiNdEWpIjxSh(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_2 => TnwmjowQzyiPVeqUoSClWKuCICIC(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_1 => LvlxOuYXlcqJgTgRxjFGfscEhJFS(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_9_1_0 => mzIIuYiNaGDRhKZsBimagOHkDiTuA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int mzIIuYiNaGDRhKZsBimagOHkDiTuA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int LvlxOuYXlcqJgTgRxjFGfscEhJFS(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TnwmjowQzyiPVeqUoSClWKuCICIC(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QQaHkOftzlnXAmxZOiNdEWpIjxSh(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int gosCzoFRZoVDTtiKgDRpYLMwMKcuA(int P_0, int P_1, void* P_2);

	public unsafe static int eRhiyVOnQCSeMJFkplbgZefYbopB(int P_0, bGhABghGQIpNpkFkKBtTFgXdLVzTb P_1, out iQbjJCiYsWKykOcZeRCqsNcRFUfi P_2)
	{
		P_2 = default(iQbjJCiYsWKykOcZeRCqsNcRFUfi);
		int result;
		fixed (iQbjJCiYsWKykOcZeRCqsNcRFUfi* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = qnwcMbfNLDGdhrnuyaWyEDhbtJhhc(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int qnwcMbfNLDGdhrnuyaWyEDhbtJhhc(int P_0, int P_1, void* P_2)
	{
		return xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU switch
		{
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3 => huNrVfBkGYiQSrNjAoZChmDeIpxG(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_2 => TFyjZLQuNvLkMLyAhEyXfRSTcwyd(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_1 => QrlFNThImkpiWmWtLcqCRMMNSthqA(P_0, P_1, P_2), 
			pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_9_1_0 => bCujIsHzOkMfnVPzkjYhgGhciVeIA(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int bCujIsHzOkMfnVPzkjYhgGhciVeIA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QrlFNThImkpiWmWtLcqCRMMNSthqA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int TFyjZLQuNvLkMLyAhEyXfRSTcwyd(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int huNrVfBkGYiQSrNjAoZChmDeIpxG(int P_0, int P_1, void* P_2);

	public static void bbpXSMBlxZNTpjQdfnEdhbRYRywE(BicPxZfWIPNacckpNSxKcxfbKgVe P_0)
	{
		MPToJMMiZkBATrXGDIJdVknmccTeA(P_0);
	}

	private static void MPToJMMiZkBATrXGDIJdVknmccTeA(BicPxZfWIPNacckpNSxKcxfbKgVe P_0)
	{
		switch (xRUGkURngkKlvPjZVWYliaTXRZSh.LorZFiTvIzDDvgiCACMHuNorTpzU)
		{
		case pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_3:
			zwtDhmYNjTlrsYybNbsVCSGnNnNX(P_0);
			break;
		case pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_2:
			fNHjmrrsLfftXGPyTtQiwZnOLlGc(P_0);
			break;
		case pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_1_1:
			aZsFBFaeirtONQSajiceKssFoskP(P_0);
			break;
		case pYOnYkqGRQCrLrgLYQZQXwPkTLVu.XINPUT_9_1_0:
			gwynxDCerQTAGPNDMJzmZZYGFfUm(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void gwynxDCerQTAGPNDMJzmZZYGFfUm(BicPxZfWIPNacckpNSxKcxfbKgVe P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void aZsFBFaeirtONQSajiceKssFoskP(BicPxZfWIPNacckpNSxKcxfbKgVe P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void fNHjmrrsLfftXGPyTtQiwZnOLlGc(BicPxZfWIPNacckpNSxKcxfbKgVe P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void zwtDhmYNjTlrsYybNbsVCSGnNnNX(BicPxZfWIPNacckpNSxKcxfbKgVe P_0);
}
