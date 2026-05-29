using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.FloorPaintSystem;

namespace __Project__.Scripts.Multiplayer.Customization
{
	public class NetworkFloorBox : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
	{
		public bool IsNetworkOccupied;

		private FloorBox m_FloorBox;

		private FloorBoxData m_BoxData;

		private Rigidbody m_Rigidbody;

		public FloorBox FloorBox => null;

		public Rigidbody Rigidbody => null;

		private void Start()
		{
		}

		public override void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnSyncRequest(string userId)
		{
		}

		private void SyncFloorBox_Broadcast(string userId)
		{
		}

		[PunRPC]
		public void SyncFloorBoxData_RPC(object[] boxData)
		{
		}

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}

		public void PickUp_Broadcast(PlayerInstance player)
		{
		}

		[PunRPC]
		public void PickUpFloorBox_RPC(string userId)
		{
		}

		public void AskAvailability()
		{
		}

		[PunRPC]
		public bool AskFloorBoxAvailability_RPC(string userId)
		{
			return false;
		}

		[PunRPC]
		public void AvailabilityRejected_Response()
		{
		}

		public void OpenBox_Broadcast()
		{
		}

		[PunRPC]
		public void OpenFloorBox_RPC()
		{
		}

		public void CloseBox_Broadcast()
		{
		}

		[PunRPC]
		public void CloseFloorBox_RPC()
		{
		}
	}
}
