using System;

namespace BCnEncoder.Shared.ImageFiles
{
	[Flags]
	public enum PixelFormatFlags : uint
	{
		DdpfAlphaPixels = 1u,
		DdpfAlpha = 2u,
		DdpfFourcc = 4u,
		DdpfRgb = 0x40u,
		DdpfYuv = 0x200u,
		DdpfLuminance = 0x20000u
	}
}
