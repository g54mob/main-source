using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Canvas Group Block Raycasts")]
	[Category("UI/Canvas Group Block Raycasts")]
	[Image(typeof(IconUICanvasGroup), ColorTheme.Type.TextLight)]
	[Description("Changes whether the Canvas Group blocks raycasts or not")]
	[Parameter("Canvas Group", "The Canvas Group component that changes its value")]
	[Parameter("Block Raycasts", "If true, the canvas group and its children block raycasts")]
	public class InstructionUICanvasGroupBlockRaycasts : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_CanvasGroup = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetBool m_BlockRaycasts = GetBoolValue.Create(value: true);

		public override string Title => $"{m_CanvasGroup} Block Raycasts = {m_BlockRaycasts}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_CanvasGroup.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			CanvasGroup canvasGroup = gameObject.Get<CanvasGroup>();
			if (canvasGroup == null)
			{
				return Instruction.DefaultResult;
			}
			canvasGroup.blocksRaycasts = m_BlockRaycasts.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
