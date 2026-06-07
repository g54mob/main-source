using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class CompareMinDistanceOrNone
	{
		private enum MinDistance
		{
			None = 0,
			GameObject = 1
		}

		private static Color COLOR_EDITOR = new Color(0f, 1f, 0f, 0.25f);

		private static Color COLOR_IN = new Color(0f, 1f, 0f, 0.1f);

		private static Color COLOR_OUT = new Color(1f, 0f, 0f, 0.05f);

		[SerializeField]
		private MinDistance m_MinDistance;

		[SerializeField]
		private PropertyGetGameObject m_To = GetGameObjectPlayer.Create();

		[SerializeField]
		private float m_Radius = 2f;

		[SerializeField]
		private Vector3 m_Offset = Vector3.zero;

		public bool NoDistance => m_MinDistance == MinDistance.None;

		public CompareMinDistanceOrNone()
		{
		}

		public CompareMinDistanceOrNone(PropertyGetGameObject to)
			: this()
		{
			m_MinDistance = MinDistance.GameObject;
			m_To = to;
		}

		public bool Match(Transform self, Args args)
		{
			if (NoDistance)
			{
				return true;
			}
			if (self == null)
			{
				return false;
			}
			GameObject gameObject = m_To.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			return Vector3.Distance(self.TransformPoint(m_Offset), gameObject.transform.position) <= m_Radius;
		}

		public void OnDrawGizmos(Transform self, Args args)
		{
			if (!NoDistance && !(self == null))
			{
				Vector3 vector = self.TransformPoint(m_Offset);
				GameObject gameObject = m_To.Get(args);
				if (Application.isPlaying)
				{
					Gizmos.color = ((((gameObject != null) ? Vector3.Distance(vector, gameObject.transform.position) : float.PositiveInfinity) <= m_Radius) ? COLOR_IN : COLOR_OUT);
				}
				else
				{
					Gizmos.color = COLOR_EDITOR;
				}
				GizmosExtension.Octahedron(vector, Quaternion.identity, m_Radius);
			}
		}
	}
}
