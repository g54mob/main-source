using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Multiply Decimals")]
	[Category("Math/Arithmetic/Multiply Decimals")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.TextNormal)]
	[Description("The result of multiplying two numbers")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Product" })]
	public class GetDecimalMathMultiply : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDecimal m_Number1 = new PropertyGetDecimal();

		[SerializeField]
		protected PropertyGetDecimal m_Number2 = new PropertyGetDecimal();

		public override string String => $"({m_Number1} * {m_Number2})";

		public override double Get(Args args)
		{
			double num = m_Number1.Get(args);
			double num2 = m_Number2.Get(args);
			return num * num2;
		}
	}
}
