using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class MotionToLocation : TMotionTarget<Location>
	{
		protected override bool HasTarget => m_Target.HasPosition(base.Character.gameObject);

		protected override Vector3 Position
		{
			get
			{
				if (!m_Target.HasPosition(base.Character.gameObject))
				{
					return Vector3.zero;
				}
				return m_Target.GetPosition(base.Character.gameObject);
			}
		}

		protected override Vector3 Direction
		{
			get
			{
				if (!m_Target.HasRotation(base.Character.gameObject))
				{
					return Vector3.zero;
				}
				return m_Target.GetRotation(base.Character.gameObject) * Vector3.forward;
			}
		}
	}
}
