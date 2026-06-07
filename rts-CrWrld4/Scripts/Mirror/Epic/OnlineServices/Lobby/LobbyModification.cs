using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	public sealed class LobbyModification : Handle
	{
		public const int LobbymodificationAddattributeApiLatest = 1;

		public const int LobbymodificationAddmemberattributeApiLatest = 1;

		public const int LobbymodificationMaxAttributeLength = 64;

		public const int LobbymodificationMaxAttributes = 64;

		public const int LobbymodificationRemoveattributeApiLatest = 1;

		public const int LobbymodificationRemovememberattributeApiLatest = 1;

		public const int LobbymodificationSetbucketidApiLatest = 1;

		public const int LobbymodificationSetinvitesallowedApiLatest = 1;

		public const int LobbymodificationSetmaxmembersApiLatest = 1;

		public const int LobbymodificationSetpermissionlevelApiLatest = 1;

		public LobbyModification()
		{
		}

		public LobbyModification(IntPtr innerHandle)
		{
		}

		public Result AddAttribute(LobbyModificationAddAttributeOptions options)
		{
			return default(Result);
		}

		public Result AddMemberAttribute(LobbyModificationAddMemberAttributeOptions options)
		{
			return default(Result);
		}

		public void Release()
		{
		}

		public Result RemoveAttribute(LobbyModificationRemoveAttributeOptions options)
		{
			return default(Result);
		}

		public Result RemoveMemberAttribute(LobbyModificationRemoveMemberAttributeOptions options)
		{
			return default(Result);
		}

		public Result SetBucketId(LobbyModificationSetBucketIdOptions options)
		{
			return default(Result);
		}

		public Result SetInvitesAllowed(LobbyModificationSetInvitesAllowedOptions options)
		{
			return default(Result);
		}

		public Result SetMaxMembers(LobbyModificationSetMaxMembersOptions options)
		{
			return default(Result);
		}

		public Result SetPermissionLevel(LobbyModificationSetPermissionLevelOptions options)
		{
			return default(Result);
		}

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_AddAttribute(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_AddMemberAttribute(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_LobbyModification_Release(IntPtr lobbyModificationHandle);

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_RemoveAttribute(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_RemoveMemberAttribute(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_SetBucketId(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_SetInvitesAllowed(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_SetMaxMembers(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_LobbyModification_SetPermissionLevel(IntPtr handle, IntPtr options);
	}
}
