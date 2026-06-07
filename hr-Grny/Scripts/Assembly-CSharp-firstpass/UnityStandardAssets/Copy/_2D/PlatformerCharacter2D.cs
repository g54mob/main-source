using UnityEngine;

namespace UnityStandardAssets.Copy._2D
{
	public class PlatformerCharacter2D : MonoBehaviour
	{
		[SerializeField]
		private float m_MaxSpeed;

		[SerializeField]
		private float m_JumpForce;

		[SerializeField]
		private bool m_AirControl;

		[SerializeField]
		private LayerMask m_WhatIsGround;

		private Transform m_GroundCheck;

		private const float k_GroundedRadius = 0.2f;

		private bool m_Grounded;

		private Animator m_Anim;

		private Rigidbody2D m_Rigidbody2D;

		private bool m_FacingRight;

		private void Awake()
		{
		}

		private void FixedUpdate()
		{
		}

		public void Move(float move, bool jump)
		{
		}

		private void Flip()
		{
		}
	}
}
