using System;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	[Flags]
	public enum SplineMeshBuilderMeshDataFlags
	{
		None = 0,
		Tangents = 1,
		Colors = 2,
		UV0 = 4,
		UV1 = 8,
		UV2 = 0x10,
		UV3 = 0x20
	}
}
