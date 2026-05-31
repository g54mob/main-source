using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCrouchStand_003Ed__103 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController _003C_003E4__this;

		public bool stepAwayDevice;

		private float _003CtimeElapsed_003E5__2;

		private float _003CtargetHeight_003E5__3;

		private float _003CcurrentHeight_003E5__4;

		private Vector3 _003CtargetCenter_003E5__5;

		private Vector3 _003CcurrentCenter_003E5__6;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CCrouchStand_003Ed__103(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Functional Options")]
	public bool canSprint;

	public bool canJump;

	public bool canCrouch;

	public bool canUseHeadbob;

	public bool blockCamera;

	public bool blockMovement;

	public bool animHeadbob;

	[Header("Stamin")]
	[Range(0f, 100f)]
	public float stamin;

	[Range(0f, 10f)]
	public float regeneratingStayStamin;

	[Range(0f, 10f)]
	public float regeneratingMoveStamin;

	[Range(0f, 10f)]
	public float degradationSpeedStamin;

	public bool staminNull;

	public Image staminViewPower;

	public Image staminSlideViewPower;

	public RectTransform staminView;

	private string hexgreen;

	private Color newGreen;

	[Header("Movement Parameters")]
	public float walkSpeed;

	public float sprintSpeed;

	public float crouchSpeed;

	[Range(1f, 10f)]
	[Header("Look Parameters")]
	public float lookSpeedX;

	[Range(1f, 10f)]
	public float lookSpeedY;

	[Range(1f, 180f)]
	public float upperLookLimit;

	[Range(1f, 180f)]
	public float lowerLookLimit;

	[Header("Jumping Parameters")]
	public float jumpForce;

	public float gravity;

	public bool gravityEnabled;

	[Header("Crouch Parameters")]
	private float crouchHeight;

	private float standingHeight;

	private float timeToCrouch;

	private Vector3 crouchingCenter;

	private Vector3 standingCenter;

	private bool isCrouching;

	public bool duringCrouchAnimation;

	[Header("Headbob Parameters")]
	public float walkBobSpeed;

	public float walkBobAmount;

	public float sprintBobSpeed;

	public float sprintBobAmount;

	public float crouchBobSpeed;

	public float crouchBobAmount;

	public float defaultYPos;

	private float timer;

	[Header("Intervalo de pasos")]
	public float TimeBetweenSteps;

	private float tiempo;

	private int soundControl;

	public bool isMoving;

	public bool isSpriting;

	public bool isAgachado;

	private float airTime;

	public Camera playerCamera;

	private CharacterController characterController;

	public Vector3 moveDirection;

	public Vector2 currentInput;

	public float currentHorizontalInput;

	public float currentVerticalInput;

	public float rotationX;

	[Header("Movement Control")]
	public bool canMoveVertically;

	public int InvertMouseX;

	public int InvertMouseY;

	public float MouseSensitivity;

	public float FieldOfView;

	public float targetFieldOfView;

	[Header("Audio Settings")]
	public AudioSource RightFoot;

	public AudioSource LeftFoot;

	public float stepDelayWalking;

	public float stepDelayRunning;

	public float stepDelayCrouching;

	public AudioClip clip;

	public float clipStartTime;

	private float stepTimer;

	private bool rightFootNext;

	public bool CanMove { get; private set; }

	private bool IsSprinting => false;

	private bool ShouldJump => false;

	private bool ShouldCrouch => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
	}

	public void ManualUpdate()
	{
	}

	private void Update()
	{
	}

	private void PlayFootstep()
	{
	}

	private void HandleFootsteps()
	{
	}

	private void RegenerateStamin(float power)
	{
	}

	private void DegradateStamin(float power)
	{
	}

	private void UpdateUIStamin()
	{
	}

	private void HandleMovementInput()
	{
	}

	public int InputGetAxis(string name)
	{
		return 0;
	}

	private void HandleMouseLook()
	{
	}

	private void HandleJump()
	{
	}

	public void HandleCrouch()
	{
	}

	public void HandleCrouchByStepAwayDevice()
	{
	}

	private void HandleHeadbob()
	{
	}

	private void HandleHeadbobAlways()
	{
	}

	public void HandleHeadbobAlwaysSetDeflaut(bool stepAwayDevice = false)
	{
	}

	private void ApplyFinalMovements()
	{
	}

	public void ToggleGravity(bool enable)
	{
	}

	public void Teleport(Vector3 pos, Quaternion rot)
	{
	}

	[IteratorStateMachine(typeof(_003CCrouchStand_003Ed__103))]
	private IEnumerator CrouchStand(bool stepAwayDevice = false)
	{
		return null;
	}
}
