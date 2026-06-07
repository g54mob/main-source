using System.Diagnostics;

namespace MoreMountains.Tools
{
	public struct MMSpeedTestItem
	{
		public string TestID;

		public Stopwatch Timer;

		public MMSpeedTestItem(string testID)
		{
			TestID = testID;
			Timer = Stopwatch.StartNew();
		}
	}
}
