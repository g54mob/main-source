using System;
using System.Collections.Generic;

public static class AkCallbackManager
{
	public delegate void EventCallback(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info);

	public delegate void MonitoringCallback(AkMonitorErrorCode in_errorCode, AkMonitorErrorLevel in_errorLevel, uint in_playingID, ulong in_gameObjID, string in_msg);

	public delegate void BankCallback(uint in_bankID, IntPtr in_InMemoryBankPtr, AKRESULT in_eLoadResult, object in_Cookie);

	public class EventCallbackPackage
	{
		public bool m_bNotifyEndOfEvent;

		public EventCallback m_Callback;

		public object m_Cookie;

		public uint m_playingID;

		public static EventCallbackPackage Create(EventCallback in_cb, object in_cookie, ref uint io_Flags)
		{
			return null;
		}
	}

	public class BankCallbackPackage
	{
		public BankCallback m_Callback;

		public object m_Cookie;

		public BankCallbackPackage(BankCallback in_cb, object in_cookie)
		{
		}
	}

	public delegate AKRESULT BGMCallback(bool in_bOtherAudioPlaying, object in_Cookie);

	public class BGMCallbackPackage
	{
		public BGMCallback m_Callback;

		public object m_Cookie;
	}

	public class InitializationSettings
	{
		public const bool DefaultIsLoggingEnabled = true;

		public bool IsLoggingEnabled;
	}

	private static readonly AkEventCallbackInfo AkEventCallbackInfo;

	private static readonly AkDynamicSequenceItemCallbackInfo AkDynamicSequenceItemCallbackInfo;

	private static readonly AkMIDIEventCallbackInfo AkMIDIEventCallbackInfo;

	private static readonly AkMarkerCallbackInfo AkMarkerCallbackInfo;

	private static readonly AkDurationCallbackInfo AkDurationCallbackInfo;

	private static readonly AkMusicSyncCallbackInfo AkMusicSyncCallbackInfo;

	private static readonly AkMusicPlaylistCallbackInfo AkMusicPlaylistCallbackInfo;

	private static readonly AkAudioSourceChangeCallbackInfo AkAudioSourceChangeCallbackInfo;

	private static readonly AkMonitoringCallbackInfo AkMonitoringCallbackInfo;

	private static readonly AkBankCallbackInfo AkBankCallbackInfo;

	private static readonly Dictionary<int, EventCallbackPackage> m_mapEventCallbacks;

	private static readonly Dictionary<int, BankCallbackPackage> m_mapBankCallbacks;

	private static EventCallbackPackage m_LastAddedEventPackage;

	private static MonitoringCallback m_MonitoringCB;

	private static BGMCallbackPackage ms_sourceChangeCallbackPkg;

	public static bool IsLoggingEnabled { get; set; }

	public static void RemoveEventCallback(EventCallbackPackage in_package)
	{
	}

	public static IEnumerable<EventCallbackPackage> GetEventCallbacks()
	{
		return null;
	}

	public static void RemoveEventCallback(uint in_playingID)
	{
	}

	public static void RemoveEventCallbackCookie(object in_cookie)
	{
	}

	public static IEnumerable<BankCallbackPackage> GetBankCallbacks()
	{
		return null;
	}

	public static void RemoveBankCallback(object in_cookie)
	{
	}

	public static void SetLastAddedPlayingID(uint in_playingID)
	{
	}

	public static void Init(InitializationSettings settings)
	{
	}

	public static void Term()
	{
	}

	public static void SetMonitoringCallback(AkMonitorErrorLevel in_Level, MonitoringCallback in_CB)
	{
	}

	private static void SetLocalOutput(AkMonitorErrorLevel in_Level)
	{
	}

	public static void SetBGMCallback(BGMCallback in_CB, object in_cookie)
	{
	}

	public static void ParseCallbackInfoMessage(ref string in_message)
	{
	}

	public static int PostCallbacks()
	{
		return 0;
	}
}
