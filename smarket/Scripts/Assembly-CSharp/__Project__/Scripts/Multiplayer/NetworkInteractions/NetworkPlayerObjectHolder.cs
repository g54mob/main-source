using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkPlayerObjectHolder : NetworkInteraction
	{
		[SerializeField]
		private Transform m_ObjectHolder;

		private PlayerObjectHolder m_PlayerObjectHolder;

		protected override void Initialize()
		{
		}

		public void PlacingMode_Broadcast()
		{
		}

		[PunRPC]
		public void PlacingMode_RPC(string userID)
		{
		}

		public void UpdateObjectParent_Broadcast(bool isNull)
		{
		}

		[PunRPC]
		public void UpdateObjectParent_RPC(bool isNull)
		{
		}
	}
}
