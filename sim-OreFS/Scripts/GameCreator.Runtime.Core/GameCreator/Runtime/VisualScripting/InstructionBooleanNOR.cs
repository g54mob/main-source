using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("NOR Bool")]
	[Description("Executes a NOR operation between to values and saves the result")]
	[Category("Math/Boolean/NOR Bool")]
	[Keywords(new string[] { "Not", "Negative", "Sum", "Plus", "Variable" })]
	[Keywords(new string[] { "Boolean" })]
	[Image(typeof(IconNOR), ColorTheme.Type.Red)]
	public class InstructionBooleanNOR : TInstructionBoolean
	{
		protected override string Operator => "NOR";

		protected override bool Operate(bool value1, bool value2)
		{
			return !(value1 || value2);
		}
	}
}
