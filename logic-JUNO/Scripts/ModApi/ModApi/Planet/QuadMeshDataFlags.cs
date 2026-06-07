using System;

namespace ModApi.Planet
{
	[Flags]
	public enum QuadMeshDataFlags
	{
		None = 0,
		Color = 1,
		UV = 2,
		UV2 = 4,
		UV3 = 8,
		UV4 = 0x10,
		Tangents = 0x10,
		All = 0x1F
	}
}
