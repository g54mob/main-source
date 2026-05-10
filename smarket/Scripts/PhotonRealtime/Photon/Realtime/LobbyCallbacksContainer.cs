using System.Collections.Generic;

namespace Photon.Realtime
{
	internal class LobbyCallbacksContainer : List<ILobbyCallbacks>, ILobbyCallbacks
	{
		private readonly LoadBalancingClient client;

		public LobbyCallbacksContainer(LoadBalancingClient client)
		{
		}

		public void OnJoinedLobby()
		{
		}

		public void OnLeftLobby()
		{
		}

		public void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
		{
		}
	}
}
