using System;
using System.Runtime.InteropServices;
using System.Security;

internal static class epNvjTHoNsvxseuNtgIjCHGjViOc
{
	public unsafe static int uhLPoUgMaIVznrqzOfSkgglYEzhC(int P_0, int P_1, out pedsIvwqXlgZbAReGBKiaPVMOTXXA P_2)
	{
		if (EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY >= OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_4)
		{
			P_2 = default(pedsIvwqXlgZbAReGBKiaPVMOTXXA);
			return 0;
		}
		P_2 = default(pedsIvwqXlgZbAReGBKiaPVMOTXXA);
		int result;
		fixed (pedsIvwqXlgZbAReGBKiaPVMOTXXA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = TDWwxsRTuFfTkuoYGDdBWadZAnCL(P_0, P_1, ptr2);
		}
		return result;
	}

	private unsafe static int TDWwxsRTuFfTkuoYGDdBWadZAnCL(int P_0, int P_1, void* P_2)
	{
		return EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY switch
		{
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3 => yvBhGVFdpwdtHLPVymsAgKczolTs(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_2 => YfTIqTcsgMYFulPmQcUyvXNTHxriA(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_1 => hwvkNFYcjvaxdIVJanKNivgVisFX(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_9_1_0 => OqNwCOhzqQhzgjUFtTaZKjQiIAQU(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OqNwCOhzqQhzgjUFtTaZKjQiIAQU(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int hwvkNFYcjvaxdIVJanKNivgVisFX(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int YfTIqTcsgMYFulPmQcUyvXNTHxriA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int yvBhGVFdpwdtHLPVymsAgKczolTs(int P_0, int P_1, void* P_2);

	public unsafe static int mxkvIIVDnjHsZnciJEZkCqLYFXsP(int P_0, EnTOzHRkIdPCTFPEBBSpMiCrzLkt P_1)
	{
		return XAIVMoNxEDLYLzlTzGBLtPpGWbmo(P_0, &P_1);
	}

	private unsafe static int XAIVMoNxEDLYLzlTzGBLtPpGWbmo(int P_0, void* P_1)
	{
		return EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY switch
		{
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_4 => ACfYijkkVaNxBQuNzJoNjBWDdigR(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3 => uucFasCUKroWBLcHGYEMvKRJoEBJb(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_2 => vejFHPZsKThqxggajBOwLRewzUytA(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_1 => SGxNHaOmCYCftyGEEsURDvDVyvMB(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_9_1_0 => MyPBESAOJTAKHOByLvduGMMfFZPv(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int MyPBESAOJTAKHOByLvduGMMfFZPv(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int SGxNHaOmCYCftyGEEsURDvDVyvMB(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int vejFHPZsKThqxggajBOwLRewzUytA(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int uucFasCUKroWBLcHGYEMvKRJoEBJb(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ACfYijkkVaNxBQuNzJoNjBWDdigR(int P_0, void* P_1);

	public unsafe static int CDzUyPvAdHMuymMBBcUwCJYfquvTA(int P_0, out Guid P_1, out Guid P_2)
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
				result = sLiMDilEJWmEQKiSBmEAJpFYvzyr(P_0, ptr2, ptr4);
			}
		}
		return result;
	}

	private unsafe static int sLiMDilEJWmEQKiSBmEAJpFYvzyr(int P_0, void* P_1, void* P_2)
	{
		return EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY switch
		{
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3 => XODBclrmBelCWaANbkBdoBWrxmJl(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_2 => xthtFtpJSwMQSDfhjpVxTCTaVWCb(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_1 => BEipKSQGSklyKDfMRdjlpEnlWsPl(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_9_1_0 => OQacrCEpHwODkyQqzLZBDyfOVuNR(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int OQacrCEpHwODkyQqzLZBDyfOVuNR(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BEipKSQGSklyKDfMRdjlpEnlWsPl(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int xthtFtpJSwMQSDfhjpVxTCTaVWCb(int P_0, void* P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int XODBclrmBelCWaANbkBdoBWrxmJl(int P_0, void* P_1, void* P_2);

	[SuppressUnmanagedCodeSecurity]
	public unsafe static int UalVhJldxiSAyWbkwGDZeGwdIXcxA(int P_0, out DthKZXUAHQnsCHloLMbBfxPrIUcV P_1)
	{
		P_1 = default(DthKZXUAHQnsCHloLMbBfxPrIUcV);
		int result;
		fixed (DthKZXUAHQnsCHloLMbBfxPrIUcV* ptr = &P_1)
		{
			void* ptr2 = ptr;
			result = dJKFPzjZEPILDtSLKrEUmdsyDoGN(P_0, ptr2);
		}
		return result;
	}

	private unsafe static int dJKFPzjZEPILDtSLKrEUmdsyDoGN(int P_0, void* P_1)
	{
		if (EJqfQyyvppiQRwtOQClnSRtsWpmI.YnraZBJCUvvQFSeRpDddaWWHCxbHA && EJqfQyyvppiQRwtOQClnSRtsWpmI.SWLdCoxRWcswcZtXxBNXyYrxYWJG != null)
		{
			return EJqfQyyvppiQRwtOQClnSRtsWpmI.SWLdCoxRWcswcZtXxBNXyYrxYWJG(P_0, P_1);
		}
		return EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY switch
		{
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_4 => NiePAxMLFljMDJwHOfIkcRjKlyBhc(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3 => pyEawRHRCNrbRdycvMCulHztsTkW(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_2 => XAuRxCqgGWgvfyzjhtmItCogTbgt(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_1 => ZuyygXmIzwYtXYjAyguyznHxWYxA(P_0, P_1), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_9_1_0 => tykEbDSxWkmjRMLuLFioKffDydqCA(P_0, P_1), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int tykEbDSxWkmjRMLuLFioKffDydqCA(int P_0, void* P_1);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ZuyygXmIzwYtXYjAyguyznHxWYxA(int P_0, void* P_1);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int XAuRxCqgGWgvfyzjhtmItCogTbgt(int P_0, void* P_1);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int pyEawRHRCNrbRdycvMCulHztsTkW(int P_0, void* P_1);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int NiePAxMLFljMDJwHOfIkcRjKlyBhc(int P_0, void* P_1);

	public unsafe static int GqrbPwkqNZsPCLsTPncaxrlzjOzhA(int P_0, ddrNxChsiLuVtQynDItAHKGwFiuaA P_1, out KkCedRUBGjrnSczYvIhPFYMUDQuP P_2)
	{
		P_2 = default(KkCedRUBGjrnSczYvIhPFYMUDQuP);
		int result;
		fixed (KkCedRUBGjrnSczYvIhPFYMUDQuP* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = uzbgMBbcENFFQauehaLbdHHpgjPWb(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int uzbgMBbcENFFQauehaLbdHHpgjPWb(int P_0, int P_1, void* P_2)
	{
		return EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY switch
		{
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_4 => BaYBQCFcOhNftwTLzJPtNpmBmVAGb(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3 => znYlTiIussHHoJcCNDkjcwJpBawib(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_2 => ieYZeMLNinUTjHppnMBdujwhDpsi(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_1 => kZRCLUvKkfAUAyEKmXMSLERvScth(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_9_1_0 => HmepXyHylNqjFiUfMVyemZbFnzpv(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int HmepXyHylNqjFiUfMVyemZbFnzpv(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int kZRCLUvKkfAUAyEKmXMSLERvScth(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int ieYZeMLNinUTjHppnMBdujwhDpsi(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int znYlTiIussHHoJcCNDkjcwJpBawib(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int BaYBQCFcOhNftwTLzJPtNpmBmVAGb(int P_0, int P_1, void* P_2);

	public unsafe static int DbxLjEpdyNyzUyCSrjNxjKpfyBSg(int P_0, IbHzuYlJXPPnRmyfLspTCSxwmWBP P_1, out XDHEEoFXhDggQddMvENaWESebUHBA P_2)
	{
		P_2 = default(XDHEEoFXhDggQddMvENaWESebUHBA);
		int result;
		fixed (XDHEEoFXhDggQddMvENaWESebUHBA* ptr = &P_2)
		{
			void* ptr2 = ptr;
			result = BAYblDHgOCGRZXWbnLGcuxNQrQVBA(P_0, (int)P_1, ptr2);
		}
		return result;
	}

	private unsafe static int BAYblDHgOCGRZXWbnLGcuxNQrQVBA(int P_0, int P_1, void* P_2)
	{
		return EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY switch
		{
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3 => UlrMRfcNmRSaXCuXuaWADbAPFVxb(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_2 => cpWMEhfdKebTamHBoIMHXopwMnUw(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_1 => nDRWqzdpxxoOezYeYcsYmgoggmBJA(P_0, P_1, P_2), 
			OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_9_1_0 => QlEVnGWsVtQHTuzktWMluZXPlYYP(P_0, P_1, P_2), 
			_ => 0, 
		};
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int QlEVnGWsVtQHTuzktWMluZXPlYYP(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int nDRWqzdpxxoOezYeYcsYmgoggmBJA(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int cpWMEhfdKebTamHBoIMHXopwMnUw(int P_0, int P_1, void* P_2);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	[SuppressUnmanagedCodeSecurity]
	private unsafe static extern int UlrMRfcNmRSaXCuXuaWADbAPFVxb(int P_0, int P_1, void* P_2);

	public static void QWVscZgmKYvTeIXVihxYBprhKAyB(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0)
	{
		zfpXBkdGWtFcfOuXEIPlhPPZpnjM(P_0);
	}

	private static void zfpXBkdGWtFcfOuXEIPlhPPZpnjM(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0)
	{
		switch (EJqfQyyvppiQRwtOQClnSRtsWpmI.sSVwcMweZuOfHZDXNrKJIEWAVaBY)
		{
		case OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_3:
			ABHrISddiOwHEvrcIIeZgXgKsmpt(P_0);
			break;
		case OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_2:
			CEnKHNEzoyZDBtKxSzDKAdklYLPD(P_0);
			break;
		case OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_1_1:
			TRIQcfHQhidypfVfodmoyMCyhzYm(P_0);
			break;
		case OsmjxKLuEDgHrYkWJcPKjDxVvElW.XINPUT_9_1_0:
			ZiKfObzCwTlkomcYJmbibVyjbwwP(P_0);
			break;
		}
	}

	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void ZiKfObzCwTlkomcYJmbibVyjbwwP(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0);

	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void TRIQcfHQhidypfVfodmoyMCyhzYm(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0);

	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void CEnKHNEzoyZDBtKxSzDKAdklYLPD(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0);

	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	[SuppressUnmanagedCodeSecurity]
	private static extern void ABHrISddiOwHEvrcIIeZgXgKsmpt(uWOqpRQeRUtDCJArQdGhUlVIEJbt P_0);
}
