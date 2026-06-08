namespace Jobberwocky.TriangleNet.Tools
{
	public class Statistic
	{
		public static long InCircleCount = 0L;

		public static long InCircleAdaptCount = 0L;

		public static long CounterClockwiseCount = 0L;

		public static long CounterClockwiseAdaptCount = 0L;

		public static long Orient3dCount = 0L;

		public static long HyperbolaCount = 0L;

		public static long CircumcenterCount = 0L;

		public static long CircleTopCount = 0L;

		public static long RelocationCount = 0L;

		private static readonly int[] plus1Mod3 = new int[3] { 1, 2, 0 };

		private static readonly int[] minus1Mod3 = new int[3] { 2, 0, 1 };
	}
}
