using Unity.Entities;

namespace Pug.ECS.Hybrid
{
	public struct GraphicalObjectSpawnedCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
	{
		public bool Instantiated;

		public int Index;

		public Entity PrimaryEntity;
	}
}
