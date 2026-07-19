using System;

namespace UniJSON
{
	public static class Utf8StringSplitterExtensions
	{
		public static Utf8String SplitInteger(this Utf8String src)
		{
			int num = 0;
			if (src[0] == 43 || src[0] == 45)
			{
				num++;
			}
			int i;
			for (i = num; i < src.ByteLength && src[i] >= 48 && src[i] <= 57; i++)
			{
			}
			if (num == i)
			{
				throw new FormatException();
			}
			return src.Subbytes(0, i);
		}
	}
}
