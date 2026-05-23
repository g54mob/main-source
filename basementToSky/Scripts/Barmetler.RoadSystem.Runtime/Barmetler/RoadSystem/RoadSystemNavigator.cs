using System.Collections.Generic;
using Barmetler.RoadSystem.Util;
using Unity.Profiling;
using UnityEngine;

namespace Barmetler.RoadSystem
{
	public class RoadSystemNavigator : MonoBehaviour
	{
		public RoadSystem currentRoadSystem;

		public Vector3 Goal = Vector3.zero;

		public float GraphStepSize = 1f;

		public float MinDistanceYScale = 1f;

		public float MinDistanceToRoadToConnect = 10f;

		private AsyncUpdater<List<Bezier.OrientedPoint>> _currentPoints;

		private static readonly ProfilerMarker GetNewWayPointsPerfMarker = new ProfilerMarker("RoadSystemNavigator.cs GetNewWayPoints");

		public List<Bezier.OrientedPoint> CurrentPoints { get; private set; } = new List<Bezier.OrientedPoint>();

		private void Awake()
		{
			_currentPoints = new AsyncUpdater<List<Bezier.OrientedPoint>>(this, GetNewWayPoints, new List<Bezier.OrientedPoint>(), 1f / 144f);
		}

		private void Update()
		{
			_currentPoints.Update();
		}

		private void FixedUpdate()
		{
			List<Bezier.OrientedPoint> data = _currentPoints.GetData();
			if (data != CurrentPoints)
			{
				CurrentPoints = data;
				RemovePointsAhead();
			}
			RemovePointsBehind();
		}

		public float GetMinDistance(out Road road, out Vector3 closestPoint, out float distanceAlongRoad)
		{
			if (!currentRoadSystem)
			{
				road = null;
				closestPoint = Vector3.zero;
				distanceAlongRoad = 0f;
				return float.PositiveInfinity;
			}
			return currentRoadSystem.GetMinDistance(base.transform.position, Mathf.Max(0.1f, GraphStepSize), MinDistanceYScale, out road, out closestPoint, out distanceAlongRoad);
		}

		public float GetMinDistance(out Intersection intersection, out RoadAnchor anchor, out Vector3 closestPoint, out float distanceAlongRoad)
		{
			if (!currentRoadSystem)
			{
				intersection = null;
				anchor = null;
				closestPoint = Vector3.zero;
				distanceAlongRoad = 0f;
				return float.PositiveInfinity;
			}
			return currentRoadSystem.GetMinDistance(base.transform.position, MinDistanceYScale, out intersection, out anchor, out closestPoint, out distanceAlongRoad);
		}

		private void RemovePointsBehind()
		{
			Vector3 position = base.transform.position;
			int i;
			for (i = 0; i < CurrentPoints.Count - 1; i++)
			{
				float sqrMagnitude = (CurrentPoints[i].position - position).sqrMagnitude;
				if (sqrMagnitude < (CurrentPoints[i + 1].position - position).sqrMagnitude && sqrMagnitude > GraphStepSize / 2f * GraphStepSize / 2f)
				{
					break;
				}
			}
			if (i > 0)
			{
				CurrentPoints.RemoveRange(0, i);
			}
		}

		private void RemovePointsAhead()
		{
			Vector3 goal = Goal;
			int i;
			for (i = 0; i < CurrentPoints.Count - 1; i++)
			{
				float sqrMagnitude = (CurrentPoints[CurrentPoints.Count - 1 - i].position - goal).sqrMagnitude;
				if (sqrMagnitude < (CurrentPoints[CurrentPoints.Count - 1 - i - 1].position - goal).sqrMagnitude && sqrMagnitude > GraphStepSize / 2f * GraphStepSize / 2f)
				{
					break;
				}
			}
			if (i > 0)
			{
				CurrentPoints.RemoveRange(CurrentPoints.Count - i, i);
			}
		}

		public void CalculateWayPointsSync()
		{
			CurrentPoints = GetNewWayPoints();
		}

		private List<Bezier.OrientedPoint> GetNewWayPoints()
		{
			using (GetNewWayPointsPerfMarker.Auto())
			{
				return currentRoadSystem.FindPath(base.transform.position, Goal, null, MinDistanceYScale, Mathf.Max(0.1f, GraphStepSize), MinDistanceToRoadToConnect);
			}
		}
	}
}
