using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Bool")]
	[Description("Sets a boolean value equal to another value")]
	[Category("Math/Boolean/Set Bool")]
	[Parameter("Set", "Where the value is set")]
	[Parameter("From", "The value that is set")]
	[Keywords(new string[] { "Change", "Boolean", "Variable" })]
	[Image(typeof(IconToggleOn), ColorTheme.Type.Red)]
	public class InstructionBooleanSetBool : Instruction
	{
		[SerializeField]
		private PropertySetBool m_Set = SetBoolNone.Create;

		[SerializeField]
		private PropertyGetBool m_From = new PropertyGetBool();

		public override string Title => $"Set {m_Set} = {m_From}";

		protected override Task Run(Args args)
		{
			bool value = m_From.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
