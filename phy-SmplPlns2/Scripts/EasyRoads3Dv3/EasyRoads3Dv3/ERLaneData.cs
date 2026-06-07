using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERLaneData
	{
		public Vector3[] points;

		public List<ERLaneConnector> connectors = new List<ERLaneConnector>();

		public ERLane laneType;

		public int laneIndex = 0;

		public ERLaneDirection direction;

		public static ERLaneData CreateInstance()
		{
			return new ERLaneData();
		}

		public static ERLaneData OCDCDCODCO(List<ERLaneData> laneData, int index)
		{
			for (int i = 0; i < laneData.Count; i++)
			{
				if (laneData[i].laneIndex == index)
				{
					return laneData[i];
				}
			}
			return null;
		}

		public bool Exists(int index, int lane)
		{
			for (int i = 0; i < connectors.Count; i++)
			{
				if (connectors[i].endConnectionIndex == index && connectors[i].endLaneIndex == lane)
				{
					return true;
				}
			}
			return false;
		}
	}
}
