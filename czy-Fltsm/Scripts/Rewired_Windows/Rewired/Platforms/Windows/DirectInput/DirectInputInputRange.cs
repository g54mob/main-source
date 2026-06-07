namespace Rewired.Platforms.Windows.DirectInput
{
	public struct DirectInputInputRange
	{
		public int Minimum;

		public int Maximum;

		public const int NoMinimum = int.MinValue;

		public const int NoMaximum = int.MaxValue;

		public DirectInputInputRange(int P_0, int P_1)
		{
			this = default(DirectInputInputRange);
			Minimum = P_0;
			Maximum = P_1;
		}
	}
}
