using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PlayFabLobbyByPass : IPlayFabLobbyInterface
{
	private PlayFabPartyNetworkDescriptor _networkDescriptor;

	public bool SupportsCrossPlatformSessions => false;

	public string LobbyId => _networkDescriptor?.Guid;

	public string NetworkId => _networkDescriptor?.FullId;

	public string JoinString => _networkDescriptor?.FullId;

	public event Action<string> NetworkIdChanged;

	public Task<string> CreateLobby(string networkId, uint maxPlayers, CancellationToken cancellationToken)
	{
		if (LobbyId != null)
		{
			Debug.LogError("PlayFabLobbyByPass.CreateLobby: Already connected to a lobby, aborting.");
			return Task.FromResult<string>(null);
		}
		_networkDescriptor = new PlayFabPartyNetworkDescriptor(networkId);
		if (_networkDescriptor.Suffix == null)
		{
			return Task.FromResult("Error/GameNotFound");
		}
		return Task.FromResult<string>(null);
	}

	public Task<string> JoinLobby(string joinString, CancellationToken cancellationToken)
	{
		if (LobbyId != null)
		{
			Debug.LogWarning("PlayFabLobbyByPass.JoinLobby: Already connected to a lobby. Aborting.");
			return Task.FromResult<string>(null);
		}
		_networkDescriptor = new PlayFabPartyNetworkDescriptor(joinString);
		if (_networkDescriptor.Suffix == null)
		{
			return Task.FromResult("Error/GameNotFound");
		}
		return Task.FromResult<string>(null);
	}

	public Task<string> LeaveLobby()
	{
		_networkDescriptor = null;
		return Task.FromResult<string>(null);
	}

	public void UpdateLobbyDataInternal(string lobbyId, string networkFullId)
	{
	}

	public Task<string> UpdateLobbyData(string lobbyId, string networkFullId, CancellationToken cancellationToken)
	{
		if (networkFullId != _networkDescriptor?.FullId)
		{
			_networkDescriptor = new PlayFabPartyNetworkDescriptor(networkFullId);
		}
		return Task.FromResult<string>(null);
	}
}
