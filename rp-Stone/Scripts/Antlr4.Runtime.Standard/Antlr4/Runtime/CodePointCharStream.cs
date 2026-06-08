using System;
using System.Text;

namespace Antlr4.Runtime
{
	public class CodePointCharStream : BaseInputCharStream
	{
		private int[] data;

		public CodePointCharStream(string input)
		{
			data = new int[input.Length];
			int num = 0;
			int num2;
			for (int i = 0; i < input.Length; i += ((num2 <= 65535) ? 1 : 2))
			{
				num2 = char.ConvertToUtf32(input, i);
				data[num++] = num2;
				if (num > data.Length)
				{
					Array.Resize(ref data, data.Length * 2);
				}
			}
			n = num;
		}

		protected override int ValueAt(int i)
		{
			return data[i];
		}

		protected override string ConvertDataToString(int start, int count)
		{
			StringBuilder stringBuilder = new StringBuilder(count);
			for (int i = start; i < start + count; i++)
			{
				stringBuilder.Append(char.ConvertFromUtf32(data[i]));
			}
			return stringBuilder.ToString();
		}
	}
}
