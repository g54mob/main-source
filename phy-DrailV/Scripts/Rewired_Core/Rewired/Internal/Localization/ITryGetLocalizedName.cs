namespace Rewired.Internal.Localization
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal interface ITryGetLocalizedName
	{
		bool TryGetLocalizedName(out string value);
	}
}
