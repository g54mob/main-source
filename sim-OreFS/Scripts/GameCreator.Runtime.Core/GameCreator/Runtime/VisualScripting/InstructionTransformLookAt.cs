using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Look At")]
	[Description("Rotates the transform towards the chosen target")]
	[Image(typeof(IconEye), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Category("Transforms/Look At")]
	[Parameter("Target", "The desired targeted object to look at")]
	[Keywords(new string[] { "Rotate", "Rotation", "See" })]
	public class InstructionTransformLookAt : TInstructionTransform
	{
		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectTransform.Create();

		public override string Title => $"{m_Transform} look at {m_Target}";

		protected override Task Run(Args args)
		{
			Transform transform = m_Transform.Get<Transform>(args);
			if (transform == null)
			{
				return Instruction.DefaultResult;
			}
			Transform transform2 = m_Target.Get<Transform>(args);
			if (transform2 == null)
			{
				return Instruction.DefaultResult;
			}
			transform.LookAt(transform2);
			return Instruction.DefaultResult;
		}
	}
}
