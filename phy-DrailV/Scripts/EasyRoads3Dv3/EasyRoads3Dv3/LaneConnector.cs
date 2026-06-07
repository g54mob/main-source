using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class LaneConnector
	{
		public List<Vector3> vecs = new List<Vector3>();

		public List<LaneConnector> connectors = new List<LaneConnector>();

		public ERLane laneType;

		public ERDirectionType laneDirection;
	}
}
