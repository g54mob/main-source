namespace Motorways.Utility
{
	public static class MathExtensions
	{
		public static int Mod(int a, int n)
		{
			int num = a % n;
			if (num >= 0)
			{
				return num;
			}
			return num + n;
		}
	}
}
