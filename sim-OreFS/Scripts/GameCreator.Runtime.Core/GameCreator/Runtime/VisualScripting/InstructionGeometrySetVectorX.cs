using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Vector X")]
	[Description("Changes the X component of a vector")]
	[Category("Math/Geometry/Set Vector X")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("X", "The value that is changed for")]
	[Keywords(new string[] { "Change", "Component", "Axis" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Red, typeof(OverlayDot))]
	public class InstructionGeometrySetVectorX : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDecimal m_X = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set}.x = {m_X}";

		protected override Task Run(Args args)
		{
			Vector3 value = m_Set.Get(args);
			value.x = (float)m_X.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
