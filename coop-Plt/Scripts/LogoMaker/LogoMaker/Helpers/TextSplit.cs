using System.Collections.Generic;
using System.Linq;

namespace LogoMaker.Helpers
{
	public static class TextSplit
	{
		public static List<string> SplitString(string input)
		{
			int num = input.Count((char c) => c == ' ');
			string[] array = input.Split(' ');
			if (num <= 1)
			{
				return array.ToList();
			}
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num2 = 0;
			for (int num3 = 0; num3 < array.Length; num3++)
			{
				string text = array[num3];
				if (num2 > input.Length / 2 || num3 == array.Length - 1)
				{
					list2.Add(text);
					continue;
				}
				list.Add(text);
				num2 += text.Length + 1;
			}
			return new List<string>
			{
				string.Join(" ", list),
				string.Join(" ", list2)
			};
		}
	}
}
