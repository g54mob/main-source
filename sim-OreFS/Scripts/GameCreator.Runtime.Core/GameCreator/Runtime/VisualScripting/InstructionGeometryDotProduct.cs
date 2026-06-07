using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Dot Product")]
	[Description("Calculates the dot product between two directions and saves the result")]
	[Category("Math/Geometry/Dot Product")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Direction 1", "The first operand of the geometric operation that represents a direction")]
	[Parameter("Direction 2", "The second operand of the geometric operation that represents a direction")]
	[Keywords(new string[] { "Direction", "Parallel", "Perpendicular" })]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Green)]
	public class InstructionGeometryDotProduct : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Set = SetNumberNone.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction1 = new PropertyGetDirection();

		[SerializeField]
		private PropertyGetDirection m_Direction2 = new PropertyGetDirection();

		public override string Title => $"Set {m_Set} = {m_Direction1} · {m_Direction2}";

		protected override Task Run(Args args)
		{
			float num = Vector3.Dot(m_Direction1.Get(args), m_Direction2.Get(args));
			m_Set.Set(num, args);
			return Instruction.DefaultResult;
		}
	}
}
