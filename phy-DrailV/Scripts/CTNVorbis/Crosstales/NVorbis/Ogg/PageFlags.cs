using System;

namespace Crosstales.NVorbis.Ogg
{
	[Flags]
	internal enum PageFlags
	{
		None = 0,
		ContinuesPacket = 1,
		BeginningOfStream = 2,
		EndOfStream = 4
	}
}
