using System.Collections;
using UnityEngine;

public class AnimalController : AnimalBase
{
	[Header("Movement Settings")]
	public float walkSpeed = 2f;

	public float runSpeed = 5f;

	[Header("Wandering Settings")]
	public float minWanderInterval = 3f;

	public float maxWanderInterval = 8f;

	[Header("Idle Animation Settings")]
	public float minIdleChangeInterval = 3f;

	public float maxIdleChangeInterval = 8f;

	[Header("Path Timeout")]
	[Tooltip("Seconds before giving up on current path and picking a new direction")]
	[Range(3f, 30f)]
	public float pathTimeout = 10f;

	[Header("Stuck Detection")]
	[Tooltip("How often to check if the animal is stuck (seconds)")]
	[Range(1f, 5f)]
	public float stuckCheckInterval = 3f;

	[Tooltip("Minimum distance the animal must move within the check interval to not be considered stuck")]
	[Range(0.3f, 3f)]
	public float stuckDistanceThreshold = 0.5f;

	private float walkStartTime;

	private Vector3 lastStuckCheckPosition;

	private float nextStuckCheckTime;

	private float nextWanderTime;

	private float nextIdleChangeTime;

	public int failedWanderAttempts;

	private bool isMoving;

	private bool waitingForPath;

	private float lastObstacleCollisionTime = -999f;

	private float lastWaterCollisionTime = -999f;

	private const float OBSTACLE_COLLISION_COOLDOWN = 30f;

	private const float WATER_COLLISION_COOLDOWN = 5f;

	protected override void Start()
	{
		base.Start();
		nextWanderTime = Time.time + Random.Range(minWanderInterval, maxWanderInterval);
		nextIdleChangeTime = Time.time + Random.Range(minIdleChangeInterval, maxIdleChangeInterval);
		state = AnimalState.Idle;
		if (base.isServer)
		{
			StartCoroutine(CheckSpawnInWater());
		}
	}

	private IEnumerator CheckSpawnInWater()
	{
		yield return new WaitForSeconds(1f);
		Collider[] array = Physics.OverlapSphere(base.transform.position, 0.5f);
		foreach (Collider collider in array)
		{
			if (collider.GetComponent<WaterInteractable>() != null)
			{
				Vector3 normalized = (base.transform.position - collider.ClosestPoint(base.transform.position)).normalized;
				normalized.y = 0f;
				if (normalized.sqrMagnitude < 0.01f)
				{
					normalized = Random.insideUnitSphere.normalized;
				}
				normalized.y = 0f;
				Vector3 destination = base.transform.position + normalized * walkPointSearchRadius;
				SetDestination(destination);
				SetSpeed(runSpeed);
				StartMoving();
				state = AnimalState.Walking;
				SetAnimatorSpeed(2f);
				break;
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		if (isDead || currentHealth <= 0 || !base.isServer)
		{
			return;
		}
		if (base.transform.position.y < -200f)
		{
			DieWithoutLoot();
			return;
		}
		if (isFleeing)
		{
			if (IsPathPending())
			{
				waitingForPath = true;
				return;
			}
			if (waitingForPath)
			{
				waitingForPath = false;
				if (!HasValidPath())
				{
					FindNewFleePoint();
					return;
				}
			}
			if (HasReachedDestinationOrClose(2f))
			{
				FindNewFleePoint();
			}
			return;
		}
		if (state == AnimalState.Idle && Time.time >= nextIdleChangeTime)
		{
			SetRandomIdleVariation();
			nextIdleChangeTime = Time.time + Random.Range(minIdleChangeInterval, maxIdleChangeInterval);
		}
		if (state == AnimalState.Idle && currentTarget == null && Time.time >= nextWanderTime)
		{
			TryWander();
			nextWanderTime = Time.time + Random.Range(minWanderInterval, maxWanderInterval);
		}
		if (isMoving)
		{
			if (showPathDebug)
			{
				Debug.Log($"{base.name}: RVO - hasPath:{HasValidPath()} pathPending:{IsPathPending()} speed:{currentSpeed:F2} remainingDist:{RemainingDistance():F2}");
			}
			if (IsPathPending())
			{
				return;
			}
			if (!HasValidPath())
			{
				SetIdle();
				isMoving = false;
				failedWanderAttempts++;
				nextWanderTime = Time.time + Random.Range(1f, 3f);
				return;
			}
			if (HasReachedDestinationOrClose(1f))
			{
				SetIdle();
				isMoving = false;
				nextWanderTime = Time.time + Random.Range(minWanderInterval, maxWanderInterval);
				return;
			}
			if (Time.time >= nextStuckCheckTime)
			{
				float num = Vector3.Distance(base.transform.position, lastStuckCheckPosition);
				if (num < stuckDistanceThreshold)
				{
					if (showPathDebug)
					{
						Debug.LogWarning($"{base.name}: Stuck detected! Moved only {num:F2}m in {stuckCheckInterval}s");
					}
					PickNewDirectionAfterTimeout();
					return;
				}
				lastStuckCheckPosition = base.transform.position;
				nextStuckCheckTime = Time.time + stuckCheckInterval;
			}
			if (Time.time - walkStartTime >= pathTimeout)
			{
				if (showPathDebug)
				{
					Debug.LogWarning(base.name + ": Path timeout! Picking new direction.");
				}
				PickNewDirectionAfterTimeout();
				return;
			}
		}
		if (currentTarget != null && !isPeaceful)
		{
			SetDestination(currentTarget.position);
			SetSpeed(runSpeed);
			SetAnimatorSpeed(2f);
		}
		UpdateAnimatorFromState();
	}

	private bool HasReachedDestinationOrClose(float threshold)
	{
		if (HasReachedDestination())
		{
			return true;
		}
		if (RemainingDistance() <= threshold && !IsPathPending())
		{
			return true;
		}
		return false;
	}

	private void FindNewFleePoint()
	{
		Vector3 vector = Random.insideUnitSphere * fleeDistance;
		vector.y = 0f;
		Vector3 destination = base.transform.position + vector;
		SetDestination(destination);
		SetSpeed(fleeSpeed);
		SetAnimatorSpeed(2f);
	}

	private void StartMoving()
	{
		isMoving = true;
		walkStartTime = Time.time;
		lastStuckCheckPosition = base.transform.position;
		nextStuckCheckTime = Time.time + stuckCheckInterval;
	}

	private void TryWander()
	{
		if (FindWalkPoint(out var walkPoint))
		{
			SetDestination(walkPoint);
			SetSpeed(walkSpeed);
			StartMoving();
			state = AnimalState.Walking;
			failedWanderAttempts = 0;
		}
		else
		{
			failedWanderAttempts++;
		}
	}

	private void PickNewDirectionAfterTimeout()
	{
		Vector3 forward = base.transform.forward;
		float y = Random.Range(90f, 270f);
		Vector3 vector = Quaternion.Euler(0f, y, 0f) * forward;
		vector.y = 0f;
		vector.Normalize();
		Vector3 destination = base.transform.position + vector * walkPointSearchRadius * 0.5f;
		SetDestination(destination);
		SetSpeed(walkSpeed);
		StartMoving();
		state = AnimalState.Walking;
	}

	private void UpdateAnimatorFromState()
	{
		if (state == AnimalState.Idle || state == AnimalState.Attacking)
		{
			SetAnimatorSpeed(0f);
		}
		else if (state == AnimalState.Walking)
		{
			SetAnimatorSpeed(1f);
		}
		else if (state == AnimalState.Fleeing || currentTarget != null)
		{
			SetAnimatorSpeed(2f);
		}
	}

	protected override void StopFleeing()
	{
		base.StopFleeing();
		isMoving = false;
		SetAnimatorSpeed(0f);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (base.isServer && !isDead && currentHealth > 0 && !(other.GetComponent<WaterInteractable>() == null) && !(Time.time - lastWaterCollisionTime < 5f))
		{
			lastWaterCollisionTime = Time.time;
			FleeFromPoint(other.ClosestPoint(base.transform.position));
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (base.isServer && !isDead && currentHealth > 0 && !(Time.time - lastObstacleCollisionTime < 30f) && (hit.gameObject.GetComponent<TreeCollectable>() != null || hit.gameObject.GetComponent<OreCollectable>() != null || hit.gameObject.GetComponent<TrainController>() != null || hit.gameObject.GetComponent<PlaceableObject>() != null))
		{
			lastObstacleCollisionTime = Time.time;
			FleeFromPoint(hit.point);
		}
	}

	private void FleeFromPoint(Vector3 contactPoint)
	{
		Vector3 vector = (base.transform.position - contactPoint).normalized;
		vector.y = 0f;
		if (vector.sqrMagnitude < 0.01f)
		{
			vector = -base.transform.forward;
		}
		Vector3 destination = base.transform.position + vector * walkPointSearchRadius;
		SetDestination(destination);
		SetSpeed(runSpeed);
		StartMoving();
		state = AnimalState.Walking;
		SetAnimatorSpeed(2f);
	}

	public override void Die()
	{
		base.Die();
		isMoving = false;
	}

	public override bool Weaved()
	{
		return true;
	}
}
