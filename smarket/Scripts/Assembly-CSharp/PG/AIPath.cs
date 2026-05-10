using System;
using System.Collections.Generic;
using UnityEngine;

namespace PG
{
	public class AIPath : MonoBehaviour
	{
		public struct RoutePoint
		{
			public Vector3 Position;

			public Vector3 Direction;

			public float OvertakeZoneLeft;

			public float OvertakeZoneRight;

			public float SpeedLimit;

			public RoutePoint(Vector3 position, Vector3 direction, float overtakeZoneLeft, float overtakeZoneRight, float speedLimit)
			{
				Position = default(Vector3);
				Direction = default(Vector3);
				OvertakeZoneLeft = 0f;
				OvertakeZoneRight = 0f;
				SpeedLimit = 0f;
			}
		}

		[Serializable]
		public struct WaypointData
		{
			public Transform Point;

			public float OvertakeZoneLeft;

			public float OvertakeZoneRight;

			public float SpeedLimit;

			public Vector3 position => default(Vector3);

			public Vector3 localPosition => default(Vector3);

			public WaypointData(Transform point, float overtakeZoneLeft = 2f, float overtakeZoneRight = 2f, float speedLimit = 1f / 0f)
			{
				Point = null;
				OvertakeZoneLeft = 0f;
				OvertakeZoneRight = 0f;
				SpeedLimit = 0f;
			}
		}

		public bool LoopedPath;

		public float MaxSpeedLimit;

		public BaseAIConfigAsset AIConfigAsset;

		[Header("Waypoints settings")]
		public List<WaypointData> Waypoints;

		public static List<AIPath> AIPaths;

		private int PointsCount;

		private List<Vector3> Points;

		private List<float> Distances;

		private int P0n;

		private int P1n;

		private int P2n;

		private int P3n;

		private float I;

		private Vector3 P0;

		private Vector3 P1;

		private Vector3 P2;

		private Vector3 P3;

		public static AIPath FirstPath { get; private set; }

		public Transform GetLastPoint => null;

		public float Length { get; private set; }

		private void Awake()
		{
		}

		public RoutePoint GetRoutePoint(float dist)
		{
			return default(RoutePoint);
		}

		public Vector3 GetRoutePosition(float dist, out float overtakeZoneLeft, out float overtakeZoneRight, out float speedLimit)
		{
			overtakeZoneLeft = default(float);
			overtakeZoneRight = default(float);
			speedLimit = default(float);
			return default(Vector3);
		}

		private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float i)
		{
			return default(Vector3);
		}

		private void CachePositionsAndDistances()
		{
		}
	}
}
