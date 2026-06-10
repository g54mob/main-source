using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SnailController : MonoBehaviour
{
	[Serializable]
	public class SnailSaveData
	{
		public Vector3 pos;

		public Quaternion rot;

		public bool inAirVent;

		public int duct;
	}

	[Serializable]
	public struct SnailSearchVector
	{
		public Vector3 startPoint;

		public Vector3 forwards;

		public Vector3 up;

		public List<Vector3> previousPoints;
	}

	[Serializable]
	public struct SnailPath
	{
		public Vector3 pos;

		public bool vent;

		public AirDuctGroup.AirDuctSection duct;

		public SnailPath(Vector3 newPos)
		{
			pos = default(Vector3);
			vent = false;
			duct = null;
		}

		public SnailPath(Vector3 newPos, AirDuctGroup.AirDuctSection newDuct)
		{
			pos = default(Vector3);
			vent = false;
			duct = null;
		}
	}

	[Header("Data")]
	public bool inAirVent;

	public AirDuctGroup currentAirDuctGroup;

	public AirDuctGroup.AirDuctSection currentAirDuctSection;

	public int snailLayerMask;

	public int pointCloudLayerMask;

	private AudioController.LoopingSoundInfo audioLoop;

	public GameObject snailSlimePrefab;

	public float slimeTimer;

	public List<SnailPath> currentPath;

	public int pathCursor;

	private NewNode lastRouteWhenPlayerWasAt;

	public float closePathUpdateTimer;

	public float distancePathUpdateTimer;

	private float playerXZDistance;

	private float movementAmount;

	[Header("Stick to Geometry Movement")]
	public float surfaceOffset;

	public Vector3 surfaceNormal;

	public float probeRange;

	public float faceDirectionSpeed;

	public float psuedoGravity;

	public float snailSpeed;

	[Header("Target")]
	public Vector3 currentDestination;

	public float stopDistance;

	[Header("Point Cloud Pathing")]
	private Dictionary<Vector3, List<Vector3>> points;

	public NewRoom pointsGeneratedForRoom;

	public Vector3 lastPointCloudPathNodeReached;

	public Vector3 closestPlayerCloudPoint;

	[Header("Stuck Detection")]
	public float sampleTimer;

	private List<Vector3> samplePositions;

	[Tooltip("While above 0, snail will stick to its current direction")]
	public float snailUnstuckTimer;

	public Vector3 currentNormal;

	public float upAlignSpeed;

	public float forwardTurnSpeed;

	public void SetupNewSnail(NewNode startingNode)
	{
	}

	public void SetupNewSnail(SnailSaveData loadSnailPos)
	{
	}

	public void StartAudio()
	{
	}

	private void OnDestroy()
	{
	}

	public SnailSaveData GetSaveData()
	{
		return null;
	}

	public void UpdatePath()
	{
	}

	private SnailPath GenerateStuckPath()
	{
		return default(SnailPath);
	}

	private void Update()
	{
	}

	public void ResolveSnailMovement()
	{
	}

	public void MoveSnail(float movementAmount)
	{
	}

	public Vector3 ApplyTraversalYConditions(Vector3 input, NewNode currentNode)
	{
		return default(Vector3);
	}

	private void PathAdvanceCheck()
	{
	}

	private bool FindSurface(out RaycastHit bestHit, out bool useGroundLevelTarget, bool includeBackwardsDiagonal = false)
	{
		bestHit = default(RaycastHit);
		useGroundLevelTarget = default(bool);
		return false;
	}

	private bool IsInRenderedRoom(out NewNode currentNode)
	{
		currentNode = null;
		return false;
	}

	private void SamplePositionTest()
	{
	}

	private void AdvancePath()
	{
	}

	public void TouchPlayerCheck()
	{
	}

	public List<SnailPath> SnailCustomPathfind()
	{
		return null;
	}

	public List<SnailPath> PathfindIncludingVentSystem()
	{
		return null;
	}

	private AirDuctGroup.AirVent FindClosestVentThatConnectsToPlayer()
	{
		return null;
	}

	private bool DoesCurrentDuctConnectWithPlayer()
	{
		return false;
	}

	public bool TryAirDuctPathfind(AirDuctGroup.AirDuctSection origin, AirDuctGroup.AirDuctSection destination, bool findNearestExitInstead, out List<AirDuctGroup.AirDuctSection> ret)
	{
		ret = null;
		return false;
	}

	public void SetInAirDuct(bool isIn, AirDuctGroup.AirDuctSection setToSection)
	{
	}

	public NewNode GetCurrentNodePos()
	{
		return null;
	}

	public Vector3 GetGroundLevelPlayerPosition()
	{
		return default(Vector3);
	}

	public List<SnailPath> GetSameRoomPathingRoute()
	{
		return null;
	}

	private List<SnailPath> TrimPath(List<SnailPath> input)
	{
		return null;
	}

	private bool SnailRaycast(Vector3 origin, Vector3 direction, out RaycastHit hit, float range, int layerMask)
	{
		hit = default(RaycastHit);
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateCurrentRoomPointCloud()
	{
	}

	private void AddPlayerLocationPoints(int count)
	{
	}

	private Vector3 GetClosestPlayerCloudPoint()
	{
		return default(Vector3);
	}

	public bool GetRouteFromPointCloud(out List<SnailPath> ret)
	{
		ret = null;
		return false;
	}

	private float GetCeilingHeight(NewNode forNode)
	{
		return 0f;
	}

	private Vector3 GetRoundedVector3(Vector3 v3)
	{
		return default(Vector3);
	}
}
