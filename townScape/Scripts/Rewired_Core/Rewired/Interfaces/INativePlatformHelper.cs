namespace Rewired.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface INativePlatformHelper
	{
		bool isApplicationFocused { get; }
	}
}
