using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Clear Parent")]
	[Description("Clears the parent of a game object")]
	[Image(typeof(IconHanger), ColorTheme.Type.Yellow, typeof(OverlayMinus))]
	[Category("Transforms/Clear Parent")]
	[Keywords(new string[] { "Child", "Children", "Hierarchy", "Orphan" })]
	public class InstructionTransformClearParent : TInstructionTransform
	{
		[SerializeField]
		private bool m_KeepPosition;

		public override string Title => $"Clear Parent of {m_Transform}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Transform.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			gameObject.transform.SetParent(null, m_KeepPosition);
			return Instruction.DefaultResult;
		}
	}
}
