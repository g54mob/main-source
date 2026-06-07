using System;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public enum ColliderType
	{
		Disabled = 0,
		Capsule = 1,
		Sphere = 2,
		Box = 3,
		Mesh = 4,
		CustomMesh = 5,
		FromPrefab = 6
	}
}
