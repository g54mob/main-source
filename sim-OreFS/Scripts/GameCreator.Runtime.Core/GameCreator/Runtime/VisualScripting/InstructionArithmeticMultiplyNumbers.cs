using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Multiply Numbers")]
	[Description("Multiplies two values together")]
	[Category("Math/Arithmetic/Multiply Numbers")]
	[Keywords(new string[] { "Product", "Float", "Integer", "Variable" })]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Blue)]
	public class InstructionArithmeticMultiplyNumbers : TInstructionArithmetic
	{
		protected override string Operator => "*";

		protected override double Operate(double value1, double value2)
		{
			return value1 * value2;
		}
	}
}
