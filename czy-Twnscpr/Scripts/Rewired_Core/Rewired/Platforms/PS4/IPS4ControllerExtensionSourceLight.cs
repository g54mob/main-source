namespace Rewired.Platforms.PS4
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IPS4ControllerExtensionSourceLight
	{
		void SetLightColor(int red, int green, int blue);

		void ResetLight();
	}
}
