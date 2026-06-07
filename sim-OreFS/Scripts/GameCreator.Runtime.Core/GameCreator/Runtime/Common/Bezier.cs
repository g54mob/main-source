using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct Bezier
	{
		private const float GIZMOS_RESOLUTION = 0.02f;

		[SerializeField]
		private Vector3 m_PointA;

		[SerializeField]
		private Vector3 m_ControlA;

		[SerializeField]
		private Vector3 m_PointB;

		[SerializeField]
		private Vector3 m_ControlB;

		public Vector3 PointA => m_PointA;

		public Vector3 PointB => m_PointB;

		public Vector3 ControlA => m_ControlA;

		public Vector3 ControlB => m_ControlB;

		public Vector3 Get(float t)
		{
			return Get(this, t);
		}

		public static Vector3 Get(Vector3 pA, Vector3 pB, Vector3 cA, Vector3 cB, float t)
		{
			return Get(new Bezier(pA, pB, cA, cB), t);
		}

		public static Vector3 Get(Bezier bezier, float t)
		{
			t = Mathf.Clamp01(t);
			float num = t * t;
			float num2 = t * num;
			float num3 = 1f - t;
			float num4 = num3 * num3;
			return num3 * num4 * bezier.m_PointA + 3f * num4 * t * (bezier.PointA + bezier.m_ControlA) + 3f * num3 * num * (bezier.PointB + bezier.m_ControlB) + num2 * bezier.m_PointB;
		}

		public Bezier(Vector3 pointA, Vector3 pointB, Vector3 controlA, Vector3 controlB)
		{
			m_PointA = pointA;
			m_PointB = pointB;
			m_ControlA = controlA;
			m_ControlB = controlB;
		}

		public void DrawGizmos(Transform transform)
		{
			Vector3 vector = transform.TransformPoint(m_PointA);
			int num = Mathf.FloorToInt(50f);
			for (int i = 1; i <= num; i++)
			{
				float t = (float)i * 0.02f;
				Vector3 vector2 = transform.TransformPoint(Get(t));
				Gizmos.DrawLine(vector, vector2);
				vector = vector2;
			}
			Color color = Gizmos.color;
			Gizmos.color = new Color(1f, 0f, 0f, color.a);
			Gizmos.DrawLine(transform.TransformPoint(m_PointA), transform.TransformPoint(m_PointA + m_ControlA));
			Gizmos.DrawLine(transform.TransformPoint(m_PointB), transform.TransformPoint(m_PointB + m_ControlB));
			Gizmos.color = color;
		}
	}
}
