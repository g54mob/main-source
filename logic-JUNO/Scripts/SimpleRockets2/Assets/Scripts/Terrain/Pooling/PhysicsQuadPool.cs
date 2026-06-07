using UnityEngine;

namespace Assets.Scripts.Terrain.Pooling
{
	public class PhysicsQuadPool : GameObjectPool<MeshCollider>
	{
		public PhysicsQuadPool(int initialSize)
			: base("PhysicsQuadPool", "Planets/PlanetPhysicsQuad", initialSize)
		{
		}
	}
}
