using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour, IPushable
{
	[Header("Player")]
	[Tooltip("Move speed of the character in m/s")]
	[SerializeField]
	private float MoveSpeed;

	[Tooltip("Sprint speed of the character in m/s")]
	[SerializeField]
	private float SprintSpeed;

	[Tooltip("Rotation speed of the character")]
	[SerializeField]
	private float RotationSpeed;

	[Tooltip("Acceleration and deceleration")]
	[SerializeField]
	private float SpeedChangeRate;

	[Space(10f)]
	[Tooltip("The height the player can jump")]
	[SerializeField]
	private float JumpHeight;

	[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
	[SerializeField]
	private float m_Gravity;

	[SerializeField]
	private float m_FreeGravity;

	[Space(10f)]
	[Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
	[SerializeField]
	private float JumpTimeout;

	[Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
	[SerializeField]
	private float FallTimeout;

	[Header("Player Grounded")]
	[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
	[SerializeField]
	private bool Grounded;

	[Tooltip("Useful for rough ground")]
	[SerializeField]
	private float GroundedOffset;

	[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
	[SerializeField]
	private float GroundedRadius;

	[Tooltip("What layers the character uses as ground")]
	[SerializeField]
	private LayerMask GroundLayers;

	[Header("Cinemachine")]
	[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
	[SerializeField]
	private GameObject CinemachineCameraTarget;

	[Tooltip("How far in degrees can you move the camera up")]
	[SerializeField]
	private float TopClamp;

	[Tooltip("How far in degrees can you move the camera down")]
	[SerializeField]
	private float BottomClamp;

	[Tooltip("How far in degrees can you move the camera down")]
	[SerializeField]
	private float minVerticalAngle;

	[Tooltip("How far in degrees can you move the camera up")]
	[SerializeField]
	private float maxVerticalAngle;

	[Tooltip("How far in degrees can you move the camera left")]
	[SerializeField]
	private float minHorizontalAngle;

	[Tooltip("How far in degrees can you move the camera right")]
	[SerializeField]
	private float maxHorizontalAngle;

	private float _verticalAngle;

	private float _horizontalAngle;

	private Vector3 defaultCameraPosition;

	private float pushPositionOffset;

	[Header("Auto Reset Settings")]
	public float resetDelay;

	public float resetSpeed;

	private float _timeSinceLastInput;

	private bool _resetingCamera;

	private const float _threshold = 0.01f;

	private float _cinemachineTargetPitch;

	private float _speed;

	private float _rotationVelocity;

	private float _verticalVelocity;

	private float _terminalVelocity;

	private float _jumpTimeoutDelta;

	private float _fallTimeoutDelta;

	private CharacterController _controller;

	private InputActions m_InputActions;

	private bool _movementInteraction;

	private bool _cameraInteraction;

	private Vector3 m_PushVector;

	private bool m_CachedCameraInteraction;

	private bool m_CachedMovementInteraction;

	public LayerMask TrafficLayer;

	private PlayerInstance playerInstance;

	private PlayerInstance currentPlayerInstance;

	public bool CameraInteraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool MovementInteraction
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public event Action Jumped
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance newLocalInstance)
	{
	}

	private void Start()
	{
	}

	private void SubscribeControllerState(bool enable, bool includeCamera, bool hasSentFromPauseMenu)
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	private void GroundedCheck()
	{
	}

	private void CameraRotation()
	{
	}

	public void ResetCameraRotation()
	{
	}

	public void HardResetCameraRotation(Vector3 _LookRotation)
	{
	}

	public void PushCameraEffect()
	{
	}

	public void SetCameraXRotation(float localEulerX)
	{
	}

	private void Move()
	{
	}

	private void Gravity()
	{
	}

	private void Jump()
	{
	}

	private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		return 0f;
	}

	public void Push(Vector3 dist)
	{
	}
}
