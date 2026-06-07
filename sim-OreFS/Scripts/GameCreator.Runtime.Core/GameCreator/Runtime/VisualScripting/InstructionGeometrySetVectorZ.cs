using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Vector Z")]
	[Description("Changes the Z component of a vector")]
	[Category("Math/Geometry/Set Vector Z")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Z", "The value that is changed for")]
	[Keywords(new string[] { "Change", "Component", "Axis" })]
	[Image(typeof(IconVector3), ColorTheme.Type.Blue, typeof(OverlayDot))]
	public class InstructionGeometrySetVectorZ : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDecimal m_Z = new PropertyGetDecimal();

		public override string Title => $"Set {m_Set}.z = {m_Z}";

		protected override Task Run(Args args)
		{
			Vector3 value = m_Set.Get(args);
			value.z = (float)m_Z.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
