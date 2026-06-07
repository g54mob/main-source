using System.Collections.Generic;

public class ArabicHelper
{
	private struct CharRep
	{
		public char code;

		public char code2;

		public char isolated;

		public char initial;

		public char medial;

		public char final;

		public CharRep(char newCode, char newIsolated, char newInitial, char newMedial, char newFinal)
		{
			code = newCode;
			code2 = '\0';
			isolated = newIsolated;
			initial = newInitial;
			medial = newMedial;
			final = newFinal;
		}

		public CharRep(char newCode, char newCode2, char newIsolated, char newInitial, char newMedial, char newFinal)
		{
			code = newCode;
			code2 = newCode2;
			isolated = newIsolated;
			initial = newInitial;
			medial = newMedial;
			final = newFinal;
		}
	}

	private const char NullChar = '\0';

	private static ArabicHelper _instance;

	private List<CharRep> _charMap = new List<CharRep>();

	private CharRep _nilCharRep;

	private List<CharRep> _combCharsMap = new List<CharRep>();

	private CharRep _nilCombCharRep;

	private List<char> _transparentChars = new List<char>();

	public static ArabicHelper Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new ArabicHelper();
			}
			return _instance;
		}
	}

	private ArabicHelper()
	{
		BuildCharacterMaps();
	}

	public string ConvertArabic(string normal)
	{
		int length = normal.Length;
		string text = "";
		int num = 0;
		while (num < length)
		{
			char c = normal[num];
			if (CharacterMapContains(c))
			{
				char c2 = '\0';
				char c3 = '\0';
				int num2 = num - 1;
				int i = num + 1;
				while (num2 >= 0 && IsTransparent(normal[num2]))
				{
					num2--;
				}
				if (num2 >= 0)
				{
					c2 = normal[num2];
					if (CharacterMapContains(c2))
					{
						CharRep charRep = GetCharRep(c2);
						if (charRep.initial == '\0' || charRep.medial == '\0')
						{
							c2 = '\0';
						}
					}
					else
					{
						c2 = '\0';
					}
				}
				for (; i < length && IsTransparent(normal[i]); i++)
				{
				}
				if (i < length)
				{
					c3 = normal[i];
					if (CharacterMapContains(c3))
					{
						CharRep charRep2 = GetCharRep(c3);
						if (charRep2.medial == '\0' && charRep2.final == '\0' && c3 != 'ـ')
						{
							c3 = '\0';
						}
					}
					else
					{
						c3 = '\0';
					}
				}
				if (c == 'ل')
				{
					switch (c3)
					{
					case 'آ':
					case 'أ':
					case 'إ':
					case 'ا':
					{
						CharRep combCharRep = GetCombCharRep(c, c3);
						text = ((c2 == '\0') ? (text + combCharRep.isolated) : (text + combCharRep.final));
						num += 2;
						continue;
					}
					}
				}
				CharRep charRep3 = GetCharRep(c);
				if (c2 != 0 && c3 != 0 && charRep3.medial != 0)
				{
					text += charRep3.medial;
					num++;
					continue;
				}
				if (c2 != 0 && charRep3.final != 0)
				{
					text += charRep3.final;
					num++;
					continue;
				}
				if (c3 != 0 && charRep3.initial != 0)
				{
					text += charRep3.initial;
					num++;
					continue;
				}
				text += charRep3.isolated;
			}
			else
			{
				text += c;
			}
			num++;
		}
		return text;
	}

	private void BuildCharacterMaps()
	{
		_charMap.Add(new CharRep('ء', 'ﺀ', '\0', '\0', '\0'));
		_charMap.Add(new CharRep('آ', 'ﺁ', '\0', '\0', 'ﺂ'));
		_charMap.Add(new CharRep('أ', 'ﺃ', '\0', '\0', 'ﺄ'));
		_charMap.Add(new CharRep('ؤ', 'ﺅ', '\0', '\0', 'ﺆ'));
		_charMap.Add(new CharRep('إ', 'ﺇ', '\0', '\0', 'ﺈ'));
		_charMap.Add(new CharRep('ئ', 'ﺉ', 'ﺋ', 'ﺌ', 'ﺊ'));
		_charMap.Add(new CharRep('ا', 'ﺍ', '\0', '\0', 'ﺎ'));
		_charMap.Add(new CharRep('ب', 'ﺏ', 'ﺑ', 'ﺒ', 'ﺐ'));
		_charMap.Add(new CharRep('ة', 'ﺓ', '\0', '\0', 'ﺔ'));
		_charMap.Add(new CharRep('ت', 'ﺕ', 'ﺗ', 'ﺘ', 'ﺖ'));
		_charMap.Add(new CharRep('ث', 'ﺙ', 'ﺛ', 'ﺜ', 'ﺚ'));
		_charMap.Add(new CharRep('ج', 'ﺝ', 'ﺟ', 'ﺠ', 'ﺞ'));
		_charMap.Add(new CharRep('ح', 'ﺡ', 'ﺣ', 'ﺤ', 'ﺢ'));
		_charMap.Add(new CharRep('خ', 'ﺥ', 'ﺧ', 'ﺨ', 'ﺦ'));
		_charMap.Add(new CharRep('د', 'ﺩ', '\0', '\0', 'ﺪ'));
		_charMap.Add(new CharRep('ذ', 'ﺫ', '\0', '\0', 'ﺬ'));
		_charMap.Add(new CharRep('ر', 'ﺭ', '\0', '\0', 'ﺮ'));
		_charMap.Add(new CharRep('ز', 'ﺯ', '\0', '\0', 'ﺰ'));
		_charMap.Add(new CharRep('س', 'ﺱ', 'ﺳ', 'ﺴ', 'ﺲ'));
		_charMap.Add(new CharRep('ش', 'ﺵ', 'ﺷ', 'ﺸ', 'ﺶ'));
		_charMap.Add(new CharRep('ص', 'ﺹ', 'ﺻ', 'ﺼ', 'ﺺ'));
		_charMap.Add(new CharRep('ض', 'ﺽ', 'ﺿ', 'ﻀ', 'ﺾ'));
		_charMap.Add(new CharRep('ط', 'ﻁ', 'ﻃ', 'ﻄ', 'ﻂ'));
		_charMap.Add(new CharRep('ظ', 'ﻅ', 'ﻇ', 'ﻈ', 'ﻆ'));
		_charMap.Add(new CharRep('ع', 'ﻉ', 'ﻋ', 'ﻌ', 'ﻊ'));
		_charMap.Add(new CharRep('غ', 'ﻍ', 'ﻏ', 'ﻐ', 'ﻎ'));
		_charMap.Add(new CharRep('ـ', 'ـ', '\0', '\0', '\0'));
		_charMap.Add(new CharRep('ف', 'ﻑ', 'ﻓ', 'ﻔ', 'ﻒ'));
		_charMap.Add(new CharRep('ق', 'ﻕ', 'ﻗ', 'ﻘ', 'ﻖ'));
		_charMap.Add(new CharRep('ك', 'ﻙ', 'ﻛ', 'ﻜ', 'ﻚ'));
		_charMap.Add(new CharRep('ل', 'ﻝ', 'ﻟ', 'ﻠ', 'ﻞ'));
		_charMap.Add(new CharRep('م', 'ﻡ', 'ﻣ', 'ﻤ', 'ﻢ'));
		_charMap.Add(new CharRep('ن', 'ﻥ', 'ﻧ', 'ﻨ', 'ﻦ'));
		_charMap.Add(new CharRep('ه', 'ﻩ', 'ﻫ', 'ﻬ', 'ﻪ'));
		_charMap.Add(new CharRep('و', 'ﻭ', '\0', '\0', 'ﻮ'));
		_charMap.Add(new CharRep('ى', 'ﻯ', '\0', '\0', 'ﻰ'));
		_charMap.Add(new CharRep('ي', 'ﻱ', 'ﻳ', 'ﻴ', 'ﻲ'));
		_nilCharRep = new CharRep('\0', '\0', '\0', '\0', '\0');
		_combCharsMap.Add(new CharRep('ل', 'آ', 'ﻵ', '\0', '\0', 'ﻶ'));
		_combCharsMap.Add(new CharRep('ل', 'أ', 'ﻷ', '\0', '\0', 'ﻸ'));
		_combCharsMap.Add(new CharRep('ل', 'إ', 'ﻹ', '\0', '\0', 'ﻺ'));
		_combCharsMap.Add(new CharRep('ل', 'ا', 'ﻻ', '\0', '\0', 'ﻼ'));
		_nilCombCharRep = new CharRep('\0', '\0', '\0', '\0', '\0', '\0');
		_transparentChars.Add('\u0610');
		_transparentChars.Add('\u0612');
		_transparentChars.Add('\u0613');
		_transparentChars.Add('\u0614');
		_transparentChars.Add('\u0615');
		_transparentChars.Add('\u064b');
		_transparentChars.Add('\u064c');
		_transparentChars.Add('\u064d');
		_transparentChars.Add('\u064e');
		_transparentChars.Add('\u064f');
		_transparentChars.Add('\u0650');
		_transparentChars.Add('\u0651');
		_transparentChars.Add('\u0652');
		_transparentChars.Add('\u0653');
		_transparentChars.Add('\u0654');
		_transparentChars.Add('\u0655');
		_transparentChars.Add('\u0656');
		_transparentChars.Add('\u0657');
		_transparentChars.Add('\u0658');
		_transparentChars.Add('\u0670');
		_transparentChars.Add('\u06d6');
		_transparentChars.Add('\u06d7');
		_transparentChars.Add('\u06d8');
		_transparentChars.Add('\u06d9');
		_transparentChars.Add('\u06da');
		_transparentChars.Add('\u06db');
		_transparentChars.Add('\u06dc');
		_transparentChars.Add('\u06df');
		_transparentChars.Add('\u06e0');
		_transparentChars.Add('\u06e1');
		_transparentChars.Add('\u06e2');
		_transparentChars.Add('\u06e3');
		_transparentChars.Add('\u06e4');
		_transparentChars.Add('\u06e7');
		_transparentChars.Add('\u06e8');
		_transparentChars.Add('\u06ea');
		_transparentChars.Add('\u06eb');
		_transparentChars.Add('\u06ec');
		_transparentChars.Add('\u06ed');
	}

	private bool CharacterMapContains(char c)
	{
		for (int i = 0; i < _charMap.Count; i++)
		{
			if (_charMap[i].code == c)
			{
				return true;
			}
		}
		return false;
	}

	private CharRep GetCharRep(char c)
	{
		for (int i = 0; i < _charMap.Count; i++)
		{
			if (_charMap[i].code == c)
			{
				return _charMap[i];
			}
		}
		return _nilCharRep;
	}

	private CharRep GetCombCharRep(char c1, char c2)
	{
		for (int i = 0; i < _combCharsMap.Count; i++)
		{
			if (_combCharsMap[i].code == c1 && _combCharsMap[i].code2 == c2)
			{
				return _combCharsMap[i];
			}
		}
		return _nilCombCharRep;
	}

	private bool IsTransparent(char c)
	{
		for (int i = 0; i < _transparentChars.Count; i++)
		{
			if (_transparentChars[i] == c)
			{
				return true;
			}
		}
		return false;
	}
}
