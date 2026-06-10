using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Epic.OnlineServices;
using Epic.OnlineServices.Achievements;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Ecom;
using Epic.OnlineServices.Friends;
using Epic.OnlineServices.Leaderboards;
using Epic.OnlineServices.Lobby;
using Epic.OnlineServices.Logging;
using Epic.OnlineServices.Metrics;
using Epic.OnlineServices.Mods;
using Epic.OnlineServices.P2P;
using Epic.OnlineServices.Platform;
using Epic.OnlineServices.PlayerDataStorage;
using Epic.OnlineServices.Presence;
using Epic.OnlineServices.RTC;
using Epic.OnlineServices.Sessions;
using Epic.OnlineServices.Stats;
using Epic.OnlineServices.TitleStorage;
using Epic.OnlineServices.UI;
using Epic.OnlineServices.UserInfo;
using UnityEngine;

namespace PlayEveryWare.EpicOnlineServices
{
	public class EOSManager : MonoBehaviour, IEOSCoroutineOwner
	{
		public delegate void OnAuthLoginCallback(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo);

		public delegate void OnAuthLogoutCallback(LogoutCallbackInfo data);

		public delegate void OnConnectLoginCallback(Epic.OnlineServices.Connect.LoginCallbackInfo loginCallbackInfo);

		public delegate void OnCreateConnectUserCallback(CreateUserCallbackInfo createUserCallbackInfo);

		public delegate void OnConnectLinkExternalAccountCallback(Epic.OnlineServices.Connect.LinkAccountCallbackInfo linkAccountCallbackInfo);

		public delegate void OnAuthLinkExternalAccountCallback(Epic.OnlineServices.Auth.LinkAccountCallbackInfo linkAccountCallbackInfo);

		private enum EOSState
		{
			NotStarted = 0,
			Starting = 1,
			Running = 2,
			ShuttingDown = 3,
			Shutdown = 4
		}

		public class EOSSingleton
		{
			public struct EpicLauncherArgs
			{
				public string authLogin;

				public string authPassword;

				public string authType;

				public string epicApp;

				public string epicEnv;

				public string epicUsername;

				public string epicUserID;

				public string epicLocale;
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			private delegate void PrintDelegateType(string str);

			private static EpicAccountId s_localUserId;

			private static ProductUserId s_localProductUserId = null;

			private static NotifyEventHandle s_notifyLoginStatusChangedCallbackHandle;

			private static NotifyEventHandle s_notifyConnectLoginStatusChangedCallbackHandle;

			private static EOSConfig loadedEOSConfig;

			private static bool hasSetLoggingCallback = false;

			private static bool s_hasInitializedPlatform = false;

			private static PlatformInterface s_eosPlatformInterface;

			public const string EOSBinaryName = "EOSSDK-Win64-Shipping";

			public const string GfxPluginNativeRenderPath = "GfxPluginNativeRender-x64";

			private static Dictionary<string, DLLHandle> LoadedDLLs = new Dictionary<string, DLLHandle>();

			private static bool loadEOSWithReflection = false;

			protected void SetLocalUserId(EpicAccountId localUserId)
			{
				s_localUserId = localUserId;
			}

			public EpicAccountId GetLocalUserId()
			{
				return s_localUserId;
			}

			private string PUIDToString(ProductUserId puid)
			{
				string text = null;
				if (puid != null)
				{
					text = puid.ToString();
				}
				if (text == null)
				{
					text = "null";
				}
				return text;
			}

			protected void SetLocalProductUserId(ProductUserId localProductUserId)
			{
				s_localProductUserId = localProductUserId;
			}

			public ProductUserId GetProductUserId()
			{
				return s_localProductUserId;
			}

			private EOSConfig GetLoadedEOSConfig()
			{
				return loadedEOSConfig;
			}

			public string GetProductId()
			{
				return GetLoadedEOSConfig().productID;
			}

			public string GetSandboxId()
			{
				return GetLoadedEOSConfig().sandboxID;
			}

			public string GetDeploymentID()
			{
				return GetLoadedEOSConfig().deploymentID;
			}

			public bool IsEncryptionKeyValid()
			{
				return GetLoadedEOSConfig().IsEncryptionKeyValid();
			}

			private bool HasShutdown()
			{
				return s_state == EOSState.Shutdown;
			}

			public bool HasLoggedInWithConnect()
			{
				return s_localProductUserId != null;
			}

			public bool ShouldOverlayReceiveInput()
			{
				if (!s_isOverlayVisible || !s_DoesOverlayHaveExcusiveInput)
				{
					return GetLoadedEOSConfig().alwaysSendInputToOverlay;
				}
				return true;
			}

			public bool IsOverlayOpenWithExclusiveInput()
			{
				if (s_isOverlayVisible)
				{
					return s_DoesOverlayHaveExcusiveInput;
				}
				return false;
			}

			[Conditional("ENABLE_DEBUG_EOSMANAGER")]
			private static void print(string toPrint)
			{
				UnityEngine.Debug.Log(toPrint);
			}

			public T GetOrCreateManager<T>() where T : IEOSSubManager, new()
			{
				T val = default(T);
				Type typeFromHandle = typeof(T);
				if (!s_subManagers.ContainsKey(typeFromHandle))
				{
					val = new T();
					s_subManagers.Add(typeFromHandle, val);
					if (val is IEOSOnConnectLogin)
					{
						s_onConnectLoginCallbacks.Add((val as IEOSOnConnectLogin).OnConnectLogin);
					}
					if (val is IEOSOnAuthLogin)
					{
						s_onAuthLoginCallbacks.Add((val as IEOSOnAuthLogin).OnAuthLogin);
					}
					if (val is IEOSOnAuthLogout)
					{
						s_onAuthLogoutCallbacks.Add((val as IEOSOnAuthLogout).OnAuthLogout);
					}
				}
				else
				{
					val = (T)s_subManagers[typeFromHandle];
				}
				return val;
			}

			public void RemoveManager<T>() where T : IEOSSubManager
			{
				Type typeFromHandle = typeof(T);
				if (s_subManagers.ContainsKey(typeFromHandle))
				{
					T val = (T)s_subManagers[typeFromHandle];
					if (val is IEOSOnConnectLogin)
					{
						s_onConnectLoginCallbacks.Remove((val as IEOSOnConnectLogin).OnConnectLogin);
					}
					if (val is IEOSOnAuthLogin)
					{
						s_onAuthLoginCallbacks.Remove((val as IEOSOnAuthLogin).OnAuthLogin);
					}
					if (val is IEOSOnAuthLogout)
					{
						s_onAuthLogoutCallbacks.Remove((val as IEOSOnAuthLogout).OnAuthLogout);
					}
					s_subManagers.Remove(typeFromHandle);
				}
			}

			private Result InitializePlatformInterface(EOSConfig configData)
			{
				IEOSManagerPlatformSpecifics instance = EOSManagerPlatformSpecifics.Instance;
				IEOSInitializeOptions initializeOptions = instance.CreateSystemInitOptions();
				initializeOptions.ProductName = configData.productName;
				initializeOptions.ProductVersion = configData.productVersion;
				initializeOptions.OverrideThreadAffinity = default(InitializeThreadAffinity);
				initializeOptions.AllocateMemoryFunction = IntPtr.Zero;
				initializeOptions.ReallocateMemoryFunction = IntPtr.Zero;
				initializeOptions.ReleaseMemoryFunction = IntPtr.Zero;
				InitializeThreadAffinity value = default(InitializeThreadAffinity);
				value.NetworkWork = configData.GetThreadAffinityNetworkWork(value.NetworkWork);
				value.StorageIo = configData.GetThreadAffinityStorageIO(value.StorageIo);
				value.WebSocketIo = configData.GetThreadAffinityWebSocketIO(value.WebSocketIo);
				value.P2PIo = configData.GetThreadAffinityP2PIO(value.P2PIo);
				value.HttpRequestIo = configData.GetThreadAffinityHTTPRequestIO(value.HttpRequestIo);
				value.RTCIo = configData.GetThreadAffinityRTCIO(value.RTCIo);
				initializeOptions.OverrideThreadAffinity = value;
				instance.ConfigureSystemInitOptions(ref initializeOptions, configData);
				RegisterForPlatformNotifications();
				return instance.InitializePlatformInterface(initializeOptions);
			}

			private PlatformInterface CreatePlatformInterface(EOSConfig configData)
			{
				IEOSManagerPlatformSpecifics instance = EOSManagerPlatformSpecifics.Instance;
				IEOSCreateOptions createOptions = instance.CreateSystemPlatformOption();
				createOptions.CacheDirectory = instance.GetTempDir();
				createOptions.IsServer = false;
				createOptions.Flags = configData.platformOptionsFlagsAsPlatformFlags();
				if (configData.IsEncryptionKeyValid())
				{
					createOptions.EncryptionKey = configData.encryptionKey;
				}
				else
				{
					UnityEngine.Debug.LogError("EOS config data does not contain valid encryption key");
				}
				createOptions.OverrideCountryCode = null;
				createOptions.OverrideLocaleCode = null;
				createOptions.ProductId = configData.productID;
				createOptions.SandboxId = configData.sandboxID;
				createOptions.DeploymentId = configData.deploymentID;
				createOptions.TickBudgetInMilliseconds = configData.tickBudgetInMilliseconds;
				ClientCredentials clientCredentials = new ClientCredentials
				{
					ClientId = configData.clientID,
					ClientSecret = configData.clientSecret
				};
				createOptions.ClientCredentials = clientCredentials;
				instance.ConfigureSystemPlatformCreateOptions(ref createOptions);
				return instance.CreatePlatformInterface(createOptions);
			}

			private void InitializeOverlay(IEOSCoroutineOwner coroutineOwner)
			{
				EOSManagerPlatformSpecifics.Instance.InitializeOverlay(coroutineOwner);
				AddNotifyDisplaySettingsUpdatedOptions options = default(AddNotifyDisplaySettingsUpdatedOptions);
				GetEOSUIInterface().AddNotifyDisplaySettingsUpdated(ref options, null, delegate(ref OnDisplaySettingsUpdatedCallbackInfo data)
				{
					s_isOverlayVisible = data.IsVisible;
					s_DoesOverlayHaveExcusiveInput = data.IsExclusiveInput;
				});
			}

			public void Init(IEOSCoroutineOwner coroutineOwner)
			{
				Init(coroutineOwner, ConfigFileName);
			}

			public void Init(IEOSCoroutineOwner coroutineOwner, string configFileName)
			{
				if (GetEOSPlatformInterface() != null)
				{
					if (!hasSetLoggingCallback)
					{
						LoggingInterface.SetCallback(SimplePrintCallback);
						hasSetLoggingCallback = true;
					}
					SetLogLevel(LogCategory.AllCategories, LogLevel.Warning);
					EpicLauncherArgs commandLineArgsFromEpicLauncher = Instance.GetCommandLineArgsFromEpicLauncher();
					Instance.StartLoginWithLoginTypeAndToken(LoginCredentialType.ExchangeCode, string.Empty, commandLineArgsFromEpicLauncher.authPassword, StartLoginWithLoginTypeAndTokenCallback);
					InitializeOverlay(coroutineOwner);
					return;
				}
				s_state = EOSState.Starting;
				LoadEOSLibraries();
				NativeCallToUnloadEOS();
				string text = Path.Combine(Application.streamingAssetsPath, "EOS", configFileName);
				if (!File.Exists(text))
				{
					throw new Exception("Couldn't find EOS Config file: Please ensure " + text + " exists and is a valid config");
				}
				EOSConfig configData = JsonUtility.FromJson<EOSConfig>(File.ReadAllText(text));
				Result result = InitializePlatformInterface(configData);
				UnityEngine.Debug.LogWarning($"EOSManager::Init: InitializePlatformInterface: initResult = {result}");
				if (result != Result.Success)
				{
					throw new Exception("Epic Online Services didn't init correctly: " + result);
				}
				s_hasInitializedPlatform = true;
				LoggingInterface.SetCallback(SimplePrintCallback);
				SetLogLevel(LogCategory.AllCategories, LogLevel.Warning);
				PlatformInterface platformInterface = CreatePlatformInterface(configData);
				if (platformInterface == null)
				{
					throw new Exception("failed to create an Epic Online Services PlatformInterface");
				}
				SetEOSPlatformInterface(platformInterface);
				UpdateEOSApplicationStatus();
				loadedEOSConfig = configData;
				InitializeOverlay(coroutineOwner);
			}

			private void StartLoginWithLoginTypeAndTokenCallback(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo)
			{
				if (loginCallbackInfo.ResultCode == Result.Success)
				{
					StartConnectLoginWithLoginCallbackInfo(loginCallbackInfo);
				}
				else
				{
					UnityEngine.Debug.LogError("loginCallbackInfo result code: " + loginCallbackInfo.ResultCode);
				}
			}

			private void StartConnectLoginWithLoginCallbackInfo(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo)
			{
				Instance.StartConnectLoginWithEpicAccount(loginCallbackInfo.LocalUserId, delegate(Epic.OnlineServices.Connect.LoginCallbackInfo connectLoginCallbackInfo)
				{
					if (connectLoginCallbackInfo.ResultCode == Result.Success)
					{
						Connected = true;
					}
					else if (connectLoginCallbackInfo.ResultCode == Result.InvalidUser)
					{
						Instance.CreateConnectUserWithContinuanceToken(connectLoginCallbackInfo.ContinuanceToken, delegate
						{
							Instance.StartConnectLoginWithEpicAccount(loginCallbackInfo.LocalUserId, delegate
							{
								Connected = true;
							});
						});
					}
				});
			}

			public void RegisterForPlatformNotifications()
			{
				IEOSManagerPlatformSpecifics instance = EOSManagerPlatformSpecifics.Instance;
				if (instance != null)
				{
					UnityEngine.Debug.Log("EOSManager: Registering for platform-specific notifications");
					instance.RegisterForPlatformNotifications();
				}
			}

			[MonoPInvokeCallback(typeof(string))]
			private static void SimplePrintStringCallback(string str)
			{
				UnityEngine.Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", str);
			}

			[MonoPInvokeCallback(typeof(LogMessageFunc))]
			private static void SimplePrintCallback(ref LogMessage message)
			{
				DateTime now = DateTime.Now;
				Utf8String utf8String = ((message.Category.Length == 0) ? new Utf8String() : message.Category);
				LogType logType = ((message.Level >= LogLevel.Warning) ? ((message.Level <= LogLevel.Warning) ? LogType.Warning : LogType.Log) : LogType.Error);
				UnityEngine.Debug.LogFormat(logType, LogOption.NoStacktrace, null, "{0:O} {1}({2}): {3}", now, utf8String, message.Level, message.Message);
			}

			public void SetLogLevel(LogCategory Category, LogLevel Level)
			{
				LoggingInterface.SetLogLevel(Category, Level);
				if (logLevels == null)
				{
					logLevels = new Dictionary<LogCategory, LogLevel>();
				}
				if (Category == LogCategory.AllCategories)
				{
					foreach (LogCategory value in Enum.GetValues(typeof(LogCategory)))
					{
						if (value != LogCategory.AllCategories)
						{
							logLevels[value] = Level;
						}
					}
					return;
				}
				logLevels[Category] = Level;
			}

			public LogLevel GetLogLevel(LogCategory Category)
			{
				if (logLevels == null)
				{
					return LogLevel.Off;
				}
				if (Category == LogCategory.AllCategories)
				{
					LogLevel logLevel = GetLogLevel(LogCategory.Core);
					{
						foreach (LogCategory value in Enum.GetValues(typeof(LogCategory)))
						{
							if (value != LogCategory.AllCategories && GetLogLevel(value) != logLevel)
							{
								return (LogLevel)(-1);
							}
						}
						return logLevel;
					}
				}
				if (logLevels.ContainsKey(Category))
				{
					return logLevels[Category];
				}
				return LogLevel.Off;
			}

			[MonoPInvokeCallback(typeof(LogMessageFunc))]
			private static void SimplePrintCallbackWithCallstack(LogMessage message)
			{
				DateTime now = DateTime.Now;
				Utf8String utf8String = ((message.Category.Length == 0) ? new Utf8String() : message.Category);
				UnityEngine.Debug.LogFormat(null, "{0:O} {1}({2}): {3}", now, utf8String, message.Level, message.Message);
			}

			private static Epic.OnlineServices.Auth.LoginOptions MakeLoginOptions(LoginCredentialType loginType, ExternalCredentialType externalCredentialType, string id, string token)
			{
				Epic.OnlineServices.Auth.Credentials value = new Epic.OnlineServices.Auth.Credentials
				{
					Type = loginType,
					ExternalType = externalCredentialType,
					Id = id,
					Token = token
				};
				return new Epic.OnlineServices.Auth.LoginOptions
				{
					Credentials = value,
					ScopeFlags = (AuthScopeFlags.BasicProfile | AuthScopeFlags.FriendsList | AuthScopeFlags.Presence)
				};
			}

			public Token? GetUserAuthTokenForAccountId(EpicAccountId accountId)
			{
				AuthInterface authInterface = GetEOSPlatformInterface().GetAuthInterface();
				CopyUserAuthTokenOptions options = default(CopyUserAuthTokenOptions);
				authInterface.CopyUserAuthToken(ref options, accountId, out var outUserAuthToken);
				return outUserAuthToken;
			}

			public EpicLauncherArgs GetCommandLineArgsFromEpicLauncher()
			{
				EpicLauncherArgs result = default(EpicLauncherArgs);
				string[] commandLineArgs = Environment.GetCommandLineArgs();
				foreach (string text in commandLineArgs)
				{
					if (text.StartsWith("-AUTH_LOGIN="))
					{
						ConfigureEpicArgument(text, ref result.authLogin);
					}
					else if (text.StartsWith("-AUTH_PASSWORD="))
					{
						ConfigureEpicArgument(text, ref result.authPassword);
					}
					else if (text.StartsWith("-AUTH_TYPE="))
					{
						ConfigureEpicArgument(text, ref result.authType);
					}
					else if (text.StartsWith("-epicapp="))
					{
						ConfigureEpicArgument(text, ref result.epicApp);
					}
					else if (text.StartsWith("-epicenv="))
					{
						ConfigureEpicArgument(text, ref result.epicEnv);
					}
					else if (text.StartsWith("-epicusername="))
					{
						ConfigureEpicArgument(text, ref result.epicUsername);
					}
					else if (text.StartsWith("-epicuserid="))
					{
						ConfigureEpicArgument(text, ref result.epicUserID);
					}
					else if (text.StartsWith("-epiclocale="))
					{
						ConfigureEpicArgument(text, ref result.epicLocale);
					}
				}
				return result;
				static void ConfigureEpicArgument(string argument, ref string argumentString)
				{
					int num = argument.IndexOf('=') + 1;
					if (num >= 0 && num <= argument.Length)
					{
						argumentString = argument.Substring(num);
					}
				}
			}

			public void CreateConnectUserWithContinuanceToken(ContinuanceToken token, OnCreateConnectUserCallback onCreateUserCallback)
			{
				ConnectInterface connectInterface = GetEOSPlatformInterface().GetConnectInterface();
				CreateUserOptions options = new CreateUserOptions
				{
					ContinuanceToken = token
				};
				connectInterface.CreateUser(ref options, null, delegate(ref CreateUserCallbackInfo createUserCallbackInfo)
				{
					if (createUserCallbackInfo.ResultCode == Result.Success)
					{
						SetLocalProductUserId(createUserCallbackInfo.LocalUserId);
					}
					if (onCreateUserCallback != null)
					{
						onCreateUserCallback(createUserCallbackInfo);
					}
				});
			}

			public void AuthLinkExternalAccountWithContinuanceToken(ContinuanceToken token, LinkAccountFlags linkAccountFlags, OnAuthLinkExternalAccountCallback callback)
			{
				AuthInterface authInterface = GetEOSPlatformInterface().GetAuthInterface();
				Epic.OnlineServices.Auth.LinkAccountOptions options = new Epic.OnlineServices.Auth.LinkAccountOptions
				{
					ContinuanceToken = token,
					LinkAccountFlags = linkAccountFlags,
					LocalUserId = null
				};
				if (linkAccountFlags.HasFlag(LinkAccountFlags.NintendoNsaId))
				{
					options.LocalUserId = Instance.GetLocalUserId();
				}
				authInterface.LinkAccount(ref options, null, delegate(ref Epic.OnlineServices.Auth.LinkAccountCallbackInfo linkAccountCallbackInfo)
				{
					Instance.SetLocalUserId(linkAccountCallbackInfo.LocalUserId);
					if (callback != null)
					{
						callback(linkAccountCallbackInfo);
					}
				});
			}

			public void ConnectLinkExternalAccountWithContinuanceToken(ContinuanceToken token, OnConnectLinkExternalAccountCallback callback)
			{
				ConnectInterface connectInterface = GetEOSPlatformInterface().GetConnectInterface();
				Epic.OnlineServices.Connect.LinkAccountOptions options = new Epic.OnlineServices.Connect.LinkAccountOptions
				{
					ContinuanceToken = token,
					LocalUserId = Instance.GetProductUserId()
				};
				connectInterface.LinkAccount(ref options, null, delegate(ref Epic.OnlineServices.Connect.LinkAccountCallbackInfo linkAccountCallbackInfo)
				{
					if (callback != null)
					{
						callback(linkAccountCallbackInfo);
					}
				});
			}

			public void StartConnectLoginWithEpicAccount(EpicAccountId epicAccountId, OnConnectLoginCallback onConnectLoginCallback)
			{
				Token? userAuthTokenForAccountId = Instance.GetUserAuthTokenForAccountId(epicAccountId);
				StartConnectLoginWithOptions(new Epic.OnlineServices.Connect.LoginOptions
				{
					Credentials = new Epic.OnlineServices.Connect.Credentials
					{
						Token = userAuthTokenForAccountId.Value.AccessToken,
						Type = ExternalCredentialType.Epic
					}
				}, delegate(Epic.OnlineServices.Connect.LoginCallbackInfo connectLoginData)
				{
					if (onConnectLoginCallback != null)
					{
						onConnectLoginCallback(connectLoginData);
					}
				});
			}

			public void StartConnectLoginWithOptions(ExternalCredentialType externalCredentialType, string displayname, string token, OnConnectLoginCallback onloginCallback)
			{
				Epic.OnlineServices.Connect.LoginOptions connectLoginOptions = new Epic.OnlineServices.Connect.LoginOptions
				{
					Credentials = new Epic.OnlineServices.Connect.Credentials
					{
						Token = token,
						Type = externalCredentialType
					}
				};
				switch (externalCredentialType)
				{
				case ExternalCredentialType.XblXstsToken:
					connectLoginOptions.UserLoginInfo = null;
					break;
				case ExternalCredentialType.NintendoIdToken:
				case ExternalCredentialType.NintendoNsaIdToken:
				case ExternalCredentialType.AppleIdToken:
					connectLoginOptions.UserLoginInfo = new UserLoginInfo
					{
						DisplayName = displayname
					};
					break;
				}
				StartConnectLoginWithOptions(connectLoginOptions, onloginCallback);
			}

			public void StartConnectLoginWithOptions(Epic.OnlineServices.Connect.LoginOptions connectLoginOptions, OnConnectLoginCallback onloginCallback)
			{
				GetEOSPlatformInterface().GetConnectInterface().Login(ref connectLoginOptions, null, delegate(ref Epic.OnlineServices.Connect.LoginCallbackInfo connectLoginData)
				{
					if (connectLoginData.LocalUserId != null)
					{
						SetLocalProductUserId(connectLoginData.LocalUserId);
						ConfigureConnectStatusCallback();
						CallOnConnectLogin(connectLoginData);
					}
					if (onloginCallback != null)
					{
						onloginCallback(connectLoginData);
					}
				});
			}

			public void StartConnectLoginWithDeviceToken(string displayName, OnConnectLoginCallback onLoginCallback)
			{
				GetEOSPlatformInterface().GetConnectInterface();
				StartConnectLoginWithOptions(new Epic.OnlineServices.Connect.LoginOptions
				{
					UserLoginInfo = new UserLoginInfo
					{
						DisplayName = displayName
					},
					Credentials = new Epic.OnlineServices.Connect.Credentials
					{
						Token = null,
						Type = ExternalCredentialType.DeviceidAccessToken
					}
				}, onLoginCallback);
			}

			public void ConnectTransferDeviceIDAccount(TransferDeviceIdAccountOptions options, object clientData, OnTransferDeviceIdAccountCallback completionDelegate = null)
			{
				GetEOSPlatformInterface().GetConnectInterface().TransferDeviceIdAccount(ref options, clientData, delegate(ref TransferDeviceIdAccountCallbackInfo data)
				{
					SetLocalProductUserId(data.LocalUserId);
					if (completionDelegate != null)
					{
						completionDelegate(ref data);
					}
				});
			}

			public void StartPersistentLogin(OnAuthLoginCallback onLoginCallback)
			{
				StartLoginWithLoginTypeAndToken(LoginCredentialType.PersistentAuth, null, null, delegate(Epic.OnlineServices.Auth.LoginCallbackInfo callbackInfo)
				{
					Result resultCode = callbackInfo.ResultCode;
					if (resultCode == Result.AuthInvalidRefreshToken || resultCode == Result.AuthInvalidPlatformToken)
					{
						AuthInterface authInterface = Instance.GetEOSPlatformInterface().GetAuthInterface();
						DeletePersistentAuthOptions options = default(DeletePersistentAuthOptions);
						authInterface.DeletePersistentAuth(ref options, null, delegate
						{
							if (onLoginCallback != null)
							{
								onLoginCallback(callbackInfo);
							}
						});
					}
					else if (onLoginCallback != null)
					{
						onLoginCallback(callbackInfo);
					}
				});
			}

			public void StartLoginWithLoginTypeAndToken(LoginCredentialType loginType, string id, string token, OnAuthLoginCallback onLoginCallback)
			{
				StartLoginWithLoginTypeAndToken(loginType, ExternalCredentialType.Epic, id, token, onLoginCallback);
			}

			public void StartLoginWithLoginTypeAndToken(LoginCredentialType loginType, ExternalCredentialType externalCredentialType, string id, string token, OnAuthLoginCallback onLoginCallback)
			{
				Epic.OnlineServices.Auth.LoginOptions loginOptions = MakeLoginOptions(loginType, externalCredentialType, id, token);
				StartLoginWithLoginOptions(loginOptions, onLoginCallback);
			}

			private void ConfigureAuthStatusCallback()
			{
				if (s_notifyLoginStatusChangedCallbackHandle != null)
				{
					return;
				}
				AuthInterface authInterface = GetEOSPlatformInterface().GetAuthInterface();
				Epic.OnlineServices.Auth.AddNotifyLoginStatusChangedOptions options = default(Epic.OnlineServices.Auth.AddNotifyLoginStatusChangedOptions);
				s_notifyLoginStatusChangedCallbackHandle = new NotifyEventHandle(authInterface.AddNotifyLoginStatusChanged(ref options, null, delegate(ref Epic.OnlineServices.Auth.LoginStatusChangedCallbackInfo callbackInfo)
				{
					if (callbackInfo.CurrentStatus == LoginStatus.NotLoggedIn && callbackInfo.PrevStatus == LoginStatus.LoggedIn)
					{
						loggedInAccountIDs.Remove(callbackInfo.LocalUserId);
						SetLocalUserId(null);
					}
				}), delegate(ulong handle)
				{
					GetEOSAuthInterface()?.RemoveNotifyLoginStatusChanged(handle);
				});
			}

			private void ConfigureConnectStatusCallback()
			{
				if (s_notifyConnectLoginStatusChangedCallbackHandle != null)
				{
					return;
				}
				ConnectInterface eOSConnectInterface = GetEOSConnectInterface();
				Epic.OnlineServices.Connect.AddNotifyLoginStatusChangedOptions options = default(Epic.OnlineServices.Connect.AddNotifyLoginStatusChangedOptions);
				s_notifyConnectLoginStatusChangedCallbackHandle = new NotifyEventHandle(eOSConnectInterface.AddNotifyLoginStatusChanged(ref options, null, delegate(ref Epic.OnlineServices.Connect.LoginStatusChangedCallbackInfo callbackInfo)
				{
					if (callbackInfo.CurrentStatus == LoginStatus.NotLoggedIn && callbackInfo.PreviousStatus == LoginStatus.LoggedIn)
					{
						SetLocalProductUserId(null);
					}
					else if (callbackInfo.CurrentStatus == LoginStatus.LoggedIn && callbackInfo.PreviousStatus == LoginStatus.NotLoggedIn)
					{
						SetLocalProductUserId(callbackInfo.LocalUserId);
					}
				}), delegate(ulong handle)
				{
					GetEOSConnectInterface()?.RemoveNotifyLoginStatusChanged(handle);
				});
			}

			private void CallOnAuthLogin(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo)
			{
				foreach (OnAuthLoginCallback s_onAuthLoginCallback in s_onAuthLoginCallbacks)
				{
					s_onAuthLoginCallback(loginCallbackInfo);
				}
			}

			private void CallOnConnectLogin(Epic.OnlineServices.Connect.LoginCallbackInfo connectLoginData)
			{
				foreach (OnConnectLoginCallback s_onConnectLoginCallback in s_onConnectLoginCallbacks)
				{
					s_onConnectLoginCallback(connectLoginData);
				}
			}

			public void StartLoginWithLoginOptions(Epic.OnlineServices.Auth.LoginOptions loginOptions, OnAuthLoginCallback onLoginCallback)
			{
				AuthInterface authInterface = GetEOSPlatformInterface().GetAuthInterface();
				SetDisplayPreferenceOptions options = new SetDisplayPreferenceOptions
				{
					NotificationLocation = NotificationLocation.TopRight
				};
				Instance.GetEOSPlatformInterface().GetUIInterface().SetDisplayPreference(ref options);
				authInterface.Login(ref loginOptions, null, delegate(ref Epic.OnlineServices.Auth.LoginCallbackInfo data)
				{
					if (data.ResultCode == Result.Success)
					{
						loggedInAccountIDs.Add(data.LocalUserId);
						SetLocalUserId(data.LocalUserId);
						ConfigureAuthStatusCallback();
						CallOnAuthLogin(data);
					}
					if (onLoginCallback != null)
					{
						onLoginCallback(data);
					}
				});
			}

			public void SetPresenceRichTextForUser(EpicAccountId accountId, string richText)
			{
				PresenceInterface eOSPresenceInterface = GetEOSPresenceInterface();
				PresenceModification outPresenceModificationHandle = new PresenceModification();
				CreatePresenceModificationOptions options = new CreatePresenceModificationOptions
				{
					LocalUserId = accountId
				};
				if (eOSPresenceInterface.CreatePresenceModification(ref options, out outPresenceModificationHandle) != Result.Success)
				{
					UnityEngine.Debug.LogError("Unable to create presence modfication handle");
				}
				PresenceModificationSetStatusOptions options2 = new PresenceModificationSetStatusOptions
				{
					Status = Status.Online
				};
				if (outPresenceModificationHandle.SetStatus(ref options2) != Result.Success)
				{
					UnityEngine.Debug.LogError("unable to set status");
				}
				PresenceModificationSetRawRichTextOptions options3 = new PresenceModificationSetRawRichTextOptions
				{
					RichText = richText
				};
				outPresenceModificationHandle.SetRawRichText(ref options3);
				SetPresenceOptions options4 = new SetPresenceOptions
				{
					LocalUserId = accountId,
					PresenceModificationHandle = outPresenceModificationHandle
				};
				eOSPresenceInterface.SetPresence(ref options4, null, delegate(ref SetPresenceCallbackInfo callbackInfo)
				{
					if (callbackInfo.ResultCode != Result.Success)
					{
						UnityEngine.Debug.LogError("Unable to set presence: " + callbackInfo.ResultCode);
					}
				});
			}

			public void StartLogout(EpicAccountId accountId, OnLogoutCallback onLogoutCallback)
			{
				AuthInterface authInterface = GetEOSPlatformInterface().GetAuthInterface();
				LogoutOptions options = new LogoutOptions
				{
					LocalUserId = accountId
				};
				authInterface.Logout(ref options, null, delegate(ref LogoutCallbackInfo data)
				{
					if (onLogoutCallback != null)
					{
						onLogoutCallback(ref data);
						foreach (OnLogoutCallback s_onAuthLogoutCallback in s_onAuthLogoutCallbacks)
						{
							s_onAuthLogoutCallback(ref data);
						}
					}
				});
			}

			public void Tick()
			{
				if (GetEOSPlatformInterface() != null)
				{
					UpdateApplicationConstrainedState(shouldUpdateEOSAppStatus: true);
					UpdateNetworkStatus();
					GetEOSPlatformInterface().Tick();
				}
			}

			public void OnShutdown()
			{
				PlatformInterface eOSPlatformInterface = GetEOSPlatformInterface();
				if (eOSPlatformInterface != null)
				{
					AuthInterface authInterface = eOSPlatformInterface.GetAuthInterface();
					LogoutOptions options = default(LogoutOptions);
					foreach (EpicAccountId loggedInAccountID in loggedInAccountIDs)
					{
						options.LocalUserId = loggedInAccountID;
						authInterface.Logout(ref options, null, delegate(ref LogoutCallbackInfo data)
						{
							if (data.ResultCode == Result.Success)
							{
								Connected = false;
							}
						});
					}
				}
				if (!HasShutdown())
				{
					OnApplicationShutdown();
				}
			}

			public void OnApplicationShutdown()
			{
				if (!HasShutdown())
				{
					s_state = EOSState.ShuttingDown;
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GetEOSPlatformInterface()?.Release();
					ShutdownPlatformInterface();
					SetEOSPlatformInterface(null);
					s_state = EOSState.Shutdown;
				}
			}

			private void ShutdownPlatformInterface()
			{
				if (s_hasInitializedPlatform)
				{
					PlatformInterface.Shutdown();
				}
				s_hasInitializedPlatform = false;
			}

			public ApplicationStatus GetEOSApplicationStatus()
			{
				return GetEOSPlatformInterface().GetApplicationStatus();
			}

			private void SetEOSApplicationStatus(ApplicationStatus newStatus)
			{
				if (GetEOSApplicationStatus() != newStatus)
				{
					Result result = GetEOSPlatformInterface().SetApplicationStatus(newStatus);
					if (result != Result.Success)
					{
						UnityEngine.Debug.LogError($"EOSSingleton.SetEOSApplicationStatus: Error setting EOS application status (Result = {result})");
					}
				}
			}

			private void UpdateEOSApplicationStatus()
			{
				if (!(GetEOSPlatformInterface() == null))
				{
					if (s_isPaused)
					{
						SetEOSApplicationStatus(ApplicationStatus.BackgroundSuspended);
					}
					else if (s_hasFocus)
					{
						SetEOSApplicationStatus(ApplicationStatus.Foreground);
					}
					else if (s_isConstrained)
					{
						SetEOSApplicationStatus(ApplicationStatus.BackgroundConstrained);
					}
					else
					{
						SetEOSApplicationStatus(ApplicationStatus.BackgroundUnconstrained);
					}
				}
			}

			public void OnApplicationPause(bool isPaused)
			{
				_ = s_isPaused;
				s_isPaused = isPaused;
				UpdateApplicationConstrainedState(shouldUpdateEOSAppStatus: false);
			}

			public void OnApplicationFocus(bool hasFocus)
			{
				_ = s_hasFocus;
				s_hasFocus = hasFocus;
				UpdateApplicationConstrainedState(shouldUpdateEOSAppStatus: false);
			}

			public void OnApplicationConstrained(bool isConstrained, bool shouldUpdateEOSAppStatus)
			{
				_ = s_isConstrained;
				s_isConstrained = isConstrained;
				if (shouldUpdateEOSAppStatus)
				{
					UpdateEOSApplicationStatus();
				}
			}

			private void UpdateApplicationConstrainedState(bool shouldUpdateEOSAppStatus)
			{
				bool s_isConstrained = EOSManager.s_isConstrained;
				bool flag = EOSManagerPlatformSpecifics.Instance.IsApplicationConstrainedWhenOutOfFocus();
				if (s_isConstrained != flag)
				{
					OnApplicationConstrained(flag, shouldUpdateEOSAppStatus);
				}
			}

			private void UpdateNetworkStatus()
			{
				IEOSManagerPlatformSpecifics instance = EOSManagerPlatformSpecifics.Instance;
				if (instance != null && instance is IEOSNetworkStatusUpdater)
				{
					(instance as IEOSNetworkStatusUpdater).UpdateNetworkStatus();
				}
			}

			[DllImport("GfxPluginNativeRender-x64")]
			private static extern void UnloadEOS();

			[DllImport("GfxPluginNativeRender-x64", CallingConvention = CallingConvention.StdCall)]
			private static extern IntPtr EOS_GetPlatformInterface();

			[DllImport("GfxPluginNativeRender-x64", CallingConvention = CallingConvention.StdCall)]
			private static extern void global_log_flush_with_function(IntPtr ptr);

			private static void NativeCallToUnloadEOS()
			{
				DynamicLoadGFXNativeMethodsForWSA();
				UnloadEOS();
			}

			private static void DynamicLoadGFXNativeMethodsForWSA()
			{
			}

			public PlatformInterface GetEOSPlatformInterface()
			{
				if (s_eosPlatformInterface == null && s_state != EOSState.Shutdown)
				{
					IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate<PrintDelegateType>(SimplePrintStringCallback);
					SimplePrintStringCallback("Start of Early EOS LOG:");
					global_log_flush_with_function(functionPointerForDelegate);
					SimplePrintStringCallback("End of Early EOS LOG");
					if (EOS_GetPlatformInterface() == IntPtr.Zero)
					{
						throw new Exception("NULL EOS Platform returned by native code: issue probably occurred in GFX Plugin!");
					}
					SetEOSPlatformInterface(new PlatformInterface(EOS_GetPlatformInterface()));
				}
				return s_eosPlatformInterface;
			}

			private void SetEOSPlatformInterface(PlatformInterface platformInterface)
			{
				if (platformInterface != null)
				{
					s_state = EOSState.Running;
				}
				s_eosPlatformInterface = platformInterface;
			}

			private static void AddAllAssembliesInCurrentDomain(List<Assembly> list)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly item in assemblies)
				{
					list.Add(item);
				}
			}

			public static DLLHandle LoadDynamicLibrary(string libraryName)
			{
				if (LoadedDLLs.ContainsKey(libraryName))
				{
					return LoadedDLLs[libraryName];
				}
				DLLHandle dLLHandle = DLLHandle.LoadDynamicLibrary(libraryName);
				LoadedDLLs[libraryName] = dLLHandle;
				return dLLHandle;
			}

			public static void UnloadAllLibraries()
			{
				foreach (KeyValuePair<string, DLLHandle> loadedDLL in LoadedDLLs)
				{
					loadedDLL.Value.Dispose();
				}
				LoadedDLLs.Clear();
				LoadedDLLs = new Dictionary<string, DLLHandle>();
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}

			public static void LoadDelegatesWithEOSBindingAPI()
			{
			}

			public static void LoadDelegatesWithReflection()
			{
				List<Assembly> list = new List<Assembly>();
				DLLHandle dLLHandle = LoadDynamicLibrary("EOSSDK-Win64-Shipping");
				list.Add(typeof(PlatformInterface).Assembly);
				foreach (Assembly item in list)
				{
					Type[] types = item.GetTypes();
					foreach (Type type in types)
					{
						if (type.Namespace == null || !type.Namespace.StartsWith("Epic"))
						{
							continue;
						}
						MemberInfo[] members = type.GetMembers(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
						foreach (MemberInfo memberInfo in members)
						{
							FieldInfo field = type.GetField(memberInfo.Name);
							if (!(field == null) && field.FieldType.Name.EndsWith("_delegate"))
							{
								Type fieldType = field.FieldType;
								string functionName = memberInfo.Name.Replace("_delegate", "");
								dLLHandle.ConfigureFromLibraryDelegateFieldOnClassWithFunctionName(type, fieldType, functionName);
							}
						}
					}
				}
			}

			private static void LoadDelegatesByHand()
			{
			}

			private static void ForceUnloadEOSLibrary()
			{
			}

			public static void LoadEOSLibraries()
			{
				if (loadEOSWithReflection)
				{
					LoadDelegatesWithReflection();
				}
			}

			public AuthInterface GetEOSAuthInterface()
			{
				return GetEOSPlatformInterface().GetAuthInterface();
			}

			public AchievementsInterface GetEOSAchievementInterface()
			{
				return GetEOSPlatformInterface().GetAchievementsInterface();
			}

			public ConnectInterface GetEOSConnectInterface()
			{
				return GetEOSPlatformInterface().GetConnectInterface();
			}

			public EcomInterface GetEOSEcomInterface()
			{
				return GetEOSPlatformInterface().GetEcomInterface();
			}

			public FriendsInterface GetEOSFriendsInterface()
			{
				return GetEOSPlatformInterface().GetFriendsInterface();
			}

			public LeaderboardsInterface GetEOSLeaderboardsInterface()
			{
				return GetEOSPlatformInterface().GetLeaderboardsInterface();
			}

			public LobbyInterface GetEOSLobbyInterface()
			{
				return GetEOSPlatformInterface().GetLobbyInterface();
			}

			public MetricsInterface GetEOSMetricsInterface()
			{
				return GetEOSPlatformInterface().GetMetricsInterface();
			}

			public ModsInterface GetEOSModsInterface()
			{
				return GetEOSPlatformInterface().GetModsInterface();
			}

			public P2PInterface GetEOSP2PInterface()
			{
				return GetEOSPlatformInterface().GetP2PInterface();
			}

			public PlayerDataStorageInterface GetPlayerDataStorageInterface()
			{
				PlayerDataStorageInterface playerDataStorageInterface = GetEOSPlatformInterface().GetPlayerDataStorageInterface();
				if (playerDataStorageInterface == null)
				{
					throw new Exception("Could not get PlayerDataStorage interface, EncryptionKey maybe empty or null");
				}
				return playerDataStorageInterface;
			}

			public PresenceInterface GetEOSPresenceInterface()
			{
				return GetEOSPlatformInterface().GetPresenceInterface();
			}

			public RTCInterface GetEOSRTCInterface()
			{
				return GetEOSPlatformInterface().GetRTCInterface();
			}

			public SessionsInterface GetEOSSessionsInterface()
			{
				return GetEOSPlatformInterface().GetSessionsInterface();
			}

			public StatsInterface GetEOSStatsInterface()
			{
				return GetEOSPlatformInterface().GetStatsInterface();
			}

			public TitleStorageInterface GetEOSTitleStorageInterface()
			{
				return GetEOSPlatformInterface().GetTitleStorageInterface();
			}

			public UIInterface GetEOSUIInterface()
			{
				return GetEOSPlatformInterface().GetUIInterface();
			}

			public UserInfoInterface GetEOSUserInfoInterface()
			{
				return GetEOSPlatformInterface().GetUserInfoInterface();
			}
		}

		[NonSerialized]
		public bool InitializeOnAwake = true;

		public static string ConfigFileName = "EpicOnlineServicesConfig.json";

		public static string DefaultConfigFileName = "EpicOnlineServicesConfigDefault.json";

		public static string TestConfigFileName = "EpicOnlineServicesConfigTest.json";

		private static List<EpicAccountId> loggedInAccountIDs = new List<EpicAccountId>();

		private static Dictionary<Type, IEOSSubManager> s_subManagers = new Dictionary<Type, IEOSSubManager>();

		private static List<OnConnectLoginCallback> s_onConnectLoginCallbacks = new List<OnConnectLoginCallback>();

		private static List<OnAuthLoginCallback> s_onAuthLoginCallbacks = new List<OnAuthLoginCallback>();

		private static List<OnLogoutCallback> s_onAuthLogoutCallbacks = new List<OnLogoutCallback>();

		private static bool s_isOverlayVisible = false;

		private static bool s_DoesOverlayHaveExcusiveInput = false;

		private static Dictionary<LogCategory, LogLevel> logLevels = null;

		private static EOSState s_state = EOSState.NotStarted;

		private static bool s_isPaused = false;

		private static bool s_hasFocus = true;

		private static bool s_isConstrained = true;

		private static EOSSingleton s_instance;

		public static bool Connected { get; private set; }

		public static bool Running => s_state == EOSState.Running;

		public static bool ApplicationIsPaused => s_isPaused;

		public static bool ApplicationHasFocus => s_hasFocus;

		public static bool ApplicationIsConstrained => s_isConstrained;

		public static EOSSingleton Instance
		{
			get
			{
				if (s_instance == null)
				{
					s_instance = new EOSSingleton();
				}
				return s_instance;
			}
		}

		private void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(this);
			if (InitializeOnAwake)
			{
				UnityEngine.Debug.Log("Initializing EOS manager");
				Instance.Init(this);
			}
		}

		private void Update()
		{
			Instance.Tick();
		}

		private void OnApplicationQuit()
		{
			Instance.OnShutdown();
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			Instance.OnApplicationFocus(hasFocus);
		}

		private void OnApplicationPause(bool pauseStatus)
		{
			Instance.OnApplicationPause(pauseStatus);
		}

		void IEOSCoroutineOwner.StartCoroutine(IEnumerator routine)
		{
			StartCoroutine(routine);
		}
	}
}
