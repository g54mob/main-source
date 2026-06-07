using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Reflect on Plane")]
	[Description("Reflects a direction on a plane defined by a normal vector and saves the result")]
	[Category("Math/Geometry/Reflect on Plane")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Direction", "The direction vector that is reflected on a plane")]
	[Parameter("Plane Normal", "The plane represented by the direction of its normal vector")]
	[Keywords(new string[] { "Direction", "Bounce", "Ricochet", "Snell" })]
	[Image(typeof(IconReflection), ColorTheme.Type.Green)]
	public class InstructionGeometryReflectPlane : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction = new PropertyGetDirection();

		[SerializeField]
		private PropertyGetDirection m_PlaneNormal = new PropertyGetDirection();

		public override string Title => $"Set {m_Set} = {m_Direction} bounce on {m_PlaneNormal}";

		protected override Task Run(Args args)
		{
			Vector3 value = Vector3.Reflect(m_Direction.Get(args), m_PlaneNormal.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
