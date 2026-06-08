using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class VehicleSegmentPath : MonoBehaviour
{
	public GroupType groupType;

	public List<VehiclePathPoint> pathPoints;

	public int EntranceLocalEdge => EntrancePoint.localEdge;

	public int ExitLocalEdge => ExitPoint.localEdge;

	public VehiclePathPoint ExitPoint => pathPoints[pathPoints.Count - 1];

	public int ExitWorldEdge => ExitPoint.worldEdge;

	public int EntranceWorldEdge => EntrancePoint.worldEdge;

	public VehiclePathPoint EntrancePoint => pathPoints[0];

	public bool IsCompleted()
	{
		if (pathPoints != null && pathPoints.Count >= 2)
		{
			return pathPoints[pathPoints.Count - 1].type == VehiclePathPointType.entrance;
		}
		return false;
	}

	public void AddPoint(VehiclePathPoint pointToAdd)
	{
		pathPoints.Add(pointToAdd);
	}

	public Vector3 GetPointPosition(int nextPathPointIndex)
	{
		return pathPoints[nextPathPointIndex].transform.position;
	}

	public void Initialize(GroupType segmentGroupType, List<VehiclePathPoint> vehiclePathPoints)
	{
		groupType = segmentGroupType;
		pathPoints = new List<VehiclePathPoint>(vehiclePathPoints);
	}

	public void UpdateName()
	{
		base.gameObject.name = $"VehiclePath_{EntranceLocalEdge}-{ExitPoint.localEdge}";
	}

	public VehiclePathPoint GetPoint(int nextPathPointIndex)
	{
		return pathPoints[nextPathPointIndex];
	}
}
