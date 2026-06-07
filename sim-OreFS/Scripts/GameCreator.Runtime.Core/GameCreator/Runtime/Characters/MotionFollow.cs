using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class MotionFollow : TMotion
	{
		protected bool m_ActiveFollow;

		protected bool m_IsFollowing;

		protected Transform m_Target;

		protected Vector3 m_LastKnownPosition;

		protected float m_MinRadius;

		protected float m_MaxRadius;

		public Transform Target => m_Target;

		public float MinRadius => m_MinRadius;

		public float MaxRadius => m_MaxRadius;

		public Character.MovementType Setup(Transform target, float minDistance, float maxDistance)
		{
			Setup();
			m_ActiveFollow = true;
			m_Target = target;
			m_LastKnownPosition = ((m_Target != null) ? m_Target.position : base.Transform.position);
			m_IsFollowing = true;
			m_MinRadius = minDistance;
			m_MaxRadius = maxDistance;
			return Character.MovementType.None;
		}

		public override Character.MovementType Stop(bool success)
		{
			Character.MovementType result = base.Stop(success);
			m_ActiveFollow = false;
			return result;
		}

		public override Character.MovementType Update()
		{
			if ((bool)m_Target)
			{
				m_LastKnownPosition = m_Target.position;
			}
			float num = Vector3.Distance(base.Transform.position, m_LastKnownPosition);
			bool num2 = !m_Target || !m_ActiveFollow || (m_IsFollowing && num <= m_MinRadius) || (!m_IsFollowing && num <= m_MaxRadius);
			Vector3 direction = m_Target.position - base.Transform.position;
			if (num2)
			{
				direction = Vector3.zero;
				direction = CalculateSpeed(direction);
				direction = CalculateAcceleration(direction);
				base.Motion.MoveDirection = direction;
				base.Motion.MovePosition = base.Transform.TransformDirection(Vector3.forward);
				m_IsFollowing = false;
				if (!(direction.sqrMagnitude > float.Epsilon))
				{
					return Character.MovementType.None;
				}
				return Character.MovementType.MoveToDirection;
			}
			m_IsFollowing = true;
			base.Motion.MovePosition = m_LastKnownPosition;
			direction = CalculateSpeed(direction);
			direction = CalculateAcceleration(direction);
			base.Motion.MoveDirection = direction;
			return Character.MovementType.MoveToPosition;
		}

		public override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (m_ActiveFollow && (bool)m_Target)
			{
				Gizmos.color = (m_IsFollowing ? new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.5f) : new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 1f));
				GizmosExtension.Circle(m_Target.position, m_MaxRadius);
				Gizmos.color = (m_IsFollowing ? new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 1f) : new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.5f));
				GizmosExtension.Circle(m_Target.position, m_MinRadius);
			}
		}
	}
}
