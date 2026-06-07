using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Replace Strings")]
	[Category("Math/Replace Strings")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow, typeof(OverlayDot))]
	[Description("Replaces all occurrences of a string with another string")]
	[Keywords(new string[] { "String", "Value", "Substitute" })]
	public class GetStringMathReplace : PropertyTypeGetString
	{
		[SerializeField]
		private PropertyGetString m_Text = GetStringString.Create;

		[SerializeField]
		private PropertyGetString m_OldText = new PropertyGetString("Old Text");

		[SerializeField]
		private PropertyGetString m_NewText = new PropertyGetString("New Text");

		public static PropertyGetString Create => new PropertyGetString(new GetStringMathReplace());

		public override string String => $"Replace {m_Text}";

		public override string Get(Args args)
		{
			string text = m_Text.Get(args);
			string oldValue = m_OldText.Get(args);
			string newValue = m_NewText.Get(args);
			return text.Replace(oldValue, newValue);
		}
	}
}
