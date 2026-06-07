using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal static class aJLVeOhEfeWwCQUasFxWOZoFuVi
{
	public unsafe static int BWkhmNrrafruKLExCnaUpmvRrlp(int P_0, int P_1, out dZnZiOGCGfSvEmegztTwDVuckSR P_2)
	{
		if (GBsSePSycbozcSRUzuvhWWKEEli.version >= STemBjjrVJIdAePWymtErDMfxOd.CilKymGRVvllPTBgsWZIshRmoxS)
		{
			P_2 = default(dZnZiOGCGfSvEmegztTwDVuckSR);
			return 0;
		}
		P_2 = default(dZnZiOGCGfSvEmegztTwDVuckSR);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<dZnZiOGCGfSvEmegztTwDVuckSR, IntPtr>(ref P_2))
		{
			result = YIkQOPrqPCAHCoZSAaGpxdUWFxT(P_0, P_1, ptr);
		}
		return result;
	}

	private unsafe static int YIkQOPrqPCAHCoZSAaGpxdUWFxT(int P_0, int P_1, void* P_2)
	{
		return GBsSePSycbozcSRUzuvhWWKEEli.version switch
		{
			STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb => fuXabVIrwQmbvKJEJGgpALeSixQ(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD => DXIxezUGdMkZqjjMzPOHNnjqDWu(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT => yhXTAHYbfrKJEOoOrXJyagQwoiZ(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf => RHQEJeYBgQktuGtTrQQREDKWPcG(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RHQEJeYBgQktuGtTrQQREDKWPcG(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yhXTAHYbfrKJEOoOrXJyagQwoiZ(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int DXIxezUGdMkZqjjMzPOHNnjqDWu(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int fuXabVIrwQmbvKJEJGgpALeSixQ(int P_0, int P_1, void* P_2);

	public unsafe static int mHvEXbHuidajivocootNUvWJjWm(int P_0, IVNavipaXjEHkzqGczlxUctDvay P_1)
	{
		return uyZxoQIGUuamNdRzgWnRuAdxKRXQ(P_0, &P_1);
	}

	private unsafe static int uyZxoQIGUuamNdRzgWnRuAdxKRXQ(int P_0, void* P_1)
	{
		return GBsSePSycbozcSRUzuvhWWKEEli.version switch
		{
			STemBjjrVJIdAePWymtErDMfxOd.CilKymGRVvllPTBgsWZIshRmoxS => AsliWWSrhDTeWUKCgGBSvodSFjt(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb => pPpCxgKptttlaKkYRSeedCdkDyJ(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD => wLlDhLEikBBzWgCikYHukgLHPGxZ(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT => msApGCiKgmgaEVDQuZrgOCzXTUD(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf => rolZuFuYpomKiLVBErlBwtfyFFD(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int rolZuFuYpomKiLVBErlBwtfyFFD(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int msApGCiKgmgaEVDQuZrgOCzXTUD(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int wLlDhLEikBBzWgCikYHukgLHPGxZ(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pPpCxgKptttlaKkYRSeedCdkDyJ(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int AsliWWSrhDTeWUKCgGBSvodSFjt(int P_0, void* P_1);

	public unsafe static int AvoXHCrzzRrJwKDWnbtcbNEOLJZE(int P_0, out Guid P_1, out Guid P_2)
	{
		P_1 = default(Guid);
		P_2 = default(Guid);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_1))
		{
			fixed (IntPtr* ptr2 = &System.Runtime.CompilerServices.Unsafe.As<Guid, IntPtr>(ref P_2))
			{
				result = RXuswnCOyQiedKtSSGpqqSFeQNT(P_0, ptr, ptr2);
			}
		}
		return result;
	}

	private unsafe static int RXuswnCOyQiedKtSSGpqqSFeQNT(int P_0, void* P_1, void* P_2)
	{
		return GBsSePSycbozcSRUzuvhWWKEEli.version switch
		{
			STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb => kvkbLFRmFhYkfxXfFztsrGirGVb(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD => RWWbyyeZPsbeMaROnibajINoFlW(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT => SNyyRgYhEdTfPqZDWeMkysXWMAA(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf => tUfoxCjQFErFUIpZsbKhkCSXpRzZ(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tUfoxCjQFErFUIpZsbKhkCSXpRzZ(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SNyyRgYhEdTfPqZDWeMkysXWMAA(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int RWWbyyeZPsbeMaROnibajINoFlW(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int kvkbLFRmFhYkfxXfFztsrGirGVb(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int hqPSPKuBEqjlJTeNKOOnbXoqOHy(int P_0, out RurWwwaiAKvkjxYcgOjFhSgRbOg P_1)
	{
		P_1 = default(RurWwwaiAKvkjxYcgOjFhSgRbOg);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<RurWwwaiAKvkjxYcgOjFhSgRbOg, IntPtr>(ref P_1))
		{
			result = iACEfHgEKnwxdZhsVeEXMemxeNT(P_0, ptr);
		}
		return result;
	}

	private unsafe static int iACEfHgEKnwxdZhsVeEXMemxeNT(int P_0, void* P_1)
	{
		if (GBsSePSycbozcSRUzuvhWWKEEli.supportsGetStateEx && GBsSePSycbozcSRUzuvhWWKEEli.getStateExDelegate != null)
		{
			return GBsSePSycbozcSRUzuvhWWKEEli.getStateExDelegate(P_0, P_1);
		}
		return GBsSePSycbozcSRUzuvhWWKEEli.version switch
		{
			STemBjjrVJIdAePWymtErDMfxOd.CilKymGRVvllPTBgsWZIshRmoxS => XzzOmNteCWiDUwqQDGkDJvVwjTE(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb => uKWNfqdonFiTfEUwAdwwUfAhQBOj(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD => tTaeOhFmFIjgrcgIqNYAJHTjNyOF(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT => owWxqgsmDvUtPHLesQqJjPagEFz(P_0, P_1), 
			STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf => oUqnbfSuWeqLEcTKueHClefVicQB(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int oUqnbfSuWeqLEcTKueHClefVicQB(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int owWxqgsmDvUtPHLesQqJjPagEFz(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tTaeOhFmFIjgrcgIqNYAJHTjNyOF(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int uKWNfqdonFiTfEUwAdwwUfAhQBOj(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int XzzOmNteCWiDUwqQDGkDJvVwjTE(int P_0, void* P_1);

	public unsafe static int tQaMlsvIcnlNgaRBvRLAKYPyWBL(int P_0, zexdwdVbzZaMEDmtcOGGUXzKpPqk P_1, out YzYsCymgJtbmvMuKUCCJNSxkFlq P_2)
	{
		P_2 = default(YzYsCymgJtbmvMuKUCCJNSxkFlq);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<YzYsCymgJtbmvMuKUCCJNSxkFlq, IntPtr>(ref P_2))
		{
			result = iEhfAQeHMPjejpqwpIyRbCtnnTW(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int iEhfAQeHMPjejpqwpIyRbCtnnTW(int P_0, int P_1, void* P_2)
	{
		return GBsSePSycbozcSRUzuvhWWKEEli.version switch
		{
			STemBjjrVJIdAePWymtErDMfxOd.CilKymGRVvllPTBgsWZIshRmoxS => rSeFFfQRjBOLYDrUnqijMJjbWYq(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb => MNlhPXkGWSdKAkXgJRrfCiZchZO(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD => yBvUxnvfIuUdKwdqZPBRuijvnHs(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT => EiROAOnfuWajwyDGRVOEQsQlOJX(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf => cSeqgFZfpKyzQsXLsnJXIDoZHSS(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cSeqgFZfpKyzQsXLsnJXIDoZHSS(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int EiROAOnfuWajwyDGRVOEQsQlOJX(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yBvUxnvfIuUdKwdqZPBRuijvnHs(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MNlhPXkGWSdKAkXgJRrfCiZchZO(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int rSeFFfQRjBOLYDrUnqijMJjbWYq(int P_0, int P_1, void* P_2);

	public unsafe static int xScTSZegjMOZTVCrEnrTplSHGNl(int P_0, KmNjvrHEfBagKAplwEZhSOqQfPb P_1, out DcTgJDlAqRopdPHUESqaUldYCnJe P_2)
	{
		P_2 = default(DcTgJDlAqRopdPHUESqaUldYCnJe);
		int result;
		fixed (IntPtr* ptr = &System.Runtime.CompilerServices.Unsafe.As<DcTgJDlAqRopdPHUESqaUldYCnJe, IntPtr>(ref P_2))
		{
			result = tlfjUvVleLpamHfydQMzLATSCNtF(P_0, (int)P_1, ptr);
		}
		return result;
	}

	private unsafe static int tlfjUvVleLpamHfydQMzLATSCNtF(int P_0, int P_1, void* P_2)
	{
		return GBsSePSycbozcSRUzuvhWWKEEli.version switch
		{
			STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb => UhUFTtwUhJcTKaVmcOfCvadqdUcJ(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD => UBoqoeXlFIsdIJAdKdAniOZVDZy(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT => lUsUzhuBlebWaesZQHkljAxFyxNV(P_0, P_1, P_2), 
			STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf => qjTNYAbfvvKEmAcQXNaBtshXmNj(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int qjTNYAbfvvKEmAcQXNaBtshXmNj(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int lUsUzhuBlebWaesZQHkljAxFyxNV(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UBoqoeXlFIsdIJAdKdAniOZVDZy(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UhUFTtwUhJcTKaVmcOfCvadqdUcJ(int P_0, int P_1, void* P_2);

	public static void kRLdiNbnjIcrwsyhlIieNsUHuCvI(gKQaduAqSOGwbLhlzfnbbSwcienb P_0)
	{
		SYsQNIKgEqailgPCdCuaWqMURCFA(P_0);
	}

	private static void SYsQNIKgEqailgPCdCuaWqMURCFA(gKQaduAqSOGwbLhlzfnbbSwcienb P_0)
	{
		switch (GBsSePSycbozcSRUzuvhWWKEEli.version)
		{
		case STemBjjrVJIdAePWymtErDMfxOd.TnAeluaekfbSgGxrupogglCaDyBb:
			CLHUNAyRvKwfymgRIuTgqOiiQdm(P_0);
			break;
		case STemBjjrVJIdAePWymtErDMfxOd.SrFJHrVAJDdfToAzJGAEKkvnPlD:
			vCAXgEYbjCLruNGbybSXWZtaNfs(P_0);
			break;
		case STemBjjrVJIdAePWymtErDMfxOd.UIOyYvtPifeGZCFNQCnQpQGLubT:
			MkhbqPVDWlscbPVPIPlTjKQBKCN(P_0);
			break;
		case STemBjjrVJIdAePWymtErDMfxOd.hoCFZTQBoZeAoeysRWPjQamcIqLf:
			YEDnOjrnfznEyeYBLqgfyEvxdNzB(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void YEDnOjrnfznEyeYBLqgfyEvxdNzB(gKQaduAqSOGwbLhlzfnbbSwcienb P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void MkhbqPVDWlscbPVPIPlTjKQBKCN(gKQaduAqSOGwbLhlzfnbbSwcienb P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void vCAXgEYbjCLruNGbybSXWZtaNfs(gKQaduAqSOGwbLhlzfnbbSwcienb P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void CLHUNAyRvKwfymgRIuTgqOiiQdm(gKQaduAqSOGwbLhlzfnbbSwcienb P_0);
}
