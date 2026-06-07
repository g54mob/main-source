using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	public sealed class SessionsInterface : Handle
	{
		public const int AddnotifyjoinsessionacceptedApiLatest = 1;

		public const int AddnotifysessioninviteacceptedApiLatest = 1;

		public const int AddnotifysessioninvitereceivedApiLatest = 1;

		public const int AttributedataApiLatest = 1;

		public const int CopyactivesessionhandleApiLatest = 1;

		public const int CopysessionhandlebyinviteidApiLatest = 1;

		public const int CopysessionhandlebyuieventidApiLatest = 1;

		public const int CopysessionhandleforpresenceApiLatest = 1;

		public const int CreatesessionmodificationApiLatest = 3;

		public const int CreatesessionsearchApiLatest = 1;

		public const int DestroysessionApiLatest = 1;

		public const int DumpsessionstateApiLatest = 1;

		public const int EndsessionApiLatest = 1;

		public const int GetinvitecountApiLatest = 1;

		public const int GetinviteidbyindexApiLatest = 1;

		public const int InviteidMaxLength = 64;

		public const int IsuserinsessionApiLatest = 1;

		public const int JoinsessionApiLatest = 2;

		public const int MaxSearchResults = 200;

		public const int Maxregisteredplayers = 1000;

		public const int QueryinvitesApiLatest = 1;

		public const int RegisterplayersApiLatest = 1;

		public const int RejectinviteApiLatest = 1;

		public const string SearchBucketId = "bucket";

		public const string SearchEmptyServersOnly = "emptyonly";

		public const string SearchMinslotsavailable = "minslotsavailable";

		public const string SearchNonemptyServersOnly = "nonemptyonly";

		public const int SendinviteApiLatest = 1;

		public const int SessionattributeApiLatest = 1;

		public const int SessionattributedataApiLatest = 1;

		public const int StartsessionApiLatest = 1;

		public const int UnregisterplayersApiLatest = 1;

		public const int UpdatesessionApiLatest = 1;

		public const int UpdatesessionmodificationApiLatest = 1;

		public SessionsInterface()
		{
		}

		public SessionsInterface(IntPtr innerHandle)
		{
		}

		public ulong AddNotifyJoinSessionAccepted(AddNotifyJoinSessionAcceptedOptions options, object clientData, OnJoinSessionAcceptedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifySessionInviteAccepted(AddNotifySessionInviteAcceptedOptions options, object clientData, OnSessionInviteAcceptedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifySessionInviteReceived(AddNotifySessionInviteReceivedOptions options, object clientData, OnSessionInviteReceivedCallback notificationFn)
		{
			return 0uL;
		}

		public Result CopyActiveSessionHandle(CopyActiveSessionHandleOptions options, out ActiveSession outSessionHandle)
		{
			outSessionHandle = null;
			return default(Result);
		}

		public Result CopySessionHandleByInviteId(CopySessionHandleByInviteIdOptions options, out SessionDetails outSessionHandle)
		{
			outSessionHandle = null;
			return default(Result);
		}

		public Result CopySessionHandleByUiEventId(CopySessionHandleByUiEventIdOptions options, out SessionDetails outSessionHandle)
		{
			outSessionHandle = null;
			return default(Result);
		}

		public Result CopySessionHandleForPresence(CopySessionHandleForPresenceOptions options, out SessionDetails outSessionHandle)
		{
			outSessionHandle = null;
			return default(Result);
		}

		public Result CreateSessionModification(CreateSessionModificationOptions options, out SessionModification outSessionModificationHandle)
		{
			outSessionModificationHandle = null;
			return default(Result);
		}

		public Result CreateSessionSearch(CreateSessionSearchOptions options, out SessionSearch outSessionSearchHandle)
		{
			outSessionSearchHandle = null;
			return default(Result);
		}

		public void DestroySession(DestroySessionOptions options, object clientData, OnDestroySessionCallback completionDelegate)
		{
		}

		public Result DumpSessionState(DumpSessionStateOptions options)
		{
			return default(Result);
		}

		public void EndSession(EndSessionOptions options, object clientData, OnEndSessionCallback completionDelegate)
		{
		}

		public uint GetInviteCount(GetInviteCountOptions options)
		{
			return 0u;
		}

		public Result GetInviteIdByIndex(GetInviteIdByIndexOptions options, out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		public Result IsUserInSession(IsUserInSessionOptions options)
		{
			return default(Result);
		}

		public void JoinSession(JoinSessionOptions options, object clientData, OnJoinSessionCallback completionDelegate)
		{
		}

		public void QueryInvites(QueryInvitesOptions options, object clientData, OnQueryInvitesCallback completionDelegate)
		{
		}

		public void RegisterPlayers(RegisterPlayersOptions options, object clientData, OnRegisterPlayersCallback completionDelegate)
		{
		}

		public void RejectInvite(RejectInviteOptions options, object clientData, OnRejectInviteCallback completionDelegate)
		{
		}

		public void RemoveNotifyJoinSessionAccepted(ulong inId)
		{
		}

		public void RemoveNotifySessionInviteAccepted(ulong inId)
		{
		}

		public void RemoveNotifySessionInviteReceived(ulong inId)
		{
		}

		public void SendInvite(SendInviteOptions options, object clientData, OnSendInviteCallback completionDelegate)
		{
		}

		public void StartSession(StartSessionOptions options, object clientData, OnStartSessionCallback completionDelegate)
		{
		}

		public void UnregisterPlayers(UnregisterPlayersOptions options, object clientData, OnUnregisterPlayersCallback completionDelegate)
		{
		}

		public void UpdateSession(UpdateSessionOptions options, object clientData, OnUpdateSessionCallback completionDelegate)
		{
		}

		public Result UpdateSessionModification(UpdateSessionModificationOptions options, out SessionModification outSessionModificationHandle)
		{
			outSessionModificationHandle = null;
			return default(Result);
		}

		internal static void OnDestroySessionCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnEndSessionCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnJoinSessionAcceptedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnJoinSessionCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryInvitesCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnRegisterPlayersCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnRejectInviteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnSendInviteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnSessionInviteAcceptedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnSessionInviteReceivedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnStartSessionCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnUnregisterPlayersCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnUpdateSessionCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern ulong EOS_Sessions_AddNotifyJoinSessionAccepted(IntPtr handle, IntPtr options, IntPtr clientData, OnJoinSessionAcceptedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Sessions_AddNotifySessionInviteAccepted(IntPtr handle, IntPtr options, IntPtr clientData, OnSessionInviteAcceptedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Sessions_AddNotifySessionInviteReceived(IntPtr handle, IntPtr options, IntPtr clientData, OnSessionInviteReceivedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern Result EOS_Sessions_CopyActiveSessionHandle(IntPtr handle, IntPtr options, ref IntPtr outSessionHandle);

		[PreserveSig]
		internal static extern Result EOS_Sessions_CopySessionHandleByInviteId(IntPtr handle, IntPtr options, ref IntPtr outSessionHandle);

		[PreserveSig]
		internal static extern Result EOS_Sessions_CopySessionHandleByUiEventId(IntPtr handle, IntPtr options, ref IntPtr outSessionHandle);

		[PreserveSig]
		internal static extern Result EOS_Sessions_CopySessionHandleForPresence(IntPtr handle, IntPtr options, ref IntPtr outSessionHandle);

		[PreserveSig]
		internal static extern Result EOS_Sessions_CreateSessionModification(IntPtr handle, IntPtr options, ref IntPtr outSessionModificationHandle);

		[PreserveSig]
		internal static extern Result EOS_Sessions_CreateSessionSearch(IntPtr handle, IntPtr options, ref IntPtr outSessionSearchHandle);

		[PreserveSig]
		internal static extern void EOS_Sessions_DestroySession(IntPtr handle, IntPtr options, IntPtr clientData, OnDestroySessionCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern Result EOS_Sessions_DumpSessionState(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Sessions_EndSession(IntPtr handle, IntPtr options, IntPtr clientData, OnEndSessionCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern uint EOS_Sessions_GetInviteCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_Sessions_GetInviteIdByIndex(IntPtr handle, IntPtr options, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern Result EOS_Sessions_IsUserInSession(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Sessions_JoinSession(IntPtr handle, IntPtr options, IntPtr clientData, OnJoinSessionCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sessions_QueryInvites(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryInvitesCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sessions_RegisterPlayers(IntPtr handle, IntPtr options, IntPtr clientData, OnRegisterPlayersCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sessions_RejectInvite(IntPtr handle, IntPtr options, IntPtr clientData, OnRejectInviteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sessions_RemoveNotifyJoinSessionAccepted(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Sessions_RemoveNotifySessionInviteAccepted(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Sessions_RemoveNotifySessionInviteReceived(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Sessions_SendInvite(IntPtr handle, IntPtr options, IntPtr clientData, OnSendInviteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sessions_StartSession(IntPtr handle, IntPtr options, IntPtr clientData, OnStartSessionCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sessions_UnregisterPlayers(IntPtr handle, IntPtr options, IntPtr clientData, OnUnregisterPlayersCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Sessions_UpdateSession(IntPtr handle, IntPtr options, IntPtr clientData, OnUpdateSessionCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern Result EOS_Sessions_UpdateSessionModification(IntPtr handle, IntPtr options, ref IntPtr outSessionModificationHandle);
	}
}
