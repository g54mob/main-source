namespace Toybox.Port
{
	public static class PlatformSaveManager
	{
		private static IPlatformSave s_platformSave;

		public static void SetPlatformSave(IPlatformSave platformSave)
		{
		}

		public static byte[] Load(string filePath)
		{
			return null;
		}

		public static bool HaveFile(string filePath)
		{
			return false;
		}

		public static void Save(string filePath, byte[] bytes)
		{
		}

		public static void DeleteFile(string filePath)
		{
		}

		public static string PathPrefix()
		{
			return null;
		}
	}
}
