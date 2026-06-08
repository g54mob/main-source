using System.Collections.Generic;

namespace RTLTMPro
{
	public static class LigatureFixer
	{
		private static readonly List<char> LtrTextHolder = new List<char>(512);

		private static readonly List<char> TagTextHolder = new List<char>(512);

		private static readonly Dictionary<char, char> MirroredCharsMap = new Dictionary<char, char>
		{
			['('] = ')',
			[')'] = '(',
			['»'] = '«',
			['«'] = '»'
		};

		private static readonly HashSet<char> MirroredCharsSet = new HashSet<char>(MirroredCharsMap.Keys);

		private static void FlushBufferToOutput(List<char> buffer, FastStringBuilder output)
		{
			for (int i = 0; i < buffer.Count; i++)
			{
				output.Append(buffer[buffer.Count - 1 - i]);
			}
			buffer.Clear();
		}

		public static void Fix(FastStringBuilder input, FastStringBuilder output, bool farsi, bool fixTextTags, bool preserveNumbers)
		{
			LtrTextHolder.Clear();
			TagTextHolder.Clear();
			for (int num = input.Length - 1; num >= 0; num--)
			{
				bool flag = num > 0 && num < input.Length - 1;
				bool flag2 = num == 0;
				bool flag3 = num == input.Length - 1;
				char c = input.Get(num);
				char c2 = '\0';
				if (!flag3)
				{
					c2 = input.Get(num + 1);
				}
				char c3 = '\0';
				if (!flag2)
				{
					c3 = input.Get(num - 1);
				}
				if (fixTextTags && c == '>')
				{
					bool flag4 = false;
					int num2 = num;
					TagTextHolder.Add(c);
					for (int num3 = num - 1; num3 >= 0; num3--)
					{
						char c4 = input.Get(num3);
						TagTextHolder.Add(c4);
						if (c4 == '<')
						{
							if (input.Get(num3 + 1) != ' ')
							{
								flag4 = true;
								num2 = num3;
							}
							break;
						}
					}
					if (flag4)
					{
						FlushBufferToOutput(LtrTextHolder, output);
						FlushBufferToOutput(TagTextHolder, output);
						num = num2;
						continue;
					}
					TagTextHolder.Clear();
				}
				if (char.IsPunctuation(c) || char.IsSymbol(c))
				{
					if (MirroredCharsSet.Contains(c))
					{
						bool num4 = TextUtils.IsRTLCharacter(c3);
						bool flag5 = TextUtils.IsRTLCharacter(c2);
						if (num4 || flag5)
						{
							c = MirroredCharsMap[c];
						}
					}
					if (flag)
					{
						bool flag6 = TextUtils.IsRTLCharacter(c3);
						bool flag7 = TextUtils.IsRTLCharacter(c2);
						bool flag8 = char.IsWhiteSpace(c2);
						bool flag9 = char.IsWhiteSpace(c3);
						bool flag10 = c == '_';
						bool flag11 = c == '.' || c == '،' || c == '؛';
						if ((flag7 && flag6) || (flag9 && flag11) || (flag8 && flag6) || (flag7 && flag9) || ((flag7 || flag6) && flag10))
						{
							FlushBufferToOutput(LtrTextHolder, output);
							output.Append(c);
						}
						else
						{
							LtrTextHolder.Add(c);
						}
					}
					else if (flag3)
					{
						LtrTextHolder.Add(c);
					}
					else if (flag2)
					{
						output.Append(c);
					}
					continue;
				}
				if (flag)
				{
					bool flag12 = TextUtils.IsEnglishLetter(c3);
					bool flag13 = TextUtils.IsEnglishLetter(c2);
					bool flag14 = TextUtils.IsNumber(c3, preserveNumbers, farsi);
					bool flag15 = TextUtils.IsNumber(c2, preserveNumbers, farsi);
					bool flag16 = char.IsSymbol(c3);
					bool flag17 = char.IsSymbol(c2);
					if (c == ' ' && (flag13 || flag15 || flag17) && (flag12 || flag14 || flag16))
					{
						LtrTextHolder.Add(c);
						continue;
					}
				}
				if (TextUtils.IsEnglishLetter(c) || TextUtils.IsNumber(c, preserveNumbers, farsi))
				{
					LtrTextHolder.Add(c);
					continue;
				}
				if ((c >= '\ud800' && c <= '\udbff') || (c >= '\udc00' && c <= '\udfff'))
				{
					LtrTextHolder.Add(c);
					continue;
				}
				FlushBufferToOutput(LtrTextHolder, output);
				if (c != '\uffff' && c != '\u200c')
				{
					output.Append(c);
				}
			}
			FlushBufferToOutput(LtrTextHolder, output);
		}
	}
}
