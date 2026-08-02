using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;

[RequireComponent(typeof(RVOController))]
[RequireComponent(typeof(Seeker))]
public abstract class AnimalBase : NetworkBehaviour, IAnimal
{
	[Range(1f, 100f)]
	public int health = 50;

	[Tooltip("Number of idle animation variations (1-3)")]
	[Range(1f, 3f)]
	public int idleVariationCount = 1;

	[Tooltip("Is this a peaceful animal? (Will flee when attacked instead of fighting back)")]
	public bool isPeaceful = true;

	[Tooltip("Number of different attack animations (1-3)")]
	[Range(1f, 3f)]
	public int attackVariationCount = 1;

	[Tooltip("Damage dealt per attack")]
	[Range(1f, 50f)]
	public int attackDamage = 10;

	[Tooltip("Attack range in meters")]
	[Range(0.5f, 10f)]
	public float attackRange = 2f;

	[Tooltip("Cooldown between attacks in seconds")]
	[Range(0.5f, 10f)]
	public float attackCooldown = 2f;

	[Tooltip("Detection range for enemies")]
	[Range(1f, 20f)]
	public float detectionRange = 5f;

	[Tooltip("Speed when fleeing from danger")]
	[Range(1f, 15f)]
	public float fleeSpeed = 8f;

	[Tooltip("Duration of fleeing behavior in seconds")]
	[Range(3f, 30f)]
	public float fleeDuration = 5f;

	[Tooltip("Distance to run when fleeing")]
	[Range(5f, 30f)]
	public float fleeDistance = 15f;

	public List<AnimalDropData> dropData = new List<AnimalDropData>();

	public float spawnRadius = 0.3f;

	[Header("Detection Layers")]
	[SerializeField]
	protected LayerMask walkingLayer;

	[SerializeField]
	private LayerMask targetLayer;

	[Header("Walk Point Detection")]
	[Range(3f, 10f)]
	public int raycastCount = 5;

	[Range(5f, 30f)]
	public float walkPointSearchRadius = 15f;

	[Range(5f, 50f)]
	public float raycastDistance = 20f;

	[Header("Debug")]
	[SerializeField]
	protected bool showPathDebug;

	protected bool isFleeing;

	private float fleeEndTime;

	private float targetSpeed;

	protected float currentSpeed;

	[Tooltip("How fast the animal accelerates to target speed")]
	[Range(1f, 20f)]
	public float speedAcceleration = 8f;

	private Animator animator;

	protected RVOController rvoController;

	protected Seeker seeker;

	protected CharacterController characterController;

	private Path currentPath;

	private List<Vector3> vectorPath;

	private int currentWaypoint;

	private bool pathPending;

	private bool hasValidPath;

	private Vector3 currentDestination;

	private float verticalVelocity;

	[Header("RVO Settings")]
	[SerializeField]
	protected float repathRate = 0.5f;

	[SerializeField]
	protected float moveNextDist = 1f;

	[SerializeField]
	protected float slowdownDistance = 2f;

	[SerializeField]
	protected float rotationSpeed = 5f;

	[Tooltip("0 = sharp instant turn, higher = wider arc turn")]
	[Range(0f, 2f)]
	[SerializeField]
	protected float arcTurnStrength = 1.5f;

	[SerializeField]
	protected float animalGravity = -20f;

	private float nextRepathTime;

	private bool canSearchPath = true;

	protected AnimalState state;

	[SyncVar]
	protected int currentHealth;

	[SyncVar]
	public bool isDead;

	private bool dieProcessStarted;

	protected Transform currentTarget;

	private float lastAttackTime;

	[SyncVar(hook = "OnSyncedAnimSpeedChanged")]
	private float syncedAnimSpeed;

	private static readonly int SpeedHash;

	private static readonly int IsAttackingHash;

	private static readonly int IsAngryHash;

	private static readonly int IsDeadHash;

	private static readonly int HitHash;

	private static readonly int Idle1Hash;

	private static readonly int Idle2Hash;

	private static readonly int Idle3Hash;

	private static readonly int Attack1Hash;

	private static readonly int Attack2Hash;

	private static readonly int Attack3Hash;

	[Header("Path Validation")]
	[Tooltip("Check interval for obstacles along the path")]
	public float pathCheckInterval = 2f;

	[Tooltip("Sphere radius for obstacle detection along the path")]
	[Range(0.3f, 3f)]
	public float pathObstacleRadius = 0.8f;

	public Animator Animator
	{
		get
		{
			if (!(animator == null))
			{
				return animator;
			}
			return animator = GetComponent<Animator>();
		}
	}

	public int CurrentHealth => currentHealth;

	public int NetworkcurrentHealth
	{
		get
		{
			return currentHealth;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentHealth, 1uL, null);
		}
	}

	public bool NetworkisDead
	{
		get
		{
			return isDead;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isDead, 2uL, null);
		}
	}

	public float NetworksyncedAnimSpeed
	{
		get
		{
			return syncedAnimSpeed;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncedAnimSpeed, 4uL, OnSyncedAnimSpeedChanged);
		}
	}

	private void OnSyncedAnimSpeedChanged(float oldVal, float newVal)
	{
		if (!base.isServer && Animator != null)
		{
			Animator.SetFloat(SpeedHash, newVal);
		}
	}

	protected virtual void Start()
	{
		NetworkcurrentHealth = health;
		rvoController = GetComponent<RVOController>();
		seeker = GetComponent<Seeker>();
		characterController = GetComponent<CharacterController>();
		StartCoroutine(EnablePathfindingAfterDelay());
		if (Animator != null)
		{
			Animator.applyRootMotion = false;
		}
		SetRandomIdleVariation();
		StopMoving();
	}

	private IEnumerator EnablePathfindingAfterDelay()
	{
		canSearchPath = false;
		while (AstarPath.active == null || AstarPath.active.isScanning)
		{
			yield return null;
		}
		yield return new WaitForSeconds(0.5f);
		canSearchPath = true;
	}

	protected virtual void Update()
	{
		if (!isDead && currentHealth > 0 && base.isServer)
		{
			UpdateSpeed();
			ApplyGravity();
			if (Time.time >= nextRepathTime && canSearchPath && !pathPending && currentSpeed > 0.01f)
			{
				RecalculatePath();
			}
			UpdateRVOMovement();
			UpdateFleeing();
			if (!isFleeing && !isPeaceful && state != AnimalState.Attacking && currentHealth > 0)
			{
				DetectThreats();
			}
		}
	}

	private void UpdateSpeed()
	{
		if (Mathf.Abs(currentSpeed - targetSpeed) > 0.01f)
		{
			currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, speedAcceleration * Time.deltaTime);
		}
	}

	private void ApplyGravity()
	{
		if (!(characterController == null) && characterController.enabled)
		{
			if (characterController.isGrounded)
			{
				verticalVelocity = -2f;
			}
			else
			{
				verticalVelocity += animalGravity * Time.deltaTime;
			}
			Vector3 motion = new Vector3(0f, verticalVelocity, 0f) * Time.deltaTime;
			characterController.Move(motion);
		}
	}

	private void RecalculatePath()
	{
		if (!isDead && !(seeker == null) && !(rvoController == null))
		{
			pathPending = true;
			nextRepathTime = Time.time + repathRate * (Random.value + 0.5f);
			seeker.StartPath(base.transform.position, currentDestination, OnPathComplete);
		}
	}

	private void OnPathComplete(Path p)
	{
		pathPending = false;
		ABPath aBPath = p as ABPath;
		if (currentPath != null)
		{
			currentPath.Release(this);
		}
		currentPath = p;
		p.Claim(this);
		if (p.error)
		{
			currentWaypoint = 0;
			vectorPath = null;
			hasValidPath = false;
			return;
		}
		hasValidPath = true;
		vectorPath = aBPath.vectorPath;
		Vector3 originalStartPoint = aBPath.originalStartPoint;
		Vector3 position = base.transform.position;
		originalStartPoint.y = position.y;
		float magnitude = (position - originalStartPoint).magnitude;
		currentWaypoint = 0;
		if (!(moveNextDist > 0f))
		{
			return;
		}
		for (float num = 0f; num <= magnitude; num += moveNextDist * 0.6f)
		{
			currentWaypoint--;
			Vector3 vector = originalStartPoint + (position - originalStartPoint) * num;
			Vector3 vector2;
			do
			{
				currentWaypoint++;
				if (currentWaypoint >= vectorPath.Count)
				{
					break;
				}
				vector2 = vectorPath[currentWaypoint];
			}
			while (!(rvoController.To2D(vector - vector2).sqrMagnitude >= moveNextDist * moveNextDist) && currentWaypoint != vectorPath.Count - 1 && currentWaypoint < vectorPath.Count - 1);
		}
	}

	private void UpdateRVOMovement()
	{
		if (isDead || rvoController == null || currentSpeed <= 0.01f)
		{
			if (rvoController != null)
			{
				rvoController.SetTarget(base.transform.position, 0f, 0f);
			}
			return;
		}
		Vector3 position = base.transform.position;
		if (vectorPath != null && vectorPath.Count != 0)
		{
			while (currentWaypoint < vectorPath.Count && ((rvoController.To2D(position - vectorPath[currentWaypoint]).sqrMagnitude < moveNextDist * moveNextDist && currentWaypoint != vectorPath.Count - 1) || currentWaypoint == 0))
			{
				currentWaypoint++;
			}
			if (currentWaypoint >= vectorPath.Count)
			{
				currentWaypoint = vectorPath.Count - 1;
			}
			Vector3 vector = vectorPath[Mathf.Max(0, currentWaypoint - 1)];
			Vector3 vector2 = vectorPath[currentWaypoint];
			float value = VectorMath.LineCircleIntersectionFactor(rvoController.To2D(base.transform.position), rvoController.To2D(vector), rvoController.To2D(vector2), moveNextDist);
			value = Mathf.Clamp01(value);
			Vector3 vector3 = Vector3.Lerp(vector, vector2, value);
			float num = rvoController.To2D(vector3 - position).magnitude + rvoController.To2D(vector3 - vector2).magnitude;
			for (int i = currentWaypoint; i < vectorPath.Count - 1; i++)
			{
				num += rvoController.To2D(vectorPath[i + 1] - vectorPath[i]).magnitude;
			}
			Vector3 pos = (vector3 - position).normalized * num + position;
			float speed = Mathf.Clamp01(num / slowdownDistance) * currentSpeed;
			rvoController.SetTarget(pos, speed, currentSpeed);
		}
		else
		{
			rvoController.SetTarget(position, 0f, currentSpeed);
		}
		Vector3 vector4 = rvoController.CalculateMovementDelta(Time.deltaTime);
		float magnitude = vector4.magnitude;
		if (Time.deltaTime > 0f && magnitude / Time.deltaTime > 0.1f)
		{
			Quaternion rotation = base.transform.rotation;
			Quaternion b = Quaternion.LookRotation(vector4, Vector3.up);
			base.transform.rotation = Quaternion.Slerp(rotation, b, Time.deltaTime * rotationSpeed);
		}
		float b2 = Mathf.Clamp01((Vector3.Dot(base.transform.forward, vector4.normalized) + 1f) * 0.5f);
		Vector3 vector5 = Vector3.Lerp(base.transform.forward * magnitude, t: Mathf.Lerp(1f, b2, arcTurnStrength), b: vector4);
		if (characterController != null && characterController.enabled)
		{
			characterController.Move(vector5);
		}
		else
		{
			base.transform.position += vector5;
		}
	}

	protected void SetDestination(Vector3 destination)
	{
		currentDestination = destination;
		if (seeker != null && canSearchPath)
		{
			pathPending = true;
			seeker.StartPath(base.transform.position, destination, OnPathComplete);
		}
		nextRepathTime = Time.time + repathRate;
	}

	protected void SetSpeed(float speed)
	{
		targetSpeed = speed;
		currentSpeed = speed;
	}

	protected void StopMoving()
	{
		currentDestination = base.transform.position;
		targetSpeed = 0f;
		currentSpeed = 0f;
		vectorPath = null;
		hasValidPath = false;
		if (rvoController != null)
		{
			rvoController.SetTarget(base.transform.position, 0f, 0f);
		}
	}

	protected bool HasReachedDestination()
	{
		if (vectorPath == null || vectorPath.Count == 0)
		{
			return true;
		}
		Vector3 vector = currentDestination - base.transform.position;
		vector.y = 0f;
		return vector.magnitude < moveNextDist;
	}

	protected float RemainingDistance()
	{
		if (vectorPath == null || vectorPath.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		Vector3 position = base.transform.position;
		if (currentWaypoint < vectorPath.Count)
		{
			num += Vector3.Distance(position, vectorPath[currentWaypoint]);
			for (int i = currentWaypoint; i < vectorPath.Count - 1; i++)
			{
				num += Vector3.Distance(vectorPath[i], vectorPath[i + 1]);
			}
		}
		return num;
	}

	protected bool IsPathPending()
	{
		return pathPending;
	}

	protected bool HasValidPath()
	{
		return hasValidPath;
	}

	protected void SetAnimatorSpeed(float speed)
	{
		if (!(Animator == null))
		{
			Animator.SetFloat(SpeedHash, speed);
			if (base.isServer)
			{
				NetworksyncedAnimSpeed = speed;
			}
		}
	}

	public void SetRandomIdleVariation()
	{
		if (!(Animator == null))
		{
			int index = Random.Range(1, idleVariationCount + 1);
			PlayIdleVariation(index);
			if (base.isServer)
			{
				RpcPlayIdleVariation(index);
			}
		}
	}

	private void PlayIdleVariation(int index)
	{
		if (!(Animator == null))
		{
			switch (index)
			{
			case 1:
				Animator.SetTrigger(Idle1Hash);
				break;
			case 2:
				Animator.SetTrigger(Idle2Hash);
				break;
			case 3:
				Animator.SetTrigger(Idle3Hash);
				break;
			}
		}
	}

	[ClientRpc]
	private void RpcPlayIdleVariation(int index)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(index);
		SendRPCInternal("System.Void AnimalBase::RpcPlayIdleVariation(System.Int32)", -679903287, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PlayRandomAttack()
	{
		if (!(Animator == null) && !isPeaceful)
		{
			switch (Random.Range(1, attackVariationCount + 1))
			{
			case 1:
				Animator.SetTrigger(Attack1Hash);
				break;
			case 2:
				Animator.SetTrigger(Attack2Hash);
				break;
			case 3:
				Animator.SetTrigger(Attack3Hash);
				break;
			}
			Animator.SetBool(IsAttackingHash, value: true);
			StartCoroutine(ResetAttackAfterDelay(1f));
		}
	}

	private IEnumerator ResetAttackAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		if (Animator != null)
		{
			Animator.SetBool(IsAttackingHash, value: false);
		}
	}

	public void PlayHitAnimation()
	{
		if (!(Animator == null))
		{
			Animator.SetTrigger(HitHash);
		}
	}

	public void SetAngry(bool isAngry)
	{
		if (!(Animator == null))
		{
			Animator.SetBool(IsAngryHash, isAngry);
		}
	}

	private void DetectThreats()
	{
		Collider[] array = Physics.OverlapSphere(base.transform.position, detectionRange, targetLayer);
		if (array.Length != 0)
		{
			float num = float.MaxValue;
			Transform transform = null;
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				float num2 = Vector3.Distance(base.transform.position, collider.transform.position);
				if (num2 < num)
				{
					num = num2;
					transform = collider.transform;
				}
			}
			if (transform != null && num <= attackRange)
			{
				TryAttack(transform);
			}
			else if (transform != null)
			{
				currentTarget = transform;
				SetAngry(isAngry: true);
			}
		}
		else
		{
			SetAngry(isAngry: false);
			currentTarget = null;
		}
	}

	private void TryAttack(Transform target)
	{
		if (!(Time.time - lastAttackTime < attackCooldown))
		{
			state = AnimalState.Attacking;
			lastAttackTime = Time.time;
			Vector3 normalized = (target.position - base.transform.position).normalized;
			normalized.y = 0f;
			base.transform.rotation = Quaternion.LookRotation(normalized);
			PlayRandomAttack();
			PerformAttack(target);
		}
	}

	protected virtual void PerformAttack(Transform target)
	{
		if (target.GetComponent<TSPlayerController>() != null)
		{
			Debug.Log($"{base.gameObject.name} attacked player for {attackDamage} damage!");
		}
		AnimalBase component = target.GetComponent<AnimalBase>();
		if (component != null && component != this)
		{
			component.TakeDamage(attackDamage);
		}
	}

	public virtual void TakeDamage(int damage, Vector3 attackerPosition)
	{
		if (!base.isServer)
		{
			CmdTakeDamage(damage, attackerPosition);
		}
		else
		{
			ServerApplyDamage(damage, attackerPosition);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTakeDamage(int damage, Vector3 attackerPosition)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteInt(damage);
		writer.WriteVector3(attackerPosition);
		SendCommandInternal("System.Void AnimalBase::CmdTakeDamage(System.Int32,UnityEngine.Vector3)", -108333660, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerApplyDamage(int damage, Vector3 attackerPosition)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AnimalBase::ServerApplyDamage(System.Int32,UnityEngine.Vector3)' called when server was not active");
			return;
		}
		Debug.Log($"[Server] {base.gameObject.name} took {damage} damage! (current: {currentHealth})");
		if (!isDead && currentHealth > 0)
		{
			NetworkcurrentHealth = currentHealth - damage;
			RpcOnDamaged();
			if (currentHealth <= 0)
			{
				NetworkisDead = true;
				RpcOnDeath();
				Die();
			}
			else if (isPeaceful)
			{
				StartFleeing(attackerPosition);
			}
			else
			{
				SetAngry(isAngry: true);
			}
		}
	}

	[ClientRpc]
	private void RpcOnDamaged()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void AnimalBase::RpcOnDamaged()", -1475123741, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcOnDeath()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void AnimalBase::RpcOnDeath()", -1139992318, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public virtual void TakeDamage(int damage)
	{
		TakeDamage(damage, base.transform.position);
	}

	protected virtual void StartFleeing(Vector3 attackerPosition)
	{
		if (isPeaceful)
		{
			isFleeing = true;
			state = AnimalState.Fleeing;
			fleeEndTime = Time.time + fleeDuration;
			Vector3 normalized = (base.transform.position - attackerPosition).normalized;
			normalized.y = 0f;
			Vector3 vector = base.transform.position + normalized * fleeDistance;
			Vector3 vector2 = new Vector3(Random.Range((0f - fleeDistance) * 0.3f, fleeDistance * 0.3f), 0f, Random.Range((0f - fleeDistance) * 0.3f, fleeDistance * 0.3f));
			SetDestination(vector + vector2);
			SetSpeed(fleeSpeed);
			currentTarget = null;
			RpcStartFleeing();
		}
	}

	[ClientRpc]
	private void RpcStartFleeing()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void AnimalBase::RpcStartFleeing()", 567315471, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected virtual void UpdateFleeing()
	{
		if (isFleeing && Time.time >= fleeEndTime)
		{
			StopFleeing();
		}
	}

	protected virtual void StopFleeing()
	{
		isFleeing = false;
		state = AnimalState.Idle;
		StopMoving();
		RpcStopFleeing();
	}

	[ClientRpc]
	private void RpcStopFleeing()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void AnimalBase::RpcStopFleeing()", -1566974521, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	protected virtual bool FindWalkPoint(out Vector3 walkPoint)
	{
		walkPoint = Vector3.zero;
		if ((int)walkingLayer == 0)
		{
			if (showPathDebug)
			{
				Debug.LogError(base.name + ": walkingLayer ayarlanmamış!");
			}
			return false;
		}
		for (int i = 0; i < raycastCount; i++)
		{
			Vector3 vector = Random.insideUnitSphere * walkPointSearchRadius;
			vector.y = 0f;
			if (!Physics.Raycast(base.transform.position + vector + Vector3.up * 10f, Vector3.down, out var hitInfo, raycastDistance, walkingLayer))
			{
				continue;
			}
			walkPoint = hitInfo.point;
			if (showPathDebug)
			{
				Debug.DrawLine(base.transform.position, walkPoint, Color.yellow, 2f);
			}
			if (IsPathClear(base.transform.position, walkPoint))
			{
				if (showPathDebug)
				{
					Debug.DrawLine(base.transform.position, walkPoint, Color.green, 2f);
				}
				return true;
			}
			if (showPathDebug)
			{
				Debug.DrawLine(base.transform.position, walkPoint, Color.red, 2f);
			}
		}
		if (showPathDebug)
		{
			Debug.LogWarning($"{base.name}: {raycastCount} denemede valid yol bulunamadı!");
		}
		return false;
	}

	protected bool IsPathClear(Vector3 start, Vector3 end)
	{
		Vector3 vector = new Vector3(start.x, start.y + 0.5f, start.z);
		Vector3 vector2 = new Vector3(end.x, end.y + 0.5f, end.z);
		Vector3 vector3 = vector2 - vector;
		float magnitude = vector3.magnitude;
		if (magnitude < 0.1f)
		{
			return true;
		}
		LayerMask layerMask = ~(int)walkingLayer;
		float radius = pathObstacleRadius;
		if (Physics.SphereCast(vector, radius, vector3.normalized, out var hitInfo, magnitude, layerMask))
		{
			if (showPathDebug)
			{
				Debug.LogWarning(base.name + ": Engel bulundu: " + hitInfo.collider.name + " (Layer: " + LayerMask.LayerToName(hitInfo.collider.gameObject.layer) + ")");
				Debug.DrawLine(vector, hitInfo.point, Color.magenta, 2f);
			}
			return false;
		}
		if (showPathDebug)
		{
			Debug.DrawLine(vector, vector2, Color.cyan, 2f);
		}
		return true;
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
			Debug.LogWarning("[Server] function 'System.Void AnimalBase::DropLoot()' called when server was not active");
			return;
		}
		Debug.Log("[AnimalBase] DropLoot called for " + base.gameObject.name);
		if (dropData == null || dropData.Count == 0)
		{
			Debug.LogWarning("[AnimalBase] " + base.gameObject.name + " has no dropData!");
			return;
		}
		if (NetworkSceneObjectSpawner.Instance == null)
		{
			Debug.LogWarning("[AnimalBase] NetworkSceneObjectSpawner.Instance is null!");
			return;
		}
		List<LootableItemEntry> list = new List<LootableItemEntry>();
		foreach (AnimalDropData dropDatum in dropData)
		{
			if (dropDatum != null && !(dropDatum.itemData == null))
			{
				float num = Random.Range(0f, 100f);
				if (num <= dropDatum.dropChance)
				{
					LootableItemEntry item = new LootableItemEntry
					{
						collectableData = dropDatum.itemData,
						count = dropDatum.itemCount
					};
					list.Add(item);
					Debug.Log($"[AnimalBase] {base.gameObject.name} dropping {dropDatum.itemData.name} x{dropDatum.itemCount} (roll: {num:F1} <= {dropDatum.dropChance})");
				}
			}
		}
		if (list.Count > 0)
		{
			Vector3 vector = new Vector3(Random.Range(0f - spawnRadius, spawnRadius), 1.5f, Random.Range(0f - spawnRadius, spawnRadius));
			Vector3 vector2 = base.transform.position + vector;
			NetworkSceneObjectSpawner.Instance.SpawnAnimalDropItem(vector2, list);
			Debug.Log($"[AnimalBase] {base.gameObject.name} spawned loot bag with {list.Count} items at {vector2}");
		}
		else
		{
			Debug.Log("[AnimalBase] " + base.gameObject.name + " no items passed drop chance rolls");
		}
	}

	public virtual void Eat()
	{
	}

	public virtual void DrinkWater()
	{
	}

	public virtual void Walk()
	{
	}

	public virtual void Match()
	{
	}

	public virtual void Mate()
	{
	}

	protected void SetIdle()
	{
		state = AnimalState.Idle;
		SetRandomIdleVariation();
		StopMoving();
	}

	public virtual void Die()
	{
		if (!dieProcessStarted)
		{
			dieProcessStarted = true;
			NetworkisDead = true;
			if (rvoController != null)
			{
				rvoController.locked = true;
			}
			if (characterController != null)
			{
				characterController.enabled = false;
			}
			if (base.isServer)
			{
				StartCoroutine(DelayedDropLoot(2f));
			}
			StartCoroutine(DisableAfterDeath());
		}
	}

	public void DieWithoutLoot()
	{
		if (!isDead)
		{
			NetworkisDead = true;
			if (rvoController != null)
			{
				rvoController.locked = true;
			}
			if (characterController != null)
			{
				characterController.enabled = false;
			}
			if (base.isServer)
			{
				NetworkServer.Destroy(base.gameObject);
			}
		}
	}

	private IEnumerator DisableAfterDeath()
	{
		yield return new WaitForSeconds(7f);
		yield return StartCoroutine(FadeOutAndDestroy(3f));
	}

	private IEnumerator FadeOutAndDestroy(float fadeDuration)
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		List<Material> materials = new List<Material>();
		Renderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Material[] materials2 = array[i].materials;
			foreach (Material material in materials2)
			{
				materials.Add(material);
				SetMaterialTransparent(material);
			}
		}
		float elapsedTime = 0f;
		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;
			float a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
			foreach (Material item in materials)
			{
				if (item.HasProperty("_BaseColor"))
				{
					Color color = item.GetColor("_BaseColor");
					color.a = a;
					item.SetColor("_BaseColor", color);
				}
				else if (item.HasProperty("_Color"))
				{
					Color color2 = item.GetColor("_Color");
					color2.a = a;
					item.SetColor("_Color", color2);
				}
			}
			yield return null;
		}
		if (base.isServer)
		{
			NetworkServer.Destroy(base.gameObject);
		}
	}

	private void SetMaterialTransparent(Material mat)
	{
		if (mat.HasProperty("_Surface"))
		{
			mat.SetFloat("_Surface", 1f);
			mat.SetFloat("_Blend", 0f);
		}
		mat.renderQueue = 3000;
		mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
		mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
		if (mat.HasProperty("_Mode"))
		{
			mat.SetFloat("_Mode", 3f);
		}
		if (mat.HasProperty("_SrcBlend"))
		{
			mat.SetFloat("_SrcBlend", 5f);
		}
		if (mat.HasProperty("_DstBlend"))
		{
			mat.SetFloat("_DstBlend", 10f);
		}
		if (mat.HasProperty("_ZWrite"))
		{
			mat.SetFloat("_ZWrite", 0f);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, walkPointSearchRadius);
		if (!isPeaceful)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, detectionRange);
			Gizmos.color = new Color(1f, 0.5f, 0f);
			Gizmos.DrawWireSphere(base.transform.position, attackRange);
		}
	}

	static AnimalBase()
	{
		SpeedHash = Animator.StringToHash("Speed");
		IsAttackingHash = Animator.StringToHash("IsAttacking");
		IsAngryHash = Animator.StringToHash("IsAngry");
		IsDeadHash = Animator.StringToHash("IsDead");
		HitHash = Animator.StringToHash("Hit");
		Idle1Hash = Animator.StringToHash("Idle1");
		Idle2Hash = Animator.StringToHash("Idle2");
		Idle3Hash = Animator.StringToHash("Idle3");
		Attack1Hash = Animator.StringToHash("Attack1");
		Attack2Hash = Animator.StringToHash("Attack2");
		Attack3Hash = Animator.StringToHash("Attack3");
		RemoteProcedureCalls.RegisterCommand(typeof(AnimalBase), "System.Void AnimalBase::CmdTakeDamage(System.Int32,UnityEngine.Vector3)", InvokeUserCode_CmdTakeDamage__Int32__Vector3, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(AnimalBase), "System.Void AnimalBase::RpcPlayIdleVariation(System.Int32)", InvokeUserCode_RpcPlayIdleVariation__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(AnimalBase), "System.Void AnimalBase::RpcOnDamaged()", InvokeUserCode_RpcOnDamaged);
		RemoteProcedureCalls.RegisterRpc(typeof(AnimalBase), "System.Void AnimalBase::RpcOnDeath()", InvokeUserCode_RpcOnDeath);
		RemoteProcedureCalls.RegisterRpc(typeof(AnimalBase), "System.Void AnimalBase::RpcStartFleeing()", InvokeUserCode_RpcStartFleeing);
		RemoteProcedureCalls.RegisterRpc(typeof(AnimalBase), "System.Void AnimalBase::RpcStopFleeing()", InvokeUserCode_RpcStopFleeing);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcPlayIdleVariation__Int32(int index)
	{
		if (!base.isServer)
		{
			PlayIdleVariation(index);
		}
	}

	protected static void InvokeUserCode_RpcPlayIdleVariation__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayIdleVariation called on server.");
		}
		else
		{
			((AnimalBase)obj).UserCode_RpcPlayIdleVariation__Int32(reader.ReadInt());
		}
	}

	protected void UserCode_CmdTakeDamage__Int32__Vector3(int damage, Vector3 attackerPosition)
	{
		ServerApplyDamage(damage, attackerPosition);
	}

	protected static void InvokeUserCode_CmdTakeDamage__Int32__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTakeDamage called on client.");
		}
		else
		{
			((AnimalBase)obj).UserCode_CmdTakeDamage__Int32__Vector3(reader.ReadInt(), reader.ReadVector3());
		}
	}

	protected void UserCode_RpcOnDamaged()
	{
		_ = isDead;
	}

	protected static void InvokeUserCode_RpcOnDamaged(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnDamaged called on server.");
		}
		else
		{
			((AnimalBase)obj).UserCode_RpcOnDamaged();
		}
	}

	protected void UserCode_RpcOnDeath()
	{
		NetworkisDead = true;
		StopMoving();
		if (rvoController != null)
		{
			rvoController.locked = true;
		}
		if (characterController != null)
		{
			characterController.enabled = false;
		}
		if (Animator != null)
		{
			Animator.SetBool(IsDeadHash, value: true);
			Animator.SetFloat(SpeedHash, 0f);
		}
	}

	protected static void InvokeUserCode_RpcOnDeath(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnDeath called on server.");
		}
		else
		{
			((AnimalBase)obj).UserCode_RpcOnDeath();
		}
	}

	protected void UserCode_RpcStartFleeing()
	{
		SetAnimatorSpeed(2f);
	}

	protected static void InvokeUserCode_RpcStartFleeing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcStartFleeing called on server.");
		}
		else
		{
			((AnimalBase)obj).UserCode_RpcStartFleeing();
		}
	}

	protected void UserCode_RpcStopFleeing()
	{
		SetAnimatorSpeed(0f);
	}

	protected static void InvokeUserCode_RpcStopFleeing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcStopFleeing called on server.");
		}
		else
		{
			((AnimalBase)obj).UserCode_RpcStopFleeing();
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteInt(currentHealth);
			writer.WriteBool(isDead);
			writer.WriteFloat(syncedAnimSpeed);
			return;
		}
		writer.WriteULong(base.syncVarDirtyBits);
		if ((base.syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteInt(currentHealth);
		}
		if ((base.syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(isDead);
		}
		if ((base.syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteFloat(syncedAnimSpeed);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref currentHealth, null, reader.ReadInt());
			GeneratedSyncVarDeserialize(ref isDead, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref syncedAnimSpeed, OnSyncedAnimSpeedChanged, reader.ReadFloat());
			return;
		}
		long num = (long)reader.ReadULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentHealth, null, reader.ReadInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isDead, null, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncedAnimSpeed, OnSyncedAnimSpeedChanged, reader.ReadFloat());
		}
	}
}
