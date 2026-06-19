using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshHelper : MonoBehaviour
{
	public bool debugVis;

	private NavMeshSurface surface;

	private bool rebuildRequested;

	private float currentTimer;

	private float rebuildIncrement = 5f;

	private float navmeshDist = 3f;

	private float downCastDist = 50f;

	private float portalYTolerance = 0.2f;

	private NavMeshHit hit;

	private NavMeshHit hit2;

	private List<Vector3> pipePortalNodes = new List<Vector3>();

	private Dictionary<Vector3, Vector3> pipePortalNodeDict = new Dictionary<Vector3, Vector3>();

	private Dictionary<ulong, List<Vector3>> pipeIDToPortalNodePositionsDict = new Dictionary<ulong, List<Vector3>>();

	private Dictionary<ulong, NavMeshLinkInstance> pipeIDToNavmeshLink = new Dictionary<ulong, NavMeshLinkInstance>();

	private List<ulong> denIDList = new List<ulong>();

	private List<Vector3> denPortalNodes = new List<Vector3>();

	private Dictionary<ulong, List<Vector3>> denIDToPortalNodePositionsDict = new Dictionary<ulong, List<Vector3>>();

	private Dictionary<ulong, NavMeshLinkInstance> denIDToNavmeshLink = new Dictionary<ulong, NavMeshLinkInstance>();

	private void Awake()
	{
		surface = GetComponent<NavMeshSurface>();
	}

	private void LateUpdate()
	{
		if (!rebuildRequested)
		{
			return;
		}
		if (currentTimer > 0f)
		{
			currentTimer -= Time.deltaTime;
			if (currentTimer > 0f)
			{
				return;
			}
		}
		RebuildInternal();
	}

	private void OnDestroy()
	{
		foreach (ulong key in pipeIDToNavmeshLink.Keys)
		{
			NavMesh.RemoveLink(pipeIDToNavmeshLink[key]);
		}
		foreach (ulong key2 in denIDToNavmeshLink.Keys)
		{
			NavMesh.RemoveLink(denIDToNavmeshLink[key2]);
		}
	}

	public void Rebuild()
	{
		rebuildRequested = true;
	}

	public void RebuildImmediate()
	{
		RebuildInternal();
	}

	private void RebuildInternal()
	{
		currentTimer = rebuildIncrement;
		surface.BuildNavMesh();
		rebuildRequested = false;
	}

	public bool IsPointOnNavmesh(ref Vector3 point)
	{
		bool num = NavMesh.SamplePosition(point, out hit, 0.5f, -1);
		if (num)
		{
			point = hit.position;
		}
		return num;
	}

	public bool GetNearestPointOnNavmesh(ref Vector3 point, bool raycast = true)
	{
		if (IsPointOnNavmesh(ref point))
		{
			return true;
		}
		NavMeshHit navMeshHit2;
		if (RaycastUtil.NavmeshCast(point, Vector3.down, out var hitInfo, downCastDist))
		{
			Vector3 point2 = hitInfo.point;
			if (IsPointOnNavmesh(ref point2))
			{
				if (!raycast || CanCastToPoint(point2, point))
				{
					point = point2;
					return true;
				}
				return false;
			}
			if (NavMesh.SamplePosition(hitInfo.point, out var navMeshHit, navmeshDist, -1))
			{
				if (!raycast || CanCastToPoint(navMeshHit.position, point))
				{
					point = navMeshHit.position;
					return true;
				}
				return false;
			}
		}
		else if (NavMesh.SamplePosition(point, out navMeshHit2, navmeshDist, -1))
		{
			if (!raycast || CanCastToPoint(navMeshHit2.position, point))
			{
				point = navMeshHit2.position;
				return true;
			}
			return false;
		}
		return false;
	}

	private bool CanCastToPoint(Vector3 start, Vector3 end)
	{
		return !RaycastUtil.NavmeshPipeCast(start, end - start, Vector3.Distance(start, end));
	}

	public PathPosition[] GetPath(GameObject dog, Vector3 dest)
	{
		if (rebuildRequested)
		{
			RebuildInternal();
		}
		if (dest.x >= float.PositiveInfinity)
		{
			return new PathPosition[0];
		}
		bool flag = false;
		if (dog.CompareTag(Tags.DOG))
		{
			flag = true;
		}
		Vector3 point = ((!flag) ? dog.GetComponentInChildren<Rigidbody>().transform.position : dog.GetComponent<LegController>().bodyFront.transform.position);
		if (!GetNearestPointOnNavmesh(ref point))
		{
			return new PathPosition[0];
		}
		GameObject gameObject = new GameObject("Temporary Navmesh Agent");
		gameObject.transform.position = point;
		NavMeshAgent navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
		if (flag)
		{
			navMeshAgent.radius = dog.GetComponent<LegController>().GetDogBodyHalfExtents().x;
		}
		else
		{
			navMeshAgent.radius = dog.GetComponent<BoundingBoxComponent>().GetBoxSize().x;
		}
		NavMeshPath navMeshPath = new NavMeshPath();
		if (GetNearestPointOnNavmesh(ref dest))
		{
			navMeshAgent.CalculatePath(dest, navMeshPath);
			Object.Destroy(gameObject);
			if (navMeshPath.status != NavMeshPathStatus.PathComplete)
			{
				return new PathPosition[0];
			}
			ulong? num = null;
			ulong? num2 = null;
			ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
			for (int i = 0; i < denIDList.Count; i++)
			{
				BoundingBoxComponent component = DenInteriorManager.GetInteriorForDenID(denIDList[i]).GetComponent<BoundingBoxComponent>();
				if (!num2.HasValue && component.IsPointInsideBox(point))
				{
					num2 = denIDList[i];
				}
				if (!num.HasValue && component.IsPointInsideBox(dest))
				{
					num = denIDList[i];
					if (!registrationScript.GetPlaceableObjectForUID(denIDList[i]).GetComponent<DogDen>().CanAddOccupant())
					{
						return new PathPosition[0];
					}
				}
			}
			PathPosition[] array = new PathPosition[navMeshPath.corners.Length];
			for (int j = 0; j < navMeshPath.corners.Length; j++)
			{
				array[j] = new PathPosition(navMeshPath.corners[j]);
			}
			array = SmoothPath(array);
			array = InsertPipeNodes(array);
			if (num2 != num && (num2.HasValue || num.HasValue))
			{
				array = InsertDenNodes(array);
			}
			return array;
		}
		Object.Destroy(gameObject);
		return new PathPosition[0];
	}

	public void AddPortalForPipe(CreatedPipe createdPipeRef)
	{
		if ((createdPipeRef.startingWall == WallDirection.UP && createdPipeRef.endingWall == WallDirection.UP) || (createdPipeRef.startingLabel == ConnectorLabel.PLUS_Y && createdPipeRef.endingLabel == ConnectorLabel.PLUS_Y) || (createdPipeRef.startingWall == WallDirection.UP && createdPipeRef.endingLabel == ConnectorLabel.PLUS_Y) || (createdPipeRef.endingWall == WallDirection.UP && createdPipeRef.startingLabel == ConnectorLabel.PLUS_Y))
		{
			return;
		}
		RebuildImmediate();
		ulong uID = createdPipeRef.pipeRef.GetComponent<BuildObjectInfo>().GetUID();
		NavMeshLinkData link = default(NavMeshLinkData);
		Pipe component = createdPipeRef.pipeRef.GetComponent<Pipe>();
		pipeIDToPortalNodePositionsDict[uID] = new List<Vector3>();
		if (createdPipeRef.startingWall == WallDirection.UP)
		{
			link.bidirectional = false;
			Vector3 point = component.GetFirstSegmentEntranceCenter();
			Vector3 point2 = component.GetLastSegmentEntranceCenter();
			GetNearestPointOnNavmesh(ref point, raycast: false);
			GetNearestPointOnNavmesh(ref point2, raycast: false);
			link.endPosition = point;
			link.startPosition = point2;
			pipePortalNodes.Add(link.startPosition);
			pipePortalNodeDict[link.startPosition] = component.GetLastSegmentCenter();
			pipeIDToPortalNodePositionsDict[uID].Add(link.startPosition);
		}
		else if (createdPipeRef.endingWall == WallDirection.UP)
		{
			link.bidirectional = false;
			Vector3 point3 = component.GetLastSegmentEntranceCenter();
			Vector3 point4 = component.GetFirstSegmentEntranceCenter();
			GetNearestPointOnNavmesh(ref point3, raycast: false);
			GetNearestPointOnNavmesh(ref point4, raycast: false);
			link.endPosition = point3;
			link.startPosition = point4;
			pipePortalNodes.Add(link.startPosition);
			pipePortalNodeDict[link.startPosition] = component.GetFirstSegmentCenter();
			pipeIDToPortalNodePositionsDict[uID].Add(link.startPosition);
		}
		else
		{
			Vector3 point5;
			Vector3 point6;
			if (createdPipeRef.startingLabel == ConnectorLabel.PLUS_Y)
			{
				link.bidirectional = false;
				point5 = component.GetFirstSegmentEntranceCenter();
				point6 = component.GetLastSegmentEntranceCenter();
			}
			else if (createdPipeRef.endingLabel == ConnectorLabel.PLUS_Y)
			{
				link.bidirectional = false;
				point5 = component.GetLastSegmentEntranceCenter();
				point6 = component.GetFirstSegmentEntranceCenter();
			}
			else
			{
				link.bidirectional = true;
				point5 = component.GetLastSegmentEntranceCenter();
				point6 = component.GetFirstSegmentEntranceCenter();
			}
			GetNearestPointOnNavmesh(ref point5, raycast: false);
			GetNearestPointOnNavmesh(ref point6, raycast: false);
			link.endPosition = point5;
			link.startPosition = point6;
			if (createdPipeRef.startingLabel == ConnectorLabel.PLUS_Y)
			{
				pipePortalNodeDict[link.endPosition] = component.GetFirstSegmentCenter();
				pipePortalNodeDict[link.startPosition] = component.GetLastSegmentCenter();
			}
			else
			{
				pipePortalNodeDict[link.endPosition] = component.GetLastSegmentCenter();
				pipePortalNodeDict[link.startPosition] = component.GetFirstSegmentCenter();
			}
			pipePortalNodes.Add(link.endPosition);
			pipePortalNodes.Add(link.startPosition);
			pipeIDToPortalNodePositionsDict[uID].Add(link.endPosition);
			pipeIDToPortalNodePositionsDict[uID].Add(link.startPosition);
		}
		link.costModifier = 1f;
		NavMeshLinkInstance value = NavMesh.AddLink(link);
		pipeIDToNavmeshLink[uID] = value;
	}

	public void RemovePortalForPipe(GameObject pipeRef)
	{
		ulong uID = pipeRef.GetComponent<BuildObjectInfo>().GetUID();
		if (!pipeIDToNavmeshLink.ContainsKey(uID))
		{
			return;
		}
		if (pipeIDToPortalNodePositionsDict.ContainsKey(uID))
		{
			for (int i = 0; i < pipeIDToPortalNodePositionsDict[uID].Count; i++)
			{
				pipePortalNodes.Remove(pipeIDToPortalNodePositionsDict[uID][i]);
				pipePortalNodeDict.Remove(pipeIDToPortalNodePositionsDict[uID][i]);
			}
			pipeIDToPortalNodePositionsDict.Remove(uID);
		}
		NavMesh.RemoveLink(pipeIDToNavmeshLink[uID]);
		pipeIDToNavmeshLink.Remove(uID);
	}

	public void AddPortalForDen(GameObject den)
	{
		RebuildImmediate();
		ulong uID = den.GetComponent<PlacedObjectID>().GetUID();
		NavMeshLinkData link = new NavMeshLinkData
		{
			bidirectional = true
		};
		denIDToPortalNodePositionsDict[uID] = new List<Vector3>();
		Vector3 point = den.GetComponent<InteractibleDogDen>().GetInteractionPoint();
		Vector3 point2 = DenInteriorManager.GetInteriorForDen(den).GetComponent<DogDenInterior>().entranceTransform.position;
		GetNearestPointOnNavmesh(ref point2, raycast: false);
		GetNearestPointOnNavmesh(ref point, raycast: false);
		link.endPosition = point2;
		link.startPosition = point;
		denIDList.Add(uID);
		denPortalNodes.Add(link.endPosition);
		denPortalNodes.Add(link.startPosition);
		denIDToPortalNodePositionsDict[uID].Add(link.endPosition);
		denIDToPortalNodePositionsDict[uID].Add(link.startPosition);
		link.costModifier = -1f;
		NavMeshLinkInstance value = NavMesh.AddLink(link);
		denIDToNavmeshLink[uID] = value;
	}

	public void RemovePortalForDenUID(ulong denUID)
	{
		if (!denIDToNavmeshLink.ContainsKey(denUID))
		{
			Debug.LogError("Attempting to remove a navmesh portal for den " + denUID + " but none exists.");
			return;
		}
		if (denIDToPortalNodePositionsDict.ContainsKey(denUID))
		{
			for (int i = 0; i < denIDToPortalNodePositionsDict[denUID].Count; i++)
			{
				denPortalNodes.Remove(denIDToPortalNodePositionsDict[denUID][i]);
			}
			denIDToPortalNodePositionsDict.Remove(denUID);
		}
		NavMesh.RemoveLink(denIDToNavmeshLink[denUID]);
		denIDToNavmeshLink.Remove(denUID);
		denIDList.Remove(denUID);
	}

	public PathPosition[] SmoothPath(PathPosition[] inPath)
	{
		if (inPath.Length < 3)
		{
			return inPath;
		}
		PathPosition[] array = new PathPosition[inPath.Length];
		inPath.CopyTo(array, 0);
		for (int i = 2; i < inPath.Length; i++)
		{
			Vector3 position = inPath[i - 2].position;
			Vector3 position2 = inPath[i - 1].position;
			Vector3 position3 = inPath[i].position;
			if (GetPipePortalNodeIndex(position2) != -1 || GetDenPortalNodeIndex(position2) != -1)
			{
				continue;
			}
			float num = Mathf.Min((Vector3.Distance(position, position2) + Vector3.Distance(position2, position3)) / 4f, 2f);
			Vector3 vector = Vector3.Normalize(Vector3.Normalize(position2 - position) + Vector3.Normalize(position2 - position3));
			Vector3 vector2 = position2 + vector * num;
			if (!NavMesh.SamplePosition(vector2, out hit, 0.1f, -1))
			{
				continue;
			}
			NavMesh.FindClosestEdge(position2, out hit, -1);
			NavMesh.FindClosestEdge(vector2, out hit2, -1);
			if (!(hit.position != hit2.position))
			{
				array[i - 1] = new PathPosition(new Vector3(vector2.x, position2.y, vector2.z));
				if (debugVis)
				{
					Debug.DrawLine(position2, vector2, Color.red, 10f);
				}
			}
		}
		if (debugVis)
		{
			for (int j = 1; j < inPath.Length; j++)
			{
				Debug.DrawLine(inPath[j].position, inPath[j - 1].position, Color.white, 10f);
			}
		}
		return array;
	}

	private PathPosition[] InsertPipeNodes(PathPosition[] path)
	{
		List<PathPosition> list = new List<PathPosition>();
		for (int i = 0; i < path.Length; i++)
		{
			list.Add(path[i]);
			int pipePortalNodeIndex = GetPipePortalNodeIndex(path[i].position);
			if (pipePortalNodeIndex != -1)
			{
				list.Add(new PathPosition(pipePortalNodeDict[pipePortalNodes[pipePortalNodeIndex]]));
				if (i + 1 < path.Length)
				{
					i++;
					list.Add(path[i]);
				}
			}
		}
		PathPosition[] array = new PathPosition[list.Count];
		list.CopyTo(array);
		return array;
	}

	private PathPosition[] InsertDenNodes(PathPosition[] path)
	{
		bool flag = false;
		for (int i = 0; i < path.Length; i++)
		{
			if (!flag && GetDenPortalNodeIndex(path[i].position) != -1)
			{
				for (int j = 0; j < denIDList.Count; j++)
				{
					if (MathUtil.Vector3AlmostEqual(denIDToPortalNodePositionsDict[denIDList[j]][0], path[i].position, portalYTolerance))
					{
						path[i] = new PathPosition(path[i].position, denIDList[j], exterior: false);
						break;
					}
					if (MathUtil.Vector3AlmostEqual(denIDToPortalNodePositionsDict[denIDList[j]][1], path[i].position, portalYTolerance))
					{
						path[i] = new PathPosition(path[i].position, denIDList[j]);
						break;
					}
				}
				flag = true;
			}
			else
			{
				flag = false;
			}
		}
		return path;
	}

	private int GetPipePortalNodeIndex(Vector3 val)
	{
		for (int i = 0; i < pipePortalNodes.Count; i++)
		{
			if (MathUtil.Vector3AlmostEqual(pipePortalNodes[i], val, portalYTolerance))
			{
				return i;
			}
		}
		return -1;
	}

	private int GetDenPortalNodeIndex(Vector3 val)
	{
		for (int i = 0; i < denPortalNodes.Count; i++)
		{
			if (MathUtil.Vector3AlmostEqual(denPortalNodes[i], val, portalYTolerance))
			{
				return i;
			}
		}
		return -1;
	}
}
