using System.Text;
using HandlebarsDotNet.StringUtils;

namespace HandlebarsDotNet.Extensions
{
	public static class StringBuilderExtensions
	{
		public static StringBuilder Trim(this StringBuilder builder, char @char = ' ')
		{
			return builder.TrimStart(@char).TrimEnd(@char);
		}

		public static StringBuilder TrimStart(this StringBuilder builder, char @char = ' ')
		{
			int num = 0;
			for (int i = 0; i < builder.Length && builder[i] == @char; i++)
			{
				num++;
			}
			return builder.Remove(0, num);
		}

		public static StringBuilder TrimEnd(this StringBuilder builder, char @char = ' ')
		{
			int num = 0;
			int num2 = builder.Length - 1;
			while (num2 >= 0 && builder[num2] == @char)
			{
				num++;
				num2--;
			}
			return builder.Remove(builder.Length - num, num);
		}

		public static StringBuilder Append(this StringBuilder builder, in Substring substring)
		{
			return builder.Append(substring.String, substring.Start, substring.Length);
		}
	}
}
