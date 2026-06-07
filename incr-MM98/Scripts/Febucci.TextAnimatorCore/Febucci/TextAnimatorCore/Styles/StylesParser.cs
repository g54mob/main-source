using System.Collections.Generic;
using System.Text;
using Febucci.Parsing.Core;

namespace Febucci.TextAnimatorCore.Styles
{
	internal class StylesParser : TagParserBase
	{
		private bool hasLookupMap;

		private Dictionary<string, Style> stylesLookupMap;

		private List<string> openedTags;

		public StylesParser(char startSymbol, char closingSymbol, char endSymbol, Dictionary<string, Style> stylesLookupMap = null)
			: base(startSymbol, closingSymbol, endSymbol)
		{
			openedTags = new List<string>();
			AssignLookup(stylesLookupMap);
		}

		public void AssignLookup(Dictionary<string, Style> stylesLookupMap)
		{
			this.stylesLookupMap = stylesLookupMap;
			hasLookupMap = stylesLookupMap != null && stylesLookupMap.Count > 0;
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			if (!hasLookupMap)
			{
				return false;
			}
			textInsideBrackets = textInsideBrackets.ToLower();
			bool flag = textInsideBrackets[0] == EndSymbol;
			int startIndex = (flag ? 1 : 0);
			string text = textInsideBrackets.Substring(startIndex);
			if (stylesLookupMap.TryGetValue(text, out var value))
			{
				if (flag)
				{
					if (openedTags.Contains(text))
					{
						finalTextBuilder.Append(value.closingTag);
						openedTags.Remove(text);
					}
				}
				else
				{
					finalTextBuilder.Append(value.openingTag);
					openedTags.Add(text);
				}
				return true;
			}
			return false;
		}
	}
}
