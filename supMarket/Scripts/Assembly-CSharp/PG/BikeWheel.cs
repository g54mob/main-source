using Photon.Pun;
using UnityEngine;

namespace PG
{
	public class BikeWheel : Wheel
	{
		private Vector3 StartLocalPos;

		[SerializeField]
		private Transform m_FrontWheel;

		private PhotonView m_PhotonView;

		public PhotonView PhotonView => null;

		private void Start()
		{
		}

		public override void LateUpdate()
		{
		}
	}
}
