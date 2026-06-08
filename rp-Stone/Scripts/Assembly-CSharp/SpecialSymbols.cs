using System.Collections.Generic;
using System.Text;

public class SpecialSymbols
{
	public const int CLEAR = 32;

	public const char KI_SYMBOL = '@';

	public const char CRYSTAL_SYMBOL = '♦';

	public const int LEGEND = 21;

	private static Dictionary<int, char> reverseMap = new Dictionary<int, char>();

	public static char MapUnicode(char u)
	{
		return u switch
		{
			'฿' => '₿', 
			'￠' => '¢', 
			'﷼' => 'Y', 
			'㍐' => '¥', 
			'৳' => 'B', 
			'৲' => 'B', 
			'௹' => '₹', 
			'៛' => 'K', 
			_ => u, 
		};
	}

	public static int Map(char c)
	{
		if (c <= '\u007f')
		{
			return c;
		}
		int num = _MapInternal(c);
		if (!reverseMap.ContainsKey(num))
		{
			reverseMap.Add(num, c);
		}
		return num;
	}

	public static char ReverseMap(int value)
	{
		if (reverseMap.ContainsKey(value))
		{
			return reverseMap[value];
		}
		if (value <= 127)
		{
			return (char)value;
		}
		return ' ';
	}

	private static int _MapInternal(char c)
	{
		switch (c)
		{
		case '☆':
			return 0;
		case '☺':
			return 1;
		case 'ʘ':
			return 2;
		case '♥':
		case '❤':
			return 3;
		case '♦':
			return 4;
		case '♣':
			return 5;
		case '♠':
			return 6;
		case '•':
			return 7;
		case '◘':
			return 8;
		case '⏹':
			return 9;
		case '◙':
			return 10;
		case '♂':
			return 11;
		case '♀':
			return 12;
		case '♪':
			return 13;
		case '♫':
			return 14;
		case '☼':
			return 15;
		case '▶':
			return 16;
		case '◀':
			return 17;
		case 'À':
			return 18;
		case '⚿':
			return 19;
		case 'Œ':
		case 'œ':
			return 20;
		case '§':
			return 21;
		case '≠':
			return 22;
		case '¿':
			return 23;
		case '↑':
			return 24;
		case '↓':
			return 25;
		case '→':
			return 26;
		case '←':
			return 27;
		case '\u00af':
		case '‾':
			return 28;
		case '¡':
			return 29;
		case '▲':
			return 30;
		case '▼':
			return 31;
		case '"':
		case '＂':
			return 34;
		case '$':
		case '＄':
			return 36;
		case '[':
		case '［':
			return 91;
		case ']':
		case '］':
			return 93;
		case '{':
		case '｛':
			return 123;
		case '}':
		case '｝':
			return 125;
		case '\u00b4':
			return 127;
		case 'Ç':
			return 128;
		case 'ü':
			return 129;
		case 'é':
			return 130;
		case 'â':
			return 131;
		case 'ä':
			return 132;
		case 'à':
			return 133;
		case 'å':
			return 134;
		case 'ç':
			return 135;
		case 'ê':
			return 136;
		case 'ë':
			return 137;
		case 'è':
			return 138;
		case 'ï':
			return 139;
		case 'î':
			return 140;
		case 'ì':
			return 141;
		case 'Ä':
			return 142;
		case 'Å':
			return 143;
		case 'É':
			return 144;
		case 'æ':
			return 145;
		case 'Æ':
			return 146;
		case 'ô':
			return 147;
		case 'ö':
			return 148;
		case 'ò':
			return 149;
		case 'û':
			return 150;
		case 'ù':
			return 151;
		case 'ý':
			return 152;
		case 'Ö':
			return 153;
		case 'Ü':
			return 154;
		case '€':
			return 155;
		case '£':
		case '￡':
			return 156;
		case '¥':
		case '￥':
			return 157;
		case '₩':
		case '￦':
			return 158;
		case 'Á':
			return 159;
		case 'á':
			return 160;
		case 'í':
			return 161;
		case 'ó':
			return 162;
		case 'ú':
			return 163;
		case 'ñ':
			return 164;
		case 'Ñ':
			return 165;
		case 'ã':
			return 166;
		case 'õ':
			return 167;
		case 'ζ':
			return 168;
		case 'η':
			return 169;
		case 'ξ':
			return 170;
		case 'λ':
			return 171;
		case 'ψ':
			return 172;
		case 'έ':
			return 173;
		case '«':
			return 174;
		case '»':
			return 175;
		case '┌':
			return 218;
		case '┐':
			return 191;
		case '└':
			return 192;
		case '┘':
			return 217;
		case '│':
			return 179;
		case '—':
		case '─':
			return 196;
		case '┴':
			return 193;
		case '├':
			return 195;
		case '┬':
			return 194;
		case '┤':
			return 180;
		case '┼':
			return 197;
		case '╒':
			return 213;
		case '╕':
			return 184;
		case '╘':
			return 212;
		case '╛':
			return 190;
		case '╧':
			return 207;
		case '╞':
			return 198;
		case '╤':
			return 209;
		case '╡':
			return 181;
		case '╪':
			return 216;
		case '╓':
			return 214;
		case '╖':
			return 183;
		case '╙':
			return 211;
		case '╜':
			return 189;
		case '╨':
			return 208;
		case '╟':
			return 199;
		case '╥':
			return 210;
		case '╢':
			return 182;
		case '╫':
			return 215;
		case '╔':
			return 201;
		case '╗':
			return 187;
		case '╚':
			return 200;
		case '╝':
			return 188;
		case '║':
			return 186;
		case '═':
			return 205;
		case '╩':
			return 202;
		case '╠':
			return 204;
		case '╦':
			return 203;
		case '╣':
			return 185;
		case '╬':
			return 206;
		case '░':
			return 176;
		case '▒':
			return 177;
		case '▓':
			return 178;
		case '█':
			return 219;
		case '▄':
			return 220;
		case '▀':
			return 221;
		case 'ρ':
			return 222;
		case 'ι':
			return 223;
		case 'α':
			return 224;
		case 'β':
			return 225;
		case 'γ':
			return 226;
		case 'π':
			return 227;
		case 'Σ':
			return 228;
		case '∑':
			return 228;
		case 'σ':
			return 229;
		case 'μ':
			return 230;
		case 'µ':
			return 230;
		case 'τ':
			return 231;
		case 'Φ':
			return 232;
		case 'Θ':
			return 233;
		case 'θ':
			return 233;
		case 'Ω':
			return 234;
		case 'δ':
			return 235;
		case '∞':
			return 236;
		case 'φ':
			return 237;
		case 'ε':
			return 238;
		case 'ω':
			return 239;
		case '≡':
			return 240;
		case '±':
			return 241;
		case '≥':
			return 242;
		case '≤':
			return 243;
		case '⌐':
			return 244;
		case '¬':
			return 245;
		case '÷':
			return 246;
		case '≈':
			return 247;
		case '°':
		case 'º':
			return 248;
		case '…':
			return 249;
		case '·':
			return 250;
		case '†':
			return 251;
		case '✝':
			return 251;
		case '☤':
			return 252;
		case 'Δ':
		case '∆':
			return 253;
		case '❄':
			return 254;
		case '┊':
			return 255;
		default:
			return -1;
		}
	}

	public static char NormalizeInputGlyph(char inGlyph)
	{
		switch (inGlyph)
		{
		case '；':
			return ';';
		case '，':
			return ',';
		case '。':
		case '．':
			return '.';
		case '！':
			return '!';
		case '？':
			return '?';
		case '‘':
		case '’':
		case '＇':
			return '\'';
		case '"':
		case '“':
		case '”':
			return '＂';
		case '[':
			return '［';
		case ']':
			return '］';
		case '{':
			return '｛';
		case '}':
			return '｝';
		case '：':
			return ':';
		case '（':
			return '(';
		case '）':
			return ')';
		case '＃':
			return '#';
		case '＄':
			return '$';
		case '％':
			return '%';
		case '＆':
			return '&';
		case '｜':
			return '|';
		case '＊':
			return '*';
		case '＋':
			return '+';
		case '－':
			return '-';
		case '／':
			return '/';
		case '＜':
			return '<';
		case '＞':
			return '>';
		case '＝':
			return '=';
		case '\uff3e':
			return '^';
		case '\u2002':
			return ' ';
		default:
			return inGlyph;
		}
	}

	public static string NormalizeInputString(string inStr)
	{
		bool flag = false;
		foreach (char num in inStr)
		{
			char c = NormalizeInputGlyph(num);
			if (num != c)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int j = 0; j < inStr.Length; j++)
			{
				char inGlyph = inStr[j];
				inGlyph = NormalizeInputGlyph(inGlyph);
				stringBuilder.Append(inGlyph);
			}
			return stringBuilder.ToString();
		}
		return inStr;
	}
}
