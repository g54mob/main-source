using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Sign of Number")]
	[Description("Sets a value equal to -1 if the input number is negative. 1 otherwise")]
	[Category("Math/Arithmetic/Sign of Number")]
	[Parameter("Set", "Where the value is stored")]
	[Parameter("Number", "The input value")]
	[Keywords(new string[] { "Change", "Float", "Integer", "Variable", "Positive", "Negative" })]
	[Image(typeof(IconContrast), ColorTheme.Type.Blue)]
	public class InstructionArithmeticSignNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Number = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set} = Sign({m_Number})";

		protected override Task Run(Args args)
		{
			double num = m_Number.Get(args);
			m_Set.Set((num >= 0.0) ? 1 : (-1), args);
			return Instruction.DefaultResult;
		}
	}
}
