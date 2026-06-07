using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Absolute Number")]
	[Description("Sets a value without its sign")]
	[Category("Math/Arithmetic/Absolute Number")]
	[Parameter("Set", "Where the value is stored")]
	[Parameter("Number", "The input value")]
	[Keywords(new string[] { "Change", "Float", "Integer", "Variable", "Sign", "Positive", "Modulus", "Magnitude" })]
	[Image(typeof(IconAbsolute), ColorTheme.Type.Blue)]
	public class InstructionArithmeticAbsoluteNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Number = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set} = |{m_Number}|";

		protected override Task Run(Args args)
		{
			double value = m_Number.Get(args);
			m_Set.Set(Math.Abs(value), args);
			return Instruction.DefaultResult;
		}
	}
}
