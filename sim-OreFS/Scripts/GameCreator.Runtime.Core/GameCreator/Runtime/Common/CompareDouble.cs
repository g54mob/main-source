using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class CompareDouble
	{
		private enum Comparison
		{
			Equals = 0,
			Different = 1,
			Less = 2,
			Greater = 3,
			LessOrEqual = 4,
			GreaterOrEqual = 5
		}

		[SerializeField]
		private Comparison m_Comparison;

		[SerializeField]
		private PropertyGetDecimal m_CompareTo = new PropertyGetDecimal(0f);

		public CompareDouble()
		{
		}

		public CompareDouble(PropertyGetDecimal number)
			: this()
		{
			m_CompareTo = number;
		}

		public CompareDouble(double value)
			: this(new PropertyGetDecimal(value))
		{
		}

		public bool Match(double value, Args args)
		{
			double num = m_CompareTo.Get(args);
			return m_Comparison switch
			{
				Comparison.Equals => Mathf.Approximately((float)value, (float)num), 
				Comparison.Different => !Mathf.Approximately((float)value, (float)num), 
				Comparison.Less => value < num, 
				Comparison.Greater => value > num, 
				Comparison.LessOrEqual => value <= num, 
				Comparison.GreaterOrEqual => value >= num, 
				_ => throw new ArgumentOutOfRangeException($"Enum '{m_Comparison}' not found"), 
			};
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", m_Comparison switch
			{
				Comparison.Equals => "=", 
				Comparison.Different => "≠", 
				Comparison.Less => "<", 
				Comparison.Greater => ">", 
				Comparison.LessOrEqual => "≤", 
				Comparison.GreaterOrEqual => "≥", 
				_ => string.Empty, 
			}, m_CompareTo);
		}
	}
}
