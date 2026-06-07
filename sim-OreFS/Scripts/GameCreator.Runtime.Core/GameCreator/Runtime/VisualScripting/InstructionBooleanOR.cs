using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("OR Bool")]
	[Description("Executes an OR operation between to values and saves the result")]
	[Category("Math/Boolean/OR Bool")]
	[Keywords(new string[] { "Sum", "Plus", "Variable" })]
	[Keywords(new string[] { "Boolean" })]
	[Image(typeof(IconOR), ColorTheme.Type.Red)]
	public class InstructionBooleanOR : TInstructionBoolean
	{
		protected override string Operator => "OR";

		protected override bool Operate(bool value1, bool value2)
		{
			return value1 || value2;
		}
	}
}
