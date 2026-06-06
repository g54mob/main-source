using System;
using System.Text;
using Febucci.Numbers;

namespace Febucci.Parsing.Core
{
	public sealed class PlainTagParser : TagParserBase
	{
		private readonly string tag;

		private bool hasOpened;

		public Vector2Int[] results;

		public PlainTagParser(string tag, char openingBracket, char closingBracket, char endSymbol)
			: base(openingBracket, endSymbol, closingBracket)
		{
			this.tag = tag;
			results = Array.Empty<Vector2Int>();
		}

		public override bool TryProcessingTag(string textInsideBrackets, int tagLength, ref int realTextIndex, StringBuilder finalTextBuilder, int internalOrder)
		{
			textInsideBrackets = textInsideBrackets.ToLower();
			if (tagLength <= 1)
			{
				return false;
			}
			if (textInsideBrackets[0] == EndSymbol)
			{
				if (!textInsideBrackets.Substring(1, tagLength - 1).Equals(tag))
				{
					return false;
				}
				if (results.Length != 0 && hasOpened)
				{
					results[results.Length - 1].Y = realTextIndex;
					hasOpened = true;
					return true;
				}
				return false;
			}
			if (!textInsideBrackets.Equals(tag))
			{
				return false;
			}
			hasOpened = true;
			Vector2Int vector2Int = new Vector2Int(realTextIndex, int.MaxValue);
			Array.Resize(ref results, results.Length + 1);
			results[results.Length - 1] = vector2Int;
			return true;
		}
	}
}
