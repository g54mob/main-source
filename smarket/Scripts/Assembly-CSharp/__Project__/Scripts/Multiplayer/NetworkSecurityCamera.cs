using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkSecurityCamera : MonoBehaviourPunCallbacks, IPunObservable
	{
		private SecurityCamera m_SecurityCamera;

		private Transform m_CameraHolder;

		public SecurityCamera SecurityCamera => null;

		public Transform CameraHolder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void SyncCameraState_Broadcast()
		{
		}

		private void SyncCameraState_Broadcast(string newPlayerUserID)
		{
		}

		[PunRPC]
		public void SyncCameraState_RPC(bool isEnable, bool isOccupied, bool isAtCeiling, Vector3 targetRot, float[] matrixList, int id, Quaternion quaternion)
		{
		}

		public void InteractSecurityCamera_Broadcast(bool willOpen)
		{
		}

		[PunRPC]
		public void InteractSecurityCamera_RPC(bool willOpen, Player player, bool isAtCeiling, float[] matrixList)
		{
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}

		public void SwitchPlacementArea_Broadcast(bool isCeiling)
		{
		}

		[PunRPC]
		public void SwitchPlacementArea_RPC(bool isAtCeiling)
		{
		}
	}
}
