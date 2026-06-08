using System;
using UnityEngine;

namespace LaundryBear
{
	[Serializable]
	public class TimingWindow
	{
		public enum TimingStatus
		{
			OutsideEarly = 0,
			InsideEarly = 1,
			InsideLate = 2,
			OutsideLate = 3
		}

		public struct TimingResult
		{
			private TimingStatus m_status;

			private float m_delta;

			private float m_normalizedDelta;

			public TimingStatus Status => m_status;

			public float Delta => m_delta;

			public float NormalizedDelta => m_normalizedDelta;

			public TimingResult(TimingStatus status, float delta, float normalizedDelta)
			{
				m_status = status;
				m_delta = delta;
				m_normalizedDelta = normalizedDelta;
			}
		}

		[SerializeField]
		private float m_length;

		[SerializeField]
		private float m_allowanceEarly;

		[SerializeField]
		private float m_allowanceLate;

		private float m_timer;

		public bool Closed => m_timer >= m_length + m_allowanceLate;

		public bool TargetPassed => m_timer > m_length;

		public float TargetTime => m_length;

		public float CurrentTime => m_timer;

		public float CurrentTimeNormalized => m_timer / m_length;

		public TimingWindow(float length, float allowanceEarly, float allowanceLate)
		{
			m_length = length;
			m_allowanceEarly = allowanceEarly;
			m_allowanceLate = allowanceLate;
		}

		public void Update(float deltaTime)
		{
			m_timer = Mathf.Min(m_timer + deltaTime, m_length + m_allowanceLate);
		}

		public bool PollWindow(out TimingResult result)
		{
			if (m_length - m_allowanceEarly < m_timer)
			{
				if (m_timer < m_length)
				{
					result = new TimingResult(TimingStatus.InsideEarly, m_timer - m_length, (m_timer - m_length) / m_length);
					return true;
				}
				if (m_timer < m_length + m_allowanceLate)
				{
					result = new TimingResult(TimingStatus.InsideLate, m_timer - m_length, (m_timer - m_length) / m_length);
					return true;
				}
				result = new TimingResult(TimingStatus.OutsideLate, m_timer - m_length, (m_timer - m_length) / m_length);
				return false;
			}
			result = new TimingResult(TimingStatus.OutsideEarly, m_timer - m_length, (m_timer - m_length) / m_length);
			return false;
		}

		public void Reset()
		{
			m_timer = 0f;
		}
	}
}
