using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

internal static class lgYKhAZykBItMBLqoSTMmewCDmYI
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void NFMawoDsLxRKftFkiIwwenpXxxWs(AMdAgCritGErRioCrkbrBpbFGYbUA pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void wXUGZCGZkedRKRnbunFYxPqjRAao(AMdAgCritGErRioCrkbrBpbFGYbUA pGamepad);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void XfWINpVdLnDWyYcvZSUIlNzdNTNI(AMdAgCritGErRioCrkbrBpbFGYbUA pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void TLisZQGaNqKUOJxlkiSuribSIJGAA(AMdAgCritGErRioCrkbrBpbFGYbUA pRawGameController);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void RcCCzdKrGwuCcatRAbHDcBlxUMznA(AMdAgCritGErRioCrkbrBpbFGYbUA coreWindow, AMdAgCritGErRioCrkbrBpbFGYbUA keyEventArgs);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void kCMioJgbUOnZtVIOVuAzOmOScRpG(AMdAgCritGErRioCrkbrBpbFGYbUA coreDispatcher, AMdAgCritGErRioCrkbrBpbFGYbUA acceleratorKeyEventArgs);

	public const string ZyaYGUOmvDeWLnuhWSSkrDEgobtK = "Rewired_WindowsGamingInput";

	private const CallingConvention xGuaYlWEFUiTYfxWybNdoQaxZcXtA = CallingConvention.StdCall;

	private const CallingConvention EgMoKrekbeeZSHMdEyMadbQpKRTnA = CallingConvention.StdCall;

	private const UnmanagedType apkYXHgCSRiFSWRQvEEqSCYpLkPb = UnmanagedType.LPWStr;

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong NzZGNKERMOkbTyROsMCSbaafzSHlA(IntPtr P_0);

	public static ulong IHzBOdMalmXDaoDeeDFutVrkTlGn(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return NzZGNKERMOkbTyROsMCSbaafzSHlA(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong JdRcDNpGWKOIhRMYODqXiRYkmgZEb(IntPtr P_0);

	public static ulong HVcDLVGFWXyxfpzJCsIWPTHjTWvt(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0uL;
		}
		return JdRcDNpGWKOIhRMYODqXiRYkmgZEb(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool pNYeNieUNOhItxyALWuQlBuWV();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr AVGFKQhBMGGIUABEhQFxRexNUUNyB();

	public static string FXtGaTCTXeieRFXbmeltMoWDmPHBb()
	{
		IntPtr intPtr = AVGFKQhBMGGIUABEhQFxRexNUUNyB();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA uJSkqLlWgEdsJzGCkcMoFWqImlSkA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint HSifnkdgfdEUCWNhOjMJGPCASopxB(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA SjaQIexMNlrIusAcyLFXkABzoQsK(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool VLgsQEwJWlSgIheUzRzidjzjAqvI(IntPtr P_0, ref dpAQVaQJEhyBbqThhjtzRWIlvUBi P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool nsphlCNVqDLjZHuPttjRAmJnHDPm(IntPtr P_0, ref qYblfIKWTJCcUzwzMzhWLaymennH P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void ZhslrFzOuIYGgAsgLFMZWgbfTJOe(IntPtr P_0, [In][MarshalAs(UnmanagedType.Struct)] qYblfIKWTJCcUzwzMzhWLaymennH P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr kYWDcdELEAsMoIXalrNSnghMaRhAA(IntPtr P_0);

	public static OzvDnQBYVAzLbLfUSCkAUfuCGZGDA bEvEMOiTjudxUldixomBrbvXkQWr(IntPtr P_0)
	{
		IntPtr intPtr = kYWDcdELEAsMoIXalrNSnghMaRhAA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new OzvDnQBYVAzLbLfUSCkAUfuCGZGDA(new fTdetHoZcdRUbkTwkogFXUoufns(intPtr));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool RYdhDcvkJTEAzsFHjFhHguLuiRrr(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA saLeOXrgHeYzIbTrFeYJMkQxBeDu(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern YHqADBLGDCYoxXPfupjajPHIynwH JFQsJBqNUCmmbLhtoMsNgOKSkRGu(IntPtr P_0, GamepadButtons P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void KedGUEuewCqoMtQFzXenaRGcOrvd();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void GTaItrOtdWBCkNQEAKArGmxWMPDK();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void DmEOHuGMnigKcujzwHqLqkmfVEvr(NFMawoDsLxRKftFkiIwwenpXxxWs P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void iOqnjSNQyRuZggmycSfEvcfUHgPIA(wXUGZCGZkedRKRnbunFYxPqjRAao P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint HdzHLwkBhyTTzqBabHgoSnTogdAf(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA vyAhFPArtVLvhSCSWQcxotXQlmsRA();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA glxgbicpNyPdUGcuFVwxqFDjqrEVB(IntPtr P_0, uint P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong TycDRPvuEgQyXDmrFBxLdRjONUxL(IntPtr P_0, bool[] P_1, uint P_2, iFMbJgTvcxCYHZwTECCfbViNcIJTA[] P_3, uint P_4, double[] P_5, uint P_6);

	public static ulong HkGxDniTrWBswoXgfNykWVgmaboi(IntPtr P_0, bool[] P_1, iFMbJgTvcxCYHZwTECCfbViNcIJTA[] P_2, double[] P_3)
	{
		return TycDRPvuEgQyXDmrFBxLdRjONUxL(P_0, P_1, (uint)P_1.Length, P_2, (uint)P_2.Length, P_3, (uint)P_3.Length);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool LpsyUAcUAAorWUmekBxLgKutdItN(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA HNLzmdRiyJvWAwtJDyHWGdIxGIKe(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint IxGZwpKgojIWpMymlBxthvZwYWSD(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA bNoQTrPSSyGqIycSoXYKoCCivjaB(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int zsCgkpRWBLlnLItlgmIztGPuGdxJA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int CCfhZHHoVKdEKANkTVoqwjmnSQLUA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int gZXrpfXgCeNQvYUFIPhytfmxsfHL(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr BWlZMSJSOZTYvpSYbzUHMdmgBDfj(IntPtr P_0);

	public static string VebPYmMDXlfjgtQVIBEAxdDIqKcf(IntPtr P_0)
	{
		IntPtr intPtr = BWlZMSJSOZTYvpSYbzUHMdmgBDfj(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA dzATNKnZsLvHbxLcUwMdLGPYAyVk(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint sfNMhjYeiTPtKXXfPIpeSkyRgEug(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern YHqADBLGDCYoxXPfupjajPHIynwH zmbqmkPbEualqmqRZWjuAMClbGaO(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern RxJHVQfXGVOXuLHgGjXNtpYSmuvT VeTMYkSNsYeLVmahJdSmaWxDevYh(IntPtr P_0, int P_1);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort NjtKlzmjWSgQXYMQrMBCLAyuEqIv(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort jyRjKFNZxQJcVCxdIKCgHCuheACz(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA BdhNmGDZuBnnZuWVKuAQxicAEUFcA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr GhoeCNcXJSwSXEbdPRxyYwMNKqwd(IntPtr P_0);

	public static string BiQZNjYRMddyzmvDMOcJFWBqobTC(IntPtr P_0)
	{
		IntPtr intPtr = GhoeCNcXJSwSXEbdPRxyYwMNKqwd(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA zubFOrOtLfoccxhVLBAQleBNaIMFA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool ViYDWUSduMcnbIEzNXrwUthflQuAb(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern AMdAgCritGErRioCrkbrBpbFGYbUA naFiVXCTBWCvzPKDuqRrnIMlfQKyA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void menDQuiarSieYAxsIQpZLhGiNIjf();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void fRsJHBxdUgkUCAAPkVNERyHIPiDG();

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void UVgNAfQbvvBPfbmGRtyPENqtzSYd(XfWINpVdLnDWyYcvZSUIlNzdNTNI P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void pnuWXNBDWIevLdYDUyqEUSxyuhjwA(TLisZQGaNqKUOJxlkiSuribSIJGAA P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int tBJJmequphaXlqeoGQbMagEAAgxJ(IntPtr P_0);

	public static kSIqNtVaVcTkBgcOXURravDFlSPF dnADfuDOLdmqgCwactEhwsLiMRPDB(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return kSIqNtVaVcTkBgcOXURravDFlSPF.LocalUser;
		}
		return (kSIqNtVaVcTkBgcOXURravDFlSPF)tBJJmequphaXlqeoGQbMagEAAgxJ(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr owSDPaFXxeOaKperJuEYSLxierzTA(IntPtr P_0);

	public static string WoUQkmvkVdXvnzwIgpIIwTJMZAz(IntPtr P_0)
	{
		IntPtr intPtr = owSDPaFXxeOaKperJuEYSLxierzTA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern AMdAgCritGErRioCrkbrBpbFGYbUA ohoBsmmJXpiDEDQgqcLolmFWSYCD();

	public static AMdAgCritGErRioCrkbrBpbFGYbUA BdtZQDQqYXWRZotCTafUgNhaXQVw()
	{
		return ohoBsmmJXpiDEDQgqcLolmFWSYCD();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr KDQmwCGrqfbdyIpnwjPfrmFCEjFf(IntPtr P_0);

	public static feOGhFVRyyeDfXjTZISmHSuGQQrW ayUhudGroFLERfMXIavUgVsacKQK(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = KDQmwCGrqfbdyIpnwjPfrmFCEjFf(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new feOGhFVRyyeDfXjTZISmHSuGQQrW(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr DdZbvrCgTPqOwfWOoGgLmaAoJyJCb(IntPtr P_0);

	public static feOGhFVRyyeDfXjTZISmHSuGQQrW weADtbKuuKmNkCLeYHzkXAlEmrQlA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return null;
		}
		try
		{
			IntPtr intPtr = DdZbvrCgTPqOwfWOoGgLmaAoJyJCb(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new feOGhFVRyyeDfXjTZISmHSuGQQrW(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void VcmPZqjeZJeSUCYREdgPeuwHFGhmc(IntPtr P_0, IntPtr P_1);

	public static void IdZrkzjhdLBjHEoRJPqgFzWwSoyU(IntPtr P_0, feOGhFVRyyeDfXjTZISmHSuGQQrW P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !pOJFnGeJdiWQwmkAgmdJyuYyiIhd.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_1, null))
		{
			VcmPZqjeZJeSUCYREdgPeuwHFGhmc(P_0, P_1.eRuooOpUXUMNyxAVfhJQXVsDGDql);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void fMJDndEMCVKxYSEMtvtCEqfhJah(IntPtr P_0, IntPtr P_1);

	public static void RiVBzwhQzDEkgiEAXwxtuEixCeGuA(IntPtr P_0, feOGhFVRyyeDfXjTZISmHSuGQQrW P_1)
	{
		if (!(P_0 == IntPtr.Zero) && !pOJFnGeJdiWQwmkAgmdJyuYyiIhd.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_1, null))
		{
			fMJDndEMCVKxYSEMtvtCEqfhJah(P_0, P_1.eRuooOpUXUMNyxAVfhJQXVsDGDql);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void MaAbJNZNbTnwZFqhsloKnqokCdqx(RcCCzdKrGwuCcatRAbHDcBlxUMznA P_0);

	public static void LOOYjGaFpKqpVThDcckJiKBQgkszA(RcCCzdKrGwuCcatRAbHDcBlxUMznA P_0)
	{
		MaAbJNZNbTnwZFqhsloKnqokCdqx(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void jtSbqbKdGUosXrpSoSzvFORgDAAgb();

	public static void qGdDVBDBFXSgXvlYzXhNvrAbBFEy()
	{
		jtSbqbKdGUosXrpSoSzvFORgDAAgb();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void rvjRrqxAnUanAkCNOmJzDdPQOEDn(RcCCzdKrGwuCcatRAbHDcBlxUMznA P_0);

	public static void vBNpehxkAraojLhbOeNyTDDpEQjaA(RcCCzdKrGwuCcatRAbHDcBlxUMznA P_0)
	{
		rvjRrqxAnUanAkCNOmJzDdPQOEDn(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void oEMedFCKEpMysmPbyAwndBefHvDLB();

	public static void akuUVBOAxgBPAuOFrwFVnPbtFUXr()
	{
		oEMedFCKEpMysmPbyAwndBefHvDLB();
	}

	public static LyAizdVZkmsuVLCJfSyHnxOTNSyS lxAbqjeRGGYRUEuTBnbMQeaMlIOW(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(LyAizdVZkmsuVLCJfSyHnxOTNSyS);
		}
		return new LyAizdVZkmsuVLCJfSyHnxOTNSyS(QSwUZNdfVDcwMKWrbMbxZDXPnzXP(P_0), blLGMzkeWNxRqSfMvkPOZgNwonfcA(P_0), mRnuaOthUKcBtBIepTnLAYnWCCV(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool QSwUZNdfVDcwMKWrbMbxZDXPnzXP(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern sjpkkfoQTAUasVTmkudxZsAfvAyv mRnuaOthUKcBtBIepTnLAYnWCCV(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr fPofUzGnhTFNwcHnyItKbUxeZCmgA(IntPtr P_0);

	private static ZDyGkqTYobwsTeBoXbUQxthJjVVx blLGMzkeWNxRqSfMvkPOZgNwonfcA(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(ZDyGkqTYobwsTeBoXbUQxthJjVVx);
		}
		IntPtr intPtr = fPofUzGnhTFNwcHnyItKbUxeZCmgA(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(ZDyGkqTYobwsTeBoXbUQxthJjVVx);
		}
		ZDyGkqTYobwsTeBoXbUQxthJjVVx result = RnblhSDNzeLWRrQBaqqjUfVuhPLc(intPtr);
		ONlNsAIeZKpgvZENEehbZBBVqqRQ(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern AMdAgCritGErRioCrkbrBpbFGYbUA yqwgPOfhDaQLwFqgxoYYzulOpGmv();

	public static AMdAgCritGErRioCrkbrBpbFGYbUA DPlnHgmfspFsIRgozDbuZqNODoRI()
	{
		return yqwgPOfhDaQLwFqgxoYYzulOpGmv();
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr psjcQLJHwinZlYygxVhyDZngianb(IntPtr P_0);

	public static feOGhFVRyyeDfXjTZISmHSuGQQrW phzeTqbCFdkwXLZjbgwCRUXCgwNnA(IntPtr P_0)
	{
		try
		{
			IntPtr intPtr = psjcQLJHwinZlYygxVhyDZngianb(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return new feOGhFVRyyeDfXjTZISmHSuGQQrW(intPtr);
		}
		catch (Exception)
		{
			return null;
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void SUBKXEPPlZcNqUFdyPWCymkWEBtT(IntPtr P_0, IntPtr P_1);

	public static void yHZKTmXnOnEOkDTMEESWDDTfPrbcb(IntPtr P_0, feOGhFVRyyeDfXjTZISmHSuGQQrW P_1)
	{
		if (!pOJFnGeJdiWQwmkAgmdJyuYyiIhd.KnRQEmwHYQnLlhpqQiYLhcNhPfug(P_1, null))
		{
			SUBKXEPPlZcNqUFdyPWCymkWEBtT(P_0, P_1.eRuooOpUXUMNyxAVfhJQXVsDGDql);
		}
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void qCedHLFYlsapCIDMKhqobZQgdgarE(kCMioJgbUOnZtVIOVuAzOmOScRpG P_0);

	public static void hxDfpukyapZlmCWDfCVPIopxumKB(kCMioJgbUOnZtVIOVuAzOmOScRpG P_0)
	{
		qCedHLFYlsapCIDMKhqobZQgdgarE(P_0);
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void zCVjodySfZsVwcFGqBnWjOUMoGsUA();

	public static void ZoOgDbAMcFOmjEQqcbfPFfdcPGnF()
	{
		zCVjodySfZsVwcFGqBnWjOUMoGsUA();
	}

	public static glPSfYIfFjEFFChzWnnhGIedDvEPc uuzMgHXBPzNLEafpVpJnKJCijDJO(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(glPSfYIfFjEFFChzWnnhGIedDvEPc);
		}
		return new glPSfYIfFjEFFChzWnnhGIedDvEPc(PUWxdbMXGuuMpaBPyLrhHORYDHNJA(P_0), LdFOPbXVKkGmiPPELXYbWFxjgWnf(P_0), fNpMODKfXKvGsrHmIuBBXSmwYOIs(P_0), fZlyFUuRrQCryHGJhrewxmtHCFUU(P_0));
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern cygDLWsWyuhvwJiyJURrXAlVEkyy PUWxdbMXGuuMpaBPyLrhHORYDHNJA(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool LdFOPbXVKkGmiPPELXYbWFxjgWnf(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern sjpkkfoQTAUasVTmkudxZsAfvAyv fZlyFUuRrQCryHGJhrewxmtHCFUU(IntPtr P_0);

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr eBTecqJmuJkLQgKaBRcrmJwKYKOgB(IntPtr P_0);

	private static ZDyGkqTYobwsTeBoXbUQxthJjVVx fNpMODKfXKvGsrHmIuBBXSmwYOIs(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(ZDyGkqTYobwsTeBoXbUQxthJjVVx);
		}
		IntPtr intPtr = eBTecqJmuJkLQgKaBRcrmJwKYKOgB(P_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(ZDyGkqTYobwsTeBoXbUQxthJjVVx);
		}
		ZDyGkqTYobwsTeBoXbUQxthJjVVx result = RnblhSDNzeLWRrQBaqqjUfVuhPLc(intPtr);
		ONlNsAIeZKpgvZENEehbZBBVqqRQ(intPtr);
		return result;
	}

	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern AMdAgCritGErRioCrkbrBpbFGYbUA ONlNsAIeZKpgvZENEehbZBBVqqRQ(IntPtr P_0);

	private static ZDyGkqTYobwsTeBoXbUQxthJjVVx RnblhSDNzeLWRrQBaqqjUfVuhPLc(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return default(ZDyGkqTYobwsTeBoXbUQxthJjVVx);
		}
		return new ZDyGkqTYobwsTeBoXbUQxthJjVVx
		{
			OjKfwIlFZuhxHeCXleiPGHRRbPkNA = ((Marshal.ReadByte(P_0, 0) > 0) ? true : false),
			uwTxIpXKoBTavTpSsROrtLUQHBB = ((Marshal.ReadByte(P_0, 1) > 0) ? true : false),
			sRgFOGXlDmijJyaMEhhiCFPIcnfmA = ((Marshal.ReadByte(P_0, 2) > 0) ? true : false),
			dQFZyLhoSlKaCJvUgZigtdFDJHPi = (uint)Marshal.ReadInt32(P_0, 4),
			QUkaebjgKydbFEYBWlZPYQNotQPt = (uint)Marshal.ReadInt32(P_0, 8),
			ajTranDxjWTJERRwruDvdAIwBPZu = ((Marshal.ReadByte(P_0, 12) > 0) ? true : false)
		};
	}
}
