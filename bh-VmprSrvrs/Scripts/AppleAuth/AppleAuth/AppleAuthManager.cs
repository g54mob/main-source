using System;
using AppleAuth.Enums;
using AppleAuth.Interfaces;

namespace AppleAuth
{
	public class AppleAuthManager : IAppleAuthManager
	{
		public static bool IsCurrentPlatformSupported => false;

		static AppleAuthManager()
		{
		}

		public AppleAuthManager(IPayloadDeserializer payloadDeserializer)
		{
		}

		public void QuickLogin(Action<ICredential> successCallback, Action<IAppleError> errorCallback)
		{
		}

		public void QuickLogin(AppleAuthQuickLoginArgs quickLoginArgs, Action<ICredential> successCallback, Action<IAppleError> errorCallback)
		{
		}

		public void LoginWithAppleId(LoginOptions options, Action<ICredential> successCallback, Action<IAppleError> errorCallback)
		{
		}

		public void LoginWithAppleId(AppleAuthLoginArgs loginArgs, Action<ICredential> successCallback, Action<IAppleError> errorCallback)
		{
		}

		public void GetCredentialState(string userId, Action<CredentialState> successCallback, Action<IAppleError> errorCallback)
		{
		}

		public void SetCredentialsRevokedCallback(Action<string> credentialsRevokedCallback)
		{
		}

		public void Update()
		{
		}
	}
}
