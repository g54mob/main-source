using System;

namespace Linework.EdgeDetection
{
	[Flags]
	public enum DiscontinuityInput
	{
		None = 0,
		Depth = 1,
		Normals = 2,
		Luminance = 4,
		Sections = 8,
		All = -1
	}
}
