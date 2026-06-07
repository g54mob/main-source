using System;
using Zenject;

namespace VampireSurvivors.App.Scripts.Tools
{
	public class MemorySystem : IInitializable, IDisposable
	{
		public delegate void LowOnMemoryEvent();

		public static LowOnMemoryEvent OnLowMemoryEvent;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static long GetTotalAllocatedMemoryInBytes()
		{
			return 0L;
		}

		public static void LogMemoryStats()
		{
		}

		private void OnApplicationLowOnMemory()
		{
		}
	}
}
