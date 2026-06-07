using System;

internal abstract class vpCTbTysCEwsbLaIYtojpIqRGKK
{
	public abstract IntPtr GetIntPtr();

	public abstract uint GetHSteamUser();

	public abstract bool BLoggedOn();

	public abstract ulong GetSteamID();

	public abstract int InitiateGameConnection(IntPtr P_0, int P_1, ulong P_2, uint P_3, char P_4, bool P_5);

	public abstract void TerminateGameConnection(uint P_0, char P_1);

	public abstract void TrackAppUsageEvent(ulong P_0, int P_1, string P_2);

	public abstract bool GetUserDataFolder(string P_0, int P_1);

	public abstract void StartVoiceRecording();

	public abstract void StopVoiceRecording();

	public abstract uint GetAvailableVoice(ref uint P_0, ref uint P_1, uint P_2);

	public abstract uint GetVoice(bool P_0, IntPtr P_1, uint P_2, ref uint P_3, bool P_4, IntPtr P_5, uint P_6, ref uint P_7, uint P_8);

	public abstract uint DecompressVoice(IntPtr P_0, uint P_1, IntPtr P_2, uint P_3, ref uint P_4, uint P_5);

	public abstract uint GetVoiceOptimalSampleRate();

	public abstract uint GetAuthSessionTicket(IntPtr P_0, int P_1, ref uint P_2);

	public abstract uint BeginAuthSession(IntPtr P_0, int P_1, ulong P_2);

	public abstract void EndAuthSession(ulong P_0);

	public abstract void CancelAuthTicket(uint P_0);

	public abstract uint UserHasLicenseForApp(ulong P_0, uint P_1);

	public abstract bool BIsBehindNAT();

	public abstract void AdvertiseGame(ulong P_0, uint P_1, char P_2);

	public abstract ulong RequestEncryptedAppTicket(IntPtr P_0, int P_1);

	public abstract bool GetEncryptedAppTicket(IntPtr P_0, int P_1, ref uint P_2);

	public abstract int GetGameBadgeLevel(int P_0, bool P_1);

	public abstract int GetPlayerSteamLevel();

	public abstract ulong RequestStoreAuthURL(string P_0);
}
