namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class ExtensionMethods
	{
		public static bool IsNullOrDestroyed(this object @object)
		{
			return false;
		}
	}
}
