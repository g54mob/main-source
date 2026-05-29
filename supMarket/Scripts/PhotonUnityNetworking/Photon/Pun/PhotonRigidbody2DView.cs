using UnityEngine;

namespace Photon.Pun
{
	[RequireComponent(typeof(Rigidbody2D))]
	[AddComponentMenu("Photon Networking/Photon Rigidbody 2D View")]
	public class PhotonRigidbody2DView : MonoBehaviourPun, IPunObservable
	{
		private float m_Distance;

		private float m_Angle;

		private Rigidbody2D m_Body;

		private Vector2 m_NetworkPosition;

		private float m_NetworkRotation;

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
