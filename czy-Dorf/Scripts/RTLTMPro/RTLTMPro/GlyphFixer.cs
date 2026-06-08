using System.Collections.Generic;

namespace RTLTMPro
{
	public static class GlyphFixer
	{
		public static Dictionary<char, char> EnglishToFarsiNumberMap = new Dictionary<char, char>
		{
			['0'] = '۰',
			['1'] = '۱',
			['2'] = '۲',
			['3'] = '۳',
			['4'] = '۴',
			['5'] = '۵',
			['6'] = '۶',
			['7'] = '۷',
			['8'] = '۸',
			['9'] = '۹'
		};

		public static Dictionary<char, char> EnglishToHinduNumberMap = new Dictionary<char, char>
		{
			['0'] = '٠',
			['1'] = '١',
			['2'] = '٢',
			['3'] = '٣',
			['4'] = '٤',
			['5'] = '٥',
			['6'] = '٦',
			['7'] = '٧',
			['8'] = '٨',
			['9'] = '٩'
		};

		public static void Fix(FastStringBuilder input, FastStringBuilder output, bool preserveNumbers, bool farsi, bool fixTextTags)
		{
			FixYah(input, farsi);
			output.SetValue(input);
			for (int i = 0; i < input.Length; i++)
			{
				bool flag = false;
				char c = input.Get(i);
				if (c == 'ل' && i < input.Length - 1)
				{
					flag = HandleSpecialLam(input, output, i);
					if (flag)
					{
						c = output.Get(i);
					}
				}
				if (c == 'ـ' || c == '\u200c')
				{
					continue;
				}
				if (TextUtils.IsRTLCharacter(c))
				{
					char c2 = GlyphTable.Convert(c);
					if (IsMiddleLetter(input, i))
					{
						output.Set(i, (char)(c2 + 3));
					}
					else if (IsFinishingLetter(input, i))
					{
						output.Set(i, (char)(c2 + 1));
					}
					else if (IsLeadingLetter(input, i))
					{
						output.Set(i, (char)(c2 + 2));
					}
				}
				if (flag)
				{
					i++;
				}
			}
			if (!preserveNumbers)
			{
				if (fixTextTags)
				{
					FixNumbersOutsideOfTags(output, farsi);
				}
				else
				{
					FixNumbers(output, farsi);
				}
			}
		}

		public static void FixYah(FastStringBuilder text, bool farsi)
		{
			for (int i = 0; i < text.Length; i++)
			{
				if (farsi && text.Get(i) == 'ي')
				{
					text.Set(i, 'ی');
				}
				else if (!farsi && text.Get(i) == 'ی')
				{
					text.Set(i, 'ي');
				}
			}
		}

		private static bool HandleSpecialLam(FastStringBuilder input, FastStringBuilder output, int i)
		{
			bool flag;
			switch (input.Get(i + 1))
			{
			case 'إ':
				output.Set(i, 'ﻷ');
				flag = true;
				break;
			case 'ا':
				output.Set(i, 'ﻹ');
				flag = true;
				break;
			case 'أ':
				output.Set(i, 'ﻵ');
				flag = true;
				break;
			case 'آ':
				output.Set(i, 'ﻳ');
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				output.Set(i + 1, '\uffff');
			}
			return flag;
		}

		public static void FixNumbers(FastStringBuilder text, bool farsi)
		{
			text.Replace('0', farsi ? '۰' : '٠');
			text.Replace('1', farsi ? '۱' : '١');
			text.Replace('2', farsi ? '۲' : '٢');
			text.Replace('3', farsi ? '۳' : '٣');
			text.Replace('4', farsi ? '۴' : '٤');
			text.Replace('5', farsi ? '۵' : '٥');
			text.Replace('6', farsi ? '۶' : '٦');
			text.Replace('7', farsi ? '۷' : '٧');
			text.Replace('8', farsi ? '۸' : '٨');
			text.Replace('9', farsi ? '۹' : '٩');
		}

		public static void FixNumbersOutsideOfTags(FastStringBuilder text, bool farsi)
		{
			HashSet<char> hashSet = new HashSet<char>(EnglishToFarsiNumberMap.Keys);
			for (int i = 0; i < text.Length; i++)
			{
				char c = text.Get(i);
				if (c == '<')
				{
					bool flag = false;
					for (int j = i + 1; j < text.Length; j++)
					{
						char c2 = text.Get(j);
						if (j != i + 1 || c2 != ' ')
						{
							switch (c2)
							{
							case '>':
								i = j;
								flag = true;
								break;
							default:
								continue;
							case '<':
								break;
							}
						}
						break;
					}
					if (flag)
					{
						continue;
					}
				}
				if (hashSet.Contains(c))
				{
					text.Set(i, farsi ? EnglishToFarsiNumberMap[c] : EnglishToHinduNumberMap[c]);
				}
			}
		}

		private static bool IsLeadingLetter(FastStringBuilder letters, int index)
		{
			char c = letters.Get(index);
			char c2 = '\0';
			if (index != 0)
			{
				c2 = letters.Get(index - 1);
			}
			char c3 = '\0';
			if (index < letters.Length - 1)
			{
				c3 = letters.Get(index + 1);
			}
			bool num = index == 0 || !TextUtils.IsRTLCharacter(c2) || c2 == 'ا' || c2 == 'د' || c2 == 'ذ' || c2 == 'ر' || c2 == 'ز' || c2 == 'ژ' || c2 == 'و' || c2 == 'آ' || c2 == 'أ' || c2 == 'ء' || c2 == 'إ' || c2 == '\u200c' || c2 == 'ؤ' || c2 == 'ﺍ' || c2 == 'ﺩ' || c2 == 'ﺫ' || c2 == 'ﺭ' || c2 == 'ﺯ' || c2 == 'ﮊ' || c2 == 'ﻭ' || c2 == 'ﺁ' || c2 == 'ﺃ' || c2 == 'ﺀ' || c2 == 'ﺇ';
			bool flag = c != ' ' && c != 'د' && c != 'ذ' && c != 'ر' && c != 'ز' && c != 'ژ' && c != 'ا' && c != 'أ' && c != 'إ' && c != 'آ' && c != 'ؤ' && c != 'و' && c != '\u200c' && c != 'ء';
			bool flag2 = index < letters.Length - 1 && TextUtils.IsRTLCharacter(c3) && c3 != 'ء' && c3 != '\u200c';
			return num && flag && flag2;
		}

		private static bool IsFinishingLetter(FastStringBuilder letters, int index)
		{
			char c = letters.Get(index);
			char c2 = '\0';
			if (index != 0)
			{
				c2 = letters.Get(index - 1);
			}
			bool num = index != 0 && c2 != ' ' && c2 != 'د' && c2 != 'ذ' && c2 != 'ر' && c2 != 'ز' && c2 != 'ژ' && c2 != 'و' && c2 != 'ا' && c2 != 'آ' && c2 != 'أ' && c2 != 'إ' && c2 != 'ؤ' && c2 != 'ء' && c2 != '\u200c' && c2 != 'ﺩ' && c2 != 'ﺫ' && c2 != 'ﺭ' && c2 != 'ﺯ' && c2 != 'ﮊ' && c2 != 'ﻭ' && c2 != 'ﺍ' && c2 != 'ﺁ' && c2 != 'ﺃ' && c2 != 'ﺇ' && c2 != 'ﺅ' && c2 != 'ﺀ' && TextUtils.IsRTLCharacter(c2);
			bool flag = c != ' ' && c != '\u200c' && c != 'ء';
			return num && flag;
		}

		private static bool IsMiddleLetter(FastStringBuilder letters, int index)
		{
			char c = letters.Get(index);
			char c2 = '\0';
			if (index != 0)
			{
				c2 = letters.Get(index - 1);
			}
			char c3 = '\0';
			if (index < letters.Length - 1)
			{
				c3 = letters.Get(index + 1);
			}
			bool flag = index != 0 && c != 'ا' && c != 'د' && c != 'ذ' && c != 'ر' && c != 'ز' && c != 'ژ' && c != 'و' && c != 'آ' && c != 'أ' && c != 'إ' && c != 'ؤ' && c != '\u200c' && c != 'ء';
			bool flag2 = index != 0 && c2 != 'ا' && c2 != 'د' && c2 != 'ذ' && c2 != 'ر' && c2 != 'ز' && c2 != 'ژ' && c2 != 'و' && c2 != 'آ' && c2 != 'أ' && c2 != 'إ' && c2 != 'ؤ' && c2 != 'ء' && c2 != '\u200c' && c2 != 'ﺍ' && c2 != 'ﺩ' && c2 != 'ﺫ' && c2 != 'ﺭ' && c2 != 'ﺯ' && c2 != 'ﮊ' && c2 != 'ﻭ' && c2 != 'ﺁ' && c2 != 'ﺃ' && c2 != 'ﺇ' && c2 != 'ﺅ' && c2 != 'ﺀ' && TextUtils.IsRTLCharacter(c2);
			return index < letters.Length - 1 && TextUtils.IsRTLCharacter(c3) && c3 != '\u200c' && c3 != 'ء' && c3 != 'ﺀ' && flag2 && flag;
		}
	}
}
