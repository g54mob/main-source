using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Text Contains")]
	[Description("Returns true if the second text string occurs in the first one")]
	[Category("Text/Text Contains")]
	[Parameter("Text", "The text string")]
	[Parameter("Substring", "The text string contained in Text")]
	[Keywords(new string[] { "String", "Char", "Sub" })]
	[Image(typeof(IconString), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	public class ConditionTextContains : Condition
	{
		[SerializeField]
		private PropertyGetString m_Text = new PropertyGetString();

		[SerializeField]
		private PropertyGetString m_Substring = new PropertyGetString();

		protected override string Summary => $"{m_Text} contains {m_Substring}";

		protected override bool Run(Args args)
		{
			string text = m_Text.Get(args);
			string value = m_Substring.Get(args);
			return text.Contains(value);
		}
	}
}
