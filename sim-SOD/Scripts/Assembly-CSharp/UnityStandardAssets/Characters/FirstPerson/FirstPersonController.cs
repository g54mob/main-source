using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class FirstPersonController : MonoBehaviour
	{
		public class CameraJolt
		{
			public Vector3 direction;

			public float progress;

			public float speed;

			public CameraJolt(Vector3 newDirection, float newSpeed)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRatJumpCooldown_003Ed__105 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FirstPersonController _003C_003E4__this;

			public float delay;

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
			public _003CRatJumpCooldown_003Ed__105(int _003C_003E1__state)
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

		public bool enableMovement;

		public bool enableLook;

		public bool isMoving;

		public bool movementChange;

		public bool enableHeadBob;

		public bool ghostMovement;

		public bool clipping;

		public bool syncTransforms;

		public Player playerScript;

		[SerializeField]
		public bool m_IsWalking;

		public bool m_RunToggle;

		public float m_WalkSpeed;

		public float m_RunSpeed;

		public float speed;

		[SerializeField]
		private float m_RunstepLenghten;

		[SerializeField]
		public float m_StickToGroundForce;

		[SerializeField]
		public float m_GravityMultiplier;

		[SerializeField]
		public MouseLook m_MouseLook;

		[SerializeField]
		private bool m_UseFovKick;

		[SerializeField]
		private FOVKick m_FovKick;

		[SerializeField]
		public CurveControlledBob m_HeadBob;

		public bool m_UseJumpBob;

		[SerializeField]
		public LerpControlledBob m_JumpBob;

		public float m_StepInterval;

		private bool rightFootNext;

		[SerializeField]
		private Transform leanPivot;

		[SerializeField]
		private float leanSpeed;

		[SerializeField]
		private float maxLeanAngle;

		[SerializeField]
		private float maxLeanMovement;

		public Camera m_Camera;

		private bool m_Jump;

		private float m_YRotation;

		public Vector2 m_Input;

		public Vector3 m_MoveDir;

		public CharacterController m_CharacterController;

		public CollisionFlags m_CollisionFlags;

		private bool m_PreviouslyGrounded;

		public Vector3 m_OriginalCameraPosition;

		public float m_StepCycle;

		public float m_NextStep;

		public bool m_Jumping;

		public int leanState;

		public float leanProgress;

		public float currentLeanAngle;

		public float currentLeanMovement;

		public List<CameraJolt> activeJolts;

		public float lastY;

		public float fallCount;

		private Vector3 previousMovement;

		public Vector3 movementThisUpdate;

		private RaycastHit[] hitInfoArray;

		[Header("Rat Movement Settings")]
		public float slopeLimitForAddedJumpCooldown;

		public float maxGroundedDistance;

		public float maxWallRunDistance;

		public float _ratJumpHeight;

		public float ratMoveSpeed;

		public float addedSprintValue;

		public float mouseSensitivity;

		public float wallJumpDelay;

		public float slopeGroundJumpDelay;

		public float groundJumpDelay;

		public float minCamAngle;

		public float maxCamAngle;

		public LayerMask _ratGroundMask;

		public LayerMask buildingMask;

		private Vector2 _ratMoveDir;

		private RaycastHit _groundHitInfo;

		private RaycastHit _wallHitInfo;

		private bool _isRatGrounded;

		private bool _ratGroundedPossible;

		private bool _isWallRunning;

		private bool _ratJumpCooldownActive;

		private Vector3 _ratVelocity;

		private Vector3 _groundHitPoint;

		private Vector3 _groundHitNormal;

		private Vector3 _groundForwardVector;

		private Vector3 _moveVector;

		private Vector3 _wallRunHitPoint;

		private Vector3 _wallRunHitNormal;

		private Vector3 _wallRunHitForwardVector;

		private Vector3 _inputVector;

		private Vector2 _mouseInput;

		private float _currentSlopeAngle;

		private float _camRotX;

		private float _camRotY;

		private void Start()
		{
		}

		public void InitialiseController(bool setOriginalCamPosition, bool initMouslook = true)
		{
		}

		private void Update()
		{
		}

		private void PlayLandingSound()
		{
		}

		private void FixedUpdate()
		{
		}

		public bool PlayerOutOfWorldCheck()
		{
			return false;
		}

		public void UpdateMovement()
		{
		}

		public void JoltCamera(Vector3 direction, float amplitude, float speed)
		{
		}

		public void ProgressStepCycle(float speed, float deltaTime)
		{
		}

		public void UpdateCameraPosition(float speed)
		{
		}

		public void UpdateCameraPositionRatController(float speed)
		{
		}

		private void GetInput(out float speed)
		{
			speed = default(float);
		}

		private void RotateView()
		{
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
		}

		public Vector3 DoHeadBob(CurveControlledBob bob, float speed, float multiplier)
		{
			return default(Vector3);
		}

		private void EvaluateGroundAsRat()
		{
		}

		private void EvaluateRatMouseMovement()
		{
		}

		private void ApplyRatMovement()
		{
		}

		private void HandleRatJumping()
		{
		}

		[IteratorStateMachine(typeof(_003CRatJumpCooldown_003Ed__105))]
		private IEnumerator RatJumpCooldown(float delay)
		{
			return null;
		}

		private bool AreWeClimbingABuilding()
		{
			return false;
		}

		private void CheckWallCeilingCollision()
		{
		}
	}
}
