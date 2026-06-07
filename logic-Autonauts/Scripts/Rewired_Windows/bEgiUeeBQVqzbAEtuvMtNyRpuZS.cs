using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class bEgiUeeBQVqzbAEtuvMtNyRpuZS
{
	private static class zyMTepAgZdimisWfgUvUgiAsEyT
	{
		public static qKQEytGXLPHzPABLmWYxZvvEyFR jDNhEWaNZkcGmLuDeACATmLNoeS;

		private static bool XugsrESOINHVHebDAupLbovZGTT;

		public static bool GVPNrpnUrcRcuBVNsoUmnQYWdWW()
		{
			if (XugsrESOINHVHebDAupLbovZGTT)
			{
				return true;
			}
			bool flag = SystemInfo.is64Bit && nMJHbFnlNfCtEcNNydlnSPiDiVbf();
			if (!flag && !ABzRbcedpcJIzdkxWYcdjfsJaxG())
			{
				return false;
			}
			try
			{
				if (flag)
				{
					UvyANEigzZdZXRENSXjUNeCZBrq();
				}
				else
				{
					hiAzftkGxyxKsOAUBNdMSuBZQUh();
				}
				XugsrESOINHVHebDAupLbovZGTT = true;
			}
			catch
			{
			}
			return XugsrESOINHVHebDAupLbovZGTT;
		}

		private static bool ABzRbcedpcJIzdkxWYcdjfsJaxG()
		{
			return vCvAQwdJhFkNPaLiyaPbVfbOARd();
		}

		private static bool vCvAQwdJhFkNPaLiyaPbVfbOARd()
		{
			return nfPyoqENELfPsXVyBqbBHQxSViX.hXpHtBuijEDJvGwJAKyobUHfOXu();
		}

		private static bool nMJHbFnlNfCtEcNNydlnSPiDiVbf()
		{
			return zXjKhKFfzPfDsKHSqnqyKtmvzZuO();
		}

		private static bool zXjKhKFfzPfDsKHSqnqyKtmvzZuO()
		{
			return ataZvbrHQCdwKinUOSzSwpMyVhx.hXpHtBuijEDJvGwJAKyobUHfOXu();
		}

		private static void hiAzftkGxyxKsOAUBNdMSuBZQUh()
		{
			PPiietyQUheoVBbwwnyzLcgnKRU();
		}

		private static void PPiietyQUheoVBbwwnyzLcgnKRU()
		{
			jDNhEWaNZkcGmLuDeACATmLNoeS = new nfPyoqENELfPsXVyBqbBHQxSViX.gmqsMaaYKNcbGZLstIIqRcSMsoM();
		}

		private static void UvyANEigzZdZXRENSXjUNeCZBrq()
		{
			PpqqgqNkNZCAXiZygRtxTdOYJgtw();
		}

		private static void PpqqgqNkNZCAXiZygRtxTdOYJgtw()
		{
			jDNhEWaNZkcGmLuDeACATmLNoeS = new ataZvbrHQCdwKinUOSzSwpMyVhx.xQvVNzClYUopwSIrAMXNAgvWqF();
		}
	}

	private abstract class qKQEytGXLPHzPABLmWYxZvvEyFR
	{
		public abstract IntPtr SteamClient();

		public abstract IntPtr SteamController();

		public abstract bool SteamAPI_IsSteamRunning();

		public abstract void SteamAPI_RestartAppIfNecessary(uint P_0);

		public abstract void SteamAPI_Init();

		public abstract void SteamAPI_RunCallbacks();

		public abstract void SteamAPI_RegisterCallback(IntPtr P_0, int P_1);

		public abstract void SteamAPI_UnregisterCallback(IntPtr P_0);

		public abstract uint SteamAPI_GetHSteamPipe();

		public abstract uint SteamAPI_GetHSteamUser();

		public abstract uint SteamAPI_ISteamClient_CreateSteamPipe(IntPtr P_0);

		public abstract bool SteamAPI_ISteamClient_BReleaseSteamPipe(IntPtr P_0, uint P_1);

		public abstract uint SteamAPI_ISteamClient_ConnectToGlobalUser(IntPtr P_0, uint P_1);

		public abstract uint SteamAPI_ISteamClient_CreateLocalUser(IntPtr P_0, ref uint P_1, uint P_2);

		public abstract void SteamAPI_ISteamClient_ReleaseUser(IntPtr P_0, uint P_1, uint P_2);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamUser(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamGameServer(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract void SteamAPI_ISteamClient_SetLocalIPBinding(IntPtr P_0, uint P_1, char P_2);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamFriends(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamUtils(IntPtr P_0, uint P_1, string P_2);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamMatchmaking(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamMatchmakingServers(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamGenericInterface(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamUserStats(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamGameServerStats(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamApps(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamNetworking(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamRemoteStorage(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamScreenshots(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract uint SteamAPI_ISteamClient_GetIPCCallCount(IntPtr P_0);

		public abstract void SteamAPI_ISteamClient_SetWarningMessageHook(IntPtr P_0, IntPtr P_1);

		public abstract bool SteamAPI_ISteamClient_BShutdownIfAllPipesClosed(IntPtr P_0);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamHTTP(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamController(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamUGC(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamAppList(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamMusic(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamMusicRemote(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamHTMLSurface(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamInventory(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamVideo(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract IntPtr SteamAPI_ISteamClient_GetISteamParentalSettings(IntPtr P_0, uint P_1, uint P_2, string P_3);

		public abstract bool SteamAPI_ISteamController_Init(IntPtr P_0);

		public abstract bool SteamAPI_ISteamController_Shutdown(IntPtr P_0);

		public abstract bool SteamAPI_ISteamController_RunFrame(IntPtr P_0);

		public abstract int SteamAPI_ISteamController_GetConnectedControllers(IntPtr P_0, ulong[] P_1);

		public abstract int SteamAPI_ISteamController_GetConnectedControllers(IntPtr P_0, IntPtr P_1);

		public abstract bool SteamAPI_ISteamController_ShowBindingPanel(IntPtr P_0, ulong P_1);

		public abstract ulong SteamAPI_ISteamController_GetActionSetHandle(IntPtr P_0, string P_1);

		public abstract void SteamAPI_ISteamController_ActivateActionSet(IntPtr P_0, ulong P_1, ulong P_2);

		public abstract ulong SteamAPI_ISteamController_GetCurrentActionSet(IntPtr P_0, ulong P_1);

		public abstract ulong SteamAPI_ISteamController_GetDigitalActionHandle(IntPtr P_0, string P_1);

		public abstract MqFYeVKLxsquTeQxKQymlVUJzEo SteamAPI_ISteamController_GetDigitalActionData(IntPtr P_0, ulong P_1, ulong P_2);

		public abstract int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4);

		public abstract int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4);

		public abstract ulong SteamAPI_ISteamController_GetAnalogActionHandle(IntPtr P_0, string P_1);

		public abstract zquCGODUjNomfqDeknGuKrsjOHzX SteamAPI_ISteamController_GetAnalogActionData(IntPtr P_0, ulong P_1, ulong P_2);

		public abstract int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4);

		public abstract int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4);

		public abstract void SteamAPI_ISteamController_StopAnalogActionMomentum(IntPtr P_0, ulong P_1, ulong P_2);

		public abstract void SteamAPI_ISteamController_TriggerHapticPulse(IntPtr P_0, ulong P_1, uint P_2, ushort P_3);

		public abstract uint SteamAPI_ISteamUser_GetHSteamUser(IntPtr P_0);

		public abstract bool SteamAPI_ISteamUser_BLoggedOn(IntPtr P_0);

		public abstract ulong SteamAPI_ISteamUser_GetSteamID(IntPtr P_0);

		public abstract int SteamAPI_ISteamUser_InitiateGameConnection(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3, uint P_4, char P_5, bool P_6);

		public abstract void SteamAPI_ISteamUser_TerminateGameConnection(IntPtr P_0, uint P_1, char P_2);

		public abstract void SteamAPI_ISteamUser_TrackAppUsageEvent(IntPtr P_0, ulong P_1, int P_2, string P_3);

		public abstract bool SteamAPI_ISteamUser_GetUserDataFolder(IntPtr P_0, string P_1, int P_2);

		public abstract void SteamAPI_ISteamUser_StartVoiceRecording(IntPtr P_0);

		public abstract void SteamAPI_ISteamUser_StopVoiceRecording(IntPtr P_0);

		public abstract uint SteamAPI_ISteamUser_GetAvailableVoice(IntPtr P_0, ref uint P_1, ref uint P_2, uint P_3);

		public abstract uint SteamAPI_ISteamUser_GetVoice(IntPtr P_0, bool P_1, IntPtr P_2, uint P_3, ref uint P_4, bool P_5, IntPtr P_6, uint P_7, ref uint P_8, uint P_9);

		public abstract uint SteamAPI_ISteamUser_DecompressVoice(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, uint P_4, ref uint P_5, uint P_6);

		public abstract uint SteamAPI_ISteamUser_GetVoiceOptimalSampleRate(IntPtr P_0);

		public abstract uint SteamAPI_ISteamUser_GetAuthSessionTicket(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3);

		public abstract uint SteamAPI_ISteamUser_BeginAuthSession(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3);

		public abstract void SteamAPI_ISteamUser_EndAuthSession(IntPtr P_0, ulong P_1);

		public abstract void SteamAPI_ISteamUser_CancelAuthTicket(IntPtr P_0, uint P_1);

		public abstract uint SteamAPI_ISteamUser_UserHasLicenseForApp(IntPtr P_0, ulong P_1, uint P_2);

		public abstract bool SteamAPI_ISteamUser_BIsBehindNAT(IntPtr P_0);

		public abstract void SteamAPI_ISteamUser_AdvertiseGame(IntPtr P_0, ulong P_1, uint P_2, char P_3);

		public abstract ulong SteamAPI_ISteamUser_RequestEncryptedAppTicket(IntPtr P_0, IntPtr P_1, int P_2);

		public abstract bool SteamAPI_ISteamUser_GetEncryptedAppTicket(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3);

		public abstract int SteamAPI_ISteamUser_GetGameBadgeLevel(IntPtr P_0, int P_1, bool P_2);

		public abstract int SteamAPI_ISteamUser_GetPlayerSteamLevel(IntPtr P_0);

		public abstract ulong SteamAPI_ISteamUser_RequestStoreAuthURL(IntPtr P_0, string P_1);

		public abstract uint SteamAPI_ISteamUtils_GetSecondsSinceAppActive(IntPtr P_0);

		public abstract uint SteamAPI_ISteamUtils_GetSecondsSinceComputerActive(IntPtr P_0);

		public abstract int SteamAPI_ISteamUtils_GetConnectedUniverse(IntPtr P_0);

		public abstract uint SteamAPI_ISteamUtils_GetServerRealTime(IntPtr P_0);

		public abstract IntPtr SteamAPI_ISteamUtils_GetIPCountry(IntPtr P_0);

		public abstract bool SteamAPI_ISteamUtils_GetImageSize(IntPtr P_0, int P_1, ref uint P_2, ref uint P_3);

		public abstract bool SteamAPI_ISteamUtils_GetImageRGBA(IntPtr P_0, int P_1, IntPtr P_2, int P_3);

		public abstract bool SteamAPI_ISteamUtils_GetCSERIPPort(IntPtr P_0, ref uint P_1, ref char P_2);

		public abstract byte SteamAPI_ISteamUtils_GetCurrentBatteryPower(IntPtr P_0);

		public abstract uint SteamAPI_ISteamUtils_GetAppID(IntPtr P_0);

		public abstract void SteamAPI_ISteamUtils_SetOverlayNotificationPosition(IntPtr P_0, uint P_1);

		public abstract bool SteamAPI_ISteamUtils_IsAPICallCompleted(IntPtr P_0, ulong P_1, ref bool P_2);

		public abstract int SteamAPI_ISteamUtils_GetAPICallFailureReason(IntPtr P_0, ulong P_1);

		public abstract bool SteamAPI_ISteamUtils_GetAPICallResult(IntPtr P_0, ulong P_1, IntPtr P_2, int P_3, int P_4, ref bool P_5);

		public abstract uint SteamAPI_ISteamUtils_GetIPCCallCount(IntPtr P_0);

		public abstract void SteamAPI_ISteamUtils_SetWarningMessageHook(IntPtr P_0, IntPtr P_1);

		public abstract bool SteamAPI_ISteamUtils_IsOverlayEnabled(IntPtr P_0);

		public abstract bool SteamAPI_ISteamUtils_BOverlayNeedsPresent(IntPtr P_0);

		public abstract ulong SteamAPI_ISteamUtils_CheckFileSignature(IntPtr P_0, string P_1);

		public abstract bool SteamAPI_ISteamUtils_ShowGamepadTextInput(IntPtr P_0, int P_1, int P_2, string P_3, uint P_4, string P_5);

		public abstract uint SteamAPI_ISteamUtils_GetEnteredGamepadTextLength(IntPtr P_0);

		public abstract bool SteamAPI_ISteamUtils_GetEnteredGamepadTextInput(IntPtr P_0, string P_1, uint P_2);

		public abstract IntPtr SteamAPI_ISteamUtils_GetSteamUILanguage(IntPtr P_0);

		public abstract bool SteamAPI_ISteamUtils_IsSteamRunningInVR(IntPtr P_0);

		public abstract void SteamAPI_ISteamUtils_SetOverlayNotificationInset(IntPtr P_0, int P_1, int P_2);

		public abstract bool SteamAPI_ISteamUtils_IsSteamInBigPictureMode(IntPtr P_0);

		public abstract void SteamAPI_ISteamUtils_StartVRDashboard(IntPtr P_0);

		public abstract bool SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled(IntPtr P_0);

		public abstract void SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled(IntPtr P_0, bool P_1);
	}

	private class nfPyoqENELfPsXVyBqbBHQxSViX
	{
		internal class gmqsMaaYKNcbGZLstIIqRcSMsoM : qKQEytGXLPHzPABLmWYxZvvEyFR
		{
			public static bool hXpHtBuijEDJvGwJAKyobUHfOXu()
			{
				try
				{
					LtfbFERyhgBWDLCPvhvKGuOslSu();
					return true;
				}
				catch
				{
					return false;
				}
			}

			[DllImport("steam_api", EntryPoint = "SteamClient")]
			private static extern IntPtr aAEQYTLCZuVTmqOsWObIBSMBKWZ();

			public override IntPtr SteamClient()
			{
				return aAEQYTLCZuVTmqOsWObIBSMBKWZ();
			}

			[DllImport("steam_api", EntryPoint = "SteamController")]
			private static extern IntPtr CGNZZpbULAtIwRSbzutcNSTvnZU();

			public override IntPtr SteamController()
			{
				return CGNZZpbULAtIwRSbzutcNSTvnZU();
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_IsSteamRunning")]
			private static extern bool LtfbFERyhgBWDLCPvhvKGuOslSu();

			public override bool SteamAPI_IsSteamRunning()
			{
				return LtfbFERyhgBWDLCPvhvKGuOslSu();
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_RestartAppIfNecessary")]
			private static extern void jkctRAGZIVHKzDbhMHjazqQJdgfb(uint P_0);

			public override void SteamAPI_RestartAppIfNecessary(uint P_0)
			{
				jkctRAGZIVHKzDbhMHjazqQJdgfb(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_Init")]
			private static extern void JXRlLhZZJAGOxlFylfMEdsSMIqin();

			public override void SteamAPI_Init()
			{
				JXRlLhZZJAGOxlFylfMEdsSMIqin();
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_RunCallbacks")]
			private static extern void dzObPZBkJpAqyoZVAgelWFnMEPoQ();

			public override void SteamAPI_RunCallbacks()
			{
				dzObPZBkJpAqyoZVAgelWFnMEPoQ();
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_RegisterCallback")]
			private static extern void zLvSUSQbxRnslLUJVdWYFBSvJFO(IntPtr P_0, int P_1);

			public override void SteamAPI_RegisterCallback(IntPtr P_0, int P_1)
			{
				zLvSUSQbxRnslLUJVdWYFBSvJFO(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_UnregisterCallback")]
			private static extern void DXqNkzVheGOWOWyQHvtvdUjxJBW(IntPtr P_0);

			public override void SteamAPI_UnregisterCallback(IntPtr P_0)
			{
				DXqNkzVheGOWOWyQHvtvdUjxJBW(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_GetHSteamPipe")]
			private static extern uint kOOKjOlJBOujmyNlOSvVROJMzFZ();

			public override uint SteamAPI_GetHSteamPipe()
			{
				return kOOKjOlJBOujmyNlOSvVROJMzFZ();
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_GetHSteamUser")]
			private static extern uint CXyTzojTUuDBjXqzvgkcDjvRExB();

			public override uint SteamAPI_GetHSteamUser()
			{
				return CXyTzojTUuDBjXqzvgkcDjvRExB();
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_CreateSteamPipe")]
			private static extern uint AcvtlcGljNdKTsnMLvSiPTldRNX(IntPtr P_0);

			public override uint SteamAPI_ISteamClient_CreateSteamPipe(IntPtr P_0)
			{
				return AcvtlcGljNdKTsnMLvSiPTldRNX(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_BReleaseSteamPipe")]
			private static extern bool ExqBOlctqDIuyYXwgYFCvqDAEMW(IntPtr P_0, uint P_1);

			public override bool SteamAPI_ISteamClient_BReleaseSteamPipe(IntPtr P_0, uint P_1)
			{
				return ExqBOlctqDIuyYXwgYFCvqDAEMW(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_ConnectToGlobalUser")]
			private static extern uint CfArcnJwADbYZDEOByUAKiehYEe(IntPtr P_0, uint P_1);

			public override uint SteamAPI_ISteamClient_ConnectToGlobalUser(IntPtr P_0, uint P_1)
			{
				return CfArcnJwADbYZDEOByUAKiehYEe(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_CreateLocalUser")]
			private static extern uint GhLrcXHnOHWcXETmiZOleOpadP(IntPtr P_0, ref uint P_1, uint P_2);

			public override uint SteamAPI_ISteamClient_CreateLocalUser(IntPtr P_0, ref uint P_1, uint P_2)
			{
				return GhLrcXHnOHWcXETmiZOleOpadP(P_0, ref P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_ReleaseUser")]
			private static extern void mLvfvgcIDJqiaqtBvpyoqtizuFwR(IntPtr P_0, uint P_1, uint P_2);

			public override void SteamAPI_ISteamClient_ReleaseUser(IntPtr P_0, uint P_1, uint P_2)
			{
				mLvfvgcIDJqiaqtBvpyoqtizuFwR(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamUser")]
			private static extern IntPtr BtNRvphIIQEOlrzrbsWgeCfOHGaf(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUser(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return BtNRvphIIQEOlrzrbsWgeCfOHGaf(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServer")]
			private static extern IntPtr xlrJQuRAyGOlYFbUYLYVuqryWKQ(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamGameServer(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return xlrJQuRAyGOlYFbUYLYVuqryWKQ(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_SetLocalIPBinding")]
			private static extern void KYhxQvbdBKDHnBWoaJeJWTjxkgeg(IntPtr P_0, uint P_1, char P_2);

			public override void SteamAPI_ISteamClient_SetLocalIPBinding(IntPtr P_0, uint P_1, char P_2)
			{
				KYhxQvbdBKDHnBWoaJeJWTjxkgeg(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamFriends")]
			private static extern IntPtr VJxemhDUEhmHCCzAqefTNsKzhORn(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamFriends(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return VJxemhDUEhmHCCzAqefTNsKzhORn(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamUtils")]
			private static extern IntPtr EKMqhptyLRDnbNoDXTFJIQldbwW(IntPtr P_0, uint P_1, string P_2);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUtils(IntPtr P_0, uint P_1, string P_2)
			{
				return EKMqhptyLRDnbNoDXTFJIQldbwW(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmaking")]
			private static extern IntPtr CxXGJfgYLqDBoECkPRcomshxaQSw(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMatchmaking(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return CxXGJfgYLqDBoECkPRcomshxaQSw(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmakingServers")]
			private static extern IntPtr JjbKvXZYSncNIQBXALvtSBnbwal(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMatchmakingServers(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return JjbKvXZYSncNIQBXALvtSBnbwal(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamGenericInterface")]
			private static extern IntPtr otITgTwzYoHBYeYuIaJurFDcNIM(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamGenericInterface(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return otITgTwzYoHBYeYuIaJurFDcNIM(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamUserStats")]
			private static extern IntPtr UzADfTDareblddrbWnZvTShjibm(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUserStats(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return UzADfTDareblddrbWnZvTShjibm(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServerStats")]
			private static extern IntPtr zyRKMABjQPQgsTQJwHFQmhRFiID(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamGameServerStats(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return zyRKMABjQPQgsTQJwHFQmhRFiID(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamApps")]
			private static extern IntPtr bTaypQYXKUgspvEQxNaUBDdXRgu(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamApps(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return bTaypQYXKUgspvEQxNaUBDdXRgu(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamNetworking")]
			private static extern IntPtr AmqPyhEQQfdfDCbjHNWUAiCdEJe(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamNetworking(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return AmqPyhEQQfdfDCbjHNWUAiCdEJe(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamRemoteStorage")]
			private static extern IntPtr DuiAdwhAceoKHLEbQFJOOzCCCimW(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamRemoteStorage(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return DuiAdwhAceoKHLEbQFJOOzCCCimW(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamScreenshots")]
			private static extern IntPtr OPWabaDVerWGCrMTahbzgrgdoJJ(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamScreenshots(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return OPWabaDVerWGCrMTahbzgrgdoJJ(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetIPCCallCount")]
			private static extern uint zILbJmJXDKETlpUxPwzraqvrGIGK(IntPtr P_0);

			public override uint SteamAPI_ISteamClient_GetIPCCallCount(IntPtr P_0)
			{
				return zILbJmJXDKETlpUxPwzraqvrGIGK(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_SetWarningMessageHook")]
			private static extern void mFvZqrhCSFOETQnxcsMPRrakkFa(IntPtr P_0, IntPtr P_1);

			public override void SteamAPI_ISteamClient_SetWarningMessageHook(IntPtr P_0, IntPtr P_1)
			{
				mFvZqrhCSFOETQnxcsMPRrakkFa(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_BShutdownIfAllPipesClosed")]
			private static extern bool kixBlezkYKxeMdiHcavTpKEPAts(IntPtr P_0);

			public override bool SteamAPI_ISteamClient_BShutdownIfAllPipesClosed(IntPtr P_0)
			{
				return kixBlezkYKxeMdiHcavTpKEPAts(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamHTTP")]
			private static extern IntPtr wExTslGqABLUcuTebJDpPiMZwzC(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamHTTP(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return wExTslGqABLUcuTebJDpPiMZwzC(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamController")]
			private static extern IntPtr EUTNHWuTSNcqGzMCuKoljEYrOxb(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamController(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return EUTNHWuTSNcqGzMCuKoljEYrOxb(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamUGC")]
			private static extern IntPtr OnKagwgcSCdLCjPCmQZArxMXXPs(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUGC(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return OnKagwgcSCdLCjPCmQZArxMXXPs(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamAppList")]
			private static extern IntPtr UYQyXMGSlQNpDnqGUYgLfIpxhdo(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamAppList(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return UYQyXMGSlQNpDnqGUYgLfIpxhdo(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamMusic")]
			private static extern IntPtr LsrChTIzDqvWPMsPuqVSOGaJBgdh(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMusic(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return LsrChTIzDqvWPMsPuqVSOGaJBgdh(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamMusicRemote")]
			private static extern IntPtr KObnKPidtGbpXibrfIRFCYvaMevb(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMusicRemote(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return KObnKPidtGbpXibrfIRFCYvaMevb(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamHTMLSurface")]
			private static extern IntPtr MCBIqzfBfsxxKJDCxDlWaBPRnPk(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamHTMLSurface(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return MCBIqzfBfsxxKJDCxDlWaBPRnPk(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamInventory")]
			private static extern IntPtr JhobsAglKCGoFGjwmNjofibGPZPs(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamInventory(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return JhobsAglKCGoFGjwmNjofibGPZPs(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamVideo")]
			private static extern IntPtr hSlxQpJKgeGIsCIdPCNkIDpGxKaW(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamVideo(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return hSlxQpJKgeGIsCIdPCNkIDpGxKaW(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamClient_GetISteamParentalSettings")]
			private static extern IntPtr RTSRQkaiTBDAjBIBnazEFKzdkbm(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamParentalSettings(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return RTSRQkaiTBDAjBIBnazEFKzdkbm(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_Init")]
			private static extern bool swOijCSaTfsIakzWYCISoldcJhP(IntPtr P_0);

			public override bool SteamAPI_ISteamController_Init(IntPtr P_0)
			{
				return swOijCSaTfsIakzWYCISoldcJhP(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_Shutdown")]
			private static extern bool tnOOHzKDqIENNBrSUMwGgycLegXx(IntPtr P_0);

			public override bool SteamAPI_ISteamController_Shutdown(IntPtr P_0)
			{
				return tnOOHzKDqIENNBrSUMwGgycLegXx(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_RunFrame")]
			private static extern bool AdaFDOWMsIQFIVFHGNzeQosIPmZ(IntPtr P_0);

			public override bool SteamAPI_ISteamController_RunFrame(IntPtr P_0)
			{
				return AdaFDOWMsIQFIVFHGNzeQosIPmZ(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers")]
			private static extern int jTGlEFWKwiZfzxgKhdoGaQiDOJSB(IntPtr P_0, [In][Out] ulong[] P_1);

			public override int SteamAPI_ISteamController_GetConnectedControllers(IntPtr P_0, ulong[] P_1)
			{
				return jTGlEFWKwiZfzxgKhdoGaQiDOJSB(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers")]
			private static extern int jTGlEFWKwiZfzxgKhdoGaQiDOJSB(IntPtr P_0, IntPtr P_1);

			public override int SteamAPI_ISteamController_GetConnectedControllers(IntPtr P_0, IntPtr P_1)
			{
				return jTGlEFWKwiZfzxgKhdoGaQiDOJSB(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_ShowBindingPanel")]
			private static extern bool gBRwkOkglqnjTlrnIbLSiacdZAg(IntPtr P_0, ulong P_1);

			public override bool SteamAPI_ISteamController_ShowBindingPanel(IntPtr P_0, ulong P_1)
			{
				return gBRwkOkglqnjTlrnIbLSiacdZAg(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetActionSetHandle")]
			private static extern ulong dIUgXuuufpsdbDXOwiRSWtpMzaR(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamController_GetActionSetHandle(IntPtr P_0, string P_1)
			{
				return dIUgXuuufpsdbDXOwiRSWtpMzaR(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_ActivateActionSet")]
			private static extern void MMLAaBPBPsqpLQdXISukfbxlKqJ(IntPtr P_0, ulong P_1, ulong P_2);

			public override void SteamAPI_ISteamController_ActivateActionSet(IntPtr P_0, ulong P_1, ulong P_2)
			{
				MMLAaBPBPsqpLQdXISukfbxlKqJ(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetCurrentActionSet")]
			private static extern ulong YXmpVnGdZbuogInEHODbpauKCef(IntPtr P_0, ulong P_1);

			public override ulong SteamAPI_ISteamController_GetCurrentActionSet(IntPtr P_0, ulong P_1)
			{
				return YXmpVnGdZbuogInEHODbpauKCef(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionHandle")]
			private static extern ulong llqFhAjAfUnFAHCIqiIBraiYiXuL(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamController_GetDigitalActionHandle(IntPtr P_0, string P_1)
			{
				return llqFhAjAfUnFAHCIqiIBraiYiXuL(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionData")]
			private static extern MqFYeVKLxsquTeQxKQymlVUJzEo LnDcAUuCPKntNUMPPPgkXwoCylX(IntPtr P_0, ulong P_1, ulong P_2);

			public override MqFYeVKLxsquTeQxKQymlVUJzEo SteamAPI_ISteamController_GetDigitalActionData(IntPtr P_0, ulong P_1, ulong P_2)
			{
				return LnDcAUuCPKntNUMPPPgkXwoCylX(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins")]
			private static extern int aOaHIqjvoBRKKRGVPwBKHSaCEhl(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4);

			public override int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4)
			{
				return aOaHIqjvoBRKKRGVPwBKHSaCEhl(P_0, P_1, P_2, P_3, ref P_4);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins")]
			private static extern int aOaHIqjvoBRKKRGVPwBKHSaCEhl(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4);

			public override int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4)
			{
				return aOaHIqjvoBRKKRGVPwBKHSaCEhl(P_0, P_1, P_2, P_3, P_4);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionHandle")]
			private static extern ulong CizAANaAYfvyPjTuyrXXpQzeGOej(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamController_GetAnalogActionHandle(IntPtr P_0, string P_1)
			{
				return CizAANaAYfvyPjTuyrXXpQzeGOej(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionData")]
			private static extern zquCGODUjNomfqDeknGuKrsjOHzX CEYGklXWrXPUovvMAAwooKdxNnL(IntPtr P_0, ulong P_1, ulong P_2);

			public override zquCGODUjNomfqDeknGuKrsjOHzX SteamAPI_ISteamController_GetAnalogActionData(IntPtr P_0, ulong P_1, ulong P_2)
			{
				return CEYGklXWrXPUovvMAAwooKdxNnL(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins")]
			private static extern int TqLdbPcbXRPNoAthDljHUMsOsLI(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4);

			public override int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4)
			{
				return TqLdbPcbXRPNoAthDljHUMsOsLI(P_0, P_1, P_2, P_3, ref P_4);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins")]
			private static extern int TqLdbPcbXRPNoAthDljHUMsOsLI(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4);

			public override int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4)
			{
				return TqLdbPcbXRPNoAthDljHUMsOsLI(P_0, P_1, P_2, P_3, P_4);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_StopAnalogActionMomentum")]
			private static extern void bFKfxgwJHyMJKGGIdTfGYziyDGT(IntPtr P_0, ulong P_1, ulong P_2);

			public override void SteamAPI_ISteamController_StopAnalogActionMomentum(IntPtr P_0, ulong P_1, ulong P_2)
			{
				bFKfxgwJHyMJKGGIdTfGYziyDGT(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamController_TriggerHapticPulse")]
			private static extern void qgSDhkkSqzMLWkoAhDyiHrFZfNlM(IntPtr P_0, ulong P_1, uint P_2, ushort P_3);

			public override void SteamAPI_ISteamController_TriggerHapticPulse(IntPtr P_0, ulong P_1, uint P_2, ushort P_3)
			{
				qgSDhkkSqzMLWkoAhDyiHrFZfNlM(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetHSteamUser")]
			private static extern uint WyNsuHbLzYUqLiKPNhjlaFKlaefO(IntPtr P_0);

			public override uint SteamAPI_ISteamUser_GetHSteamUser(IntPtr P_0)
			{
				return WyNsuHbLzYUqLiKPNhjlaFKlaefO(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_BLoggedOn")]
			private static extern bool juSqUVRAAsElXcHBzDntaLnkiITX(IntPtr P_0);

			public override bool SteamAPI_ISteamUser_BLoggedOn(IntPtr P_0)
			{
				return juSqUVRAAsElXcHBzDntaLnkiITX(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetSteamID")]
			private static extern ulong ozXcSncKRvFSdOCSPajgWwdRpiV(IntPtr P_0);

			public override ulong SteamAPI_ISteamUser_GetSteamID(IntPtr P_0)
			{
				return ozXcSncKRvFSdOCSPajgWwdRpiV(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_InitiateGameConnection")]
			private static extern int sDOhRxKeerZrPfmlaLtpGYRSoWb(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3, uint P_4, char P_5, bool P_6);

			public override int SteamAPI_ISteamUser_InitiateGameConnection(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3, uint P_4, char P_5, bool P_6)
			{
				return sDOhRxKeerZrPfmlaLtpGYRSoWb(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_TerminateGameConnection")]
			private static extern void KfFTaxslYqvJWzYCFHVPLOsLAzOi(IntPtr P_0, uint P_1, char P_2);

			public override void SteamAPI_ISteamUser_TerminateGameConnection(IntPtr P_0, uint P_1, char P_2)
			{
				KfFTaxslYqvJWzYCFHVPLOsLAzOi(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_TrackAppUsageEvent")]
			private static extern void vGHEQSpXmHRmRaklejyuBPGNoGie(IntPtr P_0, ulong P_1, int P_2, string P_3);

			public override void SteamAPI_ISteamUser_TrackAppUsageEvent(IntPtr P_0, ulong P_1, int P_2, string P_3)
			{
				vGHEQSpXmHRmRaklejyuBPGNoGie(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetUserDataFolder")]
			private static extern bool PMLlkltdcuBHppJbGwcQXpmMdqX(IntPtr P_0, string P_1, int P_2);

			public override bool SteamAPI_ISteamUser_GetUserDataFolder(IntPtr P_0, string P_1, int P_2)
			{
				return PMLlkltdcuBHppJbGwcQXpmMdqX(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_StartVoiceRecording")]
			private static extern void KFJbFlebBVBpOWGXmPTurvbwunx(IntPtr P_0);

			public override void SteamAPI_ISteamUser_StartVoiceRecording(IntPtr P_0)
			{
				KFJbFlebBVBpOWGXmPTurvbwunx(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_StopVoiceRecording")]
			private static extern void NEgZJPZiluZypZlKQhKjquVsHKO(IntPtr P_0);

			public override void SteamAPI_ISteamUser_StopVoiceRecording(IntPtr P_0)
			{
				NEgZJPZiluZypZlKQhKjquVsHKO(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetAvailableVoice")]
			private static extern uint UmgYJYxKSgefwQoLqcgebxtMYuH(IntPtr P_0, ref uint P_1, ref uint P_2, uint P_3);

			public override uint SteamAPI_ISteamUser_GetAvailableVoice(IntPtr P_0, ref uint P_1, ref uint P_2, uint P_3)
			{
				return UmgYJYxKSgefwQoLqcgebxtMYuH(P_0, ref P_1, ref P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetVoice")]
			private static extern uint wJcNUgnJRicrNglvrYoiaFoAgnPd(IntPtr P_0, bool P_1, IntPtr P_2, uint P_3, ref uint P_4, bool P_5, IntPtr P_6, uint P_7, ref uint P_8, uint P_9);

			public override uint SteamAPI_ISteamUser_GetVoice(IntPtr P_0, bool P_1, IntPtr P_2, uint P_3, ref uint P_4, bool P_5, IntPtr P_6, uint P_7, ref uint P_8, uint P_9)
			{
				return wJcNUgnJRicrNglvrYoiaFoAgnPd(P_0, P_1, P_2, P_3, ref P_4, P_5, P_6, P_7, ref P_8, P_9);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_DecompressVoice")]
			private static extern uint lJbgIFtuZBYEtcJQBiyUxbdwQCC(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, uint P_4, ref uint P_5, uint P_6);

			public override uint SteamAPI_ISteamUser_DecompressVoice(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, uint P_4, ref uint P_5, uint P_6)
			{
				return lJbgIFtuZBYEtcJQBiyUxbdwQCC(P_0, P_1, P_2, P_3, P_4, ref P_5, P_6);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetVoiceOptimalSampleRate")]
			private static extern uint RkumCMmqCwbtMAQOLiybFEUOXaYr(IntPtr P_0);

			public override uint SteamAPI_ISteamUser_GetVoiceOptimalSampleRate(IntPtr P_0)
			{
				return RkumCMmqCwbtMAQOLiybFEUOXaYr(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetAuthSessionTicket")]
			private static extern uint yrwfcnfzFmywGnQtawiEFUUIJCnL(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3);

			public override uint SteamAPI_ISteamUser_GetAuthSessionTicket(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3)
			{
				return yrwfcnfzFmywGnQtawiEFUUIJCnL(P_0, P_1, P_2, ref P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_BeginAuthSession")]
			private static extern uint HnHnAxuFUTBHGOnrriaLnqyXETN(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3);

			public override uint SteamAPI_ISteamUser_BeginAuthSession(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3)
			{
				return HnHnAxuFUTBHGOnrriaLnqyXETN(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_EndAuthSession")]
			private static extern void EZenKMHKZDOSwHonlOykMHGiSVt(IntPtr P_0, ulong P_1);

			public override void SteamAPI_ISteamUser_EndAuthSession(IntPtr P_0, ulong P_1)
			{
				EZenKMHKZDOSwHonlOykMHGiSVt(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_CancelAuthTicket")]
			private static extern void bbXCXRTLqyoiTIFRkMTpOZNJCdu(IntPtr P_0, uint P_1);

			public override void SteamAPI_ISteamUser_CancelAuthTicket(IntPtr P_0, uint P_1)
			{
				bbXCXRTLqyoiTIFRkMTpOZNJCdu(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_UserHasLicenseForApp")]
			private static extern uint ZyUBBuzXPyHEEpajzGjdKYWffqUB(IntPtr P_0, ulong P_1, uint P_2);

			public override uint SteamAPI_ISteamUser_UserHasLicenseForApp(IntPtr P_0, ulong P_1, uint P_2)
			{
				return ZyUBBuzXPyHEEpajzGjdKYWffqUB(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_BIsBehindNAT")]
			private static extern bool lQqLcsCJgskeNaGSUiMPxSuzHRD(IntPtr P_0);

			public override bool SteamAPI_ISteamUser_BIsBehindNAT(IntPtr P_0)
			{
				return lQqLcsCJgskeNaGSUiMPxSuzHRD(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_AdvertiseGame")]
			private static extern void JElHDeKxriRFbCZBlERIYDOzmaV(IntPtr P_0, ulong P_1, uint P_2, char P_3);

			public override void SteamAPI_ISteamUser_AdvertiseGame(IntPtr P_0, ulong P_1, uint P_2, char P_3)
			{
				JElHDeKxriRFbCZBlERIYDOzmaV(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_RequestEncryptedAppTicket")]
			private static extern ulong RLtIkIrPqpStcGNCUKUhLnlvHCe(IntPtr P_0, IntPtr P_1, int P_2);

			public override ulong SteamAPI_ISteamUser_RequestEncryptedAppTicket(IntPtr P_0, IntPtr P_1, int P_2)
			{
				return RLtIkIrPqpStcGNCUKUhLnlvHCe(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetEncryptedAppTicket")]
			private static extern bool AjEHOefXzoJYZTKEMgWWqMFADMx(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3);

			public override bool SteamAPI_ISteamUser_GetEncryptedAppTicket(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3)
			{
				return AjEHOefXzoJYZTKEMgWWqMFADMx(P_0, P_1, P_2, ref P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetGameBadgeLevel")]
			private static extern int YxGAxVAGdfPfcOzlDTSiRDNhuMa(IntPtr P_0, int P_1, bool P_2);

			public override int SteamAPI_ISteamUser_GetGameBadgeLevel(IntPtr P_0, int P_1, bool P_2)
			{
				return YxGAxVAGdfPfcOzlDTSiRDNhuMa(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_GetPlayerSteamLevel")]
			private static extern int RUaGgiHvfNRiwzvnvTiZjVNJTWv(IntPtr P_0);

			public override int SteamAPI_ISteamUser_GetPlayerSteamLevel(IntPtr P_0)
			{
				return RUaGgiHvfNRiwzvnvTiZjVNJTWv(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUser_RequestStoreAuthURL")]
			private static extern ulong oAadbcKjTGdfKsWDrHDLCxbuETAh(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamUser_RequestStoreAuthURL(IntPtr P_0, string P_1)
			{
				return oAadbcKjTGdfKsWDrHDLCxbuETAh(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceAppActive")]
			private static extern uint BsmqwTkUOWRzgxIOYRGixwIwqow(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetSecondsSinceAppActive(IntPtr P_0)
			{
				return BsmqwTkUOWRzgxIOYRGixwIwqow(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceComputerActive")]
			private static extern uint GJfCJBpVQmSbbYWjrfciltfAMLv(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetSecondsSinceComputerActive(IntPtr P_0)
			{
				return GJfCJBpVQmSbbYWjrfciltfAMLv(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetConnectedUniverse")]
			private static extern int xOlrkIRpXCGSiccxdLYrGbsMaFxm(IntPtr P_0);

			public override int SteamAPI_ISteamUtils_GetConnectedUniverse(IntPtr P_0)
			{
				return xOlrkIRpXCGSiccxdLYrGbsMaFxm(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetServerRealTime")]
			private static extern uint UuEsDIxWWcMYmeMAsAtcYgqivft(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetServerRealTime(IntPtr P_0)
			{
				return UuEsDIxWWcMYmeMAsAtcYgqivft(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetIPCountry")]
			private static extern IntPtr FouoBgAVfdolUeERupBoJBrPosh(IntPtr P_0);

			public override IntPtr SteamAPI_ISteamUtils_GetIPCountry(IntPtr P_0)
			{
				return FouoBgAVfdolUeERupBoJBrPosh(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetImageSize")]
			private static extern bool tqMIpUezgRPetgcSHTRmrYsODUO(IntPtr P_0, int P_1, ref uint P_2, ref uint P_3);

			public override bool SteamAPI_ISteamUtils_GetImageSize(IntPtr P_0, int P_1, ref uint P_2, ref uint P_3)
			{
				return tqMIpUezgRPetgcSHTRmrYsODUO(P_0, P_1, ref P_2, ref P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetImageRGBA")]
			private static extern bool bpplqFjTuIlPtruLmOOAeapvPSc(IntPtr P_0, int P_1, IntPtr P_2, int P_3);

			public override bool SteamAPI_ISteamUtils_GetImageRGBA(IntPtr P_0, int P_1, IntPtr P_2, int P_3)
			{
				return bpplqFjTuIlPtruLmOOAeapvPSc(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetCSERIPPort")]
			private static extern bool FbnWugycHxlhbDxCFZAWjTssPUa(IntPtr P_0, ref uint P_1, ref char P_2);

			public override bool SteamAPI_ISteamUtils_GetCSERIPPort(IntPtr P_0, ref uint P_1, ref char P_2)
			{
				return FbnWugycHxlhbDxCFZAWjTssPUa(P_0, ref P_1, ref P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetCurrentBatteryPower")]
			private static extern byte KHEMOidGoMQcEZATHSpBOaMXhSz(IntPtr P_0);

			public override byte SteamAPI_ISteamUtils_GetCurrentBatteryPower(IntPtr P_0)
			{
				return KHEMOidGoMQcEZATHSpBOaMXhSz(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetAppID")]
			private static extern uint whRTMWfeKTsRTsfNTwZUQnqYHNT(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetAppID(IntPtr P_0)
			{
				return whRTMWfeKTsRTsfNTwZUQnqYHNT(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationPosition")]
			private static extern void nLDhRTAPWVrhusVVMBDGiokrJpnC(IntPtr P_0, uint P_1);

			public override void SteamAPI_ISteamUtils_SetOverlayNotificationPosition(IntPtr P_0, uint P_1)
			{
				nLDhRTAPWVrhusVVMBDGiokrJpnC(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_IsAPICallCompleted")]
			private static extern bool nNQGOgNjnnCOPJxWcRZobyhYEcMn(IntPtr P_0, ulong P_1, ref bool P_2);

			public override bool SteamAPI_ISteamUtils_IsAPICallCompleted(IntPtr P_0, ulong P_1, ref bool P_2)
			{
				return nNQGOgNjnnCOPJxWcRZobyhYEcMn(P_0, P_1, ref P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetAPICallFailureReason")]
			private static extern int hSDIlSEVPOXTKlNjGmzWdUDnkNQ(IntPtr P_0, ulong P_1);

			public override int SteamAPI_ISteamUtils_GetAPICallFailureReason(IntPtr P_0, ulong P_1)
			{
				return hSDIlSEVPOXTKlNjGmzWdUDnkNQ(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetAPICallResult")]
			private static extern bool xEzjxhHKLXakrgSaAxWCwwrOXoWl(IntPtr P_0, ulong P_1, IntPtr P_2, int P_3, int P_4, ref bool P_5);

			public override bool SteamAPI_ISteamUtils_GetAPICallResult(IntPtr P_0, ulong P_1, IntPtr P_2, int P_3, int P_4, ref bool P_5)
			{
				return xEzjxhHKLXakrgSaAxWCwwrOXoWl(P_0, P_1, P_2, P_3, P_4, ref P_5);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetIPCCallCount")]
			private static extern uint LsHPMyyTXncLzVscEaQkUQJjWwt(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetIPCCallCount(IntPtr P_0)
			{
				return LsHPMyyTXncLzVscEaQkUQJjWwt(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_SetWarningMessageHook")]
			private static extern void CmUaweAnupVxpxFBMcbCTzkiTfP(IntPtr P_0, IntPtr P_1);

			public override void SteamAPI_ISteamUtils_SetWarningMessageHook(IntPtr P_0, IntPtr P_1)
			{
				CmUaweAnupVxpxFBMcbCTzkiTfP(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_IsOverlayEnabled")]
			private static extern bool CoMcszQLuEAdPzDlqdzIwvmJhTwH(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsOverlayEnabled(IntPtr P_0)
			{
				return CoMcszQLuEAdPzDlqdzIwvmJhTwH(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_BOverlayNeedsPresent")]
			private static extern bool ZdqgRROeNszUUcRTTXGKvUxjCwI(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_BOverlayNeedsPresent(IntPtr P_0)
			{
				return ZdqgRROeNszUUcRTTXGKvUxjCwI(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_CheckFileSignature")]
			private static extern ulong LjVyNDdckPqxhzKDgFOigNRVygN(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamUtils_CheckFileSignature(IntPtr P_0, string P_1)
			{
				return LjVyNDdckPqxhzKDgFOigNRVygN(P_0, P_1);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_ShowGamepadTextInput")]
			private static extern bool jISrvoDdcGbpkzjPkjaWgbXjjXF(IntPtr P_0, int P_1, int P_2, string P_3, uint P_4, string P_5);

			public override bool SteamAPI_ISteamUtils_ShowGamepadTextInput(IntPtr P_0, int P_1, int P_2, string P_3, uint P_4, string P_5)
			{
				return jISrvoDdcGbpkzjPkjaWgbXjjXF(P_0, P_1, P_2, P_3, P_4, P_5);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextLength")]
			private static extern uint wIPZlJByfwbDVupyKshCYXNMNld(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetEnteredGamepadTextLength(IntPtr P_0)
			{
				return wIPZlJByfwbDVupyKshCYXNMNld(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextInput")]
			private static extern bool abOBaHKpmykjWbNIsqpAvsKSFajZ(IntPtr P_0, string P_1, uint P_2);

			public override bool SteamAPI_ISteamUtils_GetEnteredGamepadTextInput(IntPtr P_0, string P_1, uint P_2)
			{
				return abOBaHKpmykjWbNIsqpAvsKSFajZ(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_GetSteamUILanguage")]
			private static extern IntPtr ubdtMGXApjjURbeXTlvFpuWfhWrS(IntPtr P_0);

			public override IntPtr SteamAPI_ISteamUtils_GetSteamUILanguage(IntPtr P_0)
			{
				return ubdtMGXApjjURbeXTlvFpuWfhWrS(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningInVR")]
			private static extern bool mKkQFYebFzBTxcQuuItuHwiOoJvk(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsSteamRunningInVR(IntPtr P_0)
			{
				return mKkQFYebFzBTxcQuuItuHwiOoJvk(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationInset")]
			private static extern void DYeXsDWoaHkfNjcnqCBMjAXvzWnp(IntPtr P_0, int P_1, int P_2);

			public override void SteamAPI_ISteamUtils_SetOverlayNotificationInset(IntPtr P_0, int P_1, int P_2)
			{
				DYeXsDWoaHkfNjcnqCBMjAXvzWnp(P_0, P_1, P_2);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_IsSteamInBigPictureMode")]
			private static extern bool YLgHOzUDIpTQMGIEebuPBcueRHQ(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsSteamInBigPictureMode(IntPtr P_0)
			{
				return YLgHOzUDIpTQMGIEebuPBcueRHQ(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_StartVRDashboard")]
			private static extern void JkZomBxpuwqgwiSlEmtMPiHvWwy(IntPtr P_0);

			public override void SteamAPI_ISteamUtils_StartVRDashboard(IntPtr P_0)
			{
				JkZomBxpuwqgwiSlEmtMPiHvWwy(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled")]
			private static extern bool qUpshSBgZyrpldQaLPTZcSdBYOa(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled(IntPtr P_0)
			{
				return qUpshSBgZyrpldQaLPTZcSdBYOa(P_0);
			}

			[DllImport("steam_api", EntryPoint = "SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled")]
			private static extern void MFHPQSTSVSRCzznFRTzfqmqMoCm(IntPtr P_0, bool P_1);

			public override void SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled(IntPtr P_0, bool P_1)
			{
				MFHPQSTSVSRCzznFRTzfqmqMoCm(P_0, P_1);
			}
		}

		public const string YjbgwtwGpRzjbuGiCSdoSmuxuFe = "steam_api";

		public static bool hXpHtBuijEDJvGwJAKyobUHfOXu()
		{
			return gmqsMaaYKNcbGZLstIIqRcSMsoM.hXpHtBuijEDJvGwJAKyobUHfOXu();
		}
	}

	private class ataZvbrHQCdwKinUOSzSwpMyVhx
	{
		internal class xQvVNzClYUopwSIrAMXNAgvWqF : qKQEytGXLPHzPABLmWYxZvvEyFR
		{
			public static bool hXpHtBuijEDJvGwJAKyobUHfOXu()
			{
				try
				{
					LtfbFERyhgBWDLCPvhvKGuOslSu();
					return true;
				}
				catch
				{
					return false;
				}
			}

			[DllImport("steam_api64", EntryPoint = "SteamClient")]
			private static extern IntPtr aAEQYTLCZuVTmqOsWObIBSMBKWZ();

			public override IntPtr SteamClient()
			{
				return aAEQYTLCZuVTmqOsWObIBSMBKWZ();
			}

			[DllImport("steam_api64", EntryPoint = "SteamController")]
			private static extern IntPtr CGNZZpbULAtIwRSbzutcNSTvnZU();

			public override IntPtr SteamController()
			{
				return CGNZZpbULAtIwRSbzutcNSTvnZU();
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_IsSteamRunning")]
			private static extern bool LtfbFERyhgBWDLCPvhvKGuOslSu();

			public override bool SteamAPI_IsSteamRunning()
			{
				return LtfbFERyhgBWDLCPvhvKGuOslSu();
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_RestartAppIfNecessary")]
			private static extern void jkctRAGZIVHKzDbhMHjazqQJdgfb(uint P_0);

			public override void SteamAPI_RestartAppIfNecessary(uint P_0)
			{
				jkctRAGZIVHKzDbhMHjazqQJdgfb(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_Init")]
			private static extern void JXRlLhZZJAGOxlFylfMEdsSMIqin();

			public override void SteamAPI_Init()
			{
				JXRlLhZZJAGOxlFylfMEdsSMIqin();
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_RunCallbacks")]
			private static extern void dzObPZBkJpAqyoZVAgelWFnMEPoQ();

			public override void SteamAPI_RunCallbacks()
			{
				dzObPZBkJpAqyoZVAgelWFnMEPoQ();
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_RegisterCallback")]
			private static extern void zLvSUSQbxRnslLUJVdWYFBSvJFO(IntPtr P_0, int P_1);

			public override void SteamAPI_RegisterCallback(IntPtr P_0, int P_1)
			{
				zLvSUSQbxRnslLUJVdWYFBSvJFO(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_UnregisterCallback")]
			private static extern void DXqNkzVheGOWOWyQHvtvdUjxJBW(IntPtr P_0);

			public override void SteamAPI_UnregisterCallback(IntPtr P_0)
			{
				DXqNkzVheGOWOWyQHvtvdUjxJBW(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_GetHSteamPipe")]
			private static extern uint kOOKjOlJBOujmyNlOSvVROJMzFZ();

			public override uint SteamAPI_GetHSteamPipe()
			{
				return kOOKjOlJBOujmyNlOSvVROJMzFZ();
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_GetHSteamUser")]
			private static extern uint CXyTzojTUuDBjXqzvgkcDjvRExB();

			public override uint SteamAPI_GetHSteamUser()
			{
				return CXyTzojTUuDBjXqzvgkcDjvRExB();
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_CreateSteamPipe")]
			private static extern uint AcvtlcGljNdKTsnMLvSiPTldRNX(IntPtr P_0);

			public override uint SteamAPI_ISteamClient_CreateSteamPipe(IntPtr P_0)
			{
				return AcvtlcGljNdKTsnMLvSiPTldRNX(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_BReleaseSteamPipe")]
			private static extern bool ExqBOlctqDIuyYXwgYFCvqDAEMW(IntPtr P_0, uint P_1);

			public override bool SteamAPI_ISteamClient_BReleaseSteamPipe(IntPtr P_0, uint P_1)
			{
				return ExqBOlctqDIuyYXwgYFCvqDAEMW(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_ConnectToGlobalUser")]
			private static extern uint CfArcnJwADbYZDEOByUAKiehYEe(IntPtr P_0, uint P_1);

			public override uint SteamAPI_ISteamClient_ConnectToGlobalUser(IntPtr P_0, uint P_1)
			{
				return CfArcnJwADbYZDEOByUAKiehYEe(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_CreateLocalUser")]
			private static extern uint GhLrcXHnOHWcXETmiZOleOpadP(IntPtr P_0, ref uint P_1, uint P_2);

			public override uint SteamAPI_ISteamClient_CreateLocalUser(IntPtr P_0, ref uint P_1, uint P_2)
			{
				return GhLrcXHnOHWcXETmiZOleOpadP(P_0, ref P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_ReleaseUser")]
			private static extern void mLvfvgcIDJqiaqtBvpyoqtizuFwR(IntPtr P_0, uint P_1, uint P_2);

			public override void SteamAPI_ISteamClient_ReleaseUser(IntPtr P_0, uint P_1, uint P_2)
			{
				mLvfvgcIDJqiaqtBvpyoqtizuFwR(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamUser")]
			private static extern IntPtr BtNRvphIIQEOlrzrbsWgeCfOHGaf(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUser(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return BtNRvphIIQEOlrzrbsWgeCfOHGaf(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServer")]
			private static extern IntPtr xlrJQuRAyGOlYFbUYLYVuqryWKQ(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamGameServer(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return xlrJQuRAyGOlYFbUYLYVuqryWKQ(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_SetLocalIPBinding")]
			private static extern void KYhxQvbdBKDHnBWoaJeJWTjxkgeg(IntPtr P_0, uint P_1, char P_2);

			public override void SteamAPI_ISteamClient_SetLocalIPBinding(IntPtr P_0, uint P_1, char P_2)
			{
				KYhxQvbdBKDHnBWoaJeJWTjxkgeg(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamFriends")]
			private static extern IntPtr VJxemhDUEhmHCCzAqefTNsKzhORn(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamFriends(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return VJxemhDUEhmHCCzAqefTNsKzhORn(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamUtils")]
			private static extern IntPtr EKMqhptyLRDnbNoDXTFJIQldbwW(IntPtr P_0, uint P_1, string P_2);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUtils(IntPtr P_0, uint P_1, string P_2)
			{
				return EKMqhptyLRDnbNoDXTFJIQldbwW(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmaking")]
			private static extern IntPtr CxXGJfgYLqDBoECkPRcomshxaQSw(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMatchmaking(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return CxXGJfgYLqDBoECkPRcomshxaQSw(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmakingServers")]
			private static extern IntPtr JjbKvXZYSncNIQBXALvtSBnbwal(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMatchmakingServers(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return JjbKvXZYSncNIQBXALvtSBnbwal(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamGenericInterface")]
			private static extern IntPtr otITgTwzYoHBYeYuIaJurFDcNIM(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamGenericInterface(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return otITgTwzYoHBYeYuIaJurFDcNIM(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamUserStats")]
			private static extern IntPtr UzADfTDareblddrbWnZvTShjibm(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUserStats(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return UzADfTDareblddrbWnZvTShjibm(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServerStats")]
			private static extern IntPtr zyRKMABjQPQgsTQJwHFQmhRFiID(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamGameServerStats(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return zyRKMABjQPQgsTQJwHFQmhRFiID(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamApps")]
			private static extern IntPtr bTaypQYXKUgspvEQxNaUBDdXRgu(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamApps(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return bTaypQYXKUgspvEQxNaUBDdXRgu(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamNetworking")]
			private static extern IntPtr AmqPyhEQQfdfDCbjHNWUAiCdEJe(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamNetworking(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return AmqPyhEQQfdfDCbjHNWUAiCdEJe(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamRemoteStorage")]
			private static extern IntPtr DuiAdwhAceoKHLEbQFJOOzCCCimW(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamRemoteStorage(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return DuiAdwhAceoKHLEbQFJOOzCCCimW(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamScreenshots")]
			private static extern IntPtr OPWabaDVerWGCrMTahbzgrgdoJJ(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamScreenshots(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return OPWabaDVerWGCrMTahbzgrgdoJJ(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetIPCCallCount")]
			private static extern uint zILbJmJXDKETlpUxPwzraqvrGIGK(IntPtr P_0);

			public override uint SteamAPI_ISteamClient_GetIPCCallCount(IntPtr P_0)
			{
				return zILbJmJXDKETlpUxPwzraqvrGIGK(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_SetWarningMessageHook")]
			private static extern void mFvZqrhCSFOETQnxcsMPRrakkFa(IntPtr P_0, IntPtr P_1);

			public override void SteamAPI_ISteamClient_SetWarningMessageHook(IntPtr P_0, IntPtr P_1)
			{
				mFvZqrhCSFOETQnxcsMPRrakkFa(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_BShutdownIfAllPipesClosed")]
			private static extern bool kixBlezkYKxeMdiHcavTpKEPAts(IntPtr P_0);

			public override bool SteamAPI_ISteamClient_BShutdownIfAllPipesClosed(IntPtr P_0)
			{
				return kixBlezkYKxeMdiHcavTpKEPAts(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamHTTP")]
			private static extern IntPtr wExTslGqABLUcuTebJDpPiMZwzC(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamHTTP(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return wExTslGqABLUcuTebJDpPiMZwzC(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamController")]
			private static extern IntPtr EUTNHWuTSNcqGzMCuKoljEYrOxb(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamController(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return EUTNHWuTSNcqGzMCuKoljEYrOxb(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamUGC")]
			private static extern IntPtr OnKagwgcSCdLCjPCmQZArxMXXPs(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamUGC(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return OnKagwgcSCdLCjPCmQZArxMXXPs(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamAppList")]
			private static extern IntPtr UYQyXMGSlQNpDnqGUYgLfIpxhdo(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamAppList(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return UYQyXMGSlQNpDnqGUYgLfIpxhdo(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamMusic")]
			private static extern IntPtr LsrChTIzDqvWPMsPuqVSOGaJBgdh(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMusic(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return LsrChTIzDqvWPMsPuqVSOGaJBgdh(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamMusicRemote")]
			private static extern IntPtr KObnKPidtGbpXibrfIRFCYvaMevb(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamMusicRemote(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return KObnKPidtGbpXibrfIRFCYvaMevb(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamHTMLSurface")]
			private static extern IntPtr MCBIqzfBfsxxKJDCxDlWaBPRnPk(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamHTMLSurface(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return MCBIqzfBfsxxKJDCxDlWaBPRnPk(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamInventory")]
			private static extern IntPtr JhobsAglKCGoFGjwmNjofibGPZPs(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamInventory(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return JhobsAglKCGoFGjwmNjofibGPZPs(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamVideo")]
			private static extern IntPtr hSlxQpJKgeGIsCIdPCNkIDpGxKaW(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamVideo(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return hSlxQpJKgeGIsCIdPCNkIDpGxKaW(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamClient_GetISteamParentalSettings")]
			private static extern IntPtr RTSRQkaiTBDAjBIBnazEFKzdkbm(IntPtr P_0, uint P_1, uint P_2, string P_3);

			public override IntPtr SteamAPI_ISteamClient_GetISteamParentalSettings(IntPtr P_0, uint P_1, uint P_2, string P_3)
			{
				return RTSRQkaiTBDAjBIBnazEFKzdkbm(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_Init")]
			private static extern bool swOijCSaTfsIakzWYCISoldcJhP(IntPtr P_0);

			public override bool SteamAPI_ISteamController_Init(IntPtr P_0)
			{
				return swOijCSaTfsIakzWYCISoldcJhP(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_Shutdown")]
			private static extern bool tnOOHzKDqIENNBrSUMwGgycLegXx(IntPtr P_0);

			public override bool SteamAPI_ISteamController_Shutdown(IntPtr P_0)
			{
				return tnOOHzKDqIENNBrSUMwGgycLegXx(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_RunFrame")]
			private static extern bool AdaFDOWMsIQFIVFHGNzeQosIPmZ(IntPtr P_0);

			public override bool SteamAPI_ISteamController_RunFrame(IntPtr P_0)
			{
				return AdaFDOWMsIQFIVFHGNzeQosIPmZ(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers")]
			private static extern int jTGlEFWKwiZfzxgKhdoGaQiDOJSB(IntPtr P_0, [In][Out] ulong[] P_1);

			public override int SteamAPI_ISteamController_GetConnectedControllers(IntPtr P_0, ulong[] P_1)
			{
				return jTGlEFWKwiZfzxgKhdoGaQiDOJSB(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers")]
			private static extern int jTGlEFWKwiZfzxgKhdoGaQiDOJSB(IntPtr P_0, IntPtr P_1);

			public override int SteamAPI_ISteamController_GetConnectedControllers(IntPtr P_0, IntPtr P_1)
			{
				return jTGlEFWKwiZfzxgKhdoGaQiDOJSB(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_ShowBindingPanel")]
			private static extern bool gBRwkOkglqnjTlrnIbLSiacdZAg(IntPtr P_0, ulong P_1);

			public override bool SteamAPI_ISteamController_ShowBindingPanel(IntPtr P_0, ulong P_1)
			{
				return gBRwkOkglqnjTlrnIbLSiacdZAg(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetActionSetHandle")]
			private static extern ulong dIUgXuuufpsdbDXOwiRSWtpMzaR(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamController_GetActionSetHandle(IntPtr P_0, string P_1)
			{
				return dIUgXuuufpsdbDXOwiRSWtpMzaR(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_ActivateActionSet")]
			private static extern void MMLAaBPBPsqpLQdXISukfbxlKqJ(IntPtr P_0, ulong P_1, ulong P_2);

			public override void SteamAPI_ISteamController_ActivateActionSet(IntPtr P_0, ulong P_1, ulong P_2)
			{
				MMLAaBPBPsqpLQdXISukfbxlKqJ(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetCurrentActionSet")]
			private static extern ulong YXmpVnGdZbuogInEHODbpauKCef(IntPtr P_0, ulong P_1);

			public override ulong SteamAPI_ISteamController_GetCurrentActionSet(IntPtr P_0, ulong P_1)
			{
				return YXmpVnGdZbuogInEHODbpauKCef(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionHandle")]
			private static extern ulong llqFhAjAfUnFAHCIqiIBraiYiXuL(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamController_GetDigitalActionHandle(IntPtr P_0, string P_1)
			{
				return llqFhAjAfUnFAHCIqiIBraiYiXuL(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionData")]
			private static extern MqFYeVKLxsquTeQxKQymlVUJzEo LnDcAUuCPKntNUMPPPgkXwoCylX(IntPtr P_0, ulong P_1, ulong P_2);

			public override MqFYeVKLxsquTeQxKQymlVUJzEo SteamAPI_ISteamController_GetDigitalActionData(IntPtr P_0, ulong P_1, ulong P_2)
			{
				return LnDcAUuCPKntNUMPPPgkXwoCylX(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins")]
			private static extern int aOaHIqjvoBRKKRGVPwBKHSaCEhl(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4);

			public override int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4)
			{
				return aOaHIqjvoBRKKRGVPwBKHSaCEhl(P_0, P_1, P_2, P_3, ref P_4);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins")]
			private static extern int aOaHIqjvoBRKKRGVPwBKHSaCEhl(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4);

			public override int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4)
			{
				return aOaHIqjvoBRKKRGVPwBKHSaCEhl(P_0, P_1, P_2, P_3, P_4);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionHandle")]
			private static extern ulong CizAANaAYfvyPjTuyrXXpQzeGOej(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamController_GetAnalogActionHandle(IntPtr P_0, string P_1)
			{
				return CizAANaAYfvyPjTuyrXXpQzeGOej(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionData")]
			private static extern zquCGODUjNomfqDeknGuKrsjOHzX CEYGklXWrXPUovvMAAwooKdxNnL(IntPtr P_0, ulong P_1, ulong P_2);

			public override zquCGODUjNomfqDeknGuKrsjOHzX SteamAPI_ISteamController_GetAnalogActionData(IntPtr P_0, ulong P_1, ulong P_2)
			{
				return CEYGklXWrXPUovvMAAwooKdxNnL(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins")]
			private static extern int TqLdbPcbXRPNoAthDljHUMsOsLI(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4);

			public override int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, ref uint P_4)
			{
				return TqLdbPcbXRPNoAthDljHUMsOsLI(P_0, P_1, P_2, P_3, ref P_4);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins")]
			private static extern int TqLdbPcbXRPNoAthDljHUMsOsLI(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4);

			public override int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr P_0, ulong P_1, ulong P_2, ulong P_3, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_4)
			{
				return TqLdbPcbXRPNoAthDljHUMsOsLI(P_0, P_1, P_2, P_3, P_4);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_StopAnalogActionMomentum")]
			private static extern void bFKfxgwJHyMJKGGIdTfGYziyDGT(IntPtr P_0, ulong P_1, ulong P_2);

			public override void SteamAPI_ISteamController_StopAnalogActionMomentum(IntPtr P_0, ulong P_1, ulong P_2)
			{
				bFKfxgwJHyMJKGGIdTfGYziyDGT(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamController_TriggerHapticPulse")]
			private static extern void qgSDhkkSqzMLWkoAhDyiHrFZfNlM(IntPtr P_0, ulong P_1, uint P_2, ushort P_3);

			public override void SteamAPI_ISteamController_TriggerHapticPulse(IntPtr P_0, ulong P_1, uint P_2, ushort P_3)
			{
				qgSDhkkSqzMLWkoAhDyiHrFZfNlM(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetHSteamUser")]
			private static extern uint WyNsuHbLzYUqLiKPNhjlaFKlaefO(IntPtr P_0);

			public override uint SteamAPI_ISteamUser_GetHSteamUser(IntPtr P_0)
			{
				return WyNsuHbLzYUqLiKPNhjlaFKlaefO(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_BLoggedOn")]
			private static extern bool juSqUVRAAsElXcHBzDntaLnkiITX(IntPtr P_0);

			public override bool SteamAPI_ISteamUser_BLoggedOn(IntPtr P_0)
			{
				return juSqUVRAAsElXcHBzDntaLnkiITX(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetSteamID")]
			private static extern ulong ozXcSncKRvFSdOCSPajgWwdRpiV(IntPtr P_0);

			public override ulong SteamAPI_ISteamUser_GetSteamID(IntPtr P_0)
			{
				return ozXcSncKRvFSdOCSPajgWwdRpiV(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_InitiateGameConnection")]
			private static extern int sDOhRxKeerZrPfmlaLtpGYRSoWb(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3, uint P_4, char P_5, bool P_6);

			public override int SteamAPI_ISteamUser_InitiateGameConnection(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3, uint P_4, char P_5, bool P_6)
			{
				return sDOhRxKeerZrPfmlaLtpGYRSoWb(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_TerminateGameConnection")]
			private static extern void KfFTaxslYqvJWzYCFHVPLOsLAzOi(IntPtr P_0, uint P_1, char P_2);

			public override void SteamAPI_ISteamUser_TerminateGameConnection(IntPtr P_0, uint P_1, char P_2)
			{
				KfFTaxslYqvJWzYCFHVPLOsLAzOi(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_TrackAppUsageEvent")]
			private static extern void vGHEQSpXmHRmRaklejyuBPGNoGie(IntPtr P_0, ulong P_1, int P_2, string P_3);

			public override void SteamAPI_ISteamUser_TrackAppUsageEvent(IntPtr P_0, ulong P_1, int P_2, string P_3)
			{
				vGHEQSpXmHRmRaklejyuBPGNoGie(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetUserDataFolder")]
			private static extern bool PMLlkltdcuBHppJbGwcQXpmMdqX(IntPtr P_0, string P_1, int P_2);

			public override bool SteamAPI_ISteamUser_GetUserDataFolder(IntPtr P_0, string P_1, int P_2)
			{
				return PMLlkltdcuBHppJbGwcQXpmMdqX(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_StartVoiceRecording")]
			private static extern void KFJbFlebBVBpOWGXmPTurvbwunx(IntPtr P_0);

			public override void SteamAPI_ISteamUser_StartVoiceRecording(IntPtr P_0)
			{
				KFJbFlebBVBpOWGXmPTurvbwunx(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_StopVoiceRecording")]
			private static extern void NEgZJPZiluZypZlKQhKjquVsHKO(IntPtr P_0);

			public override void SteamAPI_ISteamUser_StopVoiceRecording(IntPtr P_0)
			{
				NEgZJPZiluZypZlKQhKjquVsHKO(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetAvailableVoice")]
			private static extern uint UmgYJYxKSgefwQoLqcgebxtMYuH(IntPtr P_0, ref uint P_1, ref uint P_2, uint P_3);

			public override uint SteamAPI_ISteamUser_GetAvailableVoice(IntPtr P_0, ref uint P_1, ref uint P_2, uint P_3)
			{
				return UmgYJYxKSgefwQoLqcgebxtMYuH(P_0, ref P_1, ref P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetVoice")]
			private static extern uint wJcNUgnJRicrNglvrYoiaFoAgnPd(IntPtr P_0, bool P_1, IntPtr P_2, uint P_3, ref uint P_4, bool P_5, IntPtr P_6, uint P_7, ref uint P_8, uint P_9);

			public override uint SteamAPI_ISteamUser_GetVoice(IntPtr P_0, bool P_1, IntPtr P_2, uint P_3, ref uint P_4, bool P_5, IntPtr P_6, uint P_7, ref uint P_8, uint P_9)
			{
				return wJcNUgnJRicrNglvrYoiaFoAgnPd(P_0, P_1, P_2, P_3, ref P_4, P_5, P_6, P_7, ref P_8, P_9);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_DecompressVoice")]
			private static extern uint lJbgIFtuZBYEtcJQBiyUxbdwQCC(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, uint P_4, ref uint P_5, uint P_6);

			public override uint SteamAPI_ISteamUser_DecompressVoice(IntPtr P_0, IntPtr P_1, uint P_2, IntPtr P_3, uint P_4, ref uint P_5, uint P_6)
			{
				return lJbgIFtuZBYEtcJQBiyUxbdwQCC(P_0, P_1, P_2, P_3, P_4, ref P_5, P_6);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetVoiceOptimalSampleRate")]
			private static extern uint RkumCMmqCwbtMAQOLiybFEUOXaYr(IntPtr P_0);

			public override uint SteamAPI_ISteamUser_GetVoiceOptimalSampleRate(IntPtr P_0)
			{
				return RkumCMmqCwbtMAQOLiybFEUOXaYr(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetAuthSessionTicket")]
			private static extern uint yrwfcnfzFmywGnQtawiEFUUIJCnL(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3);

			public override uint SteamAPI_ISteamUser_GetAuthSessionTicket(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3)
			{
				return yrwfcnfzFmywGnQtawiEFUUIJCnL(P_0, P_1, P_2, ref P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_BeginAuthSession")]
			private static extern uint HnHnAxuFUTBHGOnrriaLnqyXETN(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3);

			public override uint SteamAPI_ISteamUser_BeginAuthSession(IntPtr P_0, IntPtr P_1, int P_2, ulong P_3)
			{
				return HnHnAxuFUTBHGOnrriaLnqyXETN(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_EndAuthSession")]
			private static extern void EZenKMHKZDOSwHonlOykMHGiSVt(IntPtr P_0, ulong P_1);

			public override void SteamAPI_ISteamUser_EndAuthSession(IntPtr P_0, ulong P_1)
			{
				EZenKMHKZDOSwHonlOykMHGiSVt(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_CancelAuthTicket")]
			private static extern void bbXCXRTLqyoiTIFRkMTpOZNJCdu(IntPtr P_0, uint P_1);

			public override void SteamAPI_ISteamUser_CancelAuthTicket(IntPtr P_0, uint P_1)
			{
				bbXCXRTLqyoiTIFRkMTpOZNJCdu(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_UserHasLicenseForApp")]
			private static extern uint ZyUBBuzXPyHEEpajzGjdKYWffqUB(IntPtr P_0, ulong P_1, uint P_2);

			public override uint SteamAPI_ISteamUser_UserHasLicenseForApp(IntPtr P_0, ulong P_1, uint P_2)
			{
				return ZyUBBuzXPyHEEpajzGjdKYWffqUB(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_BIsBehindNAT")]
			private static extern bool lQqLcsCJgskeNaGSUiMPxSuzHRD(IntPtr P_0);

			public override bool SteamAPI_ISteamUser_BIsBehindNAT(IntPtr P_0)
			{
				return lQqLcsCJgskeNaGSUiMPxSuzHRD(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_AdvertiseGame")]
			private static extern void JElHDeKxriRFbCZBlERIYDOzmaV(IntPtr P_0, ulong P_1, uint P_2, char P_3);

			public override void SteamAPI_ISteamUser_AdvertiseGame(IntPtr P_0, ulong P_1, uint P_2, char P_3)
			{
				JElHDeKxriRFbCZBlERIYDOzmaV(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_RequestEncryptedAppTicket")]
			private static extern ulong RLtIkIrPqpStcGNCUKUhLnlvHCe(IntPtr P_0, IntPtr P_1, int P_2);

			public override ulong SteamAPI_ISteamUser_RequestEncryptedAppTicket(IntPtr P_0, IntPtr P_1, int P_2)
			{
				return RLtIkIrPqpStcGNCUKUhLnlvHCe(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetEncryptedAppTicket")]
			private static extern bool AjEHOefXzoJYZTKEMgWWqMFADMx(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3);

			public override bool SteamAPI_ISteamUser_GetEncryptedAppTicket(IntPtr P_0, IntPtr P_1, int P_2, ref uint P_3)
			{
				return AjEHOefXzoJYZTKEMgWWqMFADMx(P_0, P_1, P_2, ref P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetGameBadgeLevel")]
			private static extern int YxGAxVAGdfPfcOzlDTSiRDNhuMa(IntPtr P_0, int P_1, bool P_2);

			public override int SteamAPI_ISteamUser_GetGameBadgeLevel(IntPtr P_0, int P_1, bool P_2)
			{
				return YxGAxVAGdfPfcOzlDTSiRDNhuMa(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_GetPlayerSteamLevel")]
			private static extern int RUaGgiHvfNRiwzvnvTiZjVNJTWv(IntPtr P_0);

			public override int SteamAPI_ISteamUser_GetPlayerSteamLevel(IntPtr P_0)
			{
				return RUaGgiHvfNRiwzvnvTiZjVNJTWv(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUser_RequestStoreAuthURL")]
			private static extern ulong oAadbcKjTGdfKsWDrHDLCxbuETAh(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamUser_RequestStoreAuthURL(IntPtr P_0, string P_1)
			{
				return oAadbcKjTGdfKsWDrHDLCxbuETAh(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceAppActive")]
			private static extern uint BsmqwTkUOWRzgxIOYRGixwIwqow(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetSecondsSinceAppActive(IntPtr P_0)
			{
				return BsmqwTkUOWRzgxIOYRGixwIwqow(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceComputerActive")]
			private static extern uint GJfCJBpVQmSbbYWjrfciltfAMLv(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetSecondsSinceComputerActive(IntPtr P_0)
			{
				return GJfCJBpVQmSbbYWjrfciltfAMLv(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetConnectedUniverse")]
			private static extern int xOlrkIRpXCGSiccxdLYrGbsMaFxm(IntPtr P_0);

			public override int SteamAPI_ISteamUtils_GetConnectedUniverse(IntPtr P_0)
			{
				return xOlrkIRpXCGSiccxdLYrGbsMaFxm(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetServerRealTime")]
			private static extern uint UuEsDIxWWcMYmeMAsAtcYgqivft(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetServerRealTime(IntPtr P_0)
			{
				return UuEsDIxWWcMYmeMAsAtcYgqivft(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetIPCountry")]
			private static extern IntPtr FouoBgAVfdolUeERupBoJBrPosh(IntPtr P_0);

			public override IntPtr SteamAPI_ISteamUtils_GetIPCountry(IntPtr P_0)
			{
				return FouoBgAVfdolUeERupBoJBrPosh(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetImageSize")]
			private static extern bool tqMIpUezgRPetgcSHTRmrYsODUO(IntPtr P_0, int P_1, ref uint P_2, ref uint P_3);

			public override bool SteamAPI_ISteamUtils_GetImageSize(IntPtr P_0, int P_1, ref uint P_2, ref uint P_3)
			{
				return tqMIpUezgRPetgcSHTRmrYsODUO(P_0, P_1, ref P_2, ref P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetImageRGBA")]
			private static extern bool bpplqFjTuIlPtruLmOOAeapvPSc(IntPtr P_0, int P_1, IntPtr P_2, int P_3);

			public override bool SteamAPI_ISteamUtils_GetImageRGBA(IntPtr P_0, int P_1, IntPtr P_2, int P_3)
			{
				return bpplqFjTuIlPtruLmOOAeapvPSc(P_0, P_1, P_2, P_3);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetCSERIPPort")]
			private static extern bool FbnWugycHxlhbDxCFZAWjTssPUa(IntPtr P_0, ref uint P_1, ref char P_2);

			public override bool SteamAPI_ISteamUtils_GetCSERIPPort(IntPtr P_0, ref uint P_1, ref char P_2)
			{
				return FbnWugycHxlhbDxCFZAWjTssPUa(P_0, ref P_1, ref P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetCurrentBatteryPower")]
			private static extern byte KHEMOidGoMQcEZATHSpBOaMXhSz(IntPtr P_0);

			public override byte SteamAPI_ISteamUtils_GetCurrentBatteryPower(IntPtr P_0)
			{
				return KHEMOidGoMQcEZATHSpBOaMXhSz(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetAppID")]
			private static extern uint whRTMWfeKTsRTsfNTwZUQnqYHNT(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetAppID(IntPtr P_0)
			{
				return whRTMWfeKTsRTsfNTwZUQnqYHNT(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationPosition")]
			private static extern void nLDhRTAPWVrhusVVMBDGiokrJpnC(IntPtr P_0, uint P_1);

			public override void SteamAPI_ISteamUtils_SetOverlayNotificationPosition(IntPtr P_0, uint P_1)
			{
				nLDhRTAPWVrhusVVMBDGiokrJpnC(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_IsAPICallCompleted")]
			private static extern bool nNQGOgNjnnCOPJxWcRZobyhYEcMn(IntPtr P_0, ulong P_1, ref bool P_2);

			public override bool SteamAPI_ISteamUtils_IsAPICallCompleted(IntPtr P_0, ulong P_1, ref bool P_2)
			{
				return nNQGOgNjnnCOPJxWcRZobyhYEcMn(P_0, P_1, ref P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetAPICallFailureReason")]
			private static extern int hSDIlSEVPOXTKlNjGmzWdUDnkNQ(IntPtr P_0, ulong P_1);

			public override int SteamAPI_ISteamUtils_GetAPICallFailureReason(IntPtr P_0, ulong P_1)
			{
				return hSDIlSEVPOXTKlNjGmzWdUDnkNQ(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetAPICallResult")]
			private static extern bool xEzjxhHKLXakrgSaAxWCwwrOXoWl(IntPtr P_0, ulong P_1, IntPtr P_2, int P_3, int P_4, ref bool P_5);

			public override bool SteamAPI_ISteamUtils_GetAPICallResult(IntPtr P_0, ulong P_1, IntPtr P_2, int P_3, int P_4, ref bool P_5)
			{
				return xEzjxhHKLXakrgSaAxWCwwrOXoWl(P_0, P_1, P_2, P_3, P_4, ref P_5);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetIPCCallCount")]
			private static extern uint LsHPMyyTXncLzVscEaQkUQJjWwt(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetIPCCallCount(IntPtr P_0)
			{
				return LsHPMyyTXncLzVscEaQkUQJjWwt(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_SetWarningMessageHook")]
			private static extern void CmUaweAnupVxpxFBMcbCTzkiTfP(IntPtr P_0, IntPtr P_1);

			public override void SteamAPI_ISteamUtils_SetWarningMessageHook(IntPtr P_0, IntPtr P_1)
			{
				CmUaweAnupVxpxFBMcbCTzkiTfP(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_IsOverlayEnabled")]
			private static extern bool CoMcszQLuEAdPzDlqdzIwvmJhTwH(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsOverlayEnabled(IntPtr P_0)
			{
				return CoMcszQLuEAdPzDlqdzIwvmJhTwH(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_BOverlayNeedsPresent")]
			private static extern bool ZdqgRROeNszUUcRTTXGKvUxjCwI(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_BOverlayNeedsPresent(IntPtr P_0)
			{
				return ZdqgRROeNszUUcRTTXGKvUxjCwI(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_CheckFileSignature")]
			private static extern ulong LjVyNDdckPqxhzKDgFOigNRVygN(IntPtr P_0, string P_1);

			public override ulong SteamAPI_ISteamUtils_CheckFileSignature(IntPtr P_0, string P_1)
			{
				return LjVyNDdckPqxhzKDgFOigNRVygN(P_0, P_1);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_ShowGamepadTextInput")]
			private static extern bool jISrvoDdcGbpkzjPkjaWgbXjjXF(IntPtr P_0, int P_1, int P_2, string P_3, uint P_4, string P_5);

			public override bool SteamAPI_ISteamUtils_ShowGamepadTextInput(IntPtr P_0, int P_1, int P_2, string P_3, uint P_4, string P_5)
			{
				return jISrvoDdcGbpkzjPkjaWgbXjjXF(P_0, P_1, P_2, P_3, P_4, P_5);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextLength")]
			private static extern uint wIPZlJByfwbDVupyKshCYXNMNld(IntPtr P_0);

			public override uint SteamAPI_ISteamUtils_GetEnteredGamepadTextLength(IntPtr P_0)
			{
				return wIPZlJByfwbDVupyKshCYXNMNld(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextInput")]
			private static extern bool abOBaHKpmykjWbNIsqpAvsKSFajZ(IntPtr P_0, string P_1, uint P_2);

			public override bool SteamAPI_ISteamUtils_GetEnteredGamepadTextInput(IntPtr P_0, string P_1, uint P_2)
			{
				return abOBaHKpmykjWbNIsqpAvsKSFajZ(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_GetSteamUILanguage")]
			private static extern IntPtr ubdtMGXApjjURbeXTlvFpuWfhWrS(IntPtr P_0);

			public override IntPtr SteamAPI_ISteamUtils_GetSteamUILanguage(IntPtr P_0)
			{
				return ubdtMGXApjjURbeXTlvFpuWfhWrS(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningInVR")]
			private static extern bool mKkQFYebFzBTxcQuuItuHwiOoJvk(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsSteamRunningInVR(IntPtr P_0)
			{
				return mKkQFYebFzBTxcQuuItuHwiOoJvk(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationInset")]
			private static extern void DYeXsDWoaHkfNjcnqCBMjAXvzWnp(IntPtr P_0, int P_1, int P_2);

			public override void SteamAPI_ISteamUtils_SetOverlayNotificationInset(IntPtr P_0, int P_1, int P_2)
			{
				DYeXsDWoaHkfNjcnqCBMjAXvzWnp(P_0, P_1, P_2);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_IsSteamInBigPictureMode")]
			private static extern bool YLgHOzUDIpTQMGIEebuPBcueRHQ(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsSteamInBigPictureMode(IntPtr P_0)
			{
				return YLgHOzUDIpTQMGIEebuPBcueRHQ(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_StartVRDashboard")]
			private static extern void JkZomBxpuwqgwiSlEmtMPiHvWwy(IntPtr P_0);

			public override void SteamAPI_ISteamUtils_StartVRDashboard(IntPtr P_0)
			{
				JkZomBxpuwqgwiSlEmtMPiHvWwy(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled")]
			private static extern bool qUpshSBgZyrpldQaLPTZcSdBYOa(IntPtr P_0);

			public override bool SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled(IntPtr P_0)
			{
				return qUpshSBgZyrpldQaLPTZcSdBYOa(P_0);
			}

			[DllImport("steam_api64", EntryPoint = "SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled")]
			private static extern void MFHPQSTSVSRCzznFRTzfqmqMoCm(IntPtr P_0, bool P_1);

			public override void SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled(IntPtr P_0, bool P_1)
			{
				MFHPQSTSVSRCzznFRTzfqmqMoCm(P_0, P_1);
			}
		}

		public const string YjbgwtwGpRzjbuGiCSdoSmuxuFe = "steam_api64";

		public static bool hXpHtBuijEDJvGwJAKyobUHfOXu()
		{
			return xQvVNzClYUopwSIrAMXNAgvWqF.hXpHtBuijEDJvGwJAKyobUHfOXu();
		}
	}

	private class mFYZExXetZaHadNGAtnPcMScPdOW
	{
		public const int pDAaySGsfYqYXrIUYhcJPdbsenph = 100;

		public const int fPoYTyPunNInEpfEKrVvwXXjKFl = 200;

		public const int sDDwdlSjYjwaizkXHqRkZQqJuOW = 300;

		public const int shthQvvrovvjryacjeJKBeZYSRV = 400;

		public const int ThOGISokCDaGToLwOziFzjKoBKM = 500;

		public const int CpaqmizxKQmBZsLqRLibnlEwUIt = 600;

		public const int iQuGQxaDArYlWpOYXkZuutCnucp = 700;

		public const int ccAzCcrMnNkMLTEznURZncBkMAh = 800;

		public const int jHtzSohZoerqIzomMmhZYmZimwb = 900;

		public const int IbMiRrjuSFcrkIWzTxGAEUuNFSi = 1000;

		public const int fYcEOhcEBABbDGBoKIRLNbyBgrV = 1100;

		public const int YdYHdkqseRcRcXqQpidUyVkxDzh = 1200;

		public const int SkHHAXWsdlJfpzShWLqOLSBerNp = 1300;

		public const int PYVQNBVzNUsIKnBRPnlNIahjhbG = 1400;

		public const int tibflAQMjEdkgzYchgHEysGOFuu = 1500;

		public const int pVfecREWaWIfHoiVRLAADmwIbaBq = 1600;

		public const int vaFNoWTROQXxbUUdqmsvaqlMFpA = 1700;

		public const int cNwQtDxBWUxanIOpoAUQazONWy = 1800;

		public const int QfiMYJctXGbiTYmmpOXCpHNOsjr = 1900;

		public const int HgFEimDitIJLDJlLHCWEnvXSZtoa = 2000;

		public const int gscKPhnrmJZhZWhSRgJUpUOijnf = 2100;

		public const int QnGPWSzPNdkhvYLoEdCVDKjROXuk = 2200;

		public const int MgDGkVECHCFiKNxsZvGzvhHTOXJ = 2300;

		public const int AMltQIzGszCrnkTpOMbFgvVTrSwP = 2400;

		public const int BHwdurcLTFXlfPLcFsmQGMaasFc = 2500;

		public const int SbDXsmbWeuJWHpfwSsmruYAFKym = 2600;

		public const int hDTPlsEHfRPBMlzPJdVDidTBBZG = 2700;

		public const int aHQrOvtjCYbgmlcMIczVyteaOZs = 2800;

		public const int RfehihacjuTIOEkZxEGrYWgNqlLW = 2900;

		public const int oWdpTKgeSLfAfWHwFLksDHUIEPc = 3000;

		public const int rzBcDsgnglXIRJitoQGIwPqIMmD = 3100;

		public const int zxnENJJsBEvCeEdrhRUmOFwhprFJ = 3200;

		public const int fAkfEfOhtCuXzAYsadNdjDGjpGA = 3300;

		public const int ZBVBxEcRpWRfriIZbzkgQjIymxKp = 3400;

		public const int wHKkRWUhvpLLETGvjICoUXUiyXP = 3500;

		public const int XSbsAFwoMyADgfiTvrEcdkRYGCvj = 3600;

		public const int PebcwvbAXuPllyVcuxpBSSJEZCA = 3700;

		public const int QjWzaaojhxyAWWBiatBwztFdGQX = 3800;

		public const int ygdOQgEoNpiHzghdslOgOIHefKr = 3900;

		public const int yIozQuhLjYCkGgtaVfMekInTBOxC = 4000;

		public const int kEOGxwNClQPcGgBvnAZCEmCiIfMU = 4100;

		public const int ucAuDAvbEpaxnhscpAAkHWdaYpnR = 4200;

		public const int meyPrlrLOgaiAEvVIdUqjPpnKGyj = 4300;

		public const int oHFtEGBSbcRBQSmMCzAvAsjfihJ = 4400;

		public const int lvyeIeeWBOHknsQQRebGkrKprfc = 4500;

		public const int lhbUhCzxRJKkCbrXCFzDlUAHSOo = 4600;

		public const int lESLvoDepWAzhCJYXytmmolBgWBn = 4700;

		public const int iexfbTXPPaWGESoAUdEBvqctqUJ = 4800;

		public const int uLxjgLsmwswrRXIUhAqYTDYLHMs = 4900;

		public const int JBYGBhjTQmdwnSqiJsyvOyOHBecd = 5000;

		public const int RjsugmnLmMPnqPlnMlvQZCIQElri = 5100;

		public const int WKCuNFHoNNOJHOpvYCuojKhreBQF = 128;

		public const int wdzCaAfNGNPkxgUEeBtjtdlBHdNk = 32;

		public const int vxZiVGEtGTFmBGVcDlnxmcYCuBW = 20;

		public const int xLAqXpgoBLgqHkDyThBMjrfchkr = 64;

		public const int HdujnziEuImVqyyCmOhqASePop = 256;

		public const int JNBxsjBijUaPwfuzZitNdFKAmwlN = 128;

		public const int eGduPbGkXHereSvRgMjxdqIvgOG = 128;

		public const int yJhHMxtUUTtgfzJuGnSGMEMCEBC = 64;

		public const ulong LkffDzirnwMIaeJxPDeOJTdOhPuk = ulong.MaxValue;

		public const int oGxhgFTpuJlPchNUxIPiVULxNbj = -1;

		private static QnVApXaxRrDcfsGrGeycsynQwiyj NycrgTIEKWjGkkIaoqAAFWIZLkog;

		private static iwqQjqDpTpGbOoMZFanCpZyxWvX jTBEHGdlreqfoBUBbEkFhVThdKFc;

		private static vpCTbTysCEwsbLaIYtojpIqRGKK fYvprpDtXkJEZEfdYKdtUDjxZZe;

		private static KgGXcGSkvujYQLBVrjgeJfXjNnv YJvTAsvzBKqYufrsorHzgJqVYYu;

		private static mdVeXsRjkujfhoLTaAXdEcETjmaM bIXOxwNtuTAVaXTCbEnZwzFxXpa;

		public static iwqQjqDpTpGbOoMZFanCpZyxWvX steamClient
		{
			get
			{
				return jTBEHGdlreqfoBUBbEkFhVThdKFc;
			}
		}

		public static vpCTbTysCEwsbLaIYtojpIqRGKK steamUser
		{
			get
			{
				return fYvprpDtXkJEZEfdYKdtUDjxZZe;
			}
		}

		public static KgGXcGSkvujYQLBVrjgeJfXjNnv steamUtils
		{
			get
			{
				return YJvTAsvzBKqYufrsorHzgJqVYYu;
			}
		}

		public static mdVeXsRjkujfhoLTaAXdEcETjmaM steamController
		{
			get
			{
				return bIXOxwNtuTAVaXTCbEnZwzFxXpa;
			}
		}

		private static void bVJfbjSJHtCUhxVYYaQYFCJuPMDE()
		{
			jTBEHGdlreqfoBUBbEkFhVThdKFc = null;
			fYvprpDtXkJEZEfdYKdtUDjxZZe = null;
			YJvTAsvzBKqYufrsorHzgJqVYYu = null;
			bIXOxwNtuTAVaXTCbEnZwzFxXpa = null;
		}

		public static bool gRZcVtephTEHZvTXJFpoYOeTypkH()
		{
			bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
			uint num = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_GetHSteamPipe();
			if (num == 0)
			{
				return false;
			}
			NycrgTIEKWjGkkIaoqAAFWIZLkog = new QnVApXaxRrDcfsGrGeycsynQwiyj(num);
			IntPtr intPtr = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamClient();
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			jTBEHGdlreqfoBUBbEkFhVThdKFc = new tqUACKbiybNzsBHbRwYxtZUuXTb(intPtr);
			uint num2 = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_GetHSteamUser();
			if (num2 == 0)
			{
				return false;
			}
			fYvprpDtXkJEZEfdYKdtUDjxZZe = new piLmBCNajyHwLLIwJzLgkdyAbtm(new IntPtr((int)num2));
			IntPtr intPtr2 = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_GetISteamUtils(jTBEHGdlreqfoBUBbEkFhVThdKFc.GetIntPtr(), (uint)NycrgTIEKWjGkkIaoqAAFWIZLkog, "SteamUtils009");
			if (intPtr2 == IntPtr.Zero)
			{
				return false;
			}
			YJvTAsvzBKqYufrsorHzgJqVYYu = new BAUainJCvHOIMuoYhaKlGULXUCbp(intPtr2);
			IntPtr intPtr3 = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_GetISteamController(jTBEHGdlreqfoBUBbEkFhVThdKFc.GetIntPtr(), (uint)(int)fYvprpDtXkJEZEfdYKdtUDjxZZe.GetIntPtr(), (uint)NycrgTIEKWjGkkIaoqAAFWIZLkog, "SteamController006");
			if (intPtr3 == IntPtr.Zero)
			{
				return false;
			}
			bIXOxwNtuTAVaXTCbEnZwzFxXpa = new bPPfoDdUeEbqysrxltymPlyIrzK(intPtr3);
			return true;
		}

		public static void YUULqHZoRrEYiYtaGEUfkkfBhmb()
		{
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_RunCallbacks();
		}

		public static void bEhWsPwXElwsJSvpTpaKxwymGHw(IntPtr P_0, int P_1)
		{
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_RegisterCallback(P_0, P_1);
		}

		public static void GOtnqQXVdwilaaHGxKNemTrfAMk(IntPtr P_0)
		{
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_UnregisterCallback(P_0);
		}
	}

	private class tqUACKbiybNzsBHbRwYxtZUuXTb : iwqQjqDpTpGbOoMZFanCpZyxWvX
	{
		private IntPtr rSMPIeHrJlxqDcuhwGjncbkyymB;

		public tqUACKbiybNzsBHbRwYxtZUuXTb(IntPtr SteamClient)
		{
			rSMPIeHrJlxqDcuhwGjncbkyymB = SteamClient;
		}

		public override IntPtr GetIntPtr()
		{
			return rSMPIeHrJlxqDcuhwGjncbkyymB;
		}

		private void XjjtZnKXJbeBTJvjbNCjGghTUhw()
		{
			if (rSMPIeHrJlxqDcuhwGjncbkyymB == IntPtr.Zero)
			{
				throw new Exception("Steam Pointer not configured");
			}
		}

		public override uint CreateSteamPipe()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_CreateSteamPipe(rSMPIeHrJlxqDcuhwGjncbkyymB);
		}

		public override bool BReleaseSteamPipe(uint P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_BReleaseSteamPipe(rSMPIeHrJlxqDcuhwGjncbkyymB, P_0);
		}

		public override uint ConnectToGlobalUser(uint P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_ConnectToGlobalUser(rSMPIeHrJlxqDcuhwGjncbkyymB, P_0);
		}

		public override uint CreateLocalUser(ref uint P_0, uint P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_0 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_CreateLocalUser(rSMPIeHrJlxqDcuhwGjncbkyymB, ref P_0, P_1);
		}

		public override void ReleaseUser(uint P_0, uint P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_ReleaseUser(rSMPIeHrJlxqDcuhwGjncbkyymB, P_0, P_1);
		}

		public override vpCTbTysCEwsbLaIYtojpIqRGKK GetISteamUser(uint P_0, uint P_1, string P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			IntPtr steamUser = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_GetISteamUser(rSMPIeHrJlxqDcuhwGjncbkyymB, P_0, P_1, P_2);
			return new piLmBCNajyHwLLIwJzLgkdyAbtm(steamUser);
		}

		public override KgGXcGSkvujYQLBVrjgeJfXjNnv GetISteamUtils(uint P_0, string P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			IntPtr steamUtils = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_GetISteamUtils(rSMPIeHrJlxqDcuhwGjncbkyymB, P_0, P_1);
			return new BAUainJCvHOIMuoYhaKlGULXUCbp(steamUtils);
		}

		public override mdVeXsRjkujfhoLTaAXdEcETjmaM GetISteamController(uint P_0, uint P_1, string P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			IntPtr steamController = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamClient_GetISteamController(rSMPIeHrJlxqDcuhwGjncbkyymB, P_0, P_1, P_2);
			return new bPPfoDdUeEbqysrxltymPlyIrzK(steamController);
		}
	}

	private class piLmBCNajyHwLLIwJzLgkdyAbtm : vpCTbTysCEwsbLaIYtojpIqRGKK
	{
		private IntPtr SjfIgtHzkmnaGfHTKMexfeUvrJc;

		public piLmBCNajyHwLLIwJzLgkdyAbtm(IntPtr SteamUser)
		{
			SjfIgtHzkmnaGfHTKMexfeUvrJc = SteamUser;
		}

		public override IntPtr GetIntPtr()
		{
			return SjfIgtHzkmnaGfHTKMexfeUvrJc;
		}

		private void XjjtZnKXJbeBTJvjbNCjGghTUhw()
		{
			if (SjfIgtHzkmnaGfHTKMexfeUvrJc == IntPtr.Zero)
			{
				throw new Exception("Steam Pointer not configured");
			}
		}

		public override uint GetHSteamUser()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetHSteamUser(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override bool BLoggedOn()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_BLoggedOn(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override ulong GetSteamID()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetSteamID(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override int InitiateGameConnection(IntPtr P_0, int P_1, ulong P_2, uint P_3, char P_4, bool P_5)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_InitiateGameConnection(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, P_2, P_3, P_4, P_5);
		}

		public override void TerminateGameConnection(uint P_0, char P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_TerminateGameConnection(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1);
		}

		public override void TrackAppUsageEvent(ulong P_0, int P_1, string P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_TrackAppUsageEvent(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, P_2);
		}

		public override bool GetUserDataFolder(string P_0, int P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetUserDataFolder(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1);
		}

		public override void StartVoiceRecording()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_StartVoiceRecording(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override void StopVoiceRecording()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_StopVoiceRecording(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override uint GetAvailableVoice(ref uint P_0, ref uint P_1, uint P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_0 = 0u;
			P_1 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetAvailableVoice(SjfIgtHzkmnaGfHTKMexfeUvrJc, ref P_0, ref P_1, P_2);
		}

		public override uint GetVoice(bool P_0, IntPtr P_1, uint P_2, ref uint P_3, bool P_4, IntPtr P_5, uint P_6, ref uint P_7, uint P_8)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_3 = 0u;
			P_7 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetVoice(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, P_2, ref P_3, P_4, P_5, P_6, ref P_7, P_8);
		}

		public override uint DecompressVoice(IntPtr P_0, uint P_1, IntPtr P_2, uint P_3, ref uint P_4, uint P_5)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_4 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_DecompressVoice(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, P_2, P_3, ref P_4, P_5);
		}

		public override uint GetVoiceOptimalSampleRate()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetVoiceOptimalSampleRate(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override uint GetAuthSessionTicket(IntPtr P_0, int P_1, ref uint P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_2 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetAuthSessionTicket(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, ref P_2);
		}

		public override uint BeginAuthSession(IntPtr P_0, int P_1, ulong P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_BeginAuthSession(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, P_2);
		}

		public override void EndAuthSession(ulong P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_EndAuthSession(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0);
		}

		public override void CancelAuthTicket(uint P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_CancelAuthTicket(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0);
		}

		public override uint UserHasLicenseForApp(ulong P_0, uint P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_UserHasLicenseForApp(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1);
		}

		public override bool BIsBehindNAT()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_BIsBehindNAT(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override void AdvertiseGame(ulong P_0, uint P_1, char P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_AdvertiseGame(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, P_2);
		}

		public override ulong RequestEncryptedAppTicket(IntPtr P_0, int P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_RequestEncryptedAppTicket(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1);
		}

		public override bool GetEncryptedAppTicket(IntPtr P_0, int P_1, ref uint P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_2 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetEncryptedAppTicket(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1, ref P_2);
		}

		public override int GetGameBadgeLevel(int P_0, bool P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetGameBadgeLevel(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0, P_1);
		}

		public override int GetPlayerSteamLevel()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_GetPlayerSteamLevel(SjfIgtHzkmnaGfHTKMexfeUvrJc);
		}

		public override ulong RequestStoreAuthURL(string P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUser_RequestStoreAuthURL(SjfIgtHzkmnaGfHTKMexfeUvrJc, P_0);
		}
	}

	private class bPPfoDdUeEbqysrxltymPlyIrzK : mdVeXsRjkujfhoLTaAXdEcETjmaM
	{
		private IntPtr NwHCDBqLyfVoMXDOrjKmNjRFJso;

		public bPPfoDdUeEbqysrxltymPlyIrzK(IntPtr SteamController)
		{
			NwHCDBqLyfVoMXDOrjKmNjRFJso = SteamController;
		}

		public override IntPtr GetIntPtr()
		{
			return NwHCDBqLyfVoMXDOrjKmNjRFJso;
		}

		private void XjjtZnKXJbeBTJvjbNCjGghTUhw()
		{
			if (NwHCDBqLyfVoMXDOrjKmNjRFJso == IntPtr.Zero)
			{
				throw new Exception("Steam Pointer not configured");
			}
		}

		public override bool Init()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_Init(NwHCDBqLyfVoMXDOrjKmNjRFJso);
		}

		public override bool Shutdown()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_Shutdown(NwHCDBqLyfVoMXDOrjKmNjRFJso);
		}

		public override void RunFrame()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_RunFrame(NwHCDBqLyfVoMXDOrjKmNjRFJso);
		}

		public override int GetConnectedControllers(ulong[] P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetConnectedControllers(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0);
		}

		public override int GetConnectedControllers(IntPtr P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetConnectedControllers(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0);
		}

		public override bool ShowBindingPanel(ulong P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_ShowBindingPanel(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0);
		}

		public override ulong GetActionSetHandle(string P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetActionSetHandle(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0);
		}

		public override void ActivateActionSet(ulong P_0, ulong P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_ActivateActionSet(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1);
		}

		public override ulong GetCurrentActionSet(ulong P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetCurrentActionSet(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0);
		}

		public override ulong GetDigitalActionHandle(string P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetDigitalActionHandle(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0);
		}

		public override MqFYeVKLxsquTeQxKQymlVUJzEo GetDigitalActionData(ulong P_0, ulong P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetDigitalActionData(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1);
		}

		public override int GetDigitalActionOrigins(ulong P_0, ulong P_1, ulong P_2, ref uint P_3)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_3 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetDigitalActionOrigins(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1, P_2, ref P_3);
		}

		public override int GetDigitalActionOrigins(ulong P_0, ulong P_1, ulong P_2, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_3)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetDigitalActionOrigins(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1, P_2, P_3);
		}

		public override ulong GetAnalogActionHandle(string P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetAnalogActionHandle(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0);
		}

		public override zquCGODUjNomfqDeknGuKrsjOHzX GetAnalogActionData(ulong P_0, ulong P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetAnalogActionData(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1);
		}

		public override int GetAnalogActionOrigins(ulong P_0, ulong P_1, ulong P_2, ref uint P_3)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_3 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetAnalogActionOrigins(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1, P_2, ref P_3);
		}

		public override int GetAnalogActionOrigins(ulong P_0, ulong P_1, ulong P_2, gFyhHihEVuYgAHLAzSttsEgFbLwf[] P_3)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_GetAnalogActionOrigins(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1, P_2, P_3);
		}

		public override void StopAnalogActionMomentum(ulong P_0, ulong P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_StopAnalogActionMomentum(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1);
		}

		public override void TriggerHapticPulse(ulong P_0, uint P_1, ushort P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamController_TriggerHapticPulse(NwHCDBqLyfVoMXDOrjKmNjRFJso, P_0, P_1, P_2);
		}
	}

	private class BAUainJCvHOIMuoYhaKlGULXUCbp : KgGXcGSkvujYQLBVrjgeJfXjNnv
	{
		private IntPtr PbZzrzYjzipTbwtvEqIOHXblZpG;

		public BAUainJCvHOIMuoYhaKlGULXUCbp(IntPtr SteamUtils)
		{
			PbZzrzYjzipTbwtvEqIOHXblZpG = SteamUtils;
		}

		public override IntPtr GetIntPtr()
		{
			return PbZzrzYjzipTbwtvEqIOHXblZpG;
		}

		private void XjjtZnKXJbeBTJvjbNCjGghTUhw()
		{
			if (PbZzrzYjzipTbwtvEqIOHXblZpG == IntPtr.Zero)
			{
				throw new Exception("Steam Pointer not configured");
			}
		}

		public override uint GetSecondsSinceAppActive()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetSecondsSinceAppActive(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override uint GetSecondsSinceComputerActive()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetSecondsSinceComputerActive(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override int GetConnectedUniverse()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetConnectedUniverse(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override uint GetServerRealTime()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetServerRealTime(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override string GetIPCountry()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			IntPtr ptr = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetIPCountry(PbZzrzYjzipTbwtvEqIOHXblZpG);
			return Marshal.PtrToStringAnsi(ptr);
		}

		public override bool GetImageSize(int P_0, ref uint P_1, ref uint P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_1 = 0u;
			P_2 = 0u;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetImageSize(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0, ref P_1, ref P_2);
		}

		public override bool GetImageRGBA(int P_0, IntPtr P_1, int P_2)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetImageRGBA(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0, P_1, P_2);
		}

		public override bool GetCSERIPPort(ref uint P_0, ref char P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_0 = 0u;
			P_1 = '\0';
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetCSERIPPort(PbZzrzYjzipTbwtvEqIOHXblZpG, ref P_0, ref P_1);
		}

		public override byte GetCurrentBatteryPower()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetCurrentBatteryPower(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override uint GetAppID()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetAppID(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override void SetOverlayNotificationPosition(uint P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_SetOverlayNotificationPosition(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0);
		}

		public override bool IsAPICallCompleted(ulong P_0, ref bool P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_1 = false;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_IsAPICallCompleted(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0, ref P_1);
		}

		public override int GetAPICallFailureReason(ulong P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetAPICallFailureReason(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0);
		}

		public override bool GetAPICallResult(ulong P_0, IntPtr P_1, int P_2, int P_3, ref bool P_4)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			P_4 = false;
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetAPICallResult(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0, P_1, P_2, P_3, ref P_4);
		}

		public override uint GetIPCCallCount()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetIPCCallCount(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override void SetWarningMessageHook(IntPtr P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_SetWarningMessageHook(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0);
		}

		public override bool IsOverlayEnabled()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_IsOverlayEnabled(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override bool BOverlayNeedsPresent()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_BOverlayNeedsPresent(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override ulong CheckFileSignature(string P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_CheckFileSignature(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0);
		}

		public override bool ShowGamepadTextInput(int P_0, int P_1, string P_2, uint P_3, string P_4)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_ShowGamepadTextInput(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0, P_1, P_2, P_3, P_4);
		}

		public override uint GetEnteredGamepadTextLength()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetEnteredGamepadTextLength(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override bool GetEnteredGamepadTextInput(string P_0, uint P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetEnteredGamepadTextInput(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0, P_1);
		}

		public override string GetSteamUILanguage()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			IntPtr ptr = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_GetSteamUILanguage(PbZzrzYjzipTbwtvEqIOHXblZpG);
			return Marshal.PtrToStringAnsi(ptr);
		}

		public override bool IsSteamRunningInVR()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_IsSteamRunningInVR(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override void SetOverlayNotificationInset(int P_0, int P_1)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_SetOverlayNotificationInset(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0, P_1);
		}

		public override bool IsSteamInBigPictureMode()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_IsSteamInBigPictureMode(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override void StartVRDashboard()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_StartVRDashboard(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override bool IsVRHeadsetStreamingEnabled()
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			return zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_IsVRHeadsetStreamingEnabled(PbZzrzYjzipTbwtvEqIOHXblZpG);
		}

		public override void SetVRHeadsetStreamingEnabled(bool P_0)
		{
			XjjtZnKXJbeBTJvjbNCjGghTUhw();
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_ISteamUtils_SetVRHeadsetStreamingEnabled(PbZzrzYjzipTbwtvEqIOHXblZpG, P_0);
		}
	}

	[Serializable]
	public struct QnVApXaxRrDcfsGrGeycsynQwiyj : IEquatable<QnVApXaxRrDcfsGrGeycsynQwiyj>, IComparable<QnVApXaxRrDcfsGrGeycsynQwiyj>
	{
		public uint m_HSteamPipe;

		public QnVApXaxRrDcfsGrGeycsynQwiyj(uint value)
		{
			m_HSteamPipe = value;
		}

		public override string ToString()
		{
			return m_HSteamPipe.ToString();
		}

		public override bool Equals(object other)
		{
			if (other is QnVApXaxRrDcfsGrGeycsynQwiyj)
			{
				return this == (QnVApXaxRrDcfsGrGeycsynQwiyj)other;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return m_HSteamPipe.GetHashCode();
		}

		public static bool operator ==(QnVApXaxRrDcfsGrGeycsynQwiyj x, QnVApXaxRrDcfsGrGeycsynQwiyj y)
		{
			return x.m_HSteamPipe == y.m_HSteamPipe;
		}

		public static bool operator !=(QnVApXaxRrDcfsGrGeycsynQwiyj x, QnVApXaxRrDcfsGrGeycsynQwiyj y)
		{
			return !(x == y);
		}

		public static explicit operator QnVApXaxRrDcfsGrGeycsynQwiyj(uint value)
		{
			return new QnVApXaxRrDcfsGrGeycsynQwiyj(value);
		}

		public static explicit operator uint(QnVApXaxRrDcfsGrGeycsynQwiyj other)
		{
			return other.m_HSteamPipe;
		}

		public bool Equals(QnVApXaxRrDcfsGrGeycsynQwiyj other)
		{
			return m_HSteamPipe == other.m_HSteamPipe;
		}

		public int CompareTo(QnVApXaxRrDcfsGrGeycsynQwiyj other)
		{
			return m_HSteamPipe.CompareTo(other.m_HSteamPipe);
		}
	}

	private static bool QMigOTjYGmWPIPdOrBUNIKlfGWZ;

	private static bool XugsrESOINHVHebDAupLbovZGTT;

	private static iwqQjqDpTpGbOoMZFanCpZyxWvX mlCSNRExqaBAcNbcnZUKYvCTBRn;

	private static vpCTbTysCEwsbLaIYtojpIqRGKK rPMbTBVvxkygnJqXvAJrBBsydHBB;

	private static mdVeXsRjkujfhoLTaAXdEcETjmaM hXibvYfKIpAvUcyqYQNQfxollZi;

	private static ulong[] UujybNyVEZmKOqAkpmMTmokUBVg;

	private static ulong[] WrbbRlHToNDdiOQmBrjumMkpCjZ;

	private static GCHandle ZgHOMGJnNnxNjToTwWzJJvPjTD;

	private static int slucuYLbzeNQnMefikiqKHMUvDi;

	private static bool xcCbyZgHCynKoTBXLDiHodVtNgAH;

	private static bool icQGrDPZANtCNbZmNwMtIJqmdROh;

	private static ValueWatcher[] BEjiaIJxrLbZVbqYcXLlnQbFYFHf = new ValueWatcher[0];

	private static ValueWatcher<bool> oiLGCoSVZgeKAKLdfRRLvUOQPDvh;

	[CompilerGenerated]
	private static Func<bool> TCMPDTCLteaVWAqHtbclnMHeZaIW;

	public static bool IsReady
	{
		get
		{
			if (!XugsrESOINHVHebDAupLbovZGTT && !GVPNrpnUrcRcuBVNsoUmnQYWdWW())
			{
				return false;
			}
			return IsSteamRunning;
		}
	}

	public static bool IsInitialized
	{
		get
		{
			return XugsrESOINHVHebDAupLbovZGTT;
		}
	}

	internal static mdVeXsRjkujfhoLTaAXdEcETjmaM ControllerManager
	{
		get
		{
			return hXibvYfKIpAvUcyqYQNQfxollZi;
		}
	}

	private static bool IsSteamRunning
	{
		get
		{
			if (icQGrDPZANtCNbZmNwMtIJqmdROh)
			{
				return false;
			}
			if (QMigOTjYGmWPIPdOrBUNIKlfGWZ)
			{
				return true;
			}
			try
			{
				bool qMigOTjYGmWPIPdOrBUNIKlfGWZ = zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_IsSteamRunning();
				QMigOTjYGmWPIPdOrBUNIKlfGWZ = qMigOTjYGmWPIPdOrBUNIKlfGWZ;
				bool qMigOTjYGmWPIPdOrBUNIKlfGWZ2 = QMigOTjYGmWPIPdOrBUNIKlfGWZ;
			}
			catch
			{
				icQGrDPZANtCNbZmNwMtIJqmdROh = true;
			}
			return QMigOTjYGmWPIPdOrBUNIKlfGWZ;
		}
	}

	public static bool GVPNrpnUrcRcuBVNsoUmnQYWdWW()
	{
		if (XugsrESOINHVHebDAupLbovZGTT)
		{
			return IsSteamRunning;
		}
		try
		{
			if (!zyMTepAgZdimisWfgUvUgiAsEyT.GVPNrpnUrcRcuBVNsoUmnQYWdWW())
			{
				throw new Exception("Steam handler could not be initialized");
			}
			if (!IsSteamRunning)
			{
				throw new Exception("Steam is not running");
			}
			zyMTepAgZdimisWfgUvUgiAsEyT.jDNhEWaNZkcGmLuDeACATmLNoeS.SteamAPI_Init();
			if (!mFYZExXetZaHadNGAtnPcMScPdOW.gRZcVtephTEHZvTXJFpoYOeTypkH())
			{
				throw new Exception("SteamAPI.Init() failed.");
			}
			XugsrESOINHVHebDAupLbovZGTT = true;
			List<ValueWatcher> list = new List<ValueWatcher>();
			list.Add(oiLGCoSVZgeKAKLdfRRLvUOQPDvh = new ValueWatcher<bool>(false, () => mFYZExXetZaHadNGAtnPcMScPdOW.steamUtils.IsOverlayEnabled(), true));
			BEjiaIJxrLbZVbqYcXLlnQbFYFHf = list.ToArray();
			return true;
		}
		catch (Exception)
		{
			QMigOTjYGmWPIPdOrBUNIKlfGWZ = false;
			return false;
		}
	}

	public static void EhlPnfprjfkehAbDLrDcQKRlXmc(UpdateLoopType P_0)
	{
		if (XugsrESOINHVHebDAupLbovZGTT && IsSteamRunning)
		{
			for (int i = 0; i < BEjiaIJxrLbZVbqYcXLlnQbFYFHf.Length; i++)
			{
				BEjiaIJxrLbZVbqYcXLlnQbFYFHf[i].Update();
			}
		}
	}

	public static void wfDADgSigMdZYgftIxEIrqdrRXD()
	{
		if (!XugsrESOINHVHebDAupLbovZGTT)
		{
			return;
		}
		try
		{
			if (hXibvYfKIpAvUcyqYQNQfxollZi != null)
			{
				hXibvYfKIpAvUcyqYQNQfxollZi.Shutdown();
				ZgHOMGJnNnxNjToTwWzJJvPjTD.Free();
			}
		}
		catch
		{
		}
	}

	public static bool xwmZfwFNpraYgFWdujgccCWHaqi(ulong P_0)
	{
		QdCabdEOpIZlLTDnQivLKNqOCDw();
		for (int i = 0; i < slucuYLbzeNQnMefikiqKHMUvDi; i++)
		{
			if (UujybNyVEZmKOqAkpmMTmokUBVg[i] == P_0)
			{
				return true;
			}
		}
		return false;
	}

	public static List<SteamControllerInternal> IFvimsjYWfdLqfyaHVBMRxzlcasA()
	{
		QdCabdEOpIZlLTDnQivLKNqOCDw();
		if (slucuYLbzeNQnMefikiqKHMUvDi == 0)
		{
			return new List<SteamControllerInternal>();
		}
		List<SteamControllerInternal> list = new List<SteamControllerInternal>(slucuYLbzeNQnMefikiqKHMUvDi);
		for (int i = 0; i < slucuYLbzeNQnMefikiqKHMUvDi; i++)
		{
			list.Add(new SteamControllerInternal(UujybNyVEZmKOqAkpmMTmokUBVg[i]));
		}
		return list;
	}

	private static void QdCabdEOpIZlLTDnQivLKNqOCDw()
	{
		int num = slucuYLbzeNQnMefikiqKHMUvDi;
		for (int i = 0; i < slucuYLbzeNQnMefikiqKHMUvDi; i++)
		{
			WrbbRlHToNDdiOQmBrjumMkpCjZ[i] = UujybNyVEZmKOqAkpmMTmokUBVg[i];
		}
		slucuYLbzeNQnMefikiqKHMUvDi = hXibvYfKIpAvUcyqYQNQfxollZi.GetConnectedControllers(ZgHOMGJnNnxNjToTwWzJJvPjTD.AddrOfPinnedObject());
		for (int j = 0; j < slucuYLbzeNQnMefikiqKHMUvDi; j++)
		{
		}
		if (SleMWcCikRGJXVXPdftfdpXNikI(slucuYLbzeNQnMefikiqKHMUvDi, num, UujybNyVEZmKOqAkpmMTmokUBVg, WrbbRlHToNDdiOQmBrjumMkpCjZ))
		{
			VWDmsXCNprEXPDPMQQRkFHACbMqU();
		}
	}

	public static void hXpHtBuijEDJvGwJAKyobUHfOXu()
	{
		try
		{
			mlCSNRExqaBAcNbcnZUKYvCTBRn = mFYZExXetZaHadNGAtnPcMScPdOW.steamClient;
			if (mlCSNRExqaBAcNbcnZUKYvCTBRn == null || mlCSNRExqaBAcNbcnZUKYvCTBRn.GetIntPtr() == IntPtr.Zero)
			{
				throw new Exception();
			}
			rPMbTBVvxkygnJqXvAJrBBsydHBB = mFYZExXetZaHadNGAtnPcMScPdOW.steamUser;
			if (rPMbTBVvxkygnJqXvAJrBBsydHBB == null || rPMbTBVvxkygnJqXvAJrBBsydHBB.GetIntPtr() == IntPtr.Zero)
			{
				throw new Exception();
			}
			hXibvYfKIpAvUcyqYQNQfxollZi = mFYZExXetZaHadNGAtnPcMScPdOW.steamController;
			if (hXibvYfKIpAvUcyqYQNQfxollZi == null || hXibvYfKIpAvUcyqYQNQfxollZi.GetIntPtr() == IntPtr.Zero)
			{
				throw new Exception();
			}
			hXibvYfKIpAvUcyqYQNQfxollZi.Init();
			hXibvYfKIpAvUcyqYQNQfxollZi.RunFrame();
			UujybNyVEZmKOqAkpmMTmokUBVg = new ulong[16];
			ZgHOMGJnNnxNjToTwWzJJvPjTD = GCHandle.Alloc(UujybNyVEZmKOqAkpmMTmokUBVg, GCHandleType.Pinned);
			WrbbRlHToNDdiOQmBrjumMkpCjZ = new ulong[16];
			VWDmsXCNprEXPDPMQQRkFHACbMqU();
		}
		catch (Exception)
		{
		}
	}

	private static bool SleMWcCikRGJXVXPdftfdpXNikI(int P_0, int P_1, ulong[] P_2, ulong[] P_3)
	{
		if (P_1 != P_0)
		{
			return true;
		}
		for (int i = 0; i < P_0; i++)
		{
			if (P_2[i] != P_3[i])
			{
				return true;
			}
		}
		return false;
	}

	private static void VWDmsXCNprEXPDPMQQRkFHACbMqU()
	{
		if (xcCbyZgHCynKoTBXLDiHodVtNgAH || hXibvYfKIpAvUcyqYQNQfxollZi == null)
		{
			return;
		}
		try
		{
			string[] array = new string[2] { "InGameControls", "MenuControls" };
			Dictionary<string, ulong> dictionary = new Dictionary<string, ulong>();
			for (int i = 0; i < array.Length; i++)
			{
				ulong actionSetHandle = hXibvYfKIpAvUcyqYQNQfxollZi.GetActionSetHandle(array[i]);
				if (actionSetHandle != 0 && !dictionary.ContainsKey(array[i]))
				{
					dictionary.Add(array[i], actionSetHandle);
				}
			}
			SteamControllerInternal.SetActionSetHandles(dictionary);
			string[] array2 = new string[3] { "Move", "Camera", "Throttle" };
			string[] array3 = new string[9] { "fire", "Jump", "pause_menu", "menu_up", "menu_down", "menu_left", "menu_right", "menu_select", "menu_cancel" };
			Dictionary<string, ulong> dictionary2 = new Dictionary<string, ulong>();
			for (int j = 0; j < array2.Length; j++)
			{
				ulong analogActionHandle = hXibvYfKIpAvUcyqYQNQfxollZi.GetAnalogActionHandle(array2[j]);
				if (analogActionHandle != 0 && !dictionary2.ContainsKey(array2[j]))
				{
					dictionary2.Add(array2[j], analogActionHandle);
				}
			}
			SteamControllerInternal.SetAnalogActionHandles(dictionary2);
			Dictionary<string, ulong> dictionary3 = new Dictionary<string, ulong>();
			for (int k = 0; k < array3.Length; k++)
			{
				ulong analogActionHandle2 = hXibvYfKIpAvUcyqYQNQfxollZi.GetAnalogActionHandle(array3[k]);
				if (analogActionHandle2 != 0 && !dictionary3.ContainsKey(array3[k]))
				{
					dictionary3.Add(array3[k], analogActionHandle2);
				}
			}
			SteamControllerInternal.SetDigitalActionHandles(dictionary3);
			xcCbyZgHCynKoTBXLDiHodVtNgAH = dictionary.Count > 0 || dictionary2.Count > 0 || dictionary3.Count > 0;
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private static bool DnawPwxaGOUlxwPMpnTrkQPiGMg()
	{
		return mFYZExXetZaHadNGAtnPcMScPdOW.steamUtils.IsOverlayEnabled();
	}
}
