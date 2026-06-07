using System;

namespace VisualDesignCafe.Nature
{
	internal class TimerScope : IDisposable
	{
		private readonly ILog _log;

		public long ElapsedMiliseconds => 0L;

		public TimerScope(ILog log)
		{
		}

		public void Dispose()
		{
		}
	}
}
