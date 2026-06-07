using Photon.Pun;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkFurnitureInteraction : NetworkInteraction
	{
		private FurnitureInteraction m_FurnitureInteraction;

		protected override void Initialize()
		{
		}

		public void PlaceFurniture_Broadcast()
		{
		}

		[PunRPC]
		public void PlaceFurniture_RPC()
		{
		}

		public void SyncFurnitureState_Broadcast(string newPlayerUserId)
		{
		}

		[PunRPC]
		public void SyncFurnitureState_RPC(string newPlayerUserId, string senderUserId, int displayViewId)
		{
		}

		public void BoxUpFurniture_Broadcast()
		{
		}

		public void BoxUpFurnitureRequest()
		{
		}

		[PunRPC]
		public void BoxUpFurnitureRequest_RPC()
		{
		}
	}
}
