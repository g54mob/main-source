using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, ICombatTarget, IDamagableObject, IHasHitpoints, ITargetLocation, IUpdateCameraView
{
	public GameObject droneViewModel;

	public GameObject droneViewDeadModel;

	protected Material thisMat;

	public Material DeathMtl;

	public Material DeathModelMtl;

	public Color DeadColor = Color.grey;

	public Material StunMtl;

	public Color StunColor = Color.grey;

	public bool ShowOverlay = true;

	public bool TestOnlyUntilFirstScan = true;

	public float DistToShowOverlay = 2f;

	public float OverlayFadeOutTime = 2f;

	public float OverlayFadeOutTimeOnDeath = 4f;

	public Color OverlayTintColor = Color.red;

	private int _id = -1;

	private float _velocityScale = 2.4f;

	private float _currentSpeed;

	protected DroneManager _droneManager;

	protected float _currentHitpoints;

	private ColorBlinkManager _blinkManager = new ColorBlinkManager();

	private Material _blinkMat;

	private Material startMtl;

	private Material startMainMtl;

	private Material altMainMtl;

	private Color startColor;

	private ProjectileManager _projectileManager;

	protected Dictionary<ICombatTarget, float> _attackerThreat = new Dictionary<ICombatTarget, float>();

	protected ICombatTarget _lastCombatTarget;

	protected readonly float THREAT_MARGIN = 10f;

	protected ICombatTarget _overrideTarget;

	protected bool _isDead;

	protected static System.Random _random = new System.Random();

	private Dictionary<string, float> _speedModifiers = new Dictionary<string, float>();

	protected BaseEnemyBrain _brain;

	protected GameObject uiOverlay;

	protected Material uiOverlayMat;

	protected Transform droneViewModelDefaultTransform;

	protected Material droneViewModelDefaultTransformMat;

	protected Transform droneViewDeadModelDefaultTransform;

	protected Material droneViewDeadModelDefaultTransformMat;

	public Animator animator;

	protected bool isOverlayFadingOut;

	protected bool isOverlayFadingOutOnDeath;

	private float timerOverlayFadeOut;

	private Color overlayIsFadingColor = Color.red;

	private bool wasTravelingInShip;

	private bool overlayWasShowing;

	private bool disableOverlay;

	private bool _warnedAboutBeingInSpace;

	private Room _currentRoom;

	private Corridor _currentCorridor;

	private float guiCurrentHitpoints;

	private string _guiString = string.Empty;

	public float CurrentSpeed
	{
		get
		{
			return _currentSpeed;
		}
	}

	public int Id
	{
		get
		{
			return _id;
		}
	}

	public string CurrentState
	{
		get
		{
			return (_brain == null) ? string.Empty : _brain.CurrentState;
		}
	}

	public ICombatTarget CurrentTarget
	{
		get
		{
			object result;
			if (_brain != null)
			{
				ICombatTarget combatTarget = _brain.CombatTarget;
				result = combatTarget;
			}
			else
			{
				result = null;
			}
			return (ICombatTarget)result;
		}
	}

	protected virtual EnemyAiBehaviors Behaviors
	{
		get
		{
			return EnemyAiBehaviors.None;
		}
	}

	public virtual GameObject MainVisibleObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public virtual GameObject MainUIObject
	{
		get
		{
			return uiOverlay;
		}
	}

	public virtual bool CanSeeThroughStealth
	{
		get
		{
			return _brain.CanSeeThroughStealth;
		}
	}

	public bool TravelingInShip { get; set; }

	public virtual float BaseMoveSpeed
	{
		get
		{
			return 1f;
		}
	}

	public virtual float AttackSpeed
	{
		get
		{
			return 1f;
		}
	}

	public virtual float AttackDamage
	{
		get
		{
			return 1f;
		}
	}

	protected virtual DamageType AttackDamageType
	{
		get
		{
			return DamageType.Physical;
		}
	}

	public virtual float AttackRadius
	{
		get
		{
			return 1f;
		}
	}

	protected virtual ProjectileTypeEnum ProjectileType
	{
		get
		{
			return ProjectileTypeEnum.Large;
		}
	}

	public virtual float ChargeSpeed
	{
		get
		{
			return 4f;
		}
	}

	public virtual float ChargeAttackDamage
	{
		get
		{
			return 80f;
		}
	}

	public virtual float ChargeCooldown
	{
		get
		{
			return 30f;
		}
	}

	public virtual float ChargeStunDuration
	{
		get
		{
			return 5f;
		}
	}

	public Vector3 LastVelocity { get; set; }

	public bool TempTag { get; set; }

	public List<BaseEnemy> TempEnemies { get; set; }

	public virtual Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	public virtual Collider ObjectCollider
	{
		get
		{
			return GetComponent<Collider>();
		}
	}

	public virtual bool CanCollide
	{
		get
		{
			return true;
		}
	}

	public virtual List<ICombatTarget> SubordinateTargets { get; set; }

	public bool IsHidden
	{
		get
		{
			return false;
		}
	}

	public Room CurrentRoom
	{
		get
		{
			return _currentRoom;
		}
		set
		{
			if (_currentRoom != null)
			{
				_currentRoom.DeRegisterEnemy(this);
			}
			_currentRoom = value;
			if (value != null)
			{
				_currentRoom.RegisterEnemy(this);
			}
		}
	}

	public Corridor CurrentCorridor
	{
		get
		{
			return _currentCorridor;
		}
		set
		{
			if (_currentCorridor != null)
			{
				_currentCorridor.DeRegisterEnemy(this);
			}
			_currentCorridor = value;
			if (value != null)
			{
				_currentCorridor.RegisterEnemy(this);
			}
		}
	}

	public float CurrentHitPoints
	{
		get
		{
			return _currentHitpoints;
		}
	}

	public virtual float TotalHitpoints
	{
		get
		{
			return 100f;
		}
	}

	public float TimeStunned { get; set; }

	public bool IsDead
	{
		get
		{
			return _isDead;
		}
	}

	public bool IsStunned { get; protected set; }

	public Vector3 StunPosition { get; protected set; }

	public string guiStatus
	{
		get
		{
			if (guiCurrentHitpoints != CurrentHitPoints)
			{
				_guiString = " (" + Math.Round(CurrentHitPoints, 0) + ") ";
				guiCurrentHitpoints = CurrentHitPoints;
			}
			return _guiString;
		}
	}

	private void Awake()
	{
		_currentSpeed = BaseMoveSpeed;
		_currentHitpoints = TotalHitpoints;
		startMtl = GetComponent<Renderer>().material;
		startColor = startMtl.color;
		thisMat = GetComponent<Renderer>().material;
		SubordinateTargets = new List<ICombatTarget>();
		_droneManager = DroneManager.Instance;
		TempEnemies = new List<BaseEnemy>(15);
		if (droneViewModel != null)
		{
			Transform[] componentsInChildren = droneViewModel.GetComponentsInChildren<Transform>();
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				if (transform.name.StartsWith("default"))
				{
					droneViewModelDefaultTransform = transform;
				}
			}
		}
		if (droneViewDeadModel != null)
		{
			Transform[] componentsInChildren2 = droneViewDeadModel.GetComponentsInChildren<Transform>();
			Transform[] array2 = componentsInChildren2;
			foreach (Transform transform2 in array2)
			{
				if (transform2.name.StartsWith("default"))
				{
					droneViewDeadModelDefaultTransform = transform2;
				}
			}
		}
		disableOverlay = !GameSaveFile.Get("D_ENMYREC", true);
		OnAwake();
	}

	protected virtual void OnAwake()
	{
	}

	private void Start()
	{
		if (GetType() != typeof(SlimeEnemy))
		{
			_projectileManager = ProjectileManager.Instance();
		}
		OnInitialize();
		OnStart();
		if (_brain == null)
		{
			Debug.LogWarning("_brain must be initialized in OnStart override of the enemy!!!");
		}
		else
		{
			_brain.animator = animator;
		}
		UpdateCameraView();
		startMainMtl = MainVisibleObject.GetComponent<Renderer>().material;
		altMainMtl = MainVisibleObject.GetComponent<Renderer>().material;
		if (uiOverlay != null)
		{
			if (!uiOverlayMat)
			{
				uiOverlayMat = uiOverlay.GetComponent<Renderer>().material;
			}
			uiOverlay.GetComponent<Renderer>().enabled = false;
		}
	}

	protected virtual void OnDestroy()
	{
		droneViewModel = null;
		droneViewDeadModel = null;
		DeathMtl = null;
		DeathModelMtl = null;
		StunMtl = null;
		UnityEngine.Object.DestroyImmediate(startMtl);
		UnityEngine.Object.DestroyImmediate(startMainMtl);
		UnityEngine.Object.DestroyImmediate(_blinkMat);
		UnityEngine.Object.DestroyImmediate(uiOverlayMat);
		UnityEngine.Object.DestroyImmediate(altMainMtl);
		UnityEngine.Object.DestroyImmediate(droneViewModelDefaultTransformMat);
		UnityEngine.Object.DestroyImmediate(droneViewDeadModelDefaultTransformMat);
	}

	protected virtual void OnStart()
	{
	}

	private void Update()
	{
		if (!GlobalSettings.IsGamePaused && GlobalSettings.MissionStarted)
		{
			if (_blinkManager.IsActive)
			{
				if (!_blinkMat)
				{
					_blinkMat = GetComponent<Renderer>().material;
				}
				_blinkMat.color = _blinkManager.Update(Time.deltaTime);
				if (IsDead)
				{
					_blinkMat.color = DeadColor;
				}
			}
			if (_attackerThreat.Keys.Count > 0)
			{
				List<ICombatTarget> list = _attackerThreat.Keys.ToList();
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					ICombatTarget combatTarget = list[i];
					if (combatTarget.IsDead || IsTargetHidden(combatTarget) || !TargetIsInSameRoom(combatTarget))
					{
						_attackerThreat.Remove(combatTarget);
					}
				}
			}
			if (_brain != null && !IsDead)
			{
				_brain.Update();
			}
			if (GlobalSettings.cheatMode)
			{
				EnableRenderer(true);
			}
			if (isOverlayFadingOutOnDeath && uiOverlay != null)
			{
				timerOverlayFadeOut -= Time.deltaTime;
				if (timerOverlayFadeOut <= 0f)
				{
					isOverlayFadingOut = false;
					if (uiOverlay != null)
					{
						uiOverlay.GetComponent<Renderer>().enabled = false;
					}
				}
				else
				{
					overlayIsFadingColor.a = timerOverlayFadeOut / OverlayFadeOutTimeOnDeath;
					if (uiOverlay != null)
					{
						uiOverlayMat.color = overlayIsFadingColor;
					}
				}
			}
		}
		OnUpdate();
		if (TravelingInShip)
		{
			if (!altMainMtl)
			{
				altMainMtl = MainVisibleObject.GetComponent<Renderer>().material;
			}
			wasTravelingInShip = true;
			thisMat = GetComponent<Renderer>().material;
			thisMat = ResourceManager.GenericTransparantDiffuseCharacterMaterial;
			altMainMtl = ResourceManager.GenericTransparantDiffuseCharacterMaterial;
			Color color = altMainMtl.color;
			color.a = DungeonManager.Instance.BoardingVessel.ShipAlpha;
			thisMat.color = color;
			altMainMtl.color = color;
			if (uiOverlay != null)
			{
				color = uiOverlayMat.color;
				color.a = DungeonManager.Instance.BoardingVessel.ShipAlpha;
				uiOverlayMat.color = color;
			}
		}
		else
		{
			if (!wasTravelingInShip)
			{
				return;
			}
			wasTravelingInShip = false;
			altMainMtl = startMainMtl;
			if (!IsDead)
			{
				return;
			}
			thisMat = DeathMtl;
			if (droneViewDeadModelDefaultTransform != null)
			{
				if (!droneViewDeadModelDefaultTransformMat)
				{
					droneViewDeadModelDefaultTransformMat = droneViewDeadModelDefaultTransform.GetComponent<Renderer>().material;
				}
				droneViewDeadModelDefaultTransformMat = DeathModelMtl;
			}
			else if (droneViewModelDefaultTransform != null)
			{
				if (!droneViewModelDefaultTransformMat)
				{
					droneViewModelDefaultTransformMat = droneViewModelDefaultTransform.GetComponent<Renderer>().material;
				}
				droneViewModelDefaultTransformMat = DeathModelMtl;
			}
			thisMat.color = DeadColor;
		}
	}

	public virtual void OnUpdate()
	{
	}

	public void DisconnectOverlay()
	{
		if (uiOverlay != null)
		{
			uiOverlay.transform.parent = null;
		}
	}

	public virtual void ReconnectOverlay()
	{
		if (uiOverlay != null)
		{
			uiOverlay.transform.parent = base.transform;
		}
	}

	public virtual void EnableRenderer(bool enabled)
	{
		GetComponent<Renderer>().enabled = enabled;
	}

	public void SetId(int id)
	{
		if (_id == -1)
		{
			_id = id;
		}
	}

	public virtual void OnInitialize()
	{
	}

	private Vector3 GetVelocityDelta()
	{
		return GetVelocityDelta(_currentSpeed);
	}

	private Vector3 GetVelocityDelta(float speed)
	{
		LastVelocity = GetVelocity(speed) * Time.deltaTime;
		return LastVelocity;
	}

	public Vector3 GetVelocity(float speed)
	{
		return base.transform.up * _velocityScale * speed;
	}

	public virtual float GetRotationRateDelta()
	{
		return 180f * Time.deltaTime;
	}

	public void moveForward()
	{
		base.transform.position += GetVelocityDelta();
		OnMove();
	}

	public void moveForward(float overrideSpeed)
	{
		base.transform.position += GetVelocityDelta(overrideSpeed);
		OnMove();
	}

	public void moveBackwards()
	{
		base.transform.position -= GetVelocityDelta();
		OnMove();
	}

	protected virtual void OnMove()
	{
	}

	public void LookAt(Vector3 lookPosition)
	{
		Quaternion rotation = Quaternion.LookRotation(lookPosition - base.transform.position, Vector3.back);
		rotation.x = 0f;
		rotation.y = 0f;
		DisconnectOverlay();
		base.transform.rotation = rotation;
		ReconnectOverlay();
	}

	public void AddSpeedModifier(string modifierKey, float modifierValue)
	{
		_speedModifiers[modifierKey] = modifierValue;
		UpdateSpeed();
	}

	public void RemoveSpeedModifier(string modifierKey)
	{
		_speedModifiers.Remove(modifierKey);
		UpdateSpeed();
	}

	private void UpdateSpeed()
	{
		float num = BaseMoveSpeed;
		foreach (float value in _speedModifiers.Values)
		{
			float num2 = value;
			num *= num2;
		}
		_currentSpeed = num;
	}

	public virtual ICombatTarget SelectBestCombatTarget()
	{
		bool flag = HasBehavior(EnemyAiBehaviors.AttacksWhenHit);
		bool flag2 = HasBehavior(EnemyAiBehaviors.AttacksDroneOnSight);
		bool flag3 = HasBehavior(EnemyAiBehaviors.AttractedToLures);
		bool flag4 = HasBehavior(EnemyAiBehaviors.AttacksProbes);
		bool flag5 = HasBehavior(EnemyAiBehaviors.AttacksSensors);
		ICombatTarget combatTarget = null;
		if (flag)
		{
			combatTarget = GetMostThreateningTarget();
		}
		if (combatTarget == null && flag3)
		{
			combatTarget = GetLocalLureToAttack();
		}
		if (combatTarget == null && flag4)
		{
			combatTarget = GetLocalProbeToAttack();
		}
		if (combatTarget == null && flag2)
		{
			combatTarget = GetLocalDroneToAttack();
		}
		if (combatTarget == null && flag5)
		{
			combatTarget = GetLocalSensorToAttack();
		}
		MonoBehaviour monoBehaviour = combatTarget as MonoBehaviour;
		if (monoBehaviour != null && monoBehaviour.gameObject == null)
		{
			Debug.LogWarning("Selected a bad target, gameObject is null - " + combatTarget);
			combatTarget = null;
		}
		return combatTarget;
	}

	public bool IsTargetHidden(ICombatTarget target)
	{
		bool flag = target.IsHidden;
		if (flag && CanSeeThroughStealth)
		{
			float num = Vector3.Distance(Position, target.Position);
			if (num < _brain.STEALTH_MEMORY_DISTANCE)
			{
				flag = false;
			}
		}
		return flag;
	}

	public ICombatTarget GetMostThreateningTarget()
	{
		ICombatTarget mostThreateningAttacker = null;
		if (_attackerThreat.Count > 0)
		{
			float num = -1f;
			if (mostThreateningAttacker != null)
			{
				num = _attackerThreat.First((KeyValuePair<ICombatTarget, float> x) => x.Key == mostThreateningAttacker).Value;
			}
			foreach (KeyValuePair<ICombatTarget, float> item in _attackerThreat)
			{
				ICombatTarget key = item.Key;
				float value = item.Value;
				if (value + THREAT_MARGIN > num && !key.IsDead && !IsTargetHidden(key))
				{
					num = value;
					mostThreateningAttacker = key;
				}
			}
		}
		return mostThreateningAttacker;
	}

	public bool TargetIsInSameRoom(ICombatTarget target)
	{
		bool flag = false;
		if (CurrentCorridor != null)
		{
			if (_warnedAboutBeingInSpace)
			{
				_warnedAboutBeingInSpace = false;
			}
			if (CurrentCorridor == target.CurrentCorridor)
			{
				flag = true;
			}
			else if (target.CurrentRoom != null && target.CurrentRoom.corridors.Any((Corridor x) => x.door.state == DoorState.Open && x == CurrentCorridor))
			{
				flag = true;
			}
		}
		else if (CurrentRoom != null)
		{
			if (_warnedAboutBeingInSpace)
			{
				_warnedAboutBeingInSpace = false;
			}
			if (CurrentRoom == target.CurrentRoom)
			{
				flag = true;
			}
			else
			{
				int count = CurrentRoom.corridors.Count;
				for (int num = 0; num < count; num++)
				{
					Corridor corridor = CurrentRoom.corridors[num];
					if (corridor.door.state != DoorState.Open)
					{
						continue;
					}
					if (corridor == target.CurrentCorridor)
					{
						flag = true;
					}
					else if (target.CurrentRoom != null && target.CurrentRoom.corridors.Any((Corridor x) => x == corridor) && target.ObjectCollider != null && corridor.GetComponent<Collider>().bounds.Intersects(target.ObjectCollider.bounds))
					{
						float num2 = Vector3.Distance(target.Position, Position);
						if (num2 <= 2.5f)
						{
							flag = true;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
		}
		else if (!_warnedAboutBeingInSpace)
		{
			_warnedAboutBeingInSpace = true;
			Debug.LogWarning(ToString() + " is in space!!! (no room or corridor registered)");
		}
		return flag;
	}

	protected virtual ICombatTarget GetLocalDroneToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget combatTarget = _droneManager.dronesList.FirstOrDefault((Drone x) => !x.IsDead && !IsTargetHidden(x) && TargetIsInSameRoom(x));
		bool flag = HasBehavior(EnemyAiBehaviors.DetectsEnemyInAdjacentRoom);
		if (CurrentRoom != null && combatTarget == null)
		{
			IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(CurrentRoom)
				where AdjacentRoomCanBeEntered(x)
				select x;
			foreach (AdjacentRoomData item in enumerable)
			{
				Room adjacentRoom;
				if (item.Room1 == CurrentRoom)
				{
					adjacentRoom = item.Room2;
				}
				else
				{
					adjacentRoom = item.Room1;
				}
				combatTarget = _droneManager.dronesList.FirstOrDefault((Drone x) => !x.IsDead && !IsTargetHidden(x) && x.CurrentRoom == adjacentRoom);
				if (flag && combatTarget != null)
				{
					break;
				}
				if (combatTarget != null)
				{
					float num = Vector3.Distance(combatTarget.Position, Position);
					if (num <= 3f)
					{
						break;
					}
				}
				combatTarget = null;
			}
		}
		return combatTarget;
	}

	protected virtual ICombatTarget GetLocalLureToAttack()
	{
		if (CurrentRoom == null)
		{
			return null;
		}
		ICombatTarget combatTarget = null;
		combatTarget = _droneManager.GetAvailableLures().FirstOrDefault((ICombatTarget x) => !x.IsDead && !IsTargetHidden(x) && TargetIsInSameRoom(x));
		if (CurrentRoom != null && combatTarget == null)
		{
			IEnumerable<AdjacentRoomData> enumerable = from x in NavigationHelper.GetAllAdjacentRoomData(CurrentRoom)
				where AdjacentRoomCanBeEntered(x)
				select x;
			foreach (AdjacentRoomData item in enumerable)
			{
				Room adjacentRoom;
				if (item.Room1 == CurrentRoom)
				{
					adjacentRoom = item.Room2;
				}
				else
				{
					adjacentRoom = item.Room1;
				}
				combatTarget = _droneManager.GetAvailableLures().FirstOrDefault((ICombatTarget x) => !x.IsDead && !IsTargetHidden(x) && x.CurrentRoom == adjacentRoom);
				if (combatTarget != null)
				{
					break;
				}
			}
		}
		MonoBehaviour monoBehaviour = combatTarget as MonoBehaviour;
		if (monoBehaviour != null && monoBehaviour.gameObject == null)
		{
			Debug.LogWarning("Selected a bad Lure, gameObject is null - " + combatTarget);
			combatTarget = null;
		}
		return combatTarget;
	}

	protected virtual ICombatTarget GetLocalProbeToAttack()
	{
		ICombatTarget combatTarget = null;
		combatTarget = _droneManager.GetAvailableProbes().FirstOrDefault((ICombatTarget x) => !x.IsDead && !IsTargetHidden(x) && TargetIsInSameRoom(x));
		MonoBehaviour monoBehaviour = combatTarget as MonoBehaviour;
		if (monoBehaviour != null && monoBehaviour.gameObject == null)
		{
			Debug.LogWarning("Selected a bad Probe, gameObject is null - " + combatTarget);
			combatTarget = null;
		}
		return combatTarget;
	}

	protected virtual ICombatTarget GetLocalSensorToAttack()
	{
		return null;
	}

	public bool AdjacentRoomCanBeEntered(AdjacentRoomData adjacentRoomData)
	{
		if (adjacentRoomData.ConnectingDoor != null)
		{
			return adjacentRoomData.ConnectingDoor.state == DoorState.Open && !ShouldAvoidRoom((!(adjacentRoomData.Room1 != CurrentRoom)) ? adjacentRoomData.Room2 : adjacentRoomData.Room1);
		}
		return false;
	}

	public virtual void NavigateToRoomMainWaypoint(Room room)
	{
		Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(room);
		_brain.ForceNavigateToWaypoint(mainRoomWaypoint);
	}

	public bool ShouldLeaveCurrentRoom()
	{
		if (CurrentRoom == null)
		{
			return false;
		}
		return ShouldAvoidRoom(CurrentRoom);
	}

	public bool ShouldAvoidRoom(Room room)
	{
		bool result = false;
		int count = _droneManager.dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			Drone drone = _droneManager.dronesList[i];
			if (!drone.IsDead && drone.CurrentRoom == room && !HasBehavior(EnemyAiBehaviors.ImmuneToSonic) && drone.IsSonicPulseActive())
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public void AttackTarget(ICombatTarget target)
	{
		bool cheatMode = GlobalSettings.cheatMode;
		AttackTarget(target, AttackDamage, cheatMode);
	}

	public void AttackTarget(ICombatTarget target, bool showProjectile)
	{
		AttackTarget(target, AttackDamage, showProjectile);
	}

	public void AttackTarget(ICombatTarget target, float damage, bool showProjectile)
	{
		if (showProjectile)
		{
			_projectileManager.LaunchProjectile(ProjectileType, this, target, damage, AttackDamageType, true);
		}
		else
		{
			target.TakeDamage(damage, AttackDamageType, this);
		}
	}

	public virtual void Stun(float durationMin, float durationMax)
	{
		if (!IsDead)
		{
			StunPosition = Position;
			if (StunMtl != null)
			{
				thisMat = StunMtl;
				thisMat.color = StunColor;
			}
		}
	}

	public void ClearStun()
	{
		TimeStunned = 0f;
		IsStunned = false;
		if (!IsDead && startMtl != null)
		{
			thisMat = startMtl;
			thisMat.color = startColor;
		}
	}

	public virtual void TakeDamage(float damage, DamageType type, ICombatTarget attacker)
	{
		if (IsDead)
		{
			return;
		}
		float num = AdjustDamage(damage, type);
		ApplyDamageAsThreat(num, attacker);
		_currentHitpoints -= num;
		if (_currentHitpoints <= 0f)
		{
			_currentHitpoints = 0f;
			_isDead = true;
			IsStunned = false;
			thisMat = DeathMtl;
			if (_brain == null || _brain.animator == null)
			{
				SwitchToDeadModel();
			}
			if (uiOverlay != null)
			{
				isOverlayFadingOut = false;
				isOverlayFadingOutOnDeath = true;
				timerOverlayFadeOut = OverlayFadeOutTimeOnDeath;
				overlayIsFadingColor = OverlayTintColor;
			}
		}
		OnDamageTaken(num, attacker);
	}

	protected void SwitchToDeadModel()
	{
		if (droneViewDeadModel != null)
		{
			droneViewDeadModel.SetActive(true);
			if (droneViewModel != null)
			{
				droneViewModel.SetActive(false);
			}
		}
		if (droneViewDeadModelDefaultTransform != null)
		{
			if (!droneViewDeadModelDefaultTransformMat)
			{
				droneViewDeadModelDefaultTransformMat = droneViewDeadModelDefaultTransform.GetComponent<Renderer>().sharedMaterial;
			}
			droneViewDeadModelDefaultTransformMat = DeathModelMtl;
		}
		else if (droneViewModelDefaultTransform != null)
		{
			if (!droneViewModelDefaultTransformMat)
			{
				droneViewModelDefaultTransformMat = droneViewModelDefaultTransform.GetComponent<Renderer>().material;
			}
			droneViewModelDefaultTransformMat = DeathModelMtl;
		}
		if (thisMat != null)
		{
			thisMat.color = DeadColor;
		}
	}

	public void ApplyDamageAsThreat(float damage, ICombatTarget attacker)
	{
		if (attacker != null)
		{
			if (!_attackerThreat.ContainsKey(attacker))
			{
				_attackerThreat[attacker] = damage;
				return;
			}
			Dictionary<ICombatTarget, float> attackerThreat;
			Dictionary<ICombatTarget, float> dictionary = (attackerThreat = _attackerThreat);
			ICombatTarget key2;
			ICombatTarget key = (key2 = attacker);
			float num = attackerThreat[key2];
			dictionary[key] = num + damage;
		}
	}

	public void MissedTarget(ICombatTarget target, float attackDamage)
	{
	}

	public virtual void Vaporize()
	{
		EnemyManager.Instance.ForgetEnemy(this);
		GetComponent<Renderer>().enabled = false;
		base.gameObject.GetComponent<Renderer>().enabled = false;
		base.gameObject.SetActive(false);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void RegisterDirectionalHit(Vector3 force)
	{
	}

	protected virtual void OnDamageTaken(float damage, ICombatTarget attacker)
	{
	}

	protected virtual float AdjustDamage(float damage, DamageType type)
	{
		return damage;
	}

	protected virtual void OnAttackingTarget(ICombatTarget target)
	{
	}

	public override string ToString()
	{
		return "Enemy " + _id;
	}

	public void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode != CameraMode.Schematic)
		{
			return;
		}
		if (GlobalSettings.OverrideCameraVisibility)
		{
			EnableRenderer(true);
			return;
		}
		EnableRenderer(false);
		if (uiOverlay != null)
		{
			uiOverlay.GetComponent<Renderer>().enabled = false;
		}
	}

	public virtual void SetPosition(Vector3 position)
	{
		base.transform.position = position;
	}

	public void AttemptScan()
	{
		if (GlobalSettings.cameraMode != CameraMode.Drone || (TestOnlyUntilFirstScan && uiOverlay.GetComponent<Renderer>().enabled) || !ShowOverlay)
		{
			return;
		}
		Drone currentDrone = _droneManager.CurrentDrone;
		bool flag = false;
		if (!IsDead && currentDrone != null)
		{
			float num = Vector3.Distance(currentDrone.transform.position, base.transform.position);
			if (num < DistToShowOverlay && TargetIsInSameRoom(currentDrone))
			{
				flag = true;
			}
			else
			{
				List<Drone> dronesList = _droneManager.dronesList;
				int count = dronesList.Count;
				for (int i = 0; i < count; i++)
				{
					Drone drone = dronesList[i];
					if (drone.IsVisible && currentDrone.DroneNumber != drone.DroneNumber && !drone.IsDead)
					{
						num = Vector3.Distance(drone.transform.position, base.transform.position);
						if (num < DistToShowOverlay && TargetIsInSameRoom(drone))
						{
							flag = true;
							break;
						}
					}
				}
			}
		}
		if (!(uiOverlay != null))
		{
			return;
		}
		if (flag)
		{
			if (!disableOverlay)
			{
				uiOverlay.GetComponent<Renderer>().enabled = true;
				uiOverlayMat.color = OverlayTintColor;
				overlayWasShowing = true;
			}
		}
		else if (overlayWasShowing)
		{
			FadeOutOverlay();
		}
	}

	protected void FadeOutOverlay()
	{
		bool flag = true;
		if (isOverlayFadingOut)
		{
			timerOverlayFadeOut -= Time.deltaTime;
			if (timerOverlayFadeOut <= 0f)
			{
				isOverlayFadingOut = false;
				overlayWasShowing = false;
			}
			else
			{
				flag = false;
			}
			overlayIsFadingColor.a = timerOverlayFadeOut / OverlayFadeOutTime;
			uiOverlayMat.color = overlayIsFadingColor;
		}
		else if (uiOverlay.GetComponent<Renderer>().enabled)
		{
			flag = false;
			isOverlayFadingOut = true;
			timerOverlayFadeOut = OverlayFadeOutTime;
			overlayIsFadingColor = OverlayTintColor;
		}
		if (flag)
		{
			uiOverlay.GetComponent<Renderer>().enabled = false;
			flag = false;
		}
	}

	public void NotifyCollision(ICombatTarget collidingItem)
	{
		if (_brain != null)
		{
			_brain.NotifyCollision(collidingItem);
		}
	}

	public bool HasBehavior(EnemyAiBehaviors behavior)
	{
		return (Behaviors & behavior) == behavior;
	}

	public bool LineOfSightThroughDoor(Vector3 targetPosition)
	{
		bool result = false;
		if (CurrentRoom == null)
		{
			return false;
		}
		float num = Vector3.Distance(targetPosition, Position);
		if (num <= 3f)
		{
			Ray ray = new Ray(Position, targetPosition - Position);
			for (int i = 0; i < CurrentRoom.corridors.Count; i++)
			{
				Corridor corridor = CurrentRoom.corridors[i];
				RaycastHit hitInfo;
				if (!(corridor == null) && corridor.door.state != DoorState.Closed && corridor.GetComponent<Collider>().Raycast(ray, out hitInfo, 4f))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}
}
