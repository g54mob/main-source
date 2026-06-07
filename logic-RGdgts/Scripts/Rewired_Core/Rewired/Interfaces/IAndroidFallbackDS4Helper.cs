namespace Rewired.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IAndroidFallbackDS4Helper
	{
		bool IsDS4KeyMapped(int unityJoystickArrayIndex);

		bool IsDS4(string name);
	}
}
