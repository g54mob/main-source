namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal class SteamAction
	{
		public readonly string name;

		public readonly ulong handle;

		public SteamAction(string name, ulong handle)
		{
		}
	}
}
