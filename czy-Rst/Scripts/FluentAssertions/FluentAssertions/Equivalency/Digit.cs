using System.Collections.Generic;

namespace FluentAssertions.Equivalency
{
	internal class Digit
	{
		private readonly int length;

		private readonly Digit nextDigit;

		private int index;

		public Digit(int length, Digit nextDigit)
		{
			this.length = length;
			this.nextDigit = nextDigit;
		}

		public int[] GetIndices()
		{
			List<int> list = new List<int>();
			for (Digit digit = this; digit != null; digit = digit.nextDigit)
			{
				list.Add(digit.index);
			}
			return list.ToArray();
		}

		public bool Increment()
		{
			bool flag = nextDigit?.Increment() ?? false;
			if (!flag)
			{
				if (index < length - 1)
				{
					index++;
					flag = true;
				}
				else
				{
					index = 0;
				}
			}
			return flag;
		}
	}
}
