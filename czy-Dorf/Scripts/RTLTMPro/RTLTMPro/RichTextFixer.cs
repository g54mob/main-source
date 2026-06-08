namespace RTLTMPro
{
	public static class RichTextFixer
	{
		public enum TagType
		{
			None = 0,
			Opening = 1,
			Closing = 2,
			SelfContained = 3
		}

		public struct Tag
		{
			public int Start;

			public int End;

			public int HashCode;

			public TagType Type;
		}

		public static void Fix(FastStringBuilder text)
		{
			int num = 0;
			while (num < text.Length)
			{
				FindTag(text, num, out var tag);
				if (tag.Type != TagType.None)
				{
					text.Reverse(tag.Start, tag.End - tag.Start + 1);
					num = tag.End;
					num++;
					continue;
				}
				break;
			}
		}

		public static void FindTag(FastStringBuilder str, int start, out Tag tag)
		{
			int num = start;
			while (num < str.Length)
			{
				if (str.Get(num) != '<')
				{
					num++;
					continue;
				}
				bool flag = true;
				tag.HashCode = 0;
				for (int i = num + 1; i < str.Length; i++)
				{
					char c = str.Get(i);
					if (flag)
					{
						if (char.IsLetter(c))
						{
							if (tag.HashCode == 0)
							{
								tag.HashCode = c.GetHashCode();
							}
							else
							{
								tag.HashCode = (tag.HashCode * 397) ^ c.GetHashCode();
							}
						}
						else if (tag.HashCode != 0)
						{
							flag = false;
						}
					}
					if (i == num + 1 && c == ' ')
					{
						break;
					}
					switch (c)
					{
					case '>':
						tag.Start = num;
						tag.End = i;
						if (str.Get(i - 1) == '/')
						{
							tag.Type = TagType.SelfContained;
						}
						else if (str.Get(num + 1) == '/')
						{
							tag.Type = TagType.Closing;
						}
						else
						{
							tag.Type = TagType.Opening;
						}
						return;
					default:
						continue;
					case '<':
						break;
					}
					break;
				}
				num++;
			}
			tag.Start = 0;
			tag.End = 0;
			tag.Type = TagType.None;
			tag.HashCode = 0;
		}
	}
}
