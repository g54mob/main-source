using System;
using System.Collections.Generic;

namespace Trivial.CodeSecurity.LoopDetection
{
	public class ExecutionTimingServices
	{
		private static Dictionary<int, DateTime> timeLookups = new Dictionary<int, DateTime>();

		public static void EnterTimedExecutionContext(int executionHash)
		{
			if (timeLookups.TryGetValue(executionHash, out var value))
			{
				if ((DateTime.Now - value).TotalSeconds > 5.0)
				{
					throw new TimeoutException("Execution was aborted to because an infinite loop was detected");
				}
			}
			else
			{
				timeLookups.Add(executionHash, DateTime.Now);
			}
		}

		public static void ExitTimedExecutionContext(int executionHash)
		{
			if (timeLookups.ContainsKey(executionHash))
			{
				timeLookups.Remove(executionHash);
			}
		}
	}
}
