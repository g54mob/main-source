using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class zozEkloLkrVHftHQJGwuJDULcirhA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DPzibXcnHNBlSLzYXIFWPtJYQllF(SDOodhEmnqqbwYXmWDHLYmZQvuQj pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void yXbQRjvlwEmKdnLBXvpaKpCeUrRN(SDOodhEmnqqbwYXmWDHLYmZQvuQj pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void JkzOBYiLwVKeBgHfcozcQREworae(SDOodhEmnqqbwYXmWDHLYmZQvuQj pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void JxJffkeTGskhCeHrdmZLqagBbizNb(SDOodhEmnqqbwYXmWDHLYmZQvuQj pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void ZQxfyMzQEOPlTIYthvPxeVFmjnOf(SDOodhEmnqqbwYXmWDHLYmZQvuQj coreWindow, SDOodhEmnqqbwYXmWDHLYmZQvuQj keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void gqfeDiTGPmoTWxylkOKNxcYLZeME(SDOodhEmnqqbwYXmWDHLYmZQvuQj coreDispatcher, SDOodhEmnqqbwYXmWDHLYmZQvuQj acceleratorKeyEventArgs);

	public const string RKZEswcWLRlSByfilKSfYppWGLtz = "Rewired_WindowsGamingInput";

	private const CallingConvention PUyauayqnwOQEVCNQNPBcYcmAdeh = CallingConvention.StdCall;

	private const CallingConvention uEFgDQIxOJzfyLKCCLGcAdQyUnpX = CallingConvention.StdCall;

	private const UnmanagedType WCVJnylczegWbpTezcfifxyggTmIA = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong rKCPzIFbksylwslTVOLHyzsYrWcM(IntPtr P_0);

	public static ulong lExzXLKDFKeHcRLMUKPMvgEOrfiH(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return rKCPzIFbksylwslTVOLHyzsYrWcM(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong AoVLipMqpgmpBquHZgkfFvcjYvVc(IntPtr P_0);

	public static ulong BIApivqUeqIpXqtDIQPQgEJWEPOE(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return AoVLipMqpgmpBquHZgkfFvcjYvVc(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool mYioCBMEviDubGOLWGRGNWIIBvWYA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr wAmXfRflSYLcTHotsYKNtwCDdTeC();

	public static string WJtrRYQTIeHyfGioVCaGCTIeUTEB()
	{
		IntPtr intPtr = wAmXfRflSYLcTHotsYKNtwCDdTeC();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj SQPXDDPNlOhulHDLTMSxeOROSAjC();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint FCqCxFHLCMiuDcCmwLcCkpfXWGGrA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj SSNymXjCbsHrBamcgfkGcblyRQHo(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool vzhxqvZkTpTenXEzOFqvOLplxtqJ(IntPtr P_0, ref xJtjLRloAVFCKIkNGERFcJigdCiZ P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool XFqVbLCUyvgPcBxEKJDKmbWRJjIB(IntPtr P_0, ref auQfmzpEFzGLnDtXtfBaakWheNKY P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void SkhWFgaESjzmlPylkuKmpxBBZcqF(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] auQfmzpEFzGLnDtXtfBaakWheNKY P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr LUZwKfKlbXBmVYUCGeIcgSIpnoTTA(IntPtr P_0);

	public static WSWPBvsjVeqiQjosfQrsxdKXJkfR NNjVeqSXjdsxnsZgpTdZQFOxgsrR(IntPtr P_0)
	{
		IntPtr intPtr = LUZwKfKlbXBmVYUCGeIcgSIpnoTTA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new WSWPBvsjVeqiQjosfQrsxdKXJkfR(new rekqjQgbBOUmnTjvFUbAgMkjAMAK(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool lOnVJhLNUtclpuKLRBhkkJTNMnbcA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj RCEAuCgXXLZxWOAkrNiYVSwKROBs(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern WJmYkicHmlZOfLHPUPIUibPpDBM eVSicMXohSDNrVErbBUgbcmiscJO(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void zxkEPCeoGyQKyaFxQVQRfexMtZE();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void OXgUwstFbbpGXjzWvWyJFHzusdDg();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void SFdqvzMYGbCSmvhUhoUORQWkHuzn(DPzibXcnHNBlSLzYXIFWPtJYQllF P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void zohQRncUELLWQivWGKNHveRdVmcv(yXbQRjvlwEmKdnLBXvpaKpCeUrRN P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint aRYeozJJervfdCAGCBupFVOxFkNl(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj MfmDqtIvVUwGcChLCKFQzeEVQjYZA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj vctdRrbnETfOoDfmlBOsLjCHvihe(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong PcGFJKgQGrmdsDqEwNaFexXBMzny(IntPtr P_0, bool[] P_1, uint P_2, wNdWVLqEcHZZufOxjclVgbCWHxoS[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong KuWcBMLLEMnyzLgmFDuACPdbFpiy(IntPtr P_0, bool[] P_1, wNdWVLqEcHZZufOxjclVgbCWHxoS[] P_2, double[] P_3)
	{
		return PcGFJKgQGrmdsDqEwNaFexXBMzny(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool HGljFhZZoLRltympQihCYiLauDao(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj EbsOGNUAVIjXJEbnfiHrKftvmHwv(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint AtJinNovajCWcxNKiNQNpRANpDYg(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj gmpKYIJwvGnMZRcsTLiDhseFAdgz(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int FexgATFGcWSosIGlDgacndDZkmMd(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int nPPHeheqtOBXPMCJzkQfzlYxoWsk(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int JePUSnulpdeYSnPPICEpkhvcNmMIA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr KhlwihHqTFHQTwCbrfKIRmjjBLFL(IntPtr P_0);

	public static string UVqQrxAAPtaOMAMwGyOSqYqpYYjlA(IntPtr P_0)
	{
		IntPtr intPtr = KhlwihHqTFHQTwCbrfKIRmjjBLFL(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj BeQYUzwlmDOOzHetWgOfHxzYJZJk(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint JbGvbOgiMThvUxXGwIXLKCfAnnNe(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern WJmYkicHmlZOfLHPUPIUibPpDBM HVLcVtelDMRashIHkLYhCCfAyqeyB(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern HweRVzClOhITNdfEdDxfWFwTkLKW dvdyUWhKEQVPmCBbSnLNJMXlAilK(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort KbSPstKWnIXitbhOnxManbRdjNSe(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort wNkQsdGggAcywgIFiuOjshvApGGG(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj HalYbFOMKayiJwDdCHhFfTgoMsNk(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr jocSEuAJCLaKtEtlsRgJiuXVdBvW(IntPtr P_0);

	public static string jXjKonTgiLrmraVChEJYXhCQhUAe(IntPtr P_0)
	{
		IntPtr intPtr = jocSEuAJCLaKtEtlsRgJiuXVdBvW(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj tIvaBWEfgpbTxRUrVnHtDOLJNwBd(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool ynJHpIcqQvPqCgxCEjyJqkwniiHy(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj yCfnTyOIyMRtZsdIiGPoJzgiSGDI(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void XJOnNpvDfMajckBzndArHLaKNdYkc();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void dKotpqFUAtSXMIRcPhaMpsdbtpgC();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void bnNgtvZDxCFYlWWTFEgSALygKHAi(JkzOBYiLwVKeBgHfcozcQREworae P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void xsjKgqBoJCcMcIYsVmlOhrCmcFjr(JxJffkeTGskhCeHrdmZLqagBbizNb P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int DmTIPvIKlodArbqoEtsUooXiziaN(IntPtr P_0);

	public static mSfgEYsNBICmzUiIaoVtJnvKGqMc sLOeRQDyWPXQZaXyKoYFQYbfhrvoA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return mSfgEYsNBICmzUiIaoVtJnvKGqMc.LocalUser;
		}
		return (mSfgEYsNBICmzUiIaoVtJnvKGqMc)DmTIPvIKlodArbqoEtsUooXiziaN(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr UgnIxrwdmtSOgORtCdLMiMvDcIiH(IntPtr P_0);

	public static string owCRvSDYlAbYAxworWzaSnhOajmQ(IntPtr P_0)
	{
		IntPtr intPtr = UgnIxrwdmtSOgORtCdLMiMvDcIiH(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj ozmTtTpwRCDFwDKeQEppZgSXVhuW();

	public static SDOodhEmnqqbwYXmWDHLYmZQvuQj zgkmRIorCBGWOQmpKrajbcYlXyOe()
	{
		return ozmTtTpwRCDFwDKeQEppZgSXVhuW();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr OGSIgsqoPZeBtjGRBIIbYgewyUAs(IntPtr P_0);

	public static nQxUfeqZmSnwMvmvssYWqCCLduUi NnrbamwzjUepsjemTkzdRDziezkX(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = OGSIgsqoPZeBtjGRBIIbYgewyUAs(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new nQxUfeqZmSnwMvmvssYWqCCLduUi(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr yHgozDQRtYfymfsxoLsuJqsjbZWU(IntPtr P_0);

	public static nQxUfeqZmSnwMvmvssYWqCCLduUi tkMucQoibRlFpqngLzgeFoZMqarU(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = yHgozDQRtYfymfsxoLsuJqsjbZWU(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new nQxUfeqZmSnwMvmvssYWqCCLduUi(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void aPlLaHhqVKgzzbMRkhCXcmYyvzLT(IntPtr P_0, IntPtr P_1);

	public static void XgtAMNGJYKjwdJaLlfduqsGkLpkGb(IntPtr P_0, nQxUfeqZmSnwMvmvssYWqCCLduUi P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !jYwNOUTGZCVFxAeQPEEzLFOrjZQn.ZfEcnEcsPmAgDYPSxyTUUiKyjVbq(P_1, null))
		{
			aPlLaHhqVKgzzbMRkhCXcmYyvzLT(P_0, P_1.QokGQjcgFrKLADCILpmwUGLhwNau);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void uKMjPVewaFBIZOsTChRrkBJAeVYhA(IntPtr P_0, IntPtr P_1);

	public static void mGGsiIwcjNwnyshJDsMxNZyTzZVh(IntPtr P_0, nQxUfeqZmSnwMvmvssYWqCCLduUi P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !jYwNOUTGZCVFxAeQPEEzLFOrjZQn.ZfEcnEcsPmAgDYPSxyTUUiKyjVbq(P_1, null))
		{
			uKMjPVewaFBIZOsTChRrkBJAeVYhA(P_0, P_1.QokGQjcgFrKLADCILpmwUGLhwNau);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void QEEWMHWwzSkAHSGvPwTznDciDcdz(ZQxfyMzQEOPlTIYthvPxeVFmjnOf P_0);

	public static void nhvXTbmuLnJbifEDNlVAUvvTBeSX(ZQxfyMzQEOPlTIYthvPxeVFmjnOf P_0)
	{
		QEEWMHWwzSkAHSGvPwTznDciDcdz(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void wpuKWmUNgetVSQGLdSzBxdHqHlEu();

	public static void iACvDVzFKzitODgUuehzqJihLhdK()
	{
		wpuKWmUNgetVSQGLdSzBxdHqHlEu();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void ovLqLxHnZbBXtiNsNiPSDOuOJMPVA(ZQxfyMzQEOPlTIYthvPxeVFmjnOf P_0);

	public static void UgoACgLMibViWWKIUjikhfvqFOJEb(ZQxfyMzQEOPlTIYthvPxeVFmjnOf P_0)
	{
		ovLqLxHnZbBXtiNsNiPSDOuOJMPVA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void QfSJwEeuQRaRBryjQoBAoqIqyKUF();

	public static void wJwfwmevjaVOSATcJnxljWSbCXjNA()
	{
		QfSJwEeuQRaRBryjQoBAoqIqyKUF();
	}

	public static JypRzGkteMjbklmnOLUxGjuAcjJv zdGFHAsiXoVGogdsOYqLiDpjcjjH(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(JypRzGkteMjbklmnOLUxGjuAcjJv);
		}
		return new JypRzGkteMjbklmnOLUxGjuAcjJv(bNCSKyOVyKhZztexcUvYojBQFSDz(P_0), uNHrxMMnPIURqiQyVkwiOZaoqAk(P_0), ohnuIPKubNaTxOLoFUrDXKpGgVHc(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool bNCSKyOVyKhZztexcUvYojBQFSDz(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern gPWrwEDGZeQhRzdMXAPLcsuwCfFDb ohnuIPKubNaTxOLoFUrDXKpGgVHc(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr csXcBlLHHkqxuUBXyYwfcIVClYHB(IntPtr P_0);

	private static NmHSOVcJwHrmyYrSgwyuKPFUwgaL uNHrxMMnPIURqiQyVkwiOZaoqAk(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(NmHSOVcJwHrmyYrSgwyuKPFUwgaL);
		}
		IntPtr intPtr = csXcBlLHHkqxuUBXyYwfcIVClYHB(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(NmHSOVcJwHrmyYrSgwyuKPFUwgaL);
		}
		NmHSOVcJwHrmyYrSgwyuKPFUwgaL result = sSdgTWUuuvCwRTqeTwkFanuUNXnV(intPtr);
		ZreEoynUzMHCeYVnBtRuPYkqeMos(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj QZGvKwGFcHBQdnXvQAXeARfPOOtFb();

	public static SDOodhEmnqqbwYXmWDHLYmZQvuQj oRyOVyPKrkVBLcmBHFPkfSenIrHd()
	{
		return QZGvKwGFcHBQdnXvQAXeARfPOOtFb();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr MflSuOWrDpFuBnVNhjudiHTvlpMU(IntPtr P_0);

	public static nQxUfeqZmSnwMvmvssYWqCCLduUi TzfTVQgnesxplBfjknkswheCGYMF(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = MflSuOWrDpFuBnVNhjudiHTvlpMU(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new nQxUfeqZmSnwMvmvssYWqCCLduUi(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void TRuwWePcXdGKYVuBtphWJXMylaUV(IntPtr P_0, IntPtr P_1);

	public static void UlFCYLtrqhrpGFlSFJJcVWGGTNqn(IntPtr P_0, nQxUfeqZmSnwMvmvssYWqCCLduUi P_1)
	{
		if (!jYwNOUTGZCVFxAeQPEEzLFOrjZQn.ZfEcnEcsPmAgDYPSxyTUUiKyjVbq(P_1, null))
		{
			TRuwWePcXdGKYVuBtphWJXMylaUV(P_0, P_1.QokGQjcgFrKLADCILpmwUGLhwNau);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void KdBCxUeHqvDqqLoTOEArGuaNRMcU(gqfeDiTGPmoTWxylkOKNxcYLZeME P_0);

	public static void rGOgSbcytvcTMEIwmZSgOjArBUJi(gqfeDiTGPmoTWxylkOKNxcYLZeME P_0)
	{
		KdBCxUeHqvDqqLoTOEArGuaNRMcU(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void pfomTUDxhsstQsVmmHbiIwCxUgmX();

	public static void culCQwYldvjhLCxgXdqTeIPTVJHr()
	{
		pfomTUDxhsstQsVmmHbiIwCxUgmX();
	}

	public static elcCzptRZPgGsBRDzkXNMnWIdOvgb LMrnmbUlnQCXYpxDuEnpSvCAVpQq(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(elcCzptRZPgGsBRDzkXNMnWIdOvgb);
		}
		return new elcCzptRZPgGsBRDzkXNMnWIdOvgb(omIRvYpkMfOaltbWTLKqwZeLvjyj(P_0), eYsPOhEOySvolDcXNEykSoiNFXTW(P_0), kDwsLAXzhMOtYUmTRvpUFJQuUScU(P_0), VnjJLVSKQwXbfLnVGQSDaMunZeCb(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern yuFlFrHYkSSoJlrAgGgRqGLWuVRV omIRvYpkMfOaltbWTLKqwZeLvjyj(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool eYsPOhEOySvolDcXNEykSoiNFXTW(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern gPWrwEDGZeQhRzdMXAPLcsuwCfFDb VnjJLVSKQwXbfLnVGQSDaMunZeCb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr HbnClmXmIxJpKoAzYLFzqNKDEVFF(IntPtr P_0);

	private static NmHSOVcJwHrmyYrSgwyuKPFUwgaL kDwsLAXzhMOtYUmTRvpUFJQuUScU(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(NmHSOVcJwHrmyYrSgwyuKPFUwgaL);
		}
		IntPtr intPtr = HbnClmXmIxJpKoAzYLFzqNKDEVFF(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(NmHSOVcJwHrmyYrSgwyuKPFUwgaL);
		}
		NmHSOVcJwHrmyYrSgwyuKPFUwgaL result = sSdgTWUuuvCwRTqeTwkFanuUNXnV(intPtr);
		ZreEoynUzMHCeYVnBtRuPYkqeMos(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern SDOodhEmnqqbwYXmWDHLYmZQvuQj ZreEoynUzMHCeYVnBtRuPYkqeMos(IntPtr P_0);

	private static NmHSOVcJwHrmyYrSgwyuKPFUwgaL sSdgTWUuuvCwRTqeTwkFanuUNXnV(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(NmHSOVcJwHrmyYrSgwyuKPFUwgaL);
		}
		return new NmHSOVcJwHrmyYrSgwyuKPFUwgaL
		{
			DXovAlHMbVHNrFbGTRYgdGZTWGJdA = (Marshal.ReadByte(P_0, 0) > 0),
			uoWPBFRCqAlgRPitnWLxraNXFjxr = (Marshal.ReadByte(P_0, 1) > 0),
			GYFaBVdcOdcdEkxAPQvmqmGYGTijA = (Marshal.ReadByte(P_0, 2) > 0),
			LulwlwfgvwwRUaRnPsBlpztlMZjU = (uint)Marshal.ReadInt32(P_0, 4),
			jYbXfQiexxDfQfwJbApGxRsFVOIQ = (uint)Marshal.ReadInt32(P_0, 8),
			giZGEIYlmMKNSCJElnPzuFxVLrrp = (Marshal.ReadByte(P_0, 12) > 0)
		};
	}
}
