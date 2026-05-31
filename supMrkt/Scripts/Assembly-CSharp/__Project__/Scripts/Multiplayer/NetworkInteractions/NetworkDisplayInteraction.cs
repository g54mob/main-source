using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkDisplayInteraction : NetworkInteraction
	{
		private DisplayInteraction m_DisplayInteraction;

		protected override void Initialize()
		{
		}

		public void PlaceDisplay_Broadcast()
		{
		}

		[PunRPC]
		public void PlaceDisplay_RPC(Vector3 pos, Vector3 rot)
		{
		}

		public void SyncDisplayState_Broadcast(string newPlayerUserId)
		{
		}

		[PunRPC]
		public void SyncDisplayState_RPC(string newPlayerUserId, string senderUserId, int displayViewId)
		{
		}

		public void BoxUpDisplay_Broadcast()
		{
		}

		public void BoxUpDisplayRequest()
		{
		}

		[PunRPC]
		public void BoxUpDisplayRequest_RPC()
		{
		}
	}
}
