using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Join Strings")]
	[Category("Math/Join Strings")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow, typeof(OverlayPlus))]
	[Description("Joins two string values")]
	[Keywords(new string[] { "String", "Value", "Concat", "Concatenate", "Stick" })]
	public class GetStringMathJoin : PropertyTypeGetString
	{
		[SerializeField]
		protected PropertyGetString m_Text1 = GetStringString.Create;

		[SerializeField]
		protected PropertyGetString m_Text2 = GetStringString.Create;

		public static PropertyGetString Create => new PropertyGetString(new GetStringMathJoin());

		public override string String => $"({m_Text1} + {m_Text2})";

		public override string EditorValue => m_Text1.EditorValue + m_Text2.EditorValue;

		public override string Get(Args args)
		{
			string text = m_Text1.Get(args);
			string text2 = m_Text2.Get(args);
			return text + text2;
		}
	}
}
