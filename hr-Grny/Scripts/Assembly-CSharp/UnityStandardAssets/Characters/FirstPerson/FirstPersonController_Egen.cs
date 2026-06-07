using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Characters.FirstPerson
{
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(AudioSource))]
	public class FirstPersonController_Egen : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CafterPlayerFallHurt_003Ed__93 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FirstPersonController_Egen _003C_003E4__this;

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
			public _003CafterPlayerFallHurt_003Ed__93(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CplayerFalling_003Ed__92 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public FirstPersonController_Egen _003C_003E4__this;

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
			public _003CplayerFalling_003Ed__92(int _003C_003E1__state)
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

		public LayerMask layerMask;

		public GameObject gameController;

		[SerializeField]
		private bool m_IsWalking;

		[SerializeField]
		public float m_WalkSpeed;

		[SerializeField]
		private float m_RunSpeed;

		[SerializeField]
		private MouseLook m_MouseLook;

		[SerializeField]
		private CurveControlledBob m_HeadBob;

		[SerializeField]
		private LerpControlledBob m_JumpBob;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_RunstepLenghten;

		[SerializeField]
		private float m_StepInterval;

		[SerializeField]
		private bool m_UseFovKick;

		[SerializeField]
		private FOVKick m_FovKick;

		[SerializeField]
		private float m_GravityMultiplier;

		[SerializeField]
		private float m_StickToGroundForce;

		[SerializeField]
		private bool m_UseHeadBob;

		private Vector3 m_OriginalCameraPosition;

		private CollisionFlags m_CollisionFlags;

		public Transform m_Camera;

		private Vector2 m_Input;

		public Transform cameraPivot;

		private float m_StepCycle;

		private float m_NextStep;

		private AudioSource m_AudioSource;

		public float gravity;

		public float inAirMultiplier;

		public Vector2 rotationSpeed;

		private Transform thisTransform;

		private Vector3 m_MoveDir;

		private bool m_Jumping;

		private CharacterController character;

		private bool m_PreviouslyGrounded;

		private Vector3 velocity;

		public Transform playerRagdoll;

		public GameObject playerRagdollSP;

		public bool ragdollIsHere;

		private bool playerHurt;

		public GameObject footstepScriptHolder;

		public GameObject headBobAnimHolder;

		public GameObject mainCam;

		public bool playerCaught;

		public bool playerRestart;

		public bool playerCrouch;

		public bool PlayerIsGrounded;

		public bool PlayerIsFalling;

		public bool fallTimerStarted;

		public bool playerLandHard;

		public bool NotStand;

		public bool walkingWater;

		public bool haveSplashed;

		public bool landSoundPlayed;

		public float timeInAir;

		public float fallHurtBad;

		public float hitRoofDistance;

		public bool menuEnabled;

		public GameObject soundHolder;

		public GameObject FallsoundHolder;

		public GameObject Player;

		public GameObject checkGround;

		public GameObject crouchButtonScript;

		public GameObject playerLandAnim;

		public GameObject granny;

		public GameObject momSpider;

		public GameObject inGameOptionMenu;

		public int startingPitch;

		public object audio;

		public bool tempGravity;

		public bool playerEscape;

		public bool playerMoving;

		public bool onElevator;

		private float speed;

		public float mouseSens;

		public AudioClip PCaught;

		public AudioClip playerHit;

		public bool resetSwipeToZero;

		public GameObject landHardSound;

		public bool fallTwoTimes;

		public bool day2;

		public bool day3;

		public GameObject GrannyHuntMusicHolderNightmare;

		public GameObject GrannyHuntMusicHolderHalloween;

		public GameObject GrannyHuntMusicHolderChristmas;

		public GameObject GrannyHuntMusicHolder;

		public bool playerInFreezetrap;

		public float fallDead;

		public virtual void Start()
		{
		}

		public virtual void OnEndGame()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void ProgressStepCycle(float speed)
		{
		}

		private void UpdateCameraPosition(float speed)
		{
		}

		private void GetInput(out float speed)
		{
			speed = default(float);
		}

		public void RotateView()
		{
		}

		[IteratorStateMachine(typeof(_003CplayerFalling_003Ed__92))]
		public virtual IEnumerator playerFalling()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CafterPlayerFallHurt_003Ed__93))]
		public virtual IEnumerator afterPlayerFallHurt()
		{
			return null;
		}

		public void PlayerLandBad()
		{
		}

		public void PlayerGetsCaught()
		{
		}

		public void PlayerGetsCaughtSpider()
		{
		}

		public void resetPlayerMovement()
		{
		}

		public void resetMouse()
		{
		}

		public void disableMouse()
		{
		}

		public void enableMouse()
		{
		}
	}
}
