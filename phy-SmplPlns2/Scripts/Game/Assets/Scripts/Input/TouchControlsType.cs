using Jundroo.Common.Settings;

namespace Assets.Scripts.Input
{
	public enum TouchControlsType
	{
		[EnumOption("Off", "Touch Controls Disabled")]
		Off = 0,
		[EnumOption("Mode1 - int'l", "International Touch Control Mode")]
		Mode1 = 1,
		[EnumOption("Mode2 - USA", "USA Touch Control Mode")]
		Mode2 = 2
	}
}
