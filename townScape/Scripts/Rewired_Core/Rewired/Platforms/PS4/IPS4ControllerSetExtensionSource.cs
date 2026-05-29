namespace Rewired.Platforms.PS4
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IPS4ControllerSetExtensionSource : vluPtLjiOOBEtbozXjooaoxPcAqj
	{
		int controllerCount { get; }

		IPS4ControllerExtensionSource GetController(int index);
	}
}
