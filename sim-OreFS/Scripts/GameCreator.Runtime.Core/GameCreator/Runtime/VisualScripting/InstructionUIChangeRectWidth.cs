using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Width")]
	[Category("UI/Change Width")]
	[Image(typeof(IconRectTransform), ColorTheme.Type.TextLight, typeof(OverlayX))]
	[Description("Changes the Width of a Rect Transform")]
	[Parameter("Rect Transform", "The Rect Transform component to change")]
	[Parameter("Width", "The new width value. Also known as sizeDelta.x")]
	public class InstructionUIChangeRectWidth : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_RectTransform = GetGameObjectRectTransform.Create();

		[SerializeField]
		private ChangeDecimal m_Width = new ChangeDecimal(300f);

		public override string Title => $"Width {m_RectTransform} {m_Width}";

		protected override Task Run(Args args)
		{
			RectTransform rectTransform = m_RectTransform.Get<RectTransform>(args);
			if (rectTransform == null)
			{
				return Instruction.DefaultResult;
			}
			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta.x = (float)m_Width.Get(sizeDelta.x, args);
			rectTransform.sizeDelta = sizeDelta;
			return Instruction.DefaultResult;
		}
	}
}
