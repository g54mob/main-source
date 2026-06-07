using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Height")]
	[Category("UI/Change Height")]
	[Image(typeof(IconRectTransform), ColorTheme.Type.TextLight, typeof(OverlayY))]
	[Description("Changes the Height of a Rect Transform")]
	[Parameter("Rect Transform", "The Rect Transform component to change")]
	[Parameter("Height", "The new height value. Also known as sizeDelta.y")]
	public class InstructionUIChangeRectHeight : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_RectTransform = GetGameObjectRectTransform.Create();

		[SerializeField]
		private ChangeDecimal m_Height = new ChangeDecimal(50f);

		public override string Title => $"Height {m_RectTransform} {m_Height}";

		protected override Task Run(Args args)
		{
			RectTransform rectTransform = m_RectTransform.Get<RectTransform>(args);
			if (rectTransform == null)
			{
				return Instruction.DefaultResult;
			}
			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta.y = (float)m_Height.Get(sizeDelta.y, args);
			rectTransform.sizeDelta = sizeDelta;
			return Instruction.DefaultResult;
		}
	}
}
