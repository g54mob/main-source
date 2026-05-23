namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class ExtensionMethods
	{
		public static bool IsNullOrDestroyed(this object @object)
		{
			return false;
		}
	}
}
