using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SimpleWanderer : MonoBehaviour
{
	private enum WandererState
	{
		Idle = 0,
		Walking = 1,
		Paused = 2
	}

	[Serializable]
	private class BehaviorProfile
	{
		public FloatRange walkDuration;

		public FloatRange idleDuration;

		public FloatRange pauseChance;

		public FloatRange pauseDuration;

		public FloatRange preferredDistance;

		public static BehaviorProfile Standard()
		{
			return new BehaviorProfile
			{
				walkDuration = new FloatRange(4f, 8f),
				idleDuration = new FloatRange(2f, 4f),
				pauseChance = new FloatRange(0.25f, 0.35f),
				pauseDuration = new FloatRange(1f, 2f),
				preferredDistance = new FloatRange(8f, 15f)
			};
		}

		public static BehaviorProfile Idler()
		{
			return new BehaviorProfile
			{
				walkDuration = new FloatRange(3f, 6f),
				idleDuration = new FloatRange(3f, 6f),
				pauseChance = new FloatRange(0.45f, 0.55f),
				pauseDuration = new FloatRange(2f, 4f),
				preferredDistance = new FloatRange(5f, 12f)
			};
		}

		public static BehaviorProfile Hyper()
		{
			return new BehaviorProfile
			{
				walkDuration = new FloatRange(6f, 10f),
				idleDuration = new FloatRange(1f, 3f),
				pauseChance = new FloatRange(0.1f, 0.2f),
				pauseDuration = new FloatRange(0.5f, 1.5f),
				preferredDistance = new FloatRange(10f, 18f)
			};
		}
	}

	private const float StoppingDistance = 0.5f;

	private const float MinSpeed = 1.2f;

	private const float MaxSpeed = 2.2f;

	private const float PathRecalculationInterval = 2f;

	private const float MovementThreshold = 0.1f;

	private NavMeshAgent _agent;

	private Animator _animator;

	private WandererState _currentState;

	private float _stateTimer;

	private Vector3 _centerPoint;

	private bool _isInitialized;

	private BehaviorProfile _profile;

	private float _pathRecalculationTimer;

	private Vector3 _lastDestination;

	private AnimationClip _idleClip;

	private AnimationClip _walkClip;

	private bool AgentActive
	{
		get
		{
			if (_isInitialized && (bool)_agent && _agent.enabled)
			{
				return _agent.isOnNavMesh;
			}
			return false;
		}
	}

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
		_agent.stoppingDistance = 0.5f;
		_agent.speed = BiteRandom.NextFloat(1.2f, 2.2f);
		_agent.acceleration = BiteRandom.NextFloat(6f, 10f);
		_agent.angularSpeed = BiteRandom.NextFloat(180f, 300f);
		LoadAnimationClips();
		GenerateBehaviorProfile();
	}

	private void LoadAnimationClips()
	{
		_animator = GetComponentInChildren<Animator>();
		AnimationClip[] animationClips = _animator.runtimeAnimatorController.animationClips;
		foreach (AnimationClip animationClip in animationClips)
		{
			if (animationClip.name.Contains("Idle", StringComparison.OrdinalIgnoreCase))
			{
				_idleClip = animationClip;
			}
			else if (animationClip.name.Contains("Walk", StringComparison.OrdinalIgnoreCase))
			{
				_walkClip = animationClip;
			}
			if ((bool)_idleClip && (bool)_walkClip)
			{
				break;
			}
		}
		if (!_idleClip || !_walkClip)
		{
			Debug.LogError($"[{base.gameObject.name}] Could not find required animation clips! Idle: {_idleClip}, Walk: {_walkClip}", this);
		}
	}

	private void GenerateBehaviorProfile()
	{
		float num = BiteRandom.NextFloat();
		BehaviorProfile profile = ((num < 0.3f) ? BehaviorProfile.Idler() : ((!(num < 0.6f)) ? BehaviorProfile.Standard() : BehaviorProfile.Hyper()));
		_profile = profile;
	}

	private void OnEnable()
	{
		if (AgentActive)
		{
			TransitionToState(WandererState.Idle);
		}
	}

	public void Initialize(Vector3 spawnCenter)
	{
		_centerPoint = spawnCenter;
		_isInitialized = true;
		if (AgentActive)
		{
			TransitionToState((!(BiteRandom.NextFloat() > 0.5f)) ? WandererState.Walking : WandererState.Idle);
		}
	}

	private void Update()
	{
		if (AgentActive)
		{
			_stateTimer -= Time.deltaTime;
			_pathRecalculationTimer -= Time.deltaTime;
			switch (_currentState)
			{
			case WandererState.Idle:
				UpdateIdleState();
				break;
			case WandererState.Walking:
				UpdateWalkingState();
				break;
			case WandererState.Paused:
				UpdatePausedState();
				break;
			}
			UpdateAnimation();
		}
	}

	private void UpdateIdleState()
	{
		if (_stateTimer <= 0f)
		{
			TransitionToState(WandererState.Walking);
		}
	}

	private void UpdateWalkingState()
	{
		if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
		{
			TransitionToState((BiteRandom.NextFloat() < _profile.pauseChance.Random) ? WandererState.Paused : WandererState.Idle);
		}
		else if (_stateTimer <= 0f)
		{
			TransitionToState(WandererState.Idle);
		}
		else if (!(_pathRecalculationTimer > 0f) && _agent.hasPath)
		{
			if (Vector3.Distance(base.transform.position, _lastDestination) > _profile.preferredDistance.Random * 1.5f)
			{
				SetPurposefulDestination();
			}
			_pathRecalculationTimer = 2f;
		}
	}

	private void UpdatePausedState()
	{
		if (!(_stateTimer > 0f))
		{
			TransitionToState((BiteRandom.NextFloat() > 0.5f) ? WandererState.Walking : WandererState.Idle);
		}
	}

	private void TransitionToState(WandererState newState)
	{
		_currentState = newState;
		switch (_currentState)
		{
		case WandererState.Idle:
			_stateTimer = _profile.idleDuration.Random;
			if (AgentActive)
			{
				_agent.ResetPath();
			}
			break;
		case WandererState.Walking:
			_stateTimer = _profile.walkDuration.Random;
			_pathRecalculationTimer = 2f;
			SetPurposefulDestination();
			break;
		case WandererState.Paused:
			_stateTimer = _profile.pauseDuration.Random;
			if (AgentActive)
			{
				_agent.ResetPath();
			}
			break;
		}
	}

	private void SetPurposefulDestination()
	{
		if (!AgentActive)
		{
			return;
		}
		Vector3 vector2;
		if (BiteRandom.NextFloat() < 0.7f)
		{
			Vector3 vector = base.transform.position - _centerPoint;
			vector.y = 0f;
			vector2 = Quaternion.Euler(0f, BiteRandom.NextFloat(-45f, 45f), 0f) * vector.normalized;
		}
		else
		{
			vector2 = BiteRandom.NextVector3InsideSphere();
			vector2.y = 0f;
			vector2.Normalize();
		}
		float random = _profile.preferredDistance.Random;
		Vector3 sourcePosition = _centerPoint + vector2 * random;
		sourcePosition.y = _centerPoint.y;
		if (NavMesh.SamplePosition(sourcePosition, out var hit, random * 0.5f, _agent.areaMask))
		{
			NavMeshPath navMeshPath = new NavMeshPath();
			if (_agent.CalculatePath(hit.position, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
			{
				_agent.SetPath(navMeshPath);
				_lastDestination = hit.position;
			}
		}
	}

	private void UpdateAnimation()
	{
		AnimationClip animationClip = ((_currentState == WandererState.Walking && AgentActive && _agent.velocity.magnitude > 0.1f) ? _walkClip : _idleClip);
		if ((bool)animationClip && !IsClipPlaying(animationClip))
		{
			_animator.Play(animationClip.name, 0, 0f);
		}
	}

	private bool IsClipPlaying(AnimationClip clip)
	{
		return _animator.GetCurrentAnimatorStateInfo(0).IsName(clip?.name);
	}
}
