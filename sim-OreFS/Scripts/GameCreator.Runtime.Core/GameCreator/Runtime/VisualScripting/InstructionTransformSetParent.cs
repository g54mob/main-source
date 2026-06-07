using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Parent")]
	[Description("Changes the parent of a game object")]
	[Image(typeof(IconHanger), ColorTheme.Type.Yellow)]
	[Category("Transforms/Set Parent")]
	[Parameter("Parent", "The game object that becomes the parent")]
	[Keywords(new string[] { "Child", "Children", "Hierarchy", "Hang", "Inherit" })]
	public class InstructionTransformSetParent : TInstructionTransform
	{
		[SerializeField]
		private PropertyGetGameObject m_Parent = GetGameObjectTransform.Create();

		public override string Title => $"Set Parent of {m_Transform} to {m_Parent}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			GameObject gameObject2 = m_Parent.Get(args);
			if (gameObject2 == null)
			{
				return Instruction.DefaultResult;
			}
			gameObject.transform.SetParent(gameObject2.transform);
			return Instruction.DefaultResult;
		}
	}
}
