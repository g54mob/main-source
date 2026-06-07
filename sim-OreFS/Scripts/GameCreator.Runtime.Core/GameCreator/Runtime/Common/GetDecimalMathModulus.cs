using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Modulus Decimals")]
	[Category("Math/Arithmetic/Modulus Decimals")]
	[Image(typeof(IconDivideCircle), ColorTheme.Type.TextNormal, typeof(OverlayArrowRight))]
	[Description("The modulus operation, which is what's left of the division between two numbers")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalMathModulus : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number1 = new PropertyGetDecimal();

		[SerializeField]
		protected PropertyGetDecimal m_Number2 = new PropertyGetDecimal();

		public override string String => $"({m_Number1} % {m_Number2})";

		public override double Get(Args args)
		{
			double num = m_Number1.Get(args);
			double num2 = m_Number2.Get(args);
			return num % num2;
		}
	}
}
