using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Canvas Group Interactable")]
	[Category("UI/Canvas Group Interactable")]
	[Image(typeof(IconUICanvasGroup), ColorTheme.Type.TextLight)]
	[Description("Changes the interactable value of a Canvas Group component")]
	[Parameter("Canvas Group", "The Canvas Group component that changes its value")]
	[Parameter("Interactable", "The on/off state value")]
	public class InstructionUICanvasGroupInteractable : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_CanvasGroup = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetBool m_Interactable = GetBoolValue.Create(value: true);

		public override string Title => $"{m_CanvasGroup} Interactable = {m_Interactable}";

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
			canvasGroup.interactable = m_Interactable.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
