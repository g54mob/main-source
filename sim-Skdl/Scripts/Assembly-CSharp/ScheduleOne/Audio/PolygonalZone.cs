using System;
using UnityEngine;

namespace ScheduleOne.Audio
{
	public class PolygonalZone : MonoBehaviour
	{
		public Transform PointContainer;

		public bool IsClosed;

		public float VerticalSize;

		[Header("Debug")]
		public Color ZoneColor;

		protected Vector3[] points;

		protected virtual void Awake()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public bool IsPointInsidePolygon(Vector3 point)
		{
			return false;
		}

		public bool IsPointInsideZone(Vector3 point)
		{
			return false;
		}

		public float GetDistanceToClosestPointOnZone(Vector3 source)
		{
			return 0f;
		}

		protected Vector3[] GetPoints()
		{
			return null;
		}

		protected bool DoBoundsContainPoint(Vector3 point)
		{
			return false;
		}

		protected Tuple<Vector3, Vector3> GetBoundingPoints()
		{
			return null;
		}

		protected int CalculateWindingNumber(Vector2[] polygon, Vector2 point)
		{
			return 0;
		}

		protected Vector3 GetClosestPointOnPolygon(Vector3[] polyPoints, Vector3 point)
		{
			return default(Vector3);
		}
	}
}
