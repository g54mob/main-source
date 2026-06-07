using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	internal class InRoomCallbacksContainer : List<IInRoomCallbacks>, IInRoomCallbacks
	{
		private readonly LoadBalancingClient client;

		public InRoomCallbacksContainer(LoadBalancingClient client)
		{
		}

		public void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		public void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}

		public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProp)
		{
		}

		public void OnMasterClientSwitched(Player newMasterClient)
		{
		}
	}
}
