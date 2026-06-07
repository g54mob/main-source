using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public abstract class TMotionTarget<T> : TMotion
	{
		private const float MIN_THRESHOLD = 0.15f;

		private const float STUCK_TIME = 0.5f;

		[NonSerialized]
		protected T m_Target;

		[NonSerialized]
		protected float m_Threshold;

		[NonSerialized]
		protected bool m_HasFinished;

		[NonSerialized]
		protected Action<Character, bool> m_OnFinish;

		[NonSerialized]
		private int m_FacingLayerKey = -1;

		[NonSerialized]
		private Vector3 m_StartStuckPosition;

		[NonSerialized]
		private float m_StartStuckTime;

		protected abstract bool HasTarget { get; }

		protected abstract Vector3 Position { get; }

		protected abstract Vector3 Direction { get; }

		public virtual Character.MovementType Setup(T target, float threshold, Action<Character, bool> onFinish)
		{
			Setup();
			m_HasFinished = false;
			m_Target = target;
			m_Threshold = Math.Max(threshold, 0.15f);
			m_OnFinish = onFinish;
			base.Motion.MoveDirection = (Position - base.Transform.position).normalized;
			base.Motion.MovePosition = Position;
			m_StartStuckPosition = base.Transform.position;
			m_StartStuckTime = base.Character.Time.Time;
			return Character.MovementType.MoveToPosition;
		}

		public override Character.MovementType Update()
		{
			if (m_HasFinished)
			{
				return Character.MovementType.None;
			}
			Vector3 feet = base.Character.Feet;
			Vector3 position = Position;
			float num = (HasTarget ? Vector3.Distance(feet, position) : 0f);
			float num2 = m_Threshold + base.Motion.Radius * 2f;
			if (Direction != Vector3.zero && num <= num2)
			{
				IUnitFacing facing = base.Character.Facing;
				m_FacingLayerKey = facing.SetLayerDirection(m_FacingLayerKey, Direction, autoDestroyOnReach: true);
			}
			if (num <= m_Threshold)
			{
				return Stop(success: true);
			}
			if (m_StartStuckPosition != base.Transform.position)
			{
				m_StartStuckPosition = base.Transform.position;
				m_StartStuckTime = base.Character.Time.Time;
			}
			else if (base.Character.Time.Time - m_StartStuckTime >= 0.5f)
			{
				return Stop(success: false);
			}
			Vector3 direction = position - feet;
			if (num < m_Threshold)
			{
				direction = Vector3.zero;
			}
			direction = CalculateSpeed(direction);
			direction = CalculateAcceleration(direction);
			base.Motion.MoveDirection = direction;
			base.Motion.MovePosition = Position;
			if (!(direction.sqrMagnitude > float.Epsilon))
			{
				return Character.MovementType.None;
			}
			return Character.MovementType.MoveToPosition;
		}

		public override Character.MovementType Stop(bool success)
		{
			Character.MovementType result = base.Stop(success);
			m_OnFinish?.Invoke(base.Character, success);
			m_HasFinished = true;
			return result;
		}

		public override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (!m_HasFinished && !(m_Threshold < 0.15f))
			{
				Gizmos.color = Color.yellow;
				GizmosExtension.Circle(Position, m_Threshold);
			}
		}
	}
}
