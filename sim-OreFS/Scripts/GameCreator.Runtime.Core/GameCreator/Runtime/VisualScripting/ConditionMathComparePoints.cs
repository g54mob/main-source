using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Point")]
	[Description("Returns true if a comparison between two points in space is satisfied")]
	[Category("Math/Geometry/Compare Point")]
	[Parameter("Value", "The point in space that is being compared")]
	[Parameter("Comparison", "The comparison operation performed between both values")]
	[Parameter("Compare To", "The point in space that is compared against")]
	[Keywords(new string[] { "Position", "Vector", "Magnitude", "Length" })]
	[Keywords(new string[] { "Equals", "Different", "Greater", "Larger", "Smaller" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	public class ConditionMathComparePoints : Condition
	{
		private enum Comparison
		{
			Equals = 0
		}

		[SerializeField]
		private PropertyGetPosition m_Value = new PropertyGetPosition();

		[SerializeField]
		private Comparison m_Comparison;

		[SerializeField]
		private PropertyGetPosition m_CompareTo = new PropertyGetPosition();

		protected override string Summary
		{
			get
			{
				object value = m_Value;
				string arg = ((m_Comparison != Comparison.Equals) ? string.Empty : "=");
				return $"{value} {arg} {m_CompareTo}";
			}
		}

		protected override bool Run(Args args)
		{
			Vector3 vector = m_Value.Get(args);
			Vector3 vector2 = m_CompareTo.Get(args);
			if (m_Comparison == Comparison.Equals)
			{
				return vector == vector2;
			}
			throw new ArgumentOutOfRangeException($"Point Comparison '{m_Comparison}' not found");
		}
	}
}
