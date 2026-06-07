using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Distance Vertical")]
	[Description("Returns true if a comparison of the vertical distance between two points is satisfied")]
	[Category("Math/Geometry/Compare Distance Vertical")]
	[Parameter("Point A", "The first operand that represents a point in space")]
	[Parameter("Point B", "The second operand that represents a point in space")]
	[Parameter("Comparison", "The comparison operation performed between both values")]
	[Parameter("Distance", "The distance value compared against")]
	[Keywords(new string[] { "Position", "Vector", "Magnitude", "Length" })]
	[Keywords(new string[] { "Equals", "Different", "Greater", "Larger", "Smaller" })]
	[Image(typeof(IconCompass), ColorTheme.Type.Green, typeof(OverlayY))]
	public class ConditionMathCompareVerticalDistance : Condition
	{
		[SerializeField]
		private PropertyGetPosition m_PointA = new PropertyGetPosition();

		[SerializeField]
		private PropertyGetPosition m_PointB = new PropertyGetPosition();

		[SerializeField]
		private CompareDouble m_Distance = new CompareDouble();

		protected override string Summary => $"Vertical Distance [{m_PointA}, {m_PointB}] {m_Distance}";

		protected override bool Run(Args args)
		{
			float y = m_PointA.Get(args).y;
			float y2 = m_PointB.Get(args).y;
			float num = Math.Abs(y - y2);
			return m_Distance.Match(num, args);
		}
	}
}
