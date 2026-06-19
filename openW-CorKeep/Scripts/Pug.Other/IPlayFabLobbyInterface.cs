using System;
using System.Threading;
using System.Threading.Tasks;

public interface IPlayFabLobbyInterface
{
	bool SupportsCrossPlatformSessions { get; }

	string LobbyId { get; }

	string NetworkId { get; }

	string JoinString { get; }

	event Action<string> NetworkIdChanged;

	Task<string> CreateLobby(string networkId, uint maxPlayers, CancellationToken cancellationToken);

	Task<string> LeaveLobby();

	Task<string> JoinLobby(string joinString, CancellationToken cancellationToken);

	void UpdateLobbyDataInternal(string lobbyId, string networkFullId);

	Task<string> UpdateLobbyData(string lobbyId, string networkFullId, CancellationToken cancellationToken);
}
