using System.Threading;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class CustomPlayFabAuthentication : IPlayFabAuthentication
{
	private const int MAX_AUTH_RETRIES = 5;

	private string _customId;

	public bool IsAuthenticated => LocalPlayerEntityKey != null;

	public string PlayFabTitleId { get; }

	public EntityKey LocalPlayerEntityKey { get; private set; }

	private string CustomId => _customId ?? SystemInfo.deviceUniqueIdentifier;

	private AuthenticationVO failedVo => new AuthenticationVO
	{
		Success = false
	};

	public CustomPlayFabAuthentication(string customId, string titleId)
	{
		if (string.IsNullOrEmpty(customId))
		{
			Debug.LogWarning("CustomPlayFabAuthentication: null or empty custom login id provided. PlayFab authentication will fail.");
		}
		_customId = customId;
		PlayFabTitleId = titleId;
	}

	public async Task<AuthenticationVO> Login(CancellationToken cancellationToken)
	{
		LoginWithCustomIDRequest request = new LoginWithCustomIDRequest
		{
			TitleId = PlayFabTitleId,
			CreateAccount = true,
			CustomId = CustomId
		};
		for (int retries = 0; retries < 5; retries++)
		{
			LoginResult loginResult = await LoginWithPlayFab(request);
			if (loginResult == null)
			{
				if (cancellationToken.IsCancellationRequested)
				{
					return failedVo;
				}
				continue;
			}
			Debug.Log("PlayFab login successful.");
			LocalPlayerEntityKey = loginResult.EntityToken.Entity;
			return new AuthenticationVO
			{
				Success = true,
				UserId = loginResult.PlayFabId,
				EntityKey = LocalPlayerEntityKey
			};
		}
		Debug.LogError("Max retries reached. Aborting login.");
		return failedVo;
	}

	public Task Logout()
	{
		PlayFabClientAPI.ForgetAllCredentials();
		LocalPlayerEntityKey = null;
		return Task.CompletedTask;
	}

	public void Update()
	{
	}

	public async void Destroy()
	{
		await Logout();
	}

	private async Task<LoginResult> LoginWithPlayFab(LoginWithCustomIDRequest request)
	{
		TaskCompletionSource<LoginResult> loginCompletion = new TaskCompletionSource<LoginResult>();
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			PlayFabClientAPI.LoginWithCustomID(request, delegate(LoginResult result)
			{
				loginCompletion.SetResult(result);
			}, delegate(PlayFabError error)
			{
				PlayFabPartyNetworking.LogPlayFabError("PlayFab Login Error: ", error);
				loginCompletion.SetResult(null);
			});
		});
		return await loginCompletion.Task;
	}
}
