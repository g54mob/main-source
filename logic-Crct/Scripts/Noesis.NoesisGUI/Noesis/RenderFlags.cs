using System;

namespace Noesis
{
	[Flags]
	public enum RenderFlags
	{
		Wireframe = 1,
		ColorBatches = 2,
		Overdraw = 4,
		FlipY = 8,
		PPAA = 0x10,
		LCD = 0x20
	}
}
