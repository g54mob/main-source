using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	public sealed class LobbyInterface : Handle
	{
		public const int AddnotifyjoinlobbyacceptedApiLatest = 1;

		public const int AddnotifylobbyinviteacceptedApiLatest = 1;

		public const int AddnotifylobbyinvitereceivedApiLatest = 1;

		public const int AddnotifylobbymemberstatusreceivedApiLatest = 1;

		public const int AddnotifylobbymemberupdatereceivedApiLatest = 1;

		public const int AddnotifylobbyupdatereceivedApiLatest = 1;

		public const int AttributeApiLatest = 1;

		public const int AttributedataApiLatest = 1;

		public const int CopylobbydetailshandleApiLatest = 1;

		public const int CopylobbydetailshandlebyinviteidApiLatest = 1;

		public const int CopylobbydetailshandlebyuieventidApiLatest = 1;

		public const int CreatelobbyApiLatest = 4;

		public const int CreatelobbysearchApiLatest = 1;

		public const int DestroylobbyApiLatest = 1;

		public const int GetinvitecountApiLatest = 1;

		public const int GetinviteidbyindexApiLatest = 1;

		public const int InviteidMaxLength = 64;

		public const int JoinlobbyApiLatest = 2;

		public const int KickmemberApiLatest = 1;

		public const int LeavelobbyApiLatest = 1;

		public const int MaxLobbies = 16;

		public const int MaxLobbyMembers = 64;

		public const int MaxSearchResults = 200;

		public const int PromotememberApiLatest = 1;

		public const int QueryinvitesApiLatest = 1;

		public const int RejectinviteApiLatest = 1;

		public const string SearchBucketId = "bucket";

		public const string SearchMincurrentmembers = "mincurrentmembers";

		public const string SearchMinslotsavailable = "minslotsavailable";

		public const int SendinviteApiLatest = 1;

		public const int UpdatelobbyApiLatest = 1;

		public const int UpdatelobbymodificationApiLatest = 1;

		public LobbyInterface()
		{
		}

		public LobbyInterface(IntPtr innerHandle)
		{
		}

		public ulong AddNotifyJoinLobbyAccepted(AddNotifyJoinLobbyAcceptedOptions options, object clientData, OnJoinLobbyAcceptedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifyLobbyInviteAccepted(AddNotifyLobbyInviteAcceptedOptions options, object clientData, OnLobbyInviteAcceptedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifyLobbyInviteReceived(AddNotifyLobbyInviteReceivedOptions options, object clientData, OnLobbyInviteReceivedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifyLobbyMemberStatusReceived(AddNotifyLobbyMemberStatusReceivedOptions options, object clientData, OnLobbyMemberStatusReceivedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifyLobbyMemberUpdateReceived(AddNotifyLobbyMemberUpdateReceivedOptions options, object clientData, OnLobbyMemberUpdateReceivedCallback notificationFn)
		{
			return 0uL;
		}

		public ulong AddNotifyLobbyUpdateReceived(AddNotifyLobbyUpdateReceivedOptions options, object clientData, OnLobbyUpdateReceivedCallback notificationFn)
		{
			return 0uL;
		}

		public Result CopyLobbyDetailsHandle(CopyLobbyDetailsHandleOptions options, out LobbyDetails outLobbyDetailsHandle)
		{
			outLobbyDetailsHandle = null;
			return default(Result);
		}

		public Result CopyLobbyDetailsHandleByInviteId(CopyLobbyDetailsHandleByInviteIdOptions options, out LobbyDetails outLobbyDetailsHandle)
		{
			outLobbyDetailsHandle = null;
			return default(Result);
		}

		public Result CopyLobbyDetailsHandleByUiEventId(CopyLobbyDetailsHandleByUiEventIdOptions options, out LobbyDetails outLobbyDetailsHandle)
		{
			outLobbyDetailsHandle = null;
			return default(Result);
		}

		public void CreateLobby(CreateLobbyOptions options, object clientData, OnCreateLobbyCallback completionDelegate)
		{
		}

		public Result CreateLobbySearch(CreateLobbySearchOptions options, out LobbySearch outLobbySearchHandle)
		{
			outLobbySearchHandle = null;
			return default(Result);
		}

		public void DestroyLobby(DestroyLobbyOptions options, object clientData, OnDestroyLobbyCallback completionDelegate)
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

		public void JoinLobby(JoinLobbyOptions options, object clientData, OnJoinLobbyCallback completionDelegate)
		{
		}

		public void KickMember(KickMemberOptions options, object clientData, OnKickMemberCallback completionDelegate)
		{
		}

		public void LeaveLobby(LeaveLobbyOptions options, object clientData, OnLeaveLobbyCallback completionDelegate)
		{
		}

		public void PromoteMember(PromoteMemberOptions options, object clientData, OnPromoteMemberCallback completionDelegate)
		{
		}

		public void QueryInvites(QueryInvitesOptions options, object clientData, OnQueryInvitesCallback completionDelegate)
		{
		}

		public void RejectInvite(RejectInviteOptions options, object clientData, OnRejectInviteCallback completionDelegate)
		{
		}

		public void RemoveNotifyJoinLobbyAccepted(ulong inId)
		{
		}

		public void RemoveNotifyLobbyInviteAccepted(ulong inId)
		{
		}

		public void RemoveNotifyLobbyInviteReceived(ulong inId)
		{
		}

		public void RemoveNotifyLobbyMemberStatusReceived(ulong inId)
		{
		}

		public void RemoveNotifyLobbyMemberUpdateReceived(ulong inId)
		{
		}

		public void RemoveNotifyLobbyUpdateReceived(ulong inId)
		{
		}

		public void SendInvite(SendInviteOptions options, object clientData, OnSendInviteCallback completionDelegate)
		{
		}

		public void UpdateLobby(UpdateLobbyOptions options, object clientData, OnUpdateLobbyCallback completionDelegate)
		{
		}

		public Result UpdateLobbyModification(UpdateLobbyModificationOptions options, out LobbyModification outLobbyModificationHandle)
		{
			outLobbyModificationHandle = null;
			return default(Result);
		}

		internal static void OnCreateLobbyCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnDestroyLobbyCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnJoinLobbyAcceptedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnJoinLobbyCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnKickMemberCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLeaveLobbyCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLobbyInviteAcceptedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLobbyInviteReceivedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLobbyMemberStatusReceivedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLobbyMemberUpdateReceivedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLobbyUpdateReceivedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnPromoteMemberCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryInvitesCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnRejectInviteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnSendInviteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnUpdateLobbyCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern ulong EOS_Lobby_AddNotifyJoinLobbyAccepted(IntPtr handle, IntPtr options, IntPtr clientData, OnJoinLobbyAcceptedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Lobby_AddNotifyLobbyInviteAccepted(IntPtr handle, IntPtr options, IntPtr clientData, OnLobbyInviteAcceptedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Lobby_AddNotifyLobbyInviteReceived(IntPtr handle, IntPtr options, IntPtr clientData, OnLobbyInviteReceivedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Lobby_AddNotifyLobbyMemberStatusReceived(IntPtr handle, IntPtr options, IntPtr clientData, OnLobbyMemberStatusReceivedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Lobby_AddNotifyLobbyMemberUpdateReceived(IntPtr handle, IntPtr options, IntPtr clientData, OnLobbyMemberUpdateReceivedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern ulong EOS_Lobby_AddNotifyLobbyUpdateReceived(IntPtr handle, IntPtr options, IntPtr clientData, OnLobbyUpdateReceivedCallbackInternal notificationFn);

		[PreserveSig]
		internal static extern Result EOS_Lobby_CopyLobbyDetailsHandle(IntPtr handle, IntPtr options, ref IntPtr outLobbyDetailsHandle);

		[PreserveSig]
		internal static extern Result EOS_Lobby_CopyLobbyDetailsHandleByInviteId(IntPtr handle, IntPtr options, ref IntPtr outLobbyDetailsHandle);

		[PreserveSig]
		internal static extern Result EOS_Lobby_CopyLobbyDetailsHandleByUiEventId(IntPtr handle, IntPtr options, ref IntPtr outLobbyDetailsHandle);

		[PreserveSig]
		internal static extern void EOS_Lobby_CreateLobby(IntPtr handle, IntPtr options, IntPtr clientData, OnCreateLobbyCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern Result EOS_Lobby_CreateLobbySearch(IntPtr handle, IntPtr options, ref IntPtr outLobbySearchHandle);

		[PreserveSig]
		internal static extern void EOS_Lobby_DestroyLobby(IntPtr handle, IntPtr options, IntPtr clientData, OnDestroyLobbyCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern uint EOS_Lobby_GetInviteCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_Lobby_GetInviteIdByIndex(IntPtr handle, IntPtr options, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern void EOS_Lobby_JoinLobby(IntPtr handle, IntPtr options, IntPtr clientData, OnJoinLobbyCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Lobby_KickMember(IntPtr handle, IntPtr options, IntPtr clientData, OnKickMemberCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Lobby_LeaveLobby(IntPtr handle, IntPtr options, IntPtr clientData, OnLeaveLobbyCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Lobby_PromoteMember(IntPtr handle, IntPtr options, IntPtr clientData, OnPromoteMemberCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Lobby_QueryInvites(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryInvitesCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Lobby_RejectInvite(IntPtr handle, IntPtr options, IntPtr clientData, OnRejectInviteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Lobby_Attribute_Release(IntPtr lobbyAttribute);

		[PreserveSig]
		internal static extern void EOS_Lobby_RemoveNotifyJoinLobbyAccepted(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Lobby_RemoveNotifyLobbyInviteAccepted(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Lobby_RemoveNotifyLobbyInviteReceived(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Lobby_RemoveNotifyLobbyMemberStatusReceived(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Lobby_RemoveNotifyLobbyMemberUpdateReceived(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Lobby_RemoveNotifyLobbyUpdateReceived(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Lobby_SendInvite(IntPtr handle, IntPtr options, IntPtr clientData, OnSendInviteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Lobby_UpdateLobby(IntPtr handle, IntPtr options, IntPtr clientData, OnUpdateLobbyCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern Result EOS_Lobby_UpdateLobbyModification(IntPtr handle, IntPtr options, ref IntPtr outLobbyModificationHandle);
	}
}
