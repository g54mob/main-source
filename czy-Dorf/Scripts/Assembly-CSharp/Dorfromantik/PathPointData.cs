using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	[Serializable]
	public class PathPointData
	{
		public Vector3 localPosition;

		public VehiclePathPointType type;

		public int localEdge;

		public List<int> connectedPathPoints;

		public PathPointData(VehiclePathPoint pathPoint, List<VehiclePathPoint> allPathPoints)
		{
			localPosition = pathPoint.transform.localPosition;
			type = pathPoint.type;
			localEdge = pathPoint.localEdge;
			connectedPathPoints = new List<int>();
			foreach (VehiclePathPoint connectedPathPoint in pathPoint.connectedPathPoints)
			{
				connectedPathPoints.Add(allPathPoints.IndexOf(connectedPathPoint));
			}
		}
	}
}
