namespace KitchenData
{
	public static class IntExtensions
	{
		public static bool GetBit(this int b, int pos)
		{
			return (b & (1 << pos)) != 0;
		}

		public static int SetBit(this int b, int pos)
		{
			return b | (1 << pos);
		}

		public static int CountBits(this int b)
		{
			int num = 0;
			while (b > 0)
			{
				b &= b - 1;
				num++;
			}
			return num;
		}
	}
}
