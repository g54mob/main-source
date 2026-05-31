using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	[RequireComponent(typeof(PhotonView))]
	public class MoveByKeys : MonoBehaviourPun
	{
		public float Speed;

		public float JumpForce;

		public float JumpTimeout;

		private bool isSprite;

		private float jumpingTime;

		private Rigidbody body;

		private Rigidbody2D body2d;

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}
	}
}
