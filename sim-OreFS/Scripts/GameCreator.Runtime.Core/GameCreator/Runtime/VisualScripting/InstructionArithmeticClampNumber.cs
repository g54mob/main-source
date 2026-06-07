using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Clamp Number")]
	[Description("Clamps a value between a range defined by two others (inclusive)")]
	[Category("Math/Arithmetic/Clamp Number")]
	[Keywords(new string[] { "Min", "Max", "Negative", "Minus", "Float", "Integer", "Variable" })]
	[Image(typeof(IconContrast), ColorTheme.Type.Blue)]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Value", "The value that is clamped between two others")]
	[Parameter("Minimum", "The smallest possible value")]
	[Parameter("Maximum", "The largest possible value")]
	public class InstructionArithmeticClampNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Value = new PropertyGetDecimal();

		[SerializeField]
		private float m_Minimum;

		[SerializeField]
		private float m_Maximum = 1f;

		public override string Title => $"Clamp {m_Set} = {m_Value} [{m_Minimum}, {m_Maximum}]";

		protected override Task Run(Args args)
		{
			double value = Math.Clamp(m_Value.Get(args), m_Minimum, m_Maximum);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
