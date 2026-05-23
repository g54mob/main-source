using Libs;

namespace Factory.FieldData
{
	public enum eMapExtension
	{
		None = 0,
		[RectIntValue(0, 0, 22, 20)]
		Area1 = 1,
		[RectIntValue(22, 0, 42, 20)]
		Area2 = 2,
		[RectIntValue(64, 0, 22, 20)]
		Area3 = 3,
		[RectIntValue(0, 20, 22, 35)]
		Area4 = 4,
		[RectIntValue(22, 20, 42, 35)]
		Area5 = 5,
		[RectIntValue(64, 20, 22, 35)]
		Area6 = 6,
		[RectIntValue(0, 55, 22, 20)]
		Area7 = 7,
		[RectIntValue(22, 55, 42, 20)]
		Area8 = 8,
		[RectIntValue(64, 55, 22, 20)]
		Area9 = 9
	}
}
