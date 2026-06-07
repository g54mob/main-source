using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Friends
{
	public sealed class FriendsInterface : Handle
	{
		public const int AcceptinviteApiLatest = 1;

		public const int AddnotifyfriendsupdateApiLatest = 1;

		public const int GetfriendatindexApiLatest = 1;

		public const int GetfriendscountApiLatest = 1;

		public const int GetstatusApiLatest = 1;

		public const int QueryfriendsApiLatest = 1;

		public const int RejectinviteApiLatest = 1;

		public const int SendinviteApiLatest = 1;

		public FriendsInterface()
		{
		}

		public FriendsInterface(IntPtr innerHandle)
		{
		}

		public void AcceptInvite(AcceptInviteOptions options, object clientData, OnAcceptInviteCallback completionDelegate)
		{
		}

		public ulong AddNotifyFriendsUpdate(AddNotifyFriendsUpdateOptions options, object clientData, OnFriendsUpdateCallback friendsUpdateHandler)
		{
			return 0uL;
		}

		public EpicAccountId GetFriendAtIndex(GetFriendAtIndexOptions options)
		{
			return null;
		}

		public int GetFriendsCount(GetFriendsCountOptions options)
		{
			return 0;
		}

		public FriendsStatus GetStatus(GetStatusOptions options)
		{
			return default(FriendsStatus);
		}

		public void QueryFriends(QueryFriendsOptions options, object clientData, OnQueryFriendsCallback completionDelegate)
		{
		}

		public void RejectInvite(RejectInviteOptions options, object clientData, OnRejectInviteCallback completionDelegate)
		{
		}

		public void RemoveNotifyFriendsUpdate(ulong notificationId)
		{
		}

		public void SendInvite(SendInviteOptions options, object clientData, OnSendInviteCallback completionDelegate)
		{
		}

		internal static void OnAcceptInviteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnFriendsUpdateCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryFriendsCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnRejectInviteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnSendInviteCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern void EOS_Friends_AcceptInvite(IntPtr handle, IntPtr options, IntPtr clientData, OnAcceptInviteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern ulong EOS_Friends_AddNotifyFriendsUpdate(IntPtr handle, IntPtr options, IntPtr clientData, OnFriendsUpdateCallbackInternal friendsUpdateHandler);

		[PreserveSig]
		internal static extern IntPtr EOS_Friends_GetFriendAtIndex(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern int EOS_Friends_GetFriendsCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern FriendsStatus EOS_Friends_GetStatus(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Friends_QueryFriends(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryFriendsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Friends_RejectInvite(IntPtr handle, IntPtr options, IntPtr clientData, OnRejectInviteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Friends_RemoveNotifyFriendsUpdate(IntPtr handle, ulong notificationId);

		[PreserveSig]
		internal static extern void EOS_Friends_SendInvite(IntPtr handle, IntPtr options, IntPtr clientData, OnSendInviteCallbackInternal completionDelegate);
	}
}
