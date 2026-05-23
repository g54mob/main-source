#define ENABLE_DEBUG_LOGS
using System;
using Integrations.Interfaces;
using PlayFab;
using PlayFab.ClientModels;
using Utils;

namespace Integrations
{
	public class SteamPlayFabConnector : IPlatformCloudServiceConnector
	{
		private readonly IPlatformHandler _platformHandler;

		public Action<bool, string> OnLoginSequenceComplete { get; set; }

		public SteamPlayFabConnector(IPlatformHandler platformHandler)
		{
			_platformHandler = platformHandler;
		}

		public void AttemptLogin()
		{
			_platformHandler.GetAuthToken(OnGetAuthTokenComplete, OnGetAuthTokenError);
		}

		private void OnGetAuthTokenComplete(string token)
		{
			LoginWithPlatformToken(token);
		}

		private void OnGetAuthTokenError(string error)
		{
			this.Log("Failed to GetAuthToken with error " + error, "OnGetAuthTokenError", 34);
			OnLoginSequenceComplete?.Invoke(arg1: false, null);
		}

		private void LoginWithPlatformToken(string authToken)
		{
			PlayFabClientAPI.LoginWithSteam(new LoginWithSteamRequest
			{
				CreateAccount = true,
				SteamTicket = authToken,
				TicketIsServiceSpecific = true
			}, OnLoginComplete, OnLoginError);
		}

		private void OnLoginComplete(LoginResult result)
		{
			this.Log("Completed login to platform", "OnLoginComplete", 54);
			OnLoginSequenceComplete?.Invoke(arg1: true, result.PlayFabId);
		}

		private void OnLoginError(PlayFabError error)
		{
			this.Log($"Failed to login to platform with error code {error.Error}, HTTP status " + $"{error.HttpCode}, and message {error.ErrorMessage}", "OnLoginError", 60);
			OnLoginSequenceComplete?.Invoke(arg1: false, null);
		}
	}
}
