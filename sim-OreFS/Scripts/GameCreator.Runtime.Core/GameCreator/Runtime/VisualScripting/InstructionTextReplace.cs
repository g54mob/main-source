using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Replace")]
	[Description("Replaces all occurrences of a string with another string")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow, typeof(OverlayDot))]
	[Category("Math/Text/Replace")]
	[Parameter("Text", "The source of the text")]
	[Parameter("Old Text", "The text replaced")]
	[Parameter("New Text", "The text that replaces each occurrence")]
	[Keywords(new string[] { "Substitute", "Change" })]
	public class InstructionTextReplace : TInstructionText
	{
		[SerializeField]
		private PropertyGetString m_Text = GetStringString.Create;

		[SerializeField]
		private PropertyGetString m_OldText = new PropertyGetString("Old Text");

		[SerializeField]
		private PropertyGetString m_NewText = new PropertyGetString("New Text");

		public override string Title => $"Set {m_Set} = Replace on {m_Text}";

		protected override Task Run(Args args)
		{
			string text = m_Text.Get(args);
			string oldValue = m_OldText.Get(args);
			string newValue = m_NewText.Get(args);
			m_Set.Set(text.Replace(oldValue, newValue), args);
			return Instruction.DefaultResult;
		}
	}
}
