using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkRackInteraction : NetworkInteraction
	{
		private RackInteraction m_RackInteraction;

		protected override void Initialize()
		{
		}

		public void PlaceRack_Broadcast()
		{
		}

		[PunRPC]
		public void PlaceRack_RPC(Vector3 playSoundPosition)
		{
		}

		public void SyncRackState_Broadcast(string newPlayerUserId)
		{
		}

		[PunRPC]
		public void SyncRackState_RPC(string newPlayerUserId, string senderUserId, int rackViewId)
		{
		}

		public void BoxUpRack_Broadcast()
		{
		}

		public void BoxUpRackRequest()
		{
		}

		[PunRPC]
		public void BoxUpRackRequest_RPC()
		{
		}
	}
}
