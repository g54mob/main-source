using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Number")]
	[Description("Sets a value equal to another value")]
	[Category("Math/Arithmetic/Set Number")]
	[Parameter("Set", "Where the value is set")]
	[Parameter("From", "The value that is set")]
	[Keywords(new string[] { "Change", "Float", "Integer", "Variable" })]
	[Image(typeof(IconArrowCircleDown), ColorTheme.Type.Blue)]
	public class InstructionArithmeticSetNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_From = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set} = {m_From}";

		protected override Task Run(Args args)
		{
			double value = m_From.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
