using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class CompareDirection
	{
		private enum Comparison
		{
			Equals = 0,
			AreParallel = 1,
			AreOrthogonal = 2,
			SameDirection = 3,
			EqualMagnitude = 4,
			SmallerMagnitude = 5,
			BiggerMagnitude = 6
		}

		[SerializeField]
		private Comparison m_Comparison;

		[SerializeField]
		private PropertyGetDirection m_CompareTo = new PropertyGetDirection();

		public CompareDirection()
		{
		}

		public CompareDirection(PropertyGetDirection direction)
			: this()
		{
			m_CompareTo = direction;
		}

		public bool Match(Vector3 value, Args args)
		{
			Vector3 vector = value;
			Vector3 vector2 = m_CompareTo.Get(args);
			return m_Comparison switch
			{
				Comparison.Equals => vector == vector2, 
				Comparison.AreParallel => Mathf.Approximately(Vector3.Dot(vector.normalized, vector2.normalized), 1f), 
				Comparison.AreOrthogonal => Mathf.Approximately(Vector3.Dot(vector.normalized, vector2.normalized), 0f), 
				Comparison.SameDirection => Vector3.Dot(vector.normalized, vector2.normalized) >= 0f, 
				Comparison.EqualMagnitude => Mathf.Approximately(vector.magnitude, vector2.magnitude), 
				Comparison.SmallerMagnitude => vector.magnitude < vector2.magnitude, 
				Comparison.BiggerMagnitude => vector.magnitude > vector2.magnitude, 
				_ => throw new ArgumentOutOfRangeException($"Enum '{m_Comparison}' not found"), 
			};
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", m_Comparison switch
			{
				Comparison.Equals => "=", 
				Comparison.AreParallel => "is parallel with", 
				Comparison.AreOrthogonal => "is orthogonal with", 
				Comparison.SameDirection => "same direction as", 
				Comparison.EqualMagnitude => "same length as", 
				Comparison.SmallerMagnitude => "smaller length than", 
				Comparison.BiggerMagnitude => "bigger length than", 
				_ => string.Empty, 
			}, m_CompareTo);
		}
	}
}
