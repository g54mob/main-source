using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class fHTWvRQigOspLqWwlUksTsmndmm
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void BdZxPtDVVWKEChCFiTIQulLrTroC(OJildwdrNjtgpyyrVCVypxbByVgb pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void iAZEMhiAuZOHlvZVsfqkdrgXcsCxA(OJildwdrNjtgpyyrVCVypxbByVgb pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void LGRJtWBSJCVUZGTTDtVubdrPhYvj(OJildwdrNjtgpyyrVCVypxbByVgb pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void ZwnoiieHKlWmYpmbPhERFPKCohsfA(OJildwdrNjtgpyyrVCVypxbByVgb pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void ZZHsMhCUaTQHLwdFOmtnZtWHuGPd(OJildwdrNjtgpyyrVCVypxbByVgb coreWindow, OJildwdrNjtgpyyrVCVypxbByVgb keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void odXbSmyuYxxMEVNqVLcXMVIcOlVI(OJildwdrNjtgpyyrVCVypxbByVgb coreDispatcher, OJildwdrNjtgpyyrVCVypxbByVgb acceleratorKeyEventArgs);

	public const string BLhxbgHtLYriNOcaMjTbavVvnWaLA = "Rewired_WindowsGamingInput";

	private const CallingConvention XRWxMsXForDDWjjYhSVNLjoNPunl = CallingConvention.StdCall;

	private const CallingConvention ornsCGjEIWtmkfUIrZuyzGuXfuoV = CallingConvention.StdCall;

	private const UnmanagedType EufZoaSKfnNTdVYmWDskOwIDtClx = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong dnwAeQIqwbpgqUARmZSDdJMdUHhZ(IntPtr P_0);

	public static ulong vlReXTtJAFxoBpGlhBGzUolzohib(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return dnwAeQIqwbpgqUARmZSDdJMdUHhZ(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong IrAIGwzkmqhlxCRwoncuowJIJrki(IntPtr P_0);

	public static ulong ZFeyDzTGKfKZZCTfnoTSXrmpkRXU(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return IrAIGwzkmqhlxCRwoncuowJIJrki(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool uZEfTPehrtJbnGoJlUIGGzgvEgFzA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr usWKeRWdtHAMDnUoFeZPOTIcrcvU();

	public static string QLpqyJdbFZIkksLwXTuwvflJJdYj()
	{
		IntPtr intPtr = usWKeRWdtHAMDnUoFeZPOTIcrcvU();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb YczEcRufZJhadbrTeBRzjDorWTotA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint PvOlwXqSAXffFmKoXAdMWUZgADDw(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb QwpntLUdHhoeXWknFzhAJFGZPUWe(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool btTAubiMuafOtFjfrNGhifJdYunAc(IntPtr P_0, ref dPRXSTAtGIjVCqYJlEOTHkKLkTfM P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool LHWYVbbeStnWBvPxdYpXFsZeAxci(IntPtr P_0, ref gXscSvKVwaCJjrRAEGEwVgIGOxHD P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void EGZXToRuEmqbptaoLityQSZkCAnM(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] gXscSvKVwaCJjrRAEGEwVgIGOxHD P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr RcxMDpzqtWfhZbiQrYRoorcUTdOWA(IntPtr P_0);

	public static IklKbBTFbxvSKNmnQJeNQydgjCod JDHedatpnyRbbMHwIeGTcvsKdhctA(IntPtr P_0)
	{
		IntPtr intPtr = RcxMDpzqtWfhZbiQrYRoorcUTdOWA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new IklKbBTFbxvSKNmnQJeNQydgjCod(new viEpNAHHRHFFfjbvgOVCPmMEQDNR(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool ffFDQdmUMajktOHJwpweytbgacur(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb RReGzYRGHOkeScsqWbxWywQjgHAu(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern IivVqoFMRnWpEFlHmKfYnZRaYJUF ikaxCsmvXyCnHzfIYJciYYTPrKmA(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void hNBfqTblkLdtSGpJANwSeHYUXvCg();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void QOlZsIWrwVuDoPMGyZFUmJBynWnA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void IvNFkxChWqrRgJTGEXPGWkuHMxsUA(BdZxPtDVVWKEChCFiTIQulLrTroC P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void fkFfMnJZCMQBCGCUhVKBfWnAcvpsA(iAZEMhiAuZOHlvZVsfqkdrgXcsCxA P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint mXqzfvacVicavgaYpPAtipsSeIUt(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb EqQMvhOaVVFNoAVLtLSCTRisbwNAb();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb jqZgxTOelEyIUnVdUSPMiwNkwaaJ(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong RYwPMSrnMqTmiOMOXCdHSxdgnowN(IntPtr P_0, bool[] P_1, uint P_2, udHFWZZzgAQSuVezUjzPJxungolV[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong StgYHYmGKZjjztRksfiMzLHEeLzg(IntPtr P_0, bool[] P_1, udHFWZZzgAQSuVezUjzPJxungolV[] P_2, double[] P_3)
	{
		return RYwPMSrnMqTmiOMOXCdHSxdgnowN(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool XNJXWhiiwIJcxSgrlUgSbXzNtUjo(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb MsSPLLdJCZwRZebWYEnAtXfGUcte(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint GYtrlHVHjsBZoFsXRJOVQrluvqNt(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb aIHYHAcnvBdZDAbkoHrPYKGaJofLA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int RkBfzDaWKRDrksBGmlSsUpHcnhLH(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int djvudpPxlVHCZcCBIjNhjAcEkxrCb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int JnzeVjZDtwVBMFpVxqZbATHLfXVK(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr APGvvsJNCGOZWhtUNsYuKJQfUEV(IntPtr P_0);

	public static string QXKcmdIjHeiHYOwabABMAvIgGDcKb(IntPtr P_0)
	{
		IntPtr intPtr = APGvvsJNCGOZWhtUNsYuKJQfUEV(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb XHmJtRXwVGHjkjjurRdmaJpwKAyA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint JsegUGZOoYwmGBCJHZvDpzcpkqOL(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern IivVqoFMRnWpEFlHmKfYnZRaYJUF XCptExKcJZzxckFNNcHdEhXZoljbA(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern DaIGKbbbUkAJBBPIcCadSzEwjQRfb bEZIDCWcWLBAmdqtxjUDGqnCAZmqA(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort ELabWhraSTUUzTRbMSaqALDWhaBQ(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort cZKaBvzswJnnaWpZXhLzByJvqYNj(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb TsZAHTbPErrdZGqvpDqNHCUTNPUeA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr dKIhDaffSEqFjojfNerJHLvkTMcjA(IntPtr P_0);

	public static string duHNHvkCqAkioOiDIPBIiwZfqaJy(IntPtr P_0)
	{
		IntPtr intPtr = dKIhDaffSEqFjojfNerJHLvkTMcjA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb dFNpsYpupsgxfzOAiieratmuSlGF(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool qgpumQBxUmkxOQoYlGhTZJEIfpQHA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern OJildwdrNjtgpyyrVCVypxbByVgb kXnkofnsFPQNDWAFuHaOaYLENOZA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void XIeDMbEKnXpeoezliWNtikYwcwHAB();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void fdUmxxeWHaPBRuKLmmkAEAYIadri();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void zalCbbwGlVBQrhuDanROVpWXhPXIA(LGRJtWBSJCVUZGTTDtVubdrPhYvj P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void jEBYpsktBDKZaqwwqmwGYzmDMWeq(ZwnoiieHKlWmYpmbPhERFPKCohsfA P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int FIxXGdjprtGBtHputGvAFrpRbxxm(IntPtr P_0);

	public static otBzvWNQZRZskyQmXfQTqiPrJXzE wLmMAMLaSMFDTCnyvMXVZfFKNcgNA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return otBzvWNQZRZskyQmXfQTqiPrJXzE.LocalUser;
		}
		return (otBzvWNQZRZskyQmXfQTqiPrJXzE)FIxXGdjprtGBtHputGvAFrpRbxxm(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr ImNDvfRysiRqtmzhtaWeBHUoptfc(IntPtr P_0);

	public static string uZiekCdqhHpLSGNaWgamhrHEjoxmB(IntPtr P_0)
	{
		IntPtr intPtr = ImNDvfRysiRqtmzhtaWeBHUoptfc(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern OJildwdrNjtgpyyrVCVypxbByVgb gsUFaZOKXPkWqhwavEqhwoukCspu();

	public static OJildwdrNjtgpyyrVCVypxbByVgb ngSArAJszIyFAqAaxCsnDIkYMMTpA()
	{
		return gsUFaZOKXPkWqhwavEqhwoukCspu();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr SchZwBFRIzRzLDNeIXvldEBRJBu(IntPtr P_0);

	public static xdDPCmXIuLuvQTdzXfASDMqkieFk FgTehuRhQLzniNeoqiEvcFXLqsvj(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = SchZwBFRIzRzLDNeIXvldEBRJBu(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new xdDPCmXIuLuvQTdzXfASDMqkieFk(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr yKGayNnftVVnuHytLLveosUSWQZy(IntPtr P_0);

	public static xdDPCmXIuLuvQTdzXfASDMqkieFk dhgHfANbtOrKlYDcgzhmyClbhleDA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = yKGayNnftVVnuHytLLveosUSWQZy(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new xdDPCmXIuLuvQTdzXfASDMqkieFk(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void uFHCxHYuLRbqfbFNTeBFnBoPZoCJA(IntPtr P_0, IntPtr P_1);

	public static void BMHNRDgSYRubrWgNKuggHzqPWmpX(IntPtr P_0, xdDPCmXIuLuvQTdzXfASDMqkieFk P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !trCAUUyMTJDMtqOOghTphagUoCJlA.BiuaHYTZipbbNwHCUMAIrOoBKqkJ(P_1, null))
		{
			uFHCxHYuLRbqfbFNTeBFnBoPZoCJA(P_0, P_1.QdUTNzZPdgWbShApevfibcvGGmji);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void ohkXWLDgaGTJLypNptIhJVlhIKVy(IntPtr P_0, IntPtr P_1);

	public static void aIaxnIPIjIFvqEoHcIfvgkCgsiKZ(IntPtr P_0, xdDPCmXIuLuvQTdzXfASDMqkieFk P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !trCAUUyMTJDMtqOOghTphagUoCJlA.BiuaHYTZipbbNwHCUMAIrOoBKqkJ(P_1, null))
		{
			ohkXWLDgaGTJLypNptIhJVlhIKVy(P_0, P_1.QdUTNzZPdgWbShApevfibcvGGmji);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void CpiFPHvpvBrPViVbsmGdAtITztmK(ZZHsMhCUaTQHLwdFOmtnZtWHuGPd P_0);

	public static void tKRIKjZMFeemeHFHqlSYjNTawtBy(ZZHsMhCUaTQHLwdFOmtnZtWHuGPd P_0)
	{
		CpiFPHvpvBrPViVbsmGdAtITztmK(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void mCMYFazvklnUOmjFOEyRgWpFQoLQA();

	public static void eOweFLEzQgtLIvtYZtgjPOKUGPwH()
	{
		mCMYFazvklnUOmjFOEyRgWpFQoLQA();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void wyrCAbIeTsBGzFxkbcEOLrIqhNOPB(ZZHsMhCUaTQHLwdFOmtnZtWHuGPd P_0);

	public static void QgGZqgsqpixiSskSddRkEzJZXkAI(ZZHsMhCUaTQHLwdFOmtnZtWHuGPd P_0)
	{
		wyrCAbIeTsBGzFxkbcEOLrIqhNOPB(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void OMcZzGRAMGHzRDmdlCpGXUyFPjVT();

	public static void imSqhcYephAJYcjumjsrEfufWYuWb()
	{
		OMcZzGRAMGHzRDmdlCpGXUyFPjVT();
	}

	public static VaNgyIRgyZBywRgpbyTzlISzwuYt hQaMLEXgglcMcKJkrmBXFrLUKhos(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(VaNgyIRgyZBywRgpbyTzlISzwuYt);
		}
		return new VaNgyIRgyZBywRgpbyTzlISzwuYt(plihJszOaNpYtJcdHKsQJrtjHDKn(P_0), qGpmPrvtxOLdDSoQPlliJhtNbtFx(P_0), slZnZOdhkMfSLoNTyXVvicchzGUJ(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool plihJszOaNpYtJcdHKsQJrtjHDKn(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern ulaGnQBwNjyqFHFYeiKFCBKJBoEBc slZnZOdhkMfSLoNTyXVvicchzGUJ(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr yTjjLXukHnlZnaVJNZmmXiadoHVI(IntPtr P_0);

	private static VnPJPXeUCsWeoGqTvauvAnhnezL qGpmPrvtxOLdDSoQPlliJhtNbtFx(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(VnPJPXeUCsWeoGqTvauvAnhnezL);
		}
		IntPtr intPtr = yTjjLXukHnlZnaVJNZmmXiadoHVI(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(VnPJPXeUCsWeoGqTvauvAnhnezL);
		}
		VnPJPXeUCsWeoGqTvauvAnhnezL result = kBJAYMCpekFlRwpecvnFbJObGEiIb(intPtr);
		NhUUxuYcbZnXykWrwSQieICBwBzT(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern OJildwdrNjtgpyyrVCVypxbByVgb OxgjDkxnyMFDrbTlrLCkwkRenHujb();

	public static OJildwdrNjtgpyyrVCVypxbByVgb gAEEReedKhsCPIyymBWaEleALxSk()
	{
		return OxgjDkxnyMFDrbTlrLCkwkRenHujb();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr EmLGnUfmFojhPBcPAVlxVbjSBuRDA(IntPtr P_0);

	public static xdDPCmXIuLuvQTdzXfASDMqkieFk HpJQIcZoTnwbJlnIPqsPNUDlPDgB(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = EmLGnUfmFojhPBcPAVlxVbjSBuRDA(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new xdDPCmXIuLuvQTdzXfASDMqkieFk(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void FyAxUacBHcVCSnOJIueYeteBzGRI(IntPtr P_0, IntPtr P_1);

	public static void CEnDvBOEyuwXQrEFeQQiucRnWNlC(IntPtr P_0, xdDPCmXIuLuvQTdzXfASDMqkieFk P_1)
	{
		if (!trCAUUyMTJDMtqOOghTphagUoCJlA.BiuaHYTZipbbNwHCUMAIrOoBKqkJ(P_1, null))
		{
			FyAxUacBHcVCSnOJIueYeteBzGRI(P_0, P_1.QdUTNzZPdgWbShApevfibcvGGmji);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void OpjutIFgaolpebaZdLolnpGaDlrf(odXbSmyuYxxMEVNqVLcXMVIcOlVI P_0);

	public static void zFydPhLtYeztOuilNQsovswOIqOC(odXbSmyuYxxMEVNqVLcXMVIcOlVI P_0)
	{
		OpjutIFgaolpebaZdLolnpGaDlrf(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void hqWeOQkwhrlwMKueXgccEhyOYptuA();

	public static void aTPREsrKjuiDLynekdGHVlzoGoII()
	{
		hqWeOQkwhrlwMKueXgccEhyOYptuA();
	}

	public static mkGLczOqHMbPkxLRAbMTMPkbdLukA DNHDtnavbNoYMvHTBKujAdsczqHMB(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(mkGLczOqHMbPkxLRAbMTMPkbdLukA);
		}
		return new mkGLczOqHMbPkxLRAbMTMPkbdLukA(iEkEcKWSxqXlpVArcOecRCTeckfe(P_0), aCCFPfhhoLPzhHvPodviTdUaSOIz(P_0), qxKdKCeatLDoMRcTsTqSbokLpDjvA(P_0), PyXAVDvjMDUajZyxuBCAFeoXGQhs(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern sAndUzfqgXjfJpZWZbdFtZttdIWwA iEkEcKWSxqXlpVArcOecRCTeckfe(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool aCCFPfhhoLPzhHvPodviTdUaSOIz(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern ulaGnQBwNjyqFHFYeiKFCBKJBoEBc PyXAVDvjMDUajZyxuBCAFeoXGQhs(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr HRxNoaqImDOOWntlDAdNhckCPAGA(IntPtr P_0);

	private static VnPJPXeUCsWeoGqTvauvAnhnezL qxKdKCeatLDoMRcTsTqSbokLpDjvA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(VnPJPXeUCsWeoGqTvauvAnhnezL);
		}
		IntPtr intPtr = HRxNoaqImDOOWntlDAdNhckCPAGA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(VnPJPXeUCsWeoGqTvauvAnhnezL);
		}
		VnPJPXeUCsWeoGqTvauvAnhnezL result = kBJAYMCpekFlRwpecvnFbJObGEiIb(intPtr);
		NhUUxuYcbZnXykWrwSQieICBwBzT(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern OJildwdrNjtgpyyrVCVypxbByVgb NhUUxuYcbZnXykWrwSQieICBwBzT(IntPtr P_0);

	private static VnPJPXeUCsWeoGqTvauvAnhnezL kBJAYMCpekFlRwpecvnFbJObGEiIb(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(VnPJPXeUCsWeoGqTvauvAnhnezL);
		}
		return new VnPJPXeUCsWeoGqTvauvAnhnezL
		{
			DUOjJxkfzWBEvJDYeoJiTrlgXZKCA = (Marshal.ReadByte(P_0, 0) > 0),
			aaoItRaPMXsvNzhpQJNnGyncgHqK = (Marshal.ReadByte(P_0, 1) > 0),
			OPpxJqOEGawkQQKnwybuDsllQzbd = (Marshal.ReadByte(P_0, 2) > 0),
			XaPnckYMnrcGWJMzozArqKZOHKohb = (uint)Marshal.ReadInt32(P_0, 4),
			xyLhwIFMtyKgOXgPOooAIKQyABPfA = (uint)Marshal.ReadInt32(P_0, 8),
			mLtsDMhdsJoMKyIGWzSvXVRqCiwR = (Marshal.ReadByte(P_0, 12) > 0)
		};
	}
}
