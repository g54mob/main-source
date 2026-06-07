using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Increment Number")]
	[Description("Sets a value equal the sum of itself, plus another number")]
	[Category("Math/Arithmetic/Increment Number")]
	[Parameter("Set", "The value being incremented")]
	[Parameter("Value", "The value to add")]
	[Keywords(new string[] { "Change", "Float", "Integer", "Variable" })]
	[Image(typeof(IconPlusCircle), ColorTheme.Type.Blue, typeof(OverlayDot))]
	public class InstructionArithmeticIncrementNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Value = new PropertyGetDecimal();

		public override string Title => $"Increment {m_Set} + {m_Value}";

		protected override Task Run(Args args)
		{
			double num = m_Set.Get(args);
			double num2 = m_Value.Get(args);
			m_Set.Set(num + num2, args);
			return Instruction.DefaultResult;
		}
	}
}
