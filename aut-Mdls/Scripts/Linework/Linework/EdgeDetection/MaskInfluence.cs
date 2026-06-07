using System;

namespace Linework.EdgeDetection
{
	[Flags]
	public enum MaskInfluence
	{
		Nothing = 0,
		Sections = 1,
		Depth = 2,
		Normals = 4,
		Luminance = 8,
		All = -1
	}
}
