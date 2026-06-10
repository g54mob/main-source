using System;

namespace NSMedieval
{
	public class DebugTimerJanitor : IDisposable
	{
		private string name;

		private bool isTrace;

		public void Dispose()
		{
		}

		public static DebugTimerJanitor EditorTrace(string name)
		{
			return null;
		}
	}
}
