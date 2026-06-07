using UnityEngine;

namespace Photon.Pun
{
	[RequireComponent(typeof(Rigidbody))]
	[AddComponentMenu("Photon Networking/Photon Rigidbody View")]
	public class PhotonRigidbodyView : MonoBehaviourPun, IPunObservable
	{
		private float m_Distance;

		private float m_Angle;

		private Rigidbody m_Body;

		private Vector3 m_NetworkPosition;

		private Quaternion m_NetworkRotation;

		[HideInInspector]
		public bool m_SynchronizeVelocity;

		[HideInInspector]
		public bool m_SynchronizeAngularVelocity;

		[HideInInspector]
		public bool m_TeleportEnabled;

		[HideInInspector]
		public float m_TeleportIfDistanceGreaterThan;

		public void Awake()
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}
	}
}
