using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Distance Flat")]
	[Description("Returns true if a comparison of the flat XZ distance between two points is satisfied")]
	[Category("Math/Geometry/Compare Distance Flat")]
	[Parameter("Point A", "The first operand that represents a point in space")]
	[Parameter("Point B", "The second operand that represents a point in space")]
	[Parameter("Comparison", "The comparison operation performed between both values")]
	[Parameter("Distance", "The distance value compared against")]
	[Keywords(new string[] { "Position", "Vector", "Magnitude", "Length" })]
	[Keywords(new string[] { "Equals", "Different", "Greater", "Larger", "Smaller" })]
	[Image(typeof(IconCompass), ColorTheme.Type.Green, typeof(OverlayBar))]
	public class ConditionMathCompareFlatDistance : Condition
	{
		[SerializeField]
		private PropertyGetPosition m_PointA = new PropertyGetPosition();

		[SerializeField]
		private PropertyGetPosition m_PointB = new PropertyGetPosition();

		[SerializeField]
		private CompareDouble m_Distance = new CompareDouble();

		protected override string Summary => $"Flat Distance [{m_PointA}, {m_PointB}] {m_Distance}";

		protected override bool Run(Args args)
		{
			Vector2 a = m_PointA.Get(args).XZ();
			Vector2 b = m_PointB.Get(args).XZ();
			float num = Vector2.Distance(a, b);
			return m_Distance.Match(num, args);
		}
	}
}
