using System;
using Duskers.EnemyStates;
using UnityEngine;

public abstract class BaseEnemyBrain
{
	private const float RotationSpeed = 250f;

	private BaseEnemy _thisEnemy;

	private ICombatTarget _combatTarget;

	protected StateMachine _stateMachine;

	private static int _nextBrainId = 1;

	private float _startAngleRads;

	private float _desiredAngleRads;

	private float _rotateStep;

	private float _rotateSpeed;

	private bool _isRotating;

	public virtual BaseEnemy ThisEnemy
	{
		get
		{
			return _thisEnemy;
		}
	}

	public string CurrentState
	{
		get
		{
			return _stateMachine.CurrentState;
		}
	}

	public virtual ICombatTarget CombatTarget
	{
		get
		{
			return _combatTarget;
		}
	}

	public ICombatTarget CollisionTarget { get; private set; }

	public virtual bool RotatesBeforeAttack
	{
		get
		{
			return false;
		}
	}

	public virtual bool RotatesBeforeNavigate
	{
		get
		{
			return false;
		}
	}

	public bool IgnoreCombatWhileNavigating { get; set; }

	public StatePatrol StatePatrol { get; protected set; }

	public StateCombat StateCombat { get; protected set; }

	public StateFlee StateFlee { get; protected set; }

	public StatePatrolIdle StatePatrolIdle { get; protected set; }

	public StatePatrolChewDoor StatePatrolChewDoor { get; protected set; }

	public StateNavigatePath StatePatrolNavigatePath { get; protected set; }

	public StateCurious StatePatrolCurious { get; protected set; }

	public StateNavigatePath StateNavigatePath { get; protected set; }

	public StateStunned StateStunned { get; protected set; }

	public StateGlobalCommon StateGlobalCommon { get; protected set; }

	public StateNil StateNil { get; protected set; }

	public StateCombatNavigate StateCombatNavigate { get; protected set; }

	public StateCombatAttack StateCombatAttack { get; protected set; }

	public StateCombatCharge StateCombatCharge { get; protected set; }

	public virtual int WANDERYNESS
	{
		get
		{
			return 50;
		}
	}

	public virtual float WANDER_CHECK_PERIOD
	{
		get
		{
			return 10f;
		}
	}

	public virtual float DRONE_MOVING_DOOR_CHEW_TIME
	{
		get
		{
			return 5f;
		}
	}

	public virtual float DRONE_IDLE_DOOR_CHEW_TIME
	{
		get
		{
			return 60f;
		}
	}

	public virtual float LURE_DOOR_CHEW_TIME
	{
		get
		{
			return 20f;
		}
	}

	public virtual float GENERAL_DOOR_CHEW_TIME
	{
		get
		{
			return 180f;
		}
	}

	public virtual float DOOR_CHEWED_REMEMBER_TIME
	{
		get
		{
			return 5f;
		}
	}

	public virtual float CURIOUS_PAUSE_TIME
	{
		get
		{
			return 2f;
		}
	}

	public virtual float STEALTH_REMEMBER_TIME
	{
		get
		{
			return 10f;
		}
	}

	public virtual float STEALTH_MEMORY_DISTANCE
	{
		get
		{
			return 2.5f;
		}
	}

	public float WanderCheckTimer { get; set; }

	public float DroneMovingDoorChewTimer { get; set; }

	public float DroneIdleDoorChewTimer { get; set; }

	public float LureDoorChewTimer { get; set; }

	public float GeneralDoorChewTimer { get; set; }

	public float LastAttackTimestamp { get; set; }

	public float LastChewedDoorTimer { get; set; }

	public Door LastChewedDoor { get; set; }

	public Room LastChewedDoorInRoom { get; set; }

	public float ChargeCooldownTimer { get; set; }

	public float SeeStealthedDronesTimer { get; set; }

	public float CollisionMemoryTimer { get; set; }

	public bool CanSeeThroughStealth
	{
		get
		{
			return SeeStealthedDronesTimer > 0f;
		}
	}

	public DroneManager DroneManager { get; private set; }

	public int Id { get; private set; }

	public Animator animator { get; set; }

	public BaseEnemyBrain(BaseEnemy enemy)
	{
		SetThisEnemy(enemy);
		_stateMachine = new StateMachine();
		Id = _nextBrainId++;
	}

	public void SetThisEnemy(BaseEnemy enemy)
	{
		_thisEnemy = enemy;
	}

	public void Initialize()
	{
		CreateStateInstances();
		DroneManager = DroneManager.Instance;
		if (StatePatrolIdle != null && StateCombat != null)
		{
			StatePatrol.Initialize(StatePatrolIdle, StateCombat);
		}
		SetInitialState();
		SetGlobalState();
		WanderCheckTimer = WANDER_CHECK_PERIOD;
		DroneMovingDoorChewTimer = DRONE_MOVING_DOOR_CHEW_TIME;
		DroneIdleDoorChewTimer = DRONE_IDLE_DOOR_CHEW_TIME;
		LureDoorChewTimer = LURE_DOOR_CHEW_TIME;
		GeneralDoorChewTimer = GENERAL_DOOR_CHEW_TIME;
		LastAttackTimestamp = 0f;
		LastChewedDoorTimer = 0f;
		LastChewedDoor = null;
		ChargeCooldownTimer = 0f;
		SeeStealthedDronesTimer = 0f;
	}

	public virtual void CreateStateInstances()
	{
		StatePatrol = new StatePatrol(this);
		StateCombat = new StateCombat(this);
		StateFlee = new StateFlee(this);
		StatePatrolIdle = new StatePatrolIdle(this);
		StatePatrolChewDoor = new StatePatrolChewDoor(this);
		StatePatrolNavigatePath = new StateNavigatePath(this);
		StatePatrolCurious = new StateCurious(this);
		StateNavigatePath = new StateNavigatePath(this);
		StateStunned = new StateStunned(this);
		StateGlobalCommon = new StateGlobalCommon(this);
		StateNil = new StateNil(this);
		StateCombatNavigate = new StateCombatNavigate(this);
		StateCombatAttack = new StateCombatAttack(this);
		StateCombatCharge = new StateCombatCharge(this);
	}

	public void SetCombatTarget(ICombatTarget combatTarget)
	{
		_combatTarget = combatTarget;
	}

	public void ForceNavigateToWaypoint(Waypoint waypoint)
	{
		ForceNavigateToWaypoint(waypoint, 0f);
	}

	public void ForceNavigateToWaypoint(Waypoint waypoint, float overrideSpeed)
	{
		StateNavigatePath.Initialize(waypoint, StatePatrol, overrideSpeed);
		_stateMachine.ChangeState(StateNavigatePath);
	}

	public virtual void Update()
	{
		if (!GlobalSettings.IsGamePaused)
		{
			if (WanderCheckTimer > 0f)
			{
				WanderCheckTimer -= Time.deltaTime;
			}
			if (DroneMovingDoorChewTimer > 0f)
			{
				DroneMovingDoorChewTimer -= Time.deltaTime;
			}
			if (DroneIdleDoorChewTimer > 0f)
			{
				DroneIdleDoorChewTimer -= Time.deltaTime;
			}
			if (LureDoorChewTimer > 0f)
			{
				LureDoorChewTimer -= Time.deltaTime;
			}
			if (GeneralDoorChewTimer > 0f)
			{
				GeneralDoorChewTimer -= Time.deltaTime;
			}
			if (LastChewedDoorTimer > 0f)
			{
				LastChewedDoorTimer -= Time.deltaTime;
			}
			if (ChargeCooldownTimer > 0f)
			{
				ChargeCooldownTimer -= Time.deltaTime;
			}
			if (SeeStealthedDronesTimer > 0f)
			{
				SeeStealthedDronesTimer -= Time.deltaTime;
			}
			if (CollisionMemoryTimer > 0f)
			{
				CollisionMemoryTimer -= Time.deltaTime;
			}
			if (LastChewedDoorTimer <= 0f)
			{
				LastChewedDoor = null;
			}
			if (CollisionMemoryTimer <= 0f && CollisionTarget != null)
			{
				CollisionTarget = null;
			}
			_stateMachine.Update();
		}
	}

	private void DecrementTimerAboveZero(ref float timer)
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
		}
	}

	protected virtual void SetInitialState()
	{
		_stateMachine.ChangeState(StatePatrol);
	}

	protected virtual void SetGlobalState()
	{
		_stateMachine.SetGlobalState(StateGlobalCommon);
	}

	public virtual bool BumpedIntoStealthDrone(ICombatTarget target)
	{
		if (target != null && ThisEnemy != null && !target.IsDead && target.IsHidden && target.ObjectCollider.bounds.Intersects(ThisEnemy.GetComponent<Collider>().bounds))
		{
			return true;
		}
		return false;
	}

	public virtual bool MoveTo(ITargetLocation targetLocation, bool lookAt)
	{
		if (ThisEnemy.CurrentRoom != null)
		{
			for (int i = 0; i < ThisEnemy.CurrentRoom.corridors.Count; i++)
			{
				Corridor corridor = ThisEnemy.CurrentRoom.corridors[i];
				if (!(corridor == null) && corridor.door.state == DoorState.Closed)
				{
					Collider component = corridor.GetComponent<Collider>();
					Collider component2 = ThisEnemy.GetComponent<Collider>();
					if (component.bounds.Intersects(component2.bounds))
					{
						return true;
					}
				}
			}
		}
		else if (ThisEnemy.CurrentCorridor != null && ThisEnemy.CurrentCorridor.door.state == DoorState.Closed)
		{
			return true;
		}
		Vector3 vector = targetLocation.Position;
		bool flag = false;
		Vector3 overrideDestination;
		if (ThisEnemy.CurrentRoom != targetLocation.CurrentRoom && ThisEnemy.CurrentCorridor != targetLocation.CurrentCorridor && StateCombatAttack.GetOverrideDestination(ThisEnemy, targetLocation, out overrideDestination))
		{
			vector = overrideDestination;
		}
		float num = Vector3.Distance(ThisEnemy.transform.position, vector);
		float num2 = 0.3f;
		if (num > num2)
		{
			if (lookAt)
			{
				ThisEnemy.DisconnectOverlay();
				ThisEnemy.LookAt(vector);
				ThisEnemy.ReconnectOverlay();
			}
			ThisEnemy.moveForward();
			return false;
		}
		return true;
	}

	public virtual void LookAt(Vector3 position)
	{
		ThisEnemy.DisconnectOverlay();
		ThisEnemy.LookAt(position);
		ThisEnemy.ReconnectOverlay();
	}

	public virtual void BeginCuriousPause()
	{
	}

	public virtual void EndCuriousPause()
	{
	}

	public void NotifyCollision(ICombatTarget collidingItem)
	{
		CollisionTarget = collidingItem;
		CollisionMemoryTimer = 0.3f;
	}

	public void InitializeRotation(Vector3 targetPos)
	{
		_startAngleRads = (float)Math.PI / 180f * ThisEnemy.transform.rotation.eulerAngles.z;
		Vector3 vector = targetPos - ThisEnemy.transform.position;
		Quaternion quaternion = Quaternion.LookRotation(vector, Vector3.back);
		quaternion.x = 0f;
		quaternion.y = 0f;
		_desiredAngleRads = (float)Math.PI / 180f * quaternion.eulerAngles.z;
		float num = Vector3.Angle(ThisEnemy.transform.up, vector);
		if (num > 0f)
		{
			_rotateSpeed = 250f / num;
		}
		else
		{
			_rotateSpeed = 0f;
		}
		_rotateStep = 0f;
		if (_rotateSpeed != 0f)
		{
			_isRotating = true;
		}
	}

	public bool RotateWhileNotLookingAtTarget()
	{
		if (_isRotating && _rotateStep < 1f)
		{
			_rotateStep += Time.deltaTime * _rotateSpeed;
			_rotateStep = Mathf.Min(_rotateStep, 1f);
			float num = CommonMethods.CurveAngle(_startAngleRads, _desiredAngleRads, _rotateStep);
			ThisEnemy.DisconnectOverlay();
			ThisEnemy.transform.rotation = Quaternion.AngleAxis(num * 57.29578f, new Vector3(0f, 0f, 1f));
			ThisEnemy.ReconnectOverlay();
			return true;
		}
		_isRotating = false;
		return false;
	}

	public void ClearRotating()
	{
		_isRotating = false;
	}

	public bool StartIdleAnimation()
	{
		OnStartIdle();
		return StartAnimation("StartIdle");
	}

	public virtual void OnStartIdle()
	{
	}

	public bool StartWalkAnimation()
	{
		OnStartWalk();
		return StartAnimation("StartWalk");
	}

	public virtual void OnStartWalk()
	{
	}

	public bool StartDeathAnimation()
	{
		OnStartDeath();
		return StartAnimation("StartDeath");
	}

	public virtual void OnStartDeath()
	{
	}

	public bool StartAnimation(string animationName)
	{
		if (!SceneLevelInput.DisableEnemyAnimation && animator != null)
		{
			float transitionDuration = animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
			animator.CrossFade(animationName, transitionDuration, 0, 0f);
			animator.SetTrigger(animationName);
			return true;
		}
		return false;
	}

	public bool StartAttackAnimation()
	{
		if (!SceneLevelInput.DisableEnemyAnimation && animator != null)
		{
			animator.SetTrigger("StartAttack");
			animator.Play("StartAttack");
			return true;
		}
		return false;
	}
}
