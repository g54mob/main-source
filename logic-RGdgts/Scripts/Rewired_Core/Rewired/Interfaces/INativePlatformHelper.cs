namespace Rewired.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface INativePlatformHelper
	{
		bool isApplicationFocused { get; }
	}
}
