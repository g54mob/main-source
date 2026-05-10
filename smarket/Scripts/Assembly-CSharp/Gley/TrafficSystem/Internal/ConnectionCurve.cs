using System;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	[Serializable]
	public class ConnectionCurve : ConnectionCurveBase
	{
		[HideInInspector]
		public string name;

		public Transform holder;

		public Path curve;

		public Road fromRoad;

		public Road toRoad;

		public int fromIndex;

		public int toIndex;

		public bool draw;

		public bool drawWaypoints;

		public Vector3 inPosition;

		public Vector3 outPosition;

		public bool inView;

		public ConnectionCurve(Path curve, Road fromRoad, int fromIndex, Road toRoad, int toIndex, bool draw, Transform holder)
		{
		}

		public bool VerifyAssignments()
		{
			return false;
		}

		public WaypointSettings GetOutConnector()
		{
			return null;
		}

		public WaypointSettings GetInConnector()
		{
			return null;
		}

		public string GetName()
		{
			return null;
		}

		public Path GetCurve()
		{
			return null;
		}

		public Vector3 GetOffset()
		{
			return default(Vector3);
		}

		public Transform GetHolder()
		{
			return null;
		}

		public bool ContainsRoad(Road road)
		{
			return false;
		}

		public bool ContainsLane(Road road, int laneIndex)
		{
			return false;
		}
	}
}
