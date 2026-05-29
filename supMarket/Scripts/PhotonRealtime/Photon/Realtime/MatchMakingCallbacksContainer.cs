using System.Collections.Generic;

namespace Photon.Realtime
{
	public class MatchMakingCallbacksContainer : List<IMatchmakingCallbacks>, IMatchmakingCallbacks
	{
		private readonly LoadBalancingClient client;

		public MatchMakingCallbacksContainer(LoadBalancingClient client)
		{
		}

		public void OnCreatedRoom()
		{
		}

		public void OnJoinedRoom()
		{
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public void OnLeftRoom()
		{
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}
	}
}
