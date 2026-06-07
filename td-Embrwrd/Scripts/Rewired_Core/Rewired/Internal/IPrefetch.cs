namespace Rewired.Internal
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal interface IPrefetch
	{
		void Prefetch();
	}
}
