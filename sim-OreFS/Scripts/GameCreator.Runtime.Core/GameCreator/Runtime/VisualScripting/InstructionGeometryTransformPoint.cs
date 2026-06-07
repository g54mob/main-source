using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Transform to World Point")]
	[Description("Transform the Point from Local to World space")]
	[Category("Math/Geometry/Transform to World Point")]
	[Parameter("Set", "Where the resulting value is set")]
	[Parameter("Transform", "The reference object to transform the coordinates")]
	[Parameter("Point", "The point that changes its space mode")]
	[Keywords(new string[] { "Location", "Position", "Local", "World", "Space", "Variable" })]
	[Image(typeof(IconLocation), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class InstructionGeometryTransformPoint : Instruction
	{
		[SerializeField]
		private PropertySetVector3 m_Set = SetVector3None.Create;

		[SerializeField]
		private PropertyGetGameObject m_Transform = GetGameObjectTransform.Create();

		[SerializeField]
		private PropertyGetPosition m_Position = new PropertyGetPosition();

		public override string Title => string.Format("Set {0} = {2} to {1} World Space", m_Set, m_Transform, m_Position);

		protected override Task Run(Args args)
		{
			Transform transform = m_Transform.Get<Transform>(args);
			if (transform == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 value = transform.TransformPoint(m_Position.Get(args));
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}
