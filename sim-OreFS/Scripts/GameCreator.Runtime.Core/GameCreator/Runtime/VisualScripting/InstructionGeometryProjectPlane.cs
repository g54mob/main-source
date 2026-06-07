using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Project on Plane")]
	[Description("Projects a direction on a plane defined by a normal vector and saves the result")]
	[Category("Math/Geometry/Project on Plane")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Direction", "The direction vector that is projected on a plane")]
	[Parameter("Plane Normal", "The plane represented by the direction of its normal vector")]
	[Keywords(new string[] { "Direction", "Surface", "Sway" })]
	[Image(typeof(IconProjection), ColorTheme.Type.Green)]
	public class InstructionGeometryProjectPlane : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetDirection m_Direction = new PropertyGetDirection();

		[SerializeField]
		private PropertyGetDirection m_PlaneNormal = new PropertyGetDirection();

		public override string Title => $"Set {m_Set} = {m_Direction} project on {m_PlaneNormal}";

		protected override Task Run(Args args)
		{
			Vector3 value = Vector3.ProjectOnPlane(m_Direction.Get(args), m_PlaneNormal.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
