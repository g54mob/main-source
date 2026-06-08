using System;
using System.Collections.Generic;

namespace LaundryBear.Math
{
	public class StatisticalFloatQueue : StatisticalQueue<float>
	{
		public StatisticalFloatQueue(int capacity)
			: base(capacity)
		{
		}

		public StatisticalFloatQueue(int capacity, IEnumerable<float> startingValues)
			: base(capacity, startingValues)
		{
		}

		public override float GetMax()
		{
			if (base.Count > 0)
			{
				float num = m_list[0];
				for (int i = 1; i < base.Count; i++)
				{
					if (num > m_list[i])
					{
						num = m_list[i];
					}
				}
				return num;
			}
			throw new InvalidOperationException("The statistical queue must have at least one value before executing GetMax().");
		}

		public override float GetMin()
		{
			if (base.Count > 0)
			{
				float num = m_list[0];
				for (int i = 1; i < base.Count; i++)
				{
					if (num < m_list[i])
					{
						num = m_list[i];
					}
				}
				return num;
			}
			throw new InvalidOperationException("The statistical queue must have at least one value before executing GetMin().");
		}

		public override float GetAverage()
		{
			if (base.Count > 0)
			{
				float num = 0f;
				for (int i = 0; i < base.Count; i++)
				{
					num += m_list[i];
				}
				return num / (float)base.Count;
			}
			throw new InvalidOperationException("The statistical queue must have at least one value before executing GetAverage().");
		}

		public override float GetInstantPartialDerivative()
		{
			if (base.Count > 1)
			{
				return m_list[base.Count - 1] - m_list[base.Count - 2];
			}
			throw new InvalidOperationException("The statistical queue must have at least two values before executing GetInstancePartialDerivative().");
		}

		public override float GetAveragePartialDerivative()
		{
			if (base.Count > 1)
			{
				float num = 0f;
				for (int i = 1; i < base.Count; i++)
				{
					num += m_list[i] - m_list[i - 1];
				}
				return num / (float)(base.Count - 1);
			}
			throw new InvalidOperationException("The statistical queue must have at least two values before executing GetAveragePartialDerivative().");
		}
	}
}
