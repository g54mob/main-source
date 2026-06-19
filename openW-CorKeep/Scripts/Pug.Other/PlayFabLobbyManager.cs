using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using PlayFab;
using PlayFab.Multiplayer;
using PlayFab.MultiplayerModels;
using PlayFab.Party;
using Unity.Mathematics;
using UnityEngine;

public class PlayFabLobbyManager : IPlayFabLobbyInterface
{
	private const int GAME_ID_BASE_KEY_LENGTH = 3;

	private const string LOBBY_DATA_KEY_PARTY_DESCRIPTOR = "string_key1";

	private const string LOBBY_DATA_KEY_CROSSPLAY_ENABLED = "string_key2";

	private const string LOBBY_DATA_KEY_GAME_ID = "string_key3";

	private const string LOBBY_DATA_KEY_PLATFORM_NAME = "string_key4";

	private const string LOBBY_DATA_KEY_GAME_LOBBY_ID = "string_key5";

	private const string LOBBY_DATA_KEY_ENCRYPTED_PARTY_DESCRIPTOR = "string_key6";

	private const string LOBBY_DATA_KEY_AUTHENTICATION_SALT = "string_key7";

	private const string LOBBY_DATA_KEY_AUTHENTICATION_IV = "string_key8";

	private const string TOO_MANY_REQUESTS_ERROR_CODE = "801901AD";

	private const string SUBCEED_RETRY_PERIOD_ERROR_CODE = "8923640D";

	private GameID _gameID;

	private PlayFabPartyNetworkDescriptor _networkDescriptor;

	private PlayFab.Multiplayer.Lobby _currentLobby;

	public bool SupportsCrossPlatformSessions => true;

	public string LobbyId => _gameID?.fullId;

	public string JoinString => LobbyId;

	public string NetworkId => _networkDescriptor?.FullId;

	private PlayFab.Multiplayer.Lobby currentLobby
	{
		get
		{
			return _currentLobby;
		}
		set
		{
			if (_currentLobby != value)
			{
				if (value == null)
				{
					PlayFabMultiplayer.OnLobbyPostUpdateCompleted -= OnLobbyPostUpdateCompleted;
					PlayFabMultiplayer.OnLobbyUpdated -= OnLobbyUpdated;
					PlayFabMultiplayer.OnLobbyMemberRemoved -= OnLobbyMemberRemoved;
					PlayFabMultiplayer.OnLobbyMemberAdded -= OnLobbyMemberAdded;
					PlayFabMultiplayer.OnLobbyDisconnected -= OnLobbyDisconnected;
				}
				if (_currentLobby == null && value != null)
				{
					PlayFabMultiplayer.OnLobbyPostUpdateCompleted += OnLobbyPostUpdateCompleted;
					PlayFabMultiplayer.OnLobbyUpdated += OnLobbyUpdated;
					PlayFabMultiplayer.OnLobbyMemberRemoved += OnLobbyMemberRemoved;
					PlayFabMultiplayer.OnLobbyMemberAdded += OnLobbyMemberAdded;
				}
				_currentLobby = value;
			}
		}
	}

	public event Action<string> NetworkIdChanged;

	public async Task<string> CreateLobby(string networkId, uint maxPlayers, CancellationToken cancellationToken)
	{
		if (currentLobby != null)
		{
			Debug.LogWarning("PlayFabLobbyManager.CreateLobby: Already connected to a lobby, aborting.");
			return null;
		}
		(PlayFab.Multiplayer.Lobby, GameID, string) obj = await CreateLobbyInternal(networkId, maxPlayers, cancellationToken);
		PlayFab.Multiplayer.Lobby item = obj.Item1;
		GameID item2 = obj.Item2;
		string item3 = obj.Item3;
		_currentLobby = item;
		if (item == null || item3 != null)
		{
			return item3;
		}
		if (cancellationToken.IsCancellationRequested)
		{
			return null;
		}
		_gameID = item2;
		_networkDescriptor = new PlayFabPartyNetworkDescriptor(networkId);
		return null;
	}

	public async Task<string> JoinLobby(string joinString, CancellationToken cancellationToken)
	{
		if (currentLobby != null)
		{
			Debug.LogWarning("PlayFabLobbyManager.JoinLobby: Already connected to a lobby. Aborting.");
			return null;
		}
		GameID gameId = new GameID(joinString);
		FindLobbiesResult findLobbiesResult = await FindLobby(gameId);
		if (findLobbiesResult == null)
		{
			Debug.Log("PlayFabLobbyManager.JoinLobby: lobby find request failed.");
			return "Error/GameNotFound";
		}
		if (cancellationToken.IsCancellationRequested)
		{
			return null;
		}
		(PlayFab.Multiplayer.Lobby, string, string) obj = await JoinAnyLobby(findLobbiesResult.Lobbies, gameId, cancellationToken);
		PlayFab.Multiplayer.Lobby item = obj.Item1;
		string item2 = obj.Item2;
		string item3 = obj.Item3;
		_currentLobby = item;
		if (item3 != null)
		{
			return item3;
		}
		_gameID = gameId;
		_networkDescriptor = new PlayFabPartyNetworkDescriptor(item2);
		return null;
	}

	public void UpdateLobbyDataInternal(string lobbyId, string networkFullId)
	{
		if (currentLobby != null && (!(LobbyId == lobbyId) || !(networkFullId == NetworkId)))
		{
			_gameID = new GameID(lobbyId);
			_networkDescriptor = new PlayFabPartyNetworkDescriptor(networkFullId);
		}
	}

	public async Task<string> UpdateLobbyData(string lobbyId, string networkFullId, CancellationToken cancellationToken)
	{
		if (currentLobby == null)
		{
			Debug.LogError("PlayFabLobbyManager.UpdateLobbyData: Can't update lobby data without being connected to a lobby.");
			return "Error/ConnectionClose";
		}
		if (LobbyId == lobbyId && networkFullId == NetworkId)
		{
			return null;
		}
		string text = await UpdateLobbySearchDataWithCurrentSession(lobbyId, networkFullId, cancellationToken);
		if (cancellationToken.IsCancellationRequested)
		{
			return null;
		}
		if (text != null)
		{
			return text;
		}
		_gameID = new GameID(lobbyId);
		_networkDescriptor = new PlayFabPartyNetworkDescriptor(networkFullId);
		return null;
	}

	public async Task<string> LeaveLobby()
	{
		if (_currentLobby == null)
		{
			Debug.LogWarning("PlayFabLobbyManager.LeaveLobbyInternal: can't leave a lobby since we don't have a current one at the moment.");
			return null;
		}
		string text = await LeaveLobbyInternal(_currentLobby);
		_currentLobby = null;
		if (text != null)
		{
			Debug.Log("PlayFabLobbyManager.LeaveLobby: Failed to leave PlayFab lobby: " + text + ".");
		}
		_gameID = null;
		_networkDescriptor = null;
		return text;
	}

	public async Task<(GameID newId, string error)> RecreateGameID(CancellationToken cancellationToken)
	{
		GameID newId = await FindGameIdCheckCollisions(cancellationToken);
		if (newId == null)
		{
			Debug.Log("PlayFabLobbyManager.RecreateGameID: Failed to create new game id.");
			return (newId: null, error: "Consoles/SessionCreateFailed");
		}
		if (cancellationToken.IsCancellationRequested)
		{
			return (newId: null, error: null);
		}
		return (newId: newId, error: await UpdateLobbyData(newId.fullId, NetworkId, cancellationToken));
	}

	private async Task<GameID> FindGameIdCheckCollisions(CancellationToken cancellationToken)
	{
		for (int i = 0; i <= 20; i++)
		{
			TaskCompletionSource<GameID> gameIDCompletion = new TaskCompletionSource<GameID>();
			if (cancellationToken.IsCancellationRequested)
			{
				return null;
			}
			UnityMainThreadDispatcher.Instance().Enqueue(delegate
			{
				gameIDCompletion.SetResult(new GameID(3 + math.min(2, i)));
			});
			GameID gameId = await gameIDCompletion.Task;
			if (cancellationToken.IsCancellationRequested)
			{
				return null;
			}
			FindLobbiesResult findLobbiesResult = await FindLobby(gameId);
			if (findLobbiesResult?.Lobbies == null)
			{
				Debug.LogError("FindLobby returned no lobbies. Likely no internet connection.");
				return null;
			}
			if (findLobbiesResult.Lobbies.Count <= math.min(10, i))
			{
				Debug.Log($"Found game ID {gameId} with {findLobbiesResult.Lobbies.Count} collisions");
				return gameId;
			}
			if (i == 5)
			{
				Debug.LogWarning("> 5 retries for finding a game ID without too many collisions");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return null;
			}
		}
		Debug.LogError("20 retries for finding a game ID without too many collisions");
		return null;
	}

	private async Task<FindLobbiesResult> FindLobby(GameID gameId)
	{
		string filter = "string_key5 eq '" + gameId.PublicID + "'";
		TaskCompletionSource<FindLobbiesResult> findLobbiesCompletion = new TaskCompletionSource<FindLobbiesResult>();
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			PlayFabMultiplayerAPI.FindLobbies(new FindLobbiesRequest
			{
				Filter = filter
			}, delegate(FindLobbiesResult result)
			{
				findLobbiesCompletion.SetResult(result);
			}, delegate(PlayFabError error)
			{
				PlayFabPartyNetworking.LogPlayFabError(error);
				findLobbiesCompletion.SetResult(null);
			});
		});
		return await findLobbiesCompletion.Task;
	}

	private async Task<(PlayFab.Multiplayer.Lobby lobby, string networkDescriptor, string error)> JoinAnyLobby(List<LobbySummary> lobbies, GameID gameId, CancellationToken cancellationToken)
	{
		string lastError = null;
		for (int i = 0; i < lobbies.Count; i++)
		{
			var (lobby, text, text2) = await TryJoinLobby(lobbies[i], gameId, cancellationToken);
			if ((lobby != null && text != null) || cancellationToken.IsCancellationRequested)
			{
				return (lobby: lobby, networkDescriptor: text, error: text2);
			}
			if (text2 != null)
			{
				lastError = text2;
			}
		}
		Debug.Log(string.Format("{0}: no lobbies found with given session id {1} among {2} lobbies.", "PlayFabLobbyManager", gameId, lobbies.Count));
		return (lobby: null, networkDescriptor: null, error: lastError ?? "Error/GameNotFound");
	}

	private async Task<(PlayFab.Multiplayer.Lobby lobby, string partyNetworkDescriptor, string error)> TryJoinLobby(LobbySummary lobby, GameID gameId, CancellationToken cancellationToken)
	{
		TaskCompletionSource<PlayFab.Multiplayer.Lobby> lobbyJoinCompletion = new TaskCompletionSource<PlayFab.Multiplayer.Lobby>();
		PlayFabMultiplayer.OnLobbyJoinCompleted += LobbyJoinCompletion;
		PlayFabMultiplayer.JoinLobby(PlayFabSettings.staticPlayer, lobby.ConnectionString, null);
		string networkDescriptor = null;
		bool lobbyIsCrossplay = false;
		string lobbyPlatformName = null;
		string resultCode = "";
		PlayFab.Multiplayer.Lobby lobby2 = await lobbyJoinCompletion.Task;
		PlayFabMultiplayer.OnLobbyJoinCompleted -= LobbyJoinCompletion;
		if (resultCode == "801901AD" || resultCode == "8923640D")
		{
			Debug.Log("PlayFabLobbyManager.LobbyJoinCompletion: Failed to connect with too many requests sent, leaving lobby again.");
			await LeaveLobbyInternal(lobby2);
			return (lobby: null, partyNetworkDescriptor: null, error: "Error/MaxConnectionAttempts");
		}
		if (networkDescriptor == null)
		{
			Debug.Log("PlayFabLobbyManager.LobbyJoinCompletion: Failed to parse network descriptor from lobby data, leaving lobby again.");
			await LeaveLobbyInternal(lobby2);
			return (lobby: null, partyNetworkDescriptor: null, error: "Error/GameNotFound");
		}
		Debug.Log("PlayFabLobbyManager.LobbyJoinCompletion");
		if (!Manager.platform.parentalControlManager.AllowCrossPlay(showUI: false) && (lobbyIsCrossplay || Manager.platform.platformName != lobbyPlatformName))
		{
			await LeaveLobbyInternal(lobby2);
			return (lobby: null, partyNetworkDescriptor: networkDescriptor, error: "Error/CrossplayNotEnabled");
		}
		return (lobby: lobby2, partyNetworkDescriptor: networkDescriptor, error: null);
		void LobbyJoinCompletion(PlayFab.Multiplayer.Lobby lobby3, PFEntityKey newMember, int result)
		{
			if (LobbyError.FAILED(result))
			{
				resultCode = $"{(uint)result:X}";
				lobbyJoinCompletion.SetResult(null);
			}
			else
			{
				ParseLobbyData(lobby3, gameId, out networkDescriptor, out lobbyIsCrossplay, out lobbyPlatformName);
				lobbyJoinCompletion.SetResult(lobby3);
			}
		}
	}

	private void ParseLobbyData(PlayFab.Multiplayer.Lobby lobby, GameID gameId, out string partyDescriptor, out bool crossPlayEnabled, out string lobbyPlatformName)
	{
		IDictionary<string, string> lobbyProperties = lobby.GetLobbyProperties();
		lobby.GetSearchProperties();
		partyDescriptor = null;
		crossPlayEnabled = false;
		lobbyPlatformName = null;
		string value2;
		string value3;
		string value4;
		if (!lobbyProperties.TryGetValue("string_key2", out var value))
		{
			Debug.LogError("PlayFabLobbyManager.ParseLobbyData: lobby doesn't have crossplay data.");
		}
		else if (!bool.TryParse(value, out crossPlayEnabled))
		{
			Debug.LogError("PlayFabLobbyManager.ParseLobbyData: failed to parse crossplay setting from '" + value + "'.");
		}
		else if (!lobbyProperties.TryGetValue("string_key4", out lobbyPlatformName))
		{
			Debug.LogError("PlayFabLobbyManager.ParseLobbyData: lobby doesn't have platform name.");
		}
		else if (!lobbyProperties.TryGetValue("string_key7", out value2))
		{
			Debug.LogError("PlayFabLobbyManager.ParseLobbyData: lobby doesn't have salt.");
		}
		else if (!lobbyProperties.TryGetValue("string_key8", out value3))
		{
			Debug.LogError("PlayFabLobbyManager.ParseLobbyData: lobby doesn't have IV.");
		}
		else if (!lobbyProperties.TryGetValue("string_key6", out value4))
		{
			Debug.LogError("PlayFabLobbyManager.ParseLobbyData: lobby doesn't have party descriptor.");
		}
		else
		{
			gameId.DecryptPartyDescriptor(value4, value2, value3, out partyDescriptor);
		}
	}

	private async Task<(PlayFab.Multiplayer.Lobby lobby, GameID gameId, string error)> CreateLobbyInternal(string networkFullId, uint maxPlayers, CancellationToken cancellationToken)
	{
		GameID gameId = await FindGameIdCheckCollisions(cancellationToken);
		if (cancellationToken.IsCancellationRequested)
		{
			return (lobby: null, gameId: null, error: null);
		}
		if (gameId == null)
		{
			return (lobby: null, gameId: null, error: "Consoles/SessionCreateFailed");
		}
		string publicID = gameId.PublicID;
		string platformName = Manager.platform.platformName;
		bool flag = Manager.platform.parentalControlManager.AllowCrossPlay(showUI: false);
		Debug.Log("PlayFabLobbyManager.CreateLobbyInternal: creating a lobby.");
		if (!gameId.EncryptPartyDescriptor(networkFullId, out var encryptedSecret, out var salt, out var iv))
		{
			Debug.Log("Failed to encrypt party descriptor");
			return (lobby: null, gameId: null, error: "Consoles/SessionCreateFailed");
		}
		LobbyCreateConfiguration createConfiguration = new LobbyCreateConfiguration
		{
			MaxMemberCount = maxPlayers,
			OwnerMigrationPolicy = LobbyOwnerMigrationPolicy.None,
			AccessPolicy = LobbyAccessPolicy.Public,
			LobbyProperties = new Dictionary<string, string>
			{
				{ "string_key4", platformName },
				{
					"string_key2",
					flag.ToString()
				},
				{ "string_key7", salt },
				{ "string_key8", iv },
				{ "string_key6", encryptedSecret }
			},
			SearchProperties = new Dictionary<string, string>
			{
				{ "string_key5", publicID },
				{ "string_key4", platformName },
				{
					"string_key2",
					flag.ToString()
				}
			}
		};
		TaskCompletionSource<int> lobbyCompletion = new TaskCompletionSource<int>();
		PlayFabMultiplayer.OnLobbyCreateAndJoinCompleted += LobbyCompletion;
		PlayFabMultiplayer.CreateAndJoinLobby(PlayFabSettings.staticPlayer, createConfiguration, new LobbyJoinConfiguration());
		PlayFab.Multiplayer.Lobby newLobby = null;
		int num = await lobbyCompletion.Task;
		PlayFabMultiplayer.OnLobbyCreateAndJoinCompleted -= LobbyCompletion;
		if (LobbyError.SUCCEEDED(num))
		{
			Debug.Log("PlayFabLobbyManager.CreateLobbyInternal: Lobby created.");
			return (lobby: newLobby, gameId: gameId, error: null);
		}
		Debug.LogError(string.Format("{0}.{1}: Lobby creation failed with error code {2}.", "PlayFabLobbyManager", "CreateLobbyInternal", num));
		return (lobby: newLobby, gameId: gameId, error: "Consoles/SessionCreateFailed");
		void LobbyCompletion(PlayFab.Multiplayer.Lobby lobby, int result)
		{
			newLobby = lobby;
			lobbyCompletion.SetResult(result);
		}
	}

	private async Task<string> UpdateLobbySearchDataWithCurrentSession(string gameIDFullString, string networkDescriptor, CancellationToken cancellationToken)
	{
		if (currentLobby == null)
		{
			Debug.LogWarning("PlayFabLobbyManager.UpdateLobbySearchDataWithCurrentSession: can't update lobby data since we don't have a current one at the moment.");
			return "Consoles/SessionCreateFailed";
		}
		GameID gameID = new GameID(gameIDFullString);
		string gamePublicId = gameID.PublicID;
		Debug.Log(string.Format("{0}.{1}: updating lobby with following parameters:\nGame id: {2}", "PlayFabLobbyManager", "UpdateLobbySearchDataWithCurrentSession", gameID));
		if (!gameID.EncryptPartyDescriptor(networkDescriptor, out var encryptedPartyDescriptor, out var salt, out var iv))
		{
			Debug.Log("PlayFabLobbyManager.UpdateLobbySearchDataWithCurrentSession: Failed to encrypt party descriptor for current session");
			return "Consoles/SessionCreateFailed";
		}
		TaskCompletionSource<string> updateLobbyCompletion = new TaskCompletionSource<string>();
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			PlayFabMultiplayerAPI.UpdateLobby(new UpdateLobbyRequest
			{
				LobbyId = currentLobby.Id,
				LobbyData = new Dictionary<string, string>
				{
					{ "string_key7", salt },
					{ "string_key8", iv },
					{ "string_key6", encryptedPartyDescriptor }
				},
				SearchData = new Dictionary<string, string> { { "string_key5", gamePublicId } }
			}, delegate
			{
				Debug.Log("PlayFabLobbyManager.UpdateLobbySearchDataWithCurrentSession: PlayFab Lobby updated successfully. New game public id is " + gamePublicId + ".");
				updateLobbyCompletion.SetResult(null);
			}, delegate(PlayFabError error)
			{
				PlayFabPartyNetworking.LogPlayFabError(error);
				updateLobbyCompletion.SetResult("Consoles/SessionCreateFailed");
			});
		});
		return await updateLobbyCompletion.Task;
	}

	private async Task<string> LeaveLobbyInternal(PlayFab.Multiplayer.Lobby lobby)
	{
		if (lobby == null)
		{
			return null;
		}
		if (PlayFabMultiplayerManager.Get() == null)
		{
			Debug.LogError("PlayFabLobbyManager.LeaveLobbyInternal: can't leave lobby since PlayFabMultiplayerManager is null.");
			return "Error/Unknown";
		}
		TaskCompletionSource<string> leaveLobbyCompletion = new TaskCompletionSource<string>();
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			PlayFabMultiplayerAPI.LeaveLobby(new LeaveLobbyRequest
			{
				LobbyId = lobby.Id,
				MemberEntity = ConvertEntityKey(PlayFabSettings.staticPlayer)
			}, delegate
			{
				leaveLobbyCompletion.SetResult(null);
			}, delegate(PlayFabError error)
			{
				PlayFabPartyNetworking.LogPlayFabError(error);
				leaveLobbyCompletion.SetResult("Error/Unknown");
			});
		});
		string obj = await leaveLobbyCompletion.Task;
		if (obj == null)
		{
			Debug.Log("PlayFabLobbyManager.LeaveLobbyInternal: PlayFab Lobby left successfully.");
		}
		return obj;
	}

	private EntityKey ConvertEntityKey(PlayFabAuthenticationContext context)
	{
		if (context == null)
		{
			return null;
		}
		return new EntityKey
		{
			Id = context.EntityId,
			Type = context.EntityType
		};
	}

	private void OnLobbyPostUpdateCompleted(PlayFab.Multiplayer.Lobby lobby, PFEntityKey localuser, int result)
	{
		if (LobbyError.SUCCEEDED(result))
		{
			Debug.Log("PlayFabLobbyManager.OnLobbyPostUpdateCompleted");
		}
		else
		{
			Debug.Log("PlayFabLobbyManager.OnLobbyPostUpdateCompleted: post lobby update failed.");
		}
	}

	private void OnLobbyUpdated(PlayFab.Multiplayer.Lobby lobby, bool ownerUpdated, bool maxMembersUpdated, bool accessPolicyUpdated, bool membershipLockUpdated, IList<string> updatedSearchPropertyKeys, IList<string> updatedLobbyPropertyKeys, IList<LobbyMemberUpdateSummary> memberUpdates)
	{
		Debug.Log("PlayFabLobbyManager.OnLobbyUpdated");
		if (_currentLobby == null)
		{
			Debug.LogError("PlayFabLobbyManager.OnLobbyUpdated: Received lobby update even though we don't have a running platform session.");
			return;
		}
		ParseLobbyData(lobby, _gameID, out var partyDescriptor, out var _, out var _);
		if (partyDescriptor != _networkDescriptor.FullId)
		{
			_networkDescriptor = new PlayFabPartyNetworkDescriptor(partyDescriptor);
			this.NetworkIdChanged?.Invoke(partyDescriptor);
			Debug.Log("PlayFabLobbyManager.OnLobbyUpdated: Received new party network descriptor.");
		}
	}

	private void OnLobbyMemberRemoved(PlayFab.Multiplayer.Lobby lobby, PFEntityKey member, LobbyMemberRemovedReason reason)
	{
		Debug.Log(string.Format("{0}.{1}: reason - {2}", "PlayFabLobbyManager", "OnLobbyMemberRemoved", reason));
	}

	private void OnLobbyMemberAdded(PlayFab.Multiplayer.Lobby lobby, PFEntityKey member)
	{
		Debug.Log("PlayFabLobbyManager.OnLobbyMemberAdded");
	}

	private void OnLobbyDisconnected(PlayFab.Multiplayer.Lobby lobby)
	{
		Debug.Log("PlayFabLobbyManager.OnLobbyDisconnected");
	}
}
