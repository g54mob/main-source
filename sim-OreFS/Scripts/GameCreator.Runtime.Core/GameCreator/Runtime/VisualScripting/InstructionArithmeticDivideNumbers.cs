using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Divide Numbers")]
	[Description("Performs a division between the first and the second values")]
	[Category("Math/Arithmetic/Divide Numbers")]
	[Keywords(new string[] { "Fraction", "Float", "Integer", "Variable" })]
	[Image(typeof(IconDivideCircle), ColorTheme.Type.Blue)]
	public class InstructionArithmeticDivideNumbers : TInstructionArithmetic
	{
		protected override string Operator => "/";

		protected override double Operate(double value1, double value2)
		{
			return value1 / value2;
		}
	}
}
