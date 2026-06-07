using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Direction")]
	[Description("Returns true if a comparison between two direction values is satisfied")]
	[Category("Math/Geometry/Compare Direction")]
	[Parameter("Value", "The direction value that is being compared")]
	[Parameter("Comparison", "The comparison operation performed between both values")]
	[Parameter("Compare To", "The direction value that is compared against")]
	[Keywords(new string[] { "Towards", "Vector", "Magnitude", "Length" })]
	[Keywords(new string[] { "Equals", "Different", "Greater", "Larger", "Smaller" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class ConditionMathCompareDirections : Condition
	{
		[SerializeField]
		private PropertyGetDirection m_Value = new PropertyGetDirection();

		[SerializeField]
		private CompareDirection m_CompareTo = new CompareDirection();

		protected override string Summary => $"{m_Value} {m_CompareTo}";

		protected override bool Run(Args args)
		{
			Vector3 value = m_Value.Get(args);
			return m_CompareTo.Match(value, args);
		}
	}
}
