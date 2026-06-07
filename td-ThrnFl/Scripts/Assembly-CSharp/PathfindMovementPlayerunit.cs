using System.Collections.Generic;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class PathfindMovementPlayerunit : PathfindMovement, DayNightCycle.IDaytimeSensitive
{
	public List<TargetPriority> targetPriorities = new List<TargetPriority>();

	public float keepDistanceOf = 2f;

	public float maximumDistanceFromHome = 100000f;

	public float movementSpeed = 2f;

	public float recalculatePathInterval = 1f;

	public string backupMovementGraph = "";

	public float agroTimeWhenAttackedByPlayer = 5f;

	public float speedBoostDuringDaytime = 1.5f;

	private TaggedObject agroPlayerTarget;

	private Seeker seeker;

	private RVOController rvo;

	private Vector3 seekToTargetPosSnappedtoNavmesh = Vector3.zero;

	private Vector3 seekToTargetPos = Vector3.zero;

	private TaggedObject seekToTaggedObj;

	private List<Vector3> path = new List<Vector3>();

	private int nextPathPointIndex;

	private float recalculatePathCooldown;

	private Vector3 homePosition;

	private Vector3 homePositionOriginal;

	private bool currentlyWalkingHome = true;

	private TargetPriority targetPrio;

	private NNConstraint nearestConstraint = new NNConstraint();

	private GraphMask graphMaskOriginal;

	private Vector3 nextPathPoint;

	private SettingsManager settingsManager;

	private bool followingPlayer;

	[SerializeField]
	private GameObject holdPositionMarker;

	private Transform holdPositionMarkerTransform;

	private float slowedFor;

	private bool day = true;

	private bool holdPosition;

	private const float HAS_REACHED_HOME_POS_DIST = 3f;

	private const float TINY_AGRO_RANGE_ON_HOLD_POSITION = 7f;

	private bool hasReachedHomePositionAlready;

	private bool flying;

	[Header("References")]
	public Hp hp;

	public AutoAttack[] autoAttacks;

	private Vector3 storeRequestedTargetPos;

	public override RVOController RVO => rvo;

	public Vector3 SeekToTargetPosSnappedtoNavmesh => seekToTargetPosSnappedtoNavmesh;

	public Vector3 HomePositionOriginal => homePositionOriginal;

	public Vector3 HomePosition
	{
		get
		{
			return homePosition;
		}
		set
		{
			homePosition = value;
		}
	}

	public Vector3 NextPathPoint => nextPathPoint;

	public bool FollowingPlayer => followingPlayer;

	public override bool IsSlowed => slowedFor > 0f;

	public bool HasReachedHomePositionAlready
	{
		get
		{
			return hasReachedHomePositionAlready;
		}
		set
		{
			hasReachedHomePositionAlready = value;
		}
	}

	public bool Flying => flying;

	public bool HoldPosition
	{
		get
		{
			return holdPosition;
		}
		set
		{
			if (holdPosition == value)
			{
				return;
			}
			if (PlayerUpgradeManager.instance.commander)
			{
				if (value)
				{
					hp.ScaleHp(CommandUnits.instance.commanderHoldHealthMulti);
					AutoAttack[] array = autoAttacks;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].DamageMultiplyer *= CommandUnits.instance.commanderHoldDamageMulti;
					}
				}
				else
				{
					hp.ScaleHp(1f / CommandUnits.instance.commanderHoldHealthMulti);
					AutoAttack[] array = autoAttacks;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].DamageMultiplyer /= CommandUnits.instance.commanderHoldDamageMulti;
					}
				}
			}
			holdPosition = value;
			holdPositionMarker.SetActive(value);
			if ((bool)holdPositionMarkerTransform)
			{
				holdPositionMarkerTransform.position = homePosition + 0.05f * Vector3.up;
			}
		}
	}

	public void FollowPlayer(bool _follow)
	{
		followingPlayer = _follow;
		HoldPosition = false;
	}

	public override void GetAgroFromObject(TaggedObject _agroTarget)
	{
	}

	private void OnDisable()
	{
		if ((bool)holdPositionMarker)
		{
			holdPositionMarker.SetActive(value: false);
		}
	}

	private void OnEnable()
	{
		HoldPosition = false;
	}

	public void OnDuskEarly()
	{
	}

	public void OnDusk()
	{
		day = false;
	}

	public void OnDawn_AfterSunrise()
	{
		day = true;
	}

	public void OnDawn_BeforeSunrise()
	{
		if (settingsManager.ResetUnitFormationEveryMorning)
		{
			homePosition = homePositionOriginal;
			HoldPosition = false;
		}
	}

	private void Start()
	{
		settingsManager = SettingsManager.Instance;
		holdPositionMarkerTransform = holdPositionMarker.transform;
		holdPositionMarkerTransform.SetParent(null);
		HoldPosition = false;
		seeker = GetComponent<Seeker>();
		rvo = GetComponent<RVOController>();
		recalculatePathCooldown = recalculatePathInterval * Random.value;
		homePosition = base.transform.position;
		homePositionOriginal = base.transform.position;
		nearestConstraint.graphMask = seeker.graphMask;
		graphMaskOriginal = seeker.graphMask;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		flying = GetComponent<TaggedObject>().Tags.Contains(TagManager.ETag.Flying);
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
			if ((storeRequestedTargetPos - _p.vectorPath[_p.vectorPath.Count - 1]).magnitude > 0.1f)
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
		seeker.StartPath(base.transform.position, seekToTargetPosSnappedtoNavmesh, BackupOnPathComplete, GraphMask.FromGraphName(backupMovementGraph));
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
		if (followingPlayer)
		{
			seekToTaggedObj = null;
			targetPrio = null;
			currentlyWalkingHome = true;
			return homePosition;
		}
		if (!hasReachedHomePositionAlready)
		{
			seekToTaggedObj = null;
			targetPrio = null;
			currentlyWalkingHome = true;
			return homePosition;
		}
		currentlyWalkingHome = false;
		for (int i = 0; i < targetPriorities.Count; i++)
		{
			targetPrio = targetPriorities[i];
			Vector3 _outPosition;
			if (holdPosition)
			{
				seekToTaggedObj = targetPrio.FindTaggedObjectCloseToHomeInHomeRange(base.transform.position, homePosition, 7f, out _outPosition);
			}
			else
			{
				seekToTaggedObj = targetPrio.FindTaggedObjectCloseToHome(base.transform.position, homePosition, maximumDistanceFromHome, out _outPosition);
			}
			if (!(seekToTaggedObj == null))
			{
				return _outPosition;
			}
		}
		seekToTaggedObj = null;
		targetPrio = null;
		currentlyWalkingHome = true;
		return homePosition;
	}

	private void Update()
	{
		recalculatePathCooldown -= Time.deltaTime;
		if (recalculatePathCooldown <= 0f)
		{
			recalculatePathCooldown = recalculatePathInterval;
			OriginalPathRequest();
		}
		if (followingPlayer)
		{
			if (path.Count > 0)
			{
				path[path.Count - 1] = homePosition;
			}
			seekToTargetPos = homePosition;
		}
		FollowPathUpdate();
	}

	public override void Slow(float _duration)
	{
	}

	private void FollowPathUpdate()
	{
		if (path.Count <= nextPathPointIndex)
		{
			if (!followingPlayer || path.Count <= 0)
			{
				return;
			}
			nextPathPointIndex = path.Count - 1;
		}
		nextPathPoint = path[nextPathPointIndex];
		float magnitude = (base.transform.position - seekToTargetPos).magnitude;
		if (magnitude < 3f && currentlyWalkingHome)
		{
			HasReachedHomePositionAlready = true;
		}
		Vector3 vector;
		if (magnitude < keepDistanceOf && !currentlyWalkingHome)
		{
			vector = Vector3.zero;
			nextPathPoint = base.transform.position;
		}
		else
		{
			vector = nextPathPoint - base.transform.position;
			for (int i = 0; i < 100; i++)
			{
				if (!(vector.magnitude <= 1f))
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
				vector = nextPathPoint - base.transform.position;
			}
		}
		float magnitude2 = vector.magnitude;
		rvo.priority = magnitude2;
		float speed = Mathf.Min(movementSpeed, magnitude2 / Time.deltaTime);
		rvo.SetTarget(nextPathPoint, speed, movementSpeed * 1.15f, path[path.Count - 1]);
		Vector3 position = base.transform.position + rvo.CalculateMovementDelta(Time.deltaTime);
		Vector3 position2 = AstarPath.active.GetNearest(position, nearestConstraint).position;
		base.transform.position = position2;
	}

	public void SnapToNavmesh()
	{
		base.transform.position = AstarPath.active.GetNearest(base.transform.position, nearestConstraint).position;
	}

	public override void ClearCurrentPath()
	{
		path.Clear();
	}

	public Vector3 GetNearestGroundPosition(Vector3 _position)
	{
		return AstarPath.active.GetNearest(_position, nearestConstraint).position;
	}
}
