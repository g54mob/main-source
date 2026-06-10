namespace Rewired.Platforms.PS4
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IPS4ControllerSetExtensionSource : ggTkdwJMwyHZjrvxNfFQYoCehWyD
	{
		int controllerCount { get; }

		IPS4ControllerExtensionSource GetController(int index);
	}
}
