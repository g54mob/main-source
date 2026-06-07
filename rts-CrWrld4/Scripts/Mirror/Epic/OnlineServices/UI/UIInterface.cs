using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UI
{
	public sealed class UIInterface : Handle
	{
		public const int AcknowledgecorrelationidApiLatest = 1;

		public const int AcknowledgeeventidApiLatest = 1;

		public const int AddnotifydisplaysettingsupdatedApiLatest = 1;

		public const int EventidInvalid = 0;

		public const int GetfriendsvisibleApiLatest = 1;

		public const int GettogglefriendskeyApiLatest = 1;

		public const int HidefriendsApiLatest = 1;

		public const int PrepresentApiLatest = 1;

		public const int ReportkeyeventApiLatest = 1;

		public const int SetdisplaypreferenceApiLatest = 1;

		public const int SettogglefriendskeyApiLatest = 1;

		public const int ShowfriendsApiLatest = 1;

		public UIInterface()
		{
		}

		public UIInterface(IntPtr innerHandle)
		{
		}

		public Result AcknowledgeEventId(AcknowledgeEventIdOptions options)
		{
			return default(Result);
		}

		public ulong AddNotifyDisplaySettingsUpdated(AddNotifyDisplaySettingsUpdatedOptions options, object clientData, OnDisplaySettingsUpdatedCallback notificationFn)
		{
			return 0uL;
		}

		public bool GetFriendsVisible(GetFriendsVisibleOptions options)
		{
			return false;
		}

		public NotificationLocation GetNotificationLocationPreference()
		{
			return default(NotificationLocation);
		}

		public KeyCombination GetToggleFriendsKey(GetToggleFriendsKeyOptions options)
		{
			return default(KeyCombination);
		}

		public void HideFriends(HideFriendsOptions options, object clientData, OnHideFriendsCallback completionDelegate)
		{
		}

		public bool IsValidKeyCombination(KeyCombination keyCombination)
		{
			return false;
		}

		public void RemoveNotifyDisplaySettingsUpdated(ulong id)
		{
		}

		public Result SetDisplayPreference(SetDisplayPreferenceOptions options)
		{
			return default(Result);
		}

		public Result SetToggleFriendsKey(SetToggleFriendsKeyOptions options)
		{
			return default(Result);
		}

		public void ShowFriends(ShowFriendsOptions options, object clientData, OnShowFriendsCallback completionDelegate)
		{
		}

		internal static void OnDisplaySettingsUpdatedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnHideFriendsCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnShowFriendsCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_UI_AcknowledgeEventId(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern ulong EOS_UI_AddNotifyDisplaySettingsUpdated(IntPtr handle, IntPtr options, IntPtr clientData, OnDisplaySettingsUpdatedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern int EOS_UI_GetFriendsVisible(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern NotificationLocation EOS_UI_GetNotificationLocationPreference(IntPtr handle);

		[PreserveSig]
		internal static extern KeyCombination EOS_UI_GetToggleFriendsKey(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_UI_HideFriends(IntPtr handle, IntPtr options, IntPtr clientData, OnHideFriendsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern int EOS_UI_IsValidKeyCombination(IntPtr handle, KeyCombination keyCombination);

		[PreserveSig]
		internal static extern void EOS_UI_RemoveNotifyDisplaySettingsUpdated(IntPtr handle, ulong id);

		[PreserveSig]
		internal static extern Result EOS_UI_SetDisplayPreference(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_UI_SetToggleFriendsKey(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_UI_ShowFriends(IntPtr handle, IntPtr options, IntPtr clientData, OnShowFriendsCallbackInternal completionDelegate);
	}
}
