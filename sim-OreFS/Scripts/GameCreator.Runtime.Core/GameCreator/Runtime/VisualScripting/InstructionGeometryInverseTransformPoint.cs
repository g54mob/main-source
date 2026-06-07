using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Transform to Local Point")]
	[Description("Transform the Point from World to Local space")]
	[Category("Math/Geometry/Transform to Local Point")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Transform", "The reference object to transform the coordinates")]
	[Parameter("Point", "The point that changes its space mode")]
	[Keywords(new string[] { "Location", "Position", "Local", "World", "Space", "Variable", "Inverse" })]
	[Image(typeof(IconLocation), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	public class InstructionGeometryInverseTransformPoint : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetGameObject m_Transform = GetGameObjectTransform.Create();

		[SerializeField]
		private PropertyGetPosition m_Position = new PropertyGetPosition();

		public override string Title => string.Format("Set {0} = {2} to {1} Local Space", m_Set, m_Transform, m_Position);

		protected override Task Run(Args args)
		{
			Transform transform = m_Transform.Get<Transform>(args);
			if (transform == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 value = transform.InverseTransformPoint(m_Position.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
