using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkSecurityGuard : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
	{
		private GameObject m_BaseballBat;

		[SerializeField]
		private Crate m_Crate;

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}

		public void ToggleBaseballBat_Broadcast(bool isEnable)
		{
		}

		[PunRPC]
		public void ToggleBaseballBat_RPC(bool isEnable)
		{
		}

		public void ToggleSecurityCrate_Broadcast(bool isOpen)
		{
		}

		[PunRPC]
		public void ToggleSecurityCrate_RPC(bool isOpen)
		{
		}

		public void AddProductToDisplayGuard_Broadcast(Product currentProduct, int displayViewId, int getIndexFromDisplay)
		{
		}

		[PunRPC]
		public void AddProductToDisplayGuard_RPC(int productID, Vector3 position, Quaternion rotation, int displayViewId, int displaySlotIndex)
		{
		}
	}
}
