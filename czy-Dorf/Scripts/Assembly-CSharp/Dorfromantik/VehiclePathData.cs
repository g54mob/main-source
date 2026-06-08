using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	[Serializable]
	public class VehiclePathData
	{
		public int entranceLocalEdge;

		public int exitLocalEdge;

		private int _003CExitWorldEdge_003Ek__BackingField;

		private int _003CEntranceWorldEdge_003Ek__BackingField;

		private bool _003CPlaced_003Ek__BackingField;

		[SerializeField]
		private int priority;

		[SerializeField]
		private bool entranceBlocked;

		[SerializeField]
		private bool exitBlocked;

		public List<Vector3> pathPoints;

		private List<Vector3> worldPathPoints = new List<Vector3>();

		public int ExitWorldEdge
		{
			get
			{
				return _003CExitWorldEdge_003Ek__BackingField;
			}
			private set
			{
				_003CExitWorldEdge_003Ek__BackingField = value;
			}
		}

		public int EntranceWorldEdge
		{
			get
			{
				return _003CEntranceWorldEdge_003Ek__BackingField;
			}
			private set
			{
				_003CEntranceWorldEdge_003Ek__BackingField = value;
			}
		}

		private bool Placed
		{
			set
			{
				_003CPlaced_003Ek__BackingField = value;
			}
		}

		public int LastPathPointIndex => pathPoints.Count - 1;

		public int Priority
		{
			get
			{
				return priority;
			}
			private set
			{
				priority = value;
			}
		}

		private bool EntranceBlocked
		{
			set
			{
				entranceBlocked = value;
			}
		}

		public bool ExitBlocked
		{
			get
			{
				return exitBlocked;
			}
			private set
			{
				exitBlocked = value;
			}
		}

		public VehiclePathData(List<PathPointData> vehiclePathPoints, int priority)
		{
			entranceLocalEdge = vehiclePathPoints[0].localEdge;
			exitLocalEdge = Enumerable.Last(vehiclePathPoints).localEdge;
			pathPoints = new List<Vector3>();
			foreach (PathPointData vehiclePathPoint in vehiclePathPoints)
			{
				pathPoints.Add(vehiclePathPoint.localPosition);
			}
			Priority = priority;
		}

		public void ApplyRotation(ElementGroupSegment segment)
		{
			int rotationIndex = segment.RotationIndex + segment.Tile.RotationIndex;
			Transform transform = segment.transform;
			_ = segment.Tile.transform;
			ExitWorldEdge = GridCalculator.RotatedDirection(exitLocalEdge, rotationIndex);
			EntranceWorldEdge = GridCalculator.RotatedDirection(entranceLocalEdge, rotationIndex);
			worldPathPoints = new List<Vector3>();
			foreach (Vector3 pathPoint in pathPoints)
			{
				worldPathPoints.Add(transform.TransformPoint(pathPoint));
			}
			Placed = true;
		}

		public Vector3 GetPathPointPosition(int index, Space space)
		{
			if (space == Space.Self)
			{
				return pathPoints[index];
			}
			return worldPathPoints[index];
		}

		public void BlockEdge(int localEdge, bool newBlocked)
		{
			if (localEdge == -1 || entranceLocalEdge == localEdge)
			{
				EntranceBlocked = newBlocked;
			}
			if (localEdge == -1 || exitLocalEdge == localEdge)
			{
				ExitBlocked = newBlocked;
			}
		}
	}
}
