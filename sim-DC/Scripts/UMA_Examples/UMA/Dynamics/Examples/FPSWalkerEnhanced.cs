using UnityEngine;

namespace UMA.Dynamics.Examples
{
	[RequireComponent(typeof(CharacterController))]
	public class FPSWalkerEnhanced : MonoBehaviour
	{
		public float walkSpeed;

		public float runSpeed;

		public bool limitDiagonalSpeed;

		public bool toggleRun;

		public float jumpSpeed;

		public float gravity;

		public float fallingDamageThreshold;

		public bool slideWhenOverSlopeLimit;

		public bool slideOnTaggedObjects;

		public float slideSpeed;

		public bool airControl;

		public float antiBumpFactor;

		public int antiBunnyHopFactor;

		private Vector3 moveDirection;

		private bool grounded;

		private CharacterController controller;

		private Transform myTransform;

		private float speed;

		private RaycastHit hit;

		private float fallStartLevel;

		private bool falling;

		private float slideLimit;

		private float rayDistance;

		private Vector3 contactPoint;

		private bool playerControl;

		private int jumpTimer;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
		}

		private void FallingDamageAlert(float fallDistance)
		{
		}
	}
}
