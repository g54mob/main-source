using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	public sealed class UserInfoInterface : Handle
	{
		public const int CopyexternaluserinfobyaccountidApiLatest = 1;

		public const int CopyexternaluserinfobyaccounttypeApiLatest = 1;

		public const int CopyexternaluserinfobyindexApiLatest = 1;

		public const int CopyuserinfoApiLatest = 2;

		public const int ExternaluserinfoApiLatest = 1;

		public const int GetexternaluserinfocountApiLatest = 1;

		public const int MaxDisplaynameCharacters = 16;

		public const int MaxDisplaynameUtf8Length = 64;

		public const int QueryuserinfoApiLatest = 1;

		public const int QueryuserinfobydisplaynameApiLatest = 1;

		public const int QueryuserinfobyexternalaccountApiLatest = 1;

		public UserInfoInterface()
		{
		}

		public UserInfoInterface(IntPtr innerHandle)
		{
		}

		public Result CopyExternalUserInfoByAccountId(CopyExternalUserInfoByAccountIdOptions options, out ExternalUserInfo outExternalUserInfo)
		{
			outExternalUserInfo = null;
			return default(Result);
		}

		public Result CopyExternalUserInfoByAccountType(CopyExternalUserInfoByAccountTypeOptions options, out ExternalUserInfo outExternalUserInfo)
		{
			outExternalUserInfo = null;
			return default(Result);
		}

		public Result CopyExternalUserInfoByIndex(CopyExternalUserInfoByIndexOptions options, out ExternalUserInfo outExternalUserInfo)
		{
			outExternalUserInfo = null;
			return default(Result);
		}

		public Result CopyUserInfo(CopyUserInfoOptions options, out UserInfoData outUserInfo)
		{
			outUserInfo = null;
			return default(Result);
		}

		public uint GetExternalUserInfoCount(GetExternalUserInfoCountOptions options)
		{
			return 0u;
		}

		public void QueryUserInfo(QueryUserInfoOptions options, object clientData, OnQueryUserInfoCallback completionDelegate)
		{
		}

		public void QueryUserInfoByDisplayName(QueryUserInfoByDisplayNameOptions options, object clientData, OnQueryUserInfoByDisplayNameCallback completionDelegate)
		{
		}

		public void QueryUserInfoByExternalAccount(QueryUserInfoByExternalAccountOptions options, object clientData, OnQueryUserInfoByExternalAccountCallback completionDelegate)
		{
		}

		internal static void OnQueryUserInfoByDisplayNameCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryUserInfoByExternalAccountCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryUserInfoCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_UserInfo_CopyExternalUserInfoByAccountId(IntPtr handle, IntPtr options, ref IntPtr outExternalUserInfo);

		[PreserveSig]
		internal static extern Result EOS_UserInfo_CopyExternalUserInfoByAccountType(IntPtr handle, IntPtr options, ref IntPtr outExternalUserInfo);

		[PreserveSig]
		internal static extern Result EOS_UserInfo_CopyExternalUserInfoByIndex(IntPtr handle, IntPtr options, ref IntPtr outExternalUserInfo);

		[PreserveSig]
		internal static extern Result EOS_UserInfo_CopyUserInfo(IntPtr handle, IntPtr options, ref IntPtr outUserInfo);

		[PreserveSig]
		internal static extern uint EOS_UserInfo_GetExternalUserInfoCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_UserInfo_QueryUserInfo(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryUserInfoCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_UserInfo_QueryUserInfoByDisplayName(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryUserInfoByDisplayNameCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_UserInfo_QueryUserInfoByExternalAccount(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryUserInfoByExternalAccountCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_UserInfo_Release(IntPtr userInfo);

		[PreserveSig]
		internal static extern void EOS_UserInfo_ExternalUserInfo_Release(IntPtr externalUserInfo);
	}
}
