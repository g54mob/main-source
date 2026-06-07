using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class Transition
	{
		[SerializeField]
		private float m_Duration;

		[SerializeField]
		private Easing.Type m_Easing = Easing.Type.QuadInOut;

		[SerializeField]
		private TimeMode.UpdateMode m_Time;

		[SerializeField]
		private bool m_WaitToComplete = true;

		public float Duration => m_Duration;

		public Easing.Type EasingType => m_Easing;

		public TimeMode.UpdateMode Time => m_Time;

		public bool WaitToComplete
		{
			get
			{
				if (m_Duration > float.Epsilon)
				{
					return m_WaitToComplete;
				}
				return false;
			}
		}

		public Transition()
		{
		}

		public Transition(TimeMode.UpdateMode time)
		{
			m_Time = time;
		}

		public Transition(float duration, Easing.Type easing, bool waitToComplete)
		{
			m_Duration = duration;
			m_Easing = easing;
			m_WaitToComplete = waitToComplete;
		}

		public Transition(float duration, Easing.Type easing, TimeMode.UpdateMode time, bool waitToComplete)
		{
			m_Duration = duration;
			m_Easing = easing;
			m_Time = time;
			m_WaitToComplete = waitToComplete;
		}
	}
}
