using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LittleSantaController : MonoBehaviour
{
	private enum AIState
	{
		Wandering = 0,
		Following = 1,
		Attacking = 2,
		Stunned = 3
	}

	[CompilerGenerated]
	private sealed class _003CAttackRoutine_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LittleSantaController _003C_003E4__this;

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
		public _003CAttackRoutine_003Ed__63(int _003C_003E1__state)
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
	private sealed class _003CGetHitSequence_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LittleSantaController _003C_003E4__this;

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
		public _003CGetHitSequence_003Ed__60(int _003C_003E1__state)
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
	private sealed class _003CStartAIAfterDelay_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LittleSantaController _003C_003E4__this;

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
		public _003CStartAIAfterDelay_003Ed__57(int _003C_003E1__state)
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
	private sealed class _003CWanderRoutine_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public LittleSantaController _003C_003E4__this;

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
		public _003CWanderRoutine_003Ed__67(int _003C_003E1__state)
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

	private const float PATROL_ANIM_MULTIPLIER = 1.1f;

	private const float CHASE_ANIM_MULTIPLIER = 2f;

	private AIState currentState;

	private Coroutine wanderCoroutine;

	private Coroutine hitCoroutine;

	private float chaseTimer;

	private Transform currentActualTarget;

	private static readonly string ANIM_PARAM_IS_BITING;

	private static readonly string ANIM_PARAM_IS_WALKING;

	private static readonly string ANIM_PARAM_SPEED;

	private static readonly string ANIM_PARAM_IS_STUNNED_ANIMATOR;

	private static readonly string ANIM_TRIGGER_FALLDOWN;

	private static readonly string ANIM_TRIGGER_STANDUP;

	[SerializeField]
	private bool getHit;

	[SerializeField]
	private float fallDownDuration;

	[SerializeField]
	private float standUpDuration;

	[SerializeField]
	private float startDelayTime;

	[SerializeField]
	private Transform playerTarget;

	[SerializeField]
	private Transform hideSpotTarget;

	[SerializeField]
	private EnemyAIGranny grannyRef;

	[SerializeField]
	private GameObject gameController;

	[SerializeField]
	private float wanderRange;

	[SerializeField]
	private float minWaitTime;

	[SerializeField]
	private float maxWaitTime;

	[SerializeField]
	private float maxTimeStuck;

	[SerializeField]
	private float followRadius;

	[SerializeField]
	private float maxChaseDuration;

	[SerializeField]
	private float followSpeedMultiplier;

	[SerializeField]
	private float losePlayerRadius;

	[SerializeField]
	private float viewHeightOffset;

	[SerializeField]
	private float walkSpeed;

	private float animationSpeedMultiplier;

	[SerializeField]
	private AudioSource footstepSource;

	[SerializeField]
	private AudioClip detectionSound;

	[SerializeField]
	private float detectionVolume;

	[SerializeField]
	private AudioClip[] footstepClips;

	[SerializeField]
	private float attackDistance;

	[SerializeField]
	private float attackDuration;

	[SerializeField]
	private float attackCooldownDuration;

	[SerializeField]
	private AudioClip biteSound;

	[SerializeField]
	private AudioClip afterBiteSound;

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

	private float lastAttackTime;

	public bool GetHit
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CStartAIAfterDelay_003Ed__57))]
	private IEnumerator StartAIAfterDelay()
	{
		return null;
	}

	private void InitializeAI()
	{
	}

	private void StartWandering()
	{
	}

	[IteratorStateMachine(typeof(_003CGetHitSequence_003Ed__60))]
	private IEnumerator GetHitSequence()
	{
		return null;
	}

	private bool CanSeePlayer()
	{
		return false;
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CAttackRoutine_003Ed__63))]
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

	[IteratorStateMachine(typeof(_003CWanderRoutine_003Ed__67))]
	private IEnumerator WanderRoutine()
	{
		return null;
	}

	private Vector3 GetRandomPointInNavMesh(Vector3 origin, float range)
	{
		return default(Vector3);
	}
}
