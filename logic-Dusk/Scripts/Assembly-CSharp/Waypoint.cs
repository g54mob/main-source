using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Waypoint : MonoBehaviour
{
	public List<WaypointEdge> WaypointEdges = new List<WaypointEdge>();

	public Door Door;

	public Room Room;

	public WaypointTypeEnum WaypointType;

	public List<Waypoint> ConnectedWaypoints = new List<Waypoint>();

	public List<Waypoint> ConnectedRooms = new List<Waypoint>();

	public bool IsMainRoomWaypoint;

	public Waypoint AuxWaypoint { get; set; }

	private void Awake()
	{
	}

	private void Start()
	{
		CalculateDistancesToConnectedWaypoints();
	}

	private void Update()
	{
	}

	public bool IsBlocked()
	{
		bool result = false;
		if (WaypointType == WaypointTypeEnum.Door && Door.state == DoorState.Closed)
		{
			result = true;
		}
		return result;
	}

	public void CalculateDistancesToConnectedWaypoints()
	{
		WaypointEdges.Clear();
		int count = ConnectedWaypoints.Count;
		for (int i = 0; i < count; i++)
		{
			Waypoint waypoint = ConnectedWaypoints[i];
			if (waypoint != null)
			{
				WaypointEdge item = new WaypointEdge(this, waypoint, Vector3.Distance(base.transform.position, waypoint.transform.position));
				WaypointEdges.Add(item);
			}
		}
	}

	public override string ToString()
	{
		return string.Format("{0}, {1}, {2}, {3}", base.name, WaypointType, Room, Door);
	}
}
