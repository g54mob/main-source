namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class SystemInfo
	{
		public static readonly bool is64Bit;

		static SystemInfo()
		{
		}
	}
}
