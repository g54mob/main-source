namespace Mono.Btls
{
	internal static class MonoBtlsX509StoreManager
	{
		private static bool initialized;

		private static string machineTrustedRootPath;

		private static string machineIntermediateCAPath;

		private static string machineUntrustedPath;

		private static string userTrustedRootPath;

		private static string userIntermediateCAPath;

		private static string userUntrustedPath;

		private static void Initialize()
		{
		}

		private static void DoInitialize()
		{
		}

		public static string GetStorePath(MonoBtlsX509StoreType type)
		{
			return null;
		}
	}
}
