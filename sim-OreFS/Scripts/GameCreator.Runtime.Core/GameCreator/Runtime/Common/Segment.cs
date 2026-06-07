using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct Segment
	{
		public static readonly Segment NONE = new Segment(Vector3.zero, Vector3.zero);

		[SerializeField]
		private Vector3 m_PointA;

		[SerializeField]
		private Vector3 m_PointB;

		public Vector3 PointA => m_PointA;

		public Vector3 PointB => m_PointB;

		public Vector3 Get(float t)
		{
			return Get(this, t);
		}

		public float LargeDistance(Segment other)
		{
			float num = Vector3.Distance(PointA, other.PointA);
			float num2 = Vector3.Distance(PointB, other.PointB);
			if (!(num > num2))
			{
				return num2;
			}
			return num;
		}

		public float SmallDistance(Segment other)
		{
			float num = Vector3.Distance(PointA, other.PointA);
			float num2 = Vector3.Distance(PointB, other.PointB);
			if (!(num < num2))
			{
				return num2;
			}
			return num;
		}

		public Segment Lerp(Segment other, float t)
		{
			return new Segment(Vector3.Lerp(PointA, other.PointA, t), Vector3.Lerp(PointB, other.PointB, t));
		}

		public static Vector3 Get(Vector3 pointA, Vector3 pointB, float t)
		{
			return Get(new Segment(pointA, pointB), t);
		}

		public static Vector3 Get(Segment segment, float t)
		{
			return Vector3.Lerp(segment.m_PointA, segment.m_PointB, t);
		}

		public Segment(Vector3 pointA, Vector3 pointB)
		{
			m_PointA = pointA;
			m_PointB = pointB;
		}

		public void DrawGizmos(Transform transform)
		{
			Gizmos.DrawLine(transform.TransformPoint(m_PointA), transform.TransformPoint(m_PointB));
		}
	}
}
