using UnityEngine;

namespace StarterAssets
{
	public class FirstPersonController : MonoBehaviour
	{
		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		public float MoveSpeed = 4f;

		[Tooltip("Sprint speed of the character in m/s")]
		public float SprintSpeed = 6f;

		[Tooltip("Rotation speed of the character")]
		public float RotationSpeed = 1f;

		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate = 10f;

		[Space(10f)]
		[Tooltip("The height the player can jump")]
		public float JumpHeight = 1.2f;

		[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
		public float Gravity = -15f;

		[Space(10f)]
		[Header("Crouch - Source Style")]
		[Tooltip("Height of the CharacterController while crouching")]
		public float CrouchHeight = 1f;

		[Tooltip("Height of the CharacterController while standing")]
		public float StandHeight = 2f;

		[Tooltip("How fast the camera lerps between stand and crouch positions")]
		public float CrouchTransitionSpeed = 12f;

		[Tooltip("Speed multiplier applied while crouching (0–1)")]
		[Range(0f, 1f)]
		public float CrouchSpeedMultiplier = 0.65f;

		[Tooltip("Extra jump height added when jumping from a crouch")]
		public float CrouchJumpBonus = 0.6f;

		[Header("CharacterController Offset")]
		[Tooltip("Додатковий офсет центру CharacterController (по Y)")]
		public float ControllerCenterYOffset;

		[Space(5f)]
		[Tooltip("Radius used to check for ceiling obstruction when trying to stand up")]
		public float CeilingCheckRadius = 0.3f;

		[Tooltip("Extra upward offset for ceiling check sphere from the top of StandHeight")]
		public float CeilingCheckOffset = 0.1f;

		private bool _isCrouching;

		private bool _wantsToCrouch;

		[Space(10f)]
		[Header("Momentum Buffer")]
		[Tooltip("Time window (seconds) to remember recent ground speed after the player stops moving, applied on jump")]
		public float MomentumBufferTime = 0.15f;

		[Header("Air Control")]
		[Tooltip("Maximum horizontal speed gained purely from air control (when jumping from standstill)")]
		public float AirControlMaxSpeed = 2.5f;

		[Tooltip("Horizontal acceleration rate in air when speed is below AirControlMaxSpeed")]
		public float AirControlAcceleration = 4f;

		[Space(10f)]
		[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
		public float JumpTimeout = 0.1f;

		[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
		public float FallTimeout = 0.15f;

		[Header("Player Grounded")]
		[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
		public bool Grounded = true;

		[Tooltip("Useful for rough ground")]
		public float GroundedOffset = -0.14f;

		[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
		public float GroundedRadius = 0.5f;

		[Tooltip("What layers the character uses as ground")]
		public LayerMask GroundLayers;

		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;

		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 90f;

		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -90f;

		private float _cinemachineTargetPitch;

		private float _speed;

		private float _rotationVelocity;

		private float _verticalVelocity;

		private float _terminalVelocity = 53f;

		private float _jumpTimeoutDelta;

		private float _fallTimeoutDelta;

		private CharacterController _controller;

		private StarterAssetsInputs _input;

		private GameObject _mainCamera;

		private bool _canSprint = true;

		private bool _canRotateCamera = true;

		private const float _threshold = 0.01f;

		private float _lastGroundedSpeed;

		private float _momentumTimer;

		private bool _wasGrounded;

		public bool FlyModeEnabled { get; set; }

		public bool NoclipEnabled { get; set; }

		public float FlySpeed { get; set; } = 15f;

		public bool IsInVehicle { get; set; }

		public float DefaultSensitivity { get; private set; }

		public bool CanSprint
		{
			get
			{
				return _canSprint;
			}
			set
			{
				_canSprint = value;
			}
		}

		public float CurrentSpeed => _speed;

		public bool IsCrouching => _isCrouching;

		public bool CanRotateCamera => _canRotateCamera;

		private void Awake()
		{
			_controller = GetComponent<CharacterController>();
			_input = GetComponent<StarterAssetsInputs>();
			if (_mainCamera == null)
			{
				_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}
			DefaultSensitivity = RotationSpeed;
			_controller.height = StandHeight;
			_controller.center = new Vector3(0f, StandHeight / 2f, 0f);
		}

		private void Start()
		{
			_jumpTimeoutDelta = JumpTimeout;
			_fallTimeoutDelta = FallTimeout;
		}

		private void Update()
		{
			if (FlyModeEnabled)
			{
				FlyUpdate();
			}
			else if (!IsInVehicle)
			{
				if (!_controller.enabled)
				{
					_controller.enabled = true;
				}
				JumpAndGravity();
				GroundedCheck();
				Crouch();
				Move();
			}
		}

		private void LateUpdate()
		{
			if (_canRotateCamera)
			{
				CameraRotation();
			}
		}

		private void FlyUpdate()
		{
			Vector3 forward = _mainCamera.transform.forward;
			Vector3 right = _mainCamera.transform.right;
			Vector3 vector = (forward * _input.move.y + right * _input.move.x).normalized * FlySpeed * Time.deltaTime;
			_input.jump = false;
			_verticalVelocity = 0f;
			if (NoclipEnabled)
			{
				_controller.enabled = false;
				base.transform.position += vector;
				return;
			}
			if (!_controller.enabled)
			{
				_controller.enabled = true;
			}
			_controller.Move(vector);
		}

		public void SetCanRotateCamera(bool value)
		{
			_canRotateCamera = value;
		}

		public void ResetLookPitch()
		{
			_cinemachineTargetPitch = 0f;
			if (CinemachineCameraTarget != null)
			{
				CinemachineCameraTarget.transform.localRotation = Quaternion.identity;
			}
		}

		public void ForceUncrouch()
		{
			_isCrouching = false;
			_controller.height = StandHeight;
			_controller.center = new Vector3(0f, StandHeight / 2f + ControllerCenterYOffset, 0f);
			if (CinemachineCameraTarget != null)
			{
				Vector3 localPosition = CinemachineCameraTarget.transform.localPosition;
				localPosition.y = StandHeight - 0.2f;
				CinemachineCameraTarget.transform.localPosition = localPosition;
			}
		}

		private void GroundedCheck()
		{
			Vector3 position = new Vector3(base.transform.position.x, base.transform.position.y - GroundedOffset, base.transform.position.z);
			Grounded = Physics.CheckSphere(position, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
		}

		private void Crouch()
		{
			_wantsToCrouch = _input.crouch;
			if (_wantsToCrouch)
			{
				_isCrouching = true;
			}
			else if (_isCrouching && !CeilingBlocked())
			{
				_isCrouching = false;
			}
			float num = (_isCrouching ? CrouchHeight : StandHeight);
			_controller.height = num;
			_controller.center = new Vector3(0f, num / 2f + ControllerCenterYOffset, 0f);
			if (CinemachineCameraTarget != null)
			{
				float b = num - 0.2f;
				Vector3 localPosition = CinemachineCameraTarget.transform.localPosition;
				localPosition.y = Mathf.Lerp(localPosition.y, b, Time.deltaTime * CrouchTransitionSpeed);
				CinemachineCameraTarget.transform.localPosition = localPosition;
			}
		}

		private bool CeilingBlocked()
		{
			return Physics.CheckSphere(base.transform.position + Vector3.up * (StandHeight - CeilingCheckOffset), CeilingCheckRadius, GroundLayers, QueryTriggerInteraction.Ignore);
		}

		private void CameraRotation()
		{
			if (_input.look.sqrMagnitude >= 0.01f)
			{
				float num = 1f;
				_cinemachineTargetPitch += _input.look.y * RotationSpeed * num;
				_rotationVelocity = _input.look.x * RotationSpeed * num;
				_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);
				CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0f, 0f);
				base.transform.Rotate(Vector3.up * _rotationVelocity);
			}
		}

		private void Move()
		{
			if (!_controller.enabled)
			{
				return;
			}
			float num = (_isCrouching ? CrouchSpeedMultiplier : 1f);
			float num2 = ((_input.sprint && _canSprint && !_isCrouching) ? SprintSpeed : MoveSpeed) * num;
			float magnitude = new Vector3(_controller.velocity.x, 0f, _controller.velocity.z).magnitude;
			float num3 = 0.1f;
			float num4 = (_input.analogMovement ? _input.move.magnitude : 1f);
			if (Grounded && _input.move != Vector2.zero && _speed > 0.1f)
			{
				float num5 = Mathf.Max(_speed, magnitude);
				if (_isCrouching)
				{
					num5 = Mathf.Min(num5, num2);
				}
				_lastGroundedSpeed = num5;
				_momentumTimer = MomentumBufferTime;
			}
			else if (_momentumTimer > 0f)
			{
				_momentumTimer -= Time.deltaTime;
			}
			bool flag = _wasGrounded && !Grounded;
			_wasGrounded = Grounded;
			if (Grounded)
			{
				float num6 = ((_input.move == Vector2.zero) ? 0f : num2);
				if (magnitude < num6 - num3 || magnitude > num6 + num3)
				{
					_speed = Mathf.Lerp(magnitude, num6 * num4, Time.deltaTime * SpeedChangeRate);
					_speed = Mathf.Round(_speed * 1000f) / 1000f;
				}
				else
				{
					_speed = num6;
				}
			}
			else
			{
				if (flag)
				{
					_speed = magnitude;
					if (!_isCrouching && _momentumTimer > 0f && _input.move != Vector2.zero)
					{
						_speed = Mathf.Max(_speed, _lastGroundedSpeed);
					}
				}
				if (_input.move != Vector2.zero && _speed < AirControlMaxSpeed)
				{
					_speed = Mathf.MoveTowards(_speed, AirControlMaxSpeed, AirControlAcceleration * Time.deltaTime);
				}
			}
			Vector3 vector = new Vector3(_input.move.x, 0f, _input.move.y).normalized;
			if (_input.move != Vector2.zero)
			{
				vector = base.transform.right * _input.move.x + base.transform.forward * _input.move.y;
			}
			_controller.Move(vector.normalized * (_speed * Time.deltaTime) + new Vector3(0f, _verticalVelocity, 0f) * Time.deltaTime);
		}

		private void JumpAndGravity()
		{
			if (Grounded)
			{
				_fallTimeoutDelta = FallTimeout;
				if (_verticalVelocity < 0f)
				{
					_verticalVelocity = -2f;
				}
				if (_input.jump && _jumpTimeoutDelta <= 0f)
				{
					float num = JumpHeight + (_isCrouching ? CrouchJumpBonus : 0f);
					_verticalVelocity = Mathf.Sqrt(num * -2f * Gravity);
				}
				if (_jumpTimeoutDelta >= 0f)
				{
					_jumpTimeoutDelta -= Time.deltaTime;
				}
			}
			else
			{
				_jumpTimeoutDelta = JumpTimeout;
				if (_fallTimeoutDelta >= 0f)
				{
					_fallTimeoutDelta -= Time.deltaTime;
				}
				if (_verticalVelocity > 0f && (_controller.collisionFlags & CollisionFlags.Above) != CollisionFlags.None)
				{
					_verticalVelocity = 0f;
				}
				_input.jump = false;
			}
			if (_verticalVelocity < _terminalVelocity)
			{
				_verticalVelocity += Gravity * Time.deltaTime;
			}
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f)
			{
				lfAngle += 360f;
			}
			if (lfAngle > 360f)
			{
				lfAngle -= 360f;
			}
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}

		private void OnDrawGizmosSelected()
		{
			Color color = new Color(0f, 1f, 0f, 0.35f);
			Color color2 = new Color(1f, 0f, 0f, 0.35f);
			Gizmos.color = (Grounded ? color : color2);
			Gizmos.DrawSphere(new Vector3(base.transform.position.x, base.transform.position.y - GroundedOffset, base.transform.position.z), GroundedRadius);
			Gizmos.color = new Color(0f, 0.5f, 1f, 0.25f);
			Gizmos.DrawSphere(base.transform.position + Vector3.up * (StandHeight - CeilingCheckOffset), CeilingCheckRadius);
		}
	}
}
