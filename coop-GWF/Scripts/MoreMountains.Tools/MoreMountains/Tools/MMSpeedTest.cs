using System.Collections.Generic;

namespace MoreMountains.Tools
{
	public static class MMSpeedTest
	{
		private static readonly Dictionary<string, MMSpeedTestItem> _speedTests = new Dictionary<string, MMSpeedTestItem>();

		public static void StartTest(string testID)
		{
			if (_speedTests.ContainsKey(testID))
			{
				_speedTests.Remove(testID);
			}
			MMSpeedTestItem value = new MMSpeedTestItem(testID);
			_speedTests.Add(testID, value);
		}

		public static void EndTest(string testID)
		{
			if (_speedTests.ContainsKey(testID))
			{
				_speedTests[testID].Timer.Stop();
				float num = (float)_speedTests[testID].Timer.ElapsedMilliseconds / 1000f;
				_speedTests.Remove(testID);
				MMDebug.DebugLogInfo("<color=red>MMSpeedTest</color> [Test " + testID + "] test duration : " + num + "s");
			}
		}
	}
}
