using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Subtract Decimals")]
	[Category("Math/Arithmetic/Subtract Decimals")]
	[Image(typeof(IconMinusCircle), ColorTheme.Type.TextNormal)]
	[Description("The result of subtracting two numbers")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Rest", "Minus", "Decrease", "Decrement" })]
	public class GetDecimalMathSubtract : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number1 = new PropertyGetDecimal();

		[SerializeField]
		protected PropertyGetDecimal m_Number2 = new PropertyGetDecimal();

		public override string String => $"({m_Number1} - {m_Number2})";

		public override double Get(Args args)
		{
			double num = m_Number1.Get(args);
			double num2 = m_Number2.Get(args);
			return num - num2;
		}
	}
}
