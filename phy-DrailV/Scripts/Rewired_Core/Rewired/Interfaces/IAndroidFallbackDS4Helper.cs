namespace Rewired.Interfaces
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal interface IAndroidFallbackDS4Helper
	{
		bool IsDS4KeyMapped(int unityJoystickArrayIndex);

		bool IsDS4(string name);
	}
}
