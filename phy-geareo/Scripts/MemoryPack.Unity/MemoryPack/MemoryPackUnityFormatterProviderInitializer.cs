using UnityEngine;

namespace MemoryPack
{
	public static class MemoryPackUnityFormatterProviderInitializer
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		public static void RegisterInitialFormatters()
		{
		}

		private static void UnityRegister<T>() where T : struct
		{
		}
	}
}
