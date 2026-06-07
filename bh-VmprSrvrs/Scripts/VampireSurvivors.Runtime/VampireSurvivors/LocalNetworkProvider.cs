using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Log;

namespace VampireSurvivors
{
	public class LocalNetworkProvider : INetworkProvider
	{
		private Logger _logger;

		private RoomData? _roomData;

		private ReplicationServerRoomsService _roomsService;

		public NetworkProviders Provider => default(NetworkProviders);

		public NetworkType NetworkType => default(NetworkType);

		public bool UsesRsl => false;

		public bool IsReady => false;

		public string InitializationError => null;

		public Action OnJoinError { get; set; }

		public Action OnP2PSessionReady { get; set; }

		public Action<string> OnP2PSessionError { get; set; }

		public int HostConnectedPlayers => 0;

		public LocalNetworkProvider(Logger logger)
		{
		}

		public void JoinP2P(LobbySession lobbySession)
		{
		}

		public bool JoinGame(LobbySession lobbySession)
		{
			return false;
		}

		public void PrepareGame(LobbySession lobbySession, Action<bool, string, Dictionary<string, string>> onGameReady)
		{
		}

		public void HostGame()
		{
		}

		public void Update()
		{
		}

		private static void JoinRoom(RoomData room)
		{
		}

		private void OnCreatedRoom(RequestResponse<RoomData> request, Action<bool, string, Dictionary<string, string>> onGameReady)
		{
		}

		public Task ShutDown()
		{
			return null;
		}
	}
}
