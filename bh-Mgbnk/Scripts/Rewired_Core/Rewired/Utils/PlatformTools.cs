namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class PlatformTools
	{
		public static bool IsSysVersionInRange(string min, string max)
		{
			return false;
		}
	}
}
