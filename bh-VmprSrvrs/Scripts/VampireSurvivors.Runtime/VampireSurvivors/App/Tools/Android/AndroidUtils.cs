namespace VampireSurvivors.App.Tools.Android
{
	public static class AndroidUtils
	{
		private const string PLAY_STORE_PACKAGE_NAME = "com.android.vending";

		public static bool WasPackageInstalledViaPlayStore(string packageName)
		{
			return false;
		}

		private static string GetInstallerName(string packageName)
		{
			return null;
		}
	}
}
