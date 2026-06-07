using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coherence.Cloud;

namespace VampireSurvivors
{
	public interface INetworkProvider
	{
		NetworkProviders Provider { get; }

		NetworkType NetworkType { get; }

		bool UsesRsl { get; }

		bool IsReady { get; }

		string InitializationError { get; }

		int HostConnectedPlayers { get; }

		Action OnJoinError { get; set; }

		Action OnP2PSessionReady { get; set; }

		Action<string> OnP2PSessionError { get; set; }

		void JoinP2P(LobbySession lobbySession);

		bool JoinGame(LobbySession lobbySession);

		void PrepareGame(LobbySession lobbySession, Action<bool, string, Dictionary<string, string>> onGameReady);

		void HostGame();

		Task ShutDown();

		void Update();
	}
}
