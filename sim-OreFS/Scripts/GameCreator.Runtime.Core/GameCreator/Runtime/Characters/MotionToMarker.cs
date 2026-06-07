using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class MotionToMarker : TMotionTarget<Marker>
	{
		private Vector3 m_LastKnownPosition;

		protected override bool HasTarget => m_Target != null;

		protected override Vector3 Position
		{
			get
			{
				if (m_Target != null)
				{
					Vector3 position = m_Target.GetPosition(base.Character.gameObject);
					m_LastKnownPosition = position;
				}
				return m_LastKnownPosition;
			}
		}

		protected override Vector3 Direction
		{
			get
			{
				if (m_Target == null)
				{
					return default(Vector3);
				}
				return m_Target.GetDirection(base.Character.gameObject);
			}
		}
	}
}
