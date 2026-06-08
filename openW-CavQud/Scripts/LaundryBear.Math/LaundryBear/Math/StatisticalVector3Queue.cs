using System;
using System.Collections.Generic;
using UnityEngine;

namespace LaundryBear.Math
{
	public class StatisticalVector3Queue : StatisticalQueue<Vector3>
	{
		public StatisticalVector3Queue(int capacity)
			: base(capacity)
		{
		}

		public StatisticalVector3Queue(int capacity, IEnumerable<Vector3> startingValues)
			: base(capacity, startingValues)
		{
		}

		public override Vector3 GetMax()
		{
			if (base.Count > 0)
			{
				Vector3 result = m_list[0];
				for (int i = 1; i < base.Count; i++)
				{
					if (result.sqrMagnitude > m_list[i].sqrMagnitude)
					{
						result = m_list[i];
					}
				}
				return result;
			}
			throw new InvalidOperationException("The statistical queue must have at least one value before executing GetMax().");
		}

		public override Vector3 GetMin()
		{
			if (base.Count > 0)
			{
				Vector3 result = m_list[0];
				for (int i = 1; i < base.Count; i++)
				{
					if (result.sqrMagnitude < m_list[i].sqrMagnitude)
					{
						result = m_list[i];
					}
				}
				return result;
			}
			throw new InvalidOperationException("The statistical queue must have at least one value before executing GetMin().");
		}

		public override Vector3 GetAverage()
		{
			if (base.Count > 0)
			{
				Vector3 zero = Vector3.zero;
				for (int i = 0; i < base.Count; i++)
				{
					zero += m_list[i];
				}
				return zero / base.Count;
			}
			throw new InvalidOperationException("The statistical queue must have at least one value before executing GetAverage().");
		}

		public override Vector3 GetInstantPartialDerivative()
		{
			if (base.Count > 1)
			{
				return m_list[base.Count - 1] - m_list[base.Count - 2];
			}
			throw new InvalidOperationException("The statistical queue must have at least two values before executing GetInstancePartialDerivative().");
		}

		public override Vector3 GetAveragePartialDerivative()
		{
			if (base.Count > 1)
			{
				Vector3 zero = Vector3.zero;
				for (int i = 1; i < base.Count; i++)
				{
					zero += m_list[i] - m_list[i - 1];
				}
				return zero / (base.Count - 1);
			}
			throw new InvalidOperationException("The statistical queue must have at least two values before executing GetAveragePartialDerivative().");
		}
	}
}
