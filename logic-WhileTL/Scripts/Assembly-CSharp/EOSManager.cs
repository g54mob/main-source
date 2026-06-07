using System;
using System.Collections.Generic;
using Epic.OnlineServices;
using Epic.OnlineServices.Achievements;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Logging;
using Epic.OnlineServices.Platform;
using UnityEngine;
using UnityEngine.UI;

public class EOSManager : MonoBehaviour
{
	public string m_ProductName = "Radicchio";

	public string m_ProductVersion = "1.3.97";

	public string m_ProductId = "9359fa123dbf4b89b7d70be316d7810c";

	public string m_SandboxId = "p-7d94qarzxv9gblsbmqe9v75mu82es6";

	public string m_DeploymentId = "3f52036dd797455fa4e3e5f08687cb19";

	public string m_ClientId = "xyza7891pcnMAVhkWc03DzQTQM9WwP3W";

	public string m_ClientSecret = "re47r0yIkGYvNe0juVUosDlGo7up4WTycMf1zghL8E4";

	private LoginCredentialType m_LoginCredentialType = LoginCredentialType.Developer;

	private string m_LoginCredentialId = string.Empty;

	private string m_LoginCredentialToken = string.Empty;

	private static PlatformInterface s_PlatformInterface;

	private const float c_PlatformTickInterval = 0.1f;

	private float m_PlatformTickTimer;

	private string passwordToken = string.Empty;

	public string LangaugeEpic = string.Empty;

	private Text testApi;

	private EpicAccountId productUserID;

	private bool canSendAchievements;

	private ProductUserId LocalUserId;

	private List<string> achievements = new List<string>();

	public void Init()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (GameObject.Find("TestAPI") != null)
		{
			testApi = GameObject.Find("TestAPI").GetComponent<Text>();
		}
		if (testApi != null)
		{
			testApi.text = string.Empty;
		}
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].Contains("-AUTH_PASSWORD"))
			{
				commandLineArgs[i] = commandLineArgs[i].Replace("-AUTH_PASSWORD=", "");
				string text = commandLineArgs[i];
				if (testApi != null)
				{
					Text text2 = testApi;
					text2.text = text2.text + "AUTH_PASSWORD : " + text + "\n";
				}
				Debug.LogError("************************* AUTH_PASSWORD : " + text + " ******************");
				passwordToken = text;
			}
			if (commandLineArgs[i].Contains("-epiclocale"))
			{
				string text3 = commandLineArgs[i].Replace("-epiclocale=", "");
				if (testApi != null)
				{
					Text text4 = testApi;
					text4.text = text4.text + text3 + "\n";
				}
				LangaugeEpic = text3;
			}
		}
		m_LoginCredentialType = LoginCredentialType.PersistentAuth;
		m_ProductName = "Radicchio";
		m_ProductVersion = "1.3.97";
		m_ProductId = "59033de6e3994c75b19db2cb07d9b681";
		m_SandboxId = "9359fa123dbf4b89b7d70be316d7810c";
		m_DeploymentId = "15c435c35f19476db85a44b98872038a";
		m_ClientId = "xyza7891pcnMAVhkWc03DzQTQM9WwP3W";
		m_ClientSecret = "re47r0yIkGYvNe0juVUosDlGo7up4WTycMf1zghL8E4";
	}

	private void OnApplicationQuit()
	{
		if (s_PlatformInterface != null)
		{
			s_PlatformInterface.Release();
			s_PlatformInterface = null;
			PlatformInterface.Shutdown();
		}
	}

	private void Start()
	{
		Debug.LogError("Start EOS");
		Epic.OnlineServices.Result result = PlatformInterface.Initialize(new InitializeOptions
		{
			ProductName = m_ProductName,
			ProductVersion = m_ProductVersion
		});
		if (testApi != null)
		{
			testApi.text += "Initialazing\n";
		}
		if (result != Epic.OnlineServices.Result.Success)
		{
			if (testApi != null)
			{
				Text text = testApi;
				text.text = text.text + "Failed to initialize platform: " + result.ToString() + "\n";
			}
			throw new Exception("Failed to initialize platform: " + result);
		}
		LoggingInterface.SetLogLevel(LogCategory.AllCategories, LogLevel.VeryVerbose);
		LoggingInterface.SetCallback(delegate(LogMessage logMessage)
		{
			Debug.LogError(logMessage.Message);
		});
		s_PlatformInterface = PlatformInterface.Create(new Options
		{
			ProductId = m_ProductId,
			SandboxId = m_SandboxId,
			DeploymentId = m_DeploymentId,
			ClientCredentials = new ClientCredentials
			{
				ClientId = m_ClientId,
				ClientSecret = m_ClientSecret
			}
		});
		if (s_PlatformInterface == null)
		{
			if (testApi != null)
			{
				testApi.text += "Failed to create platform\n";
			}
			throw new Exception("Failed to create platform");
		}
		if (passwordToken.Length == 0)
		{
			if (testApi != null)
			{
				testApi.text += "ExchangeCodeFailed\n";
			}
			Debug.LogError("ExchangeCodeFailed");
			return;
		}
		m_LoginCredentialToken = passwordToken;
		m_LoginCredentialType = LoginCredentialType.ExchangeCode;
		m_LoginCredentialId = string.Empty;
		Epic.OnlineServices.Auth.LoginOptions options = new Epic.OnlineServices.Auth.LoginOptions
		{
			ScopeFlags = AuthScopeFlags.BasicProfile,
			Credentials = new Epic.OnlineServices.Auth.Credentials
			{
				Type = m_LoginCredentialType,
				Id = m_LoginCredentialId,
				Token = m_LoginCredentialToken
			}
		};
		if (testApi != null)
		{
			testApi.text += "Login started\n";
		}
		Debug.LogError("Login started");
		s_PlatformInterface.GetAuthInterface().Login(options, null, LoginCallBack);
	}

	private void Login(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo)
	{
		CopyUserAuthTokenOptions options = new CopyUserAuthTokenOptions();
		Token outUserAuthToken = null;
		s_PlatformInterface.GetAuthInterface().CopyUserAuthToken(options, loginCallbackInfo.LocalUserId, out outUserAuthToken);
		Debug.LogError("token=" + outUserAuthToken.AccessToken);
		Debug.LogError("app=" + outUserAuthToken.App);
		Debug.LogError("expires=" + outUserAuthToken.ExpiresAt);
		Debug.LogError("clientid=" + outUserAuthToken.ClientId);
		Debug.LogError("authType=" + outUserAuthToken.AuthType);
		Epic.OnlineServices.Connect.LoginOptions options2 = new Epic.OnlineServices.Connect.LoginOptions
		{
			Credentials = new Epic.OnlineServices.Connect.Credentials
			{
				Type = ExternalCredentialType.Epic,
				Token = outUserAuthToken.AccessToken
			},
			UserLoginInfo = null
		};
		s_PlatformInterface.GetConnectInterface().Login(options2, null, LoginCallBack);
	}

	private void LoginOldCallBack(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo)
	{
		if (loginCallbackInfo.ResultCode != Epic.OnlineServices.Result.Success)
		{
			if (passwordToken.Length == 0)
			{
				return;
			}
			m_LoginCredentialToken = passwordToken;
			m_LoginCredentialType = LoginCredentialType.ExchangeCode;
			m_LoginCredentialId = string.Empty;
			Epic.OnlineServices.Auth.LoginOptions options = new Epic.OnlineServices.Auth.LoginOptions
			{
				ScopeFlags = AuthScopeFlags.BasicProfile,
				Credentials = new Epic.OnlineServices.Auth.Credentials
				{
					Type = m_LoginCredentialType,
					Id = m_LoginCredentialId,
					Token = m_LoginCredentialToken
				}
			};
			s_PlatformInterface.GetAuthInterface().Login(options, null, LoginCallBack);
		}
		Login(loginCallbackInfo);
	}

	private void LoginCallBack(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo)
	{
		if (testApi != null)
		{
			Text text = testApi;
			text.text = text.text + "login_result=" + loginCallbackInfo.ResultCode.ToString() + "\n";
		}
		Debug.LogError("login_result=" + loginCallbackInfo.ResultCode);
		Login(loginCallbackInfo);
	}

	private void CreateCallBack(CreateUserCallbackInfo data)
	{
		Debug.LogError("Create: " + data.ResultCode);
		if (testApi != null)
		{
			Text text = testApi;
			text.text = text.text + "Create: " + data.ResultCode.ToString() + "\n";
		}
		LocalUserId = data.LocalUserId;
		canSendAchievements = true;
	}

	public void AddAchievementToQueue(string id)
	{
		achievements.Add(id);
	}

	private void UnlockAchievement(string achievement)
	{
		UnlockAchievementsOptions unlockAchievementsOptions = new UnlockAchievementsOptions();
		unlockAchievementsOptions.UserId = LocalUserId;
		unlockAchievementsOptions.AchievementIds = new string[1] { achievement };
		s_PlatformInterface.GetAchievementsInterface().UnlockAchievements(unlockAchievementsOptions, null, AchievementCallback);
	}

	public void LoginCallBack(Epic.OnlineServices.Connect.LoginCallbackInfo data)
	{
		if (testApi != null)
		{
			Text text = testApi;
			text.text = text.text + "Login: " + data.ResultCode.ToString() + "\n";
		}
		Debug.LogError("Login: " + data.ResultCode);
		if (data.ResultCode != Epic.OnlineServices.Result.Success)
		{
			s_PlatformInterface.GetConnectInterface().CreateUser(new CreateUserOptions
			{
				ContinuanceToken = data.ContinuanceToken
			}, null, CreateCallBack);
			return;
		}
		if (testApi != null)
		{
			Text text2 = testApi;
			text2.text = text2.text + "Login: " + data.ContinuanceToken?.ToString() + "\n";
		}
		if (testApi != null)
		{
			Text text3 = testApi;
			text3.text = text3.text + data.LocalUserId.ToString() + "\n";
		}
		Debug.LogError("Login: " + data.ContinuanceToken);
		canSendAchievements = true;
		LocalUserId = data.LocalUserId;
	}

	public void UnlockAchievements(string[] achievementIds, string userId)
	{
		Debug.LogError("ACHIEVEMENT");
		UnlockAchievementsOptions unlockAchievementsOptions = new UnlockAchievementsOptions();
		unlockAchievementsOptions.UserId = ProductUserId.FromString(userId);
		unlockAchievementsOptions.AchievementIds = achievementIds;
		s_PlatformInterface.GetAchievementsInterface().UnlockAchievements(unlockAchievementsOptions, new object(), AchievementCallback);
	}

	private void AchievementCallback(OnUnlockAchievementsCompleteCallbackInfo data)
	{
		Debug.LogError("Achievement " + data.ResultCode);
	}

	private void Update()
	{
		if (s_PlatformInterface != null)
		{
			m_PlatformTickTimer += Time.deltaTime;
			if (m_PlatformTickTimer >= 0.1f)
			{
				m_PlatformTickTimer = 0f;
				s_PlatformInterface.Tick();
			}
		}
		if (canSendAchievements && achievements.Count > 0)
		{
			UnlockAchievement(achievements[0]);
			achievements.RemoveAt(0);
		}
	}
}
