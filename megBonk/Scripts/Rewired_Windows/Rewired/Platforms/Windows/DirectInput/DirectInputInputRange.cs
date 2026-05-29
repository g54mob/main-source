namespace Rewired.Platforms.Windows.DirectInput
{
	public struct DirectInputInputRange
	{
		public int Minimum;

		public int Maximum;

		public const int NoMinimum = -2147483648;

		public const int NoMaximum = 2147483647;

		public DirectInputInputRange(int P_0, int P_1)
		{
			Minimum = 0;
			Maximum = 0;
		}
	}
}
