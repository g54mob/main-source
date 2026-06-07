using System;

namespace BCnEncoder.Shared.ImageFiles
{
	[Flags]
	public enum HeaderCaps : uint
	{
		DdscapsComplex = 8u,
		DdscapsMipmap = 0x400000u,
		DdscapsTexture = 0x1000u
	}
}
