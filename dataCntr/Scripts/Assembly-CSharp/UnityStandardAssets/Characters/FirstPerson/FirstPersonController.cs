using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityStandardAssets.Characters.FirstPerson
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(AudioSource))]
	public class FirstPersonController : MonoBehaviour
	{
		private Vector2 move;

		[Header("Basic Movement")]
		[SerializeField]
		private bool m_IsWalking;

		[SerializeField]
		private bool m_IsSitting;

		public bool m_isCrouching;

		[Range(0f, 5f)]
		public float m_WalkSpeed;

		[Range(0f, 10f)]
		public float m_RunSpeed;

		[Range(0f, 5f)]
		[SerializeField]
		private float m_CrouchSpeed;

		[Range(1f, 3f)]
		[SerializeField]
		private float m_CrouchingMultiplyer;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_RunstepLenghten;

		[SerializeField]
		private float m_JumpSpeed;

		[SerializeField]
		private float m_AnimationSmoother;

		[SerializeField]
		private float m_StickToGroundForce;

		[SerializeField]
		private float m_GravityMultiplier;

		[SerializeField]
		private float m_StepInterval;

		[SerializeField]
		private float m_ClimbSpeed;

		[SerializeField]
		private float m_Acceleration;

		[SerializeField]
		private float m_Deceleration;

		[Header("Zoom Settings")]
		[SerializeField]
		private float zoomedFov;

		[SerializeField]
		private float fovChangeSpeed;

		private float normalFov;

		private bool isZooming;

		[Header("Audio")]
		private FootSteps footStepsClass;

		[SerializeField]
		private AudioClip[] m_JumpSound;

		[SerializeField]
		[Range(0f, 1f)]
		private float jumpVolume;

		[SerializeField]
		private AudioClip[] m_LandSound;

		[SerializeField]
		[Range(0f, 1f)]
		private float landVolume;

		[Header("External classes")]
		[SerializeField]
		private MouseLook m_MouseLook;

		[SerializeField]
		private RayLookAt m_RayLookAt;

		private CinemachineCamera m_Camera;

		private Vector3 m_OriginalCameraPosition;

		private Vector3 m_OriginalCameraPositionUnchanged;

		private bool m_Jump;

		private Vector2 m_Input;

		private Vector3 m_MoveDir;

		private CharacterController m_CharacterController;

		private CollisionFlags m_CollisionFlags;

		private bool m_PreviouslyGrounded;

		private float m_StepCycle;

		private float m_NextStep;

		private bool m_Jumping;

		private AudioSource m_AudioSource;

		private float m_CurrentSpeed;

		private float crouchHeight;

		private float crouchingHeight;

		private float standingHeight;

		private float pushPower;

		private Transform ladderTrigger;

		private bool m_IsClimbing;

		private Action<InputAction.CallbackContext> movePerformed;

		private Action<InputAction.CallbackContext> moveCanceled;

		private Action<InputAction.CallbackContext> sprintPerformed;

		private Action<InputAction.CallbackContext> sprintCanceled;

		private Action<InputAction.CallbackContext> crouchPerformed;

		private Action<InputAction.CallbackContext> jumpPerformed;

		private Action<InputAction.CallbackContext> zoomPerformed;

		private Action<InputAction.CallbackContext> zoomCanceled;

		private int footStepsCount;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void HandleZoom()
		{
		}

		private void UpdateCameraPosition(float speed)
		{
		}

		private void PlayLandingSound()
		{
		}

		private AudioClip PlayRandomAudioClip(AudioClip[] audioClips, float volume)
		{
			return null;
		}

		private void ProgressStepCycle(float speed)
		{
		}

		private void RotateView()
		{
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
		}

		public MouseLook GetMouseLook()
		{
			return null;
		}

		private void GetInput(out float speed)
		{
			speed = default(float);
		}

		private void Crouch()
		{
		}

		private void StopCrouching()
		{
		}

		public void ResetCameraPosition()
		{
		}

		public void UpdateNormalFov(float fov)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
