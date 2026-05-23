using System;

namespace Deform
{
	[Flags]
	public enum DataFlags
	{
		None = 0,
		Vertices = 1,
		Normals = 2,
		Tangents = 4,
		UVs = 8,
		Colors = 0x10,
		Triangles = 0x20,
		MaskVertices = 0x40,
		Bounds = 0x80,
		All = -1
	}
}
