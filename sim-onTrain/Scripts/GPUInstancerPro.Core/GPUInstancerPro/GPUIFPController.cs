using UnityEngine;

namespace GPUInstancerPro
{
	[RequireComponent(typeof(CharacterController))]
	public class GPUIFPController : GPUIInputHandler
	{
		[SerializeField]
		public float m_WalkSpeed;

		[SerializeField]
		public float m_RunSpeed;

		[SerializeField]
		public float m_JumpSpeed;

		private bool m_IsWalking;

		private MouseLook m_MouseLook;

		private Camera m_Camera;

		private bool m_Jump;

		private float m_YRotation;

		private Vector2 m_Input;

		private Vector3 m_MoveDir = Vector3.zero;

		private CharacterController m_CharacterController;

		private CollisionFlags m_CollisionFlags;

		private bool m_PreviouslyGrounded;

		private bool m_Jumping;

		private float m_StickToGroundForce = 10f;

		private float m_GravityMultiplier = 2f;

		protected override void Start()
		{
			base.Start();
			m_CharacterController = GetComponent<CharacterController>();
			m_Camera = Camera.main;
			m_Jumping = false;
			m_MouseLook = new MouseLook();
			m_MouseLook.Init(base.transform, m_Camera.transform);
		}

		private void Update()
		{
			RotateView();
			if (!m_Jump && Cursor.lockState == CursorLockMode.Locked)
			{
				m_Jump = GetKey(KeyCode.Space);
			}
			if (!m_PreviouslyGrounded && m_CharacterController.isGrounded)
			{
				m_MoveDir.y = 0f;
				m_Jumping = false;
			}
			if (!m_CharacterController.isGrounded && !m_Jumping && m_PreviouslyGrounded)
			{
				m_MoveDir.y = 0f;
			}
			m_PreviouslyGrounded = m_CharacterController.isGrounded;
		}

		private void FixedUpdate()
		{
			GetInput(out var speed);
			Vector3 vector = base.transform.forward * m_Input.y + base.transform.right * m_Input.x;
			Physics.SphereCast(base.transform.position, m_CharacterController.radius, Vector3.down, out var hitInfo, m_CharacterController.height / 2f, -1, QueryTriggerInteraction.Ignore);
			vector = Vector3.ProjectOnPlane(vector, hitInfo.normal).normalized;
			m_MoveDir.x = vector.x * speed;
			m_MoveDir.z = vector.z * speed;
			if (m_CharacterController.isGrounded)
			{
				m_MoveDir.y = 0f - m_StickToGroundForce;
				if (m_Jump)
				{
					m_MoveDir.y = m_JumpSpeed;
					m_Jump = false;
					m_Jumping = true;
				}
			}
			else
			{
				m_MoveDir += Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime;
			}
			m_CollisionFlags = m_CharacterController.Move(m_MoveDir * Time.fixedDeltaTime);
			m_MouseLook.UpdateCursorLock(this);
		}

		private void GetInput(out float speed)
		{
			float axis = GetAxis("Horizontal");
			float axis2 = GetAxis("Vertical");
			m_IsWalking = !GetKey(KeyCode.LeftShift);
			speed = (m_IsWalking ? m_WalkSpeed : m_RunSpeed);
			m_Input = new Vector2(axis, axis2);
			if (m_Input.sqrMagnitude > 1f)
			{
				m_Input.Normalize();
			}
		}

		private void RotateView()
		{
			m_MouseLook.LookRotation(this, base.transform, m_Camera.transform);
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			Rigidbody attachedRigidbody = hit.collider.attachedRigidbody;
			if (m_CollisionFlags != CollisionFlags.Below && !(attachedRigidbody == null) && !attachedRigidbody.isKinematic)
			{
				attachedRigidbody.AddForceAtPosition(m_CharacterController.velocity * 0.1f, hit.point, ForceMode.Impulse);
			}
		}
	}
}
