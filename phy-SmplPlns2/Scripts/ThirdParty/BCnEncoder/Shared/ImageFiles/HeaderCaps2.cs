using System;

namespace BCnEncoder.Shared.ImageFiles
{
	[Flags]
	public enum HeaderCaps2 : uint
	{
		Ddscaps2Cubemap = 0x200u,
		Ddscaps2CubemapPositivex = 0x400u,
		Ddscaps2CubemapNegativex = 0x800u,
		Ddscaps2CubemapPositivey = 0x1000u,
		Ddscaps2CubemapNegativey = 0x2000u,
		Ddscaps2CubemapPositivez = 0x4000u,
		Ddscaps2CubemapNegativez = 0x8000u,
		Ddscaps2Volume = 0x200000u
	}
}
