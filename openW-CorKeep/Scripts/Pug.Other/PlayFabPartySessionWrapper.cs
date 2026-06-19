using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PartyCSharpSDK;
using PlayFab;
using PlayFab.Party;
using UnityEngine;

public class PlayFabPartySessionWrapper : IDisposable
{
	public const int RECONNECT_STEP_COUNT = 5;

	private const PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS PartySessionOptions = (PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS)15u;

	private const int PLAYFAB_NETWORK_JOIN_TIMEOUT_S = 10;

	private PlayFabMultiplayerManager _playfabPartyManager;

	private Task _connectSessionTask;

	private CancellationTokenSource _connectSessionCancellation;

	private Task _stopSessionTask;

	private IPlayFabAuthentication _authentication;

	private IPlayFabLobbyInterface _lobbyManager;

	private IPlatformSessionManager _platformSessionManager;

	private Dictionary<Platform, string> _platformSessionIds = new Dictionary<Platform, string>();

	private Task _crossPlatformSessionInitiationTask;

	private CancellationTokenSource _crossPlatformSessionInitiationCancellation;

	private Task _recreateGameIDTask;

	private CancellationTokenSource _recreateGameIDCancellation;

	public string SessionUID => _lobbyManager?.LobbyId;

	public string JoinString => _lobbyManager?.JoinString;

	public bool IsInSession { get; private set; }

	public bool IsHost { get; private set; }

	public bool IsDisconnecting
	{
		get
		{
			if (_stopSessionTask != null)
			{
				return !_stopSessionTask.IsCompleted;
			}
			return false;
		}
	}

	public bool IsConnecting
	{
		get
		{
			if (_connectSessionTask != null)
			{
				return !_connectSessionTask.IsCompleted;
			}
			return false;
		}
	}

	public string CurrentReconnectStatus { get; private set; }

	public int CurrentReconnectStep { get; private set; }

	public uint MaxPlayerCount { get; private set; }

	public PlayFabPartySessionWrapper(PlayFabMultiplayerManager manager)
	{
		_playfabPartyManager = manager;
		InitializePlatformSpecificManagers();
	}

	public async void Dispose()
	{
		StopSession();
		if (_stopSessionTask != null)
		{
			await _stopSessionTask;
		}
		_authentication.Destroy();
		_authentication = null;
		_platformSessionManager = null;
		IsHost = false;
		_playfabPartyManager.OnNetworkChanged -= OnNetworkChanged;
		_connectSessionCancellation?.Dispose();
		_recreateGameIDCancellation?.Dispose();
		_crossPlatformSessionInitiationCancellation?.Dispose();
	}

	public void Update()
	{
		_authentication.Update();
		_platformSessionManager.Update();
	}

	public void JoinSession(string connectId, Action<string> callback)
	{
		PreSessionStart();
		Task newConnectTask = null;
		newConnectTask = WrapTaskExecution(async delegate
		{
			await WaitForTaskCompletion(_stopSessionTask);
			Debug.Log("PlayFabPartySessionWrapper.JoinSession");
			_connectSessionTask = newConnectTask;
			IsInSession = true;
			IsHost = false;
			Manager.networking.connectionFailedReason = null;
			Manager.networking.connectionFailed = false;
			_connectSessionCancellation?.Dispose();
			_connectSessionCancellation = new CancellationTokenSource();
			_crossPlatformSessionInitiationCancellation?.Dispose();
			_crossPlatformSessionInitiationCancellation = new CancellationTokenSource();
			Debug.Log("PlayFabPartySessionWrapper.JoinSession: Starting user login.");
			AuthenticationVO authenticationVO = await _authentication.Login(_connectSessionCancellation.Token);
			if (!CheckSessionStepFailure("Authentication", authenticationVO, callback) && !WasConnectCancelled(callback))
			{
				HandleAuthenticationSuccess(authenticationVO);
				Debug.Log("PlayFabPartySessionWrapper.JoinSession: Joining lobby.");
				string error = await _lobbyManager.JoinLobby(connectId, _connectSessionCancellation.Token);
				if (!CheckSessionStepFailure("JoinLobby", error, callback))
				{
					if (!_lobbyManager.SupportsCrossPlatformSessions)
					{
						Debug.Log("PlayFabPartySessionWrapper.JoinSession: Joining platform session.");
						var (platformSession, error2) = await _platformSessionManager.JoinSessionAsync(_lobbyManager.LobbyId, _connectSessionCancellation.Token);
						if (CheckSessionStepFailure("JoinPlatformSession", error2, callback) || WasConnectCancelled(callback))
						{
							return;
						}
						if (platformSession == null || platformSession.SessionId == null)
						{
							Debug.LogWarning("PlayFabPartySessionWrapper.JoinSession: Returned null platformsession. Canceling joining");
							CheckSessionStepFailure("JoinPlatformSession", Manager.platform.hasNetwork ? "Error/GameNotFound" : "Error/NoNetwork", callback);
							return;
						}
						Debug.Log("PlayFabPartySessionWrapper.JoinSession: joined platform session.");
					}
					Debug.Log("PlayFabPartySessionWrapper.JoinSession: Joining network.");
					string networkDescriptor = _lobbyManager.NetworkId;
					if (string.IsNullOrEmpty(networkDescriptor))
					{
						Debug.LogError("PlayFabPartySessionWrapper.JoinSession: Network id is null or empty. Can't join PlayFab network.");
						CheckSessionStepFailure("JoinPlayFabNetwork", "Consoles/SessionJoinFailed", callback);
					}
					else
					{
						string item = (await JoinNetworkAsync(networkDescriptor, delegate
						{
							_playfabPartyManager.JoinNetwork(networkDescriptor);
						})).Item2;
						if (!CheckSessionStepFailure("JoinPlayFabNetwork", item, callback) && !WasConnectCancelled(callback))
						{
							UpdateSessionInfo();
							Debug.Log("PlayFabPartySessionWrapper.JoinSession: Join network complete.");
							PrintPartyConnectionType();
							callback(null);
						}
					}
				}
			}
		}, callback);
	}

	public void CreateSession(uint maxPlayerCount, Action<string> callback)
	{
		PreSessionStart();
		Task newConnectTask = null;
		newConnectTask = WrapTaskExecution(async delegate
		{
			await WaitForTaskCompletion(_stopSessionTask);
			Debug.Log("PlayFabPartySessionWrapper.CreateSession");
			_connectSessionTask = newConnectTask;
			IsInSession = true;
			IsHost = true;
			MaxPlayerCount = maxPlayerCount;
			_connectSessionCancellation?.Dispose();
			_connectSessionCancellation = new CancellationTokenSource();
			_crossPlatformSessionInitiationCancellation?.Dispose();
			_crossPlatformSessionInitiationCancellation = new CancellationTokenSource();
			Debug.Log("PlayFabPartySessionWrapper.CreateSession: Starting user login.");
			AuthenticationVO authenticationVO = await _authentication.Login(_connectSessionCancellation.Token);
			if (!CheckSessionStepFailure("Authentication", authenticationVO, callback) && !WasConnectCancelled(callback))
			{
				HandleAuthenticationSuccess(authenticationVO);
				Debug.Log("PlayFabPartySessionWrapper.CreateSession: Create and join PlayFab network.");
				var (networkId, error) = await JoinNetworkAsync(null, delegate
				{
					_playfabPartyManager.CreateAndJoinNetwork(new PlayFabNetworkConfiguration
					{
						MaxPlayerCount = maxPlayerCount,
						DirectPeerConnectivityOptions = (PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS)15u
					});
				});
				if (!CheckSessionStepFailure("CreateAndJoinPlayFabNetwork", error, callback) && !WasConnectCancelled(callback))
				{
					Debug.Log("PlayFabPartySessionWrapper.CreateSession: Create and join PlayFab network successful.");
					PrintPartyConnectionType();
					Debug.Log("PlayFabPartySessionWrapper.CreateSession: Creating lobby.");
					string error2 = await _lobbyManager.CreateLobby(networkId, maxPlayerCount, _connectSessionCancellation.Token);
					if (!CheckSessionStepFailure("CreateLobby", error2, callback) && !WasConnectCancelled(callback))
					{
						Debug.Log("PlayFabPartySessionWrapper.CreateSession: Creating platform session.");
						var (session, error3) = await _platformSessionManager.StartSessionAsync(CreatePlatformSessionParams(), _connectSessionCancellation.Token);
						if (!CheckSessionStepFailure("CreatePlatformSession", error3, callback) && !WasConnectCancelled(callback))
						{
							PlatformSessionCreatedSuccessfully(session);
							callback(null);
						}
					}
				}
			}
		}, callback);
	}

	public void StopSession()
	{
		if (IsDisconnecting)
		{
			Debug.Log("PlayFabPartySessionWrapper.StopSession: Tried to stop session while it is already being stopped.");
			return;
		}
		_stopSessionTask = WrapTaskExecution(async delegate
		{
			Debug.Log("PlayFabPartySessionWrapper.StopSession");
			_connectSessionCancellation?.Cancel();
			_crossPlatformSessionInitiationCancellation?.Cancel();
			await WaitForTaskCompletion(_crossPlatformSessionInitiationTask);
			_platformSessionIds.Clear();
			await WaitForTaskCompletion(_connectSessionTask);
			_recreateGameIDCancellation?.Cancel();
			Debug.Log("PlayFabPartySessionWrapper.StopSession: Ending platform session.");
			string item = (await _platformSessionManager.EndSessionAsync()).Item2;
			if (item == null)
			{
				Debug.Log("PlayFabPartySessionWrapper.StopSession: left platform session.");
			}
			else
			{
				Debug.LogError("PlayFabPartySessionWrapper.StopSession: Failed to leave platform session: " + item + ".");
			}
			Debug.Log("PlayFabPartySessionWrapper.StopSession: Leave lobby.");
			item = await _lobbyManager.LeaveLobby();
			if (item == null)
			{
				Debug.Log("PlayFabPartySessionWrapper.StopSession: left lobby.");
			}
			else
			{
				Debug.LogError("PlayFabPartySessionWrapper.StopSession: Failed to leave lobby: " + item + ".");
			}
			Debug.Log("PlayFabPartySessionWrapper.StopSession: Leaving PlayFabPartyNetwork.");
			item = await LeaveNetworkAsync();
			if (item == null)
			{
				Debug.Log("PlayFabPartySessionWrapper.StopSession: Successfully left PlayFabPartyNetwork.");
			}
			else
			{
				Debug.LogError("PlayFabPartySessionWrapper.StopSession: Failed to leave PlayFabPartyNetwork: " + item + ".");
			}
			Debug.Log("PlayFabPartySessionWrapper.StopSession: Starting user logout.");
			await _authentication.Logout();
			Debug.Log("PlayFabPartySessionWrapper.StopSession: User logged out.");
			IsHost = false;
			MaxPlayerCount = 0u;
			await WaitForTaskCompletion(_recreateGameIDTask);
			IsInSession = false;
			Debug.Log("PlayFabPartySessionWrapper.StopSession: Session stop complete.");
		}, null);
	}

	public bool ReconnectSession(int timeoutInSeconds, Action<string> callback)
	{
		if (IsDisconnecting)
		{
			Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Already trying to disconnect.");
			return false;
		}
		if (IsConnecting)
		{
			Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Already trying to connect.");
			return false;
		}
		if (!IsInSession)
		{
			Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Tried to rejoin session, while not currently in any session.");
			return false;
		}
		CurrentReconnectStatus = "Error/ReconnectNetwork";
		CurrentReconnectStep = 1;
		_connectSessionTask = WrapTaskExecution(async delegate
		{
			_connectSessionCancellation?.Dispose();
			_connectSessionCancellation = new CancellationTokenSource();
			using CancellationTokenSource timeoutCancellation = new CancellationTokenSource(1000 * timeoutInSeconds);
			using CancellationTokenSource linkedCancellation = CancellationTokenSource.CreateLinkedTokenSource(_connectSessionCancellation.Token, timeoutCancellation.Token);
			Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Checking for internet connection.");
			bool hasNetwork = false;
			bool showUi = true;
			while (!hasNetwork)
			{
				hasNetwork = await PlayFabPartyNetworking.CheckForInternetConnectivity(showUi);
				if (WasConnectCancelled(callback, timeoutCancellation))
				{
					return;
				}
				await Task.Delay(2000);
				showUi = false;
			}
			if (!CheckSessionStepFailure("CheckInternetConnectivity", hasNetwork ? null : "Error/NoNetwork", callback))
			{
				Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: User has internet connection.");
				CurrentReconnectStatus = "Error/ReconnectAuthentication";
				int currentReconnectStep = CurrentReconnectStep;
				CurrentReconnectStep = currentReconnectStep + 1;
				if (!_authentication.IsAuthenticated)
				{
					Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Trying to login again.");
					await _authentication.Logout();
					AuthenticationVO authResult = await _authentication.Login(linkedCancellation.Token);
					if (CheckSessionStepFailure("Authentication", authResult, callback) || WasConnectCancelled(callback, timeoutCancellation))
					{
						return;
					}
					Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Login completed.");
				}
				CurrentReconnectStatus = "Error/ReconnectLobby";
				currentReconnectStep = CurrentReconnectStep;
				CurrentReconnectStep = currentReconnectStep + 1;
				if (!CheckSessionStepFailure("RejoinLobby", (_lobbyManager.JoinString == null) ? "Error/ConnectionClose" : null, callback) && !WasConnectCancelled(callback, timeoutCancellation))
				{
					CurrentReconnectStatus = "Error/ReconnectPlatformSession";
					currentReconnectStep = CurrentReconnectStep;
					CurrentReconnectStep = currentReconnectStep + 1;
					if (_platformSessionManager.CurrentPlatformSession == null)
					{
						Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Trying to rejoin platform session.");
						PlatformSessionParams platformSessionParams = CreatePlatformSessionParams();
						(PlatformSession, string) tuple = await _platformSessionManager.JoinSessionAsync(platformSessionParams.SessionId, linkedCancellation.Token);
						if (CheckSessionStepFailure("RejoinPlatformSession", tuple.Item2, callback) || WasConnectCancelled(callback, timeoutCancellation))
						{
							return;
						}
						Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Platform session rejoin completed.");
					}
					CurrentReconnectStatus = "Error/ReconnectPlayFabNetwork";
					currentReconnectStep = CurrentReconnectStep;
					CurrentReconnectStep = currentReconnectStep + 1;
					(string id, string error) rejoinNetworkResult = (id: null, error: null);
					if (_lobbyManager.NetworkId != null)
					{
						do
						{
							Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Trying to rejoin Party Network.");
							string networkDescriptor = _lobbyManager.NetworkId;
							rejoinNetworkResult = await JoinNetworkAsync(networkDescriptor, delegate
							{
								_playfabPartyManager.JoinNetwork(networkDescriptor);
							});
							if (WasConnectCancelled(callback, timeoutCancellation))
							{
								return;
							}
							if (IsHost)
							{
								break;
							}
							if (rejoinNetworkResult.error != null)
							{
								Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Rejoining PlayFab network failed, trying again with slight delay.");
								await Task.Delay(2000);
							}
							if (WasConnectCancelled(callback, timeoutCancellation))
							{
								return;
							}
						}
						while (rejoinNetworkResult.error != null);
					}
					else if (!IsHost)
					{
						CheckSessionStepFailure("RejoinPlayFabNetwork", "Error/ConnectionClose", callback);
						return;
					}
					if ((IsHost || !CheckSessionStepFailure("RejoinPlayFabNetwork", rejoinNetworkResult.error, callback)) && !WasConnectCancelled(callback, timeoutCancellation))
					{
						if (rejoinNetworkResult.error != null && IsHost)
						{
							Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Rejoining PlayFab network failed, trying to create new one.");
							rejoinNetworkResult = await JoinNetworkAsync(null, delegate
							{
								_playfabPartyManager.CreateAndJoinNetwork(new PlayFabNetworkConfiguration
								{
									MaxPlayerCount = MaxPlayerCount,
									DirectPeerConnectivityOptions = (PARTY_DIRECT_PEER_CONNECTIVITY_OPTIONS)15u
								});
							});
							if (CheckSessionStepFailure("RecreatePlayFabNetwork", rejoinNetworkResult.error, callback) || WasConnectCancelled(callback, timeoutCancellation))
							{
								return;
							}
							Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Party Network recreate completed.");
						}
						string error = await _lobbyManager.UpdateLobbyData(_lobbyManager.LobbyId, rejoinNetworkResult.id, linkedCancellation.Token);
						if (!CheckSessionStepFailure("UpdateLobbyInfo", error, callback) && !WasConnectCancelled(callback, timeoutCancellation))
						{
							UpdateSessionInfo();
							Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Party Network rejoin completed.");
							Debug.Log("PlayFabPartySessionWrapper.ReconnectSession: Rejoined session successfully.");
							callback(null);
						}
					}
				}
			}
		}, callback, delegate
		{
			CurrentReconnectStatus = null;
			CurrentReconnectStep = 0;
		});
		return true;
	}

	public void CancelConnect()
	{
		if (IsConnecting && _connectSessionCancellation != null)
		{
			_connectSessionCancellation.Cancel();
		}
	}

	private bool CheckSessionStepFailure(string stepName, AuthenticationVO authResult, Action<string> errorCallback)
	{
		return CheckSessionStepFailure(stepName, authResult.Success ? null : "Error/AuthenticationFailed", errorCallback);
	}

	private bool CheckSessionStepFailure(string stepName, string error, Action<string> errorCallback)
	{
		if (error == null)
		{
			return false;
		}
		Debug.Log("PlayFabPartySessionWrapper.CheckSessionStepFailure: Session connect step '" + stepName + "' failed. Stopping session connect.");
		_connectSessionCancellation?.Cancel();
		errorCallback(error);
		return true;
	}

	public void StartSessionInivitationFlow()
	{
		_platformSessionManager.StartFriendInvitation();
	}

	public void SendSessionInvitations(List<PlatformUserID> invitees, Action<bool> callback)
	{
	}

	public void UpdateSessionInfo()
	{
		if (_platformSessionManager.CurrentPlatformSession != null)
		{
			PlatformSessionParams sessionParams = CreatePlatformSessionParams();
			List<string> list = new List<string>();
			list = _playfabPartyManager.RemotePlayers.Select((PlayFabPlayer x) => x?.EntityKey?.Id).ToList();
			_platformSessionManager.UpdateSessionInfo(sessionParams, list);
		}
	}

	public void RecreateGameId()
	{
		if (!IsHost)
		{
			Debug.LogWarning("PlayFabPartySessionWrapper.RecreateGameId: this should not be run for the non-host clients!");
			return;
		}
		if (!_authentication.IsAuthenticated)
		{
			Debug.LogWarning("PlayFabPartySessionWrapper.RecreateGameId: not logged in.");
			return;
		}
		IPlayFabLobbyInterface lobbyManager = _lobbyManager;
		PlayFabLobbyManager lobbyManager2 = lobbyManager as PlayFabLobbyManager;
		if (lobbyManager2 == null)
		{
			Debug.LogError("PlayFabPartySessionWrapper.RecreateGameId: Trying to recreate GameID but not using PlayFabLobbyManager.");
			return;
		}
		Task runningTask = _recreateGameIDTask;
		_recreateGameIDTask = WrapTaskExecution(async delegate
		{
			if (runningTask != null && !runningTask.IsCompleted && _recreateGameIDCancellation != null)
			{
				_recreateGameIDCancellation.Cancel();
				await runningTask;
			}
			_recreateGameIDCancellation?.Dispose();
			_recreateGameIDCancellation = new CancellationTokenSource();
			string item = (await lobbyManager2.RecreateGameID(_recreateGameIDCancellation.Token)).Item2;
			if (!_recreateGameIDCancellation.Token.IsCancellationRequested)
			{
				if (item == null)
				{
					UpdateSessionInfo();
				}
				_recreateGameIDCancellation = null;
			}
		}, null);
	}

	public void UpdateSessionID(string newId)
	{
		if (!newId.Equals(SessionUID))
		{
			Debug.Log("PlayFabPartySessionWrapper.UpdateSessionID: session identifier updated from " + SessionUID + " to " + newId);
			_lobbyManager.UpdateLobbyDataInternal(newId, _lobbyManager.NetworkId);
		}
		UpdateLobbyAndSessionInfo(newId, _lobbyManager.NetworkId);
	}

	private void UpdateLobbyAndSessionInfo(string lobbyId, string networkId)
	{
		WrapTaskExecution(async delegate
		{
			using (CancellationTokenSource cancellation = new CancellationTokenSource())
			{
				string text = await _lobbyManager.UpdateLobbyData(lobbyId, networkId, cancellation.Token);
				if (cancellation.Token.IsCancellationRequested || text != null)
				{
					return;
				}
			}
			UpdateSessionInfo();
		}, null);
	}

	private void PreSessionStart()
	{
		if (IsConnecting)
		{
			Debug.LogWarning("PlayFabPartySessionWrapper.PreSessionStart: Trying to create / join session, while already waiting for session intiation.");
			StopSession();
		}
		else if (IsInSession)
		{
			Debug.LogWarning("PlayFabPartySessionWrapper.PreSessionStart: Trying to create / join session, while already in a session.");
			StopSession();
		}
	}

	public void PrintPartyConnectionType(PlayFabPlayer player = null)
	{
		PlayFabMultiplayerManager.PartyNetworkConnectionType devicePartyNetworkConnectionTypeByPlayer = _playfabPartyManager.GetDevicePartyNetworkConnectionTypeByPlayer(player);
		Debug.Log(string.Format("{0}: connection type is {1}.", "PlayFabPartySessionWrapper", devicePartyNetworkConnectionTypeByPlayer));
	}

	private async Task WaitForTaskCompletion(Task task)
	{
		if (task != null && !task.IsCompleted)
		{
			try
			{
				await task;
			}
			catch (Exception exception)
			{
				Debug.LogError("Waiting on other task completion yielded exception:");
				Debug.LogException(exception);
			}
		}
	}

	private bool WasConnectCancelled(Action<string> initiationCallback, CancellationTokenSource timeoutCancellation = null)
	{
		if (timeoutCancellation != null && timeoutCancellation.IsCancellationRequested)
		{
			initiationCallback("Error/Timeout");
			return true;
		}
		if (_connectSessionCancellation != null && _connectSessionCancellation.IsCancellationRequested)
		{
			initiationCallback("Error/Canceled");
			return true;
		}
		return false;
	}

	private async Task<(string networkId, string error)> JoinNetworkAsync(string networkDescriptor, Action networkOperation)
	{
		_playfabPartyManager.OnNetworkChanged -= OnNetworkChanged;
		_playfabPartyManager.OnNetworkChanged += OnNetworkChanged;
		_lobbyManager.NetworkIdChanged -= OnNetworkIdChanged;
		_lobbyManager.NetworkIdChanged += OnNetworkIdChanged;
		if (networkDescriptor != null && _playfabPartyManager.State == PlayFabMultiplayerManagerState.ConnectedToNetwork && _playfabPartyManager.NetworkId == networkDescriptor)
		{
			Debug.Log("PlayFabPartySessionWrapper.JoinNetworkAsync: Already connected to this network");
			return (networkId: _playfabPartyManager.NetworkId, error: null);
		}
		using CancellationTokenSource timeoutCancellation = new CancellationTokenSource();
		TaskCompletionSource<(string networkId, string error)> networkJoinCompletion = new TaskCompletionSource<(string, string)>();
		_playfabPartyManager.OnNetworkJoined += OnNetworkJoined;
		_playfabPartyManager.OnError += OnPlayFabError;
		(string id, string error) result = (id: null, error: null);
		try
		{
			timeoutCancellation.CancelAfter(10000);
			using (timeoutCancellation.Token.Register(delegate
			{
				networkJoinCompletion.SetCanceled();
			}, useSynchronizationContext: false))
			{
				networkOperation();
				result = await networkJoinCompletion.Task;
			}
		}
		catch (TaskCanceledException)
		{
			Debug.LogError("PlayFabPartySessionWrapper.JoinNetworkAsync: Network join timed out.");
			if (result.error == null)
			{
				result.error = "Error/Timeout";
			}
		}
		finally
		{
			_playfabPartyManager.OnNetworkJoined -= OnNetworkJoined;
			_playfabPartyManager.OnError -= OnPlayFabError;
		}
		if (result.id == null && result.error == null)
		{
			result.error = "Error/ConnectionClose";
		}
		return result;
		void OnNetworkJoined(object sender, string id)
		{
			networkJoinCompletion.TrySetResult((id, null));
		}
		void OnPlayFabError(object sender, PlayFabMultiplayerManagerErrorArgs args)
		{
			Debug.Log(string.Format("{0}.{1}: Received PlayFab Error while trying to join network: {2} - {3} - {4}", "PlayFabPartySessionWrapper", "JoinNetworkAsync", args.Type, args.Code, args.Message));
			networkJoinCompletion.TrySetResult((null, PlayFabPartyNetworking.ConvertPlayFabError(args)));
		}
	}

	private async Task<string> LeaveNetworkAsync()
	{
		if (_playfabPartyManager.NetworkId == null)
		{
			Debug.Log("PlayFabPartySessionWrapper.LeaveNetworkAsync: Tried to leave network, but not currently connected to a network.");
			return null;
		}
		using CancellationTokenSource timeoutCancellation = new CancellationTokenSource();
		TaskCompletionSource<string> networkLeaveCompletion = new TaskCompletionSource<string>();
		_playfabPartyManager.OnNetworkLeft += OnNetworkLeft;
		_playfabPartyManager.OnError += OnPlayFabError;
		string error = null;
		try
		{
			using (timeoutCancellation.Token.Register(delegate
			{
				networkLeaveCompletion.SetCanceled();
			}, useSynchronizationContext: false))
			{
				timeoutCancellation.CancelAfter(10000);
				_playfabPartyManager.LeaveNetwork();
				error = await networkLeaveCompletion.Task;
			}
		}
		catch (TaskCanceledException)
		{
			Debug.LogError("PlayFabPartySessionWrapper.LeaveNetworkAsync: Network leave timed out.");
			if (error == null)
			{
				error = "Error/Timeout";
			}
		}
		finally
		{
			_playfabPartyManager.OnNetworkLeft -= OnNetworkLeft;
			_playfabPartyManager.OnError -= OnPlayFabError;
			_playfabPartyManager.OnNetworkChanged -= OnNetworkChanged;
			_lobbyManager.NetworkIdChanged -= OnNetworkIdChanged;
		}
		return error;
		void OnNetworkLeft(object sender, string networkId)
		{
			networkLeaveCompletion.TrySetResult(null);
		}
		void OnPlayFabError(object sender, PlayFabMultiplayerManagerErrorArgs args)
		{
			Debug.Log(string.Format("{0}.{1}: Received PlayFab Error while trying to leave network: {2} - {3} - {4}", "PlayFabPartySessionWrapper", "JoinNetworkAsync", args.Type, args.Code, args.Message));
			networkLeaveCompletion.TrySetResult("Consoles/ConnectionErrorGeneric");
		}
	}

	private void OnNetworkChanged(object sender, string newNetworkId)
	{
		Debug.Log("PlayFabPartySessionWrapper.OnNetworkChanged");
		UpdateLobbyAndSessionInfo(_lobbyManager.LobbyId, newNetworkId);
	}

	private void HandleAuthenticationSuccess(AuthenticationVO vo)
	{
		Debug.Log("PlayFabPartySessionWrapper.HandleAuthenticationSuccess: PlayFab user logged in successfully.");
		_playfabPartyManager.LocalPlayer.IsMuted = true;
		_playfabPartyManager.LocalPlayer.LanguageCode = Manager.prefs.language;
	}

	private void PlatformSessionCreatedSuccessfully(PlatformSession session)
	{
		Debug.Log("PlayFabPartySessionWrapper: platform session created.");
		_platformSessionIds[Manager.platform.Platform] = session.SessionId;
	}

	private PlatformSessionParams CreatePlatformSessionParams()
	{
		if (Manager.networking.OfflineSession)
		{
			Debug.LogWarning("PlayFabPartySessionWrapper.CreatePlatformSessionParams: no need to create platform session parameters for an offline game.");
			return null;
		}
		if (_lobbyManager.LobbyId == null)
		{
			Debug.Log("PlayFabPartySessionWrapper.CreatePlatformSessionParams: Not connected to any lobby.");
			return null;
		}
		WorldInfo worldInfo = Manager.saves.GetWorldInfo();
		if (worldInfo == null)
		{
			Debug.LogWarning("PlayFabPartySessionWrapper.CreatePlatformSessionParams: world info is null still.");
		}
		return new PlatformSessionParams
		{
			SessionId = _lobbyManager.LobbyId,
			JoinString = _lobbyManager.JoinString,
			WorldName = (worldInfo?.name ?? ""),
			MaxPlayers = MaxPlayerCount,
			IconIndex = (worldInfo?.iconIndex ?? 0),
			WorldMode = (worldInfo?.mode ?? WorldMode.Normal),
			IsHosting = IsHost
		};
	}

	private void OnNetworkIdChanged(string networkId)
	{
		if (IsHost)
		{
			Debug.LogError("PlayFabPartySessionWrapper.OnNetworkIdChanged: Should not be receiving this event as host.");
			return;
		}
		if (!IsInSession)
		{
			Debug.LogWarning("PlayFabPartySessionWrapper.OnNetworkIdChanged: Network id changed while not in a session.");
			return;
		}
		Debug.Log("PlayFabPartySessionWrapper.OnNetworkIdChanged: Network id changed. Trying to join new network via reconnect flow.");
		ReconnectSession(15, delegate(string error)
		{
			Debug.LogError("PlayFabPartySessionWrapper.OnNetworkIdChanged: Failed to reconnect to session: " + error + ".");
		});
	}

	public CrossPlatformSessionData CreateCrossPlatformSessionData()
	{
		return new CrossPlatformSessionData
		{
			platformSessionData = CreatePlatformSessionParams(),
			platformSessionIds = _platformSessionIds
		};
	}

	public void ReceiveCrossPlatformSessionData(CrossPlatformSessionData crossPlatformData, Action<PlatformSession> newPlatformSessionCreatedCallback)
	{
		Debug.Log("PlayFabPartySessionWrapper.ReceiveCrossPlatformSessionData: Received cross platform session data.");
		if (IsHost)
		{
			Debug.Log("PlayFabPartySessionWrapper.ReceiveCrossPlatformSessionData: Adding session data to host storage.");
			{
				foreach (Platform key in crossPlatformData.platformSessionIds.Keys)
				{
					_platformSessionIds[key] = crossPlatformData.platformSessionIds[key];
				}
				return;
			}
		}
		if (_crossPlatformSessionInitiationCancellation.IsCancellationRequested)
		{
			return;
		}
		Task previousTask = _crossPlatformSessionInitiationTask;
		if (crossPlatformData.platformSessionIds.TryGetValue(Manager.platform.Platform, out var sessionId))
		{
			_crossPlatformSessionInitiationTask = WrapTaskExecution(async delegate
			{
				Debug.Log("PlayFabPartySessionWrapper.ReceiveCrossPlatformSessionData: Trying to join existing session.");
				await WaitForTaskCompletion(previousTask);
				if (!_crossPlatformSessionInitiationCancellation.IsCancellationRequested)
				{
					PlatformSession item = (await _platformSessionManager.JoinSessionAsync(sessionId, _crossPlatformSessionInitiationCancellation.Token)).Item1;
					if (!_crossPlatformSessionInitiationCancellation.IsCancellationRequested)
					{
						if (item == null || item.SessionId == null)
						{
							Debug.LogWarning("PlayFabPartySessionWrapper.ReceiveCrossPlatformSessionData: Returned null platformsession. Starting our own instead.");
							await CreateNewCrossplayPlatformSession(crossPlatformData.platformSessionData, newPlatformSessionCreatedCallback, _crossPlatformSessionInitiationCancellation);
						}
						else
						{
							UpdateSessionInfo();
						}
					}
				}
			}, null);
			return;
		}
		_crossPlatformSessionInitiationTask = WrapTaskExecution(async delegate
		{
			await WaitForTaskCompletion(previousTask);
			if (!_crossPlatformSessionInitiationCancellation.IsCancellationRequested)
			{
				await CreateNewCrossplayPlatformSession(crossPlatformData.platformSessionData, newPlatformSessionCreatedCallback, _crossPlatformSessionInitiationCancellation);
			}
		}, null);
	}

	private async Task<PlatformSession> CreateNewCrossplayPlatformSession(PlatformSessionParams sessionParams, Action<PlatformSession> newPlatformSessionCreatedCallback, CancellationTokenSource cancellationToken)
	{
		var (platformSession, text) = await _platformSessionManager.StartSessionAsync(sessionParams, _crossPlatformSessionInitiationCancellation.Token);
		if (cancellationToken.IsCancellationRequested)
		{
			return null;
		}
		if (platformSession == null || text != null)
		{
			Debug.LogError("PlayFabPartySessionWrapper.CreateNewCrossplayPlatformSession: Creating session returned null platformsession (error: " + text + ").");
			return null;
		}
		PlatformSessionCreatedSuccessfully(platformSession);
		if (!cancellationToken.IsCancellationRequested)
		{
			newPlatformSessionCreatedCallback?.Invoke(platformSession);
		}
		return platformSession;
	}

	private Task WrapTaskExecution(Func<Task> asyncTask, Action<string> errorCallback, Action finallyCallback = null)
	{
		return Task.Run(async delegate
		{
			try
			{
				await asyncTask();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				errorCallback?.Invoke("Error/Unknown");
			}
			finally
			{
				finallyCallback?.Invoke();
			}
		});
	}

	private void InitializePlatformSpecificManagers()
	{
		_authentication = new SteamPlayFabAuthentication(PlayFabSettings.staticSettings.TitleId);
		_platformSessionManager = new DummySessionManager();
		_lobbyManager = new PlayFabLobbyManager();
	}
}
