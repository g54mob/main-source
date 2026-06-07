using System;

internal abstract class KgGXcGSkvujYQLBVrjgeJfXjNnv
{
	public abstract IntPtr GetIntPtr();

	public abstract uint GetSecondsSinceAppActive();

	public abstract uint GetSecondsSinceComputerActive();

	public abstract int GetConnectedUniverse();

	public abstract uint GetServerRealTime();

	public abstract string GetIPCountry();

	public abstract bool GetImageSize(int P_0, ref uint P_1, ref uint P_2);

	public abstract bool GetImageRGBA(int P_0, IntPtr P_1, int P_2);

	public abstract bool GetCSERIPPort(ref uint P_0, ref char P_1);

	public abstract byte GetCurrentBatteryPower();

	public abstract uint GetAppID();

	public abstract void SetOverlayNotificationPosition(uint P_0);

	public abstract bool IsAPICallCompleted(ulong P_0, ref bool P_1);

	public abstract int GetAPICallFailureReason(ulong P_0);

	public abstract bool GetAPICallResult(ulong P_0, IntPtr P_1, int P_2, int P_3, ref bool P_4);

	public abstract uint GetIPCCallCount();

	public abstract void SetWarningMessageHook(IntPtr P_0);

	public abstract bool IsOverlayEnabled();

	public abstract bool BOverlayNeedsPresent();

	public abstract ulong CheckFileSignature(string P_0);

	public abstract bool ShowGamepadTextInput(int P_0, int P_1, string P_2, uint P_3, string P_4);

	public abstract uint GetEnteredGamepadTextLength();

	public abstract bool GetEnteredGamepadTextInput(string P_0, uint P_1);

	public abstract string GetSteamUILanguage();

	public abstract bool IsSteamRunningInVR();

	public abstract void SetOverlayNotificationInset(int P_0, int P_1);

	public abstract bool IsSteamInBigPictureMode();

	public abstract void StartVRDashboard();

	public abstract bool IsVRHeadsetStreamingEnabled();

	public abstract void SetVRHeadsetStreamingEnabled(bool P_0);
}
