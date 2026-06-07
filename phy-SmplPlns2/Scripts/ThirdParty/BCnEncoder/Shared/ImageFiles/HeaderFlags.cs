using System;

namespace BCnEncoder.Shared.ImageFiles
{
	[Flags]
	public enum HeaderFlags : uint
	{
		DdsdCaps = 1u,
		DdsdHeight = 2u,
		DdsdWidth = 4u,
		DdsdPitch = 8u,
		DdsdPixelformat = 0x1000u,
		DdsdMipmapcount = 0x20000u,
		DdsdLinearsize = 0x80000u,
		DdsdDepth = 0x800000u,
		Required = 0x1007u
	}
}
