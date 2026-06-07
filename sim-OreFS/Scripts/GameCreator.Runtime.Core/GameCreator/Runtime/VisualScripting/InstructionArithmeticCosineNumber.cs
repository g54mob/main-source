using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Cosine")]
	[Description("Sets a value equal the Cosine of a number")]
	[Category("Math/Arithmetic/Cosine")]
	[Parameter("Set", "Where the value is stored")]
	[Parameter("Cosine", "The angle input in radians")]
	[Keywords(new string[] { "Change", "Float", "Integer", "Variable" })]
	[Image(typeof(IconCurveCircle), ColorTheme.Type.Blue)]
	public class InstructionArithmeticCosineNumber : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberGlobalName.Create;

		[SerializeField]
		private PropertyGetDecimal m_Cosine = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set} = Cos({m_Cosine})";

		protected override Task Run(Args args)
		{
			double d = m_Cosine.Get(args);
			m_Set.Set(Math.Cos(d), args);
			return Instruction.DefaultResult;
		}
	}
}
