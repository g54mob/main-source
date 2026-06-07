namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class SystemInfo
	{
		public static readonly bool is64Bit;

		static SystemInfo()
		{
		}
	}
}
