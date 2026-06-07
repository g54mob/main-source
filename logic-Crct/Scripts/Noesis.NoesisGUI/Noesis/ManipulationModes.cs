using System;

namespace Noesis
{
	[Flags]
	public enum ManipulationModes
	{
		None = 0,
		TranslateX = 1,
		TranslateY = 2,
		Translate = 3,
		Rotate = 4,
		Scale = 8,
		All = 0xF
	}
}
