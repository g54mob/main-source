using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("NAND Bool")]
	[Description("Executes a NAND operation between to values and saves the result")]
	[Category("Math/Boolean/NAND Bool")]
	[Keywords(new string[] { "Not", "Negative", "Subtract", "Minus", "Variable" })]
	[Keywords(new string[] { "Boolean" })]
	[Image(typeof(IconNAND), ColorTheme.Type.Red)]
	public class InstructionBooleanNAND : TInstructionBoolean
	{
		protected override string Operator => "NAND";

		protected override bool Operate(bool value1, bool value2)
		{
			return !(value1 && value2);
		}
	}
}
