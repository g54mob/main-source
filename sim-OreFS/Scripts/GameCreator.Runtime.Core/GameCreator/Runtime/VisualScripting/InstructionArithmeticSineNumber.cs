using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Sine")]
	[Description("Sets a value equal the Sine of a number")]
	[Category("Math/Arithmetic/Sine")]
	[Parameter("Set", "Where the value is stored")]
	[Parameter("Sine", "The angle input in radians")]
	[Keywords(new string[] { "Change", "Float", "Integer", "Variable" })]
	[Image(typeof(IconCurveCircle), ColorTheme.Type.Blue)]
	public class InstructionArithmeticSineNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Sine = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set} = Sin({m_Sine})";

		protected override Task Run(Args args)
		{
			double a = m_Sine.Get(args);
			m_Set.Set(Math.Sin(a), args);
			return Instruction.DefaultResult;
		}
	}
}
