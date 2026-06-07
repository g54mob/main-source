using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Log;

namespace VampireSurvivors
{
	public class CloudNetworkProvider : INetworkProvider
	{
		private IRoomsService _roomsService;

		private Logger _logger;

		private RoomData? _roomData;

		public NetworkProviders Provider => default(NetworkProviders);

		public NetworkType NetworkType => default(NetworkType);

		public bool UsesRsl => false;

		public bool IsReady { get; private set; }

		public string InitializationError { get; private set; }

		public Action OnJoinError { get; set; }

		public Action OnP2PSessionReady { get; set; }

		public Action<string> OnP2PSessionError { get; set; }

		public int HostConnectedPlayers => 0;

		public CloudNetworkProvider(Logger logger)
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

		private void OnCreatedRoom(RequestResponse<RoomData> request, Action<bool, string, Dictionary<string, string>> onGameReady)
		{
		}

		private static void JoinRoom(RoomData room)
		{
		}

		public Task ShutDown()
		{
			return null;
		}
	}
}
