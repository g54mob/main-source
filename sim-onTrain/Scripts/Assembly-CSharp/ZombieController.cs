using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using Mirror;
using Mirror.RemoteCalls;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;

[RequireComponent(typeof(RVOController))]
[RequireComponent(typeof(Seeker))]
public class ZombieController : NetworkBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEmergeRoutine_003Ed__165 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 groundPosition;

		public ZombieController _003C_003E4__this;

		private Vector3 _003CendPos_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private float _003Celapsed_003E5__4;

		private float _003Cduration_003E5__5;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CEmergeRoutine_003Ed__165(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			ZombieController zombieController = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CendPos_003E5__2 = groundPosition;
				_003CendPos_003E5__2.y += zombieController.GetGroundedPivotOffset();
				_003CstartPos_003E5__3 = _003CendPos_003E5__2 + Vector3.down * zombieController.emergeDepth;
				_003Celapsed_003E5__4 = 0f;
				_003Cduration_003E5__5 = Mathf.Max(0.01f, zombieController.emergeDuration);
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003Celapsed_003E5__4 < _003Cduration_003E5__5)
			{
				float t = zombieController.emergeCurve.Evaluate(_003Celapsed_003E5__4 / _003Cduration_003E5__5);
				zombieController.transform.position = Vector3.LerpUnclamped(_003CstartPos_003E5__3, _003CendPos_003E5__2, t);
				_003Celapsed_003E5__4 += Time.deltaTime;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			zombieController.transform.position = _003CendPos_003E5__2;
			zombieController.NetworknetworkPosition = _003CendPos_003E5__2;
			if (zombieController.characterController != null)
			{
				zombieController.characterController.enabled = true;
			}
			if (zombieController.controller != null)
			{
				zombieController.controller.enabled = true;
			}
			if (zombieController.seeker != null)
			{
				zombieController.seeker.enabled = true;
			}
			zombieController.NetworkisEmerging = false;
			zombieController.ApplyEmergeAnimator(value: false);
			zombieController.emergeCoroutine = null;
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
			throw new NotSupportedException();
		}
	}

	[Header("Components")]
	public CharacterController characterController;

	public Animator Animator;

	[Header("Movement")]
	public float RotationSpeed = 1f;

	public float gravity = -20f;

	[Header("Health System")]
	public float maxHp = 150f;

	[SyncVar(hook = "OnHealthChangedHook")]
	public float currentHp = 150f;

	[SyncVar(hook = "OnDeathStateChangedHook")]
	public bool isDeath;

	public bool isPlayingHitAnimation;

	public bool isStopped;

	[Header("Movement Settings")]
	public ZombieWalkType walkType = ZombieWalkType.Sprint;

	public float walkSpeed = 2f;

	public float runSpeed = 2f;

	public float sprintSpeed = 6f;

	public float idleSpeed;

	public float wanderSpeed = 1.5f;

	public float speedTransitionSpeed = 2f;

	[Header("RVO Settings")]
	public float repathRate = 0.5f;

	public float moveNextDist = 1f;

	public float slowdownDistance = 2f;

	[Header("AI Settings")]
	public float triggerRadius = 10f;

	public float followRadius = 15f;

	public float randomTargetInterval = 5f;

	public float randomMoveRadius = 20f;

	public float runTriggerDistance = 12f;

	[Header("Performance Settings")]
	public float playerSearchInterval = 0.5f;

	public float animationUpdateInterval = 0.1f;

	[Header("Attack Settings")]
	public float attackRange = 1.5f;

	public float moveAttackRange = 2.5f;

	public float attackCooldown = 2f;

	public float walkStartDelay = 0.5f;

	[Tooltip("Standing attack başlamadan önce oyuncuya bu açıdan fazla ters bakıyorsa önce döner, sonra vurur")]
	public float standingAttackFacingAngle = 40f;

	[Header("Player Proximity Slowdown")]
	[Tooltip("Bu mesafeden yakın olunca yavaşlamaya başlar")]
	public float proximitySlowdownDistance = 3f;

	[Tooltip("Oyuncuya bu mesafeden fazla yaklaşmaz")]
	public float minDistanceToPlayer = 1.2f;

	[Tooltip("Minimum mesafedeyken hız çarpanı (0-1)")]
	[Range(0f, 1f)]
	public float minProximitySpeedMultiplier = 0.3f;

	[Header("Prop Attack Settings")]
	public BoxCollider propCheckCollider;

	public LayerMask validProps = -1;

	public float propCheckInterval = 0.3f;

	public float propAttackDamage = 10f;

	[Tooltip("Player yokken prop aramak için etraf tarama yarıçapı")]
	public float propSearchRadius = 10f;

	[Tooltip("Oyuncuyu görmezken prop/trene saldırmak için bu mesafe içinde en az bir oyuncu bulunmalı")]
	public float propAttackPlayerRange = 50f;

	private float lastPropRangeLogTime;

	[Tooltip("Saldırı kararı öncesi oyuncuya görüş hattı kontrolü için kullanılır")]
	public float losCheckHeight = 1f;

	[Header("Train Jump Settings")]
	public LayerMask trainLayer = -1;

	public float jumpAngle = 45f;

	public float minJumpHeight = 2f;

	public float maxJumpHeight = 4f;

	public float jumpCooldown = 2f;

	public float rayCheckInterval = 0.5f;

	public float minJumpDistance = 1.5f;

	public float maxJumpDistance = 8f;

	public float trajectoryMultiplier = 1.1f;

	[Header("Hit Reaction Stop Durations")]
	public float headHitStopDuration = 1.8f;

	public float spineHitStopDuration = 1.8f;

	public float rightArmHitStopDuration = 2.3f;

	public float leftArmHitStopDuration = 2.3f;

	public float rightLegHitStopDuration = 2.3f;

	public float leftLegHitStopDuration = 2.3f;

	[Header("Hit Reaction Cooldown")]
	public float hitReactionCooldown = 10f;

	[Header("Hit Sound Cooldown")]
	public float hitSoundCooldown = 0.5f;

	private float lastHitSoundTime = -999f;

	[Header("Death Settings")]
	[Tooltip("Açık: ölünce fizik ragdoll (ZombieHitReactor). Kapalı: eski sistem — direkt death animasyonu.")]
	public bool useRagdollDeath;

	public float deathAnimationDuration = 3f;

	public float despawnDelay = 5f;

	private static List<TSPlayerController> allPlayers;

	private static Action<TSPlayerController> onPlayerAdded;

	private static Action<TSPlayerController> onPlayerRemoved;

	private Transform currentTarget;

	private RVOController controller;

	private Seeker seeker;

	private ZombieAnimationController animController;

	private ZombieHitReactor hitReactor;

	private float nextRepath;

	private bool canSearchPath = true;

	private Path path;

	private List<Vector3> vectorPath;

	private int wp;

	private float lastRandomTargetTime;

	private float lastPlayerSearch;

	private float lastAnimationUpdate;

	private float lastAttackTime;

	private float lastJumpTime;

	private float lastTrainCheck;

	private float lastPropCheck;

	private float lastHitReactionTime = -999f;

	[HideInInspector]
	public Vector3 lastHitDirection = Vector3.back;

	private Vector3 randomTargetPosition;

	private Vector3 currentPathTarget;

	private float currentAnimationSpeed;

	private float currentSpeed;

	private float hitSpeedMultiplier = 1f;

	private float verticalVelocity;

	public bool isAttacking;

	private float attackStartTime;

	public bool isRunning;

	public bool isJumping;

	private Vector3 jumpVelocity = Vector3.zero;

	private Vector3 jumpDirection = Vector3.zero;

	private float currentJumpForwardSpeed = 5f;

	private Vector3 smoothedDirection = Vector3.zero;

	private Vector3 lastTargetPosition;

	private float targetMovementCheckTimer;

	private bool isTargetMoving;

	private const float TARGET_MOVEMENT_CHECK_INTERVAL = 0.1f;

	private const float TARGET_MOVEMENT_THRESHOLD = 0.05f;

	[SyncVar]
	private bool networkIsJumping;

	[SyncVar]
	private Vector3 networkPosition;

	[SyncVar]
	private Quaternion networkRotation;

	[SyncVar(hook = "OnTrainStateChanged")]
	private bool networkIsOnTrain;

	[SyncVar(hook = "OnConnectedTrainChanged")]
	private uint connectedTrainNetId;

	[SyncVar(hook = "OnConnectedWagonChanged")]
	private int connectedWagonId = -1;

	[SyncVar]
	private Vector3 trainLocalPosition;

	[SyncVar]
	private Quaternion trainLocalRotation;

	private Transform connectedParentTransform;

	private float lastPositionSync;

	private const float POSITION_SYNC_RATE = 0.05f;

	private const float POSITION_LERP_SPEED = 15f;

	public List<ZombieBodyHitter> bodyHitters = new List<ZombieBodyHitter>();

	public Action<float, float> OnHealthChanged;

	public Action OnDeath;

	[Header("Drop Settings")]
	public List<ZombieDropData> dropData = new List<ZombieDropData>();

	public float spawnRadius = 0.3f;

	[Header("Emerge Animation")]
	[Tooltip("Spawner çağırdığında zombi yerden çıkma animasyonu yapsın mı (per-spawn override edilebilir)")]
	public bool emergeOnSpawn = true;

	[Tooltip("Yerin altında ne kadar derinden çıkmaya başlasın (metre)")]
	public float emergeDepth = 1.8f;

	[Tooltip("Yerden çıkma süresi (saniye)")]
	public float emergeDuration = 1.5f;

	[Tooltip("Yükselme eğrisi - başta hızlı sona doğru yavaşlama klasik 'çıkış' hissi verir")]
	public AnimationCurve emergeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	[Tooltip("Spawn anında çalacak toz/kir VFX prefab'ı (boş bırakılabilir)")]
	public GameObject emergeVFXPrefab;

	[Tooltip("VFX'in ground pozisyonuna göre lokal offset'i")]
	public Vector3 emergeVFXOffset = Vector3.zero;

	[Tooltip("VFX'in otomatik destroy süresi (saniye, 0 = destroy etme)")]
	public float emergeVFXLifetime = 4f;

	[Tooltip("Animator'da bool varsa adı (boş bırakılabilir). True/false olarak set edilir.")]
	public string emergeAnimatorBool = "IsEmerging";

	[SyncVar(hook = "OnEmergingChanged")]
	public bool isEmerging;

	private Coroutine emergeCoroutine;

	[Header("Test/Debug")]
	[Tooltip("True ise oyuncuyu hedeflemez, prop saldırmaz - sadece wander eder. Test için.")]
	public bool peacefulMode;

	private float lastPropRepathTime;

	private const float PROP_REPATH_INTERVAL = 3f;

	private static readonly Collider[] propOverlapResults;

	private float lastTrainPropCheck;

	private const float TRAIN_PROP_CHECK_INTERVAL = 2f;

	private float lastDismountTime = -999f;

	private const float DISMOUNT_REBOARD_COOLDOWN = 15f;

	private static readonly Collider[] trainPropOverlapResults;

	private Transform trainTarget;

	private static readonly Collider[] trainSearchResults;

	private Coroutine hitStopCoroutineRef;

	public Transform CurrentTarget => currentTarget;

	public PropBase CurrentPropTarget { get; private set; }

	public static IReadOnlyList<TSPlayerController> AllRegisteredPlayers => allPlayers;

	public float HealthPercentage
	{
		get
		{
			if (!(maxHp > 0f))
			{
				return 0f;
			}
			return Mathf.Clamp01(currentHp / maxHp);
		}
	}

	public bool IsAlive
	{
		get
		{
			if (!isDeath)
			{
				return currentHp > 0f;
			}
			return false;
		}
	}

	public float NetworkcurrentHp
	{
		get
		{
			return currentHp;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentHp, 1uL, OnHealthChangedHook);
		}
	}

	public bool NetworkisDeath
	{
		get
		{
			return isDeath;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isDeath, 2uL, OnDeathStateChangedHook);
		}
	}

	public bool NetworknetworkIsJumping
	{
		get
		{
			return networkIsJumping;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkIsJumping, 4uL, null);
		}
	}

	public Vector3 NetworknetworkPosition
	{
		get
		{
			return networkPosition;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkPosition, 8uL, null);
		}
	}

	public Quaternion NetworknetworkRotation
	{
		get
		{
			return networkRotation;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkRotation, 16uL, null);
		}
	}

	public bool NetworknetworkIsOnTrain
	{
		get
		{
			return networkIsOnTrain;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref networkIsOnTrain, 32uL, OnTrainStateChanged);
		}
	}

	public uint NetworkconnectedTrainNetId
	{
		get
		{
			return connectedTrainNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref connectedTrainNetId, 64uL, OnConnectedTrainChanged);
		}
	}

	public int NetworkconnectedWagonId
	{
		get
		{
			return connectedWagonId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref connectedWagonId, 128uL, OnConnectedWagonChanged);
		}
	}

	public Vector3 NetworktrainLocalPosition
	{
		get
		{
			return trainLocalPosition;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref trainLocalPosition, 256uL, null);
		}
	}

	public Quaternion NetworktrainLocalRotation
	{
		get
		{
			return trainLocalRotation;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref trainLocalRotation, 512uL, null);
		}
	}

	public bool NetworkisEmerging
	{
		get
		{
			return isEmerging;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isEmerging, 1024uL, OnEmergingChanged);
		}
	}

	public static void RegisterPlayer(TSPlayerController player)
	{
		if (!allPlayers.Contains(player))
		{
			allPlayers.Add(player);
			onPlayerAdded?.Invoke(player);
		}
	}

	public static void UnregisterPlayer(TSPlayerController player)
	{
		if (allPlayers.Remove(player))
		{
			onPlayerRemoved?.Invoke(player);
		}
	}

	private void OnHealthChangedHook(float oldHealth, float newHealth)
	{
		NetworkcurrentHp = newHealth;
		OnHealthChanged?.Invoke(currentHp, maxHp);
		if (currentHp <= 0f && !isDeath && base.isServer)
		{
			NetworkisDeath = true;
		}
	}

	private void OnDeathStateChangedHook(bool oldState, bool newState)
	{
		NetworkisDeath = newState;
		if (isDeath && !oldState)
		{
			HandleDeathLocal();
		}
	}

	private void OnTrainStateChanged(bool oldValue, bool newValue)
	{
		if (!base.isServer)
		{
			if (newValue && connectedTrainNetId != 0)
			{
				UpdateTrainParentFromNetwork();
				base.transform.localPosition = trainLocalPosition;
				base.transform.localRotation = trainLocalRotation;
			}
			else if (!newValue)
			{
				base.transform.SetParent(null, worldPositionStays: true);
				connectedParentTransform = null;
			}
		}
	}

	private void OnConnectedTrainChanged(uint oldValue, uint newValue)
	{
		if (!base.isServer && networkIsOnTrain && newValue != 0)
		{
			UpdateTrainParentFromNetwork();
			base.transform.localPosition = trainLocalPosition;
			base.transform.localRotation = trainLocalRotation;
		}
	}

	private void OnConnectedWagonChanged(int oldValue, int newValue)
	{
		if (!base.isServer && networkIsOnTrain)
		{
			UpdateTrainParentFromNetwork();
			base.transform.localPosition = trainLocalPosition;
			base.transform.localRotation = trainLocalRotation;
		}
	}

	private void OnEmergingChanged(bool oldValue, bool newValue)
	{
		ApplyEmergeAnimator(newValue);
	}

	private void UpdateTrainParentFromNetwork()
	{
		if (connectedTrainNetId == 0 || !NetworkClient.spawned.TryGetValue(connectedTrainNetId, out var value))
		{
			return;
		}
		TrainController component = value.GetComponent<TrainController>();
		if (component == null)
		{
			return;
		}
		Transform parent = component.transform;
		if (connectedWagonId >= 0)
		{
			WagonController wagonByID = component.GetWagonByID(connectedWagonId);
			if (wagonByID != null)
			{
				parent = wagonByID.transform;
			}
		}
		base.transform.SetParent(parent, worldPositionStays: true);
		connectedParentTransform = parent;
	}

	private TrainController GetTrainByNetId(uint netId)
	{
		if (netId == 0)
		{
			return null;
		}
		if (NetworkClient.spawned.TryGetValue(netId, out var value))
		{
			return value.GetComponent<TrainController>();
		}
		return null;
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		NetworkcurrentHp = maxHp;
		NetworkisDeath = false;
		NetworknetworkPosition = base.transform.position;
		NetworknetworkRotation = base.transform.rotation;
	}

	private void OnEnable()
	{
		if (Animator == null)
		{
			Animator = GetComponentInChildren<Animator>();
		}
		bodyHitters = new List<ZombieBodyHitter>(GetComponentsInChildren<ZombieBodyHitter>());
		animController = GetComponentInChildren<ZombieAnimationController>();
		hitReactor = GetComponent<ZombieHitReactor>();
		controller = GetComponent<RVOController>();
		seeker = GetComponent<Seeker>();
		onPlayerAdded = (Action<TSPlayerController>)Delegate.Combine(onPlayerAdded, new Action<TSPlayerController>(OnPlayerAdded));
		onPlayerRemoved = (Action<TSPlayerController>)Delegate.Combine(onPlayerRemoved, new Action<TSPlayerController>(OnPlayerRemoved));
	}

	private void OnDisable()
	{
		onPlayerAdded = (Action<TSPlayerController>)Delegate.Remove(onPlayerAdded, new Action<TSPlayerController>(OnPlayerAdded));
		onPlayerRemoved = (Action<TSPlayerController>)Delegate.Remove(onPlayerRemoved, new Action<TSPlayerController>(OnPlayerRemoved));
	}

	private void Start()
	{
		ZombieDamageDealer component = GetComponent<ZombieDamageDealer>();
		if (component != null)
		{
			component.propLayers = validProps;
		}
		else
		{
			UnityEngine.Debug.LogWarning("[ZombieController] " + base.gameObject.name + ": ZombieDamageDealer component bulunamadı!");
		}
		if (base.isServer)
		{
			ZombieSpawner.RegisterZombie(this);
		}
		SetRandomTarget();
		StartCoroutine(OptimizedUpdateLoop());
	}

	private void Update()
	{
		if (isDeath)
		{
			return;
		}
		if (!base.isServer)
		{
			UpdateClientPosition();
			return;
		}
		if (isEmerging)
		{
			SyncPosition();
			return;
		}
		if (base.transform.position.y < -100f)
		{
			Kill();
			return;
		}
		if (isAttacking && Time.time - attackStartTime > 4f)
		{
			UnityEngine.Debug.LogWarning($"[ZOMBIE_STATE] isAttacking TIMEOUT! {Time.time - attackStartTime:F1}s - force resetting");
			isAttacking = false;
		}
		if (Time.frameCount % 30 == 0)
		{
			if (currentTarget != null)
			{
				Vector3.Distance(base.transform.position, currentTarget.position);
			}
			if (controller != null)
			{
				_ = controller.velocity.magnitude;
			}
			bool flag = animController != null && animController.IsMoveAttacking;
			if (isAttacking)
			{
				_ = !flag;
			}
			else
				_ = 0;
		}
		if (!isStopped && !isPlayingHitAnimation)
		{
			ApplyGravity();
			if (networkIsOnTrain && !isJumping && Time.time - lastTrainCheck >= rayCheckInterval)
			{
				lastTrainCheck = Time.time;
				CheckIfOnTrain();
			}
			CheckIfNeedToJumpToTrain();
			UpdateMovementState();
			UpdateCurrentSpeed();
			if (Time.time >= nextRepath && canSearchPath)
			{
				RecalculatePath();
			}
			UpdateRVOMovement();
			SyncPosition();
		}
	}

	private void SyncPosition()
	{
		if (!(Time.time - lastPositionSync < 0.05f))
		{
			lastPositionSync = Time.time;
			if (networkIsOnTrain && connectedParentTransform != null)
			{
				NetworktrainLocalPosition = base.transform.localPosition;
				NetworktrainLocalRotation = base.transform.localRotation;
			}
			else
			{
				NetworknetworkPosition = base.transform.position;
				NetworknetworkRotation = base.transform.rotation;
			}
		}
	}

	private void UpdateClientPosition()
	{
		if (networkIsOnTrain && connectedParentTransform != null)
		{
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, trainLocalPosition, Time.deltaTime * 15f);
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, trainLocalRotation, Time.deltaTime * 15f);
		}
		else
		{
			base.transform.position = Vector3.Lerp(base.transform.position, networkPosition, Time.deltaTime * 15f);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, networkRotation, Time.deltaTime * 15f);
		}
	}

	private IEnumerator OptimizedUpdateLoop()
	{
		while (!isDeath && base.isServer)
		{
			if (isEmerging)
			{
				yield return new WaitForSeconds(0.1f);
				continue;
			}
			if (Time.time - lastPlayerSearch >= playerSearchInterval)
			{
				FindNearestPlayer();
				if (currentTarget == null && !networkIsOnTrain)
				{
					CheckForNearbyTrain();
				}
				lastPlayerSearch = Time.time;
			}
			if (Time.time - lastAnimationUpdate >= animationUpdateInterval)
			{
				UpdateAnimations();
				lastAnimationUpdate = Time.time;
			}
			if (Time.time - lastRandomTargetTime >= randomTargetInterval && currentTarget == null)
			{
				SetRandomTarget();
			}
			if (Time.time - lastPropCheck >= propCheckInterval)
			{
				CheckAndAttackProps();
			}
			if (currentTarget == null && Time.time - lastTrainPropCheck >= 2f)
			{
				lastTrainPropCheck = Time.time;
				if (!CheckNearbyProps() && networkIsOnTrain)
				{
					trainTarget = null;
					lastDismountTime = Time.time;
					DismountFromTrain();
					SetRandomTarget();
					ForceRecalculatePath();
				}
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	[Server]
	public void PrepareEmergeUnderground(Vector3 groundPosition)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ZombieController::PrepareEmergeUnderground(UnityEngine.Vector3)' called when server was not active");
			return;
		}
		if (characterController != null)
		{
			characterController.enabled = false;
		}
		if (controller != null)
		{
			controller.enabled = false;
		}
		if (seeker != null)
		{
			seeker.enabled = false;
		}
		Vector3 vector = groundPosition;
		vector.y += GetGroundedPivotOffset();
		Vector3 vector2 = vector + Vector3.down * emergeDepth;
		base.transform.position = vector2;
		NetworknetworkPosition = vector2;
		NetworkisEmerging = true;
		ApplyEmergeAnimator(value: true);
	}

	[Server]
	public void StartEmerge(Vector3 groundPosition)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ZombieController::StartEmerge(UnityEngine.Vector3)' called when server was not active");
			return;
		}
		if (emergeCoroutine != null)
		{
			StopCoroutine(emergeCoroutine);
		}
		if (!isEmerging)
		{
			PrepareEmergeUnderground(groundPosition);
		}
		RpcPlayEmergeVFX(groundPosition);
		emergeCoroutine = StartCoroutine(EmergeRoutine(groundPosition));
	}

	private void ApplyEmergeAnimator(bool value)
	{
		if (Animator == null)
		{
			Animator = GetComponentInChildren<Animator>();
		}
		if (!(Animator == null) && !string.IsNullOrEmpty(emergeAnimatorBool))
		{
			Animator.SetBool(emergeAnimatorBool, value);
		}
	}

	[IteratorStateMachine(typeof(_003CEmergeRoutine_003Ed__165))]
	[Server]
	private IEnumerator EmergeRoutine(Vector3 groundPosition)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator ZombieController::EmergeRoutine(UnityEngine.Vector3)' called when server was not active");
			return null;
		}
		return new _003CEmergeRoutine_003Ed__165(0)
		{
			_003C_003E4__this = this,
			groundPosition = groundPosition
		};
	}

	private float GetGroundedPivotOffset()
	{
		if (characterController == null)
		{
			return 0f;
		}
		return 0f - (characterController.center.y - characterController.height * 0.5f) + characterController.skinWidth;
	}

	[ClientRpc]
	private void RpcPlayEmergeVFX(Vector3 groundPosition)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(groundPosition);
		SendRPCInternal("System.Void ZombieController::RpcPlayEmergeVFX(UnityEngine.Vector3)", 1233653462, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ApplyGravity()
	{
		if (characterController == null || !characterController.enabled)
		{
			return;
		}
		if (isJumping)
		{
			jumpVelocity.y += gravity * Time.deltaTime;
			Vector3 motion = jumpDirection * currentJumpForwardSpeed * Time.deltaTime;
			motion.y = jumpVelocity.y * Time.deltaTime;
			characterController.Move(motion);
			if (characterController.isGrounded && jumpVelocity.y < 0f)
			{
				isJumping = false;
				NetworknetworkIsJumping = false;
				jumpVelocity = Vector3.zero;
				jumpDirection = Vector3.zero;
				verticalVelocity = 0f;
				if (controller != null)
				{
					controller.locked = false;
				}
				CheckIfOnTrain();
			}
		}
		else
		{
			if (characterController.isGrounded)
			{
				verticalVelocity = -2f;
			}
			else
			{
				verticalVelocity += gravity * Time.deltaTime;
			}
			Vector3 motion2 = new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime;
			characterController.Move(motion2);
		}
	}

	private void RecalculatePath()
	{
		if (!isDeath && !isJumping && !(seeker == null) && !(controller == null))
		{
			canSearchPath = false;
			nextRepath = Time.time + repathRate * (UnityEngine.Random.value + 0.5f);
			Vector3 end = (currentPathTarget = GetCurrentTargetPosition());
			seeker.StartPath(base.transform.position, end, OnPathComplete);
		}
	}

	public void ForceRecalculatePath()
	{
		nextRepath = 0f;
		canSearchPath = true;
		Vector3 vector = GetCurrentTargetPosition() - base.transform.position;
		vector.y = 0f;
		if (vector.sqrMagnitude > 0.01f)
		{
			smoothedDirection = vector.normalized;
		}
	}

	private Vector3 GetCurrentTargetPosition()
	{
		if (currentTarget != null)
		{
			return currentTarget.position;
		}
		if (trainTarget != null)
		{
			return trainTarget.position;
		}
		return randomTargetPosition;
	}

	private void OnPathComplete(Path _p)
	{
		ABPath aBPath = _p as ABPath;
		canSearchPath = true;
		if (path != null)
		{
			path.Release(this);
		}
		path = aBPath;
		aBPath.Claim(this);
		if (aBPath.error)
		{
			UnityEngine.Debug.LogWarning("[ZOMBIE PATH] Path ERROR: " + aBPath.errorLog);
			wp = 0;
			vectorPath = null;
			return;
		}
		Vector3 originalStartPoint = aBPath.originalStartPoint;
		Vector3 position = base.transform.position;
		originalStartPoint.y = position.y;
		float magnitude = (position - originalStartPoint).magnitude;
		wp = 0;
		vectorPath = aBPath.vectorPath;
		if (!(moveNextDist > 0f))
		{
			return;
		}
		for (float num = 0f; num <= magnitude; num += moveNextDist * 0.6f)
		{
			wp--;
			Vector3 vector = originalStartPoint + (position - originalStartPoint) * num;
			Vector3 vector2;
			do
			{
				wp++;
				if (wp >= vectorPath.Count)
				{
					break;
				}
				vector2 = vectorPath[wp];
			}
			while (!(controller.To2D(vector - vector2).sqrMagnitude >= moveNextDist * moveNextDist) && wp != vectorPath.Count - 1 && wp < vectorPath.Count - 1);
		}
	}

	private void UpdateRVOMovement()
	{
		bool flag = animController != null && animController.IsMoveAttacking;
		bool flag2 = isAttacking && !flag;
		if (isDeath || isJumping || controller == null || isStopped || isPlayingHitAnimation || flag2)
		{
			if (controller != null)
			{
				controller.SetTarget(base.transform.position, 0f, 0f);
			}
			return;
		}
		if (flag && currentTarget != null)
		{
			MoveDirectToTarget();
			return;
		}
		Vector3 position = base.transform.position;
		bool flag3 = false;
		if (currentTarget != null && HasLineOfSightToTarget())
		{
			float num = Vector3.Distance(position, currentTarget.position);
			if (num < followRadius * 0.6f)
			{
				Vector3 position2 = currentTarget.position;
				position2.y = position.y;
				float num2 = num;
				Vector3 pos = (position2 - position).normalized * num2 + position;
				float speed = Mathf.Clamp01(num2 / slowdownDistance) * currentSpeed;
				controller.SetTarget(pos, speed, currentSpeed);
				flag3 = true;
			}
		}
		if (!flag3)
		{
			if (vectorPath != null && vectorPath.Count != 0)
			{
				while (wp < vectorPath.Count && ((controller.To2D(position - vectorPath[wp]).sqrMagnitude < moveNextDist * moveNextDist && wp != vectorPath.Count - 1) || wp == 0))
				{
					wp++;
				}
				if (wp >= vectorPath.Count)
				{
					wp = vectorPath.Count - 1;
				}
				Vector3 vector = vectorPath[Mathf.Max(0, wp - 1)];
				Vector3 vector2 = vectorPath[wp];
				float value = VectorMath.LineCircleIntersectionFactor(controller.To2D(base.transform.position), controller.To2D(vector), controller.To2D(vector2), moveNextDist);
				value = Mathf.Clamp01(value);
				Vector3 vector3 = Vector3.Lerp(vector, vector2, value);
				float num3 = controller.To2D(vector3 - position).magnitude + controller.To2D(vector3 - vector2).magnitude;
				for (int i = wp; i < vectorPath.Count - 1; i++)
				{
					num3 += controller.To2D(vectorPath[i + 1] - vectorPath[i]).magnitude;
				}
				Vector3 pos2 = (vector3 - position).normalized * num3 + position;
				float speed2 = Mathf.Clamp01(num3 / slowdownDistance) * currentSpeed;
				controller.SetTarget(pos2, speed2, currentSpeed);
			}
			else
			{
				controller.SetTarget(position, 0f, currentSpeed);
			}
		}
		Vector3 vector4 = controller.CalculateMovementDelta(Time.deltaTime);
		if (vector4.sqrMagnitude > 0.0001f)
		{
			Vector3 normalized = vector4.normalized;
			if (smoothedDirection.sqrMagnitude < 0.01f || Vector3.Dot(smoothedDirection, normalized) < 0.5f)
			{
				smoothedDirection = normalized;
			}
			else
			{
				smoothedDirection = Vector3.Lerp(smoothedDirection, normalized, Time.deltaTime * 12f);
			}
			vector4 = smoothedDirection * vector4.magnitude;
		}
		if (!isAttacking)
		{
			Vector3 vector5 = Vector3.zero;
			if (currentTarget != null)
			{
				Vector3 vector6 = currentTarget.position - base.transform.position;
				vector6.y = 0f;
				vector5 = vector6;
			}
			else if (trainTarget != null && !networkIsOnTrain)
			{
				Vector3 vector7 = trainTarget.position - base.transform.position;
				vector7.y = 0f;
				vector5 = vector7;
			}
			else if (CurrentPropTarget != null)
			{
				Vector3 vector8 = CurrentPropTarget.transform.position - base.transform.position;
				vector8.y = 0f;
				vector5 = vector8;
			}
			else if (Time.deltaTime > 0f && vector4.magnitude / Time.deltaTime > 0.3f)
			{
				vector5 = vector4;
			}
			else if (currentSpeed > 0.1f)
			{
				Vector3 vector9 = randomTargetPosition - base.transform.position;
				vector9.y = 0f;
				if (vector9.sqrMagnitude > 0.25f)
				{
					vector5 = vector9;
				}
			}
			if (vector5.sqrMagnitude > 0.01f)
			{
				Quaternion b = Quaternion.LookRotation(vector5.normalized, Vector3.up);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * RotationSpeed);
			}
		}
		if (characterController != null && characterController.enabled)
		{
			characterController.Move(vector4);
		}
		else
		{
			base.transform.position += vector4;
		}
	}

	private void UpdateMovementState()
	{
		if (isPlayingHitAnimation || isDeath || isJumping)
		{
			return;
		}
		if (currentTarget != null)
		{
			float num = Vector3.Distance(base.transform.position, currentTarget.position);
			UpdateTargetMovementCheck();
			bool flag = num <= attackRange;
			bool flag2 = num <= moveAttackRange && num > attackRange;
			if (!(animController != null) || !animController.IsMoveAttacking)
			{
				if (flag && !isTargetMoving)
				{
					isRunning = false;
				}
				else if (num <= runTriggerDistance)
				{
					isRunning = true;
				}
				else
				{
					isRunning = false;
				}
			}
			if (!isAttacking && Time.time - lastAttackTime >= attackCooldown && HasLineOfSightToTarget())
			{
				Vector3 to = currentTarget.position - base.transform.position;
				to.y = 0f;
				float num2 = ((to.sqrMagnitude > 0.0001f) ? Vector3.Angle(base.transform.forward, to) : 0f);
				if (flag)
				{
					if (num2 <= standingAttackFacingAngle)
					{
						AttackBasedOnTargetMovement(num);
						lastAttackTime = Time.time;
					}
				}
				else if (flag2 && isRunning)
				{
					AttackBasedOnTargetMovement(num);
					lastAttackTime = Time.time;
				}
			}
			if (isAttacking)
			{
				RotateToTarget();
			}
		}
		else
		{
			if (trainTarget != null && networkIsOnTrain)
			{
				trainTarget = null;
			}
			isRunning = trainTarget != null && !networkIsOnTrain;
			lastTargetPosition = Vector3.zero;
			Vector3 vector = ((CurrentPropTarget != null) ? CurrentPropTarget.transform.position : ((!(trainTarget != null) || networkIsOnTrain) ? randomTargetPosition : trainTarget.position));
			Vector3 forward = vector - base.transform.position;
			forward.y = 0f;
			if (forward.sqrMagnitude > 0.25f)
			{
				float num3 = (isAttacking ? (RotationSpeed * 3f) : (RotationSpeed * 2f));
				Quaternion b = Quaternion.LookRotation(forward);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * num3);
			}
		}
	}

	private void UpdateCurrentSpeed()
	{
		float b = GetTargetSpeed() * hitSpeedMultiplier;
		currentSpeed = Mathf.Lerp(currentSpeed, b, Time.deltaTime * speedTransitionSpeed);
	}

	public void ApplySpeedMultiplier(float multiplier, bool instantRestore = false)
	{
		hitSpeedMultiplier = multiplier;
		float num = GetTargetSpeed() * multiplier;
		if (instantRestore)
		{
			currentSpeed = num;
		}
		else if (currentSpeed > num)
		{
			currentSpeed = num;
		}
	}

	public float GetTargetSpeed()
	{
		if (isDeath || isJumping)
		{
			return 0f;
		}
		if (currentTarget != null)
		{
			float num = ((!isRunning) ? walkSpeed : ((walkType != ZombieWalkType.Sprint) ? runSpeed : sprintSpeed));
			float num2 = Vector3.Distance(base.transform.position, currentTarget.position);
			if (num2 <= minDistanceToPlayer)
			{
				num = 0f;
			}
			else if (num2 < proximitySlowdownDistance)
			{
				float t = Mathf.InverseLerp(minDistanceToPlayer, proximitySlowdownDistance, num2);
				float num3 = Mathf.Lerp(0f, 1f, t);
				num *= num3;
			}
			return num;
		}
		if (trainTarget != null && !networkIsOnTrain)
		{
			return runSpeed;
		}
		if (Vector3.Distance(base.transform.position, randomTargetPosition) > 1f)
		{
			return wanderSpeed;
		}
		return idleSpeed;
	}

	private void RotateToTarget()
	{
		if (!(currentTarget == null))
		{
			Vector3 normalized = (currentTarget.position - base.transform.position).normalized;
			normalized.y = 0f;
			if (!(normalized == Vector3.zero) && !(Vector3.Angle(base.transform.forward, normalized) < 10f))
			{
				float num = (isAttacking ? (RotationSpeed * 3f) : RotationSpeed);
				Quaternion b = Quaternion.LookRotation(normalized);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * num);
			}
		}
	}

	private bool HasLineOfSightToTarget()
	{
		if (currentTarget == null)
		{
			return false;
		}
		Vector3 vector = base.transform.position + Vector3.up * losCheckHeight;
		Vector3 vector2 = currentTarget.position + Vector3.up * 1f - vector;
		if (Physics.Raycast(vector, vector2.normalized, vector2.magnitude, validProps))
		{
			return false;
		}
		return true;
	}

	private void UpdateTargetMovementCheck()
	{
		if (currentTarget == null)
		{
			return;
		}
		targetMovementCheckTimer += Time.deltaTime;
		if (targetMovementCheckTimer >= 0.1f)
		{
			Vector3 position = currentTarget.position;
			if (lastTargetPosition != Vector3.zero)
			{
				float num = Vector3.Distance(position, lastTargetPosition);
				isTargetMoving = num >= 0.05f;
			}
			lastTargetPosition = position;
			targetMovementCheckTimer = 0f;
		}
	}

	private void AttackBasedOnTargetMovement(float distanceToTarget)
	{
		if (!isDeath && !isJumping)
		{
			isAttacking = true;
			attackStartTime = Time.time;
			if (animController != null)
			{
				animController.Attack(isTargetMoving);
			}
		}
	}

	private void MoveDirectToTarget()
	{
		if (currentTarget == null || characterController == null)
		{
			return;
		}
		Vector3 vector = currentTarget.position - base.transform.position;
		vector.y = 0f;
		if (!(vector.magnitude <= minDistanceToPlayer))
		{
			vector.Normalize();
			if (vector != Vector3.zero)
			{
				Quaternion b = Quaternion.LookRotation(vector);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * RotationSpeed * 5f);
			}
			if (networkIsOnTrain && connectedParentTransform != null)
			{
				Vector3 vector2 = connectedParentTransform.InverseTransformDirection(vector);
				vector2.y = 0f;
				Vector3 vector3 = vector2 * currentSpeed * Time.deltaTime;
				base.transform.localPosition += vector3;
			}
			else
			{
				Vector3 motion = vector * currentSpeed * Time.deltaTime;
				characterController.Move(motion);
			}
		}
	}

	private float GetNearestPlayerDistance()
	{
		if (allPlayers == null)
		{
			return float.MaxValue;
		}
		float num = float.MaxValue;
		for (int num2 = allPlayers.Count - 1; num2 >= 0; num2--)
		{
			TSPlayerController tSPlayerController = allPlayers[num2];
			if (tSPlayerController == null)
			{
				allPlayers.RemoveAt(num2);
			}
			else if (!tSPlayerController.isDeath)
			{
				float sqrMagnitude = (base.transform.position - tSPlayerController.transform.position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
				}
			}
		}
		if (num != float.MaxValue)
		{
			return Mathf.Sqrt(num);
		}
		return float.MaxValue;
	}

	private void FindNearestPlayer()
	{
		if (isDeath || allPlayers == null)
		{
			return;
		}
		if (peacefulMode)
		{
			currentTarget = null;
			return;
		}
		TSPlayerController tSPlayerController = null;
		float num = float.MaxValue;
		for (int num2 = allPlayers.Count - 1; num2 >= 0; num2--)
		{
			if (allPlayers[num2] == null)
			{
				allPlayers.RemoveAt(num2);
			}
			else if (!allPlayers[num2].isDeath && !allPlayers[num2].spawnProtected)
			{
				TsPlayerNetworkHelper component = allPlayers[num2].GetComponent<TsPlayerNetworkHelper>();
				if (!(component != null) || component.playerGameMode != GameMode.Creative)
				{
					float num3 = Vector3.Distance(base.transform.position, allPlayers[num2].transform.position);
					if (num3 < num)
					{
						num = num3;
						tSPlayerController = allPlayers[num2];
					}
				}
			}
		}
		_ = currentTarget;
		if (tSPlayerController != null)
		{
			if (currentTarget == null && num <= triggerRadius)
			{
				currentTarget = tSPlayerController.transform;
				ForceRecalculatePath();
			}
			else
			{
				if (!(currentTarget != null))
				{
					return;
				}
				TSPlayerController component2 = currentTarget.GetComponent<TSPlayerController>();
				if (component2 != null && component2.isDeath)
				{
					currentTarget = null;
					if (tSPlayerController != null && num <= followRadius)
					{
						currentTarget = tSPlayerController.transform;
						ForceRecalculatePath();
					}
					else
					{
						SetRandomTarget();
					}
					return;
				}
				if (component2 != null && component2.spawnProtected)
				{
					currentTarget = null;
					if (tSPlayerController != null && num <= followRadius)
					{
						currentTarget = tSPlayerController.transform;
						ForceRecalculatePath();
					}
					else
					{
						SetRandomTarget();
					}
					return;
				}
				TsPlayerNetworkHelper component3 = currentTarget.GetComponent<TsPlayerNetworkHelper>();
				if (component3 != null && component3.playerGameMode == GameMode.Creative)
				{
					currentTarget = null;
					if (tSPlayerController != null && num <= followRadius)
					{
						currentTarget = tSPlayerController.transform;
						ForceRecalculatePath();
					}
					else
					{
						SetRandomTarget();
					}
				}
				else if (num > followRadius)
				{
					currentTarget = null;
					SetRandomTarget();
				}
				else if (tSPlayerController.transform != currentTarget && num <= followRadius)
				{
					float num4 = Vector3.Distance(base.transform.position, currentTarget.position);
					if (num < num4)
					{
						currentTarget = tSPlayerController.transform;
						ForceRecalculatePath();
					}
				}
			}
		}
		else if (currentTarget != null)
		{
			currentTarget = null;
			SetRandomTarget();
		}
	}

	private void OnPlayerAdded(TSPlayerController player)
	{
		if (!isDeath && currentTarget == null && !player.spawnProtected)
		{
			TsPlayerNetworkHelper component = player.GetComponent<TsPlayerNetworkHelper>();
			if ((!(component != null) || component.playerGameMode != GameMode.Creative) && Vector3.Distance(base.transform.position, player.transform.position) <= triggerRadius && !player.isDeath)
			{
				currentTarget = player.transform;
				ForceRecalculatePath();
			}
		}
	}

	private void OnPlayerRemoved(TSPlayerController player)
	{
		if (currentTarget == player.transform)
		{
			currentTarget = null;
			FindNearestPlayer();
		}
	}

	private void SetRandomTarget()
	{
		if (!isDeath)
		{
			Vector3 vector = UnityEngine.Random.insideUnitSphere * randomMoveRadius;
			vector.y = 0f;
			randomTargetPosition = base.transform.position + vector;
			lastRandomTargetTime = Time.time;
		}
	}

	private void UpdateAnimations()
	{
		if (!(animController == null) && !isDeath && !isJumping)
		{
			float b = 0f;
			if (currentTarget != null)
			{
				b = (isRunning ? ((walkType == ZombieWalkType.Sprint) ? 1f : 0.66f) : ((!isAttacking) ? 0.33f : 0f));
			}
			else if (((controller != null) ? controller.velocity.magnitude : 0f) > 0.1f)
			{
				b = (isRunning ? 0.66f : 0.33f);
			}
			currentAnimationSpeed = Mathf.Lerp(currentAnimationSpeed, b, Time.deltaTime * 5f);
			animController.SetWalkSpeed(currentAnimationSpeed);
		}
	}

	private void AttackTarget(float distanceToTarget)
	{
		if (!isDeath && !isJumping)
		{
			isAttacking = true;
			attackStartTime = Time.time;
			if (animController != null)
			{
				animController.Attack(isRunning);
			}
		}
	}

	public void OnAttackComplete()
	{
	}

	public void OnMoveAttackComplete()
	{
		isAttacking = false;
		CurrentPropTarget = null;
	}

	public void OnAttackStateCompleted()
	{
		isAttacking = false;
		CurrentPropTarget = null;
		if (currentTarget == null)
		{
			currentSpeed = 0f;
			currentAnimationSpeed = 0f;
			if (networkIsOnTrain)
			{
				lastTrainPropCheck = -999f;
			}
		}
	}

	public void OnAnimationAttackStateCompleted()
	{
		OnAttackStateCompleted();
	}

	public void OnPropDestroyed()
	{
		CurrentPropTarget = null;
		isAttacking = false;
		ForceRecalculatePath();
		if (networkIsOnTrain && currentTarget == null)
		{
			lastTrainPropCheck = -999f;
		}
	}

	private void CheckAndAttackProps()
	{
		if (isDeath || isJumping || isAttacking || peacefulMode || propCheckCollider == null)
		{
			return;
		}
		lastPropCheck = Time.time;
		int num = Physics.OverlapBoxNonAlloc(propCheckCollider.transform.TransformPoint(propCheckCollider.center), Vector3.Scale(propCheckCollider.size * 0.5f, propCheckCollider.transform.lossyScale), orientation: propCheckCollider.transform.rotation, results: propOverlapResults, mask: validProps);
		PropBase propBase = null;
		float num2 = float.MaxValue;
		for (int i = 0; i < num; i++)
		{
			Collider collider = propOverlapResults[i];
			if (collider.gameObject == base.gameObject || collider == propCheckCollider || !IsValidPropTarget(collider))
			{
				continue;
			}
			if (!collider.TryGetComponent<PropBase>(out var component))
			{
				component = collider.GetComponentInParent<PropBase>();
			}
			if (!(component == null))
			{
				float num3 = Vector3.Distance(base.transform.position, collider.ClosestPoint(base.transform.position));
				if (num3 < num2)
				{
					num2 = num3;
					propBase = component;
				}
			}
		}
		if (propBase == null)
		{
			return;
		}
		if (currentTarget == null)
		{
			float nearestPlayerDistance = GetNearestPlayerDistance();
			bool flag = nearestPlayerDistance <= propAttackPlayerRange;
			if (Time.time - lastPropRangeLogTime >= 1f)
			{
				lastPropRangeLogTime = Time.time;
				string text = ((propBase != null) ? propBase.name : "null");
				UnityEngine.Debug.Log($"[PROP_RANGE] {base.name}: en yakın oyuncu {nearestPlayerDistance:F1}m / limit {propAttackPlayerRange:F0}m → " + (flag ? ("SALDIRIR (hedef: " + text + ")") : "BLOKE (oyuncu çok uzak, trene vurmaz)"), this);
			}
			if (flag && Time.time - lastAttackTime >= attackCooldown)
			{
				AttackProp(propBase);
				lastAttackTime = Time.time;
			}
		}
		else if (Time.time - lastPropRepathTime >= 3f)
		{
			lastPropRepathTime = Time.time;
			ForceRecalculatePath();
		}
		else if (Time.time - lastAttackTime >= attackCooldown)
		{
			AttackProp(propBase);
			lastAttackTime = Time.time;
		}
	}

	private void CheckForNearbyTrain()
	{
		if (currentTarget != null || networkIsOnTrain || isDeath || Time.time - lastDismountTime < 15f)
		{
			return;
		}
		int num = Physics.OverlapSphereNonAlloc(base.transform.position, triggerRadius, trainSearchResults, trainLayer);
		if (num == 0)
		{
			trainTarget = null;
			return;
		}
		TrainController trainController = null;
		float num2 = float.MaxValue;
		for (int i = 0; i < num; i++)
		{
			TrainController componentInParent = trainSearchResults[i].GetComponentInParent<TrainController>();
			if (!(componentInParent == null))
			{
				float num3 = Vector3.Distance(base.transform.position, componentInParent.transform.position);
				if (num3 < num2)
				{
					num2 = num3;
					trainController = componentInParent;
				}
			}
		}
		if (trainController == null)
		{
			trainTarget = null;
		}
		else if (trainTarget != trainController.transform)
		{
			trainTarget = trainController.transform;
			lastRandomTargetTime = Time.time;
			ForceRecalculatePath();
		}
	}

	private bool CheckNearbyProps()
	{
		if (currentTarget != null)
		{
			return true;
		}
		if (isDeath || isJumping || isAttacking)
		{
			return true;
		}
		if (peacefulMode)
		{
			return true;
		}
		int num = Physics.OverlapSphereNonAlloc(base.transform.position, propSearchRadius, trainPropOverlapResults, validProps);
		PropBase propBase = null;
		float num2 = float.MaxValue;
		for (int i = 0; i < num; i++)
		{
			Collider collider = trainPropOverlapResults[i];
			if (collider.gameObject == base.gameObject || !IsValidPropTarget(collider))
			{
				continue;
			}
			if (!collider.TryGetComponent<PropBase>(out var component))
			{
				component = collider.GetComponentInParent<PropBase>();
			}
			if (!(component == null))
			{
				float num3 = Vector3.Distance(base.transform.position, collider.ClosestPoint(base.transform.position));
				if (num3 < num2)
				{
					num2 = num3;
					propBase = component;
				}
			}
		}
		if (propBase == null)
		{
			return false;
		}
		randomTargetPosition = propBase.transform.position;
		lastRandomTargetTime = Time.time;
		ForceRecalculatePath();
		return true;
	}

	private bool IsValidPropTarget(Collider col)
	{
		if (!col.TryGetComponent<GrabbableObject>(out var component))
		{
			component = col.GetComponentInParent<GrabbableObject>();
		}
		if (component != null)
		{
			if (component.grabbableType == GrabbableType.Ground)
			{
				return false;
			}
			if (component.isNotCollideWithOtherProps)
			{
				return false;
			}
			if (component.isBedOrCarpet)
			{
				return false;
			}
		}
		if (!col.TryGetComponent<PropBase>(out var component2))
		{
			component2 = col.GetComponentInParent<PropBase>();
		}
		if (component2 == null)
		{
			return false;
		}
		if (component2.propType == PropType.Ground)
		{
			return false;
		}
		return true;
	}

	private void AttackProp(PropBase prop)
	{
		if (!isDeath && !isJumping)
		{
			isAttacking = true;
			attackStartTime = Time.time;
			CurrentPropTarget = prop;
			if (animController != null)
			{
				animController.Attack();
			}
			Vector3 normalized = (prop.transform.position - base.transform.position).normalized;
			normalized.y = 0f;
			if (normalized != Vector3.zero)
			{
				Quaternion b = Quaternion.LookRotation(normalized);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * RotationSpeed);
			}
		}
	}

	public float GetHitStopDuration(BodyHitPart hitPart)
	{
		return hitPart switch
		{
			BodyHitPart.Head => headHitStopDuration, 
			BodyHitPart.Spine => spineHitStopDuration, 
			BodyHitPart.RightArm => rightArmHitStopDuration, 
			BodyHitPart.LeftArm => leftArmHitStopDuration, 
			BodyHitPart.RightLeg => rightLegHitStopDuration, 
			BodyHitPart.LeftLeg => leftLegHitStopDuration, 
			_ => 1f, 
		};
	}

	public bool CanPlayHitReaction()
	{
		return Time.time - lastHitReactionTime >= hitReactionCooldown;
	}

	public void SetLastHitReactionTime()
	{
		lastHitReactionTime = Time.time;
	}

	public bool IsChasingPlayer()
	{
		if (currentTarget != null)
		{
			return isRunning;
		}
		return false;
	}

	public float GetDistanceToTarget()
	{
		if (currentTarget == null)
		{
			return float.MaxValue;
		}
		return Vector3.Distance(base.transform.position, currentTarget.position);
	}

	public void GetDamage(float damage, Vector3 playerPos, Vector3 playerForward, Vector3 hitPosition, Quaternion quaternion, int damageType, int hitPart = 1)
	{
		if (base.isServer)
		{
			GetDamageServer(damage, playerPos, playerForward, hitPosition, quaternion, damageType, hitPart);
		}
		else
		{
			CmdGetDamage(damage, playerPos, playerForward, hitPosition, quaternion, damageType, hitPart);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdGetDamage(float damage, Vector3 playerPos, Vector3 playerForward, Vector3 hitPosition, Quaternion quaternion, int damageType, int hitPart)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(damage);
		writer.WriteVector3(playerPos);
		writer.WriteVector3(playerForward);
		writer.WriteVector3(hitPosition);
		writer.WriteQuaternion(quaternion);
		writer.WriteInt(damageType);
		writer.WriteInt(hitPart);
		SendCommandInternal("System.Void ZombieController::CmdGetDamage(System.Single,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,System.Int32,System.Int32)", 1148938015, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void GetDamageServer(float damage, Vector3 playerPos, Vector3 playerForward, Vector3 hitPosition, Quaternion quaternion, int damageType, int hitPart = 1)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ZombieController::GetDamageServer(System.Single,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,System.Int32,System.Int32)' called when server was not active");
		}
		else if (!isDeath && !(currentHp <= 0f))
		{
			NetworkcurrentHp = Mathf.Max(0f, currentHp - damage);
			if (Time.time - lastHitSoundTime >= hitSoundCooldown)
			{
				lastHitSoundTime = Time.time;
				float delay = ((damageType == 3) ? 0f : 0.22f);
				RpcPlayHitSound(delay);
			}
			if (currentHp <= 0f && !isDeath)
			{
				NetworkisDeath = true;
				RpcHandleDeath();
			}
			else
			{
				RpcApplyKnockback(playerForward, hitPart);
			}
		}
	}

	[ClientRpc]
	private void RpcHandleDeath()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ZombieController::RpcHandleDeath()", -1133270066, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcPlayHitSound(float delay)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(delay);
		SendRPCInternal("System.Void ZombieController::RpcPlayHitSound(System.Single)", 1154315931, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcApplyKnockback(Vector3 playerForward, int hitPart)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(playerForward);
		writer.WriteInt(hitPart);
		SendRPCInternal("System.Void ZombieController::RpcApplyKnockback(UnityEngine.Vector3,System.Int32)", -247476469, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void HandleDeathLocal()
	{
		if (!isDeath)
		{
			return;
		}
		if (controller != null)
		{
			controller.locked = true;
		}
		StopAllCoroutines();
		isRunning = false;
		isAttacking = false;
		isPlayingHitAnimation = false;
		isStopped = true;
		isJumping = false;
		currentTarget = null;
		if (useRagdollDeath && hitReactor != null)
		{
			if (Animator != null)
			{
				Animator.enabled = false;
			}
			hitReactor.EnableFullRagdoll(lastHitDirection);
		}
		else
		{
			PlayDeathAnimation();
		}
		SetCollidersToIgnoreRaycast();
		OnDeath?.Invoke();
		if (base.isServer)
		{
			StartCoroutine(DelayedDropLoot(2f));
			StartCoroutine(HandleDeathCleanup());
		}
	}

	private IEnumerator HandleDeathCleanup()
	{
		yield return new WaitForSeconds(deathAnimationDuration + despawnDelay);
		DespawnZombie();
	}

	private void SetCollidersToIgnoreRaycast()
	{
		int num = LayerMask.NameToLayer("Ignore Raycast");
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = num;
		}
		if (hitReactor != null)
		{
			hitReactor.SetRagdollCollidersToLayer(num);
		}
	}

	private void DespawnZombie()
	{
		if (base.isServer)
		{
			NetworkServer.Destroy(base.gameObject);
		}
	}

	private void ApplyKnockback(Vector3 playerForward, int hitPart = 1)
	{
		Vector3 vector = (-playerForward).normalized * 1f;
		base.transform.DOMove(base.transform.position - vector * 0.35f, 0.07f);
		if (hitReactor != null)
		{
			hitReactor.TriggerProceduralReact(playerForward, (BodyHitPart)hitPart);
		}
	}

	public void StartHitStop(float duration)
	{
		if (hitStopCoroutineRef != null)
		{
			StopCoroutine(hitStopCoroutineRef);
		}
		hitStopCoroutineRef = StartCoroutine(HitStopCoroutine(duration));
	}

	private IEnumerator HitStopCoroutine(float duration)
	{
		isPlayingHitAnimation = true;
		isStopped = true;
		if (controller != null)
		{
			controller.SetTarget(base.transform.position, 0f, 0f);
		}
		yield return new WaitForSeconds(duration);
		isPlayingHitAnimation = false;
		isStopped = false;
		hitStopCoroutineRef = null;
	}

	public void PlayDeathAnimation()
	{
		if (animController != null)
		{
			animController?.Death();
		}
	}

	[Server]
	public void Heal(float healAmount)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ZombieController::Heal(System.Single)' called when server was not active");
		}
		else if (!isDeath)
		{
			NetworkcurrentHp = Mathf.Min(maxHp, currentHp + healAmount);
		}
	}

	[Server]
	public void Kill()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ZombieController::Kill()' called when server was not active");
		}
		else if (!isDeath)
		{
			NetworkcurrentHp = 0f;
			NetworkisDeath = true;
			ZombieSpawner.UnregisterZombie(this);
			RpcHandleDeath();
		}
	}

	private void OnDestroy()
	{
		ZombieSpawner.UnregisterZombie(this);
	}

	private IEnumerator DelayedDropLoot(float delay)
	{
		yield return new WaitForSeconds(delay);
		DropLoot();
	}

	[Server]
	private void DropLoot()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ZombieController::DropLoot()' called when server was not active");
		}
		else
		{
			if (dropData == null || dropData.Count == 0 || NetworkSceneObjectSpawner.Instance == null)
			{
				return;
			}
			List<LootableItemEntry> list = new List<LootableItemEntry>();
			foreach (ZombieDropData dropDatum in dropData)
			{
				if (dropDatum != null && !(dropDatum.itemData == null) && UnityEngine.Random.Range(0f, 100f) <= dropDatum.dropChance)
				{
					LootableItemEntry item = new LootableItemEntry
					{
						collectableData = dropDatum.itemData,
						count = dropDatum.itemCount
					};
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				Vector3 vector = new Vector3(UnityEngine.Random.Range(0f - spawnRadius, spawnRadius), 1.5f, UnityEngine.Random.Range(0f - spawnRadius, spawnRadius));
				Vector3 spawnPoint = base.transform.position + vector;
				NetworkSceneObjectSpawner.Instance.SpawnZombieDropItem(spawnPoint, list);
			}
		}
	}

	[Server]
	private void DismountFromTrain()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void ZombieController::DismountFromTrain()' called when server was not active");
		}
		else if (networkIsOnTrain)
		{
			base.transform.SetParent(null, worldPositionStays: true);
			connectedParentTransform = null;
			NetworknetworkIsOnTrain = false;
			NetworkconnectedTrainNetId = 0u;
			NetworkconnectedWagonId = -1;
		}
	}

	private bool CheckIfOnTrain()
	{
		if (!base.isServer)
		{
			return networkIsOnTrain;
		}
		if (characterController == null)
		{
			return false;
		}
		if (!characterController.isGrounded)
		{
			if (networkIsOnTrain && !Physics.Raycast(base.transform.position + Vector3.up * 0.5f, maxDistance: characterController.height * 0.5f + 1.5f, direction: Vector3.down, layerMask: trainLayer))
			{
				DismountFromTrain();
			}
			return networkIsOnTrain;
		}
		if (Physics.Raycast(base.transform.position + Vector3.up * 0.5f, maxDistance: characterController.height * 0.5f + 1f, direction: Vector3.down, hitInfo: out var hitInfo, layerMask: trainLayer))
		{
			TrainController componentInParent = hitInfo.transform.GetComponentInParent<TrainController>();
			if (componentInParent != null)
			{
				NetworkIdentity component = componentInParent.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					uint num = component.netId;
					WagonController componentInParent2 = hitInfo.transform.GetComponentInParent<WagonController>();
					int num2 = ((componentInParent2 != null) ? componentInParent2.wagonID : (-1));
					if (!networkIsOnTrain || connectedTrainNetId != num || connectedWagonId != num2)
					{
						Transform parent = ((componentInParent2 != null) ? componentInParent2.transform : componentInParent.transform);
						base.transform.SetParent(parent, worldPositionStays: true);
						connectedParentTransform = parent;
						NetworkconnectedTrainNetId = num;
						NetworkconnectedWagonId = num2;
						NetworknetworkIsOnTrain = true;
						NetworktrainLocalPosition = base.transform.localPosition;
						NetworktrainLocalRotation = base.transform.localRotation;
					}
				}
				return true;
			}
		}
		if (networkIsOnTrain)
		{
			DismountFromTrain();
		}
		return false;
	}

	private void CheckIfNeedToJumpToTrain()
	{
		if (isJumping || isDeath || isAttacking)
		{
			return;
		}
		TSPlayerController component;
		bool num = currentTarget != null && currentTarget.TryGetComponent<TSPlayerController>(out component) && component.isOnTrain;
		bool flag = trainTarget != null && currentTarget == null && !networkIsOnTrain;
		if ((!num && !flag) || Time.time - lastTrainCheck < rayCheckInterval)
		{
			return;
		}
		lastTrainCheck = Time.time;
		if (!CheckIfOnTrain() && !(Time.time - lastJumpTime < jumpCooldown) && CheckTrainBetweenTargetAndMe(out var trainJumpPosition))
		{
			float num2 = Vector3.Distance(base.transform.position, trainJumpPosition);
			if (num2 >= minJumpDistance && num2 <= maxJumpDistance)
			{
				StartCoroutine(JumpToTrain());
			}
		}
	}

	private bool CheckTrainBetweenTargetAndMe(out Vector3 trainJumpPosition)
	{
		trainJumpPosition = Vector3.zero;
		Transform transform = ((currentTarget != null) ? currentTarget : trainTarget);
		if (transform == null)
		{
			return false;
		}
		Vector3 vector = base.transform.position + Vector3.up * 10f;
		Vector3 position = transform.position;
		_ = (position - vector).normalized;
		int value = Mathf.CeilToInt(Vector3.Distance(vector, position) / 0.5f);
		value = Mathf.Clamp(value, 5, 20);
		for (int i = 0; i < value; i++)
		{
			float t = (float)i / (float)(value - 1);
			if (Physics.Raycast(Vector3.Lerp(vector, position, t), Vector3.down, out var hitInfo, 20f, trainLayer) && hitInfo.transform.GetComponentInParent<TrainController>() != null)
			{
				trainJumpPosition = hitInfo.point;
				trainJumpPosition.y += ((characterController != null) ? (characterController.height * 0.5f + 0.2f) : 1.2f);
				return true;
			}
		}
		return false;
	}

	private IEnumerator JumpToTrain()
	{
		if (!isDeath && !isJumping && !(characterController == null))
		{
			isJumping = true;
			NetworknetworkIsJumping = true;
			lastJumpTime = Time.time;
			if (controller != null)
			{
				controller.locked = true;
			}
			if (animController != null)
			{
				animController.Jump();
			}
			Vector3 vector = FindJumpTargetPosition();
			Vector3 position = base.transform.position;
			Vector3 vector2 = vector - position;
			float heightDifference = vector.y - position.y;
			vector2.y = 0f;
			float num = vector2.magnitude;
			if (num < 0.1f)
			{
				vector2 = base.transform.forward;
				num = 2f;
			}
			vector2.Normalize();
			if (vector2 != Vector3.zero)
			{
				base.transform.rotation = Quaternion.LookRotation(vector2);
				smoothedDirection = vector2;
			}
			CalculateJumpVelocity(num, heightDifference, vector2);
			yield return null;
		}
	}

	private void CalculateJumpVelocity(float distance, float heightDifference, Vector3 direction)
	{
		float num = Mathf.InverseLerp(minJumpDistance, maxJumpDistance, distance);
		float num2 = Mathf.Lerp(minJumpHeight, maxJumpHeight, num);
		float num3 = distance * trajectoryMultiplier;
		float num4 = Mathf.Abs(gravity);
		float num5 = jumpAngle * (MathF.PI / 180f);
		float num6 = Mathf.Sqrt(num3 * num4 / Mathf.Sin(2f * num5));
		if (float.IsNaN(num6) || float.IsInfinity(num6))
		{
			num6 = Mathf.Sqrt(2f * num4 * num2);
		}
		num6 = Mathf.Max(num6, Mathf.Sqrt(2f * num4 * num2));
		float num7 = num6 * Mathf.Cos(num5);
		float num8 = num6 * Mathf.Sin(num5);
		if (num < 0.3f)
		{
			num8 *= 1.2f;
			num7 *= 0.8f;
		}
		else if (num > 0.7f)
		{
			num8 *= 1.15f;
			num7 *= 1.1f;
		}
		jumpDirection = direction;
		currentJumpForwardSpeed = num7;
		jumpVelocity = new Vector3(0f, num8, 0f);
	}

	private Vector3 FindJumpTargetPosition()
	{
		Transform transform = ((currentTarget != null) ? currentTarget : trainTarget);
		if (transform == null)
		{
			return base.transform.position + base.transform.forward * 3f;
		}
		Vector3 vector = base.transform.position + Vector3.up * 10f;
		Vector3 position = transform.position;
		_ = (position - vector).normalized;
		int value = Mathf.CeilToInt(Vector3.Distance(vector, position) / 0.5f);
		value = Mathf.Clamp(value, 5, 20);
		for (int i = 0; i < value; i++)
		{
			float t = (float)i / (float)(value - 1);
			if (Physics.Raycast(Vector3.Lerp(vector, position, t), Vector3.down, out var hitInfo, 20f, trainLayer) && hitInfo.transform.GetComponentInParent<TrainController>() != null)
			{
				Vector3 point = hitInfo.point;
				point.y += ((characterController != null) ? (characterController.height * 0.5f + 0.2f) : 1.2f);
				return point;
			}
		}
		return base.transform.position + base.transform.forward * 3f;
	}

	static ZombieController()
	{
		allPlayers = new List<TSPlayerController>();
		propOverlapResults = new Collider[16];
		trainPropOverlapResults = new Collider[16];
		trainSearchResults = new Collider[8];
		RemoteProcedureCalls.RegisterCommand(typeof(ZombieController), "System.Void ZombieController::CmdGetDamage(System.Single,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,System.Int32,System.Int32)", InvokeUserCode_CmdGetDamage__Single__Vector3__Vector3__Vector3__Quaternion__Int32__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ZombieController), "System.Void ZombieController::RpcPlayEmergeVFX(UnityEngine.Vector3)", InvokeUserCode_RpcPlayEmergeVFX__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(ZombieController), "System.Void ZombieController::RpcHandleDeath()", InvokeUserCode_RpcHandleDeath);
		RemoteProcedureCalls.RegisterRpc(typeof(ZombieController), "System.Void ZombieController::RpcPlayHitSound(System.Single)", InvokeUserCode_RpcPlayHitSound__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(ZombieController), "System.Void ZombieController::RpcApplyKnockback(UnityEngine.Vector3,System.Int32)", InvokeUserCode_RpcApplyKnockback__Vector3__Int32);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcPlayEmergeVFX__Vector3(Vector3 groundPosition)
	{
		if (!(emergeVFXPrefab == null))
		{
			GameObject obj = UnityEngine.Object.Instantiate(emergeVFXPrefab, groundPosition + emergeVFXOffset, Quaternion.identity);
			if (emergeVFXLifetime > 0f)
			{
				UnityEngine.Object.Destroy(obj, emergeVFXLifetime);
			}
		}
	}

	protected static void InvokeUserCode_RpcPlayEmergeVFX__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcPlayEmergeVFX called on server.");
		}
		else
		{
			((ZombieController)obj).UserCode_RpcPlayEmergeVFX__Vector3(reader.ReadVector3());
		}
	}

	protected void UserCode_CmdGetDamage__Single__Vector3__Vector3__Vector3__Quaternion__Int32__Int32(float damage, Vector3 playerPos, Vector3 playerForward, Vector3 hitPosition, Quaternion quaternion, int damageType, int hitPart)
	{
		GetDamageServer(damage, playerPos, playerForward, hitPosition, quaternion, damageType, hitPart);
	}

	protected static void InvokeUserCode_CmdGetDamage__Single__Vector3__Vector3__Vector3__Quaternion__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdGetDamage called on client.");
		}
		else
		{
			((ZombieController)obj).UserCode_CmdGetDamage__Single__Vector3__Vector3__Vector3__Quaternion__Int32__Int32(reader.ReadFloat(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadInt(), reader.ReadInt());
		}
	}

	protected void UserCode_RpcHandleDeath()
	{
		if (isDeath)
		{
			HandleDeathLocal();
		}
	}

	protected static void InvokeUserCode_RpcHandleDeath(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcHandleDeath called on server.");
		}
		else
		{
			((ZombieController)obj).UserCode_RpcHandleDeath();
		}
	}

	protected void UserCode_RpcPlayHitSound__Single(float delay)
	{
		if (isDeath || !(NetworkSoundPlayer.Instance != null))
		{
			return;
		}
		if (delay <= 0f)
		{
			NetworkSoundPlayer.Instance.PlaySound(GameAudios.ZombieHit, base.transform.position);
			return;
		}
		DOVirtual.DelayedCall(delay, delegate
		{
			NetworkSoundPlayer.Instance.PlaySound(GameAudios.ZombieHit, base.transform.position);
		});
	}

	protected static void InvokeUserCode_RpcPlayHitSound__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcPlayHitSound called on server.");
		}
		else
		{
			((ZombieController)obj).UserCode_RpcPlayHitSound__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_RpcApplyKnockback__Vector3__Int32(Vector3 playerForward, int hitPart)
	{
		if (!isDeath)
		{
			ApplyKnockback(playerForward, hitPart);
		}
	}

	protected static void InvokeUserCode_RpcApplyKnockback__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcApplyKnockback called on server.");
		}
		else
		{
			((ZombieController)obj).UserCode_RpcApplyKnockback__Vector3__Int32(reader.ReadVector3(), reader.ReadInt());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteFloat(currentHp);
			writer.WriteBool(isDeath);
			writer.WriteBool(networkIsJumping);
			writer.WriteVector3(networkPosition);
			writer.WriteQuaternion(networkRotation);
			writer.WriteBool(networkIsOnTrain);
			writer.WriteUInt(connectedTrainNetId);
			writer.WriteInt(connectedWagonId);
			writer.WriteVector3(trainLocalPosition);
			writer.WriteQuaternion(trainLocalRotation);
			writer.WriteBool(isEmerging);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteFloat(currentHp);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(isDeath);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(networkIsJumping);
		}
		if ((base.syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVector3(networkPosition);
		}
		if ((base.syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteQuaternion(networkRotation);
		}
		if ((base.syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteBool(networkIsOnTrain);
		}
		if ((base.syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteUInt(connectedTrainNetId);
		}
		if ((base.syncVarDirtyBits & 0x80L) != 0L)
		{
			writer.WriteInt(connectedWagonId);
		}
		if ((base.syncVarDirtyBits & 0x100L) != 0L)
		{
			writer.WriteVector3(trainLocalPosition);
		}
		if ((base.syncVarDirtyBits & 0x200L) != 0L)
		{
			writer.WriteQuaternion(trainLocalRotation);
		}
		if ((base.syncVarDirtyBits & 0x400L) != 0L)
		{
			writer.WriteBool(isEmerging);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref currentHp, OnHealthChangedHook, reader.ReadFloat());
			GeneratedSyncVarDeserialize(ref isDeath, OnDeathStateChangedHook, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref networkIsJumping, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref networkPosition, null, reader.ReadVector3());
			GeneratedSyncVarDeserialize(ref networkRotation, null, reader.ReadQuaternion());
			GeneratedSyncVarDeserialize(ref networkIsOnTrain, OnTrainStateChanged, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref connectedTrainNetId, OnConnectedTrainChanged, reader.ReadUInt());
			GeneratedSyncVarDeserialize(ref connectedWagonId, OnConnectedWagonChanged, reader.ReadInt());
			GeneratedSyncVarDeserialize(ref trainLocalPosition, null, reader.ReadVector3());
			GeneratedSyncVarDeserialize(ref trainLocalRotation, null, reader.ReadQuaternion());
			GeneratedSyncVarDeserialize(ref isEmerging, OnEmergingChanged, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentHp, OnHealthChangedHook, reader.ReadFloat());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isDeath, OnDeathStateChangedHook, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkIsJumping, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkPosition, null, reader.ReadVector3());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkRotation, null, reader.ReadQuaternion());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref networkIsOnTrain, OnTrainStateChanged, reader.ReadBool());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedTrainNetId, OnConnectedTrainChanged, reader.ReadUInt());
		}
		if ((num & 0x80L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref connectedWagonId, OnConnectedWagonChanged, reader.ReadInt());
		}
		if ((num & 0x100L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref trainLocalPosition, null, reader.ReadVector3());
		}
		if ((num & 0x200L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref trainLocalRotation, null, reader.ReadQuaternion());
		}
		if ((num & 0x400L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isEmerging, OnEmergingChanged, reader.ReadBool());
		}
	}
}
