using System;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public enum VegetationRotationType
	{
		RotateY = 0,
		RotateXYZ = 1,
		FollowTerrain = 2,
		FollowTerrainScale = 3,
		NoRotation = 4
	}
}
