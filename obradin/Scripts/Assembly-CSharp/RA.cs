using Rewired.Dev;

public static class RA
{
	[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Pause")]
	public const int Pause = 27;

	[ActionIdFieldInfo(categoryName = "Default", friendlyName = "Manifest")]
	public const int Manifest = 28;

	[ActionIdFieldInfo(categoryName = "Play", friendlyName = "Move X")]
	public const int Move_X = 0;

	[ActionIdFieldInfo(categoryName = "Play", friendlyName = "Move Y")]
	public const int Move_Y = 1;

	[ActionIdFieldInfo(categoryName = "Play", friendlyName = "Look X")]
	public const int Look_X = 2;

	[ActionIdFieldInfo(categoryName = "Play", friendlyName = "Look Y")]
	public const int Look_Y = 3;

	[ActionIdFieldInfo(categoryName = "Play", friendlyName = "Action")]
	public const int Action = 4;

	[ActionIdFieldInfo(categoryName = "Play", friendlyName = "Zoom")]
	public const int Zoom = 53;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui X")]
	public const int Ui_X = 18;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui Y")]
	public const int Ui_Y = 19;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui Submit")]
	public const int Ui_Submit = 17;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui Back")]
	public const int Ui_Back = 10;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui PagePrev")]
	public const int Ui_PagePrev = 21;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui PageNext")]
	public const int Ui_PageNext = 22;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui PagePrevStick")]
	public const int Ui_PagePrevStick = 51;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui PageNextStick")]
	public const int Ui_PageNextStick = 52;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui ScrollUp")]
	public const int Ui_ScrollUp = 37;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui ScrollDown")]
	public const int Ui_ScrollDown = 38;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui MouseButton")]
	public const int Ui_MouseButton = 44;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui MouseX")]
	public const int Ui_MouseX = 47;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui MouseY")]
	public const int Ui_MouseY = 48;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui Scroll")]
	public const int Ui_Scroll = 49;

	[ActionIdFieldInfo(categoryName = "Ui", friendlyName = "Ui Toc")]
	public const int Ui_Toc = 50;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Enable0")]
	public const int Debug_Enable0 = 11;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Enable1")]
	public const int Debug_Enable1 = 12;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Enable2")]
	public const int Debug_Enable2 = 39;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Up")]
	public const int Debug_Up = 31;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Down")]
	public const int Debug_Down = 32;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Left")]
	public const int Debug_Left = 33;

	[ActionIdFieldInfo(categoryName = "Debug", friendlyName = "Debug Right")]
	public const int Debug_Right = 40;
}
