using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class yvgWAgmxKiqEtmrAqGIhPEEXIuLEA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void ItqXeWuZjMDQOQTYoKkLPRPGOUPS(JbFAywBYXfGhagDypdlSSUPUqzcGA pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void bKqBUolUkLBbzqLvmXdzAQMoblbD(JbFAywBYXfGhagDypdlSSUPUqzcGA pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void KWkFOLqkfADDPhcVZKEdQvJmVmYu(JbFAywBYXfGhagDypdlSSUPUqzcGA pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void UjUtLvBwazaJQAjpTlHCaucfiQZH(JbFAywBYXfGhagDypdlSSUPUqzcGA pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void CtwshPdrmJgGPLutYRVseuDyOpqQ(JbFAywBYXfGhagDypdlSSUPUqzcGA coreWindow, JbFAywBYXfGhagDypdlSSUPUqzcGA keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void fPuFarNJuzOhOoEyFEoMerwVhFyZA(JbFAywBYXfGhagDypdlSSUPUqzcGA coreDispatcher, JbFAywBYXfGhagDypdlSSUPUqzcGA acceleratorKeyEventArgs);

	public const string UUIghtqxyCoZopmmSwmlUbwYPTlb = "Rewired_WindowsGamingInput";

	private const CallingConvention YhjQcfmIAdeJQKvGpAnQfkSkuCKDA = CallingConvention.StdCall;

	private const CallingConvention nBQFRXMzkWuAkYtCbilvQQKklDLK = CallingConvention.StdCall;

	private const UnmanagedType LCKrfSrVCvVzGuuzWThntcaqPAFB = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong iXVzbBVkGxoVcjBBivqOqEyMKxGJ(IntPtr P_0);

	public static ulong mfgBjUHYfRxnwgUAlqsDkdOKsnCxA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return iXVzbBVkGxoVcjBBivqOqEyMKxGJ(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong LGbIDjGhYaprbhvasHKvPijbPANV(IntPtr P_0);

	public static ulong OsXDncqJgzKRDbYldLkJiOAUwUkT(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return LGbIDjGhYaprbhvasHKvPijbPANV(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool bIzEGGQGRfdgxHvZhtnVEjYEjUai();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr lEdgHIpYZVsEZOPgPIgWdIaRthGw();

	public static string FCMJrYAfhPrQiVXaBlwrGCPyAMrjA()
	{
		IntPtr intPtr = lEdgHIpYZVsEZOPgPIgWdIaRthGw();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA BqCDFMDwnJasbOcTuWmiswEOASVV();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint YIbdzEFxkRDnJJniRdABrcdHzGqU(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA ZmAfyQAlJrEoBOdwXhSTmsfoPYljA(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool oHyKdoNxKmnYzMprjWhkUXptknQT(IntPtr P_0, ref woIXEaxkDSRQKTJnvfWBciuaAYVB P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool AwhHPgUBsxmvHOGjzilMdgjLSVTkA(IntPtr P_0, ref nqXEdeCznmdQnPGHYFzpCcMKdXyjb P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void FWsFSpeJocOcbUhyFEIffpvJXDOaA(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] nqXEdeCznmdQnPGHYFzpCcMKdXyjb P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr AoQUjkIMRIrpZRCMxsSlUMStsGlF(IntPtr P_0);

	public static PPDXZyeXrppHMaauQFyfdOAVGgNV SrmwPdYrHofHrrowGbeMWGMpFoJV(IntPtr P_0)
	{
		IntPtr intPtr = AoQUjkIMRIrpZRCMxsSlUMStsGlF(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new PPDXZyeXrppHMaauQFyfdOAVGgNV(new wXdOkBsjtVnNnIDvwJcZyTyveGyS(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool epyNQeTMayqshldBmLEdPTRHhPRg(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA OcPeeLymhOomQHEyUALZJuqUSwbe(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern LXEIYvsGfleIWyGJqcpZIUrLFNhnA piHXsVBEFLeKriArMIitmfkwrojY(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void idmLuMYDAZpjCtJLWKkDFNchNEbY();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void XKtYMrdEHwSgNyhWWjcUZnfsomdq();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void DCqncaUBsgHVawCCKoMJLEWsgKLI(ItqXeWuZjMDQOQTYoKkLPRPGOUPS P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void wTaVwgqmLUJMIpGjllvCbTspeDGg(bKqBUolUkLBbzqLvmXdzAQMoblbD P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint dmPsokLqrifspRlIpAhsXDGnfDzeA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA FazbsmtKlRLXusPDfaxHaeGVuhaT();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA mdckfIrjHEZqOKHfGZpZFnfZQbDx(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong OjRAFZIHsuXeetkULAEGtlBVdtLM(IntPtr P_0, bool[] P_1, uint P_2, frmFJCgoEMQNscrvWIaAeqGOdgGK[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong XmLZBLHJcZEhvERgyUMNMAzblfYw(IntPtr P_0, bool[] P_1, frmFJCgoEMQNscrvWIaAeqGOdgGK[] P_2, double[] P_3)
	{
		return OjRAFZIHsuXeetkULAEGtlBVdtLM(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool EqwNsuHEOhqjofrxCXBjGDwfLSXA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA HHluYCUVlJbcLFzbKWbmSDdnQLUR(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint VpMrkUsFJgTRweUXROpStODPjnas(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA vaZKFhVBJyPPmYycVSAshsDInAAA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int SXqfmYRuiTUNaTkQogGbvhtFcccHA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int yPYowNwNGNCDSJVcQcyWdYolwICB(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int SACOAqkYRkVMWiGPrIyqfOxuLewy(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr VXeWeeBQfCPWHrmbSlLPZFdzTRtu(IntPtr P_0);

	public static string JHhvwqOreiHyGFqqvyBTAgwvWULE(IntPtr P_0)
	{
		IntPtr intPtr = VXeWeeBQfCPWHrmbSlLPZFdzTRtu(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA OZPuSyczOEfBlECbvSqsXVbMoVro(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint YeVHjZwCWWjsGcDZRNmEYYOUkftW(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern LXEIYvsGfleIWyGJqcpZIUrLFNhnA GOWTXcjybHvIcDgRHIacAihscoUcA(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern KgxFLaAcukNBTcYjAZxkEwmTJWue yOsIFZfmmRGgyJqbbzSCPRJlShBj(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort HbBSVmYKmPWMvwpnQSHrrXjfrxqM(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort dPhLSuOpQFfdibuVLbKebqlUarmfb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA SiilOGONmjevXrbprgZWdxgiMIxRA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr oVhSadYAyWCXhZuhHWAAguLXlTZX(IntPtr P_0);

	public static string qKyRCiBZCOeWcncTYAcVRmnIDfwW(IntPtr P_0)
	{
		IntPtr intPtr = oVhSadYAyWCXhZuhHWAAguLXlTZX(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA sRoFgHIxHgCaxGIKkdVaZbQHXLhV(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool zoOzNsiwdufIwpOknYWwcwJvmbRb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern JbFAywBYXfGhagDypdlSSUPUqzcGA rFuyftGHITbIRezAXOepvHuyTMvcA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void CTZBoulfVLunuCFrYgmkRoyHnjyi();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void urjHvgRfkiDTRHTNmJBPHrmBnvKRB();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void mpELqqTqDVSAhDPXuzoJCXmeAVcL(KWkFOLqkfADDPhcVZKEdQvJmVmYu P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void auuexDFhZuNotTyoVTXpxQaHXZnA(UjUtLvBwazaJQAjpTlHCaucfiQZH P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int YUZHocEPpKHrAesvbIJskTmKwOmA(IntPtr P_0);

	public static diyHwLmmpJAPoBscNfECBodOqKYU vyVZvNsZqYNpTKKahqlIUBztelNq(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return diyHwLmmpJAPoBscNfECBodOqKYU.LocalUser;
		}
		return (diyHwLmmpJAPoBscNfECBodOqKYU)YUZHocEPpKHrAesvbIJskTmKwOmA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr DDaBEmIqWaRNguNbzEHRXavXfwMKA(IntPtr P_0);

	public static string dgZblXNLnXJfMgusQLGnOpuWdcCd(IntPtr P_0)
	{
		IntPtr intPtr = DDaBEmIqWaRNguNbzEHRXavXfwMKA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern JbFAywBYXfGhagDypdlSSUPUqzcGA rFxbSEjQpHSkcUcidaRwNGELpxAV();

	public static JbFAywBYXfGhagDypdlSSUPUqzcGA axvPgPkuHEuNINdaxXDefAEdPNaP()
	{
		return rFxbSEjQpHSkcUcidaRwNGELpxAV();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr BxBwQhewdEKzbeTTcqwwUCgybKcHA(IntPtr P_0);

	public static qUagInmRWXEoMgkjNfAPAyUATfoFc KWiStraNLVElsaqqeFHoZcbohrUz(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = BxBwQhewdEKzbeTTcqwwUCgybKcHA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new qUagInmRWXEoMgkjNfAPAyUATfoFc(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr tulbFOQIRRrnuuyrZIWnFGspTtag(IntPtr P_0);

	public static qUagInmRWXEoMgkjNfAPAyUATfoFc mUTkUFyQBYMJrxRisEPrDsNWaPHl(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = tulbFOQIRRrnuuyrZIWnFGspTtag(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new qUagInmRWXEoMgkjNfAPAyUATfoFc(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void rMwyRSdihPiXdcoDNaYWyrGgldlJ(IntPtr P_0, IntPtr P_1);

	public static void KauFAOTeoRxjztIBWuBhiKWuHjCW(IntPtr P_0, qUagInmRWXEoMgkjNfAPAyUATfoFc P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !uEplFFVnrXpUlRmOwcsyCVYlnFkYA.EbTedXFezrlvXFXAYXlDNAUgqJJcA(P_1, null))
		{
			rMwyRSdihPiXdcoDNaYWyrGgldlJ(P_0, P_1.JxxdWaDmvgKSCzUIgwOvUOXvmPIeb);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void hRHZWKuIEzZLdVPvMjqggVfAZwRb(IntPtr P_0, IntPtr P_1);

	public static void rWRomPiGZMZnufQHudYiDKqJdfxAA(IntPtr P_0, qUagInmRWXEoMgkjNfAPAyUATfoFc P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !uEplFFVnrXpUlRmOwcsyCVYlnFkYA.EbTedXFezrlvXFXAYXlDNAUgqJJcA(P_1, null))
		{
			hRHZWKuIEzZLdVPvMjqggVfAZwRb(P_0, P_1.JxxdWaDmvgKSCzUIgwOvUOXvmPIeb);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void DzLIkWGpZRXcBFmxgdCmzvyiqmDh(CtwshPdrmJgGPLutYRVseuDyOpqQ P_0);

	public static void cWkTDyiqruiqokxDkxIRIVvNoQcF(CtwshPdrmJgGPLutYRVseuDyOpqQ P_0)
	{
		DzLIkWGpZRXcBFmxgdCmzvyiqmDh(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void tndMfKUSxrKWIBXArHYedLcUvgFA();

	public static void jBJsfMxpawdrYFEEBsIwUyazGXXX()
	{
		tndMfKUSxrKWIBXArHYedLcUvgFA();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void dhADTsXtowMgtChwohAXYKeSEovg(CtwshPdrmJgGPLutYRVseuDyOpqQ P_0);

	public static void XYldIvJsKcCxQfREdBOfFltBqYfFB(CtwshPdrmJgGPLutYRVseuDyOpqQ P_0)
	{
		dhADTsXtowMgtChwohAXYKeSEovg(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void VJZmDpwaEnpDetnxYITcNQudmgv();

	public static void hWnaQxfVVbXqWYukuZfiWBKdJFDr()
	{
		VJZmDpwaEnpDetnxYITcNQudmgv();
	}

	public static MkcpoVeWMTwxqqvDfioiIwmAbHzd kDPQTZmyMjHUklmelOgKgAltGaRFA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(MkcpoVeWMTwxqqvDfioiIwmAbHzd);
		}
		return new MkcpoVeWMTwxqqvDfioiIwmAbHzd(ovHMZlGOKXIszsslFDFNydHMkYzL(P_0), hvAjloSwRKeNJnfSLdUpCwZkikwWA(P_0), xyuhwPSUAAPvZBHXugUkVzQAchhl(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool ovHMZlGOKXIszsslFDFNydHMkYzL(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern pSPclJBtwpyMHmMOmbCYoBgwdbrK xyuhwPSUAAPvZBHXugUkVzQAchhl(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr zJUEyKNUpncxbHRHLEwjctEQnzyT(IntPtr P_0);

	private static OSCvYQcUOQvuiZbWNdEdJIJKpkIVA hvAjloSwRKeNJnfSLdUpCwZkikwWA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(OSCvYQcUOQvuiZbWNdEdJIJKpkIVA);
		}
		IntPtr intPtr = zJUEyKNUpncxbHRHLEwjctEQnzyT(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(OSCvYQcUOQvuiZbWNdEdJIJKpkIVA);
		}
		OSCvYQcUOQvuiZbWNdEdJIJKpkIVA result = fjoNXICYKcrTqKaYkGWEyaaMHKRC(intPtr);
		UpfcjphXhVXuiFxUoxbbDaRqYrYD(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern JbFAywBYXfGhagDypdlSSUPUqzcGA ZITQopKPSYNpraCfplMzJhlBOpZi();

	public static JbFAywBYXfGhagDypdlSSUPUqzcGA hQhOYzXbgdeUVtoyclKjjaApBCxv()
	{
		return ZITQopKPSYNpraCfplMzJhlBOpZi();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr PZocaLUChytwXuFRSeMiauFvFtmS(IntPtr P_0);

	public static qUagInmRWXEoMgkjNfAPAyUATfoFc MFuTTLmKUfBkvaKpPJTnzkuAICkaA(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = PZocaLUChytwXuFRSeMiauFvFtmS(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new qUagInmRWXEoMgkjNfAPAyUATfoFc(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void KOncqrkFxyNTGSODOkVPTRMszmcqA(IntPtr P_0, IntPtr P_1);

	public static void JvSZQAfNKmjoSbYKsarlfBYFKNQxb(IntPtr P_0, qUagInmRWXEoMgkjNfAPAyUATfoFc P_1)
	{
		if (!uEplFFVnrXpUlRmOwcsyCVYlnFkYA.EbTedXFezrlvXFXAYXlDNAUgqJJcA(P_1, null))
		{
			KOncqrkFxyNTGSODOkVPTRMszmcqA(P_0, P_1.JxxdWaDmvgKSCzUIgwOvUOXvmPIeb);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void TiUcpPBkEqgpkoUFvtayUMsTVSIfA(fPuFarNJuzOhOoEyFEoMerwVhFyZA P_0);

	public static void qZJDkoGuVcKxCdJaLMbnUCUxpNpYA(fPuFarNJuzOhOoEyFEoMerwVhFyZA P_0)
	{
		TiUcpPBkEqgpkoUFvtayUMsTVSIfA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void cxrNIBLcBfeJUtVeNRNnQXEnqDIK();

	public static void fMcaIfbIBuBwVxFkmLMQjaVHbRnZA()
	{
		cxrNIBLcBfeJUtVeNRNnQXEnqDIK();
	}

	public static zvlanclAlMuXsWoDMdhSpbWEQITW YuwgnmSCZRKrCmFJRTqoGAEAdAgK(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(zvlanclAlMuXsWoDMdhSpbWEQITW);
		}
		return new zvlanclAlMuXsWoDMdhSpbWEQITW(nXHuXBvNaqKRpgoSgcjtiKwFZhEu(P_0), jInQrqCILNppnGBlgUyxImBDDflG(P_0), zdhZRVVTxHawKPFjoPnTBEXsMiEe(P_0), CpuKNCAIgLoGluLzosmLgHGkiLIFA(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern bjQRqwDAEDfkPgiQPGAYyjPKIJfW nXHuXBvNaqKRpgoSgcjtiKwFZhEu(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool jInQrqCILNppnGBlgUyxImBDDflG(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern pSPclJBtwpyMHmMOmbCYoBgwdbrK CpuKNCAIgLoGluLzosmLgHGkiLIFA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr YDwzGnBAaqRWGxKtdIjmimIRNUxv(IntPtr P_0);

	private static OSCvYQcUOQvuiZbWNdEdJIJKpkIVA zdhZRVVTxHawKPFjoPnTBEXsMiEe(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(OSCvYQcUOQvuiZbWNdEdJIJKpkIVA);
		}
		IntPtr intPtr = YDwzGnBAaqRWGxKtdIjmimIRNUxv(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(OSCvYQcUOQvuiZbWNdEdJIJKpkIVA);
		}
		OSCvYQcUOQvuiZbWNdEdJIJKpkIVA result = fjoNXICYKcrTqKaYkGWEyaaMHKRC(intPtr);
		UpfcjphXhVXuiFxUoxbbDaRqYrYD(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern JbFAywBYXfGhagDypdlSSUPUqzcGA UpfcjphXhVXuiFxUoxbbDaRqYrYD(IntPtr P_0);

	private static OSCvYQcUOQvuiZbWNdEdJIJKpkIVA fjoNXICYKcrTqKaYkGWEyaaMHKRC(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(OSCvYQcUOQvuiZbWNdEdJIJKpkIVA);
		}
		return new OSCvYQcUOQvuiZbWNdEdJIJKpkIVA
		{
			YhbSrcBvLKYkvwtEmujrCGXRIMnk = (Marshal.ReadByte(P_0, 0) > 0),
			dNNFPQXPaXHeDGsrUDuecxDXchVBb = (Marshal.ReadByte(P_0, 1) > 0),
			JfESkGrVwwKeEpkCqyLdaRKMvZYv = (Marshal.ReadByte(P_0, 2) > 0),
			UKyxGpnpXlEFAfWnwpqwtAfnEVFX = (uint)Marshal.ReadInt32(P_0, 4),
			slihCVirTqsCYwXZYVkJjqrNQdwf = (uint)Marshal.ReadInt32(P_0, 8),
			jSKGLkCAgNYFIVIQQhxyqndZjEVe = (Marshal.ReadByte(P_0, 12) > 0)
		};
	}
}
