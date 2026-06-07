using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Text Equals")]
	[Description("Returns true if two text Strings are equal")]
	[Category("Text/Text Equals")]
	[Parameter("Text 1", "The first text string to compare")]
	[Parameter("Text 2", "The second text string to compare")]
	[Keywords(new string[] { "String", "Char" })]
	[Image(typeof(IconString), ColorTheme.Type.Yellow)]
	public class ConditionTextEquals : Condition
	{
		[SerializeField]
		private PropertyGetString m_Text1 = new PropertyGetString();

		[SerializeField]
		private PropertyGetString m_Text2 = new PropertyGetString();

		protected override string Summary => $"{m_Text1} = {m_Text2}";

		protected override bool Run(Args args)
		{
			string text = m_Text1.Get(args);
			string text2 = m_Text2.Get(args);
			return text == text2;
		}
	}
}
