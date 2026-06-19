using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class CujeeBcirxyINwnVbhnsGACTyjMg
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void uHxUmnoGMXemiQrLbJSIAlPSQWIi(rUAEJXUFemXNKVczqbGZBRDYPlhV pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void BhdTrXjRpAObVicSxXwcLNYwjpsl(rUAEJXUFemXNKVczqbGZBRDYPlhV pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void aOpumgiICBCxxbvMMgbePTBymcLX(rUAEJXUFemXNKVczqbGZBRDYPlhV pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void qHZFHEJQVgJCqKxuGIIBnpqfDiOo(rUAEJXUFemXNKVczqbGZBRDYPlhV pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void cRdDOclJvEuFnFkPNwsrnDwqvNrC(rUAEJXUFemXNKVczqbGZBRDYPlhV coreWindow, rUAEJXUFemXNKVczqbGZBRDYPlhV keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void RrzMLMTHZcdNwgxlEnJNyAeFTVfO(rUAEJXUFemXNKVczqbGZBRDYPlhV coreDispatcher, rUAEJXUFemXNKVczqbGZBRDYPlhV acceleratorKeyEventArgs);

	public const string gCTHQWCsSJxOdvfrPjDfbJfCLHWab = "Rewired_WindowsGamingInput";

	private const CallingConvention iCyKTGqvjulNoKUDkYJTtbIsJIZo = CallingConvention.StdCall;

	private const CallingConvention FaVGfkMTHZCOMMWRkjVuDiIuZbQv = CallingConvention.StdCall;

	private const UnmanagedType jAXCLAhfyqAdLYmrXmceHwqwyFFSA = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong AuGvZyFSbcOAIfcKdDCBbWqSYIZr(IntPtr P_0);

	public static ulong GudFQxICmIPjYGDRoNmYsaIYkvBR(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return AuGvZyFSbcOAIfcKdDCBbWqSYIZr(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong xdqBpSOWdvfJNbmrdnhkCdfdSQCu(IntPtr P_0);

	public static ulong wOEBLDwHLibxvtFcuGHWbWAGcEbw(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return xdqBpSOWdvfJNbmrdnhkCdfdSQCu(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool TOkwcrYyokTNXNjCeYCILPQAZfxS();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr BWujIvjCcUjofAXzIBPJqbcTbvHgA();

	public static string fjDdXhOkKYFwYJqjCqDwPIJieSsS()
	{
		IntPtr intPtr = BWujIvjCcUjofAXzIBPJqbcTbvHgA();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV rRTjhlNjOCAYLMiKlRVhduKGvCUT();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint uckJZdLiJIEHrHepIUxQqanPUWzU(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV fOTSBpfoSuCgtzpiYbEEjcpwWRmG(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool UHbPaHTurpsqZAAeqOQrPvjrjjTh(IntPtr P_0, ref UEhDjvAzZPVreaJMknILCleqWCHcA P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool uSoAdZExXyADbKcaaDSBexbBJRUNA(IntPtr P_0, ref PnWZbRpKCvwNHCKoFStsrOitTtdC P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void roxeoOaiPnbKTColEnhscaxBrBHs(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] PnWZbRpKCvwNHCKoFStsrOitTtdC P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr cjBOkTOOiXzZbZiTufFoTtApbooS(IntPtr P_0);

	public static toQbnLcFOcNhsiEfXAPyajAJbuSgA wArrEEGeevQZBjSdXpQBLJWbBeMW(IntPtr P_0)
	{
		IntPtr intPtr = cjBOkTOOiXzZbZiTufFoTtApbooS(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new toQbnLcFOcNhsiEfXAPyajAJbuSgA(new GtkUkygTUOvyDIbobZpOxuepAbdi(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool UYxOjRBRXzIlNbhGbisyYzRNGlMn(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV sLUmWakuGNOrgDypBdUWOScIQSkF(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern bZNByWiTGyDoqqcSvUWABUjTkHyO TBMUncHKmCkRFCQkBDWciPqgcuoh(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void YUtbCvSIfOCRyvPCPgHGSayzROmT();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void rZagHErmxnCXrmXoDFRJIjrwqqeD();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void zYruVJMhRvmjUeBFPCTQeWUqmqCOA(uHxUmnoGMXemiQrLbJSIAlPSQWIi P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void SqnTrBgdXFAloKnFiVIDIiHpMoRJA(BhdTrXjRpAObVicSxXwcLNYwjpsl P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint JrWEaJRaSvfCDDrPosYnUwOtcJkN(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV liujSRzNKMXzIeXKqEASlTKJNlfM();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV CftdLtrBeNYGiACmTeICcGjVnfOgb(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong cMIHleAbRjXOItBJKuvBkfZHfhIdA(IntPtr P_0, bool[] P_1, uint P_2, VAdrvvalxDcgQyreDizNfoSKWbLX[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong zUbViLxDIRsXKPvtrUIPgfhzPTL(IntPtr P_0, bool[] P_1, VAdrvvalxDcgQyreDizNfoSKWbLX[] P_2, double[] P_3)
	{
		return cMIHleAbRjXOItBJKuvBkfZHfhIdA(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool qGzddJgJdPgUTzxioyoMiLZevFPCA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV lgmsPdYYOOGchTkoRIFjZmxlNpHj(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint jPPEevqGmjixEwPEEwINilXHYjlX(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV TSlawmHDcCAzvnQnlpnJamiKTvTwb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int eExAYpVBFAifCCDZjinonabZZqftA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int KXTdCNyQcQAkrIZOBVXfFcElAqHfb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int aKNRsBiRibjpwuvCkCPlcirerkfSA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr hRlShZDWmJaexxhmLqIWMUlpTZiG(IntPtr P_0);

	public static string xIsTRJSWWjjbsPoxicTMLvcrkCYr(IntPtr P_0)
	{
		IntPtr intPtr = hRlShZDWmJaexxhmLqIWMUlpTZiG(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV odGiCLoHpJzqHUmogFJtKEbKHaik(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint wwABmyuZzZQUkqOVUDaNROnAnMme(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern bZNByWiTGyDoqqcSvUWABUjTkHyO giTHxNzQUItNQTJYANHlRuvedaXP(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern gHutvJErDhBnxinRJDelVHaBGBdGA OTrmugttHOQeGLieexAROZBtSWCU(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort vwEtzDQuPWqNJmziJsWaqHxxhWrG(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort NUooUTSzxKBAIjGIUjKtxEhKfhvv(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV cIdazrOeRgDJxlnewucNemosKuoH(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr AAwueICPXLCvPXnqAPfPdvNHUXYR(IntPtr P_0);

	public static string IbhkaRZdbPGrIbHANiXMMbtGBndHA(IntPtr P_0)
	{
		IntPtr intPtr = AAwueICPXLCvPXnqAPfPdvNHUXYR(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV MOlGmaOiibdSBCcZjuejCMWPiBkW(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool TbHFNoemBveBqDxBGkhDdzemloiNc(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern rUAEJXUFemXNKVczqbGZBRDYPlhV RepPlOKfnIqfbdWFWNrgCkmcGral(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void uEIalVGriSwSKgQkRFLzAImENrdFc();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void GyqABNZVLlstlPkOjvqOoqahGlVr();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void WuVEVLJaeAoyBHpKhLFMTHosiYtR(aOpumgiICBCxxbvMMgbePTBymcLX P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void UwbaEUATISWvOFHnfPuKceOFgTEiB(qHZFHEJQVgJCqKxuGIIBnpqfDiOo P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int oSZBnVaSiajfLAubBsvIwtBCucHyB(IntPtr P_0);

	public static LOvUwqweMWahSZIrWwjDIytEsAPx NRMgtkopLRMdvYNrmcNFBOdzcvQn(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return LOvUwqweMWahSZIrWwjDIytEsAPx.LocalUser;
		}
		return (LOvUwqweMWahSZIrWwjDIytEsAPx)oSZBnVaSiajfLAubBsvIwtBCucHyB(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr xsjkUBgJhnjnQNYgekMItWdFqWLf(IntPtr P_0);

	public static string ZhWtVgHhcKspcinbRzqyPMlYTbPo(IntPtr P_0)
	{
		IntPtr intPtr = xsjkUBgJhnjnQNYgekMItWdFqWLf(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern rUAEJXUFemXNKVczqbGZBRDYPlhV DFgQTdpEMUUuGYTrsEijEEAZthXu();

	public static rUAEJXUFemXNKVczqbGZBRDYPlhV CcuIIqoEgBihoBIryCqnJeWrOVxaA()
	{
		return DFgQTdpEMUUuGYTrsEijEEAZthXu();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr jQOefEmKCVFNPwAElLQvFYiuAzji(IntPtr P_0);

	public static EibcJUwdzESOuksQEfrApYBTnwzd wlxBoGkiyEVvUelOtahdSzowlGBe(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = jQOefEmKCVFNPwAElLQvFYiuAzji(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new EibcJUwdzESOuksQEfrApYBTnwzd(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr PVewZpCLmSkPUeMsWfreEEenoTvdb(IntPtr P_0);

	public static EibcJUwdzESOuksQEfrApYBTnwzd QeWsCaoQuNNuVnGlxIpiGAXYhkEJA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = PVewZpCLmSkPUeMsWfreEEenoTvdb(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new EibcJUwdzESOuksQEfrApYBTnwzd(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void NojYAxvhCMgINsRSKZwXvaAkGzmr(IntPtr P_0, IntPtr P_1);

	public static void cYpkohJeNIyRJzRMZaqanFQmxnRt(IntPtr P_0, EibcJUwdzESOuksQEfrApYBTnwzd P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !SJqfYgHdWEqERVLNrJIhUARlTAxF.kdGZeSoUvyDzCFLjBWEQVACsHaIg(P_1, null))
		{
			NojYAxvhCMgINsRSKZwXvaAkGzmr(P_0, P_1.luwkDSgKmtkkJGTIhfGeRJflBENf);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void FuGbnzCufJlvlLDYmfAfdxTDQXvyB(IntPtr P_0, IntPtr P_1);

	public static void FsGWjqqscPTmSzpErrqlAhgVjouh(IntPtr P_0, EibcJUwdzESOuksQEfrApYBTnwzd P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !SJqfYgHdWEqERVLNrJIhUARlTAxF.kdGZeSoUvyDzCFLjBWEQVACsHaIg(P_1, null))
		{
			FuGbnzCufJlvlLDYmfAfdxTDQXvyB(P_0, P_1.luwkDSgKmtkkJGTIhfGeRJflBENf);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void hIArmrAauGBplJTcfhElqemsdyIXA(cRdDOclJvEuFnFkPNwsrnDwqvNrC P_0);

	public static void KghOtNcoMtEKWeoQvIUIZJtFtsxS(cRdDOclJvEuFnFkPNwsrnDwqvNrC P_0)
	{
		hIArmrAauGBplJTcfhElqemsdyIXA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void BymauODCjcpewgNWPtgRgiLIoflEc();

	public static void HGYHbhryJbXTyIoJAdInzuknPWGF()
	{
		BymauODCjcpewgNWPtgRgiLIoflEc();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void RiZulNBhAxYoRYhhliWSAJwOPGgFb(cRdDOclJvEuFnFkPNwsrnDwqvNrC P_0);

	public static void lrquEoNvcfJmDFBvupcgcrgwQEaC(cRdDOclJvEuFnFkPNwsrnDwqvNrC P_0)
	{
		RiZulNBhAxYoRYhhliWSAJwOPGgFb(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void piYCUgwxFXZJpwnwaRzAzcIgfaxjA();

	public static void VEuhYKfrosRbiUNthbozBxAjMPEM()
	{
		piYCUgwxFXZJpwnwaRzAzcIgfaxjA();
	}

	public static iGxsZsyklWeKQcFsgtVhRrsMtvgX YDEzUmyPneqDEripwhZBnzndmtGk(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(iGxsZsyklWeKQcFsgtVhRrsMtvgX);
		}
		return new iGxsZsyklWeKQcFsgtVhRrsMtvgX(EaWukIUBfUtiFgYaOdgUtWZSIkok(P_0), PBHERHMvsZDlddaDQybgfyDiusvr(P_0), JqlACeWgbXbDdfDGjRVxdYCUziss(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool EaWukIUBfUtiFgYaOdgUtWZSIkok(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern TpMtWuTaMwSQpcnHjTGZrneoAvwhA JqlACeWgbXbDdfDGjRVxdYCUziss(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr HGDCpxVySwVuBHcQGHkofYQMzihm(IntPtr P_0);

	private static wwJyblyFvXIiCJZVStmyDfFYehDj PBHERHMvsZDlddaDQybgfyDiusvr(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(wwJyblyFvXIiCJZVStmyDfFYehDj);
		}
		IntPtr intPtr = HGDCpxVySwVuBHcQGHkofYQMzihm(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(wwJyblyFvXIiCJZVStmyDfFYehDj);
		}
		wwJyblyFvXIiCJZVStmyDfFYehDj result = HmberaCIjbgHhFWpxFvHYveCqHURA(intPtr);
		aNmgMYczcUglAfVehvCeWSkgWSDhA(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern rUAEJXUFemXNKVczqbGZBRDYPlhV pNCPkGMLpHzdRgSkkEQoIhrBoMYs();

	public static rUAEJXUFemXNKVczqbGZBRDYPlhV DhicQEXSHgmLrpWrtCjisREbENaK()
	{
		return pNCPkGMLpHzdRgSkkEQoIhrBoMYs();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr fZhsUaONErAFhcNIRjvlpYXlzkxi(IntPtr P_0);

	public static EibcJUwdzESOuksQEfrApYBTnwzd qjjjwekxXcYSZOstOwAynqjKGcpd(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = fZhsUaONErAFhcNIRjvlpYXlzkxi(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new EibcJUwdzESOuksQEfrApYBTnwzd(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void qGeIQAHERzngqEGHRuKSKOmacvHB(IntPtr P_0, IntPtr P_1);

	public static void pTMwnexhlUWcCoDvyCeOUKWRwTK(IntPtr P_0, EibcJUwdzESOuksQEfrApYBTnwzd P_1)
	{
		if (!SJqfYgHdWEqERVLNrJIhUARlTAxF.kdGZeSoUvyDzCFLjBWEQVACsHaIg(P_1, null))
		{
			qGeIQAHERzngqEGHRuKSKOmacvHB(P_0, P_1.luwkDSgKmtkkJGTIhfGeRJflBENf);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void hHCReYmdlEVSWIUoyHrMJqNDKXHb(RrzMLMTHZcdNwgxlEnJNyAeFTVfO P_0);

	public static void SRAIFPwifxHuhLpBQChuTGJdPBmd(RrzMLMTHZcdNwgxlEnJNyAeFTVfO P_0)
	{
		hHCReYmdlEVSWIUoyHrMJqNDKXHb(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void QywXteDFskEGsEpfEagqnFSxGaLgb();

	public static void HleJMOfkdhWpJbxnszHfpLJcBiO()
	{
		QywXteDFskEGsEpfEagqnFSxGaLgb();
	}

	public static NToiBLvAITTzWQfQNUKTiMAKOMAt uApaKBaKmGXeydqKGAshxXAMMjjaA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(NToiBLvAITTzWQfQNUKTiMAKOMAt);
		}
		return new NToiBLvAITTzWQfQNUKTiMAKOMAt(DMMhVqlPkvdrLcTSxAaehheHnIXL(P_0), JfkuoTQitIaXZeEMtVnogHwRGHeoA(P_0), NJmulqRtoImCoFEEfHuYWXIqZOFs(P_0), gQrCntIqDOamTAaghWPInnQkTFLvA(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern LuPzfBVExGfXnwJFWapTHlBILLiFA DMMhVqlPkvdrLcTSxAaehheHnIXL(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool JfkuoTQitIaXZeEMtVnogHwRGHeoA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern TpMtWuTaMwSQpcnHjTGZrneoAvwhA gQrCntIqDOamTAaghWPInnQkTFLvA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr uhzuOYLDDreocduewYhjxSIXYdaK(IntPtr P_0);

	private static wwJyblyFvXIiCJZVStmyDfFYehDj NJmulqRtoImCoFEEfHuYWXIqZOFs(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(wwJyblyFvXIiCJZVStmyDfFYehDj);
		}
		IntPtr intPtr = uhzuOYLDDreocduewYhjxSIXYdaK(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(wwJyblyFvXIiCJZVStmyDfFYehDj);
		}
		wwJyblyFvXIiCJZVStmyDfFYehDj result = HmberaCIjbgHhFWpxFvHYveCqHURA(intPtr);
		aNmgMYczcUglAfVehvCeWSkgWSDhA(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern rUAEJXUFemXNKVczqbGZBRDYPlhV aNmgMYczcUglAfVehvCeWSkgWSDhA(IntPtr P_0);

	private static wwJyblyFvXIiCJZVStmyDfFYehDj HmberaCIjbgHhFWpxFvHYveCqHURA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(wwJyblyFvXIiCJZVStmyDfFYehDj);
		}
		return new wwJyblyFvXIiCJZVStmyDfFYehDj
		{
			grkPaBDjgBdcVGmFtzZogTZXRYmy = (Marshal.ReadByte(P_0, 0) > 0),
			PuQvmlNAZEfMtUmcDMBzqZLRnxAM = (Marshal.ReadByte(P_0, 1) > 0),
			jILAPlrRJtYAkjjZpolwrNGIFvHF = (Marshal.ReadByte(P_0, 2) > 0),
			gKjoLGlmombeoGxkxMGzmwltOVQQA = (uint)Marshal.ReadInt32(P_0, 4),
			IgbnFcgymduWoyRMTGyImRaHtKlo = (uint)Marshal.ReadInt32(P_0, 8),
			HVLDciaGlWCyisTHZgQnzhhDofYlA = (Marshal.ReadByte(P_0, 12) > 0)
		};
	}
}
