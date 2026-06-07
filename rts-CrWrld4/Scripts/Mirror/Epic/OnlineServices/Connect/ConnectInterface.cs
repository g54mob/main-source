using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	public sealed class ConnectInterface : Handle
	{
		public const int AddnotifyauthexpirationApiLatest = 1;

		public const int AddnotifyloginstatuschangedApiLatest = 1;

		public const int CopyproductuserexternalaccountbyaccountidApiLatest = 1;

		public const int CopyproductuserexternalaccountbyaccounttypeApiLatest = 1;

		public const int CopyproductuserexternalaccountbyindexApiLatest = 1;

		public const int CopyproductuserinfoApiLatest = 1;

		public const int CreatedeviceidApiLatest = 1;

		public const int CreatedeviceidDevicemodelMaxLength = 64;

		public const int CreateuserApiLatest = 1;

		public const int CredentialsApiLatest = 1;

		public const int DeletedeviceidApiLatest = 1;

		public const int ExternalAccountIdMaxLength = 256;

		public const int ExternalaccountinfoApiLatest = 1;

		public const int GetexternalaccountmappingApiLatest = 1;

		public const int GetexternalaccountmappingsApiLatest = 1;

		public const int GetproductuserexternalaccountcountApiLatest = 1;

		public const int GetproductuseridmappingApiLatest = 1;

		public const int LinkaccountApiLatest = 1;

		public const int LoginApiLatest = 2;

		public const int OnauthexpirationcallbackApiLatest = 1;

		public const int QueryexternalaccountmappingsApiLatest = 1;

		public const int QueryexternalaccountmappingsMaxAccountIds = 128;

		public const int QueryproductuseridmappingsApiLatest = 2;

		public const int TimeUndefined = -1;

		public const int TransferdeviceidaccountApiLatest = 1;

		public const int UnlinkaccountApiLatest = 1;

		public const int UserlogininfoApiLatest = 1;

		public const int UserlogininfoDisplaynameMaxLength = 32;

		public ConnectInterface()
		{
		}

		public ConnectInterface(IntPtr innerHandle)
		{
		}

		public ulong AddNotifyAuthExpiration(AddNotifyAuthExpirationOptions options, object clientData, OnAuthExpirationCallback notification)
		{
			return 0uL;
		}

		public ulong AddNotifyLoginStatusChanged(AddNotifyLoginStatusChangedOptions options, object clientData, OnLoginStatusChangedCallback notification)
		{
			return 0uL;
		}

		public Result CopyProductUserExternalAccountByAccountId(CopyProductUserExternalAccountByAccountIdOptions options, out ExternalAccountInfo outExternalAccountInfo)
		{
			outExternalAccountInfo = null;
			return default(Result);
		}

		public Result CopyProductUserExternalAccountByAccountType(CopyProductUserExternalAccountByAccountTypeOptions options, out ExternalAccountInfo outExternalAccountInfo)
		{
			outExternalAccountInfo = null;
			return default(Result);
		}

		public Result CopyProductUserExternalAccountByIndex(CopyProductUserExternalAccountByIndexOptions options, out ExternalAccountInfo outExternalAccountInfo)
		{
			outExternalAccountInfo = null;
			return default(Result);
		}

		public Result CopyProductUserInfo(CopyProductUserInfoOptions options, out ExternalAccountInfo outExternalAccountInfo)
		{
			outExternalAccountInfo = null;
			return default(Result);
		}

		public void CreateDeviceId(CreateDeviceIdOptions options, object clientData, OnCreateDeviceIdCallback completionDelegate)
		{
		}

		public void CreateUser(CreateUserOptions options, object clientData, OnCreateUserCallback completionDelegate)
		{
		}

		public void DeleteDeviceId(DeleteDeviceIdOptions options, object clientData, OnDeleteDeviceIdCallback completionDelegate)
		{
		}

		public ProductUserId GetExternalAccountMapping(GetExternalAccountMappingsOptions options)
		{
			return null;
		}

		public ProductUserId GetLoggedInUserByIndex(int index)
		{
			return null;
		}

		public int GetLoggedInUsersCount()
		{
			return 0;
		}

		public LoginStatus GetLoginStatus(ProductUserId localUserId)
		{
			return default(LoginStatus);
		}

		public uint GetProductUserExternalAccountCount(GetProductUserExternalAccountCountOptions options)
		{
			return 0u;
		}

		public Result GetProductUserIdMapping(GetProductUserIdMappingOptions options, out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		public void LinkAccount(LinkAccountOptions options, object clientData, OnLinkAccountCallback completionDelegate)
		{
		}

		public void Login(LoginOptions options, object clientData, OnLoginCallback completionDelegate)
		{
		}

		public void QueryExternalAccountMappings(QueryExternalAccountMappingsOptions options, object clientData, OnQueryExternalAccountMappingsCallback completionDelegate)
		{
		}

		public void QueryProductUserIdMappings(QueryProductUserIdMappingsOptions options, object clientData, OnQueryProductUserIdMappingsCallback completionDelegate)
		{
		}

		public void RemoveNotifyAuthExpiration(ulong inId)
		{
		}

		public void RemoveNotifyLoginStatusChanged(ulong inId)
		{
		}

		public void TransferDeviceIdAccount(TransferDeviceIdAccountOptions options, object clientData, OnTransferDeviceIdAccountCallback completionDelegate)
		{
		}

		public void UnlinkAccount(UnlinkAccountOptions options, object clientData, OnUnlinkAccountCallback completionDelegate)
		{
		}

		internal static void OnAuthExpirationCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnCreateDeviceIdCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnCreateUserCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnDeleteDeviceIdCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLinkAccountCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLoginCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnLoginStatusChangedCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryExternalAccountMappingsCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryProductUserIdMappingsCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnTransferDeviceIdAccountCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnUnlinkAccountCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern ulong EOS_Connect_AddNotifyAuthExpiration(IntPtr handle, IntPtr options, IntPtr clientData, OnAuthExpirationCallbackInternal notification);

		[PreserveSig]
		internal static extern ulong EOS_Connect_AddNotifyLoginStatusChanged(IntPtr handle, IntPtr options, IntPtr clientData, OnLoginStatusChangedCallbackInternal notification);

		[PreserveSig]
		internal static extern Result EOS_Connect_CopyProductUserExternalAccountByAccountId(IntPtr handle, IntPtr options, ref IntPtr outExternalAccountInfo);

		[PreserveSig]
		internal static extern Result EOS_Connect_CopyProductUserExternalAccountByAccountType(IntPtr handle, IntPtr options, ref IntPtr outExternalAccountInfo);

		[PreserveSig]
		internal static extern Result EOS_Connect_CopyProductUserExternalAccountByIndex(IntPtr handle, IntPtr options, ref IntPtr outExternalAccountInfo);

		[PreserveSig]
		internal static extern Result EOS_Connect_CopyProductUserInfo(IntPtr handle, IntPtr options, ref IntPtr outExternalAccountInfo);

		[PreserveSig]
		internal static extern void EOS_Connect_CreateDeviceId(IntPtr handle, IntPtr options, IntPtr clientData, OnCreateDeviceIdCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Connect_CreateUser(IntPtr handle, IntPtr options, IntPtr clientData, OnCreateUserCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Connect_DeleteDeviceId(IntPtr handle, IntPtr options, IntPtr clientData, OnDeleteDeviceIdCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern IntPtr EOS_Connect_GetExternalAccountMapping(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern IntPtr EOS_Connect_GetLoggedInUserByIndex(IntPtr handle, int index);

		[PreserveSig]
		internal static extern int EOS_Connect_GetLoggedInUsersCount(IntPtr handle);

		[PreserveSig]
		internal static extern LoginStatus EOS_Connect_GetLoginStatus(IntPtr handle, IntPtr localUserId);

		[PreserveSig]
		internal static extern uint EOS_Connect_GetProductUserExternalAccountCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_Connect_GetProductUserIdMapping(IntPtr handle, IntPtr options, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern void EOS_Connect_LinkAccount(IntPtr handle, IntPtr options, IntPtr clientData, OnLinkAccountCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Connect_Login(IntPtr handle, IntPtr options, IntPtr clientData, OnLoginCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Connect_QueryExternalAccountMappings(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryExternalAccountMappingsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Connect_QueryProductUserIdMappings(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryProductUserIdMappingsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Connect_ExternalAccountInfo_Release(IntPtr externalAccountInfo);

		[PreserveSig]
		internal static extern void EOS_Connect_RemoveNotifyAuthExpiration(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Connect_RemoveNotifyLoginStatusChanged(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Connect_TransferDeviceIdAccount(IntPtr handle, IntPtr options, IntPtr clientData, OnTransferDeviceIdAccountCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Connect_UnlinkAccount(IntPtr handle, IntPtr options, IntPtr clientData, OnUnlinkAccountCallbackInternal completionDelegate);
	}
}
