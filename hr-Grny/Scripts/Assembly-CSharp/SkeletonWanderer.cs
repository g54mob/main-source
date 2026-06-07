using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class SkeletonWanderer : MonoBehaviour
{
	private enum AIState
	{
		Wandering = 0,
		Following = 1,
		Attacking = 2
	}

	[CompilerGenerated]
	private sealed class _003CAttackRoutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SkeletonWanderer _003C_003E4__this;

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
		public _003CAttackRoutine_003Ed__43(int _003C_003E1__state)
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
	private sealed class _003CWanderRoutine_003Ed__47 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SkeletonWanderer _003C_003E4__this;

		private float _003CtimeStuck_003E5__2;

		private bool _003CreachedDestination_003E5__3;

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
		public _003CWanderRoutine_003Ed__47(int _003C_003E1__state)
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

	private AIState currentState;

	private Coroutine wanderCoroutine;

	private float chaseTimer;

	[Header("Dependencies")]
	[Tooltip("Reference to the Granny GameObject that holds the EnemyAIGranny script, used to check if the player is hidden.")]
	[SerializeField]
	private GameObject granny;

	[Header("Wander Parameters")]
	[SerializeField]
	private float wanderRange;

	[SerializeField]
	private float minWaitTime;

	[SerializeField]
	private float maxWaitTime;

	[SerializeField]
	private float maxTimeStuck;

	[Header("Detection & Follow")]
	[Tooltip("The player's Transform used for movement (NavMesh destination) and detection checks. MUST BE ASSIGNED IN INSPECTOR.")]
	[SerializeField]
	private Transform playerTarget;

	[Tooltip("Radius at which the skeleton stops wandering and attempts to see the player (LOS must be clear to START chase).")]
	[SerializeField]
	private float followRadius;

	[Tooltip("The time (in seconds) the skeleton will pursue the player's current location once detected, regardless of LOS.")]
	[SerializeField]
	private float maxChaseDuration;

	[SerializeField]
	private float followSpeedMultiplier;

	[SerializeField]
	private float losePlayerRadius;

	[Header("Line of Sight")]
	[Tooltip("Vertical offset for the sight line (e.5f for chest height).")]
	[SerializeField]
	private float viewHeightOffset;

	[Header("Movement & Animation")]
	[SerializeField]
	private float walkSpeed;

	[SerializeField]
	private string isWalkingParamName;

	[Tooltip("The name of the Animator float parameter used to control the walk/run animation speed (e.g., 'Speed' or 'MovementSpeed').")]
	[SerializeField]
	private string movementSpeedParamName;

	[Header("Sound")]
	[SerializeField]
	private AudioSource footstepSource;

	[Tooltip("Sound played when the skeleton transitions from Wandering to Following.")]
	[SerializeField]
	private AudioClip detectionSound;

	[Tooltip("Volume multiplier for the detection sound (3.0 is a good loud default).")]
	[SerializeField]
	private float detectionVolume;

	[SerializeField]
	private AudioClip[] footstepClips;

	[Header("Attack")]
	[Tooltip("The minimum distance required to stop and perform the attack animation/action.")]
	[SerializeField]
	private float attackDistance;

	[Tooltip("The duration (in seconds) the skeleton pauses to perform the attack.")]
	[SerializeField]
	private float attackDuration;

	[Tooltip("The particle system component to play when the skeleton attacks (vomits).")]
	[SerializeField]
	private ParticleSystem vomitParticles;

	[Tooltip("The duration (in seconds) the skeleton must ignore the player after attacking.")]
	[SerializeField]
	private float attackCooldownDuration;

	[Tooltip("Sound played when the skeleton attacks (vomits).")]
	[SerializeField]
	private AudioClip vomitSound;

	[Tooltip("Reference to the UI script that manages the screen vomit overlay effect.")]
	[SerializeField]
	private VomitEffectUI vomitEffectUI;

	[Header("Head Look At Player (IK)")]
	[Tooltip("The Transform the skeleton's head will rotate toward. If NULL, it defaults to the Player Target.")]
	[SerializeField]
	private Transform lookTarget;

	[SerializeField]
	private string headBoneName;

	[SerializeField]
	private float lookSpeed;

	private NavMeshAgent agent;

	private Animator animator;

	private Vector3 initialPosition;

	private Transform headBone;

	private float currentLookWeight;

	private float stuckSpeedThreshold;

	private Vector3 lastTargetPosition;

	private float lastAttackTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private bool CanSeePlayer()
	{
		return false;
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CAttackRoutine_003Ed__43))]
	private IEnumerator AttackRoutine()
	{
		return null;
	}

	private void OnAnimatorIK(int layerIndex)
	{
	}

	private Transform FindDeepChild(Transform parent, string name)
	{
		return null;
	}

	public void PlayFootstepSound()
	{
	}

	[IteratorStateMachine(typeof(_003CWanderRoutine_003Ed__47))]
	private IEnumerator WanderRoutine()
	{
		return null;
	}

	private Vector3 GetRandomPointInNavMesh(Vector3 origin, float range)
	{
		return default(Vector3);
	}
}
