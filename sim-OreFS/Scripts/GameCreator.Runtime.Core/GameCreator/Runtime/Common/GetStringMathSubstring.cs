using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Substring")]
	[Category("Math/Substring")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow, typeof(OverlayBar))]
	[Description("Extracts a substring based on an index and length")]
	[Keywords(new string[] { "String", "Value", "Remove", "Part", "Section" })]
	public class GetStringMathSubstring : PropertyTypeGetString
	{
		[SerializeField]
		private PropertyGetString m_Text = GetStringString.Create;

		[SerializeField]
		private PropertyGetInteger m_Index = GetDecimalInteger.Create(0);

		[SerializeField]
		private PropertyGetInteger m_Length = GetDecimalInteger.Create(5);

		public static PropertyGetString Create => new PropertyGetString(new GetStringMathSubstring());

		public override string String => $"Substring {m_Text}";

		public override string Get(Args args)
		{
			string text = m_Text.Get(args);
			int startIndex = (int)m_Index.Get(args);
			int length = (int)m_Length.Get(args);
			return text.Substring(startIndex, length);
		}
	}
}
