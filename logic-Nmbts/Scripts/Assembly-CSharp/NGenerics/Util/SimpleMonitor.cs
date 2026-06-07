using System;

namespace NGenerics.Util
{
	[Serializable]
	internal class SimpleMonitor : IDisposable
	{
		private int busyCount;

		public bool Busy
		{
			get
			{
				return busyCount > 0;
			}
		}

		public void Dispose()
		{
			busyCount--;
			GC.SuppressFinalize(this);
		}

		public void Enter()
		{
			busyCount++;
		}
	}
}
