using System.Collections.Generic;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class PathfindMovementEnemy : PathfindMovement, DayNightCycle.IDaytimeSensitive
{
	public List<TargetPriority> targetPriorities = new List<TargetPriority>();

	public float keepDistanceOf = 2f;

	public float maximumDistanceFromHome = 100000f;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float movementSpeed = 2f;

	public float recalculatePathInterval = 1f;

	public string backupMovementGraph = "";

	public float agroTimeWhenAttackedByPlayer = 5f;

	private TaggedObject agroPlayerTarget;

	private float remainingPlayerAgroTime;

	private Seeker seeker;

	private RVOController rvo;

	private Vector3 seekToTargetPosSnappedtoNavmesh = Vector3.zero;

	private Vector3 seekToTargetPos = Vector3.zero;

	private TaggedObject seekToTaggedObj;

	private List<Vector3> path = new List<Vector3>();

	private int nextPathPointIndex;

	private float recalculatePathCooldown;

	private Vector3 homePosition;

	private bool currentlyWalkingHome = true;

	private TargetPriority targetPrio;

	private bool currentlyChasingPlayer;

	private NNConstraint nearestConstraint = new NNConstraint();

	private Vector3 nextPathPoint;

	private Vector3 homeOffset = Vector3.zero;

	private GraphMask graphMaskOriginal;

	private GraphMask graphMaskBackup;

	private float slowDurationMulti = 1f;

	private float slowedFor;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.PercentageModifyer)]
	private float speedWhenSlowed = 0.33f;

	private Vector3 storeRequestedTargetPos;

	[SerializeField]
	private bool eneableStuckDetection;

	private float stuckDetectionTimer;

	private float solveStuckTimer;

	private float distanceToTarget;

	private Vector3 fromToVector;

	private Vector3 escapeVector = Vector3.right;

	public override RVOController RVO => rvo;

	public Vector3 SeekToTargetPosSnappedtoNavmesh => seekToTargetPosSnappedtoNavmesh;

	public List<Vector3> Path => path;

	public Vector3 HomePosition => homePosition;

	public Vector3 NextPathPoint => nextPathPoint;

	public override bool IsSlowed => slowedFor > 0f;

	public override void GetAgroFromObject(TaggedObject _agroTarget)
	{
		if ((bool)_agroTarget && _agroTarget.Tags.Contains(TagManager.ETag.Player))
		{
			agroPlayerTarget = _agroTarget;
			remainingPlayerAgroTime = agroTimeWhenAttackedByPlayer;
			if (!currentlyChasingPlayer && agroTimeWhenAttackedByPlayer > 0f)
			{
				OriginalPathRequest();
			}
		}
	}

	public void OnDusk()
	{
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	private void Start()
	{
		seeker = GetComponent<Seeker>();
		rvo = GetComponent<RVOController>();
		recalculatePathCooldown = recalculatePathInterval * Random.value;
		homePosition = base.transform.position;
		nearestConstraint.graphMask = seeker.graphMask;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		homeOffset = new Vector3(Random.value - 0.5f, 0f, Random.value - 0.5f);
		foreach (TargetPriority targetPriority in targetPriorities)
		{
			targetPriority.mayNotHaveTags.Add(TagManager.ETag.AUTO_Commanded);
		}
		if (PerkManager.instance.IceMagicActive)
		{
			speedWhenSlowed *= PerkManager.instance.iceMagic_AdditionalsSlowMutli;
			slowDurationMulti *= PerkManager.instance.iceMagic_SlowDurationMulti;
		}
		graphMaskOriginal = seeker.graphMask;
		graphMaskBackup = GraphMask.FromGraphName(backupMovementGraph);
		if (GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.MeeleFighter) && EnemySpawner.totalEnemiesSpawnedThisWave % 2 == 1)
		{
			graphMaskOriginal = graphMaskBackup;
		}
		SnapToNavmesh();
	}

	public void OriginalPathRequest()
	{
		seekToTargetPos = FindMoveToTarget();
		seekToTargetPosSnappedtoNavmesh = AstarPath.active.GetNearest(seekToTargetPos, nearestConstraint).position;
		storeRequestedTargetPos = seekToTargetPosSnappedtoNavmesh;
		seeker.StartPath(base.transform.position, seekToTargetPosSnappedtoNavmesh, OriginalOnPathComplete, graphMaskOriginal);
	}

	private void OriginalOnPathComplete(Path _p)
	{
		if (backupMovementGraph != "")
		{
			if (_p.error)
			{
				BackupPathRequest();
				return;
			}
			if ((storeRequestedTargetPos - _p.vectorPath[_p.vectorPath.Count - 1]).magnitude > 1f)
			{
				BackupPathRequest();
				return;
			}
		}
		else if (_p.error)
		{
			return;
		}
		path = _p.vectorPath;
		nextPathPointIndex = 0;
	}

	private void BackupPathRequest()
	{
		seekToTargetPos = FindMoveToTarget();
		seekToTargetPosSnappedtoNavmesh = AstarPath.active.GetNearest(seekToTargetPos, nearestConstraint).position;
		storeRequestedTargetPos = seekToTargetPosSnappedtoNavmesh;
		seeker.StartPath(base.transform.position, seekToTargetPosSnappedtoNavmesh, BackupOnPathComplete, graphMaskBackup);
	}

	public Vector3 GetNearestGroundPosition(Vector3 _position)
	{
		return AstarPath.active.GetNearest(_position, nearestConstraint).position;
	}

	private void BackupOnPathComplete(Path _p)
	{
		if (!_p.error)
		{
			path = _p.vectorPath;
			nextPathPointIndex = 0;
		}
	}

	private Vector3 FindMoveToTarget()
	{
		currentlyWalkingHome = false;
		currentlyChasingPlayer = false;
		if (remainingPlayerAgroTime > 0f && agroPlayerTarget != null && !agroPlayerTarget.Hp.KnockedOut)
		{
			seekToTaggedObj = agroPlayerTarget;
			currentlyChasingPlayer = true;
			return seekToTaggedObj.transform.position;
		}
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			targetPrio = targetPriorities[i];
			seekToTaggedObj = targetPrio.FindTaggedObjectCloseToHome(base.transform.position, homePosition, maximumDistanceFromHome, out var _outPosition);
			if (!(seekToTaggedObj == null))
			{
				if (seekToTaggedObj.Tags.Contains(TagManager.ETag.Player))
				{
					currentlyChasingPlayer = true;
				}
				return _outPosition;
			}
		}
		seekToTaggedObj = null;
		targetPrio = null;
		currentlyWalkingHome = true;
		return homePosition + homeOffset;
	}

	private void Update()
	{
		if (remainingPlayerAgroTime > 0f)
		{
			remainingPlayerAgroTime -= Time.deltaTime;
		}
		recalculatePathCooldown -= Time.deltaTime;
		if (recalculatePathCooldown <= 0f)
		{
			recalculatePathCooldown = recalculatePathInterval;
			OriginalPathRequest();
		}
		if (currentlyChasingPlayer)
		{
			seekToTargetPosSnappedtoNavmesh = seekToTaggedObj.transform.position;
			if (path.Count > 0)
			{
				path[path.Count - 1] = seekToTargetPosSnappedtoNavmesh;
			}
			seekToTargetPos = seekToTargetPosSnappedtoNavmesh;
		}
		FollowPathUpdate();
	}

	public override void Slow(float _duration)
	{
		slowedFor = Mathf.Max(_duration, slowedFor);
	}

	private void FollowPathUpdate()
	{
		if (path.Count <= nextPathPointIndex)
		{
			if (!currentlyChasingPlayer || path.Count <= 0)
			{
				return;
			}
			nextPathPointIndex = path.Count - 1;
		}
		nextPathPoint = path[nextPathPointIndex];
		distanceToTarget = (base.transform.position - seekToTargetPos).magnitude;
		if (distanceToTarget < keepDistanceOf && !currentlyWalkingHome)
		{
			fromToVector = Vector3.zero;
			nextPathPoint = base.transform.position;
		}
		else
		{
			fromToVector = nextPathPoint - base.transform.position;
			for (int i = 0; i < 100; i++)
			{
				if (!(fromToVector.magnitude <= 1f))
				{
					break;
				}
				if (nextPathPointIndex == path.Count - 1)
				{
					break;
				}
				nextPathPointIndex++;
				nextPathPointIndex = Mathf.Clamp(nextPathPointIndex, 0, path.Count - 1);
				nextPathPoint = path[nextPathPointIndex];
				fromToVector = nextPathPoint - base.transform.position;
			}
		}
		if (solveStuckTimer > 0f)
		{
			solveStuckTimer -= Time.deltaTime;
			nextPathPoint = base.transform.position + escapeVector * 10f;
			escapeVector = Quaternion.Euler(0f, 30f * Time.deltaTime, 0f) * escapeVector;
			fromToVector = nextPathPoint - base.transform.position;
		}
		float magnitude = fromToVector.magnitude;
		rvo.priority = magnitude;
		float num = Mathf.Min(movementSpeed, magnitude / Time.deltaTime);
		if (slowedFor > 0f)
		{
			rvo.SetTarget(nextPathPoint, num * speedWhenSlowed, movementSpeed * 1.15f, path[path.Count - 1]);
			slowedFor -= Time.deltaTime / slowDurationMulti;
		}
		else
		{
			rvo.SetTarget(nextPathPoint, num, movementSpeed * 1.15f, path[path.Count - 1]);
		}
		Vector3 position = base.transform.position + rvo.CalculateMovementDelta(Time.deltaTime);
		Vector3 position2 = AstarPath.active.GetNearest(position, nearestConstraint).position;
		Vector3 vector = base.transform.position - position2;
		float magnitude2 = new Vector2(vector.x, vector.z).magnitude;
		if (eneableStuckDetection && solveStuckTimer <= 0f)
		{
			if (magnitude2 < 0.001f && distanceToTarget > keepDistanceOf)
			{
				stuckDetectionTimer += Time.deltaTime;
			}
			else
			{
				stuckDetectionTimer = Mathf.Max(0f, stuckDetectionTimer - Time.deltaTime);
			}
			if (stuckDetectionTimer > 3f)
			{
				stuckDetectionTimer = 0f;
				solveStuckTimer = 5f;
			}
		}
		if (magnitude2 < 2f)
		{
			base.transform.position = position2;
		}
	}

	public void SnapToNavmesh()
	{
		base.transform.position = AstarPath.active.GetNearest(base.transform.position, nearestConstraint).position;
	}

	public override void ClearCurrentPath()
	{
		path.Clear();
	}

	public void OnDuskEarly()
	{
	}
}
