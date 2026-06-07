using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Tangent")]
	[Description("Sets a value equal the Tangent of a number")]
	[Category("Math/Arithmetic/Tangent")]
	[Parameter("Set", "Where the value is stored")]
	[Parameter("Tangent", "The angle input in radians")]
	[Keywords(new string[] { "Change", "Float", "Integer", "Variable" })]
	[Image(typeof(IconCurveCircle), ColorTheme.Type.Blue)]
	public class InstructionArithmeticTangentNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Tangent = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set} = Tan({m_Tangent})";

		protected override Task Run(Args args)
		{
			double a = m_Tangent.Get(args);
			m_Set.Set(Math.Tan(a), args);
			return Instruction.DefaultResult;
		}
	}
}
