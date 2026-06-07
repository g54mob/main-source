using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Toggle Bool")]
	[Description("Toggles the value of a Boolean value")]
	[Category("Math/Boolean/Toggle Bool")]
	[Parameter("Set", "The boolean value that stores the result")]
	[Parameter("From", "The boolean value that is toggled")]
	[Keywords(new string[] { "Change", "Boolean", "Variable", "Not", "Flip", "Switch" })]
	[Image(typeof(IconToggleOff), ColorTheme.Type.Red)]
	public class InstructionBooleanToggle : Instruction
	{
		[SerializeField]
		private PropertySetBool m_Bool = SetBoolGlobalName.Create;

		public override string Title => $"Toggle {m_Bool}";

		protected override Task Run(Args args)
		{
			bool flag = m_Bool.Get(args);
			m_Bool.Set(!flag, args);
			return Instruction.DefaultResult;
		}
	}
}
