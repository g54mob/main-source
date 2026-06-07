using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	public sealed class AuthInterface : Handle
	{
		public const int AccountfeaturerestrictedinfoApiLatest = 1;

		public const int AddnotifyloginstatuschangedApiLatest = 1;

		public const int CopyuserauthtokenApiLatest = 1;

		public const int CredentialsApiLatest = 3;

		public const int DeletepersistentauthApiLatest = 2;

		public const int LinkaccountApiLatest = 1;

		public const int LoginApiLatest = 2;

		public const int LogoutApiLatest = 1;

		public const int PingrantinfoApiLatest = 2;

		public const int TokenApiLatest = 2;

		public const int VerifyuserauthApiLatest = 1;

		public const int AuthIoscredentialssystemauthcredentialsoptionsApiLatest = 1;

		public AuthInterface()
		{
		}

		public AuthInterface(IntPtr innerHandle)
		{
		}

		public ulong AddNotifyLoginStatusChanged(AddNotifyLoginStatusChangedOptions options, object clientData, OnLoginStatusChangedCallback notification)
		{
			return 0uL;
		}

		public Result CopyUserAuthToken(CopyUserAuthTokenOptions options, EpicAccountId localUserId, out Token outUserAuthToken)
		{
			outUserAuthToken = null;
			return default(Result);
		}

		public void DeletePersistentAuth(DeletePersistentAuthOptions options, object clientData, OnDeletePersistentAuthCallback completionDelegate)
		{
		}

		public EpicAccountId GetLoggedInAccountByIndex(int index)
		{
			return null;
		}

		public int GetLoggedInAccountsCount()
		{
			return 0;
		}

		public LoginStatus GetLoginStatus(EpicAccountId localUserId)
		{
			return default(LoginStatus);
		}

		public void LinkAccount(LinkAccountOptions options, object clientData, OnLinkAccountCallback completionDelegate)
		{
		}

		public void Login(LoginOptions options, object clientData, OnLoginCallback completionDelegate)
		{
		}

		public void Logout(LogoutOptions options, object clientData, OnLogoutCallback completionDelegate)
		{
		}

		public void RemoveNotifyLoginStatusChanged(ulong inId)
		{
		}

		public void VerifyUserAuth(VerifyUserAuthOptions options, object clientData, OnVerifyUserAuthCallback completionDelegate)
		{
		}

		internal static void OnDeletePersistentAuthCallbackInternalImplementation(IntPtr data)
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

		internal static void OnLogoutCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnVerifyUserAuthCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern ulong EOS_Auth_AddNotifyLoginStatusChanged(IntPtr handle, IntPtr options, IntPtr clientData, OnLoginStatusChangedCallbackInternal notification);

		[PreserveSig]
		internal static extern Result EOS_Auth_CopyUserAuthToken(IntPtr handle, IntPtr options, IntPtr localUserId, ref IntPtr outUserAuthToken);

		[PreserveSig]
		internal static extern void EOS_Auth_DeletePersistentAuth(IntPtr handle, IntPtr options, IntPtr clientData, OnDeletePersistentAuthCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern IntPtr EOS_Auth_GetLoggedInAccountByIndex(IntPtr handle, int index);

		[PreserveSig]
		internal static extern int EOS_Auth_GetLoggedInAccountsCount(IntPtr handle);

		[PreserveSig]
		internal static extern LoginStatus EOS_Auth_GetLoginStatus(IntPtr handle, IntPtr localUserId);

		[PreserveSig]
		internal static extern void EOS_Auth_LinkAccount(IntPtr handle, IntPtr options, IntPtr clientData, OnLinkAccountCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Auth_Login(IntPtr handle, IntPtr options, IntPtr clientData, OnLoginCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Auth_Logout(IntPtr handle, IntPtr options, IntPtr clientData, OnLogoutCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Auth_Token_Release(IntPtr authToken);

		[PreserveSig]
		internal static extern void EOS_Auth_RemoveNotifyLoginStatusChanged(IntPtr handle, ulong inId);

		[PreserveSig]
		internal static extern void EOS_Auth_VerifyUserAuth(IntPtr handle, IntPtr options, IntPtr clientData, OnVerifyUserAuthCallbackInternal completionDelegate);

		public void Login(IOSLoginOptions options, object clientData, OnLoginCallback completionDelegate)
		{
		}
	}
}
