using System.Text;
using UnityEngine;

namespace Febucci.UI.Core.Parsing
{
	public static class TextParser
	{
		public static string ParseText(string text, params TagParserBase[] rules)
		{
			if (rules == null || rules.Length == 0)
			{
				Debug.LogWarning("No rules were provided to parse the text. Skipping");
				return text;
			}
			TagParserBase[] array = rules;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initialize();
			}
			StringBuilder result = new StringBuilder();
			char[] array2 = text.ToCharArray();
			int num = array2.Length;
			bool flag = true;
			int textIndex = 0;
			int realTextIndex = 0;
			bool foundTag;
			string fullTag;
			for (; textIndex < num; textIndex++)
			{
				foundTag = false;
				int closeIndex;
				if (array2[textIndex] == '<')
				{
					closeIndex = text.IndexOf('>', textIndex + 1);
					if (closeIndex > 0)
					{
						int length = closeIndex - textIndex + 1;
						fullTag = text.Substring(textIndex, length);
						string text2 = fullTag.ToLower();
						if (!(text2 == "<noparse>"))
						{
							if (text2 == "</noparse>")
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
					array = rules;
					foreach (TagParserBase tagParserBase in array)
					{
						if (array2[textIndex] != tagParserBase.startSymbol)
						{
							continue;
						}
						for (int j = textIndex + 1; j < num; j++)
						{
							if (foundTag)
							{
								break;
							}
							if (array2[j] == tagParserBase.startSymbol)
							{
								break;
							}
							if (array2[j] == tagParserBase.endSymbol)
							{
								int num2 = j - textIndex - 1;
								if (num2 == 0)
								{
									break;
								}
								if (tagParserBase.TryProcessingTag(text.Substring(textIndex + 1, num2), num2, ref realTextIndex, result, textIndex))
								{
									foundTag = true;
									textIndex = j;
									break;
								}
							}
						}
					}
				}
				if (!foundTag)
				{
					result.Append(array2[textIndex]);
					realTextIndex++;
				}
				void PasteTagToText()
				{
					foundTag = true;
					result.Append(fullTag);
					textIndex = closeIndex;
				}
			}
			return result.ToString();
		}
	}
}
