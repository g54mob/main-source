namespace RTLTMPro
{
	public static class TextUtils
	{
		public static bool IsNumber(char ch, bool preserverNumbers, bool farsi)
		{
			if (preserverNumbers)
			{
				return IsEnglishNumber(ch);
			}
			if (farsi)
			{
				return IsFarsiNumber(ch);
			}
			return IsHinduNumber(ch);
		}

		public static bool IsEnglishNumber(char ch)
		{
			if (ch >= '0')
			{
				return ch <= '9';
			}
			return false;
		}

		public static bool IsFarsiNumber(char ch)
		{
			if (ch >= '۰')
			{
				return ch <= '۹';
			}
			return false;
		}

		public static bool IsHinduNumber(char ch)
		{
			if (ch >= '٠')
			{
				return ch <= '٩';
			}
			return false;
		}

		public static bool IsEnglishLetter(char ch)
		{
			if (ch >= 'A')
			{
				return ch <= 'z';
			}
			return false;
		}

		public static bool IsRTLCharacter(char ch)
		{
			if (ch >= 'ﺀ' && ch <= 'ﺃ')
			{
				return true;
			}
			if (ch >= 'ﺍ' && ch <= 'ﺐ')
			{
				return true;
			}
			if (ch >= 'ﺃ' && ch <= 'ﺆ')
			{
				return true;
			}
			if (ch >= 'ﺅ' && ch <= 'ﺈ')
			{
				return true;
			}
			if (ch >= 'ﺇ' && ch <= 'ﺊ')
			{
				return true;
			}
			if (ch >= 'ﻯ' && ch <= 'ﻲ')
			{
				return true;
			}
			if (ch >= 'ﺉ' && ch <= 'ﺌ')
			{
				return true;
			}
			if (ch >= 'ﺏ' && ch <= 'ﺒ')
			{
				return true;
			}
			if (ch >= 'ﺕ' && ch <= 'ﺘ')
			{
				return true;
			}
			if (ch >= 'ﺙ' && ch <= 'ﺜ')
			{
				return true;
			}
			if (ch >= 'ﺝ' && ch <= 'ﺠ')
			{
				return true;
			}
			if (ch >= 'ﺡ' && ch <= 'ﺤ')
			{
				return true;
			}
			if (ch >= 'ﺥ' && ch <= 'ﺨ')
			{
				return true;
			}
			if (ch >= 'ﺩ' && ch <= 'ﺬ')
			{
				return true;
			}
			if (ch >= 'ﺫ' && ch <= 'ﺮ')
			{
				return true;
			}
			if (ch >= 'ﺭ' && ch <= 'ﺰ')
			{
				return true;
			}
			if (ch >= 'ﺯ' && ch <= 'ﺲ')
			{
				return true;
			}
			if (ch >= 'ﺱ' && ch <= 'ﺴ')
			{
				return true;
			}
			if (ch >= 'ﺵ' && ch <= 'ﺸ')
			{
				return true;
			}
			if (ch >= 'ﺹ' && ch <= 'ﺼ')
			{
				return true;
			}
			if (ch >= 'ﺽ' && ch <= 'ﻀ')
			{
				return true;
			}
			if (ch >= 'ﻁ' && ch <= 'ﻄ')
			{
				return true;
			}
			if (ch >= 'ﻅ' && ch <= 'ﻈ')
			{
				return true;
			}
			if (ch >= 'ﻉ' && ch <= 'ﻌ')
			{
				return true;
			}
			if (ch >= 'ﻍ' && ch <= 'ﻐ')
			{
				return true;
			}
			if (ch >= 'ﻑ' && ch <= 'ﻔ')
			{
				return true;
			}
			if (ch >= 'ﻕ' && ch <= 'ﻘ')
			{
				return true;
			}
			if (ch >= 'ﻙ' && ch <= 'ﻜ')
			{
				return true;
			}
			if (ch >= 'ﻝ' && ch <= 'ﻠ')
			{
				return true;
			}
			if (ch >= 'ﻡ' && ch <= 'ﻤ')
			{
				return true;
			}
			if (ch >= 'ﻥ' && ch <= 'ﻨ')
			{
				return true;
			}
			if (ch >= 'ﻩ' && ch <= 'ﻬ')
			{
				return true;
			}
			if (ch >= 'ﻭ' && ch <= 'ﻰ')
			{
				return true;
			}
			if (ch >= 'ﻱ' && ch <= 'ﻴ')
			{
				return true;
			}
			if (ch >= 'ﺁ' && ch <= 'ﺄ')
			{
				return true;
			}
			if (ch >= 'ﺓ' && ch <= 'ﺖ')
			{
				return true;
			}
			if (ch >= 'ﭖ' && ch <= 'ﭙ')
			{
				return true;
			}
			if (ch >= 'ﯼ' && ch <= 'ﯿ')
			{
				return true;
			}
			if (ch >= 'ﭺ' && ch <= 'ﭽ')
			{
				return true;
			}
			if (ch >= 'ﮊ' && ch <= 'ﮍ')
			{
				return true;
			}
			if (ch >= 'ﮒ' && ch <= 'ﮕ')
			{
				return true;
			}
			if (ch >= 'ﮎ' && ch <= 'ﮑ')
			{
				return true;
			}
			switch (ch)
			{
			case 'ﻳ':
				return true;
			case 'ﻵ':
				return true;
			case 'ﻷ':
				return true;
			case 'ﻹ':
				return true;
			case 'ء':
			case 'آ':
			case 'أ':
			case 'ؤ':
			case 'إ':
			case 'ئ':
			case 'ا':
			case 'ب':
			case 'ة':
			case 'ت':
			case 'ث':
			case 'ج':
			case 'ح':
			case 'خ':
			case 'د':
			case 'ذ':
			case 'ر':
			case 'ز':
			case 'س':
			case 'ش':
			case 'ص':
			case 'ض':
			case 'ط':
			case 'ظ':
			case 'ع':
			case 'غ':
			case 'ـ':
			case 'ف':
			case 'ق':
			case 'ك':
			case 'ل':
			case 'م':
			case 'ن':
			case 'ه':
			case 'و':
			case 'ى':
			case 'ي':
			case 'پ':
			case 'چ':
			case 'ژ':
			case 'ک':
			case 'گ':
			case 'ی':
			case '\u200c':
				return true;
			default:
				return false;
			}
		}

		public static bool IsRTLInput(string input)
		{
			bool flag = false;
			foreach (char c in input)
			{
				switch (c)
				{
				case '<':
					flag = true;
					continue;
				case '>':
					flag = false;
					continue;
				case '\u064b':
				case '\u064c':
				case '\u064d':
				case '\u064e':
				case '\u064f':
				case '\u0650':
				case '\u0651':
				case '\u0652':
				case '\u0653':
					return true;
				}
				if (!flag && char.IsLetter(c))
				{
					return IsRTLCharacter(c);
				}
			}
			return false;
		}
	}
}
