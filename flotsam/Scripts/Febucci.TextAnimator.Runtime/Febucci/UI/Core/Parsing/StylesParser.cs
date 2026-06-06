using System.Collections.Generic;
using System.Text;
using Febucci.UI.Styles;

namespace Febucci.UI.Core.Parsing
{
	public class StylesParser : TagParserBase
	{
		private StyleSheetScriptable sheet;

		private List<string> openedTags;

		public StylesParser(char startSymbol, char closingSymbol, char endSymbol, StyleSheetScriptable sheet)
			: base(startSymbol, closingSymbol, endSymbol)
		{
			this.sheet = sheet;
			openedTags = new List<string>();
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (!sheet)
			{
				return false;
			}
			textInsideBrackets = textInsideBrackets.ToLower();
			sheet.BuildOnce();
			bool flag = textInsideBrackets[0] == closingSymbol;
			int startIndex = (flag ? 1 : 0);
			string text = textInsideBrackets.Substring(startIndex);
			if (sheet.TryGetStyle(text, out var result))
			{
				if (flag)
				{
					if (openedTags.Contains(text))
					{
						finalTextBuilder.Append(result.closingTag);
						openedTags.Remove(text);
					}
				}
				else
				{
					finalTextBuilder.Append(result.openingTag);
					openedTags.Add(text);
				}
				return true;
			}
			return false;
		}
	}
}
