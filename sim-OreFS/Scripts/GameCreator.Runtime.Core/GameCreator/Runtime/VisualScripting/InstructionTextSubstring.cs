using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Substring")]
	[Description("Extracts a substring based on an index and length")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow, typeof(OverlayBar))]
	[Category("Math/Text/Substring")]
	[Parameter("Text", "The source of the text")]
	[Parameter("Index", "Starting index of the substring")]
	[Parameter("Length", "Amount of characters extracted")]
	public class InstructionTextSubstring : TInstructionText
	{
		[SerializeField]
		private PropertyGetString m_Text = GetStringString.Create;

		[SerializeField]
		private PropertyGetInteger m_Index = GetDecimalInteger.Create(0);

		[SerializeField]
		private PropertyGetInteger m_Length = GetDecimalInteger.Create(5);

		public override string Title => $"Set {m_Set} = Substring of {m_Text}";

		protected override Task Run(Args args)
		{
			string text = m_Text.Get(args);
			int startIndex = (int)m_Index.Get(args);
			int length = (int)m_Length.Get(args);
			m_Set.Set(text.Substring(startIndex, length), args);
			return Instruction.DefaultResult;
		}
	}
}
