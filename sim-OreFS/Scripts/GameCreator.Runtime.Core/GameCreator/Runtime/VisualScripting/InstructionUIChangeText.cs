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
	[Title("Change Text")]
	[Category("UI/Change Text")]
	[Image(typeof(IconUIText), ColorTheme.Type.TextLight)]
	[Description("Changes the value of a Text or Text Mesh Pro component")]
	[Parameter("Text", "The Text or Text Mesh Pro component that changes its value")]
	[Parameter("Value", "The new value set")]
	public class InstructionUIChangeText : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Text = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetString m_Value = GetStringString.Create;

		public override string Title => $"Text {m_Text} = {m_Value}";

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
				text.text = m_Value.Get(args);
				return Instruction.DefaultResult;
			}
			TMP_Text tMP_Text = gameObject.Get<TMP_Text>();
			if (tMP_Text != null)
			{
				tMP_Text.text = m_Value.Get(args);
			}
			return Instruction.DefaultResult;
		}
	}
}
