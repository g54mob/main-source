using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class CompareInteger
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
		private PropertyGetInteger m_CompareTo = new PropertyGetInteger(0);

		public CompareInteger()
		{
		}

		public CompareInteger(int value)
			: this(GetDecimalInteger.Create(value))
		{
		}

		public CompareInteger(PropertyGetInteger number)
			: this()
		{
			m_CompareTo = number;
		}

		public bool Match(int value, Args args)
		{
			int num = (int)m_CompareTo.Get(args);
			return m_Comparison switch
			{
				Comparison.Equals => value == num, 
				Comparison.Different => value != num, 
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
