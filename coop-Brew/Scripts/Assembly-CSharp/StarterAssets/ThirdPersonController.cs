using UnityEngine;

namespace StarterAssets
{
	[RequireComponent(typeof(CharacterController))]
	public class ThirdPersonController : MonoBehaviour
	{
		[Header("Player")]
		[Tooltip("Move speed of the character in m/s")]
		public float MoveSpeed;

		[Tooltip("Sprint speed of the character in m/s")]
		public float SprintSpeed;

		[Tooltip("How fast the character turns to face movement direction")]
		[Range(0f, 0.3f)]
		public float RotationSmoothTime;

		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate;

		public float Sensitivity;

		[Space(10f)]
		[Tooltip("The height the player can jump")]
		public float JumpHeight;

		[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
		public float Gravity;

		[Space(10f)]
		[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
		public float JumpTimeout;

		[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
		public float FallTimeout;

		[Header("Player Grounded")]
		[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
		public bool Grounded;

		[Tooltip("Useful for rough ground")]
		public float GroundedOffset;

		[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
		public float GroundedRadius;

		[Tooltip("What layers the character uses as ground")]
		public LayerMask GroundLayers;

		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;

		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp;

		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp;

		[Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
		public float CameraAngleOverride;

		[Tooltip("For locking the camera position on all axis")]
		public bool LockCameraPosition;

		private float _cinemachineTargetYaw;

		private float _cinemachineTargetPitch;

		private float _speed;

		private float _animationBlend;

		private float _targetRotation;

		private float _rotationVelocity;

		private float _verticalVelocity;

		private float _terminalVelocity;

		private float _jumpTimeoutDelta;

		private float _fallTimeoutDelta;

		private int _animIDSpeed;

		private int _animIDGrounded;

		private int _animIDJump;

		private int _animIDFreeFall;

		private int _animIDMotionSpeed;

		private Animator _animator;

		private CharacterController _controller;

		private StarterAssetsInputs _input;

		private GameObject _mainCamera;

		private bool _rotateOnMove;

		private const float _threshold = 0.01f;

		private bool _hasAnimator;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void AssignAnimationIDs()
		{
		}

		private void GroundedCheck()
		{
		}

		private void CameraRotation()
		{
		}

		private void Move()
		{
		}

		private void JumpAndGravity()
		{
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			return 0f;
		}

		private void OnDrawGizmosSelected()
		{
		}

		public void SetSensitivity(float newSensitivity)
		{
		}

		public void SetRotateOnMove(bool newRotateOnMove)
		{
		}
	}
}
