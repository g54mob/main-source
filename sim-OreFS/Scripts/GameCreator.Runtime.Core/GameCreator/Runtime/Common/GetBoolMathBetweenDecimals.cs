using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Between Decimals")]
	[Category("Math/Between Decimals")]
	[Image(typeof(IconPercent), ColorTheme.Type.Red, typeof(OverlayBar))]
	[Description("Returns True if the value is between Min and Max")]
	[Keywords(new string[] { "Compare", "Range" })]
	public class GetBoolMathBetweenDecimals : PropertyTypeGetBool
	{
		[SerializeField]
		private PropertyGetDecimal m_Value = new PropertyGetDecimal();

		[SerializeField]
		private PropertyGetDecimal m_Min = new PropertyGetDecimal();

		[SerializeField]
		private PropertyGetDecimal m_Max = new PropertyGetDecimal();

		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolMathBetweenDecimals());

		public override string String => $"{m_Value} between [{m_Min}, {m_Max}]";

		public override bool Get(Args args)
		{
			double num = m_Value.Get(args);
			double num2 = m_Min.Get(args);
			double num3 = m_Max.Get(args);
			if (num >= num2)
			{
				return num <= num3;
			}
			return false;
		}
	}
}
