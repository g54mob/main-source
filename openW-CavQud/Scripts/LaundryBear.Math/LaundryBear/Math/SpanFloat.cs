using System;
using UnityEngine;

namespace LaundryBear.Math
{
	[Serializable]
	public class SpanFloat : ISpan<float>
	{
		[SerializeField]
		private float m_start;

		[SerializeField]
		private float m_duration;

		public float Start => m_start;

		public float Duration => m_duration;

		public bool ContainsPoint(float point)
		{
			if (m_start <= point)
			{
				return point <= m_start + m_duration;
			}
			return false;
		}

		public bool ContainsSpan(ISpan<float> span)
		{
			if (m_start <= span.Start)
			{
				return span.Start + span.Duration <= m_start + m_duration;
			}
			return false;
		}

		public bool Overlaps(ISpan<float> span)
		{
			if (StartsBefore(span))
			{
				return ContainsPoint(span.Start);
			}
			return span.ContainsPoint(m_start);
		}

		public bool StartsBefore(ISpan<float> span)
		{
			return m_start < span.Start;
		}

		public bool EndsAfter(ISpan<float> span)
		{
			return span.Start + span.Duration < m_start + m_duration;
		}
	}
}
