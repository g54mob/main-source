using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	[RequireComponent(typeof(Animator))]
	public class SimpleNPCAnimator : MonoBehaviour, INPCAnimator
	{
		[CompilerGenerated]
		private sealed class _003CDrunkCountdown_003Ed__94 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleNPCAnimator _003C_003E4__this;

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
			public _003CDrunkCountdown_003Ed__94(int _003C_003E1__state)
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
		private sealed class _003CSipToggleRoutine_003Ed__96 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SimpleNPCAnimator _003C_003E4__this;

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
			public _003CSipToggleRoutine_003Ed__96(int _003C_003E1__state)
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

		[Header("Animation Settings")]
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private float speedSmoothing;

		[Header("Ground Snap")]
		[Tooltip("Automatically snap NPC feet to ground on spawn")]
		[SerializeField]
		private bool snapToGroundOnSpawn;

		[Tooltip("Maximum distance to search for ground below NPC")]
		[SerializeField]
		private float groundSnapMaxDistance;

		[Tooltip("Offset from ground (0 = feet exactly on ground)")]
		[SerializeField]
		private float groundOffset;

		private static readonly int MoveSpeedHash;

		private static readonly int CurrentGaitHash;

		private static readonly int IsWalkingHash;

		private static readonly int IsStoppedHash;

		private static readonly int IsStartingHash;

		private static readonly int IsGroundedHash;

		private static readonly int MovementInputHeldHash;

		private static readonly int EmoteTriggerHash;

		private static readonly int DrinkTriggerHash;

		private static readonly int WorkingHash;

		private static readonly int SitHash;

		private static readonly int HeadLookXHash;

		private static readonly int HeadLookYHash;

		private static readonly int SipHash;

		private static readonly int IsDrinkingHash;

		private static readonly int WaveHash;

		private static readonly int IsDrunkHash;

		private static readonly int HitFrontHash;

		private static readonly int HitBackHash;

		private static readonly int HitLeftHash;

		private static readonly int HitRightHash;

		private static readonly int IsDeadHash;

		private static readonly int StaggerHash;

		private static readonly int InCombatHash;

		private static readonly int IsUnarmedAttackingHash;

		private static readonly int UnarmedAttackIndexHash;

		private static readonly int StrafeDirectionXHash;

		private static readonly int StrafeDirectionZHash;

		private static readonly int IsStrafingHash;

		private static readonly int ForwardStrafeHash;

		private static readonly int ThrowBottleHash;

		private Vector3 previousPosition;

		private float smoothedSpeed;

		private bool initialized;

		private bool hasWorkingParam;

		private bool hasSipParam;

		private Coroutine sipRoutine;

		private bool isSipping;

		private int drinkingLayerIndex;

		private float currentDrinkingWeight;

		private float targetDrinkingWeight;

		private const float drinkingWeightTransitionSpeed = 2f;

		private int combatLayerIndex;

		private float currentCombatWeight;

		private float targetCombatWeight;

		private const float combatWeightTransitionSpeed = 5f;

		private int throwLayerIndex;

		private float currentThrowWeight;

		private float targetThrowWeight;

		private const float throwWeightTransitionSpeed = 25f;

		private bool isThrowing;

		private int prevGait;

		private bool prevWalking;

		private bool prevStopped;

		private bool prevStarting;

		private float drunkUntilTime;

		private Coroutine drunkRoutine;

		private AStarNPCMotor cachedMotor;

		private const float MaxDrunkDurationSeconds = 180f;

		private bool isStrafing;

		private float strafeDirectionX;

		private float strafeDirectionZ;

		private float smoothedStrafeX;

		private float smoothedStrafeZ;

		private const float strafeSmoothSpeed = 10f;

		public bool IsDrunk => false;

		public event Action OnDrunkStateCleared
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

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private float CalculateSpeed(float deltaTime)
		{
			return 0f;
		}

		public void PlayWalking()
		{
		}

		public void PlayIdle()
		{
		}

		public void PlayRandomEmote()
		{
		}

		public void PlayDrink()
		{
		}

		public void PlayWorking()
		{
		}

		public void StopWorking()
		{
		}

		public void PlaySitting()
		{
		}

		public void StopSitting()
		{
		}

		public void SetHeadLook(float x, float y)
		{
		}

		public void StartDrinking()
		{
		}

		public void StopDrinking()
		{
		}

		public void SetDrunkForDuration(float durationSeconds)
		{
		}

		public void SetIsDrunk(bool isDrunk)
		{
		}

		public void ClearDrunkState()
		{
		}

		[IteratorStateMachine(typeof(_003CDrunkCountdown_003Ed__94))]
		private IEnumerator DrunkCountdown()
		{
			return null;
		}

		public void TriggerSip()
		{
		}

		[IteratorStateMachine(typeof(_003CSipToggleRoutine_003Ed__96))]
		private IEnumerator SipToggleRoutine()
		{
			return null;
		}

		public void TriggerWave()
		{
		}

		public void EnableCombatLayer()
		{
		}

		public void DisableCombatLayer()
		{
		}

		public void SetCombatLayerWeightImmediate(float weight)
		{
		}

		public void SetUnarmedAttacking(bool isAttacking)
		{
		}

		public void SetUnarmedAttackIndex(int index)
		{
		}

		public bool IsCombatLayerActive()
		{
			return false;
		}

		public float GetCombatLayerWeight()
		{
			return 0f;
		}

		public int StartThrow()
		{
			return 0;
		}

		public void EndThrow()
		{
		}

		public bool IsThrowing()
		{
			return false;
		}

		public float GetThrowLayerWeight()
		{
			return 0f;
		}

		public int GetThrowLayerIndex()
		{
			return 0;
		}

		public void SetStrafing(bool enable)
		{
		}

		public void SetStrafeDirection(float x, float z)
		{
		}

		public void SetStrafeDirectionFromMovement(Vector3 movementDirection, Vector3 facingDirection)
		{
		}

		public bool IsStrafing()
		{
			return false;
		}

		public Vector2 GetStrafeDirection()
		{
			return default(Vector2);
		}

		private bool IsMotorCommanded()
		{
			return false;
		}

		public void SnapToGround()
		{
		}

		public bool IsWalking()
		{
			return false;
		}

		public bool IsWorking()
		{
			return false;
		}

		public bool IsSitting()
		{
			return false;
		}

		public void SetDead(bool isDead)
		{
		}

		public void SetStagger(bool isStaggered)
		{
		}

		private void SetWorking(bool isWorking)
		{
		}

		private bool HasParameter(int nameHash, AnimatorControllerParameterType type)
		{
			return false;
		}

		public void TriggerHitReaction(int direction)
		{
		}
	}
}
