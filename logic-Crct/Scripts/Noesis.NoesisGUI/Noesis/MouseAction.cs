using System.ComponentModel;

namespace Noesis
{
	[TypeConverter(typeof(MouseActionConverter))]
	public enum MouseAction
	{
		None = 0,
		LeftClick = 1,
		RightClick = 2,
		MiddleClick = 3,
		WheelClick = 4,
		LeftDoubleClick = 5,
		RightDoubleClick = 6,
		MiddleDoubleClick = 7
	}
}
