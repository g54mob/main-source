using System;
using UnityEngine;

namespace ScheduleOne.Audio
{
	public class Zone : MonoBehaviour
	{
		public const float UPDATE_INTERVAL = 0.25f;

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

		public bool IsPointInsidePolygon(Vector3 point)
		{
			return false;
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
