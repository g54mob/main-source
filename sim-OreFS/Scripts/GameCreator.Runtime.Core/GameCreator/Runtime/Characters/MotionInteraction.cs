using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class MotionInteraction
	{
		private static readonly Color COLOR_GIZMOS = new Color(0f, 1f, 0f, 0.05f);

		[SerializeField]
		protected float m_Radius = 2f;

		[SerializeField]
		protected InteractionMode m_Focus = new InteractionMode();

		public float Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public InteractionMode Mode
		{
			get
			{
				return m_Focus;
			}
			set
			{
				m_Focus = value;
			}
		}

		public void DrawGizmos(Character character)
		{
			m_Focus.DrawGizmos(character);
			Gizmos.color = COLOR_GIZMOS;
			GizmosExtension.Octahedron(character.transform.position, Quaternion.identity, m_Radius);
		}
	}
}
