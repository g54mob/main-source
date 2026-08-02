using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;

namespace EAST_UP
{
	public class EASTUP_PlayerController : MonoBehaviour
	{
		[SerializeField]
		private Transform groundCheck;

		[SerializeField]
		public CapsuleCollider characterCollider;

		[SerializeField]
		public Transform characterModel;

		[SerializeField]
		public InputReader animationStates;

		public float walkSpeed = 5f;

		public float sprintSpeed = 9f;

		public float jumpForce = 8f;

		public float turnSmoothTime = 0.2f;

		public float speedSmoothTime = 0.15f;

		public float airControlMultiplier = 0.8f;

		public float airSpeedMultiplier = 0.7f;

		public float normalHeight = 2f;

		public float crouchHeight = 1f;

		public float proneHeight = 0.5f;

		public float crouchSpeed = 3f;

		public float proneSpeed = 1.5f;

		[SerializeField]
		private float groundRadius = 0.3f;

		[SerializeField]
		private LayerMask groundMask;

		[Range(0f, 90f)]
		[SerializeField]
		public float maxSlopeAngle = 45f;

		[SerializeField]
		private float maxStepHeight = 0.4f;

		[SerializeField]
		private float stepCheckDistance = 0.2f;

		[SerializeField]
		private LayerMask stairMask;

		public bool isGrounded;

		public float currentSpeed;

		public Vector3 moveDirection;

		public bool isInStanceTransition;

		public Vector3 groundNormal;

		public bool isOnStairs;

		[HideInInspector]
		public Rigidbody rb;

		[HideInInspector]
		public Transform cameraTransform;

		[HideInInspector]
		public Vector2 moveInput;

		[HideInInspector]
		public float turnSmoothVelocity;

		[HideInInspector]
		public float speedSmoothVelocity;

		[HideInInspector]
		public EASTUP_PlayerStateMachine stateMachine;

		public Vector3 center;

		public float height;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
			stateMachine = GetComponent<EASTUP_PlayerStateMachine>();
			characterCollider = GetComponent<CapsuleCollider>();
			cameraTransform = Camera.main.transform;
			center = characterCollider.center;
			height = characterCollider.height;
			if (!rb || !stateMachine || !characterCollider || !characterModel)
			{
				Debug.LogError("Gerekli componentler eksik!");
				return;
			}
			rb.constraints = RigidbodyConstraints.FreezeRotation;
			if (groundCheck == null)
			{
				Debug.LogError("Ground Check objesi atanmamış!");
			}
			characterCollider.height = normalHeight;
			characterCollider.center = new Vector3(0f, normalHeight / 2f, 0f);
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void Start()
		{
			stateMachine.Initialize(new PlayerIdleState(stateMachine, this, PlayerStateType.Idle, animationStates));
		}

		public void CheckGround()
		{
			isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
			if (isGrounded && Physics.Raycast(base.transform.position + Vector3.up * 0.1f, Vector3.down, out var hitInfo, 0.3f, groundMask))
			{
				groundNormal = hitInfo.normal;
				if (Vector3.Angle(groundNormal, Vector3.up) > maxSlopeAngle)
				{
					isGrounded = false;
					Vector3 normalized = Vector3.ProjectOnPlane(Vector3.down, groundNormal).normalized;
					rb.velocity += normalized * 20f * Time.deltaTime;
				}
			}
		}

		public void CheckStairs()
		{
			Vector3 position = base.transform.position;
			Vector3 vector;
			if (moveInput.magnitude > 0.1f)
			{
				float y = Mathf.Atan2(moveInput.x, moveInput.y) * 57.29578f + cameraTransform.eulerAngles.y;
				vector = Quaternion.Euler(0f, y, 0f) * Vector3.forward;
			}
			else
			{
				vector = base.transform.forward;
			}
			Vector3 vector2 = position + Vector3.up * 0.05f;
			float[] array = new float[3] { -10f, 0f, 10f };
			float[] array2 = array;
			foreach (float y2 in array2)
			{
				Vector3 vector3 = Quaternion.Euler(0f, y2, 0f) * vector;
				Debug.DrawRay(vector2, vector3 * stepCheckDistance, Color.blue, 0.01f);
				Debug.DrawRay(vector2 + Vector3.up * maxStepHeight + vector3 * stepCheckDistance, Vector3.down * maxStepHeight, Color.green, 0.01f);
			}
			if (stateMachine.CurrentStateType != PlayerStateType.Moving)
			{
				isOnStairs = false;
				return;
			}
			float num = maxStepHeight;
			Vector3 vector4 = Vector3.zero;
			bool flag = false;
			array2 = array;
			foreach (float y3 in array2)
			{
				Vector3 direction = Quaternion.Euler(0f, y3, 0f) * vector;
				if (Physics.Raycast(vector2, direction, out var hitInfo, stepCheckDistance, stairMask))
				{
					float num2 = hitInfo.point.y - position.y;
					if (num2 > 0.01f && num2 <= maxStepHeight && num2 < num)
					{
						num = num2;
						vector4 = hitInfo.point;
						flag = true;
					}
				}
			}
			if (flag)
			{
				Debug.DrawLine(vector4, vector4 + Vector3.up * 0.5f, Color.white, 0.1f);
				Vector3 b = new Vector3(rb.position.x, vector4.y + 0.02f, rb.position.z);
				Vector3 velocity = rb.velocity;
				float y4 = Mathf.Lerp(1.5f, 3f, num / maxStepHeight);
				Vector3 b2 = new Vector3(velocity.x * 0.95f, y4, velocity.z * 0.95f);
				rb.velocity = Vector3.Lerp(rb.velocity, b2, Time.fixedDeltaTime * 8f);
				rb.MovePosition(Vector3.Lerp(rb.position, b, Time.fixedDeltaTime * 10f));
				isOnStairs = true;
			}
			else
			{
				isOnStairs = false;
			}
		}

		public Vector3 CalculateMoveDirection()
		{
			if (moveInput.magnitude > 0.1f)
			{
				float num = Mathf.Atan2(moveInput.x, moveInput.y) * 57.29578f + cameraTransform.eulerAngles.y;
				Mathf.SmoothDampAngle(base.transform.eulerAngles.y, num, ref turnSmoothVelocity, turnSmoothTime);
				Vector3 vector = Quaternion.Euler(0f, num, 0f) * Vector3.forward;
				if (isGrounded)
				{
					vector = Vector3.ProjectOnPlane(vector, groundNormal).normalized;
				}
				return vector;
			}
			return base.transform.forward;
		}

		public bool CanStandUp()
		{
			Vector3 position = base.transform.position;
			Vector3 end = position + Vector3.up * normalHeight;
			return !Physics.CheckCapsule(position, end, characterCollider.radius, ~LayerMask.GetMask("Player"));
		}

		private void OnDrawGizmos()
		{
			if (groundCheck != null)
			{
				Gizmos.color = (isGrounded ? Color.green : Color.red);
				Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
			}
		}
	}
}
