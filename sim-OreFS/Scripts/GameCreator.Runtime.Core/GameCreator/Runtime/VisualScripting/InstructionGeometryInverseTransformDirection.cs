using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Transform to Local Direction")]
	[Description("Transform the Direction from World to Local space")]
	[Category("Math/Geometry/Transform to Local Direction")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Transform", "The reference object to transform the coordinates")]
	[Parameter("Direction", "The direction that changes its space mode")]
	[Keywords(new string[] { "Direction", "Local", "World", "Space", "Variable", "Inverse" })]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	public class InstructionGeometryInverseTransformDirection : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetGameObject m_Transform = GetGameObjectTransform.Create();

		[SerializeField]
		private PropertyGetDirection m_Direction = new PropertyGetDirection();

		public override string Title => string.Format("Set {0} = {2} to {1} Local Space", m_Set, m_Transform, m_Direction);

		protected override Task Run(Args args)
		{
			Transform transform = m_Transform.Get<Transform>(args);
			if (transform == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 value = transform.InverseTransformDirection(m_Direction.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
