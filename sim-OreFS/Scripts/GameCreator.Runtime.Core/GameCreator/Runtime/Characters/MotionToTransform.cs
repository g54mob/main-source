using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class MotionToTransform : TMotionTarget<Transform>
	{
		private Vector3 m_LastKnownPosition;

		protected override bool HasTarget => m_Target != null;

		protected override Vector3 Position
		{
			get
			{
				if (m_Target != null)
				{
					m_LastKnownPosition = m_Target.position;
				}
				return m_LastKnownPosition;
			}
		}

		protected override Vector3 Direction => Vector3.zero;

		public override Character.MovementType Setup(Transform target, float threshold, Action<Character, bool> onFinish)
		{
			m_LastKnownPosition = ((m_Target != null) ? m_Target.position : base.Transform.position);
			return base.Setup(target, threshold, onFinish);
		}
	}
}
