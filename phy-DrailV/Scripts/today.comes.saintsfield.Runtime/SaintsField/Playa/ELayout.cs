using System;

namespace SaintsField.Playa
{
	[Flags]
	public enum ELayout
	{
		Vertical = 0,
		Horizontal = 1,
		Background = 2,
		TitleOut = 4,
		Foldout = 8,
		Collapse = 0x10,
		Tab = 0x20,
		Title = 0x40,
		TitleBox = 0x46,
		FoldoutBox = 0x4E,
		CollapseBox = 0x56
	}
}
