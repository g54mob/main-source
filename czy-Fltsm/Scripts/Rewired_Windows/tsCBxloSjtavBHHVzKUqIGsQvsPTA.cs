using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class tsCBxloSjtavBHHVzKUqIGsQvsPTA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void JQMCZJgwIVzxozIVtFuQMRjRhOHGA(YEddRxIQmgTYEowryWdPAJlNvhwRA pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void kGSehjbzGCuqPLWMpPmTRqfhvGrD(YEddRxIQmgTYEowryWdPAJlNvhwRA pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void JAAslQsVSRrulKqEKiIcbTrvWiYwA(YEddRxIQmgTYEowryWdPAJlNvhwRA pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void JFwIAuRaBeJDylBkEOvVnYCqjoXo(YEddRxIQmgTYEowryWdPAJlNvhwRA pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DXOcKGfxHCyxboosHwDpRhbpgvyIA(YEddRxIQmgTYEowryWdPAJlNvhwRA coreWindow, YEddRxIQmgTYEowryWdPAJlNvhwRA keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void muMPTyNHFygMoFuzCbaZcyKOHHsnA(YEddRxIQmgTYEowryWdPAJlNvhwRA coreDispatcher, YEddRxIQmgTYEowryWdPAJlNvhwRA acceleratorKeyEventArgs);

	public const string HYgZmacCTFTLdMdkJiCbFaVZXpRF = "Rewired_WindowsGamingInput";

	private const CallingConvention NJTeLwyVbcHcifFLiczDdXwheMWAA = CallingConvention.StdCall;

	private const CallingConvention cYuquKCNTJBRMfvHaoVcPPkbxnLG = CallingConvention.StdCall;

	private const UnmanagedType SaaAWqbHumgcPRodVZXekHAhBEAH = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong ddtQGMDpePZKERWdhfTelARQGIbA(IntPtr P_0);

	public static ulong fIEeMPaEGMGCGddFfswIVwaMRpKnB(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return ddtQGMDpePZKERWdhfTelARQGIbA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong AKZKeeKabfGGHkMrxKQmYSJiSMPvA(IntPtr P_0);

	public static ulong JwpNGbcnRwGybIZugmhEnaaBeYut(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return AKZKeeKabfGGHkMrxKQmYSJiSMPvA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool alDrjDEyLsOdDocEwvEYXuiXlNwI();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr scTsaVvtyKlldfjzUavNuDYYdQGk();

	public static string KFkmWDCAMAcxEshtOFgeDXjhcWxDb()
	{
		IntPtr intPtr = scTsaVvtyKlldfjzUavNuDYYdQGk();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA MUunaBPlOYIZBnRYpgepKfaBdMLcb();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint RlLIFFBoRWWadmltKMnScpNEQzqI(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA EIivHDnAeezZrCIrKuKYpiXhOSxq(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool bEAIWdLLtvJtLzhkiMrbRrLeAlMKA(IntPtr P_0, ref tvQgtDzBXDagmkAWojrVhCYhBEWs P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool JTDMqvEDHyjAncrkayfBjjXOIJDab(IntPtr P_0, ref kmfvAbnsAlybBleITzlofpcycRap P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void YaIsbeqMJrDLTnmdUEWywNLQIRAP(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] kmfvAbnsAlybBleITzlofpcycRap P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr HsiBjbGnqLKWfwkNyTggPQyeoovv(IntPtr P_0);

	public static IMzcsxDiCghYscFleZayNqwPSeREc JoIZPaMychYWPYlhFlRLJuVwwBTf(IntPtr P_0)
	{
		IntPtr intPtr = HsiBjbGnqLKWfwkNyTggPQyeoovv(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new IMzcsxDiCghYscFleZayNqwPSeREc(new ptLEJWqNKYGsBloabxqKfrAoMUgn(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool nMUuqdNcBnJNPIUGpkTwCmnKDvVn(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA ZafdXUuvSRsFmcOfRHGIFKWTxMfjA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern IBaNvcwPYiqrcPkMbchCPFZQrDpr amfaZIcBcWKbXDxoALwaBoSQhohzB(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void tgKoRNCntYDMahKELRqAyEWedItcb();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void OoRbrqHjojYLlGHNTokNFILivkpfc();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void OzUCfpKHdrmqELHpRenQYmDjeVZd(JQMCZJgwIVzxozIVtFuQMRjRhOHGA P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void zWEmxGcNgLkcyMPNidfZsxZeiWsb(kGSehjbzGCuqPLWMpPmTRqfhvGrD P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint yhxiLfXfEjBJHJgDcPhpXGyyvNtZ(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA MBJVVxnEQUcZMFIqehjIfAkWzJcf();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA fGAMIPrvoVhZuhHqRhbQQZXOilDt(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong PLvcCWMYLzPgIQZNOANNuhrCEjJt(IntPtr P_0, bool[] P_1, uint P_2, goIoGPeYfFjFSZEmFgCVtogROhSX[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong EjnxsSFkBGUMRnAtlyGYHMNcDnUfA(IntPtr P_0, bool[] P_1, goIoGPeYfFjFSZEmFgCVtogROhSX[] P_2, double[] P_3)
	{
		return PLvcCWMYLzPgIQZNOANNuhrCEjJt(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool NRImRnPhvJZsJSqRmVDEXIrdPGWI(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA OfBGtFJSCWaRbakagNbfZBRWsNWdc(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint ALuhJZaoutdyUFVIUndBuDbAFzuv(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA wTCfCILwRCqjrrhrnEgXomEKhtMH(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int JVGRVXZmVIiXMqZLtOMseKTGszai(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int vnuNnbsutCzQhsGfDsGdcKekcQKk(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int JEanLlcAqbAoeNAMcyubyoTzFosr(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr SUABFfkDGJAlvZKiDpRSzKNkgRxrA(IntPtr P_0);

	public static string QeJCjzKIRduOeezZiqLQBCPsQCBf(IntPtr P_0)
	{
		IntPtr intPtr = SUABFfkDGJAlvZKiDpRSzKNkgRxrA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA DyfGtlgqbBMoVWjoyJwlbYXBqBhCb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint PcluEMyoxHEXsEHUYNcHwDaBkjpDb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern IBaNvcwPYiqrcPkMbchCPFZQrDpr RRasadlDAWStMcjOCaWjThRziVSK(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern VcZgAbEHJvkmjNVTRBpxVMjUXEsC btKAzEfaNWonWqpcggzDHOzkeOZvA(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort YdlgytYWTCfRHHkmZRJesHTcbKyG(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort mSLGbzSmdMLWOYxEEUGndpRDZxoS(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA JfKIlPGVLmNCnOUgyaFFqGIrHWdGA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr fZFboiUXJPaZTmoyACtXnxuAPgRF(IntPtr P_0);

	public static string dMIFflPwvFSHKMvKDwmQKbLJYpwS(IntPtr P_0)
	{
		IntPtr intPtr = fZFboiUXJPaZTmoyACtXnxuAPgRF(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA fWGPZWIvqnRTTtWNbRHbOluCRHdW(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool aLkCmGaFmvWWyWLBkQnJpOheggdh(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern YEddRxIQmgTYEowryWdPAJlNvhwRA cJSAGubWdApbhNSDGYkiPCKpnSpVA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void ZbdabczudADQalgQPehiOCHGtgsD();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void xoFMSlVcJpPcjwUEjGNIgCGcvlKT();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void rRiGLbTsaUejFuqEtJiYFOKpDCoGA(JAAslQsVSRrulKqEKiIcbTrvWiYwA P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void dSSZBcFcOGmjOmYrhDuAyKcdBvHJ(JFwIAuRaBeJDylBkEOvVnYCqjoXo P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int TTwoehEAmskqBTEfaeYKrJbvJaOs(IntPtr P_0);

	public static kMQRDKcWOYwgWgJzAeQPGULVPACib sudszWgATFcPfrgbqgRLRdDeAlZn(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return kMQRDKcWOYwgWgJzAeQPGULVPACib.LocalUser;
		}
		return (kMQRDKcWOYwgWgJzAeQPGULVPACib)TTwoehEAmskqBTEfaeYKrJbvJaOs(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr AHYDdjEkrzxwAoSomXHUxdXUAkKbA(IntPtr P_0);

	public static string mcbECQRqcOoVoZvDHLUoNVpLnvEE(IntPtr P_0)
	{
		IntPtr intPtr = AHYDdjEkrzxwAoSomXHUxdXUAkKbA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern YEddRxIQmgTYEowryWdPAJlNvhwRA cJVSFDjYUQrIWnzUcJHvQiiAniMK();

	public static YEddRxIQmgTYEowryWdPAJlNvhwRA jYFDBKiYwLdgaaptsSRfioewVByN()
	{
		return cJVSFDjYUQrIWnzUcJHvQiiAniMK();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr AUxAvmGcIFgMPbTGjxypYNUKpEaub(IntPtr P_0);

	public static nqIwrksmxGjZgVbcGIQOpnyGyhsU PbYEMagsgCAYCUTvtiHnxEVhidSDb(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = AUxAvmGcIFgMPbTGjxypYNUKpEaub(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new nqIwrksmxGjZgVbcGIQOpnyGyhsU(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr uHCQRTIcKISOANuEwCciYQEoVicB(IntPtr P_0);

	public static nqIwrksmxGjZgVbcGIQOpnyGyhsU tXrHiCyYiFxvBAwbtGbeSAdLccHx(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = uHCQRTIcKISOANuEwCciYQEoVicB(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new nqIwrksmxGjZgVbcGIQOpnyGyhsU(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void sIEDJsdQyIJFOLOQVcVyzcfTdjgA(IntPtr P_0, IntPtr P_1);

	public static void DCEhSTPpPKClVWUEVROobxihrmQj(IntPtr P_0, nqIwrksmxGjZgVbcGIQOpnyGyhsU P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !xARIgSRqIQgbRdkBdnwpgUwwtJmcA.ZXxzGCiNQoeOpCuDTnfKWXqlgHRmA(P_1, null))
		{
			sIEDJsdQyIJFOLOQVcVyzcfTdjgA(P_0, P_1.GtFTvfgmMdcpqKtBhuEwpBxkHNOSA);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void ivzmgXgClNqJrwrEsrFvdPbNROkI(IntPtr P_0, IntPtr P_1);

	public static void sSzeHKglaNtUSCqOvdKvEZUMnhxO(IntPtr P_0, nqIwrksmxGjZgVbcGIQOpnyGyhsU P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !xARIgSRqIQgbRdkBdnwpgUwwtJmcA.ZXxzGCiNQoeOpCuDTnfKWXqlgHRmA(P_1, null))
		{
			ivzmgXgClNqJrwrEsrFvdPbNROkI(P_0, P_1.GtFTvfgmMdcpqKtBhuEwpBxkHNOSA);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void OChxhVUVkEuCbaakxidneLUvfeRR(DXOcKGfxHCyxboosHwDpRhbpgvyIA P_0);

	public static void rUAdahqqGzAJMfDSbabWhPNhEuaqb(DXOcKGfxHCyxboosHwDpRhbpgvyIA P_0)
	{
		OChxhVUVkEuCbaakxidneLUvfeRR(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void sPXjAiOidexmeweYBHeLwhpxlfwH();

	public static void mdtFIZxbZbsMajDPAmSlnEUaJPHP()
	{
		sPXjAiOidexmeweYBHeLwhpxlfwH();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void kDckgtJEklrtLnxJhdLGHMnLWifg(DXOcKGfxHCyxboosHwDpRhbpgvyIA P_0);

	public static void CvTtrsDLjhoSeihHoOGcaRRhWIvT(DXOcKGfxHCyxboosHwDpRhbpgvyIA P_0)
	{
		kDckgtJEklrtLnxJhdLGHMnLWifg(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void KtfBLQqiVXUHtNoqaMPElfmzjmox();

	public static void aTPPCohbgkdymtOvxLVdBAyyzJXm()
	{
		KtfBLQqiVXUHtNoqaMPElfmzjmox();
	}

	public static ZGEAdUcbLIXpGJwPyoAxFEdXjzpD hgzeuAavrqppKOytwFmZrJZicqXm(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(ZGEAdUcbLIXpGJwPyoAxFEdXjzpD);
		}
		return new ZGEAdUcbLIXpGJwPyoAxFEdXjzpD(dYfvnwSXzYraPNQyENbEfNjFIWbF(P_0), uyylCdELeBasrGTZAXAipjbfIaagA(P_0), mvQmRECAvHRMbskEvhedbIeXmetoA(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool dYfvnwSXzYraPNQyENbEfNjFIWbF(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern yVtPCQFKIkZbvJLFhfXnvGEtbbnD mvQmRECAvHRMbskEvhedbIeXmetoA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr iikrBFHaGwcMTKgSCOqyxSgDFlyFA(IntPtr P_0);

	private static XqyZhJoXpBHVSsFFCDMuXCxFLcAV uyylCdELeBasrGTZAXAipjbfIaagA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(XqyZhJoXpBHVSsFFCDMuXCxFLcAV);
		}
		IntPtr intPtr = iikrBFHaGwcMTKgSCOqyxSgDFlyFA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(XqyZhJoXpBHVSsFFCDMuXCxFLcAV);
		}
		XqyZhJoXpBHVSsFFCDMuXCxFLcAV result = qNGaqYGAdzAmbrFpzCKNbdMTQLFV(intPtr);
		XmBLIafByAaDOgpihfJgGSUvQVGg(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern YEddRxIQmgTYEowryWdPAJlNvhwRA GNlCjqAkpVksXJHuaStoAGPAXIFv();

	public static YEddRxIQmgTYEowryWdPAJlNvhwRA qTLJvaPjXgQnlWixdfrykxmieMpjA()
	{
		return GNlCjqAkpVksXJHuaStoAGPAXIFv();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr YCKaZUKdOtGSxEFUHhAdfdbKahmQB(IntPtr P_0);

	public static nqIwrksmxGjZgVbcGIQOpnyGyhsU ZdKgyGbszqcBFxjqEaHmclGfFIiMb(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = YCKaZUKdOtGSxEFUHhAdfdbKahmQB(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new nqIwrksmxGjZgVbcGIQOpnyGyhsU(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void NRRxBsROWxNeqboSHkVUMWozGcaY(IntPtr P_0, IntPtr P_1);

	public static void EXwUvZpdplmXcxLBfNjwQRiXpXWP(IntPtr P_0, nqIwrksmxGjZgVbcGIQOpnyGyhsU P_1)
	{
		if (!xARIgSRqIQgbRdkBdnwpgUwwtJmcA.ZXxzGCiNQoeOpCuDTnfKWXqlgHRmA(P_1, null))
		{
			NRRxBsROWxNeqboSHkVUMWozGcaY(P_0, P_1.GtFTvfgmMdcpqKtBhuEwpBxkHNOSA);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void IfwZWAqVrplYAhkOenalBROQrQUu(muMPTyNHFygMoFuzCbaZcyKOHHsnA P_0);

	public static void lVrTVtqLefIEyoxnYrliLkesbJtR(muMPTyNHFygMoFuzCbaZcyKOHHsnA P_0)
	{
		IfwZWAqVrplYAhkOenalBROQrQUu(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void hHQuCyLocsFaVSrGjZudBmmSsERA();

	public static void gIEXdiQkohATrjohhhAHOddOwVrAA()
	{
		hHQuCyLocsFaVSrGjZudBmmSsERA();
	}

	public static wrTICxzlUXedMbMYHxpFyreTGSDG PWfBjHEoFKrwcJCGKFJvVqGBjXie(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(wrTICxzlUXedMbMYHxpFyreTGSDG);
		}
		return new wrTICxzlUXedMbMYHxpFyreTGSDG(ucxgaQgbTzigVINDrPlyOdKAPrUkA(P_0), sEPjDjEvnWOxDpWvxQpiTWHQPvwc(P_0), kaJmeABieKPCswGOdFXIGrkfQNGF(P_0), TLQPgBKoRAenHFWclrsWhfajPZOu(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern seycbLZziAMbCVJlOCTSvxBLXdpB ucxgaQgbTzigVINDrPlyOdKAPrUkA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool sEPjDjEvnWOxDpWvxQpiTWHQPvwc(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern yVtPCQFKIkZbvJLFhfXnvGEtbbnD TLQPgBKoRAenHFWclrsWhfajPZOu(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr LHUBxggRXfqnyjUagVtbudkWhUjQA(IntPtr P_0);

	private static XqyZhJoXpBHVSsFFCDMuXCxFLcAV kaJmeABieKPCswGOdFXIGrkfQNGF(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(XqyZhJoXpBHVSsFFCDMuXCxFLcAV);
		}
		IntPtr intPtr = LHUBxggRXfqnyjUagVtbudkWhUjQA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(XqyZhJoXpBHVSsFFCDMuXCxFLcAV);
		}
		XqyZhJoXpBHVSsFFCDMuXCxFLcAV result = qNGaqYGAdzAmbrFpzCKNbdMTQLFV(intPtr);
		XmBLIafByAaDOgpihfJgGSUvQVGg(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern YEddRxIQmgTYEowryWdPAJlNvhwRA XmBLIafByAaDOgpihfJgGSUvQVGg(IntPtr P_0);

	private static XqyZhJoXpBHVSsFFCDMuXCxFLcAV qNGaqYGAdzAmbrFpzCKNbdMTQLFV(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(XqyZhJoXpBHVSsFFCDMuXCxFLcAV);
		}
		return new XqyZhJoXpBHVSsFFCDMuXCxFLcAV
		{
			XlTCthDQqVBxPVOXjsFcDyhKWUrj = (Marshal.ReadByte(P_0, 0) > 0),
			osfPkDJfBQDLratsTwwbumrUZzLw = (Marshal.ReadByte(P_0, 1) > 0),
			QCuENPrTDdiLaETPhEVerwmRbLUeA = (Marshal.ReadByte(P_0, 2) > 0),
			VpQbIqdJkiHzmIQuhabtopXaUFRU = (uint)Marshal.ReadInt32(P_0, 4),
			xIYcOGugglMFoJsGPvLAgPCIhSiAA = (uint)Marshal.ReadInt32(P_0, 8),
			gPgfxEUnMKdjyeDSPledlXgUdXTC = (Marshal.ReadByte(P_0, 12) > 0)
		};
	}
}
