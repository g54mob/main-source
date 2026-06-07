using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Uniform Scale")]
	[Description("Multiplies each component of a vector with a decimal")]
	[Category("Math/Geometry/Uniform Scale")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Vector", "The first operand of the geometric operation that represents a direction")]
	[Parameter("Value", "The second operand of the geometric operation that represents a decimal number")]
	[Keywords(new string[] { "Direction", "Homogeneous", "Multiply", "Product" })]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Green)]
	public class InstructionGeometryUniformScale : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction = new PropertyGetDirection();

		[SerializeField]
		private PropertyGetDecimal m_Value = new PropertyGetDecimal(1f);

		public override string Title => $"Set {m_Set} = {m_Direction} * {m_Value}";

		protected override Task Run(Args args)
		{
			Vector3 value = Vector3.Scale(m_Direction.Get(args), Vector3.one * (float)m_Value.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
