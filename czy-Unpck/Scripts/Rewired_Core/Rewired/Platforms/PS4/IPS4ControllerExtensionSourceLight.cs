namespace Rewired.Platforms.PS4
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IPS4ControllerExtensionSourceLight
	{
		void SetLightColor(int red, int green, int blue);

		void ResetLight();
	}
}
