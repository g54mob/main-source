using System;

namespace DV.ShaderStripping
{
	[Flags]
	public enum PostProcessingKeyword
	{
		None = 0,
		BLOOM = 1,
		BLOOM_LOW = 2,
		CHROMATIC_ABERRATION = 4,
		CHROMATIC_ABERRATION_LOW = 8,
		COLOR_GRADING_HDR_2D = 0x10,
		COLOR_GRADING_HDR_3D = 0x20,
		COLOR_GRADING_LDR_2D = 0x40,
		DISTORT = 0x80,
		GRAIN = 0x100,
		VIGNETTE = 0x200
	}
}
