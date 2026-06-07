using UnityEngine;

namespace MalbersAnimations.SA
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[AddComponentMenu("Malbers/Utilities/Standard Asset/Rigidbody FPS Controller")]
	public class MRigidbodyFPSController : MonoBehaviour, IObjectCore
	{
		public Camera cam;

		public bool LockCursor;

		[SerializeField]
		public bool lockMovement;

		public MMovementSettings movementSettings = new MMovementSettings();

		public MMouseLook mouseLook = new MMouseLook();

		public MAdvancedSettings advancedSettings = new MAdvancedSettings();

		private Rigidbody m_RigidBody;

		private CapsuleCollider m_Capsule;

		private Vector3 m_GroundContactNormal;

		private bool m_Jump;

		private bool m_PreviouslyGrounded;

		private bool m_Jumping;

		private bool m_IsGrounded;

		private float oldYRotation;

		public bool LockMovement
		{
			get
			{
				return lockMovement;
			}
			set
			{
				lockMovement = value;
			}
		}

		public Vector3 Velocity => m_RigidBody.velocity;

		public bool Grounded => m_IsGrounded;

		public bool Jumping => m_Jumping;

		public bool Running => movementSettings.Running;

		Transform IObjectCore.transform => base.transform;

		private void Start()
		{
			m_RigidBody = GetComponent<Rigidbody>();
			m_Capsule = GetComponent<CapsuleCollider>();
			Cursor.lockState = (LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
			Cursor.visible = !LockCursor;
			RestartMouseLook();
		}

		private void Update()
		{
			RotateView();
			if (Input.GetButtonDown("Jump") && !m_Jump)
			{
				m_Jump = true;
			}
		}

		public void RestartMouseLook()
		{
			mouseLook.Init(base.transform, cam.transform);
		}

		private void FixedUpdate()
		{
			if (lockMovement)
			{
				return;
			}
			GroundCheck();
			Vector2 input = GetInput();
			if ((Mathf.Abs(input.x) > float.Epsilon || Mathf.Abs(input.y) > float.Epsilon) && (advancedSettings.airControl || m_IsGrounded))
			{
				Vector3 vector = cam.transform.forward * input.y + cam.transform.right * input.x;
				vector = Vector3.ProjectOnPlane(vector, m_GroundContactNormal).normalized;
				vector.x *= movementSettings.CurrentTargetSpeed;
				vector.z *= movementSettings.CurrentTargetSpeed;
				vector.y *= movementSettings.CurrentTargetSpeed;
				if (m_RigidBody.velocity.sqrMagnitude < movementSettings.CurrentTargetSpeed * movementSettings.CurrentTargetSpeed)
				{
					m_RigidBody.AddForce(vector * SlopeMultiplier(), ForceMode.Impulse);
				}
			}
			if (m_IsGrounded)
			{
				m_RigidBody.drag = 5f;
				if (m_Jump)
				{
					m_RigidBody.drag = 0f;
					m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, m_RigidBody.velocity.z);
					m_RigidBody.AddForce(new Vector3(0f, movementSettings.JumpForce, 0f), ForceMode.Impulse);
					m_Jumping = true;
				}
				if (!m_Jumping && Mathf.Abs(input.x) < float.Epsilon && Mathf.Abs(input.y) < float.Epsilon && m_RigidBody.velocity.magnitude < 1f)
				{
					m_RigidBody.Sleep();
				}
			}
			else
			{
				m_RigidBody.drag = 0f;
				if (m_PreviouslyGrounded && !m_Jumping)
				{
					StickToGroundHelper();
				}
			}
			m_Jump = false;
		}

		private float SlopeMultiplier()
		{
			float time = Vector3.Angle(m_GroundContactNormal, Vector3.up);
			return movementSettings.SlopeCurveModifier.Evaluate(time);
		}

		private void StickToGroundHelper()
		{
			if (Physics.SphereCast(base.transform.position, m_Capsule.radius, Vector3.down, out var hitInfo, m_Capsule.height / 2f - m_Capsule.radius + advancedSettings.stickToGroundHelperDistance) && Mathf.Abs(Vector3.Angle(hitInfo.normal, Vector3.up)) < 85f && !m_RigidBody.isKinematic)
			{
				m_RigidBody.velocity = Vector3.ProjectOnPlane(m_RigidBody.velocity, hitInfo.normal);
			}
		}

		private Vector2 GetInput()
		{
			Vector2 vector = new Vector2
			{
				x = Input.GetAxis("Horizontal"),
				y = Input.GetAxis("Vertical")
			};
			movementSettings.UpdateDesiredTargetSpeed(vector);
			return vector;
		}

		public virtual void RotateView()
		{
			if (Mathf.Abs(Time.timeScale) < float.Epsilon)
			{
				return;
			}
			mouseLook.Init(base.transform, cam.transform);
			oldYRotation = base.transform.eulerAngles.y;
			mouseLook.LookRotation(base.transform, cam.transform);
			if (m_IsGrounded || advancedSettings.airControl)
			{
				Quaternion quaternion = Quaternion.AngleAxis(base.transform.eulerAngles.y - oldYRotation, Vector3.up);
				if (!m_RigidBody.isKinematic)
				{
					m_RigidBody.velocity = quaternion * m_RigidBody.velocity;
				}
			}
		}

		private void GroundCheck()
		{
			m_PreviouslyGrounded = m_IsGrounded;
			if (Physics.SphereCast(base.transform.position, m_Capsule.radius, Vector3.down, out var hitInfo, m_Capsule.height / 2f - m_Capsule.radius + advancedSettings.groundCheckDistance))
			{
				m_IsGrounded = true;
				m_GroundContactNormal = hitInfo.normal;
			}
			else
			{
				m_IsGrounded = false;
				m_GroundContactNormal = Vector3.up;
			}
			if (!m_PreviouslyGrounded && m_IsGrounded && m_Jumping)
			{
				m_Jumping = false;
			}
		}
	}
}
