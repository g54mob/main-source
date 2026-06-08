using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Kitchen.Utility
{
	public static class UntilTask
	{
		private static int CheckFrequencyMS = 100;

		public static async Task<bool> WaitForTrue(Func<bool> func, TimeSpan timeout = default(TimeSpan))
		{
			if (timeout == default(TimeSpan))
			{
				timeout = TimeSpan.FromSeconds(5.0);
			}
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (!func())
			{
				if ((double)stopwatch.ElapsedMilliseconds > timeout.TotalMilliseconds)
				{
					return false;
				}
				await Task.Delay(CheckFrequencyMS);
			}
			return true;
		}
	}
}
