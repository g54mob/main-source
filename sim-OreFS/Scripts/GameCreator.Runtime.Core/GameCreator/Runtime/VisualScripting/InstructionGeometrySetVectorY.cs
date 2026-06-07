using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Vector Y")]
	[Description("Changes the Y component of a vector")]
	[Category("Math/Geometry/Set Vector Y")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Y", "The value that is changed for")]
	[Keywords(new string[] { "Change", "Component", "Axis" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Green, typeof(OverlayDot))]
	public class InstructionGeometrySetVectorY : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDecimal m_Y = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set}.y = {m_Y}";

		protected override Task Run(Args args)
		{
			Vector3 value = m_Set.Get(args);
			value.y = (float)m_Y.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
