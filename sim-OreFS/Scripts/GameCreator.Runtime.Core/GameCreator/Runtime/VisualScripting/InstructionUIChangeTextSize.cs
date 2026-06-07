using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Font Size")]
	[Category("UI/Change Font Size")]
	[Image(typeof(IconUIText), ColorTheme.Type.TextLight)]
	[Description("Changes the size of the Text or Text Mesh Pro component content")]
	[Parameter("Text", "The Text or Text Mesh Pro component that changes its font size")]
	[Parameter("Size", "The new text size, in pixels")]
	[Keywords(new string[] { "Text" })]
	public class InstructionUIChangeTextSize : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Text = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetInteger m_Size = new PropertyGetInteger(12);

		public override string Title => $"Font Size {m_Text} = {m_Size}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Text.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Text text = gameObject.Get<Text>();
			if (text != null)
			{
				text.fontSize = Mathf.FloorToInt((float)m_Size.Get(args));
				return Instruction.DefaultResult;
			}
			TMP_Text tMP_Text = gameObject.Get<TMP_Text>();
			if (tMP_Text != null)
			{
				tMP_Text.fontSize = (float)m_Size.Get(args);
			}
			return Instruction.DefaultResult;
		}
	}
}
