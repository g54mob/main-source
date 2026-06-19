using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using PlayFab;
using PlayFab.ClientModels;
using Steamworks;
using UnityEngine;

public class SteamPlayFabAuthentication : IPlayFabAuthentication
{
	private const int MAX_RETRIES = 5;

	private AuthTicket _authTicket;

	public bool IsAuthenticated => LocalPlayerEntityKey != null;

	public string PlayFabTitleId { get; private set; }

	public EntityKey LocalPlayerEntityKey { get; private set; }

	private AuthenticationVO failedVoResult => new AuthenticationVO
	{
		Success = false
	};

	public SteamPlayFabAuthentication(string playFabTitleId)
	{
		PlayFabTitleId = playFabTitleId;
	}

	public async Task<AuthenticationVO> Login(CancellationToken cancellationToken)
	{
		if (!SteamClient.IsValid)
		{
			return failedVoResult;
		}
		if (_authTicket != null)
		{
			Debug.LogError("SteamPlayFabAuthentication: Trying to login while already logged in.");
			_authTicket.Cancel();
			_authTicket = null;
		}
		for (int retries = 0; retries < 5; retries++)
		{
			_authTicket = await SteamUser.GetAuthSessionTicketAsync();
			if (cancellationToken.IsCancellationRequested)
			{
				return failedVoResult;
			}
			if (_authTicket == null)
			{
				Debug.Log($"Failed to get auth ticket for user {SteamClient.SteamId} try={retries}");
				continue;
			}
			Debug.Log("Got steam auth ticket, logging in to PlayFab");
			string ticketString = GetSteamAuthTicketString(_authTicket);
			TaskCompletionSource<LoginResult> loginCompletion = new TaskCompletionSource<LoginResult>();
			UnityMainThreadDispatcher.Instance().Enqueue(delegate
			{
				PlayFabClientAPI.LoginWithSteam(new LoginWithSteamRequest
				{
					TitleId = PlayFabTitleId,
					SteamTicket = ticketString,
					CreateAccount = true
				}, delegate(LoginResult result)
				{
					loginCompletion.SetResult(result);
				}, delegate(PlayFabError error)
				{
					PlayFabPartyNetworking.LogPlayFabError("PlayFab Login Error: ", error);
					loginCompletion.SetResult(null);
				});
			});
			LoginResult loginResult = await loginCompletion.Task;
			if (loginResult != null)
			{
				Debug.Log($"PlayFab login successful for user {SteamClient.SteamId}, id {loginResult.PlayFabId}.");
				if (!SentryOptionsConfiguration.piiList.Contains(loginResult.PlayFabId))
				{
					SentryOptionsConfiguration.piiList.Add(loginResult.PlayFabId);
				}
				LocalPlayerEntityKey = loginResult.EntityToken.Entity;
				return new AuthenticationVO
				{
					Success = true,
					UserId = loginResult.PlayFabId
				};
			}
			if (_authTicket != null)
			{
				_authTicket.Cancel();
				_authTicket = null;
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return failedVoResult;
			}
		}
		return failedVoResult;
	}

	public Task Logout()
	{
		PlayFabClientAPI.ForgetAllCredentials();
		LocalPlayerEntityKey = null;
		if (_authTicket != null)
		{
			_authTicket.Cancel();
			_authTicket = null;
		}
		return Task.CompletedTask;
	}

	public void Update()
	{
	}

	public async void Destroy()
	{
		await Logout();
	}

	private static string GetSteamAuthTicketString(AuthTicket ticket)
	{
		StringBuilder stringBuilder = new StringBuilder();
		byte[] data = ticket.Data;
		foreach (byte b in data)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}
}
