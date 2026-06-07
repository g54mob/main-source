using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERLaneConnector
	{
		public Vector3 connectorStart;

		public Vector3 connectorEnd;

		public Vector3 connectorStartLocal;

		public Vector3 connectorEndLocal;

		public Vector3[] points = null;

		public Vector3[] localPoints = null;

		public int startConnectionIndex;

		public int startLaneIndex = 0;

		public int endLaneIndex = 0;

		public int endLaneIndexRelative = 0;

		public int endConnectionIndex;

		public ERLane laneType;

		public ERDirectionType laneDirection;

		public float startOffset = 0f;

		public float endOffset = 0f;

		public float strength = 1.5f;

		public bool mainConnection = false;

		public bool stop = false;

		public float speedLimit = 0f;

		public float minSpeed = 0f;

		public float maxSpeed = 0f;

		public float rtSpeedLimit = 0f;

		public bool customSpeedLimit = false;

		public static ERLaneConnector CreateInstance()
		{
			return new ERLaneConnector();
		}

		public static List<ERLaneConnector> GetLaneConnectors(ERLaneData laneData, int index)
		{
			List<ERLaneConnector> list = new List<ERLaneConnector>();
			for (int i = 0; i < laneData.connectors.Count; i++)
			{
				if (laneData.connectors[i].startLaneIndex == index)
				{
					list.Add(laneData.connectors[i]);
				}
			}
			return list;
		}

		public void CloneLaneConnector(ERLaneConnector conn)
		{
			conn.connectorStart = connectorStart;
			conn.connectorEnd = connectorEnd;
			conn.connectorStartLocal = connectorStartLocal;
			conn.connectorEndLocal = connectorEndLocal;
			conn.points = points;
			conn.localPoints = localPoints;
			conn.startConnectionIndex = startConnectionIndex;
			conn.startLaneIndex = startLaneIndex;
			conn.endLaneIndex = endLaneIndex;
			conn.endLaneIndexRelative = endLaneIndexRelative;
			conn.endConnectionIndex = endConnectionIndex;
			conn.laneType = laneType;
			conn.laneDirection = laneDirection;
			conn.startOffset = startOffset;
			conn.endOffset = endOffset;
			conn.strength = strength;
			conn.mainConnection = mainConnection;
			conn.stop = stop;
			conn.speedLimit = speedLimit;
			conn.minSpeed = minSpeed;
			conn.maxSpeed = maxSpeed;
		}
	}
}
