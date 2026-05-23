using System;

namespace UImGui
{
	[Flags]
	internal enum ScriptGlyphRanges
	{
		Default = 1,
		Cyrillic = 2,
		Japanese = 4,
		Korean = 8,
		Thai = 0x10,
		Vietnamese = 0x20,
		ChineseSimplified = 0x40,
		ChineseFull = 0x80,
		Custom = 0x100
	}
}
