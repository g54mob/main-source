using System.Text;
using UnityEngine;

namespace NSMedieval
{
	public static class MemoryStats
	{
		private static long monoUsedMemory;

		private static long totalReservedMemory;

		private static long reservedUnusedMemory;

		private static long temporaryMemory;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			monoUsedMemory = 0L;
			totalReservedMemory = 0L;
			reservedUnusedMemory = 0L;
			temporaryMemory = 0L;
		}

		public static string LogMemoryUsage()
		{
			return new StringBuilder().ToString();
		}
	}
}
