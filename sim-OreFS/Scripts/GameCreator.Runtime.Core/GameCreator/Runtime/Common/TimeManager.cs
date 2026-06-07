using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class TimeManager : Singleton<TimeManager>
	{
		private readonly struct TimeData
		{
			private readonly float m_To;

			private readonly float m_From;

			private readonly float m_Transition;

			private readonly float m_StartTime;

			private readonly float m_Duration;

			private readonly float m_Delay;

			public bool IsInDelay => Time.unscaledTime - (m_StartTime + m_Delay) < 0f;

			public float Get
			{
				get
				{
					if (m_Transition <= 0.01f)
					{
						return m_To;
					}
					float t = (Time.unscaledTime - (m_StartTime + m_Delay)) / m_Transition;
					return Mathf.Lerp(m_From, m_To, t);
				}
			}

			public bool TimeRanOut
			{
				get
				{
					if (m_Duration < 0f)
					{
						return false;
					}
					return Time.unscaledTime - (m_StartTime + m_Delay) > m_Duration;
				}
			}

			public TimeData(float transition, float to, float from, float duration, float delay)
			{
				m_To = to;
				m_From = from;
				m_Transition = transition;
				m_StartTime = Time.unscaledTime;
				m_Duration = duration;
				m_Delay = delay;
			}
		}

		private const float PHYSICS_TIME_STEP = 0.02f;

		private const float EPSILON = 0.01f;

		[NonSerialized]
		private readonly Dictionary<int, TimeData> m_TimeScales = new Dictionary<int, TimeData>();

		[NonSerialized]
		private float m_EndTime;

		[NonSerialized]
		private readonly List<int> m_RemoveCandidates = new List<int>();

		public void SetTimeScale(float timeScale, int layer)
		{
			SetTimeScale(timeScale, -1f, layer);
		}

		public void SetTimeScale(float timeScale, float duration, int layer)
		{
			SetTimeScale(timeScale, duration, 0f, layer);
		}

		public void SetTimeScale(float timeScale, float duration, float delay, int layer)
		{
			m_TimeScales[layer] = new TimeData(0f, timeScale, 1f, duration, delay);
			RecalculateTimeScale();
		}

		public void SetSmoothTimeScale(float timeScale, float transition, int layer)
		{
			SetSmoothTimeScale(timeScale, transition, -1f, layer);
		}

		public void SetSmoothTimeScale(float timeScale, float transition, float duration, int layer)
		{
			SetSmoothTimeScale(timeScale, transition, duration, 0f, layer);
		}

		public void SetSmoothTimeScale(float timeScale, float transition, float duration, float delay, int layer)
		{
			if (transition < 0.01f)
			{
				SetTimeScale(timeScale, duration, layer);
				return;
			}
			float num = ((transition + duration >= 0f) ? delay : 0f);
			m_EndTime = Mathf.Max(m_EndTime, Time.unscaledTime + num);
			TimeData value = new TimeData(transition, timeScale, Time.timeScale, duration, delay);
			m_TimeScales[layer] = value;
		}

		private void Update()
		{
			RecalculateTimeScale();
		}

		private void RecalculateTimeScale()
		{
			m_RemoveCandidates.Clear();
			float num = 1f;
			bool flag = false;
			foreach (KeyValuePair<int, TimeData> timeScale in m_TimeScales)
			{
				if (!timeScale.Value.IsInDelay)
				{
					num = (flag ? Math.Min(num, timeScale.Value.Get) : timeScale.Value.Get);
					flag = true;
					if (timeScale.Value.TimeRanOut)
					{
						m_RemoveCandidates.Add(timeScale.Key);
					}
				}
			}
			Time.timeScale = num;
			Time.fixedDeltaTime = 0.02f * num;
			foreach (int removeCandidate in m_RemoveCandidates)
			{
				m_TimeScales.Remove(removeCandidate);
			}
		}
	}
}
