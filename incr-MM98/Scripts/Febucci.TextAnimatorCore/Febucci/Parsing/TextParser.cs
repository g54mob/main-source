using System.Text;
using Febucci.Parsing.Core;

namespace Febucci.Parsing
{
	public class TextParser
	{
		private readonly bool pasteNoParseTag;

		private readonly char openingBracket;

		private readonly char closingBracket;

		public const char NONE_CHARACTER = '\0';

		public TextParser(bool pasteNoParseTag, char openingBracket, char closingBracket)
		{
			this.openingBracket = openingBracket;
			this.closingBracket = closingBracket;
			this.pasteNoParseTag = pasteNoParseTag;
		}

		public string ParseText(string text, params TagParserBase[] rules)
		{
			if (rules == null || rules.Length == 0)
			{
				return text;
			}
			foreach (TagParserBase tagParserBase in rules)
			{
				tagParserBase.Initialize();
			}
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			StringBuilder result = new StringBuilder();
			char[] array = text.ToCharArray();
			int num = array.Length;
			bool flag = true;
			int textIndex = 0;
			int realTextIndex = 0;
			bool foundTag;
			string fullTag;
			for (; textIndex < num; textIndex++)
			{
				foundTag = false;
				int closeIndex;
				if (array[textIndex] == openingBracket)
				{
					closeIndex = text.IndexOf(closingBracket, textIndex + 1);
					if (closeIndex > 0)
					{
						int length = closeIndex - textIndex - 1;
						fullTag = text.Substring(textIndex + 1, length);
						string text2 = fullTag.ToLower();
						if (!(text2 == "noparse"))
						{
							if (text2 == "/noparse")
							{
								flag = true;
								PasteTagToText();
							}
						}
						else
						{
							flag = false;
							PasteTagToText();
						}
					}
				}
				if (flag && !foundTag)
				{
					foreach (TagParserBase tagParserBase2 in rules)
					{
						if (array[textIndex] != tagParserBase2.OpeningBracket)
						{
							continue;
						}
						for (int k = textIndex + 1; k < num; k++)
						{
							if (foundTag)
							{
								break;
							}
							if (array[k] == tagParserBase2.OpeningBracket)
							{
								break;
							}
							if (array[k] == tagParserBase2.ClosingBracket)
							{
								int num2 = k - textIndex - 1;
								if (num2 == 0)
								{
									break;
								}
								if (tagParserBase2.TryProcessingTag(text.Substring(textIndex + 1, num2), num2, ref realTextIndex, result, textIndex))
								{
									foundTag = true;
									textIndex = k;
									break;
								}
							}
						}
					}
				}
				if (!foundTag)
				{
					char value = array[textIndex];
					result.Append(value);
					realTextIndex++;
				}
				void PasteTagToText()
				{
					foundTag = true;
					if (pasteNoParseTag)
					{
						result.Append(openingBracket + fullTag + closingBracket);
					}
					textIndex = closeIndex;
				}
			}
			foreach (TagParserBase tagParserBase3 in rules)
			{
				tagParserBase3.FinishParsing();
			}
			return result.ToString();
		}
	}
}
