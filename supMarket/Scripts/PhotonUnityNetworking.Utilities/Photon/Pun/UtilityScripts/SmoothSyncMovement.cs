using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	[RequireComponent(typeof(PhotonView))]
	public class SmoothSyncMovement : MonoBehaviourPun, IPunObservable
	{
		public float SmoothingDelay;

		private Vector3 correctPlayerPos;

		private Quaternion correctPlayerRot;

		public void Awake()
		{
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}

		public void Update()
		{
		}
	}
}
